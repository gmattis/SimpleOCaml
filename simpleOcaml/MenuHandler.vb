﻿Imports FastColoredTextBoxNS

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
    Private WithEvents HelpMenuItem As ToolStripMenuItem = Main.HelpMenuItem
    Private WithEvents OcamlDocMenuItem As ToolStripMenuItem = Main.OcamlDocMenuItem
    Private WithEvents AboutMenuItem As ToolStripMenuItem = Main.AboutMenuItem
    Private WithEvents CopierMenuItem As ToolStripMenuItem = Main.CopyMenuItem
    Private WithEvents PasteMenuItem As ToolStripMenuItem = Main.PasteMenuItem
    Private WithEvents UndoMenuItem As ToolStripMenuItem = Main.UndoMenuItem
    Private WithEvents RedoMenuItem As ToolStripMenuItem = Main.RedoMenuItem
    Private WithEvents SaveAllMenuItem As ToolStripMenuItem = Main.SaveAllMenuItem
    Private WithEvents FindMenuItem As ToolStripMenuItem = Main.FindMenuItem
    Private WithEvents ReplaceMenuItem As ToolStripMenuItem = Main.ReplaceMenuItem

    Private WithEvents OpenFileDialog As OpenFileDialog = Main.OpenFileDialog
    Private WithEvents SaveFileDialog As SaveFileDialog = Main.SaveFileDialog

    Private Sub SaveFile() Handles SaveMenuItem.Click
        Dim CurrentTextbox As FastColoredTextBox = TryCast(Main.TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
        If Main.TabControl.SelectedTab.Tag(0) = "" OrElse Not System.IO.File.Exists(Main.TabControl.SelectedTab.Tag(0)) Then
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
        SaveFileDialog.FileName = System.IO.Path.GetFileName(Main.TabControl.SelectedTab.Tag(0))
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
        Dim CurrentPage As TabPage = Main.TabControl.SelectedTab
        Dim CurrentTextbox As FastColoredTextBox = TryCast(CurrentPage.Controls.Item(0), FastColoredTextBox)
        If Not (CurrentPage.Tag(0) = "" AndAlso CurrentTextbox.Text = "") Then
            Main.AddNewPage(True)
        End If
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

    Private Sub OcamlDocMenuItem_Click(sender As Object, e As EventArgs) Handles OcamlDocMenuItem.Click
        If System.IO.File.Exists("doc/index.html") Then
            Process.Start(System.IO.Path.GetFullPath("doc/index.html"))
        Else
            Process.Start("http://caml.inria.fr/pub/docs/manual-ocaml/")
        End If
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

    Private Sub CopierMenuItem_Click(sender As Object, e As EventArgs) Handles CopierMenuItem.Click
        Dim CurrentTextbox = FindFocussedControl(Main.ActiveControl)
        If CurrentTextbox.GetType().Equals(GetType(FastColoredTextBox)) Then
            If TryCast(CurrentTextbox, FastColoredTextBox).SelectedText <> "" Then
                Clipboard.SetText(TryCast(CurrentTextbox, FastColoredTextBox).SelectedText)
            End If
        ElseIf CurrentTextbox.GetType().Equals(GetType(RichTextBox)) Then
            If TryCast(CurrentTextbox, RichTextBox).SelectedText <> "" Then
                Clipboard.SetText(TryCast(CurrentTextbox, RichTextBox).SelectedText)
            End If
        End If
    End Sub

    Private Sub UndoMenuItem_Click(sender As Object, e As EventArgs) Handles UndoMenuItem.Click
        TryCast(Main.TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox).Undo()
    End Sub

    Private Sub RedoMenuItem_Click(sender As Object, e As EventArgs) Handles RedoMenuItem.Click
        TryCast(Main.TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox).Redo()
    End Sub

    Private Sub SaveAllMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAllMenuItem.Click
        For Each page As TabPage In Main.TabControl.TabPages
            If page.Tag(0) <> "" And Not page.Tag(1) Then
                TryCast(page.Controls.Item(0), FastColoredTextBox).SaveToFile(page.Tag(0), System.Text.Encoding.Default)
                page.Tag(1) = True
                page.Text = System.IO.Path.GetFileName(page.Tag(0))
            End If
        Next
    End Sub

    Private Sub SettingsMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsMenuItem.Click
        Settings.Show()
    End Sub

    Private Sub FindMenuItem_Click(sender As Object, e As EventArgs) Handles FindMenuItem.Click
        FindReplace.Show()
        FindReplace.TabControl.SelectTab(0)
    End Sub

    Private Sub ReplaceMenuItem_Click(sender As Object, e As EventArgs) Handles ReplaceMenuItem.Click
        FindReplace.Show()
        FindReplace.TabControl.SelectTab(1)
    End Sub
End Class
