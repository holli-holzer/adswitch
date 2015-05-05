Imports System.IO

Public Class EndPointController
    Public Shared ErrorMessage As String
    Public Shared Output As New ArrayList
    Shared StartInfo As ProcessStartInfo

    Shared Sub New()
        StartInfo = New ProcessStartInfo()
        StartInfo.UseShellExecute = False
        StartInfo.RedirectStandardOutput = True
        StartInfo.CreateNoWindow = True
        StartInfo.FileName = TempExeFileName()
        Dim di = New FileInfo(StartInfo.FileName)
        If Not di.Exists Then
            MakeTempExe(StartInfo.FileName)
        End If
    End Sub

    Shared Sub MakeTempExe(ByVal ExeFileName As String)
        Dim off As New IO.FileStream(ExeFileName, FileMode.Create)
        off.Write(My.Resources.EndPointController, 0, My.Resources.EndPointController.Length)
        off.Close()
    End Sub

    Shared Function Run(Optional ByVal Arguments As String = "") As Boolean
        Dim proc As New Process()
        proc.StartInfo = StartInfo
        proc.StartInfo.Arguments = Arguments
        Output = New ArrayList
        Try
            proc.Start()
            While (Not proc.StandardOutput.EndOfStream)
                Output.Add(proc.StandardOutput.ReadLine())
            End While
            ErrorMessage = Nothing
            Run = True
        Catch ex As Exception
            Output = New ArrayList
            ErrorMessage = ex.Message
            Run = False
        End Try
    End Function

    Shared Function TempExeFileName() As String
        TempExeFileName = IO.Path.GetTempPath() + "epc.exe"
    End Function
End Class
