Imports ADSwitch

Public Class SwitchClosure
    Public SwitchTo As AudioDevice
    Public MainMe As Main

    Public Sub Switch(ByVal sender As Object, ByVal e As System.EventArgs)
        MainMe.Notify(SwitchTo.Description)
        AudioDevice.SaveDevice(SwitchTo)
        AudioDevice.EnableDevice(SwitchTo)
        AudioDeviceList.ActiveDevice = SwitchTo
    End Sub
End Class
