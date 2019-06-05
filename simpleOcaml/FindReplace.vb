Imports FastColoredTextBoxNS

Public Class FindReplace
    Private Sub FindReplace_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub

    Private Sub FindReplace_LostFocus(sender As Object, e As EventArgs) Handles Me.Deactivate
        Try
            Me.Opacity = 0.25
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FindReplace_GotFocus(sender As Object, e As EventArgs) Handles Me.Activated
        Try
            Me.Opacity = 1.0
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FindButton_Click(sender As Object, e As EventArgs) Handles FindButton.Click
        If Not FindTextbox.Text.Equals("") Then
            Dim CurrentTextbox As FastColoredTextBox = TryCast(Main.TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
            Dim NextIndex As Integer = CurrentTextbox.Text.IndexOf(FindTextbox.Text, CurrentTextbox.SelectionStart + CurrentTextbox.SelectionLength)
            If NextIndex = -1 Then NextIndex = CurrentTextbox.Text.IndexOf(FindTextbox.Text)
            CurrentTextbox.SelectionStart = NextIndex
            CurrentTextbox.SelectionLength = FindTextbox.Text.Length
            CurrentTextbox.DoCaretVisible()
        End If
    End Sub

    Private Sub ReplaceNextButton_Click(sender As Object, e As EventArgs) Handles ReplaceNextButton.Click
        If Not FindRepTextbox.Text.Equals("") And Not ReplaceTextbox.Text.Equals("") Then
            Dim CurrentTextbox As FastColoredTextBox = TryCast(Main.TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
            Dim NextIndex As Integer = CurrentTextbox.Text.IndexOf(FindRepTextbox.Text)
            If NextIndex = -1 Then
                MsgBox("No occurrence found!")
            Else
                CurrentTextbox.SelectionStart = NextIndex
                CurrentTextbox.SelectionLength = FindRepTextbox.Text.Length
                CurrentTextbox.SelectedText = ReplaceTextbox.Text
                CurrentTextbox.DoCaretVisible()
            End If
        End If
    End Sub

    Private Sub ReplaceAllButton_Click(sender As Object, e As EventArgs) Handles ReplaceAllButton.Click
        If Not FindRepTextbox.Text.Equals("") And Not ReplaceTextbox.Text.Equals("") Then
            Dim Count As Integer = 0
            Dim CurrentTextbox As FastColoredTextBox = TryCast(Main.TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
            Dim NextIndex As Integer = CurrentTextbox.Text.IndexOf(FindRepTextbox.Text)
            While Not NextIndex.Equals(-1)
                CurrentTextbox.SelectionStart = NextIndex
                CurrentTextbox.SelectionLength = FindRepTextbox.Text.Length
                CurrentTextbox.SelectedText = ReplaceTextbox.Text
                CurrentTextbox.DoCaretVisible()
                Count += 1
                NextIndex = CurrentTextbox.Text.IndexOf(FindRepTextbox.Text)
            End While
            MsgBox($"{Count} occurrences replaced!")
        End If
    End Sub
End Class