
Public Class Form1

    Private WithEvents MIO As New Midi_IO.Midi_IO

    Private VoiceNotePlaying As Byte = 128              ' if > 127 then no note is playing
    Private DrumNotePlaying As Byte = 128               ' if > 127 then no note is playing

    Private SpacebarPressed As Boolean

    Private ResettingVoiceOrVolume As Boolean = True    ' skip MidiMsgOut when resetting the controls        
    '                                                       to avoid unnecessary Midi-Messages

#Region "Common"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmbMidiOutPorts.Items.Clear()
        For i = 1 To MIO.MidiOutPorts.Count
            If MIO.MidiOutPorts(i - 1).invalidPort = False Then          'list only valid ports
                cmbMidiOutPorts.Items.Add(MIO.MidiOutPorts(i - 1).portName)
            End If
        Next

        cmbMidiInPorts.Items.Clear()
        For i = 1 To MIO.MidiInPorts.Count
            If MIO.MidiInPorts(i - 1).invalidPort = False Then          'list only valid ports
                cmbMidiInPorts.Items.Add(MIO.MidiInPorts(i - 1).portName)
            End If
        Next

        cmbMidiInPorts2.Items.Clear()
        For i = 1 To MIO.MidiInPorts.Count
            If MIO.MidiInPorts(i - 1).invalidPort = False Then          'list only valid ports
                cmbMidiInPorts2.Items.Add(MIO.MidiInPorts(i - 1).portName)
            End If
        Next

        cmbVoiceName.Items.Clear()
        Dim str As String = ""
        For i = 1 To GM_VoiceNames.Count
            If GM_VoiceNames.TryGetValue(i - 1, str) = False Then
                str = ""
            End If
            cmbVoiceName.Items.Add(str)
        Next

        cmbVoiceName.SelectedIndex = 0
        ResettingVoiceOrVolume = False

        '---

        trkbVoiceNote.Value = 50
        trkbDrumNote.Value = 40

        btnNote.Select()                                        ' set focus to this control

    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        '--- after using Midi_IO and a MidiIn Port is still open, ._end should be used to stop Midi-In,
        '--- else application exit code is 0xc0020001
        MIO._End()
    End Sub

    Private Sub cmbMidiOutPorts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMidiOutPorts.SelectedIndexChanged
        If Not hMidiOut = 0 Then
            MIO.CloseMidiOutPort(hMidiOut)
            hMidiOut = 0
        End If

        If cmbMidiOutPorts.SelectedItem IsNot Nothing Then
            Dim devName As String
            devName = cmbMidiOutPorts.SelectedItem.ToString

            MIO.OpenMidiOutPort(devName, hMidiOut, cmbMidiOutPorts.SelectedIndex)

            '--- initialize MainVolume and voice (on track 0)

            If trkbVolume.Value <> 127 Then             ' ValueChanged is only raised when value is different
                trkbVolume.Value = 127                  ' reset volume + value changed
            Else
                ' in case the device stores the main-volume, volume was turned down,
                ' Output port was closed, later opened again, MainVolume of the device is unknown
                SetMainVolume(127)                      ' always set the volume to max.
            End If

            If cmbVoiceName.SelectedIndex <> 0 Then     ' SelectedIndexChanged is only raised when index is different
                cmbVoiceName.SelectedIndex = 0          ' select index + SelectedIndexChanged
            Else
                SendProgramChange(0)                    ' always set voice to 'Acoustic Grand Piano'
            End If

        End If

    End Sub

    Private Sub cmbMidiInPorts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMidiInPorts.SelectedIndexChanged
        If Not hMidiIn = 0 Then
            MIO.CloseMidiInPort(hMidiIn)
            hMidiIn = 0
        End If

        If cmbMidiInPorts.SelectedItem IsNot Nothing Then
            Dim devName As String
            devName = cmbMidiInPorts.SelectedItem.ToString

            MIO.OpenMidiInPort(devName, hMidiIn, cmbMidiInPorts.SelectedIndex)
        End If
    End Sub

    Private Sub btnCloseOutput_Click(sender As Object, e As EventArgs) Handles btnCloseOutput.Click
        If Not hMidiOut = 0 Then
            MIO.CloseMidiOutPort(hMidiOut)
            hMidiOut = 0
        End If
        cmbMidiOutPorts.SelectedIndex = -1
    End Sub

    Private Sub btnCloseInput_Click(sender As Object, e As EventArgs) Handles btnCloseInput.Click
        If Not hMidiIn = 0 Then
            MIO.CloseMidiInPort(hMidiIn)
            hMidiIn = 0
        End If
        cmbMidiInPorts.SelectedIndex = -1
    End Sub

    Private Sub cmbMidiInPorts2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMidiInPorts2.SelectedIndexChanged
        If Not hMidiIn2 = 0 Then
            MIO.CloseMidiInPort(hMidiIn2)
            hMidiIn2 = 0
        End If

        If cmbMidiInPorts2.SelectedItem IsNot Nothing Then
            Dim devName As String
            devName = cmbMidiInPorts2.SelectedItem.ToString

            MIO.OpenMidiInPort(devName, hMidiIn2, cmbMidiInPorts2.SelectedIndex)
        End If
    End Sub

    Private Sub btnCloseInput2_Click(sender As Object, e As EventArgs) Handles btnCloseInput2.Click
        If Not hMidiIn2 = 0 Then
            MIO.CloseMidiInPort(hMidiIn2)
            hMidiIn2 = 0
        End If
        cmbMidiInPorts2.SelectedIndex = -1
    End Sub

    Private Sub cbFilterTimingClock_CheckedChanged(sender As Object, e As EventArgs) Handles cbFilterTimingClock.CheckedChanged
        If cbFilterTimingClock.Checked = True Then
            MIO.MidiIn_filter_TimingClock = True
        Else
            MIO.MidiIn_filter_TimingClock = False
        End If
    End Sub

    Private Sub cbFilterActiveSensing_CheckedChanged(sender As Object, e As EventArgs) Handles cbFilterActiveSensing.CheckedChanged
        If cbFilterActiveSensing.Checked = True Then
            MIO.MidiIn_filter_ActiveSense = True
        Else
            MIO.MidiIn_filter_ActiveSense = False
        End If
    End Sub

