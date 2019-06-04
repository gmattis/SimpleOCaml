Imports FastColoredTextBoxNS

Public Class ThemeManager
    Public OutputColor As Color
    Public OutputCommandColor As Color
    Public ThemeLoader As New ThemeLoader

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

    Private variableStyleValue As TextStyle
    Public Property VariableStyle() As TextStyle
        Get
            Return variableStyleValue
        End Get
        Set(ByVal value As TextStyle)
            variableStyleValue = value
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

    Public Sub SwitchTheme(theme As Themes)
        ThemeLoader.Reload(theme)

        Dim TextFont As Font = New Font(My.Settings.Font_Family, My.Settings.Font_Size, My.Settings.Font_Style)
        Main.OutputBox.Font = TextFont
        Main.FastInputBox.Font = TextFont
        Main.OutputSplitContainer.SplitterIncrement = TextRenderer.MeasureText("I", TextFont).Height
        Main.OutputSplitContainer.Panel2MinSize = TextRenderer.MeasureText("I", TextFont).Height

        keywordStyleValue = New TextStyle(New SolidBrush(ThemeLoader.KeywordColor), Nothing, FontStyle.Regular)
        operatorStyleValue = New TextStyle(New SolidBrush(ThemeLoader.OperatorColor), Nothing, FontStyle.Regular)
        numericStyleValue = New TextStyle(New SolidBrush(ThemeLoader.NumericColor), Nothing, FontStyle.Regular)
        stringStyleValue = New TextStyle(New SolidBrush(ThemeLoader.StringColor), Nothing, FontStyle.Regular)
        commentStyleValue = New TextStyle(New SolidBrush(ThemeLoader.CommentColor), Nothing, FontStyle.Regular)
        variableStyleValue = New TextStyle(New SolidBrush(ThemeLoader.VariableColor), Nothing, FontStyle.Regular)

        ApplyTextBoxStyle(Main.FastInputBox)

        If theme = Themes.LightTheme Then
            My.Settings.Theme = Themes.LightTheme

            highlightBrushValue = New SolidBrush(Color.FromArgb(128, Color.LightGreen))

            With Main.MainSplitContainer
                .BackColor = SplitContainer.DefaultBackColor
                .ForeColor = SplitContainer.DefaultForeColor
            End With
            With Main.OutputSplitContainer
                .BackColor = SplitContainer.DefaultBackColor
                .ForeColor = SplitContainer.DefaultForeColor
            End With
            For Each page As TabPage In Main.TabControl.TabPages
                ApplyTextBoxStyle(page.Controls(0))
            Next
            OutputColor = Color.Black
            OutputCommandColor = Color.Blue
            With Main.OutputBox
                .BackColor = Color.FromArgb(240, 240, 240)
                .ForeColor = OutputColor
            End With
            With Main.FastInputBox
                .BackColor = Color.FromArgb(240, 240, 240)
                .ForeColor = OutputColor
            End With
            With Main.TabControl
                .DisplayStyleProvider = TradeWright.UI.Forms.TabStyleProvider.CreateProvider(Main.TabControl)
                .DisplayStyleProvider.ShowTabCloser = True
            End With
        ElseIf theme = Themes.DarkTheme Then
            My.Settings.Theme = Themes.DarkTheme

            highlightBrushValue = New SolidBrush(Color.FromArgb(64, Color.Gray))

            With Main.MainSplitContainer
                .BackColor = Color.FromArgb(60, 60, 60)
                .ForeColor = Color.LightGray
            End With
            With Main.OutputSplitContainer
                .BackColor = Color.FromArgb(60, 60, 60)
                .ForeColor = Color.LightGray
            End With
            For Each page As TabPage In Main.TabControl.TabPages
                ApplyTextBoxStyle(page.Controls(0))
            Next
            OutputColor = Color.White
            OutputCommandColor = Color.FromArgb(250, 39, 114)
            With Main.OutputBox
                .BackColor = Color.FromArgb(40, 40, 35)
                .ForeColor = OutputColor
            End With
            With Main.FastInputBox
                .BackColor = Color.FromArgb(40, 40, 35)
                .ForeColor = OutputColor
            End With
            With Main.TabControl
                .DisplayStyleProvider.TabColorFocused1 = Color.FromArgb(70, 70, 65)
                .DisplayStyleProvider.TabColorFocused2 = Color.FromArgb(70, 70, 65)
                .DisplayStyleProvider.TextColorFocused = Color.FromArgb(220, 220, 220)
                .DisplayStyleProvider.TabColorHighLighted1 = Color.FromArgb(90, 90, 85)
                .DisplayStyleProvider.TabColorHighLighted2 = Color.FromArgb(90, 90, 85)
                .DisplayStyleProvider.TextColorHighlighted = Color.FromArgb(220, 220, 220)
                .DisplayStyleProvider.TabColorSelected1 = Color.FromArgb(70, 70, 65)
                .DisplayStyleProvider.TabColorSelected2 = Color.FromArgb(70, 70, 65)
                .DisplayStyleProvider.TextColorSelected = Color.FromArgb(220, 220, 220)
                .DisplayStyleProvider.TabColorUnSelected1 = Color.FromArgb(50, 50, 45)
                .DisplayStyleProvider.TabColorUnSelected2 = Color.FromArgb(50, 50, 45)
                .DisplayStyleProvider.TextColorUnselected = Color.FromArgb(220, 220, 220)
            End With
        End If
    End Sub

    Public Sub ApplyTextBoxStyle(tb As FastColoredTextBox)
        With tb
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
                .BackColor = Color.FromArgb(40, 40, 35)
                .ForeColor = Color.White
                .SelectionColor = Color.Gray
                .IndentBackColor = Color.FromArgb(40, 40, 35)
                .LineNumberColor = Color.White
                .BracketsStyle = New MarkerStyle(New SolidBrush(Color.FromArgb(100, 150, 150, 150)))
                .CaretColor = Color.FromArgb(210, 210, 210)
            End If
            .OnTextChanged(0, .LinesCount - 1)
            .Font = New Font(My.Settings.Font_Family, My.Settings.Font_Size, My.Settings.Font_Style)
        End With
    End Sub
End Class
