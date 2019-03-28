Imports FastColoredTextBoxNS

Module Utils
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

    Public Function KeyWordList() As List(Of String)
        Return {"and", "as", "asr", "assert", "begin", "class", "constraint", "do", "done", "downto",
            "else", "end", "exception", "external", "false", "for", "fun", "function", "functor", "if",
            "in", "include", "inherit", "initializer", "land", "lazy", "let", "lor", "lsl", "lsr",
            "lxor", "match", "method", "mod", "module", "mutable", "open", "new", "nonrec", "object",
            "of", "open", "open!", "or", "private", "rec", "sig", "struct", "then", "to",
            "true", "try", "type", "val", "virtual", "when", "while", "with"}.ToList()
    End Function

    Public Sub PaintLines(sender As Object, e As PaintLineEventArgs)
        If Main.LinesToExecute(0) <= e.LineIndex And e.LineIndex <= Main.LinesToExecute(1) Then
            e.Graphics.FillRectangle(Brushes.MistyRose, e.LineRect.X, e.LineRect.Y, e.LineRect.Width, e.LineRect.Height)
        End If
    End Sub

    Public Function Max(a, b)
        If a > b Then
            Return a
        Else
            Return b
        End If
    End Function
End Module
