Public Class OCaml
    Implements IDisposable

    Public Event OutputRead(ByVal output As String)

    Private WithEvents _process As Process
    Private WithEvents _processIoMgr As ProcessReadWriteUtils.ProcessIoManager

    Public Sub Start(ByVal filePath As String, ByVal arguments As String)
        If _process IsNot Nothing Then
            Throw New Exception("Already watching process")
        End If
        _process = New Process()
        With _process.StartInfo
            .Arguments = arguments
            .CreateNoWindow = True
            .FileName = filePath
            .UseShellExecute = False
            .RedirectStandardInput = True
            .RedirectStandardOutput = True
        End With

        _process.Start()
        _processIoMgr = New ProcessReadWriteUtils.ProcessIoManager(_process)
        AddHandler _processIoMgr.StdoutTextRead, New ProcessReadWriteUtils.StringReadEventHandler(AddressOf OutputDataReceived)
        _processIoMgr.StartProcessOutputRead()
    End Sub

    Public Sub Execute(ByVal command As String)
        If _process.HasExited Then
            _process.Dispose()
            _process = Nothing
        End If
        _process.StandardInput.WriteLine(command)
    End Sub

    Private Sub OutputDataReceived(str As String)
        If _process.HasExited Then
            _process.Dispose()
            _process = Nothing
        End If
        RaiseEvent OutputRead(str)
    End Sub

    Private disposedValue As Boolean = False
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                If _process IsNot Nothing Then
                    _process.Kill()
                    _process.Dispose()
                    _process = Nothing
                End If
            End If
        End If
        Me.disposedValue = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Public Function GetState()
        Return _process IsNot Nothing
    End Function
End Class
