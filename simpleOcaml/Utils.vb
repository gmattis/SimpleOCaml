﻿Imports System.Text.RegularExpressions
Imports System.Web.Script.Serialization
Imports FastColoredTextBoxNS

Module Utils
    Public ReadOnly OperatorRegex As String = "(=|<|>|!|\+|-|\/|\.|\*|%|@|\||&)"
    Public ReadOnly KeywordRegex As String = "\b(and|asr|assert|as|begin|class|constraint|done|downto|do|" &
            "else|end|exception|external|for|function|functor|fun|if|" &
            "include|inherit|initializer|in|land|lazy|let|lor|lsl|lsr|" &
            "lxor|match|method|module|mod|mutable|open|new|nonrec|object|" &
            "of|open!|open|or|private|rec|sig|struct|then|to|" &
            "try|type|val|virtual|when|while|with)\b"
    Public ReadOnly NumericRegex As String = "\b((true\b|false\b)|\d+(\.(\d+)?)?)"
    Public ReadOnly CommentRegex As String = "[(][*][\s\S]*?[*][)][\s]*"
    Public ReadOnly StringRegex As String = "[""][\s\S]*?[""]"
    Public ReadOnly VariableRegex As String = "(?<=let |rec |and |for )(\w|,)*"
    Public ReadOnly VariableRegexBis As String = "(?<=\| )[\w]*(?=[ ]*->)"

    Public Function Normalise_Text(str As String) As String
        Dim ret As String = str.Trim((" " & vbCr & vbLf).ToCharArray())
        If Not ret.EndsWith(";;") Then ret += ";;"
        Dim matches As MatchCollection = Regex.Matches(ret, CommentRegex)
        For i As Integer = matches.Count - 1 To 0 Step -1
            Dim match As Match = matches.Item(i)
            ret = ret.Substring(0, match.Index) & ret.Substring(match.Index + match.Length, ret.Length - 1)
        Next
        Return ret
    End Function

    Public Sub OnAutoIndent(sender As Object, e As AutoIndentEventArgs)
        Dim stringEnd As String = e.LineText.Trim((" "))
        If stringEnd.EndsWith("in") OrElse stringEnd.EndsWith("do") OrElse stringEnd.EndsWith("function") OrElse stringEnd.EndsWith("then") OrElse stringEnd.EndsWith("=") OrElse stringEnd.EndsWith("(") Then
            e.ShiftNextLines = e.TabLength
        ElseIf stringEnd.EndsWith(";;") Then
            e.ShiftNextLines -= e.TabLength
        ElseIf String.IsNullOrWhiteSpace(e.PrevLineText) AndAlso String.IsNullOrWhiteSpace(e.LineText) Then
            e.ShiftNextLines -= e.TabLength
        End If
    End Sub

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

    Public Sub OnTabClosing(sender As Object, e As TabControlCancelEventArgs)
        If TryCast(e.TabPage.Controls.Item(0), FastColoredTextBox).Text.Trim() <> "" AndAlso Not e.TabPage.Tag(1) Then
            Dim result As MsgBoxResult
            If e.TabPage.Tag(0) = "" Then
                result = MsgBox("This file wasn't saved." & vbLf & "Save it?", MsgBoxStyle.YesNoCancel, "Unsaved file")
                If result = MsgBoxResult.Cancel Then
                    e.Cancel = True
                ElseIf result = MsgBoxResult.Yes Then
                    If Not SaveAsPage(e.TabPage) Then
                        e.Cancel = True
                    End If
                End If
            Else
                result = MsgBox($"{System.IO.Path.GetFileName(e.TabPage.Tag(0))} was modified." + vbLf + "Save it?", MsgBoxStyle.YesNoCancel, System.IO.Path.GetFileName(e.TabPage.Tag(0)))
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
            Main.AddNewPage(False)
        End If
    End Sub

    Public Sub InputBoxTextChanged(sender As Object, e As TextChangedEventArgs)
        Dim CurrentRange As Range = e.ChangedRange
        Dim TextRange As Range = e.ChangedRange.tb.Range()

        TextRange.ClearStyle(Main.ThemeManager.CommentStyle)
        TextRange.ClearStyle(Main.ThemeManager.StringStyle)
        CurrentRange.ClearStyle(Main.ThemeManager.NumericStyle)
        CurrentRange.ClearStyle(Main.ThemeManager.KeywordStyle)
        CurrentRange.ClearStyle(Main.ThemeManager.OperatorStyle)
        CurrentRange.ClearStyle(Main.ThemeManager.VariableStyle)

        TextRange.SetStyle(Main.ThemeManager.CommentStyle, CommentRegex)
        TextRange.SetStyle(Main.ThemeManager.StringStyle, StringRegex)
        CurrentRange.SetStyle(Main.ThemeManager.NumericStyle, NumericRegex)
        CurrentRange.SetStyle(Main.ThemeManager.KeywordStyle, KeywordRegex)
        CurrentRange.SetStyle(Main.ThemeManager.KeywordStyle, OperatorRegex)
        CurrentRange.SetStyle(Main.ThemeManager.VariableStyle, VariableRegex)
        CurrentRange.SetStyle(Main.ThemeManager.VariableStyle, VariableRegexBis)

        If Not sender.Equals(Main.FastInputBox) AndAlso Main.TabControl.SelectedTab.Tag(1) AndAlso e.ChangedRange.tb.IsChanged Then
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

    Public ReadOnly Property IsLinux As Boolean
        Get
            Dim p As PlatformID = Environment.OSVersion.Platform
            Return (p = PlatformID.Unix)
        End Get
    End Property

    Public ReadOnly Property IsMacOS As Boolean
        Get
            Dim p As PlatformID = Environment.OSVersion.Platform
            Return (p = PlatformID.MacOSX)
        End Get
    End Property

    Public Sub CheckUpdate()
        Dim webClient As New System.Net.WebClient
        webClient.Headers.Add("User-Agent", "request")
        Try
            Dim result As String = webClient.DownloadString("https://api.github.com/repos/gmattis/simpleocaml/releases/latest")
            Dim jss As New JavaScriptSerializer()
            Dim dict As Dictionary(Of String, Object) = jss.Deserialize(Of Dictionary(Of String, Object))(result)
            Dim ver As String = Nothing, html_url As String = Nothing
            If dict.TryGetValue("tag_name", ver) AndAlso dict.TryGetValue("html_url", html_url) AndAlso ver > My.Settings.Version Then
                Dim boxResult As MsgBoxResult = MsgBox("An update is available, open it in your web browser?", MsgBoxStyle.YesNo, "Available update!")
                If boxResult = MsgBoxResult.Yes Then
                    Process.Start(html_url)
                End If
            End If
        Catch e As Exception
            Console.WriteLine("Exception while fetching for updates: " & e.Message)
        End Try
    End Sub

    Public Sub OpenFile(file As String)
        Dim CurrentTextbox As FastColoredTextBox = TryCast(Main.TabControl.SelectedTab.Controls.Item(0), FastColoredTextBox)
        CurrentTextbox.OpenFile(file, System.Text.Encoding.Default)
        CurrentTextbox.IsChanged = False
        Main.TabControl.SelectedTab.Text = System.IO.Path.GetFileName(file)
        Main.TabControl.SelectedTab.Tag(0) = file
        Main.TabControl.SelectedTab.Tag(1) = True
        AddHandler CurrentTextbox.TextChangedDelayed, AddressOf InputBoxTextChanged
    End Sub

    Function FindFocussedControl(ByVal ctr As Control) As Control
        Dim container As ContainerControl = TryCast(ctr, ContainerControl)
        Do While (container IsNot Nothing AndAlso container.GetType().Equals(GetType(SplitContainer)))
            ctr = container.ActiveControl
            container = TryCast(ctr, ContainerControl)
        Loop
        Return ctr
    End Function
End Module
