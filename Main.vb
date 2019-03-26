Public Class Main
    Private WithEvents _commandExecutor As New OCaml()
    Private ExecuteCode As Integer()
    Private KeyWords As List(Of String) = KeyWordList()

    ''' Démarrage et fermeture
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ExecuteCode = {0, 0}

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

        StartOcaml()
    End Sub

    Private Sub StartOcaml()
        While Not (System.IO.File.Exists(My.Settings.Ocaml_Exe) And My.Settings.Ocaml_Exe.EndsWith("ocaml.exe"))

            MsgBox("Exécutable OCaml non trouvé ! Veuillez spécifier son emplacement")
            OcamlFileDialog.ShowDialog()
            If OcamlFileDialog.FileName = "" Then
                End
            Else
                My.Settings.Ocaml_Exe = OcamlFileDialog.FileName
                OcamlFileDialog.Reset()
            End If
        End While
        While Not System.IO.Directory.Exists(My.Settings.Ocaml_Lib)
            MsgBox("Dossier des librairies OCaml non trouvé ! Veuillez spécifier son emplacement")
            LibrariesBrowserDialog.ShowDialog()
            If LibrariesBrowserDialog.SelectedPath = "" Then
                End
            Else
                My.Settings.Ocaml_Lib = LibrariesBrowserDialog.SelectedPath
                LibrariesBrowserDialog.Reset()
            End If
        End While
        _commandExecutor.Start(My.Settings.Ocaml_Exe, "-I " + My.Settings.Ocaml_Lib)
    End Sub

    Private Sub Main_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        _commandExecutor.Dispose()
    End Sub

    ''' Execution et affichage des scripts
    Private Sub Executer(sender As Object, e As EventArgs) Handles ExécuterToolStripMenuItem.Click
        If ExecuteCode(0) <> ExecuteCode(1) Then
            Dim ToExecute As String = TryCast(TabControl.SelectedTab.Controls.Item(0), RichTextBox).Text.Substring(ExecuteCode(0), ExecuteCode(1) - ExecuteCode(0))
            OutputBox.AppendText("> ")
            If My.Settings.Detailed_Output Or Not ToExecute.Contains(vbLf) Then
                OutputBox.AppendText(ToExecute + vbCrLf)
            Else
                OutputBox.AppendText(ToExecute.Substring(0, ToExecute.IndexOf(vbLf)) + " ..." + vbCrLf)
            End If
            _commandExecutor.Execute(Normalise_Text(ToExecute))
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
        Dim CurrentTextbox As RichTextBox = TryCast(TabControl.SelectedTab.Controls.Item(0), RichTextBox)
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
        Dim CurrentTextbox As RichTextBox = TryCast(TabControl.SelectedTab.Controls.Item(0), RichTextBox)
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
        Dim CurrentTextbox As RichTextBox = TryCast(TabControl.SelectedTab.Controls.Item(0), RichTextBox)
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

    Private Sub AProposToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AProposToolStripMenuItem.Click
        MsgBox("OCaml c'est trivial", Title:="Aquatique")
    End Sub

    ''' Le reste
    Private Sub InputBox_KeyUp(sender As Object, e As KeyEventArgs)
        Dim CurrentTextbox As RichTextBox = TryCast(TabControl.SelectedTab.Controls.Item(0), RichTextBox)
        Dim Pos As List(Of Integer) = IndexsOf(CurrentTextbox.Text, ";;")
        For i = 0 To Pos.Count - 2
            If Pos(i) <= CurrentTextbox.SelectionStart And CurrentTextbox.SelectionStart <= Pos(i + 1) Then
                If Pos(i) <> ExecuteCode(0) Or Pos(i + 1) <> ExecuteCode(1) Then
                    Dim CursorPos As Integer = CurrentTextbox.SelectionStart
                    CurrentTextbox.Select(ExecuteCode(0), ExecuteCode(1) - ExecuteCode(0))
                    CurrentTextbox.SelectionBackColor = CurrentTextbox.BackColor
                    ExecuteCode = {Pos(i), Pos(i + 1)}
                    CurrentTextbox.Select(ExecuteCode(0), ExecuteCode(1) - ExecuteCode(0))
                    CurrentTextbox.SelectionBackColor = Color.LightGray
                    CurrentTextbox.DeselectAll()
                    CurrentTextbox.SelectionStart = CursorPos
                End If
                Exit Sub
            End If
        Next
        If ExecuteCode(0) <> 0 Or ExecuteCode(1) <> 0 Then
            Dim CursorPos As Integer = CurrentTextbox.SelectionStart
            CurrentTextbox.Select(ExecuteCode(0), ExecuteCode(1) - ExecuteCode(0))
            CurrentTextbox.SelectionBackColor = CurrentTextbox.BackColor
            ExecuteCode = {0, 0}
            CurrentTextbox.Select(ExecuteCode(0), ExecuteCode(1) - ExecuteCode(0))
            CurrentTextbox.SelectionBackColor = Color.LightGray
            CurrentTextbox.DeselectAll()
            CurrentTextbox.SelectionStart = CursorPos
        End If
    End Sub

    Private Sub AddNewPage()
        TabControl.TabPages.Add("*")
        TabControl.SelectTab(TabControl.TabCount - 1)
        TabControl.SelectedTab.Controls.Add(New RichTextBox)
        With TryCast(TabControl.SelectedTab.Controls.Item(0), RichTextBox)
            .AcceptsTab = True
            .Dock = DockStyle.Fill
            .Font = New Font(My.Settings.Font_Family, My.Settings.Font_Size, My.Settings.Font_Style)
            .SelectionTabs = {32, 64, 96, 128, 160, 192, 224, 256, 288, 320}
            .WordWrap = False
            .Select()
            AddHandler .KeyUp, AddressOf InputBox_KeyUp
        End With
        TabControl.SelectedTab.Controls.Add(New LineNumbers_For_RichTextBox)
        With TryCast(TabControl.SelectedTab.Controls.Item(1), LineNumbers_For_RichTextBox)
            ._SeeThroughMode_ = False
            .AutoSizing = True
            .BorderLines_Color = System.Drawing.Color.SlateGray
            .BorderLines_Style = System.Drawing.Drawing2D.DashStyle.Solid
            .BorderLines_Thickness = 1.0!
            .Dock = System.Windows.Forms.DockStyle.Left
            .DockSide = LineNumbers_For_RichTextBox.LineNumberDockSide.Left
            .ForeColor = TabControl.ForeColor
            .LineNrs_Alignment = System.Drawing.ContentAlignment.TopRight
            .LineNrs_AntiAlias = True
            .LineNrs_AsHexadecimal = False
            .LineNrs_ClippedByItemRectangle = False
            .LineNrs_LeadingZeroes = False
            .LineNrs_Offset = New System.Drawing.Size(0, 0)
            .Location = New System.Drawing.Point(0, 0)
            .Margin = New System.Windows.Forms.Padding(0)
            .MarginLines_Color = System.Drawing.Color.SlateGray
            .MarginLines_Side = LineNumbers_For_RichTextBox.LineNumberDockSide.Right
            .MarginLines_Style = System.Drawing.Drawing2D.DashStyle.Solid
            .MarginLines_Thickness = 1.0!
            .Padding = New System.Windows.Forms.Padding(0, 1, 3, 0)
            .ParentRichTextBox = TryCast(TabControl.SelectedTab.Controls.Item(0), RichTextBox)
            .Show_BackgroundGradient = False
            .Show_BorderLines = False
            .Show_GridLines = False
            .Show_LineNrs = True
            .Show_MarginLines = True
            .Size = New System.Drawing.Size(29, 298)
        End With
    End Sub
End Class
