Imports FastColoredTextBoxNS

Public Class MenuHandler
    Private WithEvents FileMenuItem As ToolStripMenuItem = Main.FileMenuItem
    Private WithEvents NewMenuItem As ToolStripMenuItem = Main.NewMenuItem
    Private WithEvents OpenMenuItem As ToolStripMenuItem = Main.OpenMenuItem
    Private WithEvents SaveMenuItem As ToolStripMenuItem = Main.SaveMenuItem
    Private WithEvents SaveAsMenuItem As ToolStripMenuItem = Main.SaveAsMenuItem
    Private WithEvents EditMenuItem As ToolStripMenuItem = Main.EditMenuItem
    Private WithEvents CleanOutputMenuItem As ToolStripMenuItem = Main.CleanOutputMenuItem
    Private WithEvents OcamlMenuItem As ToolStripMenuItem = Main.OcamlMenuItem
    Private WithEvents ExecuteMenuItem As ToolStripMenuItem = Main.ExecuteMenuItem
    Private WithEvents OutputMenuItem As ToolStripMenuItem = Main.OutputMenuItem
    Private WithEvents PartialOutputMenuItem As ToolStripMenuItem = Main.PartialOutputMenuItem
    Private WithEvents FullOutputMenuItem As ToolStripMenuItem = Main.DetailedOutputMenuItem
    Private WithEvents CloseOcamlMenuItem As ToolStripMenuItem = Main.CloseOcamlMenuItem
    Private WithEvents SettingsMenuItem As ToolStripMenuItem = Main.SettingsMenuItem
    Private WithEvents ThemeMenuItem As ToolStripMenuItem = Main.ThemeMenuItem
    Private WithEvents LightModeMenuItem As ToolStripMenuItem = Main.LightThemeMenuItem
    Private WithEvents DarkModeMenuItem As ToolStripMenuItem = Main.DarkThemeMenuItem
    Private WithEvents AutoSaveMenuItem As ToolStripMenuItem = Main.AutoSaveMenuItem
    Private WithEvents EnableAutoSaveMenuItem As ToolStripMenuItem = Main.EnableAutoSaveMenuItem
    Private WithEvents AutoSaveDelayMenuItem As ToolStripMenuItem = Main.AutoSaveDelayMenuItem
    Private WithEvents HelpMenuItem As ToolStripMenuItem = Main.HelpMenuItem
    Private WithEvents OcamlDocMenuItem As ToolStripMenuItem = Main.OcamlDocMenuItem
    Private WithEvents AboutMenuItem As ToolStripMenuItem = Main.AboutMenuItem
    Private WithEvents CopierMenuItem As ToolStripMenuItem = Main.CopyMenuItem
    Private WithEvents UndoMenuItem As ToolStripMenuItem = Main.UndoMenuItem
    Private WithEvents RedoMenuItem As ToolStripMenuItem = Main.RedoMenuItem
    Private WithEvents ToutEnregistrerMenuItem As ToolStripMenuItem = Main.SaveAllMenuItem
    Private WithEvents ReductionCodeMenuItem As ToolStripMenuItem = Main.CodeFoldingMenuItem
    Private WithEvents StartupOptionsMenuItem As ToolStripMenuItem = Main.StartupOptionsMenuItem

    Private WithEvents OpenFileDialog As OpenFileDialog = Main.OpenFileDialog
    Private WithEvents SaveFileDialog As SaveFileDialog = Main.SaveFileDialog

    Private Sub SaveFile() Handles SaveMenuItem.Click
        Dim CurrentTextbox As FastColoredTextBox = TryCast(Main.TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
        If Main.TabControl.SelectedTab.Tag(0) = "" Or Not System.IO.File.Exists(Main.TabControl.SelectedTab.Tag(0)) Then
            SaveAsFile()
        Else
            Dim savePath As String = Main.TabControl.SelectedTab.Tag(0)
            CurrentTextbox.SaveToFile(savePath, System.Text.Encoding.Default)
            Main.TabControl.SelectedTab.Text = System.IO.Path.GetFileName(Main.TabControl.SelectedTab.Tag(0))
            Main.TabControl.SelectedTab.Tag(1) = True
            Main.LastSaved = Now
            Main.ElapsedTimer_Tick()
        End If
    End Sub

    Private Sub SaveAsFile() Handles SaveAsMenuItem.Click
        SaveFileDialog.ShowDialog()
    End Sub

    Private Sub OnSaveAsFile(sender As Object, e As EventArgs) Handles SaveFileDialog.FileOk
        Dim CurrentTextbox As FastColoredTextBox = TryCast(Main.TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
        Dim savePath As String = SaveFileDialog.FileName
        CurrentTextbox.SaveToFile(savePath, System.Text.Encoding.Default)
        Main.TabControl.SelectedTab.Text = System.IO.Path.GetFileName(SaveFileDialog.FileName)
        Main.TabControl.SelectedTab.Tag(0) = savePath
        Main.TabControl.SelectedTab.Tag(1) = True
        Main.LastSaved = Now
        Main.ElapsedTimer_Tick()
    End Sub

    Private Sub OpenFile() Handles OpenMenuItem.Click
        OpenFileDialog.ShowDialog()
    End Sub

    Private Sub OnOpenFile(sender As Object, e As EventArgs) Handles OpenFileDialog.FileOk
        Utils.OpenFile(OpenFileDialog.FileName)
    End Sub

    Private Sub NewMenuItem_Click(sender As Object, e As EventArgs) Handles NewMenuItem.Click
        Main.AddNewPage(False)
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
        Main.ThemeManager.SwitchTheme(ThemeManager.Themes.DarkTheme)
    End Sub

    Private Sub LightModeMenuItem_Click(sender As Object, e As EventArgs) Handles LightModeMenuItem.Click
        Main.ThemeManager.SwitchTheme(ThemeManager.Themes.LightTheme)
    End Sub

    Private Sub OcamlDocMenuItem_Click(sender As Object, e As EventArgs) Handles OcamlDocMenuItem.Click
        Process.Start("http://caml.inria.fr/pub/docs/manual-ocaml/")
    End Sub

    Private Sub AboutMenuItem_Click(sender As Object, e As EventArgs) Handles AboutMenuItem.Click
        MsgBox("An OCaml IDE, made by Mattis GOLLIET, Thomas MICHEL and Bastien PASCAL.", Title:=$"SimpleOCaml {My.Settings.Version}")
    End Sub

    Private Sub CloseOcamlMenuItem_Click(sender As Object, e As EventArgs) Handles CloseOcamlMenuItem.Click
        Main.CommandExecutor.Dispose()
        Main.OutputBox.AppendText("OCaml has been closed." & vbLf & "Restarting ..." & vbLf & vbLf)
        Main.CommandExecutor.Start()
    End Sub

    Private Sub CleanOutputMenuItem_Click(sender As Object, e As EventArgs) Handles CleanOutputMenuItem.Click
        Main.OutputBox.Clear()
    End Sub

    Private Sub EnableAutoSaveMenuItem_Click(sender As Object, e As EventArgs) Handles EnableAutoSaveMenuItem.Click
        My.Settings.Autosave = Not My.Settings.Autosave
        If My.Settings.Autosave Then
            Main.AutoSaveTimer.Start()
        Else
            Main.AutoSaveTimer.Stop()
        End If
    End Sub

    Private Sub AutoSaveDelayMenuItem_Click(sender As Object, e As EventArgs) Handles AutoSaveDelayMenuItem.Click
        Try
            Dim Delay As Integer = InputBox("Please enter the delay between two autosaves in seconds (min. 10)", "Autosave delay", My.Settings.Autosave_delay)
            If Delay < 10 Then
                MsgBox("The delay must be higher than 10")
            Else
                My.Settings.Autosave_delay = Delay
                Main.AutoSaveTimer.Interval = Delay * 1000
            End If
        Catch
            MsgBox("The delay must be a valid integer")
        End Try
    End Sub

    Private Sub CopierMenuItem_Click(sender As Object, e As EventArgs) Handles CopierMenuItem.Click
        Dim CurrentTextbox As FastColoredTextBox = TryCast(Main.TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
        If CurrentTextbox.SelectedText <> "" Then
            Clipboard.SetText(CurrentTextbox.SelectedText)
        End If
    End Sub

    Private Sub UndoMenuItem_Click(sender As Object, e As EventArgs) Handles UndoMenuItem.Click
        TryCast(Main.TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox).Undo()
    End Sub

    Private Sub RedoMenuItem_Click(sender As Object, e As EventArgs) Handles RedoMenuItem.Click
        TryCast(Main.TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox).Redo()
    End Sub

    Private Sub ToutEnregistrerMenuItem_Click(sender As Object, e As EventArgs) Handles ToutEnregistrerMenuItem.Click
        For Each page As TabPage In Main.TabControl.TabPages
            If page.Tag(0) <> "" And Not page.Tag(1) Then
                TryCast(page.Controls.Item(0), FastColoredTextBox).SaveToFile(page.Tag(0), System.Text.Encoding.Default)
                page.Tag(1) = True
                page.Text = System.IO.Path.GetFileName(page.Tag(0))
            End If
        Next
    End Sub

    Private Sub ReductionCodeMenuItem_Click(sender As Object, e As EventArgs) Handles ReductionCodeMenuItem.Click
        My.Settings.Code_Folding = Not My.Settings.Code_Folding
        TryCast(Main.TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox).Range.ClearFoldingMarkers()
    End Sub

    Private Sub StartupOptionsMenuItem_Click(sender As Object, e As EventArgs) Handles StartupOptionsMenuItem.Click
        Dim startupOptions As String = InputBox("Command line parameters for OCaml", "Startup Options", My.Settings.StartupOptions)
        If startupOptions Then
            My.Settings.StartupOptions = startupOptions
        End If
    End Sub
End Class
