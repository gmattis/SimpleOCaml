Option Strict On
Imports System.ComponentModel

<ToolboxBitmap(GetType(System.Windows.Forms.TabControl))>
Public Class TabControlEx
    Inherits TabControl

    Private Declare Auto Function SetParent Lib "user32" (ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As IntPtr
    Protected CloseButtonCollection As New Dictionary(Of Button, TabPage)
    Private _ShowCloseButtonOnTabs As Boolean = True

    <Browsable(True), DefaultValue(True), Category("Behavior"), Description("Indicates whether a close button should be shown on each TabPage")>
    Public Property ShowCloseButtonOnTabs() As Boolean
        Get
            Return _ShowCloseButtonOnTabs
        End Get
        Set(ByVal value As Boolean)
            _ShowCloseButtonOnTabs = value
            For Each btn In CloseButtonCollection.Keys
                btn.Visible = _ShowCloseButtonOnTabs
            Next
            RePositionCloseButtons()
        End Set
    End Property

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        RePositionCloseButtons()
    End Sub

    Protected Overrides Sub OnControlAdded(ByVal e As System.Windows.Forms.ControlEventArgs)
        MyBase.OnControlAdded(e)
        Dim tp As TabPage = DirectCast(e.Control, TabPage)
        Dim rect As Rectangle = Me.GetTabRect(Me.TabPages.IndexOf(tp))
        Dim btn As Button = AddCloseButton(tp)
        btn.Size = New Size(rect.Height - 1, rect.Height - 1)
        btn.Location = New Point(rect.X + rect.Width - rect.Height - 1, rect.Y + 1)
        SetParent(btn.Handle, Me.Handle)
        AddHandler btn.Click, AddressOf OnCloseButtonClick
        CloseButtonCollection.Add(btn, tp)
    End Sub

    Protected Overrides Sub OnControlRemoved(ByVal e As System.Windows.Forms.ControlEventArgs)
        Dim btn As Button = CloseButtonOfTabPage(DirectCast(e.Control, TabPage))
        RemoveHandler btn.Click, AddressOf OnCloseButtonClick
        CloseButtonCollection.Remove(btn)
        SetParent(btn.Handle, Nothing)
        btn.Dispose()
        MyBase.OnControlRemoved(e)
    End Sub

    Protected Overrides Sub OnLayout(ByVal levent As System.Windows.Forms.LayoutEventArgs)
        MyBase.OnLayout(levent)
        RePositionCloseButtons()
    End Sub

    Public Event CloseButtonClick As CancelEventHandler
    Protected Overridable Sub OnCloseButtonClick(ByVal sender As Object, ByVal e As EventArgs)
        If Not DesignMode Then
            Dim btn As Button = DirectCast(sender, Button)
            Dim tp As TabPage = CloseButtonCollection(btn)
            Dim ee As New CancelEventArgs
            RaiseEvent CloseButtonClick(sender, ee)
            If Not ee.Cancel Then
                Me.TabPages.Remove(tp)
                RePositionCloseButtons()
            End If
        End If
    End Sub

    Protected Overridable Function AddCloseButton(ByVal tp As TabPage) As Button
        Dim closeButton As New Button
        With closeButton
            '' TODO: Give a good visual appearance to the Close button, maybe by assigning images etc.
            ''       Here I have not used images to keep things simple.
            .Text = "X"
            .FlatStyle = FlatStyle.Flat
            .BackColor = Color.FromKnownColor(KnownColor.ButtonFace)
            .ForeColor = Color.White
            .Font = New Font("Microsoft Sans Serif", 6, FontStyle.Bold)
        End With
        Return closeButton
    End Function

    Public Sub RePositionCloseButtons()
        For Each item In CloseButtonCollection
            RePositionCloseButtons(item.Value)
        Next
    End Sub

    Public Sub RePositionCloseButtons(ByVal tp As TabPage)
        Dim btn As Button = CloseButtonOfTabPage(tp)
        If btn IsNot Nothing Then
            Dim tpIndex As Integer = Me.TabPages.IndexOf(tp)
            If tpIndex >= 0 Then
                Dim rect As Rectangle = Me.GetTabRect(tpIndex)
                If Me.SelectedTab Is tp Then
                    btn.BackColor = Color.Red
                    btn.Size = New Size(rect.Height - 1, rect.Height - 1)
                    btn.Location = New Point(rect.X + rect.Width - rect.Height, rect.Y + 1)
                Else
                    btn.BackColor = Color.FromKnownColor(KnownColor.ButtonFace)
                    btn.Size = New Size(rect.Height - 3, rect.Height - 3)
                    btn.Location = New Point(rect.X + rect.Width - rect.Height - 1, rect.Y + 1)
                End If
                btn.Visible = ShowCloseButtonOnTabs
                btn.BringToFront()
            End If
        End If
    End Sub

    Protected Function CloseButtonOfTabPage(ByVal tp As TabPage) As Button
        Return (From item In CloseButtonCollection Where item.Value Is tp Select item.Key).FirstOrDefault
    End Function
End Class