#End Region

#Region "Voice Note"

#Region "Voice Note Button"
    Private Sub btnNote_KeyDown(sender As Object, e As KeyEventArgs) Handles btnNote.KeyDown
        If e.KeyCode = Keys.Space Then
            If SpacebarPressed = False Then                             ' avoid key repeat when presseed
                VoiceNoteOn(CByte(trkbVoiceNote.Value))
                SpacebarPressed = True
            End If
        End If
    End Sub

    Private Sub btnNote_KeyUp(sender As Object, e As KeyEventArgs) Handles btnNote.KeyUp
        If e.KeyCode = Keys.Space Then
            VoiceNoteOff(CByte(trkbVoiceNote.Value))
            SpacebarPressed = False
        End If
    End Sub
    Private Sub btnNote_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNote.MouseDown
        VoiceNoteOn(CByte(trkbVoiceNote.Value))
    End Sub

    Private Sub btnNote_MouseUp(sender As Object, e As MouseEventArgs) Handles btnNote.MouseUp
        VoiceNoteOff(CByte(trkbVoiceNote.Value))
    End Sub
    Private Sub btnNote_Leave(sender As Object, e As EventArgs) Handles btnNote.Leave
        If VoiceNotePlaying < 128 Then
            VoiceNoteOff(VoiceNotePlaying)                          ' avoid hanging note            
        End If
        SpacebarPressed = False
    End Sub
#End Region

#Region "Voice Combobox"
    '--- combobox ---
    Private Sub cmbVoiceName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVoiceName.SelectedIndexChanged
        lblVoiceNumberValue.Text = CStr(cmbVoiceName.SelectedIndex)
        If ResettingVoiceOrVolume = True Then Exit Sub              ' when resetting voice to 0
        If VoiceNotePlaying < 128 Then
            VoiceNoteOff(VoiceNotePlaying)
        End If
        SendProgramChange(CByte(cmbVoiceName.SelectedIndex))
        If SpacebarPressed = True Then
            VoiceNoteOn(CByte(trkbVoiceNote.Value))
        End If
    End Sub

    Private Sub SendProgramChange(progNum As Byte)
        MidiOutShortMsg(hMidiOut, &HC0, progNum, 0)
    End Sub

    Private Sub cmbVoiceName_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbVoiceName.KeyDown
        If e.KeyCode = Keys.Space Then
            If SpacebarPressed = False Then
                VoiceNoteOn(CByte(trkbVoiceNote.Value))
                SpacebarPressed = True
            End If
        End If
    End Sub

    Private Sub cmbVoiceName_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbVoiceName.KeyUp
        If e.KeyCode = Keys.Space Then
            If VoiceNotePlaying < 128 Then
                VoiceNoteOff(CByte(trkbVoiceNote.Value))
                SpacebarPressed = False
            End If
        End If
    End Sub

    Private Sub cmbVoiceName_Leave(sender As Object, e As EventArgs) Handles cmbVoiceName.Leave
        If VoiceNotePlaying < 128 Then
            VoiceNoteOff(VoiceNotePlaying)                          ' avoid hanging note            
        End If
        SpacebarPressed = False
    End Sub
