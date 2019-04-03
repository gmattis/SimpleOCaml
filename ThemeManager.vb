Imports FastColoredTextBoxNS

Public Class ThemeManager
    Public Enum Themes
        LightTheme = 0
        DarkTheme = 1
    End Enum

    Public Sub New()
        If My.Settings.Theme = Themes.DarkTheme Then
            keywordStyleValue = New TextStyle(Brushes.PaleVioletRed, Nothing, FontStyle.Regular)
            numericStyleValue = New TextStyle(Brushes.DodgerBlue, Nothing, FontStyle.Regular)
            stringStyleValue = New TextStyle(Brushes.Firebrick, Nothing, FontStyle.Regular)
            highlightBrushValue = New SolidBrush(Color.FromArgb(128, Color.CornflowerBlue))
        Else
            keywordStyleValue = New TextStyle(Brushes.Orchid, Nothing, FontStyle.Regular)
            numericStyleValue = New TextStyle(Brushes.Blue, Nothing, FontStyle.Regular)
            stringStyleValue = New TextStyle(New SolidBrush(Color.FromArgb(234, 128, 11)), Nothing, FontStyle.Regular)
            highlightBrushValue = New SolidBrush(Color.FromArgb(128, Color.LightGreen))
        End If

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
            keywordStyleValue = New TextStyle(Brushes.Orchid, Nothing, FontStyle.Regular)
            numericStyleValue = New TextStyle(Brushes.Blue, Nothing, FontStyle.Regular)
            stringStyleValue = New TextStyle(New SolidBrush(Color.FromArgb(234, 128, 11)), Nothing, FontStyle.Regular)
            highlightBrushValue = New SolidBrush(Color.FromArgb(128, Color.LightGreen))

            My.Settings.Theme = Themes.LightTheme
            With Main.SplitContainer
                .BackColor = SplitContainer.DefaultBackColor
                .ForeColor = SplitContainer.DefaultForeColor
            End With
            For Each page As TabPage In Main.TabControl.TabPages
                ApplyTabPageStyle(page)
            Next
            With Main.OutputBox
                .BackColor = RichTextBox.DefaultBackColor
                .ForeColor = RichTextBox.DefaultForeColor
            End With
            With Main.TabControl
                .DisplayStyleProvider = TradeWright.UI.Forms.TabStyleDefaultProvider.CreateProvider(Main.TabControl)
                .DisplayStyleProvider.ShowTabCloser = True
            End With

            Main.DarkModeMenuItem.Checked = False
            Main.DarkModeMenuItem.Enabled = True
            Main.LightModeMenuItem.Enabled = False
        ElseIf theme = Themes.DarkTheme Then
            keywordStyleValue = New TextStyle(Brushes.DeepPink, Nothing, FontStyle.Regular)
            numericStyleValue = New TextStyle(Brushes.SteelBlue, Nothing, FontStyle.Regular)
            stringStyleValue = New TextStyle(Brushes.Coral, Nothing, FontStyle.Regular)
            highlightBrushValue = New SolidBrush(Color.FromArgb(128, Color.CornflowerBlue))

            My.Settings.Theme = Themes.DarkTheme
            With Main.SplitContainer
                .BackColor = Color.FromArgb(60, 60, 60)
                .ForeColor = Color.LightGray
            End With
            For Each page As TabPage In Main.TabControl.TabPages
                ApplyTabPageStyle(page)
            Next
            With Main.OutputBox
                .BackColor = Color.FromArgb(45, 45, 45)
                .ForeColor = Color.LightGray
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
            If My.Settings.Theme = Themes.LightTheme Then
                .BackColor = FastColoredTextBox.DefaultBackColor
                .ForeColor = FastColoredTextBox.DefaultForeColor
                .SelectionColor = Color.DarkBlue
            ElseIf My.Settings.Theme = Themes.DarkTheme Then
                .BackColor = Color.FromArgb(45, 45, 45)
                .ForeColor = Color.LightGray
                .SelectionColor = Color.DarkBlue
                .LineNumberColor = Color.SteelBlue
            End If
            .OnTextChanged(0, .LinesCount - 1)
        End With
    End Sub
End Class
