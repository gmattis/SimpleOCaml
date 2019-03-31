Imports System.Text.RegularExpressions
Imports FastColoredTextBoxNS

Public Class Main
    Public LinesToExecute As Integer() = {-1, -1}
    Public CodeToExecute As String = ""
    Public CodeToExecutePos As Integer() = {0, 0}
    Private WithEvents _commandExecutor As New OCaml()
    'Private KeyWords As List(Of String) = KeyWordList()

    ''' Démarrage et fermeture
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        If My.Settings.Dark_Theme Then
            DarkModeMenuItem.Enabled = False
            DarkModeMenuItem.Checked = True
        Else
            LightModeMenuItem.Enabled = False
            LightModeMenuItem.Checked = True
        End If

        StartOcaml()

        If My.Settings.Autosave Then
            EnableAutoSaveMenuItem.Checked = True
        End If

        AutoSaveTimer.Interval = My.Settings.Autosave_delay * 1000
        If My.Settings.Autosave Then
            AutoSaveTimer.Start()
        End If

        AddHandler TabControl.CloseButtonClick, AddressOf OnTabClose
        AddHandler TabControl.DrawItem, AddressOf TabControl_DrawItem
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
            Dim LibsPath As String = ""
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

    ''' Interactions avec les menus
    Private Sub SaveFile() Handles SaveMenuItem.Click
        Dim CurrentTextbox As FastColoredTextBox = TryCast(TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
        If TabControl.SelectedTab.Tag(0) = "" Or Not System.IO.File.Exists(TabControl.SelectedTab.Tag(0)) Then
            SaveAsFile()
        Else
            Dim savePath As String = TabControl.SelectedTab.Tag(0)
            System.IO.File.WriteAllText(savePath, CurrentTextbox.Text, System.Text.Encoding.Default)
        End If

        TabControl.SelectedTab.Tag(1) = True
        TabControl.SelectedTab.Text = TabControl.SelectedTab.Tag(0).ToString.Substring(TabControl.SelectedTab.Tag(0).ToString.LastIndexOf("\") + 1)
    End Sub

    Private Sub SaveAsFile() Handles SaveAsMenuItem.Click
        SaveFileDialog.ShowDialog()
    End Sub

    Private Sub OnSaveAsFile(sender As Object, e As EventArgs) Handles SaveFileDialog.FileOk
        Dim CurrentTextbox As FastColoredTextBox = TryCast(TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
        Dim savePath As String = SaveFileDialog.FileName
        System.IO.File.WriteAllText(savePath, CurrentTextbox.Text, System.Text.Encoding.Default)
        TabControl.SelectedTab.Tag(0) = savePath
        TabControl.SelectedTab.Text = SaveFileDialog.FileName.Substring(SaveFileDialog.FileName.LastIndexOf("\") + 1)

        TabControl.SelectedTab.Tag(1) = True
    End Sub

    Private Sub OpenFile() Handles OpenMenuItem.Click
        OpenFileDialog.ShowDialog()
    End Sub

    Private Sub OnOpenFile(sender As Object, e As EventArgs) Handles OpenFileDialog.FileOk
        AddNewPage()
        Dim CurrentTextbox As FastColoredTextBox = TryCast(TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
        Dim openPath As String = OpenFileDialog.FileName
        TabControl.SelectedTab.Text = OpenFileDialog.SafeFileName
        TabControl.SelectedTab.Tag(0) = openPath
        TabControl.SelectedTab.Tag(1) = True
        CurrentTextbox.Text = System.IO.File.ReadAllText(openPath, System.Text.Encoding.Default)
    End Sub

    Private Sub NewMenuItem_Click(sender As Object, e As EventArgs) Handles NewMenuItem.Click
        AddNewPage()
    End Sub

    Private Sub FullOutputMenuItem_Click(sender As Object, e As EventArgs) Handles FullOutputMenuItem.Click
        PartialOutputMenuItem.Checked = False
        PartialOutputMenuItem.Enabled = True
        FullOutputMenuItem.Enabled = False
        My.Settings.Detailed_Output = True
    End Sub

    Private Sub PartialOutputMenuItem_Click(sender As Object, e As EventArgs) Handles PartialOutputMenuItem.Click
        FullOutputMenuItem.Checked = False
        FullOutputMenuItem.Enabled = True
        PartialOutputMenuItem.Enabled = False
        My.Settings.Detailed_Output = False
    End Sub

    Private Sub DarkModeMenuItem_Click(sender As Object, e As EventArgs) Handles DarkModeMenuItem.Click
        For Each tab As TabPage In TabControl.TabPages
            With Me
                .BackColor = Color.FromArgb(60, 60, 60)
                .ForeColor = Color.LightGray
            End With
            With SplitContainer
                .BackColor = Color.FromArgb(60, 60, 60)
                .ForeColor = Color.LightGray
            End With
            With TryCast(tab.Controls(0), FastColoredTextBox)
                .BackColor = Color.FromArgb(45, 45, 45)
                .ForeColor = Color.LightGray
            End With
            With OutputBox
                .BackColor = Color.FromArgb(45, 45, 45)
                .ForeColor = Color.LightGray
            End With
            With MenuStrip
                .BackColor = Color.FromArgb(60, 60, 60)
                .ForeColor = Color.LightGray
            End With
            For Each ctrl As TabPage In TabControl.TabPages
                ctrl.BackColor = Color.FromArgb(60, 60, 60)
                ctrl.ForeColor = Color.LightGray
            Next
            For Each ctrl As ToolStripMenuItem In MenuStrip.Controls
                ctrl.BackColor = Color.FromArgb(45, 45, 45)
                ctrl.ForeColor = Color.LightGray
            Next
        Next

        LightModeMenuItem.Checked = False
        LightModeMenuItem.Enabled = True
        DarkModeMenuItem.Enabled = False
        'My.Settings.Dark_Theme = True

        MsgBox("Dark Mode expérimental, redemarrez l'application pour réinitialiser les paramètres du thème (Dsl je peux pas faire mieux, faudra attendre la v2)")
    End Sub

    Private Sub LightModeMenuItem_Click(sender As Object, e As EventArgs) Handles LightModeMenuItem.Click
        For Each tab As TabPage In TabControl.TabPages
            With Me
                .BackColor = Color.FromArgb(60, 60, 60)
                .ForeColor = Color.LightGray
            End With
            With SplitContainer
                .BackColor = Color.FromArgb(60, 60, 60)
                .ForeColor = Color.LightGray
            End With
            With TryCast(tab.Controls(0), FastColoredTextBox)
                .BackColor = Color.FromArgb(45, 45, 45)
                .ForeColor = Color.LightGray
            End With
            With OutputBox
                .BackColor = Color.FromArgb(45, 45, 45)
                .ForeColor = Color.LightGray
            End With
            With MenuStrip
                .BackColor = Color.FromArgb(60, 60, 60)
                .ForeColor = Color.LightGray
            End With
            For Each ctrl As TabPage In TabControl.TabPages
                ctrl.BackColor = Color.FromArgb(60, 60, 60)
                ctrl.ForeColor = Color.LightGray
            Next
            For Each ctrl As ToolStripMenuItem In MenuStrip.Controls
                ctrl.BackColor = Color.FromArgb(45, 45, 45)
                ctrl.ForeColor = Color.LightGray
            Next
        Next

        DarkModeMenuItem.Checked = False
        DarkModeMenuItem.Enabled = True
        LightModeMenuItem.Enabled = False
        My.Settings.Dark_Theme = False
    End Sub

    Private Sub AboutMenuItem_Click(sender As Object, e As EventArgs) Handles AboutMenuItem.Click
        MsgBox("OCaml c'est trivial", Title:="Aquatique")
    End Sub

    Private Sub CloseOcamlMenuItem_Click(sender As Object, e As EventArgs) Handles CloseOcamlMenuItem.Click
        _commandExecutor.Dispose()
        OutputBox.AppendText("OCaml a été fermé" & vbLf)
    End Sub

    Private Sub CleanOutputMenuItem_Click(sender As Object, e As EventArgs) Handles CleanOutputMenuItem.Click
        OutputBox.Clear()
    End Sub

    Private Sub EnableAutoSaveMenuItem_Click(sender As Object, e As EventArgs) Handles EnableAutoSaveMenuItem.Click
        My.Settings.Autosave = Not My.Settings.Autosave
        If My.Settings.Autosave Then
            AutoSaveTimer.Start()
        Else
            AutoSaveTimer.Stop()
        End If
    End Sub

    Private Sub AutoSaveDelayMenuItem_Click(sender As Object, e As EventArgs) Handles AutoSaveDelayMenuItem.Click
        Try
            Dim Delay As Integer = InputBox("Veuillez définir le délai en secondes entre deux sauvegardes automatiques", "Délai de sauvegarde", My.Settings.Autosave_delay)
            My.Settings.Autosave_delay = Delay
            AutoSaveTimer.Interval = Delay * 1000
        Catch
            MsgBox("Veuillez entrer un nombre valide")
        End Try
    End Sub

    ''' Le reste
    Private Sub InputBox_KeyUp(sender As Object, e As EventArgs)
        If TabControl.SelectedTab.Tag(1) Then
            TabControl.SelectedTab.Tag(1) = False
            TabControl.SelectedTab.Text = "*" & TabControl.SelectedTab.Text
        End If

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
        'TabControl.SelectedTab.Controls.Add(New RichTextBox)
        'With TryCast(TabControl.SelectedTab.Controls.Item(0), RichTextBox)
        '    .AcceptsTab = True
        '    .Dock = DockStyle.Fill
        '    .Font = New Font(My.Settings.Font_Family, My.Settings.Font_Size, My.Settings.Font_Style)
        '    .SelectionTabs = {32, 64, 96, 128, 160, 192, 224, 256, 288, 320}
        '    .WordWrap = False
        '    .Select()
        '    AddHandler .KeyUp, AddressOf InputBox_KeyUp
        'End With
        TabControl.SelectedTab.Controls.Add(New ListBox)
        With TryCast(TabControl.SelectedTab.Controls(1), ListBox)
            '.DataSource = KeyWords
            .Visible = False
        End With
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
            br = New SolidBrush(tp.BackColor)
            'this is the background color of the tab page
            g.FillRectangle(br, e.Bounds)
            'this is the foreground color of the tab page
            'you could make this a standard color for the selected page
            br = New SolidBrush(tp.ForeColor)
            g.DrawString(strTitle, TabControl.Font, br, r, sf)
            'these are the standard colors for the unselected tab pages
            br = New SolidBrush(Color.WhiteSmoke)
            g.FillRectangle(br, e.Bounds)
            br = New SolidBrush(Color.Black)
            g.DrawString(strTitle, TabControl.Font, br, r, sf)
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
End Class