#End Region

#Region "Voice Trackbar"
    '--- Trackbar ---
    Private Sub trkbVoiceNote_ValueChanged(sender As Object, e As EventArgs) Handles trkbVoiceNote.ValueChanged
        Dim voice_note As Byte = CByte(trkbVoiceNote.Value)

        If VoiceNotePlaying < 128 Then
            VoiceNoteOff(VoiceNotePlaying)
        End If

        If SpacebarPressed = True Then
            VoiceNoteOn(CByte(trkbVoiceNote.Value))
        End If

        lblVoiceNoteValue.Text = CStr(trkbVoiceNote.Value)
    End Sub
    Private Sub trkbVoiceNote_KeyDown(sender As Object, e As KeyEventArgs) Handles trkbVoiceNote.KeyDown
        If e.KeyCode = Keys.Space Then
            If SpacebarPressed = False Then
                VoiceNoteOn(CByte(trkbVoiceNote.Value))
                SpacebarPressed = True
            End If
        End If
    End Sub
    Private Sub trkbVoiceNote_KeyUp(sender As Object, e As KeyEventArgs) Handles trkbVoiceNote.KeyUp
        If e.KeyCode = Keys.Space Then
            If VoiceNotePlaying < 128 Then
                VoiceNoteOff(CByte(trkbVoiceNote.Value))
                SpacebarPressed = False
            End If
        End If
    End Sub
    Private Sub trkbVoiceNote_MouseDown(sender As Object, e As MouseEventArgs) Handles trkbVoiceNote.MouseDown
        VoiceNoteOn(CByte(trkbVoiceNote.Value))
        SpacebarPressed = True
    End Sub
    Private Sub trkbVoiceNote_MouseUp(sender As Object, e As MouseEventArgs) Handles trkbVoiceNote.MouseUp
        VoiceNoteOff(CByte(trkbVoiceNote.Value))
        SpacebarPressed = False
    End Sub

    Private Sub trkbVoiceNote_Leave(sender As Object, e As EventArgs) Handles trkbVoiceNote.Leave
        If VoiceNotePlaying < 128 Then
            VoiceNoteOff(CByte(trkbVoiceNote.Value))
        End If
        SpacebarPressed = False
    End Sub
#End Region

    Private Sub VoiceNoteOn(VoiceNote As Byte)
        If VoiceNotePlaying < 128 Then
            VoiceNoteOff(VoiceNotePlaying)                          ' avoid hanging notes           
        End If
        MidiOutShortMsg(hMidiOut, &H90, VoiceNote, 100)
        VoiceNotePlaying = VoiceNote
    End Sub

    Private Sub VoiceNoteOff(VoiceNote As Byte)
        If VoiceNotePlaying < 128 Then
            MidiOutShortMsg(hMidiOut, &H90, VoiceNote, 0)
            VoiceNotePlaying = 128
        End If
    End Sub

#Region "Play Voice on Keyboard"
    '--- Play on Keyboard ---
    Private Sub btnPlayOnKeyboard_KeyDown(sender As Object, e As KeyEventArgs) Handles btnPlayOnKeyboard.KeyDown
        KbdNoteOn(CByte(e.KeyCode))
    End Sub

    Private Sub btnPlayOnKeyboard_KeyUp(sender As Object, e As KeyEventArgs) Handles btnPlayOnKeyboard.KeyUp
        KbdNoteOff(CByte(e.KeyCode))
    End Sub

    Private Sub btnPlayOnKeyboard_Leave(sender As Object, e As EventArgs) Handles btnPlayOnKeyboard.Leave
        KbdNotes_AllNotesOff()                                      ' turn all notes off
    End Sub
