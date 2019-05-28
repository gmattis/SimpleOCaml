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
        Me.MainSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.TabControl = New TradeWright.UI.Forms.TabControlExtra()
        Me.OutputSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.OutputBox = New System.Windows.Forms.RichTextBox()
        Me.FastInputBox = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAllMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CleanOutputMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedoMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OcamlMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExecuteMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExecuteAllMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OutputMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PartialOutputMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetailedOutputMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseOcamlMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartupOptionsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OcamlDocMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.AutoSaveTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.SaveLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StateLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ElapsedTimer = New System.Windows.Forms.Timer(Me.components)
        Me.RefreshTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.MainSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainSplitContainer.Panel1.SuspendLayout()
        Me.MainSplitContainer.Panel2.SuspendLayout()
        Me.MainSplitContainer.SuspendLayout()
        CType(Me.OutputSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.OutputSplitContainer.Panel1.SuspendLayout()
        Me.OutputSplitContainer.Panel2.SuspendLayout()
        Me.OutputSplitContainer.SuspendLayout()
        CType(Me.FastInputBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainSplitContainer
        '
        Me.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainSplitContainer.Location = New System.Drawing.Point(0, 24)
        Me.MainSplitContainer.Name = "MainSplitContainer"
        '
        'MainSplitContainer.Panel1
        '
        Me.MainSplitContainer.Panel1.Controls.Add(Me.TabControl)
        '
        'MainSplitContainer.Panel2
        '
        Me.MainSplitContainer.Panel2.Controls.Add(Me.OutputSplitContainer)
        Me.MainSplitContainer.Size = New System.Drawing.Size(769, 345)
        Me.MainSplitContainer.SplitterDistance = 402
        Me.MainSplitContainer.TabIndex = 2
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
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(402, 345)
        Me.TabControl.TabIndex = 0
        '
        'OutputSplitContainer
        '
        Me.OutputSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OutputSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.OutputSplitContainer.Name = "OutputSplitContainer"
        Me.OutputSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'OutputSplitContainer.Panel1
        '
        Me.OutputSplitContainer.Panel1.Controls.Add(Me.OutputBox)
        '
        'OutputSplitContainer.Panel2
        '
        Me.OutputSplitContainer.Panel2.Controls.Add(Me.FastInputBox)
        Me.OutputSplitContainer.Size = New System.Drawing.Size(363, 345)
        Me.OutputSplitContainer.SplitterDistance = 316
        Me.OutputSplitContainer.TabIndex = 1
        '
        'OutputBox
        '
        Me.OutputBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OutputBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OutputBox.Location = New System.Drawing.Point(0, 0)
        Me.OutputBox.Name = "OutputBox"
        Me.OutputBox.ReadOnly = True
        Me.OutputBox.Size = New System.Drawing.Size(363, 316)
        Me.OutputBox.TabIndex = 0
        Me.OutputBox.Text = ""
        '
        'FastInputBox
        '
        Me.FastInputBox.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.FastInputBox.AutoIndentCharsPatterns = "^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>[^;=]+);" & Global.Microsoft.VisualBasic.ChrW(10) & "^\s*(case|default)\s*[^:]*(" &
    "?<range>:)\s*(?<range>[^;]+);"
        Me.FastInputBox.AutoScrollMinSize = New System.Drawing.Size(2, 14)
        Me.FastInputBox.BackBrush = Nothing
        Me.FastInputBox.CharHeight = 14
        Me.FastInputBox.CharWidth = 8
        Me.FastInputBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FastInputBox.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.FastInputBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FastInputBox.Font = New System.Drawing.Font("Courier New", 9.75!)
        Me.FastInputBox.IsReplaceMode = False
        Me.FastInputBox.Location = New System.Drawing.Point(0, 0)
        Me.FastInputBox.Name = "FastInputBox"
        Me.FastInputBox.Paddings = New System.Windows.Forms.Padding(0)
        Me.FastInputBox.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FastInputBox.ServiceColors = CType(resources.GetObject("FastInputBox.ServiceColors"), FastColoredTextBoxNS.ServiceColors)
        Me.FastInputBox.ShowLineNumbers = False
        Me.FastInputBox.Size = New System.Drawing.Size(363, 25)
        Me.FastInputBox.TabIndex = 0
        Me.FastInputBox.Zoom = 100
        '
        'SaveFileDialog
        '
        Me.SaveFileDialog.Filter = "OCaml File|*.ml;*.oml;*.mli"
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.Filter = "OCaml File|*.ml;*.oml;*.mli"
        '
        'MenuStrip
        '
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenuItem, Me.EditMenuItem, Me.OcamlMenuItem, Me.SettingsMenuItem, Me.HelpMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(769, 24)
        Me.MenuStrip.TabIndex = 3
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'FileMenuItem
        '
        Me.FileMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewMenuItem, Me.OpenMenuItem, Me.SaveMenuItem, Me.SaveAsMenuItem, Me.SaveAllMenuItem})
        Me.FileMenuItem.Name = "FileMenuItem"
        Me.FileMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileMenuItem.Text = "File"
        '
        'NewMenuItem
        '
        Me.NewMenuItem.Name = "NewMenuItem"
        Me.NewMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.NewMenuItem.Text = "New"
        '
        'OpenMenuItem
        '
        Me.OpenMenuItem.Name = "OpenMenuItem"
        Me.OpenMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.OpenMenuItem.Text = "Open"
        '
        'SaveMenuItem
        '
        Me.SaveMenuItem.Name = "SaveMenuItem"
        Me.SaveMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SaveMenuItem.Text = "Save"
        '
        'SaveAsMenuItem
        '
        Me.SaveAsMenuItem.Name = "SaveAsMenuItem"
        Me.SaveAsMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveAsMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SaveAsMenuItem.Text = "Save as"
        '
        'SaveAllMenuItem
        '
        Me.SaveAllMenuItem.Name = "SaveAllMenuItem"
        Me.SaveAllMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SaveAllMenuItem.Text = "Save all"
        '
        'EditMenuItem
        '
        Me.EditMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CleanOutputMenuItem, Me.CopyMenuItem, Me.PasteMenuItem, Me.UndoMenuItem, Me.RedoMenuItem})
        Me.EditMenuItem.Name = "EditMenuItem"
        Me.EditMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditMenuItem.Text = "Edit"
        '
        'CleanOutputMenuItem
        '
        Me.CleanOutputMenuItem.Name = "CleanOutputMenuItem"
        Me.CleanOutputMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.CleanOutputMenuItem.Text = "CleanOutput"
        '
        'CopyMenuItem
        '
        Me.CopyMenuItem.Name = "CopyMenuItem"
        Me.CopyMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.CopyMenuItem.Text = "Copy"
        '
        'PasteMenuItem
        '
        Me.PasteMenuItem.Name = "PasteMenuItem"
        Me.PasteMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.PasteMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.PasteMenuItem.Text = "Paste"
        '
        'UndoMenuItem
        '
        Me.UndoMenuItem.Name = "UndoMenuItem"
        Me.UndoMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.UndoMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.UndoMenuItem.Text = "Undo"
        '
        'RedoMenuItem
        '
        Me.RedoMenuItem.Name = "RedoMenuItem"
        Me.RedoMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.RedoMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.RedoMenuItem.Text = "Redo"
        '
        'OcamlMenuItem
        '
        Me.OcamlMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExecuteMenuItem, Me.ExecuteAllMenuItem, Me.OutputMenuItem, Me.CloseOcamlMenuItem, Me.StartupOptionsMenuItem})
        Me.OcamlMenuItem.Name = "OcamlMenuItem"
        Me.OcamlMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.OcamlMenuItem.Text = "OCaml"
        '
        'ExecuteMenuItem
        '
        Me.ExecuteMenuItem.Name = "ExecuteMenuItem"
        Me.ExecuteMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)
        Me.ExecuteMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.ExecuteMenuItem.Text = "Execute"
        '
        'ExecuteAllMenuItem
        '
        Me.ExecuteAllMenuItem.Name = "ExecuteAllMenuItem"
        Me.ExecuteAllMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)
        Me.ExecuteAllMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.ExecuteAllMenuItem.Text = "Execute all"
        '
        'OutputMenuItem
        '
        Me.OutputMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PartialOutputMenuItem, Me.DetailedOutputMenuItem})
        Me.OutputMenuItem.Name = "OutputMenuItem"
        Me.OutputMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.OutputMenuItem.Text = "Output"
        '
        'PartialOutputMenuItem
        '
        Me.PartialOutputMenuItem.CheckOnClick = True
        Me.PartialOutputMenuItem.Name = "PartialOutputMenuItem"
        Me.PartialOutputMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.PartialOutputMenuItem.Text = "Partial"
        '
        'DetailedOutputMenuItem
        '
        Me.DetailedOutputMenuItem.CheckOnClick = True
        Me.DetailedOutputMenuItem.Name = "DetailedOutputMenuItem"
        Me.DetailedOutputMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.DetailedOutputMenuItem.Text = "Detailed"
        '
        'CloseOcamlMenuItem
        '
        Me.CloseOcamlMenuItem.Name = "CloseOcamlMenuItem"
        Me.CloseOcamlMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.K), System.Windows.Forms.Keys)
        Me.CloseOcamlMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.CloseOcamlMenuItem.Text = "Close OCaml"
        '
        'StartupOptionsMenuItem
        '
        Me.StartupOptionsMenuItem.Name = "StartupOptionsMenuItem"
        Me.StartupOptionsMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.StartupOptionsMenuItem.Text = "Startup options"
        '
        'SettingsMenuItem
        '
        Me.SettingsMenuItem.Name = "SettingsMenuItem"
        Me.SettingsMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsMenuItem.Text = "Settings"
        '
        'HelpMenuItem
        '
        Me.HelpMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OcamlDocMenuItem, Me.AboutMenuItem})
        Me.HelpMenuItem.Name = "HelpMenuItem"
        Me.HelpMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpMenuItem.Text = "Help"
        '
        'OcamlDocMenuItem
        '
        Me.OcamlDocMenuItem.Name = "OcamlDocMenuItem"
        Me.OcamlDocMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.OcamlDocMenuItem.Text = "OCaml Documentation"
        '
        'AboutMenuItem
        '
        Me.AboutMenuItem.Name = "AboutMenuItem"
        Me.AboutMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.AboutMenuItem.Text = "About"
        '
        'FolderBrowserDialog
        '
        Me.FolderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'AutoSaveTimer
        '
        Me.AutoSaveTimer.Interval = 5000
        '
        'StatusStrip
        '
        Me.StatusStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveLabel, Me.StateLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 369)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(769, 22)
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
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 391)
        Me.Controls.Add(Me.MainSplitContainer)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "Main"
        Me.Text = "SimpleOCaml"
        Me.MainSplitContainer.Panel1.ResumeLayout(False)
        Me.MainSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.MainSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainSplitContainer.ResumeLayout(False)
        Me.OutputSplitContainer.Panel1.ResumeLayout(False)
        Me.OutputSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.OutputSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.OutputSplitContainer.ResumeLayout(False)
        CType(Me.FastInputBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainSplitContainer As SplitContainer
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
    Friend WithEvents DetailedOutputMenuItem As ToolStripMenuItem
    Friend WithEvents PartialOutputMenuItem As ToolStripMenuItem
    Friend WithEvents FolderBrowserDialog As FolderBrowserDialog
    Friend WithEvents AboutMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsMenuItem As ToolStripMenuItem
    Friend WithEvents CloseOcamlMenuItem As ToolStripMenuItem
    Friend WithEvents CleanOutputMenuItem As ToolStripMenuItem
    Friend WithEvents AutoSaveTimer As Timer
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents SaveLabel As ToolStripStatusLabel
    Friend WithEvents TabControl As TradeWright.UI.Forms.TabControlExtra
    Friend WithEvents StateLabel As ToolStripStatusLabel
    Friend WithEvents ElapsedTimer As Timer
    Friend WithEvents CopyMenuItem As ToolStripMenuItem
    Friend WithEvents UndoMenuItem As ToolStripMenuItem
    Friend WithEvents RedoMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAllMenuItem As ToolStripMenuItem
    Friend WithEvents RefreshTimer As Timer
    Friend WithEvents ExecuteAllMenuItem As ToolStripMenuItem
    Friend WithEvents OutputBox As RichTextBox
    Friend WithEvents StartupOptionsMenuItem As ToolStripMenuItem
    Friend WithEvents OutputSplitContainer As SplitContainer
    Friend WithEvents FastInputBox As FastColoredTextBoxNS.FastColoredTextBox
    Friend WithEvents PasteMenuItem As ToolStripMenuItem
End Class
