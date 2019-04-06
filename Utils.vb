Imports FastColoredTextBoxNS

Module Utils
    Private OperatorRegex As String = "(=|<|>|!|\+|-|\/|\.|\*|%|@|\||&)"
    Private KeywordRegex As String = "\b(and|asr|assert|as|begin|class|constraint|done|downto|do|" &
            "else|end|exception|external|false|for|function|functor|fun|if|" &
            "include|inherit|initializer|in|land|lazy|let|lor|lsl|lsr|" &
            "lxor|match|method|module|mod|mutable|open|new|nonrec|object|" &
            "of|open!|open|or|private|rec|sig|struct|then|to|" &
            "true|try|type|val|virtual|when|while|with)\b"
    Private NumericRegex As String = "\b\d+(\.(\d+)?)?"
    Private CommentRegex As String = "[(][*][\s\S]*?[*][)]"
    Private StringRegex As String = "[""][\s\S]*?[""]"

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
        If a > b Then Return a Else Return b
    End Function

    Public Sub OnTabClosing(sender As Object, e As TabControlCancelEventArgs)
        If Not e.TabPage.Tag(1) Then
            If MsgBox("Cette page n'a pas été sauvegardée. Voulez-vous continuer ?", MsgBoxStyle.OkCancel, "Page non sauvegardée") = MsgBoxResult.Cancel Then
                e.Cancel = True
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

        TextRange.SetStyle(Main.ThemeManager.CommentStyle, CommentRegex)
        TextRange.SetStyle(Main.ThemeManager.StringStyle, StringRegex)
        CurrentRange.SetStyle(Main.ThemeManager.NumericStyle, NumericRegex)
        CurrentRange.SetStyle(Main.ThemeManager.KeywordStyle, KeywordRegex)
        CurrentRange.SetStyle(Main.ThemeManager.KeywordStyle, OperatorRegex)

        If Main.TabControl.SelectedTab.Tag(1) Then
            Main.TabControl.SelectedTab.Tag(1) = False
            Main.TabControl.SelectedTab.Text = "*" & Main.TabControl.SelectedTab.Text
        End If
    End Sub
End Module
