Public Class Form1

    Private WithEvents MIO As New Midi_IO.Midi_IO
    Private hMidiOut As UInteger

    Private NoteToPlay As Byte = 50

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbMidiOutPorts.Items.Clear()
        For i = 1 To MIO.MidiOutPorts.Count
            If MIO.MidiOutPorts(i - 1).invalidPort = False Then          'list only valid ports
                cmbMidiOutPorts.Items.Add(MIO.MidiOutPorts(i - 1).portName)
            End If
        Next
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MIO._End()                      ' close all ports, free memory
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
        End If
    End Sub

    Private Sub btnNote_KeyDown(sender As Object, e As KeyEventArgs) Handles btnNote.KeyDown
        NoteOn(NoteToPlay)
    End Sub

    Private Sub btnNote_KeyUp(sender As Object, e As KeyEventArgs) Handles btnNote.KeyUp
        NoteOff(NoteToPlay)
    End Sub

    Private Sub btnNote_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNote.MouseDown
        NoteOn(NoteToPlay)
    End Sub

    Private Sub btnNote_MouseUp(sender As Object, e As MouseEventArgs) Handles btnNote.MouseUp
        NoteOff(NoteToPlay)
    End Sub

    Private Sub NoteOn(NoteNumber As Byte)
        MIO.OutShortMsg(hMidiOut, &H90, NoteNumber, 100)    ' NoteOn OR Channel, Note Number, Velocity
    End Sub

    Private Sub NoteOff(NoteNumber As Byte)
        MIO.OutShortMsg(hMidiOut, &H90, NoteNumber, 0)      ' NoteOn OR Channel, Note Number, Velocity (0 = NoteOff)
    End Sub

End Class
