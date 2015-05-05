Public Class AudioDeviceList
    'Public Shared Devices As ArrayList
    Public Shared ActiveDevice As AudioDevice

    Shared Sub New()
        Try
            ActiveDevice = AudioDevice.LoadDevice()
            AudioDevice.SaveDevice(ActiveDevice)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Shared Function NextDevice() As AudioDevice
        Dim devices As ArrayList
        devices = AudioDevices()
        If ActiveDevice Is Nothing Then
            ActiveDevice = devices(0)
        Else
            Dim i As Integer
            Dim d As AudioDevice

            For i = 0 To devices.Count - 1
                d = devices(i)
                If d.DeviceNumber = ActiveDevice.DeviceNumber Then
                    If i = devices.Count - 1 Then
                        ActiveDevice = devices(0)
                    Else
                        ActiveDevice = devices(i + 1)
                    End If
                    Exit For
                End If
            Next
        End If

        AudioDevice.SaveDevice(ActiveDevice)
        AudioDevice.EnableDevice(ActiveDevice)
        NextDevice = ActiveDevice
    End Function

    Shared Function AudioDevices() As ArrayList
        Dim deviceList As New ArrayList
        Dim device As New AudioDevice

        EndPointController.Run()
        If Not EndPointController.ErrorMessage Is Nothing Then
            Throw New Exception("Error running the Endpoint-Controller")
        End If

        For Each deviceStr In EndPointController.Output
            device = AudioDevice.ParseDeviceStr(deviceStr)
            deviceList.Add(device)
        Next

        If deviceList.Count = 0 Then
            Throw New Exception("No audio devices found.")
        End If

        AudioDevices = deviceList
    End Function

End Class
