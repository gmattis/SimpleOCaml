Imports FastColoredTextBoxNS

Module Utils
    Public ReadOnly OperatorRegex As String = "(=|<|>|!|\+|-|\/|\.|\*|%|@|\||&)"
    Public ReadOnly KeywordRegex As String = "\b(and|asr|assert|as|begin|class|constraint|done|downto|do|" &
            "else|end|exception|external|false|for|function|functor|fun|if|" &
            "include|inherit|initializer|in|land|lazy|let|lor|lsl|lsr|" &
            "lxor|match|method|module|mod|mutable|open|new|nonrec|object|" &
            "of|open!|open|or|private|rec|sig|struct|then|to|" &
            "true|try|type|val|virtual|when|while|with)\b"
    Public ReadOnly NumericRegex As String = "\b\d+(\.(\d+)?)?"
    Public ReadOnly CommentRegex As String = "[(][*][\s\S]*?[*][)]"
    Public ReadOnly StringRegex As String = "[""][\s\S]*?[""]"
    Public ReadOnly FunctionRegex As String = "(?<=let |rec )(\w|,)*"

    Public Function Normalise_Text(str As String) As String
        Dim ret As String = str
        If Not ret.EndsWith(";;") Then ret += ";;"
        ret = ret.Replace(vbCr, " ").Replace(vbLf, "")
        ret = ret.Replace(vbTab, " ")
        Return ret
    End Function

    Public Function IndexsOf(str As String, srch As String) As List(Of Integer)
        If str.Length > 2 Then
            Dim len As Integer = str.Length
            Dim res As List(Of Integer) = New List(Of Integer)
            Dim i As Integer = 0
            res.Add(0)
            While i < len - srch.Length + 1
                If str.Substring(i, srch.Length) = srch Then
                    res.Add(i + 2)
                    i += 2
                Else
                    i += 1
                End If
            End While
            Return res
        Else
            Return New List(Of Integer)
        End If
    End Function

    Public Sub PaintLines(sender As Object, e As PaintLineEventArgs)
        If Main.LinesToExecute(0) <= e.LineIndex And e.LineIndex <= Main.LinesToExecute(1) Then
            e.Graphics.FillRectangle(Main.ThemeManager.HighlightBrush, e.LineRect.X, e.LineRect.Y, e.LineRect.Width, e.LineRect.Height)
        End If
    End Sub

    Public Function Max(a, b)
        If a > b Then Return a Else Return b
    End Function

    Public Sub OnTabClosing(sender As Object, e As TabControlCancelEventArgs)
        If Not e.TabPage.Tag(1) Then
            Dim result As MsgBoxResult
            If e.TabPage.Tag(0) = "" Then
                result = MsgBox(String.Format("Ce fichier n'a pas été sauvegardé." + vbLf + "Voulez-vous sauvegarder ?", System.IO.Path.GetFileName(e.TabPage.Tag(0))), MsgBoxStyle.YesNoCancel, "Fichier non sauvegardé")
                If result = MsgBoxResult.Cancel Then
                    e.Cancel = True
                ElseIf result = MsgBoxResult.Yes Then
                    If Not SaveAsPage(e.TabPage) Then
                        e.Cancel = True
                    End If
                End If
            Else
                result = MsgBox(String.Format("{0} a été modifié." + vbLf + "Voulez-vous sauvegarder ?", System.IO.Path.GetFileName(e.TabPage.Tag(0))), MsgBoxStyle.YesNoCancel, "Fichier non sauvegardé")
                If result = MsgBoxResult.Cancel Then
                    e.Cancel = True
                ElseIf result = MsgBoxResult.Yes Then
                    SavePage(e.TabPage, e.TabPage.Tag(0))
                End If
            End If
        End If
    End Sub

    Public Sub OnTabClosed(sender As Object, e As TabControlEventArgs)
        If Main.TabControl.TabCount = 0 Then
            Main.AddNewPage()
        End If
    End Sub

    Public Sub InputBoxTextChanged(sender As Object, e As TextChangedEventArgs)
        Dim CurrentRange As Range = e.ChangedRange
        Dim TextRange As Range = e.ChangedRange.tb.Range()

        ' Ancienne syntaxe: New Style() {Main.ThemeManager.<LeStyle>}
        TextRange.ClearStyle(Main.ThemeManager.CommentStyle)
        TextRange.ClearStyle(Main.ThemeManager.StringStyle)
        CurrentRange.ClearStyle(Main.ThemeManager.NumericStyle)
        CurrentRange.ClearStyle(Main.ThemeManager.KeywordStyle)
        CurrentRange.ClearStyle(Main.ThemeManager.OperatorStyle)
        CurrentRange.ClearStyle(Main.ThemeManager.FunctionStyle)

        TextRange.SetStyle(Main.ThemeManager.CommentStyle, CommentRegex)
        TextRange.SetStyle(Main.ThemeManager.StringStyle, StringRegex)
        CurrentRange.SetStyle(Main.ThemeManager.NumericStyle, NumericRegex)
        CurrentRange.SetStyle(Main.ThemeManager.KeywordStyle, KeywordRegex)
        CurrentRange.SetStyle(Main.ThemeManager.KeywordStyle, OperatorRegex)
        CurrentRange.SetStyle(Main.ThemeManager.FunctionStyle, FunctionRegex)

        If Main.TabControl.SelectedTab.Tag(1) Then
            Main.TabControl.SelectedTab.Tag(1) = False
            Main.TabControl.SelectedTab.Text = "*" & Main.TabControl.SelectedTab.Text
        End If
    End Sub

    Private Sub SavePage(page As TabPage, path As String)
        TryCast(page.Controls.Item(0), FastColoredTextBox).SaveToFile(path, System.Text.Encoding.Default)
    End Sub

    Private Function SaveAsPage(page As TabPage) As Boolean
        Main.SaveFileDialog.FileName = ""
        Main.SaveFileDialog.ShowDialog()
        If Main.SaveFileDialog.FileName <> "" Then
            TryCast(page.Controls.Item(0), FastColoredTextBox).SaveToFile(Main.SaveFileDialog.FileName, System.Text.Encoding.Default)
            Return True
        Else
            Return False
        End If
    End Function
End Module
