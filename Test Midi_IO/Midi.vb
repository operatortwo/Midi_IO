Imports Midi_IO.Midi_IO_Constants
Partial Public Class Form1

    Friend hMidiOut As UInteger
    Private hMidiIn As UInteger
    Private hMidiIn2 As UInteger

    Private CallbackMsgCounter As Integer = 1
    Private OutputMsgCounter As Integer = 1
    Private InputMsgCounter As Integer = 1

#Region "Output"

    Friend Sub MidiOutShortMsg(hmo As UInteger, status As Integer, data1 As Integer, data2 As Integer)
        Dim ret As Integer
        ret = MIO.OutShortMsg(hmo, status, data1, data2)
        ShowShortMsg_Output(status, data1, data2, ret)
    End Sub

    Private Sub ShowShortMsg_Output(status As Integer, data1 As Integer, data2 As Integer, ret As Integer)
        Dim buffer As Byte()
        ReDim buffer(2)
        buffer(0) = CByte(status)
        buffer(1) = CByte(data1)
        buffer(2) = CByte(data2)
        ShowHexBytes_Output(buffer, ret)
    End Sub

    Private Sub ShowHexBytes_Output(buffer As Byte(), ret As Integer)
        If tbInput.InvokeRequired = False Then
            Threadsave_ShowHexBytes_Output(buffer, ret)
        Else
            ' from Input2 (different Thread)
            tbInput.Invoke(New ShowHexBytes_Output_Delegate(AddressOf Threadsave_ShowHexBytes_Output), buffer, ret)
        End If
    End Sub

    Private Delegate Sub ShowHexBytes_Output_Delegate(buffer As Byte(), ret As Integer)
    Private Sub Threadsave_ShowHexBytes_Output(buffer As Byte(), ret As Integer)
        If tbOutput.Lines.Count > 1000 Then tbOutput.Clear()
        Dim str1 As String = CStr(OutputMsgCounter) & "...."
        Dim str2 As String
        str2 = BitConverter.ToString(buffer)
        str2 = str2.Replace("-", " ")
        If ret = MMSYSERR_NOERROR Then
            tbOutput.AppendText(str1 & str2 & vbCrLf)
        Else
            Dim str3 As String = decode_return_code(ret)
            tbOutput.AppendText(str1 & str2 & " --> ! " & str3 & vbCrLf)
        End If
        OutputMsgCounter += 1
    End Sub

    Private Function decode_return_code(ret As Integer) As String
        Select Case ret
            Case MMSYSERR_NOERROR
                Return "MMSYSERR_NOERROR"
            Case MMSYSERR_INVALHANDLE
                Return "MMSYSERR_INVALHANDLE" & " - " & Hex(hMidiOut)
            Case MMSYSERR_HANDLEBUSY
                Return "MMSYSERR_HANDLEBUSY"
            Case MIDIERR_UNPREPARED
                Return "MIDIERR_UNPREPARED"
            Case MMSYSERR_INVALPARAM
                Return "MMSYSERR_INVALPARAM"
            Case MIDIERR_BADOPENMODE
                Return "MIDIERR_BADOPENMODE"
            Case MIDIERR_NOTREADY
                Return "MIDIERR_NOTREADY"
            Case MIO_ERR_NoOutBufferAvailable
                Return "MIO_ERR_NoOutBufferAvailable"
            Case Else
                Return Hex(ret)
        End Select
    End Function

#End Region

