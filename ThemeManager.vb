Imports FastColoredTextBoxNS

Public Class ThemeManager
    Public OutputColor As Color
    Public OutputCommandColor As Color
    Public Enum Themes
        LightTheme = 0
        DarkTheme = 1
    End Enum

    Public Sub New()
        SwitchTheme(My.Settings.Theme)
    End Sub

    Private keywordStyleValue As TextStyle
    Public Property KeywordStyle() As TextStyle
        Get
            Return keywordStyleValue
        End Get
        Set(ByVal value As TextStyle)
            keywordStyleValue = value
        End Set
    End Property

    Private numericStyleValue As TextStyle
    Public Property NumericStyle() As TextStyle
        Get
            Return numericStyleValue
        End Get
        Set(ByVal value As TextStyle)
            numericStyleValue = value
        End Set
    End Property

    Private stringStyleValue As TextStyle
    Public Property StringStyle() As TextStyle
        Get
            Return stringStyleValue
        End Get
        Set(ByVal value As TextStyle)
            stringStyleValue = value
        End Set
    End Property

    Private commentStyleValue As TextStyle
    Public Property CommentStyle() As TextStyle
        Get
            Return commentStyleValue
        End Get
        Set(ByVal value As TextStyle)
            commentStyleValue = value
        End Set
    End Property

    Private operatorStyleValue As TextStyle
    Public Property OperatorStyle() As TextStyle
        Get
            Return operatorStyleValue
        End Get
        Set(ByVal value As TextStyle)
            operatorStyleValue = value
        End Set
    End Property
    Private functionStyleValue As TextStyle
    Public Property FunctionStyle() As TextStyle
        Get
            Return functionStyleValue
        End Get
        Set(ByVal value As TextStyle)
            functionStyleValue = value
        End Set
    End Property

    Private highlightBrushValue As Brush
    Public Property HighlightBrush() As Brush
        Get
            Return highlightBrushValue
        End Get
        Set(ByVal value As Brush)
            highlightBrushValue = value
        End Set
    End Property

    Public Sub SwitchTheme(theme As Integer)
        If theme = Themes.LightTheme Then
            keywordStyleValue = New TextStyle(New SolidBrush(Color.FromArgb(0, 0, 255)), Nothing, FontStyle.Regular)
            operatorStyleValue = New TextStyle(New SolidBrush(Color.FromArgb(0, 0, 255)), Nothing, FontStyle.Regular)
            numericStyleValue = New TextStyle(New SolidBrush(Color.FromArgb(128, 0, 0)), Nothing, FontStyle.Regular)
            stringStyleValue = New TextStyle(New SolidBrush(Color.FromArgb(69, 143, 34)), Nothing, FontStyle.Regular)
            commentStyleValue = New TextStyle(New SolidBrush(Color.FromArgb(173, 173, 173)), Nothing, FontStyle.Regular)
            functionStyleValue = New TextStyle(New SolidBrush(Color.FromArgb(144, 0, 144)), Nothing, FontStyle.Regular)
            highlightBrushValue = New SolidBrush(Color.FromArgb(128, Color.LightGreen))

            My.Settings.Theme = Themes.LightTheme
            With Main.SplitContainer
                .BackColor = SplitContainer.DefaultBackColor
                .ForeColor = SplitContainer.DefaultForeColor
            End With
            For Each page As TabPage In Main.TabControl.TabPages
                ApplyTabPageStyle(page)
            Next
            OutputColor = Color.Black
            OutputCommandColor = Color.Blue
            With Main.OutputBox
                .BackColor = Color.FromArgb(240, 240, 240)
                .ForeColor = OutputColor
            End With
            With Main.TabControl
                .DisplayStyleProvider = TradeWright.UI.Forms.TabStyleDefaultProvider.CreateProvider(Main.TabControl)
                .DisplayStyleProvider.ShowTabCloser = True
            End With

            Main.DarkModeMenuItem.Checked = False
            Main.DarkModeMenuItem.Enabled = True
            Main.LightModeMenuItem.Enabled = False
        ElseIf theme = Themes.DarkTheme Then
            keywordStyleValue = New TextStyle(New SolidBrush(Color.FromArgb(249, 36, 114)), Nothing, FontStyle.Regular)
            operatorStyleValue = New TextStyle(New SolidBrush(Color.FromArgb(249, 36, 114)), Nothing, FontStyle.Regular)
            numericStyleValue = New TextStyle(New SolidBrush(Color.FromArgb(172, 106, 200)), Nothing, FontStyle.Regular)
            stringStyleValue = New TextStyle(New SolidBrush(Color.FromArgb(231, 219, 116)), Nothing, FontStyle.Regular)
            commentStyleValue = New TextStyle(New SolidBrush(Color.FromArgb(116, 112, 93)), Nothing, FontStyle.Regular)
            functionStyleValue = New TextStyle(New SolidBrush(Color.FromArgb(166, 226, 43)), Nothing, FontStyle.Regular)
            highlightBrushValue = New SolidBrush(Color.FromArgb(64, Color.Gray))

            My.Settings.Theme = Themes.DarkTheme
            With Main.SplitContainer
                .BackColor = Color.FromArgb(60, 60, 60)
                .ForeColor = Color.LightGray
            End With
            For Each page As TabPage In Main.TabControl.TabPages
                ApplyTabPageStyle(page)
            Next
            OutputColor = Color.White
            OutputCommandColor = Color.FromArgb(249, 36, 114)
            With Main.OutputBox
                .BackColor = Color.FromArgb(45, 45, 45)
                .ForeColor = OutputColor
            End With
            With Main.TabControl
                .DisplayStyleProvider.TabColorUnSelected1 = Color.FromArgb(70, 70, 70)
                .DisplayStyleProvider.TabColorUnSelected2 = Color.FromArgb(70, 70, 70)
                .DisplayStyleProvider.TabColorFocused1 = Color.DimGray
                .DisplayStyleProvider.TabColorFocused2 = Color.DimGray
                .DisplayStyleProvider.TabColorHighLighted1 = Color.Gray
                .DisplayStyleProvider.TabColorHighLighted2 = Color.Gray
            End With
            Main.LightModeMenuItem.Checked = False
            Main.LightModeMenuItem.Enabled = True
            Main.DarkModeMenuItem.Enabled = False
        End If
    End Sub
    Public Sub ApplyTabPageStyle(page As TabPage)
        With TryCast(page.Controls(0), FastColoredTextBox)
            .ClearStylesBuffer()
            If My.Settings.Theme = Themes.LightTheme Then
                .BackColor = Color.White
                .ForeColor = Color.Black
                .SelectionColor = Color.DarkBlue
                .IndentBackColor = FastColoredTextBox.DefaultBackColor
                .LineNumberColor = Color.DarkBlue
                .BracketsStyle = New MarkerStyle(New SolidBrush(Color.FromArgb(100, 0, 0, 100)))
                .CaretColor = Color.Black
            ElseIf My.Settings.Theme = Themes.DarkTheme Then
                .BackColor = Color.FromArgb(45, 45, 45)
                .ForeColor = Color.White
                .SelectionColor = Color.Gray
                .IndentBackColor = Color.FromArgb(45, 45, 45)
                .LineNumberColor = Color.White
                .BracketsStyle = New MarkerStyle(New SolidBrush(Color.FromArgb(100, 150, 150, 150)))
                .CaretColor = Color.FromArgb(210, 210, 210)
            End If
            .OnTextChanged(0, .LinesCount - 1)
        End With
    End Sub
End Class
