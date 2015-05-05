Imports System
Imports System.IO

Public Class VolumeController
    Public Shared ErrorMessage As String
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

    Public Shared Function Switch() As Boolean
        Switch = Run("mutesysvolume 2")
    End Function

    Public Shared Function Mute() As Boolean
        Mute = Run("mutesysvolume 1")
    End Function

    Public Shared Function Unmute() As Boolean
        Unmute = Run("mutesysvolume 0")
    End Function

    Public Shared Function MaxVolume() As Boolean
        MaxVolume = Run("setsysvolume 65535")
    End Function

    Private Shared Function Run(ByVal Arguments As String) As Boolean
        Dim proc As New Process()
        proc.StartInfo = StartInfo
        proc.StartInfo.Arguments = Arguments
        Try
            proc.Start()
            ErrorMessage = Nothing
            Run = True
        Catch ex As Exception
            ErrorMessage = ex.Message
            Run = False
        End Try
    End Function

    Shared Function TempExeFileName() As String
        TempExeFileName = IO.Path.GetTempPath() + "nircmdc.exe"
    End Function


    Shared Sub MakeTempExe(ByVal ExeFileName As String)
        Dim off As New IO.FileStream(ExeFileName, FileMode.Create)
        off.Write(My.Resources.nircmdc, 0, My.Resources.nircmdc.Length)
        off.Close()
    End Sub
End Class
