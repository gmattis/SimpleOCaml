Public Class Settings
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ThemesDict As New Dictionary(Of String, Integer) From {
            {"Light Theme", Themes.LightTheme},
            {"Dark Theme", Themes.DarkTheme}
        }

        ThemeComboBox.DataSource = New BindingSource(ThemesDict, Nothing)
        ThemeComboBox.ValueMember = "Value"
        ThemeComboBox.DisplayMember = "Key"
        ThemeComboBox.SelectedValue = My.Settings.Theme

        AddHandler ThemeComboBox.SelectedIndexChanged, AddressOf ThemeComboBox_SelectedIndexChanged
        AddHandler AutosaveBox.CheckedChanged, AddressOf AutosaveBox_CheckedChanged

        FontButton.Font = New Font(My.Settings.Font_Family, My.Settings.Font_Size, My.Settings.Font_Style)
        FontPickerDialog.Font = New Font(My.Settings.Font_Family, My.Settings.Font_Size, My.Settings.Font_Style)

        AutosaveDelayUpDown.Value = My.Settings.Autosave_delay
        AddHandler AutosaveDelayUpDown.ValueChanged, AddressOf AutosaveDelayUpDown_ValueChanged

        ColorPickerDialog.FullOpen = True

        VersionLabel.Text = $"SimpleOCaml {My.Settings.Version}"

        LoadButtonsColor()
    End Sub

    Private Sub ThemeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        If ThemeComboBox.SelectedValue.GetType() = GetType(Integer) Then
            My.Settings.Theme = ThemeComboBox.SelectedValue
            Main.ThemeManager.ThemeLoader.Reload(ThemeComboBox.SelectedValue)
            Main.ThemeManager.SwitchTheme(ThemeComboBox.SelectedValue)
            LoadButtonsColor()
        End If
    End Sub

    Private Sub KeywordButton_Click(sender As Object, e As EventArgs) Handles KeywordButton.Click
        ColorPickerDialog.Color = Main.ThemeManager.ThemeLoader.KeywordColor
        If ColorPickerDialog.ShowDialog() = DialogResult.OK Then
            Main.ThemeManager.ThemeLoader.KeywordColor = ColorPickerDialog.Color
            KeywordButton.BackColor = ColorPickerDialog.Color
            Main.ThemeManager.SwitchTheme(My.Settings.Theme)
        End If
    End Sub

    Private Sub OperatorButton_Click(sender As Object, e As EventArgs) Handles OperatorButton.Click
        ColorPickerDialog.Color = Main.ThemeManager.ThemeLoader.OperatorColor
        If ColorPickerDialog.ShowDialog() = DialogResult.OK Then
            Main.ThemeManager.ThemeLoader.OperatorColor = ColorPickerDialog.Color
            OperatorButton.BackColor = ColorPickerDialog.Color
            Main.ThemeManager.SwitchTheme(My.Settings.Theme)
        End If
    End Sub

    Private Sub DigitButton_Click(sender As Object, e As EventArgs) Handles DigitButton.Click
        ColorPickerDialog.Color = Main.ThemeManager.ThemeLoader.NumericColor
        If ColorPickerDialog.ShowDialog() = DialogResult.OK Then
            Main.ThemeManager.ThemeLoader.NumericColor = ColorPickerDialog.Color
            DigitButton.BackColor = ColorPickerDialog.Color
            Main.ThemeManager.SwitchTheme(My.Settings.Theme)
        End If
    End Sub

    Private Sub StringButton_Click(sender As Object, e As EventArgs) Handles StringButton.Click
        ColorPickerDialog.Color = Main.ThemeManager.ThemeLoader.StringColor
        If ColorPickerDialog.ShowDialog() = DialogResult.OK Then
            Main.ThemeManager.ThemeLoader.StringColor = ColorPickerDialog.Color
            StringButton.BackColor = ColorPickerDialog.Color
            Main.ThemeManager.SwitchTheme(My.Settings.Theme)
        End If
    End Sub

    Private Sub CommentButton_Click(sender As Object, e As EventArgs) Handles CommentButton.Click
        ColorPickerDialog.Color = Main.ThemeManager.ThemeLoader.CommentColor
        If ColorPickerDialog.ShowDialog() = DialogResult.OK Then
            Main.ThemeManager.ThemeLoader.CommentColor = ColorPickerDialog.Color
            CommentButton.BackColor = ColorPickerDialog.Color
            Main.ThemeManager.SwitchTheme(My.Settings.Theme)
        End If
    End Sub

    Private Sub FunctionButton_Click(sender As Object, e As EventArgs) Handles FunctionButton.Click
        ColorPickerDialog.Color = Main.ThemeManager.ThemeLoader.VariableColor
        If ColorPickerDialog.ShowDialog() = DialogResult.OK Then
            Main.ThemeManager.ThemeLoader.VariableColor = ColorPickerDialog.Color
            FunctionButton.BackColor = ColorPickerDialog.Color
            Main.ThemeManager.SwitchTheme(My.Settings.Theme)
        End If
    End Sub

    Private Sub LoadButtonsColor()
        KeywordButton.BackColor = Main.ThemeManager.ThemeLoader.KeywordColor
        OperatorButton.BackColor = Main.ThemeManager.ThemeLoader.OperatorColor
        DigitButton.BackColor = Main.ThemeManager.ThemeLoader.NumericColor
        StringButton.BackColor = Main.ThemeManager.ThemeLoader.StringColor
        CommentButton.BackColor = Main.ThemeManager.ThemeLoader.CommentColor
        FunctionButton.BackColor = Main.ThemeManager.ThemeLoader.VariableColor
    End Sub

    Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
        Dim Ocaml_Exe As String = My.Settings.Ocaml_Exe
        Dim Ocaml_Lib As String = My.Settings.Ocaml_Lib

        My.Settings.Reset()

        My.Settings.Ocaml_Exe = Ocaml_Exe
        My.Settings.Ocaml_Lib = Ocaml_Lib

        ThemeComboBox.SelectedValue = My.Settings.Theme

        Main.ThemeManager.ThemeLoader.Reset()
        Main.ThemeManager.ThemeLoader.Reload(My.Settings.Theme)
        Main.ThemeManager.SwitchTheme(My.Settings.Theme)

        FontButton.Font = New Font(My.Settings.Font_Family, My.Settings.Font_Size, My.Settings.Font_Style)
        FontPickerDialog.Font = New Font(My.Settings.Font_Family, My.Settings.Font_Size, My.Settings.Font_Style)

        AutosaveDelayUpDown.Value = My.Settings.Autosave_delay

        LoadButtonsColor()

        MsgBox("Reset done!")
    End Sub

    Private Sub FontButton_Click(sender As Object, e As EventArgs) Handles FontButton.Click
        If FontPickerDialog.ShowDialog() = DialogResult.OK Then
            My.Settings.Font_Family = FontPickerDialog.Font.Name
            My.Settings.Font_Size = FontPickerDialog.Font.Size
            My.Settings.Font_Style = FontPickerDialog.Font.Style
        End If
        Main.ThemeManager.SwitchTheme(My.Settings.Theme)
        FontButton.Font = New Font(My.Settings.Font_Family, My.Settings.Font_Size, My.Settings.Font_Style)
    End Sub

    Private Sub AutosaveDelayUpDown_ValueChanged(sender As Object, e As EventArgs)
        My.Settings.Autosave_delay = Convert.ToInt32(AutosaveDelayUpDown.Value)
    End Sub

    Private Sub OCamlPathButton_Click(sender As Object, e As EventArgs) Handles OCamlPathButton.Click
        If FolderBrowserDialog.ShowDialog() = DialogResult.OK Then
            If System.IO.File.Exists(System.IO.Path.GetFullPath(FolderBrowserDialog.SelectedPath) & "\ocaml.exe") Then
                My.Settings.Ocaml_Exe = FolderBrowserDialog.SelectedPath
            Else
                MsgBox("This directory doesn't contain OCaml executables! Please specify a valid directory")
            End If
        End If
    End Sub

    Private Sub LibsPathButton_Click(sender As Object, e As EventArgs) Handles LibsPathButton.Click
        If FolderBrowserDialog.ShowDialog() = DialogResult.OK Then
            My.Settings.Ocaml_Lib = FolderBrowserDialog.SelectedPath
        End If
    End Sub

    Private Sub ApplyButton_Click(sender As Object, e As EventArgs) Handles ApplyButton.Click
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub CodeFoldingBox_CheckedChanged(sender As Object, e As EventArgs) Handles CodeFoldingBox.CheckedChanged
        TryCast(Main.TabControl.SelectedTab.Controls.Item(0), FastColoredTextBoxNS.FastColoredTextBox).Range.ClearFoldingMarkers()
    End Sub

    Private Sub AutosaveBox_CheckedChanged(sender As Object, e As EventArgs)
        If My.Settings.Autosave Then
            Main.AutoSaveTimer.Start()
        Else
            Main.AutoSaveTimer.Stop()
        End If
    End Sub

    Private Sub Settings_Close(sender As Object, e As EventArgs) Handles Me.Closed
        My.Settings.Save()
    End Sub
End Class