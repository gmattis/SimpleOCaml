<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.ThemeGroupBox = New System.Windows.Forms.GroupBox()
        Me.FunctionButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FontButton = New System.Windows.Forms.Button()
        Me.CommentButton = New System.Windows.Forms.Button()
        Me.StringButton = New System.Windows.Forms.Button()
        Me.DigitButton = New System.Windows.Forms.Button()
        Me.OperatorButton = New System.Windows.Forms.Button()
        Me.KeywordButton = New System.Windows.Forms.Button()
        Me.ThemeComboBox = New System.Windows.Forms.ComboBox()
        Me.ColorPickerDialog = New System.Windows.Forms.ColorDialog()
        Me.ApplyButton = New System.Windows.Forms.Button()
        Me.ResetButton = New System.Windows.Forms.Button()
        Me.FontPickerDialog = New System.Windows.Forms.FontDialog()
        Me.OCamlPathTextbox = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.StartupOptionsTextbox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LibsPathButton = New System.Windows.Forms.Button()
        Me.LibsPathTextbox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OCamlPathButton = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DetailledOutputBox = New System.Windows.Forms.CheckBox()
        Me.CodeFoldingBox = New System.Windows.Forms.CheckBox()
        Me.AutosaveDelayUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.AutosaveBox = New System.Windows.Forms.CheckBox()
        Me.VersionLabel = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.ThemeGroupBox.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.AutosaveDelayUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ThemeGroupBox
        '
        Me.ThemeGroupBox.Controls.Add(Me.FunctionButton)
        Me.ThemeGroupBox.Controls.Add(Me.Label1)
        Me.ThemeGroupBox.Controls.Add(Me.FontButton)
        Me.ThemeGroupBox.Controls.Add(Me.CommentButton)
        Me.ThemeGroupBox.Controls.Add(Me.StringButton)
        Me.ThemeGroupBox.Controls.Add(Me.DigitButton)
        Me.ThemeGroupBox.Controls.Add(Me.OperatorButton)
        Me.ThemeGroupBox.Controls.Add(Me.KeywordButton)
        Me.ThemeGroupBox.Controls.Add(Me.ThemeComboBox)
        Me.ThemeGroupBox.Location = New System.Drawing.Point(13, 13)
        Me.ThemeGroupBox.Name = "ThemeGroupBox"
        Me.ThemeGroupBox.Size = New System.Drawing.Size(210, 252)
        Me.ThemeGroupBox.TabIndex = 0
        Me.ThemeGroupBox.TabStop = False
        Me.ThemeGroupBox.Text = "Theme"
        '
        'FunctionButton
        '
        Me.FunctionButton.Location = New System.Drawing.Point(6, 191)
        Me.FunctionButton.Name = "FunctionButton"
        Me.FunctionButton.Size = New System.Drawing.Size(198, 23)
        Me.FunctionButton.TabIndex = 7
        Me.FunctionButton.Text = "Functions color"
        Me.FunctionButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "General theme"
        '
        'FontButton
        '
        Me.FontButton.Location = New System.Drawing.Point(6, 220)
        Me.FontButton.Name = "FontButton"
        Me.FontButton.Size = New System.Drawing.Size(198, 23)
        Me.FontButton.TabIndex = 4
        Me.FontButton.Text = "Change Font"
        Me.FontButton.UseVisualStyleBackColor = True
        '
        'CommentButton
        '
        Me.CommentButton.Location = New System.Drawing.Point(6, 162)
        Me.CommentButton.Name = "CommentButton"
        Me.CommentButton.Size = New System.Drawing.Size(198, 23)
        Me.CommentButton.TabIndex = 6
        Me.CommentButton.Text = "Comments color"
        Me.CommentButton.UseVisualStyleBackColor = True
        '
        'StringButton
        '
        Me.StringButton.Location = New System.Drawing.Point(6, 133)
        Me.StringButton.Name = "StringButton"
        Me.StringButton.Size = New System.Drawing.Size(198, 23)
        Me.StringButton.TabIndex = 5
        Me.StringButton.Text = "Strings color"
        Me.StringButton.UseVisualStyleBackColor = True
        '
        'DigitButton
        '
        Me.DigitButton.Location = New System.Drawing.Point(6, 104)
        Me.DigitButton.Name = "DigitButton"
        Me.DigitButton.Size = New System.Drawing.Size(198, 23)
        Me.DigitButton.TabIndex = 4
        Me.DigitButton.Text = "Digits color"
        Me.DigitButton.UseVisualStyleBackColor = True
        '
        'OperatorButton
        '
        Me.OperatorButton.Location = New System.Drawing.Point(6, 75)
        Me.OperatorButton.Name = "OperatorButton"
        Me.OperatorButton.Size = New System.Drawing.Size(198, 23)
        Me.OperatorButton.TabIndex = 3
        Me.OperatorButton.Text = "Operators color"
        Me.OperatorButton.UseVisualStyleBackColor = True
        '
        'KeywordButton
        '
        Me.KeywordButton.Location = New System.Drawing.Point(6, 46)
        Me.KeywordButton.Name = "KeywordButton"
        Me.KeywordButton.Size = New System.Drawing.Size(198, 23)
        Me.KeywordButton.TabIndex = 2
        Me.KeywordButton.Text = "Keywords color"
        Me.KeywordButton.UseVisualStyleBackColor = True
        '
        'ThemeComboBox
        '
        Me.ThemeComboBox.FormattingEnabled = True
        Me.ThemeComboBox.Location = New System.Drawing.Point(88, 19)
        Me.ThemeComboBox.Name = "ThemeComboBox"
        Me.ThemeComboBox.Size = New System.Drawing.Size(116, 21)
        Me.ThemeComboBox.TabIndex = 0
        '
        'ApplyButton
        '
        Me.ApplyButton.Location = New System.Drawing.Point(290, 271)
        Me.ApplyButton.Name = "ApplyButton"
        Me.ApplyButton.Size = New System.Drawing.Size(119, 23)
        Me.ApplyButton.TabIndex = 1
        Me.ApplyButton.Text = "OK"
        Me.ApplyButton.UseVisualStyleBackColor = True
        '
        'ResetButton
        '
        Me.ResetButton.Location = New System.Drawing.Point(415, 271)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(115, 23)
        Me.ResetButton.TabIndex = 3
        Me.ResetButton.Text = "Reset to default"
        Me.ResetButton.UseVisualStyleBackColor = True
        '
        'OCamlPathTextbox
        '
        Me.OCamlPathTextbox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.SimpleOCaml.My.MySettings.Default, "Ocaml_Exe", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.OCamlPathTextbox.Location = New System.Drawing.Point(6, 46)
        Me.OCamlPathTextbox.Name = "OCamlPathTextbox"
        Me.OCamlPathTextbox.ReadOnly = True
        Me.OCamlPathTextbox.Size = New System.Drawing.Size(288, 20)
        Me.OCamlPathTextbox.TabIndex = 5
        Me.OCamlPathTextbox.Text = Global.SimpleOCaml.My.MySettings.Default.Ocaml_Exe
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.StartupOptionsTextbox)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.LibsPathButton)
        Me.GroupBox1.Controls.Add(Me.LibsPathTextbox)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.OCamlPathButton)
        Me.GroupBox1.Controls.Add(Me.OCamlPathTextbox)
        Me.GroupBox1.Location = New System.Drawing.Point(230, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 185)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "OCaml"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Startup options"
        '
        'StartupOptionsTextbox
        '
        Me.StartupOptionsTextbox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.SimpleOCaml.My.MySettings.Default, "StartupOptions", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.StartupOptionsTextbox.Location = New System.Drawing.Point(6, 156)
        Me.StartupOptionsTextbox.Name = "StartupOptionsTextbox"
        Me.StartupOptionsTextbox.Size = New System.Drawing.Size(288, 20)
        Me.StartupOptionsTextbox.TabIndex = 12
        Me.StartupOptionsTextbox.Text = Global.SimpleOCaml.My.MySettings.Default.StartupOptions
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(182, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Librairies Path (required on Windows)"
        '
        'LibsPathButton
        '
        Me.LibsPathButton.Location = New System.Drawing.Point(194, 72)
        Me.LibsPathButton.Name = "LibsPathButton"
        Me.LibsPathButton.Size = New System.Drawing.Size(100, 23)
        Me.LibsPathButton.TabIndex = 10
        Me.LibsPathButton.Text = "Change"
        Me.LibsPathButton.UseVisualStyleBackColor = True
        '
        'LibsPathTextbox
        '
        Me.LibsPathTextbox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.SimpleOCaml.My.MySettings.Default, "Ocaml_Lib", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.LibsPathTextbox.Location = New System.Drawing.Point(6, 101)
        Me.LibsPathTextbox.Name = "LibsPathTextbox"
        Me.LibsPathTextbox.ReadOnly = True
        Me.LibsPathTextbox.Size = New System.Drawing.Size(288, 20)
        Me.LibsPathTextbox.TabIndex = 9
        Me.LibsPathTextbox.Text = Global.SimpleOCaml.My.MySettings.Default.Ocaml_Lib
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "OCaml Path (required)"
        '
        'OCamlPathButton
        '
        Me.OCamlPathButton.Location = New System.Drawing.Point(194, 17)
        Me.OCamlPathButton.Name = "OCamlPathButton"
        Me.OCamlPathButton.Size = New System.Drawing.Size(100, 23)
        Me.OCamlPathButton.TabIndex = 6
        Me.OCamlPathButton.Text = "Change"
        Me.OCamlPathButton.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DetailledOutputBox)
        Me.GroupBox2.Controls.Add(Me.CodeFoldingBox)
        Me.GroupBox2.Controls.Add(Me.AutosaveDelayUpDown)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.AutosaveBox)
        Me.GroupBox2.Location = New System.Drawing.Point(230, 204)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 61)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Misc"
        '
        'DetailledOutputBox
        '
        Me.DetailledOutputBox.AutoSize = True
        Me.DetailledOutputBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.DetailledOutputBox.Checked = Global.SimpleOCaml.My.MySettings.Default.Detailed_Output
        Me.DetailledOutputBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.SimpleOCaml.My.MySettings.Default, "Detailed_Output", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DetailledOutputBox.Location = New System.Drawing.Point(100, 42)
        Me.DetailledOutputBox.Name = "DetailledOutputBox"
        Me.DetailledOutputBox.Size = New System.Drawing.Size(102, 17)
        Me.DetailledOutputBox.TabIndex = 5
        Me.DetailledOutputBox.Text = "Detailled Output"
        Me.DetailledOutputBox.UseVisualStyleBackColor = True
        '
        'CodeFoldingBox
        '
        Me.CodeFoldingBox.AutoSize = True
        Me.CodeFoldingBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CodeFoldingBox.Checked = Global.SimpleOCaml.My.MySettings.Default.Code_Folding
        Me.CodeFoldingBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CodeFoldingBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.SimpleOCaml.My.MySettings.Default, "Code_Folding", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CodeFoldingBox.Location = New System.Drawing.Point(6, 42)
        Me.CodeFoldingBox.Name = "CodeFoldingBox"
        Me.CodeFoldingBox.Size = New System.Drawing.Size(88, 17)
        Me.CodeFoldingBox.TabIndex = 4
        Me.CodeFoldingBox.Text = "Code Folding"
        Me.CodeFoldingBox.UseVisualStyleBackColor = True
        '
        'AutosaveDelayUpDown
        '
        Me.AutosaveDelayUpDown.Location = New System.Drawing.Point(123, 16)
        Me.AutosaveDelayUpDown.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.AutosaveDelayUpDown.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.AutosaveDelayUpDown.Name = "AutosaveDelayUpDown"
        Me.AutosaveDelayUpDown.Size = New System.Drawing.Size(120, 20)
        Me.AutosaveDelayUpDown.TabIndex = 3
        Me.AutosaveDelayUpDown.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(83, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Delay"
        '
        'AutosaveBox
        '
        Me.AutosaveBox.AutoSize = True
        Me.AutosaveBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.AutosaveBox.Checked = Global.SimpleOCaml.My.MySettings.Default.Autosave
        Me.AutosaveBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AutosaveBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.SimpleOCaml.My.MySettings.Default, "Autosave", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.AutosaveBox.Location = New System.Drawing.Point(6, 19)
        Me.AutosaveBox.Name = "AutosaveBox"
        Me.AutosaveBox.Size = New System.Drawing.Size(71, 17)
        Me.AutosaveBox.TabIndex = 1
        Me.AutosaveBox.Text = "Autosave"
        Me.AutosaveBox.UseVisualStyleBackColor = True
        '
        'VersionLabel
        '
        Me.VersionLabel.AutoSize = True
        Me.VersionLabel.Location = New System.Drawing.Point(12, 276)
        Me.VersionLabel.Name = "VersionLabel"
        Me.VersionLabel.Size = New System.Drawing.Size(78, 13)
        Me.VersionLabel.TabIndex = 8
        Me.VersionLabel.Text = "SimpleOCaml []"
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 304)
        Me.Controls.Add(Me.VersionLabel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ResetButton)
        Me.Controls.Add(Me.ApplyButton)
        Me.Controls.Add(Me.ThemeGroupBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Settings"
        Me.Text = "Settings"
        Me.ThemeGroupBox.ResumeLayout(False)
        Me.ThemeGroupBox.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.AutosaveDelayUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ThemeGroupBox As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ThemeComboBox As ComboBox
    Friend WithEvents KeywordButton As Button
    Friend WithEvents ColorPickerDialog As ColorDialog
    Friend WithEvents FunctionButton As Button
    Friend WithEvents CommentButton As Button
    Friend WithEvents StringButton As Button
    Friend WithEvents DigitButton As Button
    Friend WithEvents OperatorButton As Button
    Friend WithEvents ApplyButton As Button
    Friend WithEvents ResetButton As Button
    Friend WithEvents FontPickerDialog As FontDialog
    Friend WithEvents FontButton As Button
    Friend WithEvents OCamlPathTextbox As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents OCamlPathButton As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents LibsPathButton As Button
    Friend WithEvents LibsPathTextbox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents StartupOptionsTextbox As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents AutosaveBox As CheckBox
    Friend WithEvents AutosaveDelayUpDown As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents VersionLabel As Label
    Friend WithEvents CodeFoldingBox As CheckBox
    Friend WithEvents DetailledOutputBox As CheckBox
    Friend WithEvents FolderBrowserDialog As FolderBrowserDialog
End Class
