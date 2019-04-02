Imports System.Text.RegularExpressions
Imports FastColoredTextBoxNS

Public Class Main
    Public LinesToExecute As Integer() = {-1, -1}
    Public CodeToExecute As String = ""
    Public CodeToExecutePos As Integer() = {0, 0}
    Public WithEvents _commandExecutor As New OCaml()
    Public MenuHandling As MenuHandler
    Public ThemeManager As New ThemeManager()

    ''' Démarrage et fermeture
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.Autoreset Then
            MsgBox("A des fins de tests, les paramètres seront automatiquements réinitialisés à chaque redémarrages de l'application. Pour désactiver cette fonctionnalité, veuillez la décocher dans le menu Paramètres.")
            AutoresetToolStripMenuItem.Checked = True
        Else
            AutoresetToolStripMenuItem.Checked = False
        End If

        My.Settings.Upgrade()

        AddNewPage()

        OutputBox.Font = New Font(My.Settings.Font_Family, My.Settings.Font_Size, My.Settings.Font_Style)
        OutputBox.SelectionTabs = {32, 64, 96, 128, 160, 192, 224, 256, 288, 320}

        If My.Settings.Detailed_Output Then
            FullOutputMenuItem.Enabled = False
            FullOutputMenuItem.Checked = True
        Else
            PartialOutputMenuItem.Enabled = False
            PartialOutputMenuItem.Checked = True
        End If

        If My.Settings.Theme = ThemeManager.Themes.DarkTheme Then
            DarkModeMenuItem.Enabled = False
            DarkModeMenuItem.Checked = True
        Else
            LightModeMenuItem.Enabled = False
            LightModeMenuItem.Checked = True
        End If

        If My.Settings.Autosave Then
            EnableAutoSaveMenuItem.Checked = True
        End If

        StartOcaml()

        AutoSaveTimer.Interval = My.Settings.Autosave_delay * 1000
        If My.Settings.Autosave Then
            AutoSaveTimer.Start()
        End If

        AddHandler TabControl.TabClosed, AddressOf OnTabClose
        AddHandler TabControl.DrawItem, AddressOf TabControl_DrawItem

        TabControl.DisplayStyleProvider.ShowTabCloser = True

        MenuHandling = New MenuHandler()
    End Sub

    Private Sub StartOcaml()
        While Not (System.IO.File.Exists(System.IO.Path.GetFullPath(My.Settings.Ocaml_Exe)) And My.Settings.Ocaml_Exe.EndsWith("ocaml.exe"))
            MsgBox("Exécutable OCaml non trouvé ! Veuillez spécifier son emplacement")
            OcamlFileDialog.ShowDialog()
            If OcamlFileDialog.FileName = "" Then
                End
            Else
                My.Settings.Ocaml_Exe = OcamlFileDialog.FileName
                OcamlFileDialog.Reset()
            End If
        End While
        While Not System.IO.Directory.Exists(System.IO.Path.GetFullPath(My.Settings.Ocaml_Lib))
            MsgBox("Dossier des librairies OCaml non trouvé ! Veuillez spécifier son emplacement")
            LibrariesBrowserDialog.ShowDialog()
            If LibrariesBrowserDialog.SelectedPath = "" Then
                End
            Else
                My.Settings.Ocaml_Lib = LibrariesBrowserDialog.SelectedPath
                LibrariesBrowserDialog.Reset()
            End If
        End While
        Dim LibsPath As String = "-I " + System.IO.Path.GetFullPath(My.Settings.Ocaml_Lib) + " "
        For Each path As String In System.IO.Directory.EnumerateDirectories(System.IO.Path.GetFullPath(My.Settings.Ocaml_Lib))
            LibsPath += "-I " + path + " "
        Next
        _commandExecutor.Start(System.IO.Path.GetFullPath(My.Settings.Ocaml_Exe), LibsPath)
    End Sub

    Private Sub Main_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        _commandExecutor.Dispose()
    End Sub

    ''' Execution et affichage des scripts
    Private Sub Executer(sender As Object, e As EventArgs) Handles ExecuteMenuItem.Click
        If Not _commandExecutor.GetState() Then
            Dim LibsPath As String = "-I " + System.IO.Path.GetFullPath(My.Settings.Ocaml_Lib) + " "
            For Each path As String In System.IO.Directory.EnumerateDirectories(System.IO.Path.GetFullPath(My.Settings.Ocaml_Lib))
                LibsPath += "-I " + path + " "
            Next
            _commandExecutor.Start(System.IO.Path.GetFullPath(My.Settings.Ocaml_Exe), LibsPath)
        End If
        If CodeToExecute <> "" Then
            OutputBox.AppendText("> ")
            If My.Settings.Detailed_Output Or Not CodeToExecute.Contains(vbLf) Then
                OutputBox.AppendText(CodeToExecute + vbCrLf)
            Else
                OutputBox.AppendText(CodeToExecute.Substring(0, CodeToExecute.IndexOf(vbLf)) + " ..." + vbCrLf)
            End If
            _commandExecutor.Execute(Normalise_Text(CodeToExecute))
        End If
    End Sub

    Private Sub _commandExecutor_OutputRead(ByVal output As String) Handles _commandExecutor.OutputRead
        Me.Invoke(New processCommandOutputDelegate(AddressOf processCommandOutput), output)
    End Sub

    Private Delegate Sub processCommandOutputDelegate(ByVal output As String)
    Private Sub processCommandOutput(ByVal output As String)
        OutputBox.AppendText(output & vbCrLf)
        OutputBox.ScrollToCaret()
    End Sub

    ''' Le reste
    Private Sub InputBox_KeyUp(sender As Object, e As EventArgs)
        ' Code a exécuter
        Dim CurrentTextbox As FastColoredTextBox = TryCast(TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
        Dim Pos As List(Of Integer) = IndexsOf(CurrentTextbox.Text, ";;")
        Dim Mat As MatchCollection = Regex.Matches(CurrentTextbox.Text, "[\(A-z)\(][\s\S]+?(;;)")
        For Each expr As Match In Mat
            If expr.Index <= CurrentTextbox.SelectionStart And CurrentTextbox.SelectionStart <= expr.Index + expr.Length Then
                Dim code As String = Regex.Replace(expr.Value, "[(][*][\s\S]*?[*][)][\s]*", "")
                If code <> CodeToExecute Or Not CodeToExecutePos.SequenceEqual({expr.Index, expr.Length}) Then
                    CodeToExecute = code
                    CodeToExecutePos = {expr.Index, expr.Length}
                    If Not LinesToExecute.SequenceEqual({CurrentTextbox.PositionToPlace(expr.Index).iLine, CurrentTextbox.PositionToPlace(expr.Index + expr.Length).iLine}) Then
                        LinesToExecute = {CurrentTextbox.PositionToPlace(expr.Index).iLine, CurrentTextbox.PositionToPlace(expr.Index + expr.Length).iLine}
                        CurrentTextbox.Invalidate()
                    End If
                End If
                Exit Sub
            End If
        Next
        If CodeToExecute <> "" Then
            CodeToExecute = ""
            CodeToExecutePos = {0, 0}
            LinesToExecute = {-1, -1}
            CurrentTextbox.Invalidate()
        End If

        ' Parenthèses et accolades

        ' Autocomplétion
        'Dim CurrentList As ListBox = TryCast(TabControl.SelectedTab.Controls.Item(2), ListBox)
        'CurrentList.Location = CurrentTextbox.Selection
    End Sub

    Public Sub AddNewPage()
        TabControl.TabPages.Add("*")
        TabControl.SelectTab(TabControl.TabCount - 1)
        TabControl.SelectedTab.Tag = {"", False}
        TabControl.SelectedTab.Controls.Add(New FastColoredTextBox)
        With TryCast(TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
            .Dock = DockStyle.Fill
            .Select()
            AddHandler .Click, AddressOf InputBox_KeyUp
            AddHandler .KeyUp, AddressOf InputBox_KeyUp
            AddHandler .PaintLine, AddressOf PaintLines
            AddHandler .TextChangedDelayed, AddressOf InputBoxTextChanged
        End With
        TabControl.SelectedTab.Controls.Add(New ListBox)
        With TryCast(TabControl.SelectedTab.Controls(1), ListBox)
            '.DataSource = KeyWords
            .Visible = False
        End With
        ThemeManager.ApplyTabPageStyle(TabControl.SelectedTab)
    End Sub

    Private Sub TabControl_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs)
        Dim g As Graphics = e.Graphics
        Dim tp As TabPage = TabControl.TabPages(e.Index)
        Dim br As Brush
        Dim sf As New StringFormat
        Dim r As New RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2)

        sf.Alignment = StringAlignment.Center

        Dim strTitle As String = tp.Text
        'If the current index is the Selected Index, change the color
        If TabControl.SelectedIndex = e.Index Then
            'this is the background color of the tabpage
            'you could make this a standard color for the selected page
            br = New SolidBrush(Color.Red) 'New SolidBrush(tp.BackColor)
            'this is the background color of the tab page
            g.FillRectangle(br, e.Bounds)
            'this is the foreground color of the tab page
            'you could make this a standard color for the selected page
            br = New SolidBrush(tp.ForeColor)
            g.DrawString(strTitle, TabControl.Font, br, r, sf)
            'these are the standard colors for the unselected tab pages
            'br = New SolidBrush(Color.WhiteSmoke)
            'g.FillRectangle(br, e.Bounds)
            'br = New SolidBrush(Color.Black)
            'g.DrawString(strTitle, TabControl.Font, br, r, sf)
        End If
    End Sub

    Private Sub AutoSaveTimer_Tick(sender As Object, e As EventArgs) Handles AutoSaveTimer.Tick
        Dim Count As Integer = TabControl.TabCount
        SaveLabel.Text = "Autosaving..."
        SaveProgressBar.Value = 0
        For Each tab As TabPage In TabControl.TabPages
            SaveProgressBar.Value = 100 * tab.TabIndex / Count
            If Not tab.Tag(0) = "" Then
                Dim CurrentTextbox As FastColoredTextBox = TryCast(TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
                Dim savePath As String = TabControl.SelectedTab.Tag(0)
                System.IO.File.WriteAllText(savePath, CurrentTextbox.Text, System.Text.Encoding.Default)
            End If
        Next
        SaveProgressBar.Value = 100
        SaveLabel.Text = "Autosave done!"
    End Sub

    Private Sub AutoresetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoresetToolStripMenuItem.Click
        My.Settings.Autoreset = AutoresetToolStripMenuItem.Checked
    End Sub
End Class