#End Region

#End Region

#Region "Drum Note"

#Region "Drum Note Button"
    Private Sub btnDrumNote_KeyDown(sender As Object, e As KeyEventArgs) Handles btnDrumNote.KeyDown
        If e.KeyCode = Keys.Space Then
            DrumNoteOn(CByte(trkbDrumNote.Value))
        End If
    End Sub

    Private Sub btnDrumNote_KeyUp(sender As Object, e As KeyEventArgs) Handles btnDrumNote.KeyUp
        If e.KeyCode = Keys.Space Then
            DrumNoteOff(CByte(trkbDrumNote.Value))
        End If
    End Sub

    Private Sub btnDrumNote_MouseDown(sender As Object, e As MouseEventArgs) Handles btnDrumNote.MouseDown
        DrumNoteOn(CByte(trkbDrumNote.Value))
    End Sub

    Private Sub btnDrumNote_MouseUp(sender As Object, e As MouseEventArgs) Handles btnDrumNote.MouseUp
        DrumNoteOff(CByte(trkbDrumNote.Value))
    End Sub

#End Region

#Region "Drum Trackbar"

    Private Sub trkbDrumNote_ValueChanged(sender As Object, e As EventArgs) Handles trkbDrumNote.ValueChanged
        Dim drum_note As Byte = CByte(trkbDrumNote.Value)

        If DrumNotePlaying < 128 Then
            DrumNoteOff(DrumNotePlaying)
        End If

        If SpacebarPressed = True Then
            DrumNoteOn(CByte(trkbDrumNote.Value))
        End If

        lblDrumNoteValue.Text = CStr(trkbDrumNote.Value)

        lblDrumNoteName.Text = GetDrumVoiceName(CByte(trkbDrumNote.Value))

    End Sub
    Private Sub trkbDrumNote_KeyDown(sender As Object, e As KeyEventArgs) Handles trkbDrumNote.KeyDown
        If e.KeyCode = Keys.Space Then
            If SpacebarPressed = False Then
                DrumNoteOn(CByte(trkbDrumNote.Value))
                SpacebarPressed = True
            End If
        End If
    End Sub

    Private Sub trkbDrumNote_KeyUp(sender As Object, e As KeyEventArgs) Handles trkbDrumNote.KeyUp
        If e.KeyCode = Keys.Space Then
            If DrumNotePlaying < 128 Then
                DrumNoteOff(CByte(trkbDrumNote.Value))
                SpacebarPressed = False
            End If
        End If
    End Sub

    Private Sub trkbDrumNote_MouseDown(sender As Object, e As MouseEventArgs) Handles trkbDrumNote.MouseDown
        DrumNoteOn(CByte(trkbDrumNote.Value))
        SpacebarPressed = True
    End Sub

    Private Sub trkbDrumNote_MouseUp(sender As Object, e As MouseEventArgs) Handles trkbDrumNote.MouseUp
        DrumNoteOff(CByte(trkbDrumNote.Value))
        SpacebarPressed = False
    End Sub

    Private Sub trkbDrumNote_Leave(sender As Object, e As EventArgs) Handles trkbDrumNote.Leave
        If DrumNotePlaying < 128 Then
            DrumNoteOff(CByte(trkbDrumNote.Value))
        End If
        SpacebarPressed = False
    End Sub

#End Region

    Private Sub DrumNoteOn(DrumNote As Byte)
        If DrumNotePlaying < 128 Then
            DrumNoteOff(DrumNotePlaying)                        ' avoid hanging note            
        End If
        MidiOutShortMsg(hMidiOut, &H99, DrumNote, 100)
        DrumNotePlaying = DrumNote
    End Sub

    Private Sub DrumNoteOff(DrumNote As Byte)
        If DrumNotePlaying < 128 Then
            MidiOutShortMsg(hMidiOut, &H99, DrumNote, 0)
            DrumNotePlaying = 128
        End If
    End Sub

