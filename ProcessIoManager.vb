Imports System.IO
Imports System.Text
Imports System.Threading

Namespace ProcessReadWriteUtils
    Public Delegate Sub StringReadEventHandler(ByVal text As String)

    Public Class ProcessIoManager
        Private runningProcess As Process
        Private stdoutThread As Thread
        Private stderrThread As Thread
        Private streambuffer As StringBuilder

        Public ReadOnly Property GetRunningProcess As Process
            Get
                Return runningProcess
            End Get
        End Property

        Public Event StdoutTextRead As StringReadEventHandler
        Public Event StderrTextRead As StringReadEventHandler

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

            If runningProcess.StartInfo.RedirectStandardError = True Then
                stderrThread = New Thread(New ThreadStart(AddressOf ReadStandardErrorThreadMethod))
                stderrThread.IsBackground = True
                stderrThread.Start()
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

        Private Sub ReadStream(ByVal firstCharRead As Integer, ByVal streamReader As StreamReader, ByVal isstdout As Boolean)
            SyncLock Me
                Dim ch As Integer
                streambuffer.Length = 0
                streambuffer.Append(ChrW(firstCharRead))

                While streamReader.Peek() > -1
                    ch = streamReader.Read()
                    streambuffer.Append(ChrW(ch))
                    If Chr(ch) = vbLf Then NotifyAndFlushBufferText(streambuffer, isstdout)
                End While

                NotifyAndFlushBufferText(streambuffer, isstdout)
            End SyncLock
        End Sub

        Private Sub NotifyAndFlushBufferText(ByVal textbuffer As StringBuilder, ByVal isstdout As Boolean)
            If textbuffer.Length > 0 Then

                If isstdout = True Then
                    RaiseEvent StdoutTextRead(textbuffer.ToString())
                ElseIf isstdout = False Then
                    RaiseEvent StderrTextRead(textbuffer.ToString())
                End If

                textbuffer.Length = 0
            End If
        End Sub

        Private Sub ReadStandardOutputThreadMethod()
            Try
                Dim ch As Integer = runningProcess.StandardOutput.Read()

                While runningProcess IsNot Nothing And ch > -1
                    ReadStream(ch, runningProcess.StandardOutput, True)
                    ch = runningProcess.StandardOutput.Read()
                End While

            Catch ex As Exception
                Console.WriteLine("ProcessIoManager.ReadStandardOutputThreadMethod()- Exception caught:" & ex.Message & vbLf & "Stack Trace:" & ex.StackTrace)
            End Try
        End Sub

        Private Sub ReadStandardErrorThreadMethod()
            Try
                Dim ch As Integer = runningProcess.StandardError.Read()

                While runningProcess IsNot Nothing AndAlso ch > -1
                    ReadStream(ch, runningProcess.StandardError, False)
                    ch = runningProcess.StandardError.Read()
                End While

            Catch ex As Exception
                Console.WriteLine("ProcessIoManager.ReadStandardErrorThreadMethod()- Exception caught:" & ex.Message & vbLf & "Stack Trace:" & ex.StackTrace)
            End Try
        End Sub

        Public Sub StopMonitoringProcessOutput()
            Try
                If stdoutThread IsNot Nothing Then stdoutThread.Abort()
            Catch ex As Exception
                Console.WriteLine("ProcessIoManager.StopReadThreads()-Exception caught on stopping stdout thread." & vbLf & "Exception Message:" & vbLf & ex.Message & vbLf & "Stack Trace:" & vbLf & ex.StackTrace)
            End Try

            Try
                If stderrThread IsNot Nothing Then stderrThread.Abort()
            Catch ex As Exception
                Console.WriteLine("ProcessIoManager.StopReadThreads()-Exception caught on stopping stderr thread." & vbLf & "Exception Message:" & vbLf & ex.Message & vbLf & "Stack Trace:" & vbLf & ex.StackTrace)
            End Try

            stdoutThread = Nothing
            stderrThread = Nothing
        End Sub
    End Class
End Namespace
