Imports System.IO
Imports System.IO.Path

Public Class AudioDevice
    Public DeviceNumber As Integer
    Public Description As String

    Private Shared Function DataFileName() As String
        DataFileName = Path.GetTempPath() & "lastAudioDevice"
    End Function

    Shared Function LoadDevice() As AudioDevice
        Dim infile As StreamReader
        Try
            infile = New StreamReader(DataFileName())
        Catch ex As Exception
            LoadDevice = AudioDeviceList.AudioDevices(0)
            Exit Function
        End Try

        Dim deviceStr As String = infile.ReadLine
        If deviceStr Is Nothing Then
            LoadDevice = Nothing
        Else
            LoadDevice = ParseDeviceStr(deviceStr)
        End If

        infile.Close()
    End Function

    Shared Sub SaveDevice(ByVal device As AudioDevice)
        Dim outfile As New StreamWriter(DataFileName())
        outfile.Write("Audio Device " & device.DeviceNumber & ": " & device.Description)
        outfile.Close()
    End Sub

    Shared Sub EnableDevice(ByVal device As AudioDevice)
        EndPointController.Run(Str(device.DeviceNumber))
    End Sub

    Shared Function ParseDeviceStr(ByVal deviceStr As String) As AudioDevice
        Dim d As New AudioDevice
        Dim ds As String = deviceStr
        d.Description = ds.Substring(ds.IndexOf(":") + 2)
        If Len(d.Description) > 256 Then
            d.Description = d.Description.Substring(0, 255)
        End If

        d.DeviceNumber = ds.Substring(ds.IndexOf(":") - 1, 1)
        ParseDeviceStr = d
    End Function

End Class