#Region "Play Drums on Keyboard"
    Private Sub btnDrumOnKeyboard_KeyDown(sender As Object, e As KeyEventArgs) Handles btnDrumOnKeyboard.KeyDown
        KbdDrumNoteOn(CByte(e.KeyCode))
    End Sub

    Private Sub btnDrumOnKeyboard_KeyUp(sender As Object, e As KeyEventArgs) Handles btnDrumOnKeyboard.KeyUp
        KbdDrumNoteOff(CByte(e.KeyCode))
    End Sub

    Private Sub btnDrumOnKeyboard_Leave(sender As Object, e As EventArgs) Handles btnDrumOnKeyboard.Leave
        KbdDrumNotes_AllNotesOff()                                  ' turn all notes off
    End Sub
#End Region

#End Region

#Region "SystemExclusive"

    Private Sub trkbVolume_ValueChanged(sender As Object, e As EventArgs) Handles trkbVolume.ValueChanged
        If ResettingVoiceOrVolume = False Then
            SetMainVolume(CByte(trkbVolume.Value))
        End If
        lblVolumeValue.Text = CStr(trkbVolume.Value)
    End Sub

    Private Sub SetMainVolume(volume As Byte)
        ' Master Volume for GM Instruments, Universal Real Time SysEx
        'F0 7F 7F 04 01 ll mm F7        ' ll = volume LSB, mm = volume MSB

        Dim MasterVolume_sysx As Byte() = {&HF0, &H7F, &H7F, &H4, &H1, &H0, &H64, &HF7}
        MasterVolume_sysx(6) = volume
        Dim ret As Integer
        ret = MIO.OutLongMsg(hMidiOut, MasterVolume_sysx)
        ShowHexBytes_Output(MasterVolume_sysx, ret)
    End Sub


    Private Sub btn_ID_Request_Click(sender As Object, e As EventArgs) Handles btn_ID_Request.Click
        Dim identity_request() As Byte = {&HF0, &H7E, 0, 6, 1, &HF7}
        Dim ret As Integer
        ret = MIO.OutLongMsg(hMidiOut, identity_request)                          ' send ID request
        ShowHexBytes_Output(identity_request, ret)
    End Sub

    Private Sub btnGmON_Click(sender As Object, e As EventArgs) Handles btnGmON.Click
        Dim gm_on() As Byte = {&HF0, &H7E, &H7F, 9, 1, &HF7}
        Dim ret As Integer
        ret = MIO.OutLongMsg(hMidiOut, gm_on)                          ' send ID request
        ShowHexBytes_Output(gm_on, ret)

        ' assuming GM-On resets voice and volume on the device, set the UI controls to this values
        ResettingVoiceOrVolume = True
        cmbVoiceName.SelectedIndex = 0                      ' To "Acoustic Grand Piano"
        trkbVolume.Value = 127                              ' volume to maximum
        ResettingVoiceOrVolume = False
    End Sub
    Private Sub btnEsBulkReqVc0_Click(sender As Object, e As EventArgs) Handles btnEsBulkReqVc0.Click
        Dim BulkReq_sysx As Byte() = {&HF0, &H43, &H20, &H7F, &H0, &HE, &H0, &H0, &HF7}
        Dim ret As Integer
        ret = MIO.OutLongMsg(hMidiOut, BulkReq_sysx)
        ShowHexBytes_Output(BulkReq_sysx, ret)
    End Sub

    Private Sub btnEsBulkReqDrum_Click(sender As Object, e As EventArgs) Handles btnEsBulkReqDrum.Click
        Dim BulkReq_sysx As Byte() = {&HF0, &H43, &H20, &H7F, &H0, &HE, &H28, &H0, &HF7}
        Dim ret As Integer
        ret = MIO.OutLongMsg(hMidiOut, BulkReq_sysx)
        ShowHexBytes_Output(BulkReq_sysx, ret)
    End Sub

    ' "(?=[Ff][0])([\da-fA-F]{2}[ ]{1})+?([Ff][7])"     ' old: no restriction for data bytes to 7 bit
    Private ReadOnly sysxRegexPattern As String = "[Ff][0][ ]([0-7][\da-fA-F]{1}[ ]{1})+?[Ff][7]"

    Private Sub tbSysxInput_TextChanged(sender As Object, e As EventArgs) Handles tbSysxInput.TextChanged
        Try
            Dim sysxRegex As Text.RegularExpressions.Regex
            sysxRegex = New Text.RegularExpressions.Regex(sysxRegexPattern)

            If sysxRegex.IsMatch(tbSysxInput.Text) Then
                btnSendSysx.Enabled = True
            Else
                btnSendSysx.Enabled = False
            End If
        Catch
        End Try
    End Sub

    Private Sub btnSendSysx_Click(sender As Object, e As EventArgs) Handles btnSendSysx.Click
        Try
            Dim sysxRegex As Text.RegularExpressions.Regex
            sysxRegex = New Text.RegularExpressions.Regex(sysxRegexPattern)

            Dim str As String
            str = sysxRegex.Match(tbSysxInput.Text).ToString()
            tbSysxInput.Text = str

            Dim arr As String() = str.Split(CChar(" "))
            Dim sysxMsg As Byte() = New Byte(arr.Length - 1) {}

            For i = 1 To arr.Length
                sysxMsg(i - 1) = Convert.ToByte(arr(i - 1), 16)
            Next

            '---
            Dim ret As Integer
            ret = MIO.OutLongMsg(hMidiOut, sysxMsg)
            ShowHexBytes_Output(sysxMsg, ret)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Send Sysx error")
        End Try
    End Sub
