Imports System.IO
Imports System.Text
Imports System.Threading
Public Class OCaml
    Implements IDisposable

    Private WithEvents OcamlProcess As Process
    Private stdoutThread As Thread
    Private streambuffer As StringBuilder
    Private exePath = ""
    Private args = ""

    Public Sub Init(ByVal exePath As String, ByVal arguments As String)
        Me.exePath = exePath
        Me.args = arguments
        Me.streambuffer = New StringBuilder()
    End Sub
    Public Sub Start()
        If exePath = "" Then
            Throw New Exception("No path to OCaml executable given.")
        End If
        If OcamlProcess IsNot Nothing Then
            Throw New Exception("Already watching process.")
        End If
        OcamlProcess = New Process()
        With OcamlProcess.StartInfo
            .Arguments = args
            .CreateNoWindow = True
            .FileName = exePath
            .UseShellExecute = False
            .RedirectStandardInput = True
            .RedirectStandardOutput = True
        End With

        OcamlProcess.Start()
        StartProcessOutputRead()
    End Sub

    Public Sub StartProcessOutputRead()
        StopMonitoringProcessOutput()
        If OcamlProcess Is Nothing Then
            Start()
        End If

        If OcamlProcess.StartInfo.RedirectStandardOutput = True Then
            stdoutThread = New Thread(New ThreadStart(AddressOf ReadStandardOutputThreadMethod)) With {
                .IsBackground = True
            }
            stdoutThread.Start()
        End If
    End Sub

    Public Sub StopMonitoringProcessOutput()
        Try
            If stdoutThread IsNot Nothing Then stdoutThread.Abort()
        Catch ex As Exception
            Console.WriteLine("ProcessIoManager.StopReadThreads()-Exception caught on stopping stdout thread." & vbLf & "Exception Message:" & vbLf & ex.Message & vbLf & "Stack Trace:" & vbLf & ex.StackTrace)
        End Try
        stdoutThread = Nothing
    End Sub
    Private Sub ReadStandardOutputThreadMethod()
        Try
            Dim ch As Integer = OcamlProcess.StandardOutput.Read()

            While OcamlProcess IsNot Nothing
                UpdateStreamBuffer(False, ch)
                ch = OcamlProcess.StandardOutput.Read()
            End While

        Catch ex As Exception
            Console.WriteLine("ProcessIoManager.ReadStandardOutputThreadMethod()- Exception caught:" & ex.Message & vbLf & "Stack Trace:" & ex.StackTrace)
        End Try
    End Sub

    Private Function UpdateStreamBuffer(readmode As Boolean, Optional ch As Integer = -1)
        SyncLock Me
            If readmode Then
                Dim str = streambuffer.ToString
                streambuffer.Length = 0
                Return str
            ElseIf ch > -1 Then
                streambuffer.Append(ChrW(ch))
                Return Nothing
            End If
            Return Nothing
        End SyncLock
    End Function

    Public Sub Execute(ByVal command As String)
        If OcamlProcess Is Nothing Then
            Start()
        End If
        OcamlProcess.StandardInput.WriteLine(command)
    End Sub

    Public Function Refresh()
        Return UpdateStreamBuffer(True)
    End Function

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If OcamlProcess IsNot Nothing Then
                OcamlProcess.Kill()
                OcamlProcess.Dispose()
                OcamlProcess = Nothing
            End If
        End If
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

End Class
