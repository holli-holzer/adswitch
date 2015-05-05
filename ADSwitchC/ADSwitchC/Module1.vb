Imports ADSwitch

Module Module1

    Sub Main()
        AudioDeviceList.NextDevice()
        Console.WriteLine("Now active: " & AudioDeviceList.ActiveDevice.Description)
    End Sub

End Module
