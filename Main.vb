Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Windows.Input
Imports FastColoredTextBoxNS

Public Class Main
    Public LinesToExecute As Integer() = {-1, -1}
    Public CodeToExecute As String = ""
    Public CodeToExecutePos As Integer() = {0, 0}
    Private WithEvents _commandExecutor As New OCaml()
    Private KeyWords As List(Of String) = KeyWordList()

    ''' Démarrage et fermeture
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddNewPage()

        OutputBox.Font = New Font(My.Settings.Font_Family, My.Settings.Font_Size, My.Settings.Font_Style)
        OutputBox.SelectionTabs = {32, 64, 96, 128, 160, 192, 224, 256, 288, 320}

        If My.Settings.Detailed_Output Then
            ComplèteToolStripMenuItem.Enabled = False
            ComplèteToolStripMenuItem.Checked = True
        Else
            PartielleToolStripMenuItem.Enabled = False
            PartielleToolStripMenuItem.Checked = True
        End If

        If My.Settings.Dark_Theme Then
            DarkModeToolStripMenuItem.Enabled = False
            DarkModeToolStripMenuItem.Checked = True
        Else
            LightModeToolStripMenuItem.Enabled = False
            LightModeToolStripMenuItem.Checked = True
        End If

        StartOcaml()
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
    Private Sub Executer(sender As Object, e As EventArgs) Handles ExécuterToolStripMenuItem.Click
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
    Private Sub SaveFile() Handles EnregistrerToolStripMenuItem.Click
        Dim CurrentTextbox As FastColoredTextBox = TryCast(TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
        If TabControl.SelectedTab.Tag = "" Or Not System.IO.File.Exists(TabControl.SelectedTab.Tag) Then
            SaveAsFile()
        Else
            Dim savePath As String = TabControl.SelectedTab.Tag
            System.IO.File.WriteAllText(savePath, CurrentTextbox.Text, System.Text.Encoding.Default)
        End If
    End Sub

    Private Sub SaveAsFile() Handles EnregistrerSousToolStripMenuItem.Click
        SaveFileDialog.ShowDialog()
    End Sub

    Private Sub OnSaveAsFile(sender As Object, e As EventArgs) Handles SaveFileDialog.FileOk
        Dim CurrentTextbox As FastColoredTextBox = TryCast(TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
        Dim savePath As String = SaveFileDialog.FileName
        System.IO.File.WriteAllText(savePath, CurrentTextbox.Text, System.Text.Encoding.Default)
        TabControl.SelectedTab.Tag = savePath
        TabControl.SelectedTab.Text = SaveFileDialog.FileName.Substring(SaveFileDialog.FileName.LastIndexOf("\") + 1)
    End Sub

    Private Sub OpenFile() Handles OuvrirToolStripMenuItem.Click
        OpenFileDialog.ShowDialog()
    End Sub

    Private Sub OnOpenFile(sender As Object, e As EventArgs) Handles OpenFileDialog.FileOk
        AddNewPage()
        Dim CurrentTextbox As FastColoredTextBox = TryCast(TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
        Dim openPath As String = OpenFileDialog.FileName
        TabControl.SelectedTab.Text = OpenFileDialog.SafeFileName
        CurrentTextbox.Text = System.IO.File.ReadAllText(openPath, System.Text.Encoding.Default)
    End Sub

    Private Sub NouveauToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NouveauToolStripMenuItem.Click
        AddNewPage()
    End Sub

    Private Sub FermerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FermerToolStripMenuItem.Click
        TabControl.TabPages.RemoveAt(TabControl.SelectedIndex)
        If TabControl.TabCount = 0 Then
            AddNewPage()
        End If
    End Sub

    Private Sub ComplèteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComplèteToolStripMenuItem.Click
        PartielleToolStripMenuItem.Checked = False
        PartielleToolStripMenuItem.Enabled = True
        ComplèteToolStripMenuItem.Enabled = False
        My.Settings.Detailed_Output = True
    End Sub

    Private Sub PartielleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartielleToolStripMenuItem.Click
        ComplèteToolStripMenuItem.Checked = False
        ComplèteToolStripMenuItem.Enabled = True
        PartielleToolStripMenuItem.Enabled = False
        My.Settings.Detailed_Output = False
    End Sub

    Private Sub DarkModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DarkModeToolStripMenuItem.Click
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

        LightModeToolStripMenuItem.Checked = False
        LightModeToolStripMenuItem.Enabled = True
        DarkModeToolStripMenuItem.Enabled = False
        'My.Settings.Dark_Theme = True

        MsgBox("Dark Mode expérimental, redemarrez l'application pour réinitialiser les paramètres du thème (Dsl je peux pas faire mieux, faudra attendre la v2)")
    End Sub

    Private Sub LightModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LightModeToolStripMenuItem.Click
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

        DarkModeToolStripMenuItem.Checked = False
        DarkModeToolStripMenuItem.Enabled = True
        LightModeToolStripMenuItem.Enabled = False
        My.Settings.Dark_Theme = False
    End Sub

    Private Sub AProposToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AProposToolStripMenuItem.Click
        MsgBox("OCaml c'est trivial", Title:="Aquatique")
    End Sub

    Private Sub FermerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FermerToolStripMenuItem1.Click
        _commandExecutor.Dispose()
        OutputBox.AppendText("OCaml a été fermé" & vbLf)
    End Sub

    Private Sub NettoyerLaSortieToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NettoyerLaSortieToolStripMenuItem.Click
        OutputBox.Clear()
    End Sub

    ''' Le reste
    Private Sub InputBox_KeyUp(sender As Object, e As EventArgs)
        ' Coloration
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

    Private Sub AddNewPage()
        TabControl.TabPages.Add("*")
        TabControl.SelectTab(TabControl.TabCount - 1)
        TabControl.SelectedTab.Controls.Add(New FastColoredTextBox)
        With TryCast(TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
            .Dock = DockStyle.Fill
            .Select()
            AddHandler .KeyUp, AddressOf InputBox_KeyUp
            AddHandler .PaintLine, AddressOf PaintLines
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
            .DataSource = KeyWords
            .Visible = False
        End With
    End Sub

    Private Sub TabControl_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl.DrawItem
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
        Else
            'these are the standard colors for the unselected tab pages
            br = New SolidBrush(Color.WhiteSmoke)
            g.FillRectangle(br, e.Bounds)
            br = New SolidBrush(Color.Black)
            g.DrawString(strTitle, TabControl.Font, br, r, sf)
        End If
    End Sub
End Class
