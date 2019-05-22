Imports System.Text.RegularExpressions
Imports FastColoredTextBoxNS

Public Class Main
    Public LinesToExecute As Integer() = {-1, -1}
    Public CodeToExecute As String = ""
    Public CodeToExecutePos As Integer() = {0, 0}
    Public WithEvents CommandExecutor As New OCaml
    Public MenuHandler As MenuHandler
    Public ThemeManager As ThemeManager
    Public LastSaved As Date = Nothing

    ''' Démarrage et fermeture
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Utils.CheckUpdate()

        If Utils.IsLinux Then
            MsgBox("Warning: It seems you're running this app on an Unix system. OCaml will be loaded using 'ocaml' command.")
        ElseIf Utils.IsMacOS Then
            MsgBox("Warning: It seems you're running this app on a MacOS system. OCaml will be loaded using 'ocaml' command.")
        End If

        'Settings init
        My.Settings.Upgrade()

        'Class inits
        MenuHandler = New MenuHandler()
        ThemeManager = New ThemeManager()

        'TabControl init
        TabControl.DisplayStyleProvider.ShowTabCloser = True
        AddNewPage(False)
        AddHandler TabControl.TabClosing, AddressOf OnTabClosing
        AddHandler TabControl.TabClosed, AddressOf OnTabClosed

        'TextBox init
        Dim TextFont As Font = New Font(My.Settings.Font_Family, My.Settings.Font_Size, My.Settings.Font_Style)
        OutputBox.Font = TextFont
        FastInputBox.Font = TextFont
        SplitContainer1.SplitterIncrement = TextRenderer.MeasureText("I", TextFont).Height
        AddHandler FastInputBox.TextChanged, AddressOf UpdateTextStyle

        'MenuItems init
        DetailedOutputMenuItem.Enabled = Not My.Settings.Detailed_Output
        DetailedOutputMenuItem.Checked = My.Settings.Detailed_Output
        PartialOutputMenuItem.Enabled = My.Settings.Detailed_Output
        PartialOutputMenuItem.Checked = Not My.Settings.Detailed_Output

        AutoSaveTimer.Interval = My.Settings.Autosave_delay * 1000
        If My.Settings.Autosave Then
            AutoSaveTimer.Start()
        End If
        ElapsedTimer.Start()

        'OCaml init
        InitOcaml()
    End Sub

    Private Sub InitOcaml()
        Dim LibsPath As String

        If Utils.IsLinux Then
            My.Settings.Ocaml_Exe = "ocaml"
            My.Settings.Ocaml_Lib = ""
            LibsPath = ""
            CommandExecutor.Init(My.Settings.Ocaml_Exe, My.Settings.StartupOptions)
            CommandExecutor.Start()
        ElseIf Utils.IsMacOS Then
            My.Settings.Ocaml_Exe = "ocaml"
            My.Settings.Ocaml_Lib = ""
            LibsPath = ""
            CommandExecutor.Init(My.Settings.Ocaml_Exe, My.Settings.StartupOptions)
            CommandExecutor.Start()
        Else
            While Not (System.IO.File.Exists(System.IO.Path.GetFullPath(My.Settings.Ocaml_Exe) & "\ocaml.exe"))
                MsgBox("OCaml executable not found! Please specify its location")
                FolderBrowserDialog.ShowDialog()
                If FolderBrowserDialog.SelectedPath = "" Then
                    End
                Else
                    My.Settings.Ocaml_Exe = FolderBrowserDialog.SelectedPath
                End If
            End While
            While Not (System.IO.Directory.Exists(System.IO.Path.GetFullPath(My.Settings.Ocaml_Lib)) AndAlso System.IO.Directory.GetFiles(My.Settings.Ocaml_Lib, "*.cmi").Count() > 0)
                MsgBox("OCaml libraries folder not found! Please specify its location")
                FolderBrowserDialog.ShowDialog()
                If FolderBrowserDialog.SelectedPath = "" Then
                    End
                Else
                    My.Settings.Ocaml_Lib = FolderBrowserDialog.SelectedPath
                End If
            End While
            LibsPath = "-I " + Chr(34) + System.IO.Path.GetFullPath(My.Settings.Ocaml_Lib) + Chr(34) + " "
            For Each path As String In System.IO.Directory.EnumerateDirectories(System.IO.Path.GetFullPath(My.Settings.Ocaml_Lib))
                LibsPath += "-I " + Chr(34) + path + Chr(34) + " "
            Next
            CommandExecutor.Init(System.IO.Path.GetFullPath(My.Settings.Ocaml_Exe) & "\ocaml.exe", LibsPath & " " & My.Settings.StartupOptions)
            CommandExecutor.Start()
        End If

        My.Settings.Save()
    End Sub

    Private Sub Main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        For Each page As TabPage In TabControl.TabPages
            TabControl.SelectedTab = page
            Dim eventArgs As New TabControlCancelEventArgs(page, page.TabIndex, False, TabControlAction.Selected)
            OnTabClosing(Me, eventArgs)
            If eventArgs.Cancel Then
                e.Cancel = True
                Exit For
            Else
                TabControl.TabPages.Remove(page)
            End If
        Next

        If Not e.Cancel Then
            CommandExecutor.Dispose()
        End If
    End Sub

    ''' Execution et affichage des scripts
    Private Sub Executer(sender As Object, e As EventArgs) Handles ExecuteMenuItem.Click
        If FindFocussedControl(Me.ActiveControl).Equals(FastInputBox) Then
            OutputBox.SelectionColor = ThemeManager.OutputCommandColor
            If My.Settings.Detailed_Output OrElse Not CodeToExecute.Contains(vbLf) Then
                OutputBox.AppendText(FastInputBox.Text + vbLf)
            Else
                OutputBox.AppendText(FastInputBox.Text.Substring(0, FastInputBox.Text.IndexOf(vbLf) - 1) + " [...]" + vbLf)
            End If
            OutputBox.SelectionColor = ThemeManager.OutputColor
            CommandExecutor.Execute(Normalise_Text(FastInputBox.Text))
        Else
            If CodeToExecute <> "" Then
                OutputBox.SelectionColor = ThemeManager.OutputCommandColor
                If My.Settings.Detailed_Output OrElse Not CodeToExecute.Contains(vbLf) Then
                    OutputBox.AppendText(CodeToExecute + vbLf)
                Else
                    OutputBox.AppendText(CodeToExecute.Substring(0, CodeToExecute.IndexOf(vbLf) - 1) + " [...]" + vbLf)
                End If
                OutputBox.SelectionColor = ThemeManager.OutputColor
                CommandExecutor.Execute(Normalise_Text(CodeToExecute))
                WarpToNextCode()
            End If
        End If
    End Sub

    Private Sub ToutExecuter(sender As Object, e As EventArgs) Handles ExecuteAllMenuItem.Click
        Dim CurrentTextbox As FastColoredTextBox = TryCast(TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
        Dim currentPosition As Integer = CurrentTextbox.SelectionStart
        Dim prevPosition As Integer = -1
        CurrentTextbox.SelectionStart = 0
        UpdateCodeToExecute()
        While prevPosition <> CurrentTextbox.SelectionStart
            prevPosition = CurrentTextbox.SelectionStart
            Executer(Me, Nothing)
            Do Until OutputBox.Text.Substring(OutputBox.TextLength - 2, 2) = "# " ' CONDITION A AMELIORER
                Application.DoEvents()
            Loop
        End While
        CurrentTextbox.SelectionStart = currentPosition
    End Sub

    Private Sub WarpToNextCode()
        Dim CurrentTextbox As FastColoredTextBox = TryCast(TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
        Dim Pos As List(Of Integer) = IndexsOf(CurrentTextbox.Text, ";;")
        Dim Mat As MatchCollection = Regex.Matches(CurrentTextbox.Text, "[\w\(\#]([\s\S])*?(;;)")
        For Each expr As Match In Mat
            If expr.Index > CurrentTextbox.SelectionStart Then
                CurrentTextbox.SelectionStart = expr.Index
                CurrentTextbox.DoCaretVisible()
                UpdateCodeToExecute()
                Exit Sub
            End If
        Next
    End Sub

    Private Sub UpdateCodeToExecute()
        Dim CurrentTextbox As FastColoredTextBox = TryCast(TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
        Dim Mat As MatchCollection = Regex.Matches(CurrentTextbox.Text, "[\w\(\#]([\s\S])*?(;;)")
        For Each expr As Match In Mat
            If expr.Index <= CurrentTextbox.SelectionStart And CurrentTextbox.SelectionStart <= expr.Index + expr.Length Then
                Dim code As String = Regex.Replace(expr.Value, CommentRegex, "")
                If code <> CodeToExecute Or Not CodeToExecutePos.SequenceEqual({expr.Index, expr.Length}) Then
                    CodeToExecute = Utils.Normalise_Text(code)
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
    End Sub

    Private Delegate Sub ProcessCommandOutputDelegate(ByVal output As String)
    Private Sub ProcessCommandOutput(ByVal output As String)
        OutputBox.AppendText(output)
        OutputBox.ScrollToCaret()
    End Sub

    ''' Le reste
    Private Sub InputBox_KeyDown(sender As Object, e As KeyEventArgs)
        Dim CurrentTextbox As FastColoredTextBox = TryCast(TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
        If e.KeyCode = Keys.Back Then
            If CurrentTextbox.SelectionStart > 1 Then
                Dim currentRange As Range = CurrentTextbox.GetLine(CurrentTextbox.PositionToPlace(CurrentTextbox.SelectionStart).iLine).GetIntersectionWith(New Range(CurrentTextbox, CurrentTextbox.PositionToPlace(0), CurrentTextbox.PositionToPlace(CurrentTextbox.SelectionStart)))
                Dim match As Match = Regex.Match(currentRange.Text, "^[ ]+")
                If CurrentTextbox.SelectionStart - CurrentTextbox.PlaceToPosition(currentRange.Start) <= match.Length And match.Length > 0 Then
                    CurrentTextbox.DecreaseIndent()
                    e.SuppressKeyPress = True
                End If
            End If
        End If

        If e.KeyCode = Keys.Space Or e.KeyCode = Keys.Enter Then
            CurrentTextbox.EndAutoUndo()
            CurrentTextbox.BeginAutoUndo()
        End If
    End Sub

    Private Sub DrawCodeFoldingMarkers()
        Dim CurrentTextbox As FastColoredTextBox = TryCast(TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
        CurrentTextbox.Range.ClearFoldingMarkers()
        Dim isOpened As Boolean = False
        For i As Integer = 0 To CurrentTextbox.LinesCount - 1
            Dim line As Line = CurrentTextbox(i)
            If Not isOpened AndAlso line.Text.Contains("let") Then
                line.FoldingStartMarker = line.Text
                isOpened = True
            End If
            If isOpened AndAlso line.Text.Contains(";;") Then
                line.FoldingEndMarker = ";;"
                isOpened = False
            End If
        Next
    End Sub

    Private Sub InputBox_KeyUp(sender As Object, e As EventArgs)
        ' Code a exécuter
        UpdateCodeToExecute()

        ' Code Folding
        If My.Settings.Code_Folding Then
            DrawCodeFoldingMarkers()
        End If
    End Sub

    Public Sub AddNewPage(opened As Boolean)
        TabControl.TabPages.Add("*untitled")
        TabControl.SelectTab(TabControl.TabCount - 1)
        TabControl.SelectedTab.Tag = {"", False}
        TabControl.SelectedTab.Controls.Add(New FastColoredTextBox)
        With TryCast(TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
            .AllowDrop = True
            .AutoIndentChars = False
            .Font = New Font(My.Settings.Font_Family, My.Settings.Font_Size, My.Settings.Font_Style)
            .LeftBracket = "("
            .RightBracket = ")"
            .LeftBracket2 = "["
            .RightBracket2 = "]"
            .Dock = DockStyle.Fill
            .Select()
            .BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2
            .BeginAutoUndo()
            AddHandler .Click, AddressOf InputBox_KeyUp
            AddHandler .DragEnter, AddressOf InputBox_DragEnter
            AddHandler .DragDrop, AddressOf InputBox_DragDrop
            AddHandler .KeyUp, AddressOf InputBox_KeyUp
            AddHandler .KeyDown, AddressOf InputBox_KeyDown
            AddHandler .PaintLine, AddressOf PaintLines
            If Not opened Then
                AddHandler .TextChanged, AddressOf InputBoxTextChanged
            End If
        End With
        ThemeManager.ApplyTextBoxStyle(TabControl.SelectedTab.Controls(0))
    End Sub

    Private Sub InputBox_DragEnter(sender As Object, e As DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub InputBox_DragDrop(sender As Object, e As DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim files As String() = e.Data.GetData(DataFormats.FileDrop, True)
            For Each file As String In files
                If System.IO.File.Exists(file) AndAlso (file.EndsWith(".ml") Or file.EndsWith(".oml") Or file.EndsWith(".mli")) Then
                    OpenFile(file)
                End If
            Next
        End If
    End Sub

    Private Sub AutoSaveTimer_Tick(sender As Object, e As EventArgs) Handles AutoSaveTimer.Tick
        ElapsedTimer.Stop()
        ElapsedTimer.Enabled = False
        Dim Count As Integer = TabControl.TabCount
        SaveLabel.Text = "Autosaving..."
        For Each page As TabPage In TabControl.TabPages
            If page.Tag(0) <> "" And Not page.Tag(1) Then
                Dim CurrentTextbox As FastColoredTextBox = TryCast(page.Controls.Item(0), FastColoredTextBox)
                Dim savePath As String = page.Tag(0)
                CurrentTextbox.SaveToFile(savePath, System.Text.Encoding.Default)
                page.Text = System.IO.Path.GetFileName(savePath)
            End If
        Next
        SaveLabel.Text = "Autosave done!"
        LastSaved = Now
        ElapsedTimer.Enabled = True
        ElapsedTimer.Start()
    End Sub

    Public Sub ElapsedTimer_Tick() Handles ElapsedTimer.Tick
        If LastSaved.CompareTo(New Date) <> 0 Then
            SaveLabel.Text = $"Last save {(Now - LastSaved).Minutes} min. ago"
        End If
    End Sub

    Private Sub Refresh_Output(sender As Object, e As EventArgs) Handles RefreshTimer.Tick, CommandExecutor.RefreshDemand
        Dim s = CommandExecutor.Refresh()
        If s <> "" Then
            Me.Invoke(New ProcessCommandOutputDelegate(AddressOf ProcessCommandOutput), s)
        End If
    End Sub

    Private Sub OutputBox_TextAdded(sender As Object, e As EventArgs) Handles OutputBox.TextChanged
        Dim length As Integer = OutputBox.TextLength
        If length > 362144 Then '2^18 + 100.000, create a little delay before cleaning
            OutputBox.Text = OutputBox.Text.Substring(length - 262144)
        End If
    End Sub
End Class
