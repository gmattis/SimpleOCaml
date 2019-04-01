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
    Private WithEvents FullOutputMenuItem As ToolStripMenuItem = Main.FullOutputMenuItem
    Private WithEvents CloseOcamlMenuItem As ToolStripMenuItem = Main.CloseOcamlMenuItem
    Private WithEvents SettingsMenuItem As ToolStripMenuItem = Main.SettingsMenuItem
    Private WithEvents ThemeMenuItem As ToolStripMenuItem = Main.ThemeMenuItem
    Private WithEvents LightModeMenuItem As ToolStripMenuItem = Main.LightModeMenuItem
    Private WithEvents DarkModeMenuItem As ToolStripMenuItem = Main.DarkModeMenuItem
    Private WithEvents AutoSaveMenuItem As ToolStripMenuItem = Main.AutoSaveMenuItem
    Private WithEvents EnableAutoSaveMenuItem As ToolStripMenuItem = Main.EnableAutoSaveMenuItem
    Private WithEvents AutoSaveDelayMenuItem As ToolStripMenuItem = Main.AutoSaveDelayMenuItem
    Private WithEvents HelpMenuItem As ToolStripMenuItem = Main.HelpMenuItem
    Private WithEvents OcamlDocMenuItem As ToolStripMenuItem = Main.OcamlDocMenuItem
    Private WithEvents AboutMenuItem As ToolStripMenuItem = Main.AboutMenuItem

    Private WithEvents OpenFileDialog As OpenFileDialog = Main.OpenFileDialog
    Private WithEvents SaveFileDialog As SaveFileDialog = Main.SaveFileDialog

    Private Sub SaveFile() Handles SaveMenuItem.Click
        Dim CurrentTextbox As FastColoredTextBox = TryCast(Main.TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
        If Main.TabControl.SelectedTab.Tag(0) = "" Or Not System.IO.File.Exists(Main.TabControl.SelectedTab.Tag(0)) Then
            SaveAsFile()
        Else
            Dim savePath As String = Main.TabControl.SelectedTab.Tag(0)
            System.IO.File.WriteAllText(savePath, CurrentTextbox.Text, System.Text.Encoding.Default)
        End If

        Main.TabControl.SelectedTab.Tag(1) = True
        Main.TabControl.SelectedTab.Text = Main.TabControl.SelectedTab.Tag(0).ToString.Substring(Main.TabControl.SelectedTab.Tag(0).ToString.LastIndexOf("\") + 1)
    End Sub

    Private Sub SaveAsFile() Handles SaveAsMenuItem.Click
        SaveFileDialog.ShowDialog()
    End Sub

    Private Sub OnSaveAsFile(sender As Object, e As EventArgs) Handles SaveFileDialog.FileOk
        Dim CurrentTextbox As FastColoredTextBox = TryCast(Main.TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
        Dim savePath As String = SaveFileDialog.FileName
        System.IO.File.WriteAllText(savePath, CurrentTextbox.Text, System.Text.Encoding.Default)
        Main.TabControl.SelectedTab.Tag(0) = savePath
        Main.TabControl.SelectedTab.Text = SaveFileDialog.FileName.Substring(SaveFileDialog.FileName.LastIndexOf("\") + 1)

        Main.TabControl.SelectedTab.Tag(1) = True
    End Sub

    Private Sub OpenFile() Handles OpenMenuItem.Click
        OpenFileDialog.ShowDialog()
    End Sub

    Private Sub OnOpenFile(sender As Object, e As EventArgs) Handles OpenFileDialog.FileOk
        Main.AddNewPage()
        Dim CurrentTextbox As FastColoredTextBox = TryCast(Main.TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
        Dim openPath As String = OpenFileDialog.FileName
        Main.TabControl.SelectedTab.Text = OpenFileDialog.SafeFileName
        Main.TabControl.SelectedTab.Tag(0) = openPath
        Main.TabControl.SelectedTab.Tag(1) = True
        CurrentTextbox.Text = System.IO.File.ReadAllText(openPath, System.Text.Encoding.Default)
    End Sub

    Private Sub NewMenuItem_Click(sender As Object, e As EventArgs) Handles NewMenuItem.Click
        Main.AddNewPage()
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
        For Each tab As TabPage In Main.TabControl.TabPages
            With Main
                .BackColor = Color.FromArgb(60, 60, 60)
                .ForeColor = Color.LightGray
            End With
            With Main.SplitContainer
                .BackColor = Color.FromArgb(60, 60, 60)
                .ForeColor = Color.LightGray
            End With
            With TryCast(tab.Controls(0), FastColoredTextBox)
                .BackColor = Color.FromArgb(45, 45, 45)
                .ForeColor = Color.LightGray
            End With
            With Main.OutputBox
                .BackColor = Color.FromArgb(45, 45, 45)
                .ForeColor = Color.LightGray
            End With
            With Main.MenuStrip
                .BackColor = Color.FromArgb(60, 60, 60)
                .ForeColor = Color.LightGray
            End With
            For Each ctrl As TabPage In Main.TabControl.TabPages
                ctrl.BackColor = Color.FromArgb(60, 60, 60)
                ctrl.ForeColor = Color.LightGray
            Next
            For Each ctrl As ToolStripMenuItem In Main.MenuStrip.Controls
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
        For Each tab As TabPage In Main.TabControl.TabPages
            With Main
                .BackColor = Color.FromArgb(60, 60, 60)
                .ForeColor = Color.LightGray
            End With
            With Main.SplitContainer
                .BackColor = Color.FromArgb(60, 60, 60)
                .ForeColor = Color.LightGray
            End With
            With TryCast(tab.Controls(0), FastColoredTextBox)
                .BackColor = Color.FromArgb(45, 45, 45)
                .ForeColor = Color.LightGray
            End With
            With Main.OutputBox
                .BackColor = Color.FromArgb(45, 45, 45)
                .ForeColor = Color.LightGray
            End With
            With Main.MenuStrip
                .BackColor = Color.FromArgb(60, 60, 60)
                .ForeColor = Color.LightGray
            End With
            For Each ctrl As TabPage In Main.TabControl.TabPages
                ctrl.BackColor = Color.FromArgb(60, 60, 60)
                ctrl.ForeColor = Color.LightGray
            Next
            For Each ctrl As ToolStripMenuItem In Main.MenuStrip.Controls
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
        Main._commandExecutor.Dispose()
        Main.OutputBox.AppendText("OCaml a été fermé" & vbLf)
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
            Dim Delay As Integer = InputBox("Veuillez définir le délai en secondes entre deux sauvegardes automatiques", "Délai de sauvegarde", My.Settings.Autosave_delay)
            My.Settings.Autosave_delay = Delay
            Main.AutoSaveTimer.Interval = Delay * 1000
        Catch
            MsgBox("Veuillez entrer un nombre valide")
        End Try
    End Sub
End Class
