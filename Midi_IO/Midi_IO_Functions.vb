Imports System.Runtime.InteropServices
Imports Midi_IO.Midi_IO_Structures
Imports Midi_IO.Midi_IO_Constants
Partial Public Class Midi_IO

    Friend Declare Auto Function midiInGetNumDevs Lib "winmm.dll" () As Integer
    Friend Declare Auto Function midiOutGetNumDevs Lib "winmm.dll" () As Integer
    Friend Declare Auto Function midiOutGetDevCapsA Lib "winmm.dll" (uDeviceID As Integer, ByRef lpMidiOutCaps As MIDIOUTCAPS, cbMidiOutCaps As Integer) As Integer
    Friend Declare Auto Function midiInGetDevCapsA Lib "winmm.dll" (uDeviceID As Int32, ByRef lpMidiInCaps As MIDIINCAPS, cbMidiInCaps As Int32) As Integer

    Friend Declare Auto Function midiOutOpen Lib "winmm.dll" (ByRef lphmo As IntPtr, uDeviceID As Int32, dwCallback As MidiOut_Callback, dwCallbackInstance As IntPtr, dwFlags As UInt32) As Integer
    Friend Declare Auto Function midiOutReset Lib "winmm.dll" (hmo As IntPtr) As Integer
    Friend Declare Auto Function midiOutClose Lib "winmm.dll" (hmo As IntPtr) As Integer
    Friend Declare Auto Function midiOutShortMsg Lib "winmm.dll" (hmo As IntPtr, dwMsg As UInt32) As Integer
    Friend Declare Auto Function midiOutLongMsg Lib "winmm.dll" (hmo As IntPtr, lpMidiOutHdr As IntPtr, cbMidiOutHdr As Int32) As Integer
    Friend Declare Auto Function midiOutPrepareHeader Lib "winmm.dll" (hmo As IntPtr, lpMidiOutHdr As IntPtr, cbMidiOutHdr As Int32) As Integer

    Friend Declare Auto Function midiInOpen Lib "winmm.dll" (ByRef lphmi As IntPtr, uDeviceID As Int32, dwCallback As MidiIn_Callback, dwCallbackInstance As IntPtr, dwFlags As UInt32) As Integer
    Friend Declare Auto Function midiInStart Lib "winmm.dll" (hmi As IntPtr) As Integer
    Friend Declare Auto Function midiInStop Lib "winmm.dll" (hmi As IntPtr) As Integer
    Friend Declare Auto Function midiInReset Lib "winmm.dll" (hmi As IntPtr) As Integer
    Friend Declare Auto Function midiInClose Lib "winmm.dll" (hmi As IntPtr) As Integer

    Friend Declare Auto Function midiInPrepareHeader Lib "winmm.dll" (hmi As IntPtr, lpMidiInHdr As IntPtr, cbMidiInHdr As Int32) As Integer
    Friend Declare Auto Function midiInUnprepareHeader Lib "winmm.dll" (hmi As IntPtr, lpMidiInHdr As IntPtr, cbMidiInHdr As Int32) As Integer
    Friend Declare Auto Function midiInAddBuffer Lib "winmm.dll" (hmi As IntPtr, lpMidiInHdr As IntPtr, uSize As Int32) As Integer

    '--- Callbacks ---

    Friend Delegate Sub MidiIn_Callback(hmi As UInt32, wMsg As UInt32, dwInstance As UInt32, dwParam1 As UInt32, dwParam2 As UInt32)
    Friend fptrMidiInProc As New MidiIn_Callback(AddressOf MidiInProc)

    Friend Delegate Sub MidiOut_Callback(hmo As UInt32, wMsg As UInt32, dwInstance As UInt32, dwParam1 As UInt32, dwParam2 As UInt32)
    Friend fptrMidiOutProc As New MidiOut_Callback(AddressOf MidiOutProc)

    '--- Events ---

    ''' <summary>
    ''' messages about the state of a Midi-In Port
    ''' </summary>    
    Public Event MidiInCallbackMsg(hMidiIn As UInteger, wMsg As UInteger, dwInstance As UInteger, dwParam1 As UInteger, dwParam2 As UInteger)

    ''' <summary>
    ''' messages about the state of a Midi-Out Port
    ''' </summary>    
    Public Event MidiOutCallbackMsg(hMidiOut As UInteger, wMsg As UInteger, dwInstance As UInteger, dwParam1 As UInteger, dwParam2 As UInteger)

    ''' <summary>
    ''' Handles the MIM_DATA message.
    ''' </summary>    
    Public Event MidiInData(hMidiIn As UInteger, dwInstance As UInteger, status As Byte, data1 As Byte, data2 As Byte, dwTimestamp As UInteger)

    ''' <summary>
    ''' Handles the MIM_LONGDATA message in a modified manner. 
    ''' lpMidiHdr in dwParam1 is copied to a managed buffer as byte()
    ''' </summary>  
    Public Event MidiInLongdata(hMidiIn As UInteger, dwInstance As UInteger, buffer As Byte(), dwTimestamp As UInteger)


    Friend Sub MidiOutProc(hMidiOut As UInteger, wMsg As UInteger, dwInstance As UInteger, dwParam1 As UInteger, dwParam2 As UInteger)
        ' This is the CALLBACK routine for MIDI OUT

        Try

            Select Case wMsg

                Case MOM_OPEN
                    RaiseEvent MidiOutCallbackMsg(hMidiOut, wMsg, dwInstance, 0, 0)
                Case MOM_CLOSE
                    RaiseEvent MidiOutCallbackMsg(hMidiOut, wMsg, dwInstance, 0, 0)
                Case MOM_DONE
                    ' dwParam1 = Pointer to a MIDIHDR structure identifying the buffer.
                    ' dwInstance = User defined value to dfferentiate if more than one Output port is active

                    MhdrsOut(MhdrsOut_WritePos) = CType(dwParam1, IntPtr)     'insert mhdr_ptr back into circular-buffer

                    If MhdrsOut_WritePos = NumberOf_SYSX_OutBuffers - 1 Then
                        MhdrsOut_WritePos = 0
                    Else
                        MhdrsOut_WritePos += 1
                    End If
                    MhdrsOut_NumberOfFreeBuffers += 1

                    RaiseEvent MidiOutCallbackMsg(hMidiOut, wMsg, dwInstance, 0, 0)     ' hide dwParam1 from user

            End Select

        Catch ex As Exception
            'Console.WriteLine(ex.Message) ' for debug
        End Try

    End Sub

    Friend Sub MidiInProc(hMidiIn As UInteger, wMsg As UInteger, dwInstance As UInteger, dwParam1 As UInteger, dwParam2 As UInteger)
        ' This is the CALLBACK routine for MIDI IN

        Try

            Select Case wMsg
                Case MIM_OPEN
                    RaiseEvent MidiInCallbackMsg(hMidiIn, wMsg, dwInstance, 0, 0)
                Case MIM_CLOSE
                    RaiseEvent MidiInCallbackMsg(hMidiIn, wMsg, dwInstance, 0, 0)
                Case MIM_DATA
                    Dim status As Byte = CByte(dwParam1 And &HFF)
                    Dim data1 As Byte = CByte((dwParam1 >> 8) And &HFF)
                    Dim data2 As Byte = CByte((dwParam1 >> 16) And &HFF)

                    If status = &HF8 Then                   ' if timing-clock
                        If MidiIn_filter_TimingClock = True Then Exit Select
                    End If

                    If status = &HFE Then                   ' if active sensing
                        If MidiIn_filter_ActiveSense = True Then Exit Select
                    End If

                    RaiseEvent MidiInData(hMidiIn, dwInstance, status, data1, data2, dwParam2)

                Case MIM_LONGDATA

                    Dim ptr As IntPtr = CType(dwParam1, IntPtr)
                    Dim hdr As MIDIHDR = CType(Marshal.PtrToStructure(ptr, GetType(MIDIHDR)), MIDIHDR)

                    Dim ndx As Integer
                    ndx = findPortHandleIn(hMidiIn)
                    If ndx = -1 Then Exit Sub
                    If MidiInPorts(ndx).enable_Longdata = False Then Exit Sub      ' skip Longdata after midiInReset

                    Dim buffer As Byte() = {}               ' create buffer with length 0, avoid "Nothing"
                    getLongdataBytes(dwParam1, buffer)
                    If buffer.Length > 0 Then               ' skip empty buffers (in case of MidiInReset (Closing))
                        Try
                            RaiseEvent MidiInLongdata(hMidiIn, dwInstance, buffer, dwParam2)
                        Catch ex As Exception
                        End Try
                    End If

                    ' it is important to reuse/recycle buffer always, even if there was an exception in the 
                    ' MidiInLongdata event, so there is a Try..Catch around RaiseEvent MidiInLongdata

                    midiInAddBuffer(CType(hMidiIn, IntPtr), ptr, midihdr_size)   'reuse buffer

                '-----

                Case MIM_ERROR                                      'if invalid midi-message 
                    RaiseEvent MidiInCallbackMsg(hMidiIn, wMsg, dwInstance, 0, 0)
                Case MIM_LONGERROR                                  'if invalid or incomplete sysx message                
                    RaiseEvent MidiInCallbackMsg(hMidiIn, wMsg, dwInstance, 0, 0)
                Case MIM_MOREDATA                                   '(if MIDI_IO_STATUS set) processing is too slow                
                    RaiseEvent MidiInCallbackMsg(hMidiIn, wMsg, dwInstance, 0, 0)

            End Select

        Catch ex As Exception
            'Console.WriteLine(ex.Message) ' for debug
        End Try

    End Sub

    Private Function getLongdataBytes(dwParam1 As UInt32, ByRef RetBuffer As Byte()) As Boolean

        Dim ptr As IntPtr = CType(dwParam1, IntPtr)
        Dim hdr As MIDIHDR = CType(Marshal.PtrToStructure(ptr, GetType(MIDIHDR)), MIDIHDR)

        If hdr.dwBytesRecorded = 0 Then Return False

        ReDim RetBuffer(CInt(hdr.dwBytesRecorded - 1))

        Marshal.Copy(hdr.lpData, RetBuffer, 0, CInt(hdr.dwBytesRecorded))

        Return True
    End Function

End Class