#End Region

#Region "Context Menu"

    Private Sub ctxMenuTbOut_clear_Click(sender As Object, e As EventArgs) Handles ctxMenuTbOut_clear.Click
        tbOutput.Clear()
        OutputMsgCounter = 1
    End Sub
    Private Sub ctxMenuTbIn_clear_Click(sender As Object, e As EventArgs) Handles ctxMenuTbIn_clear.Click
        tbInput.Clear()
        InputMsgCounter = 1
    End Sub
    Private Sub ctxMenuTbMsg_clear_Click(sender As Object, e As EventArgs) Handles ctxMenuTbMsg_clear.Click
        tbMessage.Clear()
        CallbackMsgCounter = 1
    End Sub

#End Region

    Private Sub cbShowTooltipHelp_CheckStateChanged(sender As Object, e As EventArgs) Handles cbShowTooltipHelp.CheckStateChanged
        ' let the user hide the ToolTip Help when it disturbs
        If cbShowTooltipHelp.Checked = True Then
            ToolTip1.Active = True
        Else
            ToolTip1.Active = False
        End If
    End Sub

    Private Sub btnRefreshPortList_Click(sender As Object, e As EventArgs) Handles btnRefreshPortList.Click

        '--- get the selected port names
        Dim output As String = CStr(cmbMidiOutPorts.SelectedItem)
        Dim input As String = CStr(cmbMidiInPorts.SelectedItem)
        Dim input2 As String = CStr(cmbMidiInPorts2.SelectedItem)

        MIO.RefreshPortList()                           ' closes all ports

        hMidiOut = 0
        hMidiIn = 0
        hMidiIn2 = 0

        cmbMidiOutPorts.Items.Clear()
        cmbMidiInPorts.Items.Clear()
        cmbMidiInPorts2.Items.Clear()

        For i = 1 To MIO.MidiOutPorts.Count
            If MIO.MidiOutPorts(i - 1).invalidPort = False Then                 'list only valid ports
                cmbMidiOutPorts.Items.Add(MIO.MidiOutPorts(i - 1).portName)
            End If
        Next

        For i = 1 To MIO.MidiInPorts.Count
            If MIO.MidiInPorts(i - 1).invalidPort = False Then                 'list only valid ports
                cmbMidiInPorts.Items.Add(MIO.MidiInPorts(i - 1).portName)
            End If
        Next

        For i = 1 To MIO.MidiInPorts.Count
            If MIO.MidiInPorts(i - 1).invalidPort = False Then                 'list only valid ports
                cmbMidiInPorts2.Items.Add(MIO.MidiInPorts(i - 1).portName)
            End If
        Next

        '--- try to re-select the ports, if available

        If output IsNot Nothing Then
            If cmbMidiOutPorts.Items.Contains(output) Then
                cmbMidiOutPorts.SelectedItem = output
            End If
        End If

        If input IsNot Nothing Then
            If cmbMidiInPorts.Items.Contains(input) Then
                cmbMidiInPorts.SelectedItem = input
            End If
        End If

        If input2 IsNot Nothing Then
            If cmbMidiInPorts2.Items.Contains(input2) Then
                cmbMidiInPorts2.SelectedItem = input2
            End If
        End If

    End Sub
End Class

