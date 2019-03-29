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
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.OutputBox = New System.Windows.Forms.RichTextBox()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FichierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NouveauToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OuvrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnregistrerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnregistrerSousToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FermerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NettoyerLaSortieToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OCamlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExécuterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SortieToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PartielleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComplèteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FermerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParamètresToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ThèmeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LightModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DarkModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DocumentationOCamlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AProposToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OcamlFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.LibrariesBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.AutoSaveTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SauvegardeAutomatiqueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.SaveLabel = New System.Windows.Forms.ToolStripStatusLabel()
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
        Me.SplitContainer.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer.Name = "SplitContainer"
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.Controls.Add(Me.TabControl)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.OutputBox)
        Me.SplitContainer.Size = New System.Drawing.Size(769, 345)
        Me.SplitContainer.SplitterDistance = 403
        Me.SplitContainer.TabIndex = 2
        '
        'TabControl
        '
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.Padding = New System.Drawing.Point(0, 0)
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(403, 345)
        Me.TabControl.TabIndex = 2
        Me.TabControl.Tag = ""
        '
        'OutputBox
        '
        Me.OutputBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OutputBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OutputBox.Location = New System.Drawing.Point(0, 0)
        Me.OutputBox.Margin = New System.Windows.Forms.Padding(6)
        Me.OutputBox.Name = "OutputBox"
        Me.OutputBox.ReadOnly = True
        Me.OutputBox.Size = New System.Drawing.Size(362, 345)
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
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FichierToolStripMenuItem, Me.EditionToolStripMenuItem, Me.OCamlToolStripMenuItem, Me.ParamètresToolStripMenuItem1, Me.AideToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(769, 24)
        Me.MenuStrip.TabIndex = 3
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'FichierToolStripMenuItem
        '
        Me.FichierToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NouveauToolStripMenuItem, Me.OuvrirToolStripMenuItem, Me.EnregistrerToolStripMenuItem, Me.EnregistrerSousToolStripMenuItem, Me.FermerToolStripMenuItem})
        Me.FichierToolStripMenuItem.Name = "FichierToolStripMenuItem"
        Me.FichierToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.FichierToolStripMenuItem.Text = "Fichier"
        '
        'NouveauToolStripMenuItem
        '
        Me.NouveauToolStripMenuItem.Name = "NouveauToolStripMenuItem"
        Me.NouveauToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NouveauToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.NouveauToolStripMenuItem.Text = "Nouveau"
        '
        'OuvrirToolStripMenuItem
        '
        Me.OuvrirToolStripMenuItem.Name = "OuvrirToolStripMenuItem"
        Me.OuvrirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OuvrirToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.OuvrirToolStripMenuItem.Text = "Ouvrir"
        '
        'EnregistrerToolStripMenuItem
        '
        Me.EnregistrerToolStripMenuItem.Name = "EnregistrerToolStripMenuItem"
        Me.EnregistrerToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.EnregistrerToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.EnregistrerToolStripMenuItem.Text = "Enregistrer"
        '
        'EnregistrerSousToolStripMenuItem
        '
        Me.EnregistrerSousToolStripMenuItem.Name = "EnregistrerSousToolStripMenuItem"
        Me.EnregistrerSousToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.EnregistrerSousToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.EnregistrerSousToolStripMenuItem.Text = "Enregistrer sous"
        '
        'FermerToolStripMenuItem
        '
        Me.FermerToolStripMenuItem.Name = "FermerToolStripMenuItem"
        Me.FermerToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.FermerToolStripMenuItem.Text = "Fermer"
        '
        'EditionToolStripMenuItem
        '
        Me.EditionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NettoyerLaSortieToolStripMenuItem})
        Me.EditionToolStripMenuItem.Name = "EditionToolStripMenuItem"
        Me.EditionToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.EditionToolStripMenuItem.Text = "Edition"
        '
        'NettoyerLaSortieToolStripMenuItem
        '
        Me.NettoyerLaSortieToolStripMenuItem.Name = "NettoyerLaSortieToolStripMenuItem"
        Me.NettoyerLaSortieToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.NettoyerLaSortieToolStripMenuItem.Text = "Nettoyer la sortie"
        '
        'OCamlToolStripMenuItem
        '
        Me.OCamlToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExécuterToolStripMenuItem, Me.SortieToolStripMenuItem, Me.FermerToolStripMenuItem1})
        Me.OCamlToolStripMenuItem.Name = "OCamlToolStripMenuItem"
        Me.OCamlToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.OCamlToolStripMenuItem.Text = "OCaml"
        '
        'ExécuterToolStripMenuItem
        '
        Me.ExécuterToolStripMenuItem.Name = "ExécuterToolStripMenuItem"
        Me.ExécuterToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)
        Me.ExécuterToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.ExécuterToolStripMenuItem.Text = "Exécuter"
        '
        'SortieToolStripMenuItem
        '
        Me.SortieToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PartielleToolStripMenuItem, Me.ComplèteToolStripMenuItem})
        Me.SortieToolStripMenuItem.Name = "SortieToolStripMenuItem"
        Me.SortieToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.SortieToolStripMenuItem.Text = "Sortie"
        '
        'PartielleToolStripMenuItem
        '
        Me.PartielleToolStripMenuItem.CheckOnClick = True
        Me.PartielleToolStripMenuItem.Name = "PartielleToolStripMenuItem"
        Me.PartielleToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.PartielleToolStripMenuItem.Text = "Partielle"
        '
        'ComplèteToolStripMenuItem
        '
        Me.ComplèteToolStripMenuItem.CheckOnClick = True
        Me.ComplèteToolStripMenuItem.Name = "ComplèteToolStripMenuItem"
        Me.ComplèteToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.ComplèteToolStripMenuItem.Text = "Complète"
        '
        'FermerToolStripMenuItem1
        '
        Me.FermerToolStripMenuItem1.Name = "FermerToolStripMenuItem1"
        Me.FermerToolStripMenuItem1.Size = New System.Drawing.Size(185, 22)
        Me.FermerToolStripMenuItem1.Text = "Fermer"
        '
        'ParamètresToolStripMenuItem1
        '
        Me.ParamètresToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ThèmeToolStripMenuItem, Me.SauvegardeAutomatiqueToolStripMenuItem})
        Me.ParamètresToolStripMenuItem1.Name = "ParamètresToolStripMenuItem1"
        Me.ParamètresToolStripMenuItem1.Size = New System.Drawing.Size(78, 20)
        Me.ParamètresToolStripMenuItem1.Text = "Paramètres"
        '
        'ThèmeToolStripMenuItem
        '
        Me.ThèmeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LightModeToolStripMenuItem, Me.DarkModeToolStripMenuItem})
        Me.ThèmeToolStripMenuItem.Name = "ThèmeToolStripMenuItem"
        Me.ThèmeToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.ThèmeToolStripMenuItem.Text = "Thème"
        '
        'LightModeToolStripMenuItem
        '
        Me.LightModeToolStripMenuItem.CheckOnClick = True
        Me.LightModeToolStripMenuItem.Name = "LightModeToolStripMenuItem"
        Me.LightModeToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.LightModeToolStripMenuItem.Text = "Light Mode"
        '
        'DarkModeToolStripMenuItem
        '
        Me.DarkModeToolStripMenuItem.CheckOnClick = True
        Me.DarkModeToolStripMenuItem.Name = "DarkModeToolStripMenuItem"
        Me.DarkModeToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.DarkModeToolStripMenuItem.Text = "Dark Mode [WIP]"
        '
        'AideToolStripMenuItem
        '
        Me.AideToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DocumentationOCamlToolStripMenuItem, Me.AProposToolStripMenuItem})
        Me.AideToolStripMenuItem.Name = "AideToolStripMenuItem"
        Me.AideToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.AideToolStripMenuItem.Text = "Aide"
        '
        'DocumentationOCamlToolStripMenuItem
        '
        Me.DocumentationOCamlToolStripMenuItem.Name = "DocumentationOCamlToolStripMenuItem"
        Me.DocumentationOCamlToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.DocumentationOCamlToolStripMenuItem.Text = "Documentation OCaml"
        '
        'AProposToolStripMenuItem
        '
        Me.AProposToolStripMenuItem.Name = "AProposToolStripMenuItem"
        Me.AProposToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.AProposToolStripMenuItem.Text = "A propos"
        '
        'AutoSaveTimer
        '
        Me.AutoSaveTimer.Interval = 300000
        '
        'SauvegardeAutomatiqueToolStripMenuItem
        '
        Me.SauvegardeAutomatiqueToolStripMenuItem.CheckOnClick = True
        Me.SauvegardeAutomatiqueToolStripMenuItem.Name = "SauvegardeAutomatiqueToolStripMenuItem"
        Me.SauvegardeAutomatiqueToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.SauvegardeAutomatiqueToolStripMenuItem.Text = "Sauvegarde automatique"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveLabel})
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
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 391)
        Me.Controls.Add(Me.SplitContainer)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip
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
    Friend WithEvents FichierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AideToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NouveauToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OuvrirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EnregistrerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EnregistrerSousToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OCamlToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExécuterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DocumentationOCamlToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabControl As TabControl
    Friend WithEvents FermerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SortieToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComplèteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PartielleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OcamlFileDialog As OpenFileDialog
    Friend WithEvents LibrariesBrowserDialog As FolderBrowserDialog
    Friend WithEvents AProposToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ParamètresToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ThèmeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LightModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DarkModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OutputBox As RichTextBox
    Friend WithEvents FermerToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents NettoyerLaSortieToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AutoSaveTimer As Timer
    Friend WithEvents SauvegardeAutomatiqueToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents SaveLabel As ToolStripStatusLabel
End Class
