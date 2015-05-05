Imports System.Text
Imports System.Windows.Forms
Imports ADSwitch

Public Class Main
    Sub Notify(ByVal ActiceDeviceDescription As String)
        NotifyIcon.Text = ActiceDeviceDescription
        'MsgBox(ActiceDeviceDescription, MsgBoxStyle.Information, "Active Audiodevice: ")
    End Sub

    Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Notify(AudioDeviceList.ActiveDevice.Description)
        Catch ex As Exception
            MsgBox(ex.InnerException.Message, MsgBoxStyle.Critical, "Error")
            Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
        End Try
    End Sub

    Sub NotifyIcon_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon.DoubleClick
        Try
            ' Run this to counteract the click event
            VolumeController.Switch()

            AudioDeviceList.NextDevice()
            Notify(AudioDeviceList.ActiveDevice.Description)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Exxit(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Mute(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not VolumeController.Mute() Then MsgBox(VolumeController.ErrorMessage, MsgBoxStyle.Critical, "Error")
    End Sub

    Private Sub UnMute(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not VolumeController.Unmute Then MsgBox(VolumeController.ErrorMessage, MsgBoxStyle.Critical, "Error")
    End Sub

    Private Sub MaxVolume(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not VolumeController.MaxVolume Then MsgBox(VolumeController.ErrorMessage, MsgBoxStyle.Critical, "Error")
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Dim device As AudioDevice
        Dim item As ToolStripItem
        Dim i As Integer = 1
        Dim closureObject As SwitchClosure
        With ContextMenuStrip1.Items
            .Clear()
            For Each device In AudioDeviceList.AudioDevices()
                closureObject = New SwitchClosure
                closureObject.SwitchTo = device
                closureObject.MainMe = Me
                If device.DeviceNumber = AudioDeviceList.ActiveDevice.DeviceNumber Then
                    item = .Add("&" & i & ") " & device.Description, My.Resources.speaker_and_sound, New System.EventHandler(AddressOf closureObject.Switch))
                Else
                    item = .Add("&" & i & ") " & device.Description, Nothing, New System.EventHandler(AddressOf closureObject.Switch))
                End If
                i = i + 1
                item.Tag = device.DeviceNumber
            Next
            .Add("-")
            .Add("&Mute", Nothing, New System.EventHandler(AddressOf Me.Mute))
            .Add("&Unmute", Nothing, New System.EventHandler(AddressOf Me.UnMute))
            .Add("Max &Volume", Nothing, New System.EventHandler(AddressOf Me.MaxVolume))
            .Add("-")
            .Add("E&xit", Nothing, New System.EventHandler(AddressOf Me.Exxit))
        End With
    End Sub

    Private Sub Main_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.Hide()
    End Sub


    Private Sub NotifyIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotifyIcon.Click
        Dim ee As System.Windows.Forms.MouseEventArgs
        ee = CType(e, System.Windows.Forms.MouseEventArgs)
        If ee.Button = Windows.Forms.MouseButtons.Left Then
            If Not VolumeController.Switch() Then MsgBox(VolumeController.ErrorMessage, MsgBoxStyle.Critical, "Error")
        End If
    End Sub
End Class
