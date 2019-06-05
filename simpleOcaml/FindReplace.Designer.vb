<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindReplace
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl = New TradeWright.UI.Forms.TabControlExtra()
        Me.FindPage = New System.Windows.Forms.TabPage()
        Me.FindTextbox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FindButton = New System.Windows.Forms.Button()
        Me.ReplacePage = New System.Windows.Forms.TabPage()
        Me.ReplaceAllButton = New System.Windows.Forms.Button()
        Me.ReplaceNextButton = New System.Windows.Forms.Button()
        Me.ReplaceTextbox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FindRepTextbox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl.SuspendLayout()
        Me.FindPage.SuspendLayout()
        Me.ReplacePage.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.FindPage)
        Me.TabControl.Controls.Add(Me.ReplacePage)
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
        Me.TabControl.Size = New System.Drawing.Size(459, 90)
        Me.TabControl.TabIndex = 0
        '
        'FindPage
        '
        Me.FindPage.Controls.Add(Me.FindTextbox)
        Me.FindPage.Controls.Add(Me.Label1)
        Me.FindPage.Controls.Add(Me.FindButton)
        Me.FindPage.Location = New System.Drawing.Point(4, 26)
        Me.FindPage.Name = "FindPage"
        Me.FindPage.Padding = New System.Windows.Forms.Padding(3)
        Me.FindPage.Size = New System.Drawing.Size(451, 60)
        Me.FindPage.TabIndex = 0
        Me.FindPage.Text = "Find"
        Me.FindPage.UseVisualStyleBackColor = True
        '
        'FindTextbox
        '
        Me.FindTextbox.Location = New System.Drawing.Point(78, 7)
        Me.FindTextbox.Name = "FindTextbox"
        Me.FindTextbox.Size = New System.Drawing.Size(261, 20)
        Me.FindTextbox.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Search:"
        '
        'FindButton
        '
        Me.FindButton.Location = New System.Drawing.Point(345, 5)
        Me.FindButton.Name = "FindButton"
        Me.FindButton.Size = New System.Drawing.Size(98, 23)
        Me.FindButton.TabIndex = 0
        Me.FindButton.Text = "Find next"
        Me.FindButton.UseVisualStyleBackColor = True
        '
        'ReplacePage
        '
        Me.ReplacePage.Controls.Add(Me.ReplaceAllButton)
        Me.ReplacePage.Controls.Add(Me.ReplaceNextButton)
        Me.ReplacePage.Controls.Add(Me.ReplaceTextbox)
        Me.ReplacePage.Controls.Add(Me.Label3)
        Me.ReplacePage.Controls.Add(Me.FindRepTextbox)
        Me.ReplacePage.Controls.Add(Me.Label2)
        Me.ReplacePage.Location = New System.Drawing.Point(4, 26)
        Me.ReplacePage.Name = "ReplacePage"
        Me.ReplacePage.Padding = New System.Windows.Forms.Padding(3)
        Me.ReplacePage.Size = New System.Drawing.Size(451, 60)
        Me.ReplacePage.TabIndex = 1
        Me.ReplacePage.Text = "Replace"
        Me.ReplacePage.UseVisualStyleBackColor = True
        '
        'ReplaceAllButton
        '
        Me.ReplaceAllButton.Location = New System.Drawing.Point(345, 31)
        Me.ReplaceAllButton.Name = "ReplaceAllButton"
        Me.ReplaceAllButton.Size = New System.Drawing.Size(98, 23)
        Me.ReplaceAllButton.TabIndex = 9
        Me.ReplaceAllButton.Text = "Replace all"
        Me.ReplaceAllButton.UseVisualStyleBackColor = True
        '
        'ReplaceNextButton
        '
        Me.ReplaceNextButton.Location = New System.Drawing.Point(345, 5)
        Me.ReplaceNextButton.Name = "ReplaceNextButton"
        Me.ReplaceNextButton.Size = New System.Drawing.Size(98, 23)
        Me.ReplaceNextButton.TabIndex = 8
        Me.ReplaceNextButton.Text = "Replace next"
        Me.ReplaceNextButton.UseVisualStyleBackColor = True
        '
        'ReplaceTextbox
        '
        Me.ReplaceTextbox.Location = New System.Drawing.Point(78, 33)
        Me.ReplaceTextbox.Name = "ReplaceTextbox"
        Me.ReplaceTextbox.Size = New System.Drawing.Size(261, 20)
        Me.ReplaceTextbox.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Replace by:"
        '
        'FindRepTextbox
        '
        Me.FindRepTextbox.Location = New System.Drawing.Point(78, 7)
        Me.FindRepTextbox.Name = "FindRepTextbox"
        Me.FindRepTextbox.Size = New System.Drawing.Size(261, 20)
        Me.FindRepTextbox.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Search:"
        '
        'FindReplace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(459, 90)
        Me.Controls.Add(Me.TabControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FindReplace"
        Me.Text = "Find and Replace"
        Me.TabControl.ResumeLayout(False)
        Me.FindPage.ResumeLayout(False)
        Me.FindPage.PerformLayout()
        Me.ReplacePage.ResumeLayout(False)
        Me.ReplacePage.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl As TradeWright.UI.Forms.TabControlExtra
    Friend WithEvents FindPage As TabPage
    Friend WithEvents ReplacePage As TabPage
    Friend WithEvents FindTextbox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents FindButton As Button
    Friend WithEvents FindRepTextbox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ReplaceTextbox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ReplaceAllButton As Button
    Friend WithEvents ReplaceNextButton As Button
End Class
