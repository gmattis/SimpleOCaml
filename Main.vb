Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports FastColoredTextBoxNS

Public Class Main
    Public LinesToExecute As Integer() = {-1, -1}
    Public CodeToExecute As String = ""
    Public CodeToExecutePos As Integer() = {0, 0}
    Public WithEvents _commandExecutor As New OCaml()
    Public MenuHandling As MenuHandler
    Public ThemeManager As ThemeManager
    Public LastSaved As Date = Nothing

    Private BracketStyle As New MarkerStyle(New SolidBrush(Color.FromArgb(192, Color.DarkRed)))

    ''' Démarrage et fermeture
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.Autoreset Then
            AutoresetMenuItem.Checked = True
            StateLabel.Text = "Attention, les paramètres seront réinitialisés au prochain redémarrage"
        Else
            AutoresetMenuItem.Checked = False
        End If

        My.Settings.Upgrade()

        MenuHandling = New MenuHandler()
        ThemeManager = New ThemeManager()

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
        ElapsedTimer.Start()

        AddHandler TabControl.TabClosing, AddressOf OnTabClosing
        AddHandler TabControl.TabClosed, AddressOf OnTabClosed
        AddHandler TabControl.DrawItem, AddressOf TabControl_DrawItem

        TabControl.DisplayStyleProvider.ShowTabCloser = True
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
        Dim LibsPath As String = "-I " + Chr(34) + System.IO.Path.GetFullPath(My.Settings.Ocaml_Lib) + Chr(34) + " "
        For Each path As String In System.IO.Directory.EnumerateDirectories(System.IO.Path.GetFullPath(My.Settings.Ocaml_Lib))
            LibsPath += "-I " + Chr(34) + path + Chr(34) + " "
        Next
        _commandExecutor.Start(System.IO.Path.GetFullPath(My.Settings.Ocaml_Exe), LibsPath)
    End Sub

    Private Sub Main_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim allSaved As Boolean = True
        For Each page As TabPage In TabControl.TabPages
            If Not page.Tag(1) Then
                allSaved = False
                Exit For
            End If
        Next
        If Not allSaved Then
            If MsgBox("Certaines pages n'ont pas été sauvegardées. Voulez-vous continuer ?", MsgBoxStyle.OkCancel, "Pages non sauvegardées") = MsgBoxResult.Cancel Then
                e.Cancel = True
            End If
        End If

        _commandExecutor.Dispose()
    End Sub

    ''' Execution et affichage des scripts
    Private Sub Executer(sender As Object, e As EventArgs) Handles ExecuteMenuItem.Click
        If Not _commandExecutor.GetState() Then
            Dim LibsPath As String = "-I " + Chr(34) + System.IO.Path.GetFullPath(My.Settings.Ocaml_Lib) + Chr(34) + " "
            For Each path As String In System.IO.Directory.EnumerateDirectories(System.IO.Path.GetFullPath(My.Settings.Ocaml_Lib))
                LibsPath += "-I " + Chr(34) + path + Chr(34) + " "
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
            Dim CurrentTextbox As FastColoredTextBox = TryCast(TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
            CurrentTextbox.SelectionStart = If(CodeToExecutePos(0) + CodeToExecutePos(1) + 2 > CurrentTextbox.TextLength, CurrentTextbox.TextLength, CodeToExecutePos(0) + CodeToExecutePos(1) + 2)
            CurrentTextbox.DoCaretVisible()
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
        Dim Mat As MatchCollection = Regex.Matches(CurrentTextbox.Text, "[\(A-z)\(\#][\s\S]+?(;;)")
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
            .LeftBracket = "("
            .RightBracket = ")"
            .LeftBracket2 = "["
            .RightBracket2 = "]"
            .BracketsStyle = BracketStyle
            .BracketsStyle2 = BracketStyle
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
        ElapsedTimer.Stop()
        ElapsedTimer.Enabled = False
        Dim Count As Integer = TabControl.TabCount
        SaveLabel.Text = "Autosaving..."
        For Each tab As TabPage In TabControl.TabPages
            If Not tab.Tag(0) = "" Then
                Dim CurrentTextbox As FastColoredTextBox = TryCast(TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
                Dim savePath As String = tab.Tag(0)
                System.IO.File.WriteAllText(savePath, CurrentTextbox.Text, System.Text.Encoding.Default)
                tab.Text = System.IO.Path.GetFileName(savePath)
            End If
        Next
        SaveLabel.Text = "Autosave done!"
        LastSaved = Now
        ElapsedTimer.Enabled = True
        ElapsedTimer.Start()
    End Sub

    Public Sub ElapsedTimer_Tick() Handles ElapsedTimer.Tick
        If LastSaved.CompareTo(New Date) <> 0 Then
            SaveLabel.Text = String.Format("Last saved {0} minutes ago.", (Now - LastSaved).Minutes)
        End If
    End Sub
End Class
