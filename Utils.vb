Imports FastColoredTextBoxNS

Module Utils
    Private OperatorRegex As String = "(=|:|;|<|>|!|\+|-|\/|\.|\*|%|@|\||&)"
    Private KeywordRegex As String = "\b(and|asr|assert|as|begin|class|constraint|done|downto|do|" &
            "else|end|exception|external|false|for|function|functor|fun|if|" &
            "include|inherit|initializer|in|land|lazy|let|lor|lsl|lsr|" &
            "lxor|match|method|module|mod|mutable|open|new|nonrec|object|" &
            "of|open!|open|or|private|rec|sig|struct|then|to|" &
            "true|try|type|val|virtual|when|while|with)\s"
    Private NumericRegex As String = "[0-9]"
    Private StringRegex As String = "[""].*[""]"

    Public Function Normalise_Text(str As String) As String
        Dim ret As String = str
        If Not ret.EndsWith(";;") Then ret = ret + ";;"
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
        Else Return New List(Of Integer)
        End If
    End Function

    Public Sub PaintLines(sender As Object, e As PaintLineEventArgs)
        If Main.LinesToExecute(0) <= e.LineIndex And e.LineIndex <= Main.LinesToExecute(1) Then
            e.Graphics.FillRectangle(Main.ThemeManager.HighlightBrush, e.LineRect.X, e.LineRect.Y, e.LineRect.Width, e.LineRect.Height)
        End If
    End Sub

    Public Function Max(a, b)
        If a > b Then
            Return a
        Else
            Return b
        End If
    End Function

    Public Sub OnTabClose(sender As Object, e As EventArgs)
        If Main.TabControl.TabCount = 0 Then
            Main.AddNewPage()
        End If
    End Sub

    Public Sub InputBoxTextChanged(sender As Object, e As TextChangedEventArgs)
        e.ChangedRange.ClearStyle(New Style() {Main.ThemeManager.StringStyle})
        e.ChangedRange.ClearStyle(New Style() {Main.ThemeManager.KeywordStyle})
        e.ChangedRange.ClearStyle(New Style() {Main.ThemeManager.NumericStyle})
        e.ChangedRange.SetStyle(Main.ThemeManager.StringStyle, StringRegex)
        e.ChangedRange.SetStyle(Main.ThemeManager.KeywordStyle, KeywordRegex)
        e.ChangedRange.SetStyle(Main.ThemeManager.NumericStyle, NumericRegex)
        e.ChangedRange.SetStyle(Main.ThemeManager.KeywordStyle, OperatorRegex)

        If Main.TabControl.SelectedTab.Tag(1) Then
            Main.TabControl.SelectedTab.Tag(1) = False
            Main.TabControl.SelectedTab.Text = "*" & Main.TabControl.SelectedTab.Text
        End If
    End Sub
End Module
