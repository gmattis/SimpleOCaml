Public Class ThemeLoader
    Private ThemeConfig As XDocument

    Private keywordColorValue As Color
    Public Property KeywordColor() As Color
        Get
            Return keywordColorValue
        End Get
        Set(value As Color)
            keywordColorValue = value
            Replace("keywordColor", value, My.Settings.Theme)
        End Set
    End Property

    Private numericColorValue As Color
    Public Property NumericColor() As Color
        Get
            Return numericColorValue
        End Get
        Set(value As Color)
            numericColorValue = value
            Replace("numericColor", value, My.Settings.Theme)
        End Set
    End Property

    Private stringColorValue As Color
    Public Property StringColor() As Color
        Get
            Return stringColorValue
        End Get
        Set(value As Color)
            stringColorValue = value
            Replace("stringColor", value, My.Settings.Theme)
        End Set
    End Property

    Private commentColorValue As Color
    Public Property CommentColor() As Color
        Get
            Return commentColorValue
        End Get
        Set(value As Color)
            commentColorValue = value
            Replace("commentColor", value, My.Settings.Theme)
        End Set
    End Property

    Private operatorColorValue As Color
    Public Property OperatorColor() As Color
        Get
            Return operatorColorValue
        End Get
        Set(value As Color)
            operatorColorValue = value
            Replace("operatorColor", value, My.Settings.Theme)
        End Set
    End Property

    Private functionColorValue As Color
    Public Property FunctionColor() As Color
        Get
            Return functionColorValue
        End Get
        Set(value As Color)
            functionColorValue = value
            Replace("functionColor", value, My.Settings.Theme)
        End Set
    End Property

    Public Sub New()
        Reload(My.Settings.Theme)
    End Sub

    Public Sub Reload(theme As Themes)
        If System.IO.File.Exists("theme.xml") Then
            ThemeConfig = XDocument.Load("theme.xml")
            Load(theme)
        Else
            LoadDefault(theme)
            CreateConfig()
        End If
    End Sub

    Public Sub Reset()
        LoadDefault(Themes.LightTheme)
        Replace("keywordColor", keywordColorValue, Themes.LightTheme)
        Replace("operatorColor", operatorColorValue, Themes.LightTheme)
        Replace("numericColor", numericColorValue, Themes.LightTheme)
        Replace("stringColor", stringColorValue, Themes.LightTheme)
        Replace("commentColor", commentColorValue, Themes.LightTheme)
        Replace("functionColor", functionColorValue, Themes.LightTheme)

        LoadDefault(Themes.DarkTheme)
        Replace("keywordColor", keywordColorValue, Themes.DarkTheme)
        Replace("operatorColor", operatorColorValue, Themes.DarkTheme)
        Replace("numericColor", numericColorValue, Themes.DarkTheme)
        Replace("stringColor", stringColorValue, Themes.DarkTheme)
        Replace("commentColor", commentColorValue, Themes.DarkTheme)
        Replace("functionColor", functionColorValue, Themes.DarkTheme)
    End Sub

    Private Sub Load(theme As Themes)
        Try
            Dim themeElement As XElement
            Select Case theme
                Case Themes.LightTheme
                    themeElement = ThemeConfig.Element("themeColors").Element("lightTheme")
                Case Themes.DarkTheme
                    themeElement = ThemeConfig.Element("themeColors").Element("darkTheme")
                Case Else
                    themeElement = ThemeConfig.Element("themeColors").Element("lightTheme")
            End Select

            Dim keywordValue As Integer() = Array.ConvertAll(Of String, Integer)(themeElement.Element("keywordColor").Value.Split(","), Function(str) Int32.Parse(str))
            Dim operatorValue As Integer() = Array.ConvertAll(Of String, Integer)(themeElement.Element("operatorColor").Value.Split(","), Function(str) Int32.Parse(str))
            Dim numericValue As Integer() = Array.ConvertAll(Of String, Integer)(themeElement.Element("numericColor").Value.Split(","), Function(str) Int32.Parse(str))
            Dim stringValue As Integer() = Array.ConvertAll(Of String, Integer)(themeElement.Element("stringColor").Value.Split(","), Function(str) Int32.Parse(str))
            Dim commentValue As Integer() = Array.ConvertAll(Of String, Integer)(themeElement.Element("commentColor").Value.Split(","), Function(str) Int32.Parse(str))
            Dim functionValue As Integer() = Array.ConvertAll(Of String, Integer)(themeElement.Element("functionColor").Value.Split(","), Function(str) Int32.Parse(str))

            keywordColorValue = Color.FromArgb(keywordValue(0), keywordValue(1), keywordValue(2))
            operatorColorValue = Color.FromArgb(operatorValue(0), operatorValue(1), operatorValue(2))
            numericColorValue = Color.FromArgb(numericValue(0), numericValue(1), numericValue(2))
            stringColorValue = Color.FromArgb(stringValue(0), stringValue(1), stringValue(2))
            commentColorValue = Color.FromArgb(commentValue(0), commentValue(1), commentValue(2))
            functionColorValue = Color.FromArgb(functionValue(0), functionValue(1), functionValue(2))
        Catch e As Exception
            Console.WriteLine("Invalid theme configuration, loading default values.")
            LoadDefault(theme)
        End Try
    End Sub

    Private Sub LoadDefault(theme As Themes)
        Select Case theme
            Case Themes.LightTheme
                keywordColorValue = Color.FromArgb(0, 0, 255)
                operatorColorValue = Color.FromArgb(0, 0, 255)
                numericColorValue = Color.FromArgb(128, 0, 0)
                stringColorValue = Color.FromArgb(69, 143, 34)
                commentColorValue = Color.FromArgb(173, 173, 173)
                functionColorValue = Color.FromArgb(144, 0, 144)

            Case Themes.DarkTheme
                keywordColorValue = Color.FromArgb(250, 39, 114)
                operatorColorValue = Color.FromArgb(250, 39, 114)
                numericColorValue = Color.FromArgb(147, 88, 254)
                stringColorValue = Color.FromArgb(231, 219, 117)
                commentColorValue = Color.FromArgb(127, 125, 105)
                functionColorValue = Color.FromArgb(166, 226, 43)

            Case Else
                keywordColorValue = Color.FromArgb(0, 0, 255)
                operatorColorValue = Color.FromArgb(0, 0, 255)
                numericColorValue = Color.FromArgb(128, 0, 0)
                stringColorValue = Color.FromArgb(69, 143, 34)
                commentColorValue = Color.FromArgb(173, 173, 173)
                functionColorValue = Color.FromArgb(144, 0, 144)

        End Select
    End Sub

    Private Sub Replace(color As String, value As Color, theme As Themes)
        Select Case theme
            Case Themes.LightTheme
                ThemeConfig.Element("themeColors").Element("lightTheme").Element(color).Value = $"{value.R},{value.G},{value.B}"
            Case Themes.DarkTheme
                ThemeConfig.Element("themeColors").Element("darkTheme").Element(color).Value = $"{value.R},{value.G},{value.B}"
            Case Else
                ThemeConfig.Element("themeColors").Element("lightTheme").Element(color).Value = $"{value.R},{value.G},{value.B}"
        End Select
        ThemeConfig.Save("theme.xml")
    End Sub

    Private Sub CreateConfig()
        ThemeConfig = New XDocument()
        ThemeConfig.Add(New XElement("themeColors"))

        ' Create structure
        With ThemeConfig.Element("themeColors")
            .Add(New XElement("lightTheme"))
            .Add(New XElement("darkTheme"))

            LoadDefault(Themes.LightTheme)

            .Element("lightTheme").Add(New XElement("keywordColor", $"{keywordColorValue.R},{keywordColorValue.G},{keywordColorValue.B}"))
            .Element("lightTheme").Add(New XElement("operatorColor", $"{operatorColorValue.R},{operatorColorValue.G},{operatorColorValue.B}"))
            .Element("lightTheme").Add(New XElement("numericColor", $"{numericColorValue.R},{numericColorValue.G},{numericColorValue.B}"))
            .Element("lightTheme").Add(New XElement("stringColor", $"{stringColorValue.R},{stringColorValue.G},{stringColorValue.B}"))
            .Element("lightTheme").Add(New XElement("commentColor", $"{commentColorValue.R},{commentColorValue.G},{commentColorValue.B}"))
            .Element("lightTheme").Add(New XElement("functionColor", $"{functionColorValue.R},{functionColorValue.G},{functionColorValue.B}"))

            LoadDefault(Themes.DarkTheme)

            .Element("darkTheme").Add(New XElement("keywordColor", $"{keywordColorValue.R},{keywordColorValue.G},{keywordColorValue.B}"))
            .Element("darkTheme").Add(New XElement("operatorColor", $"{operatorColorValue.R},{operatorColorValue.G},{operatorColorValue.B}"))
            .Element("darkTheme").Add(New XElement("numericColor", $"{numericColorValue.R},{numericColorValue.G},{numericColorValue.B}"))
            .Element("darkTheme").Add(New XElement("stringColor", $"{stringColorValue.R},{stringColorValue.G},{stringColorValue.B}"))
            .Element("darkTheme").Add(New XElement("commentColor", $"{commentColorValue.R},{commentColorValue.G},{commentColorValue.B}"))
            .Element("darkTheme").Add(New XElement("functionColor", $"{functionColorValue.R},{functionColorValue.G},{functionColorValue.B}"))
        End With

        ThemeConfig.Save("theme.xml")
        LoadDefault(My.Settings.Theme)
    End Sub
End Class