#Region "Input"

    ''' <summary>
    ''' Handles MidiInData
    ''' </summary>
    ''' <param name="hmi">handle of the Input port</param>
    ''' <param name="dwInstance">user defined value (port number)</param>
    ''' <param name="status">first byte of the Midi-message</param>
    ''' <param name="data1">second byte of the Midi message</param>
    ''' <param name="data2">third byte of the Midi-Message</param>
    ''' <param name="dwTimestamp">milliseconds since call to MidiInStart</param>
    Private Sub MidiInData(hmi As UInteger, dwInstance As UInteger, status As Byte, data1 As Byte, data2 As Byte, dwTimestamp As UInteger) Handles MIO.MidiInData
        Dim buffer As Byte()
        ReDim buffer(2)
        buffer(0) = status
        buffer(1) = data1
        buffer(2) = data2

        If hmi = hMidiIn Then
            ShowHexBytes_Input(buffer)
        ElseIf hmi = hMidiIn2 Then
            If status <> &HF8 Then                                      ' filter timing-clock
                If status <> &HFE Then                                  ' filter active sensing                    
                    MidiOutShortMsg(hMidiOut, status, data1, data2)     ' send to output
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Handles MidiInLongdata
    ''' </summary>
    ''' <param name="hmi">handle of the Input port</param>
    ''' <param name="dwInstance">user defined value (port number)</param>
    ''' <param name="buffer"></param>
    ''' <param name="dwTimestamp">milliseconds since call to MidiInStart</param>
    Private Sub MidiInLongdata(hmi As UInteger, dwInstance As UInteger, buffer As Byte(), dwTimestamp As UInteger) Handles MIO.MidiInLongdata
        If hmi = hMidiIn Then
            ShowHexBytes_Input(buffer)
        ElseIf hmi = hMidiIn2 Then
            Dim ret As Integer
            ret = MIO.OutLongMsg(hMidiOut, buffer)
            ShowHexBytes_Output(buffer, ret)
        End If
    End Sub

    Private Sub ShowHexBytes_Input(buffer As Byte())
        If tbInput.InvokeRequired = False Then
            Threadsave_ShowHexBytes_Input(buffer)
        Else
            tbInput.Invoke(New ShowHexBytes_Input_Delegate(AddressOf Threadsave_ShowHexBytes_Input), buffer)
        End If
    End Sub

    Private Delegate Sub ShowHexBytes_Input_Delegate(buffer As Byte())
    Public Sub Threadsave_ShowHexBytes_Input(buffer As Byte())

        If tbInput.Lines.Count > 1000 Then
            tbInput.Clear()
        End If
        Dim str1 As String = CStr(InputMsgCounter) & "...."
        Dim str2 As String
        Dim strOut As String
        str2 = BitConverter.ToString(buffer)
        str2 = str2.Replace("-", " ")
        strOut = str1 & str2 & vbCrLf

        tbInput.AppendText(strOut)

        InputMsgCounter += 1

        '---
        ' can update other controls on this form

    End Sub

#End Region

#Region "Callback Messages"

    ''' <summary>
    ''' Handles the information messages sent to MidiOutProc
    ''' </summary>
    ''' <param name="hmo">handle of the Output port</param>
    ''' <param name="wMsg">message numbering constant</param>
    ''' <param name="dwInstance">user defined value (port number)</param>
    ''' <param name="dwParam1">not used</param>
    ''' <param name="dwParam2">not used</param>
    Private Sub MidiOutCallbackMsg(hmo As UInteger, wMsg As UInteger, dwInstance As UInteger, dwParam1 As UInteger, dwParam2 As UInteger) Handles MIO.MidiOutCallbackMsg
        Dim msg As String = CStr(CallbackMsgCounter)
        msg &= "    " & decode_msg(wMsg) & " - " & Hex(hmo) & " - " & Hex(dwInstance) & vbCrLf
        ShowCallbackMsg(msg)
    End Sub

    ''' <summary>
    ''' Handles the information messages sent to MidiInProc
    ''' </summary>
    ''' <param name="hmi">handle of the Input port</param>
    ''' <param name="wMsg">message numbering constant</param>
    ''' <param name="dwInstance">user defined value (port number)</param>
    ''' <param name="dwParam1">not used</param>
    ''' <param name="dwParam2">not used</param>
    Private Sub MidiInCallbackMsg(hmi As UInteger, wMsg As UInteger, dwInstance As UInteger, dwParam1 As UInteger, dwParam2 As UInteger) Handles MIO.MidiInCallbackMsg
        Dim msg As String = CStr(CallbackMsgCounter)
        msg &= "    " & decode_msg(wMsg) & " - " & Hex(hmi) & " - " & Hex(dwInstance) & vbCrLf
        ShowCallbackMsg(msg)
    End Sub

    Private Sub ShowCallbackMsg(msg As String)
        ' make Threadsave in case: output to device, respond from device, Input2 --> back to output
        If tbMessage.InvokeRequired = False Then
            Threadsave_ShowCallbackMsg(msg)                         ' normal way, no invoke required
        Else
            tbMessage.Invoke(New ShowCallbackMsg_Delegate(AddressOf Threadsave_ShowCallbackMsg), msg)
        End If
    End Sub

    Private Delegate Sub ShowCallbackMsg_Delegate(msg As String)

    Private Sub Threadsave_ShowCallbackMsg(msg As String)
        If tbMessage.Lines.Count > 1000 Then tbMessage.Clear()
        tbMessage.AppendText(msg)
        CallbackMsgCounter += 1
    End Sub

    Private Function decode_msg(msg As UInteger) As String
        Select Case msg
            Case &H3C1
                Return "MIM_OPEN"
            Case &H3C2
                Return "MIM_CLOSE"
            Case &H3C5
                Return "MIM_ERROR"
            Case &H3C7
                Return "MOM_OPEN"
            Case &H3C8
                Return "MOM_CLOSE"
            Case &H3C9
                Return "MOM_DONE"
            Case Else
                Return Hex(msg)
        End Select
    End Function
#End Region

End Class
