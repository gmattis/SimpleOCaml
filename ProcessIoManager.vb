Imports System.IO
Imports System.Text
Imports System.Threading

Namespace ProcessReadWriteUtils
    Public Delegate Sub StringReadEventHandler(ByVal text As String)

    Public Class ProcessIoManager
        Private runningProcess As Process
        Private stdoutThread As Thread
        Private streambuffer As StringBuilder

        Public ReadOnly Property GetRunningProcess As Process
            Get
                Return runningProcess
            End Get
        End Property

        Public Sub New(ByVal process As Process)
            If process Is Nothing Then Throw New Exception("ProcessIoManager unable to set running process - null value is supplied")
            If process.HasExited = True Then Throw New Exception("ProcessIoManager unable to set running process - the process has already existed.")
            Me.runningProcess = process
            Me.streambuffer = New StringBuilder(256)
        End Sub

        Public Sub StartProcessOutputRead()
            StopMonitoringProcessOutput()
            CheckForValidProcess("Unable to start monitoring process output.", True)

            If runningProcess.StartInfo.RedirectStandardOutput = True Then
                stdoutThread = New Thread(New ThreadStart(AddressOf ReadStandardOutputThreadMethod))
                stdoutThread.IsBackground = True
                stdoutThread.Start()
            End If
        End Sub

        Public Sub WriteStdin(ByVal text As String)
            CheckForValidProcess("Unable to write to process standard input.", True)
            If runningProcess.StartInfo.RedirectStandardInput = True Then runningProcess.StandardInput.WriteLine(text)
        End Sub

        Private Sub CheckForValidProcess(ByVal errorMessageText As String, ByVal checkForHasExited As Boolean)
            errorMessageText = (If(errorMessageText Is Nothing, "", errorMessageText.Trim()))
            If runningProcess Is Nothing Then Throw New Exception(errorMessageText & " (Running process must be available)")
            If checkForHasExited AndAlso runningProcess.HasExited Then Throw New Exception(errorMessageText & " (Process has exited)")
        End Sub

        Private Sub ReadStandardOutputThreadMethod()
            Try
                Dim ch As Integer = runningProcess.StandardOutput.Read()

                While runningProcess IsNot Nothing
                    UpdateStreamBuffer(False, ch)
                    ch = runningProcess.StandardOutput.Read()
                End While

            Catch ex As Exception
                Console.WriteLine("ProcessIoManager.ReadStandardOutputThreadMethod()- Exception caught:" & ex.Message & vbLf & "Stack Trace:" & ex.StackTrace)
            End Try
        End Sub

        Public Sub StopMonitoringProcessOutput()
            Try
                If stdoutThread IsNot Nothing Then stdoutThread.Abort()
            Catch ex As Exception
                Console.WriteLine("ProcessIoManager.StopReadThreads()-Exception caught on stopping stdout thread." & vbLf & "Exception Message:" & vbLf & ex.Message & vbLf & "Stack Trace:" & vbLf & ex.StackTrace)
            End Try
            stdoutThread = Nothing
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

        Public Function Refresh()
            Return UpdateStreamBuffer(True)
        End Function
    End Class
End Namespace
