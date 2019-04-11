<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.TabControl = New TradeWright.UI.Forms.TabControlExtra()
        Me.OutputBox = New System.Windows.Forms.RichTextBox()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToutEnregistrerMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CleanOutputMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopierMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedoMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OcamlMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExecuteMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OutputMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PartialOutputMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FullOutputMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseOcamlMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ThemeMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LightModeMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DarkModeMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoSaveMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnableAutoSaveMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoSaveDelayMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OcamlDocMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OcamlFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.LibrariesBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.AutoSaveTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.SaveLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StateLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ElapsedTimer = New System.Windows.Forms.Timer(Me.components)
        Me.RefreshTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer
        '
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.Location = New System.Drawing.Point(0, 28)
        Me.SplitContainer.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer.Name = "SplitContainer"
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.Controls.Add(Me.TabControl)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.OutputBox)
        Me.SplitContainer.Size = New System.Drawing.Size(1025, 431)
        Me.SplitContainer.SplitterDistance = 537
        Me.SplitContainer.SplitterWidth = 5
        Me.SplitContainer.TabIndex = 2
        '
        'TabControl
        '
        '
        '
        '
        Me.TabControl.DisplayStyleProvider.BlendStyle = TradeWright.UI.Forms.BlendStyle.Normal
        Me.TabControl.DisplayStyleProvider.BorderColorDisabled = System.Drawing.SystemColors.ControlLight
        Me.TabControl.DisplayStyleProvider.BorderColorFocused = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControl.DisplayStyleProvider.BorderColorHighlighted = System.Drawing.SystemColors.ControlDark
        Me.TabControl.DisplayStyleProvider.BorderColorSelected = System.Drawing.SystemColors.ControlDark
        Me.TabControl.DisplayStyleProvider.BorderColorUnselected = System.Drawing.SystemColors.ControlDark
        Me.TabControl.DisplayStyleProvider.CloserButtonFillColorFocused = System.Drawing.Color.Empty
        Me.TabControl.DisplayStyleProvider.CloserButtonFillColorFocusedActive = System.Drawing.Color.Empty
        Me.TabControl.DisplayStyleProvider.CloserButtonFillColorHighlighted = System.Drawing.Color.Empty
        Me.TabControl.DisplayStyleProvider.CloserButtonFillColorHighlightedActive = System.Drawing.Color.Empty
        Me.TabControl.DisplayStyleProvider.CloserButtonFillColorSelected = System.Drawing.Color.Empty
        Me.TabControl.DisplayStyleProvider.CloserButtonFillColorSelectedActive = System.Drawing.Color.Empty
        Me.TabControl.DisplayStyleProvider.CloserButtonFillColorUnselected = System.Drawing.Color.Empty
        Me.TabControl.DisplayStyleProvider.CloserButtonOutlineColorFocused = System.Drawing.Color.Empty
        Me.TabControl.DisplayStyleProvider.CloserButtonOutlineColorFocusedActive = System.Drawing.Color.Empty
        Me.TabControl.DisplayStyleProvider.CloserButtonOutlineColorHighlighted = System.Drawing.Color.Empty
        Me.TabControl.DisplayStyleProvider.CloserButtonOutlineColorHighlightedActive = System.Drawing.Color.Empty
        Me.TabControl.DisplayStyleProvider.CloserButtonOutlineColorSelected = System.Drawing.Color.Empty
        Me.TabControl.DisplayStyleProvider.CloserButtonOutlineColorSelectedActive = System.Drawing.Color.Empty
        Me.TabControl.DisplayStyleProvider.CloserButtonOutlineColorUnselected = System.Drawing.Color.Empty
        Me.TabControl.DisplayStyleProvider.CloserColorFocused = System.Drawing.SystemColors.ControlDark
        Me.TabControl.DisplayStyleProvider.CloserColorFocusedActive = System.Drawing.SystemColors.ControlDark
        Me.TabControl.DisplayStyleProvider.CloserColorHighlighted = System.Drawing.SystemColors.ControlDark
        Me.TabControl.DisplayStyleProvider.CloserColorHighlightedActive = System.Drawing.SystemColors.ControlDark
        Me.TabControl.DisplayStyleProvider.CloserColorSelected = System.Drawing.SystemColors.ControlDark
        Me.TabControl.DisplayStyleProvider.CloserColorSelectedActive = System.Drawing.SystemColors.ControlDark
        Me.TabControl.DisplayStyleProvider.CloserColorUnselected = System.Drawing.Color.Empty
        Me.TabControl.DisplayStyleProvider.FocusTrack = False
        Me.TabControl.DisplayStyleProvider.HotTrack = True
        Me.TabControl.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TabControl.DisplayStyleProvider.Opacity = 1.0!
        Me.TabControl.DisplayStyleProvider.Overlap = 0
        Me.TabControl.DisplayStyleProvider.Padding = New System.Drawing.Point(6, 3)
        Me.TabControl.DisplayStyleProvider.PageBackgroundColorDisabled = System.Drawing.SystemColors.Control
        Me.TabControl.DisplayStyleProvider.PageBackgroundColorFocused = System.Drawing.SystemColors.ControlLight
        Me.TabControl.DisplayStyleProvider.PageBackgroundColorHighlighted = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControl.DisplayStyleProvider.PageBackgroundColorSelected = System.Drawing.SystemColors.ControlLightLight
        Me.TabControl.DisplayStyleProvider.PageBackgroundColorUnselected = System.Drawing.SystemColors.Control
        Me.TabControl.DisplayStyleProvider.Radius = 2
        Me.TabControl.DisplayStyleProvider.SelectedTabIsLarger = True
        Me.TabControl.DisplayStyleProvider.ShowTabCloser = False
        Me.TabControl.DisplayStyleProvider.TabColorDisabled1 = System.Drawing.SystemColors.Control
        Me.TabControl.DisplayStyleProvider.TabColorDisabled2 = System.Drawing.SystemColors.Control
        Me.TabControl.DisplayStyleProvider.TabColorFocused1 = System.Drawing.SystemColors.ControlLight
        Me.TabControl.DisplayStyleProvider.TabColorFocused2 = System.Drawing.SystemColors.ControlLight
        Me.TabControl.DisplayStyleProvider.TabColorHighLighted1 = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControl.DisplayStyleProvider.TabColorHighLighted2 = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControl.DisplayStyleProvider.TabColorSelected1 = System.Drawing.SystemColors.ControlLightLight
        Me.TabControl.DisplayStyleProvider.TabColorSelected2 = System.Drawing.SystemColors.ControlLightLight
        Me.TabControl.DisplayStyleProvider.TabColorUnSelected1 = System.Drawing.SystemColors.Control
        Me.TabControl.DisplayStyleProvider.TabColorUnSelected2 = System.Drawing.SystemColors.Control
        Me.TabControl.DisplayStyleProvider.TabPageMargin = New System.Windows.Forms.Padding(1)
        Me.TabControl.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark
        Me.TabControl.DisplayStyleProvider.TextColorFocused = System.Drawing.SystemColors.ControlText
        Me.TabControl.DisplayStyleProvider.TextColorHighlighted = System.Drawing.SystemColors.ControlText
        Me.TabControl.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText
        Me.TabControl.DisplayStyleProvider.TextColorUnselected = System.Drawing.SystemColors.ControlText
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.HotTrack = True
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(537, 431)
        Me.TabControl.TabIndex = 0
        '
        'OutputBox
        '
        Me.OutputBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OutputBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OutputBox.Location = New System.Drawing.Point(0, 0)
        Me.OutputBox.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.OutputBox.Name = "OutputBox"
        Me.OutputBox.ReadOnly = True
        Me.OutputBox.Size = New System.Drawing.Size(483, 431)
        Me.OutputBox.TabIndex = 2
        Me.OutputBox.Text = ""
        '
        'SaveFileDialog
        '
        Me.SaveFileDialog.Filter = "Fichier OCaml|*.ml;*.oml;*.mli"
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.Filter = "Fichier OCaml|*.ml;*.oml;*.mli"
        '
        'MenuStrip
        '
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenuItem, Me.EditMenuItem, Me.OcamlMenuItem, Me.SettingsMenuItem, Me.HelpMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip.Size = New System.Drawing.Size(1025, 28)
        Me.MenuStrip.TabIndex = 3
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'FileMenuItem
        '
        Me.FileMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewMenuItem, Me.OpenMenuItem, Me.SaveMenuItem, Me.SaveAsMenuItem, Me.ToutEnregistrerMenuItem})
        Me.FileMenuItem.Name = "FileMenuItem"
        Me.FileMenuItem.Size = New System.Drawing.Size(64, 24)
        Me.FileMenuItem.Text = "Fichier"
        '
        'NewMenuItem
        '
        Me.NewMenuItem.Name = "NewMenuItem"
        Me.NewMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewMenuItem.Size = New System.Drawing.Size(273, 26)
        Me.NewMenuItem.Text = "Nouveau"
        '
        'OpenMenuItem
        '
        Me.OpenMenuItem.Name = "OpenMenuItem"
        Me.OpenMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenMenuItem.Size = New System.Drawing.Size(273, 26)
        Me.OpenMenuItem.Text = "Ouvrir"
        '
        'SaveMenuItem
        '
        Me.SaveMenuItem.Name = "SaveMenuItem"
        Me.SaveMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveMenuItem.Size = New System.Drawing.Size(273, 26)
        Me.SaveMenuItem.Text = "Enregistrer"
        '
        'SaveAsMenuItem
        '
        Me.SaveAsMenuItem.Name = "SaveAsMenuItem"
        Me.SaveAsMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveAsMenuItem.Size = New System.Drawing.Size(273, 26)
        Me.SaveAsMenuItem.Text = "Enregistrer sous"
        '
        'ToutEnregistrerMenuItem
        '
        Me.ToutEnregistrerMenuItem.Name = "ToutEnregistrerMenuItem"
        Me.ToutEnregistrerMenuItem.Size = New System.Drawing.Size(273, 26)
        Me.ToutEnregistrerMenuItem.Text = "Tout enregistrer"
        '
        'EditMenuItem
        '
        Me.EditMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CleanOutputMenuItem, Me.CopierMenuItem, Me.UndoMenuItem, Me.RedoMenuItem})
        Me.EditMenuItem.Name = "EditMenuItem"
        Me.EditMenuItem.Size = New System.Drawing.Size(68, 24)
        Me.EditMenuItem.Text = "Edition"
        '
        'CleanOutputMenuItem
        '
        Me.CleanOutputMenuItem.Name = "CleanOutputMenuItem"
        Me.CleanOutputMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.CleanOutputMenuItem.Text = "Nettoyer la sortie"
        '
        'CopierMenuItem
        '
        Me.CopierMenuItem.Name = "CopierMenuItem"
        Me.CopierMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopierMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.CopierMenuItem.Text = "Copier"
        '
        'UndoMenuItem
        '
        Me.UndoMenuItem.Name = "UndoMenuItem"
        Me.UndoMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.UndoMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.UndoMenuItem.Text = "Undo"
        '
        'RedoMenuItem
        '
        Me.RedoMenuItem.Name = "RedoMenuItem"
        Me.RedoMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.RedoMenuItem.Size = New System.Drawing.Size(199, 26)
        Me.RedoMenuItem.Text = "Redo"
        '
        'OcamlMenuItem
        '
        Me.OcamlMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExecuteMenuItem, Me.OutputMenuItem, Me.CloseOcamlMenuItem})
        Me.OcamlMenuItem.Name = "OcamlMenuItem"
        Me.OcamlMenuItem.Size = New System.Drawing.Size(66, 24)
        Me.OcamlMenuItem.Text = "OCaml"
        '
        'ExecuteMenuItem
        '
        Me.ExecuteMenuItem.Name = "ExecuteMenuItem"
        Me.ExecuteMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)
        Me.ExecuteMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.ExecuteMenuItem.Text = "Exécuter"
        '
        'OutputMenuItem
        '
        Me.OutputMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PartialOutputMenuItem, Me.FullOutputMenuItem})
        Me.OutputMenuItem.Name = "OutputMenuItem"
        Me.OutputMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.OutputMenuItem.Text = "Sortie"
        '
        'PartialOutputMenuItem
        '
        Me.PartialOutputMenuItem.CheckOnClick = True
        Me.PartialOutputMenuItem.Name = "PartialOutputMenuItem"
        Me.PartialOutputMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.PartialOutputMenuItem.Text = "Partielle"
        '
        'FullOutputMenuItem
        '
        Me.FullOutputMenuItem.CheckOnClick = True
        Me.FullOutputMenuItem.Name = "FullOutputMenuItem"
        Me.FullOutputMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.FullOutputMenuItem.Text = "Complète"
        '
        'CloseOcamlMenuItem
        '
        Me.CloseOcamlMenuItem.Name = "CloseOcamlMenuItem"
        Me.CloseOcamlMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.CloseOcamlMenuItem.Text = "Fermer"
        '
        'SettingsMenuItem
        '
        Me.SettingsMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ThemeMenuItem, Me.AutoSaveMenuItem})
        Me.SettingsMenuItem.Name = "SettingsMenuItem"
        Me.SettingsMenuItem.Size = New System.Drawing.Size(94, 24)
        Me.SettingsMenuItem.Text = "Paramètres"
        '
        'ThemeMenuItem
        '
        Me.ThemeMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LightModeMenuItem, Me.DarkModeMenuItem})
        Me.ThemeMenuItem.Name = "ThemeMenuItem"
        Me.ThemeMenuItem.Size = New System.Drawing.Size(251, 26)
        Me.ThemeMenuItem.Text = "Thème"
        '
        'LightModeMenuItem
        '
        Me.LightModeMenuItem.CheckOnClick = True
        Me.LightModeMenuItem.Name = "LightModeMenuItem"
        Me.LightModeMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.LightModeMenuItem.Text = "Light Mode"
        '
        'DarkModeMenuItem
        '
        Me.DarkModeMenuItem.CheckOnClick = True
        Me.DarkModeMenuItem.Name = "DarkModeMenuItem"
        Me.DarkModeMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.DarkModeMenuItem.Text = "Dark Mode"
        '
        'AutoSaveMenuItem
        '
        Me.AutoSaveMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnableAutoSaveMenuItem, Me.AutoSaveDelayMenuItem})
        Me.AutoSaveMenuItem.Name = "AutoSaveMenuItem"
        Me.AutoSaveMenuItem.Size = New System.Drawing.Size(251, 26)
        Me.AutoSaveMenuItem.Text = "Sauvegarde automatique"
        '
        'EnableAutoSaveMenuItem
        '
        Me.EnableAutoSaveMenuItem.CheckOnClick = True
        Me.EnableAutoSaveMenuItem.Name = "EnableAutoSaveMenuItem"
        Me.EnableAutoSaveMenuItem.Size = New System.Drawing.Size(220, 26)
        Me.EnableAutoSaveMenuItem.Text = "Activer"
        '
        'AutoSaveDelayMenuItem
        '
        Me.AutoSaveDelayMenuItem.Name = "AutoSaveDelayMenuItem"
        Me.AutoSaveDelayMenuItem.Size = New System.Drawing.Size(220, 26)
        Me.AutoSaveDelayMenuItem.Text = "Délai de sauvegarde"
        '
        'HelpMenuItem
        '
        Me.HelpMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OcamlDocMenuItem, Me.AboutMenuItem})
        Me.HelpMenuItem.Name = "HelpMenuItem"
        Me.HelpMenuItem.Size = New System.Drawing.Size(52, 24)
        Me.HelpMenuItem.Text = "Aide"
        '
        'OcamlDocMenuItem
        '
        Me.OcamlDocMenuItem.Name = "OcamlDocMenuItem"
        Me.OcamlDocMenuItem.Size = New System.Drawing.Size(236, 26)
        Me.OcamlDocMenuItem.Text = "Documentation OCaml"
        '
        'AboutMenuItem
        '
        Me.AboutMenuItem.Name = "AboutMenuItem"
        Me.AboutMenuItem.Size = New System.Drawing.Size(236, 26)
        Me.AboutMenuItem.Text = "A propos"
        '
        'AutoSaveTimer
        '
        Me.AutoSaveTimer.Interval = 5000
        '
        'StatusStrip
        '
        Me.StatusStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveLabel, Me.StateLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 459)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip.Size = New System.Drawing.Size(1025, 22)
        Me.StatusStrip.TabIndex = 4
        Me.StatusStrip.Text = "StatusStrip"
        '
        'SaveLabel
        '
        Me.SaveLabel.Name = "SaveLabel"
        Me.SaveLabel.Size = New System.Drawing.Size(0, 17)
        '
        'StateLabel
        '
        Me.StateLabel.Name = "StateLabel"
        Me.StateLabel.Size = New System.Drawing.Size(0, 17)
        '
        'ElapsedTimer
        '
        Me.ElapsedTimer.Interval = 30000
        '
        'RefreshTimer
        '
        Me.RefreshTimer.Enabled = True
        Me.RefreshTimer.Interval = 50
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1025, 481)
        Me.Controls.Add(Me.SplitContainer)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Main"
        Me.Text = "SimpleOCaml"
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer.ResumeLayout(False)
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer As SplitContainer
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents FileMenuItem As ToolStripMenuItem
    Friend WithEvents EditMenuItem As ToolStripMenuItem
    Friend WithEvents HelpMenuItem As ToolStripMenuItem
    Friend WithEvents NewMenuItem As ToolStripMenuItem
    Friend WithEvents OpenMenuItem As ToolStripMenuItem
    Friend WithEvents SaveMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsMenuItem As ToolStripMenuItem
    Friend WithEvents OcamlMenuItem As ToolStripMenuItem
    Friend WithEvents ExecuteMenuItem As ToolStripMenuItem
    Friend WithEvents OcamlDocMenuItem As ToolStripMenuItem
    Friend WithEvents OutputMenuItem As ToolStripMenuItem
    Friend WithEvents FullOutputMenuItem As ToolStripMenuItem
    Friend WithEvents PartialOutputMenuItem As ToolStripMenuItem
    Friend WithEvents OcamlFileDialog As OpenFileDialog
    Friend WithEvents LibrariesBrowserDialog As FolderBrowserDialog
    Friend WithEvents AboutMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsMenuItem As ToolStripMenuItem
    Friend WithEvents ThemeMenuItem As ToolStripMenuItem
    Friend WithEvents LightModeMenuItem As ToolStripMenuItem
    Friend WithEvents DarkModeMenuItem As ToolStripMenuItem
    Friend WithEvents OutputBox As RichTextBox
    Friend WithEvents CloseOcamlMenuItem As ToolStripMenuItem
    Friend WithEvents CleanOutputMenuItem As ToolStripMenuItem
    Friend WithEvents AutoSaveTimer As Timer
    Friend WithEvents AutoSaveMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents SaveLabel As ToolStripStatusLabel
    Friend WithEvents EnableAutoSaveMenuItem As ToolStripMenuItem
    Friend WithEvents AutoSaveDelayMenuItem As ToolStripMenuItem
    Friend WithEvents TabControl As TradeWright.UI.Forms.TabControlExtra
    Friend WithEvents StateLabel As ToolStripStatusLabel
    Friend WithEvents ElapsedTimer As Timer
    Friend WithEvents CopierMenuItem As ToolStripMenuItem
    Friend WithEvents UndoMenuItem As ToolStripMenuItem
    Friend WithEvents RedoMenuItem As ToolStripMenuItem
    Friend WithEvents ToutEnregistrerMenuItem As ToolStripMenuItem
    Friend WithEvents RefreshTimer As Timer
End Class
