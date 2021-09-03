Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Midi_IO.Midi_IO_Constants
Imports Midi_IO.Midi_IO_Structures

Public Class Midi_IO
    Implements IDisposable

    ''' <summary>
    ''' Midi_IO_System state
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property IsRunning As Boolean               ' if true: memory for output is allocated

    ''' <summary>
    ''' Set to FALSE to receive TimingClock
    ''' </summary>
    ''' <returns></returns>
    Public Property MidiIn_filter_TimingClock As Boolean = True ' for MidiInProc  Real-time message F8
    '                                                           ' 24 times per quarter note
    ''' <summary>
    ''' Set to FALSE to receive ActiveSense
    ''' </summary>
    ''' <returns></returns>
    Public Property MidiIn_filter_ActiveSense As Boolean = True ' for MidiInProc  Real-time message FE
    '                                                           ' every 300 milliseconds

    Public last_error_msg As String = "ok"
    Public last_error As Integer = MMSYSERR_NOERROR

    Public ReadOnly MidiOutPorts As New List(Of MidiOutPort)     ' list of MidiOutPorts
    Public ReadOnly MidiInPorts As New List(Of MidiInPort)       ' list of MidiInPorts

    Private NumberOfMidiInPorts As Integer   '  from midiInGetNumDevs
    Private NumberOfMidiOutPorts As Integer  '  from midiOutGetNumDevs() 


    '-------- Output --------
    '---- sysx_out-buffers, shared with all Output-Ports

    Const NumberOf_SYSX_OutBuffers = 64         'SysxOutBuffers <--> MidiHdrOutBuffers (default=64)
    '                                           ' (1 MIDIHDR for each sysx-buffer)
    Const SIZE_OF_1_SYSX_OUT_BUFFER = 256       'bytes

    Const MIDI_OUT_BUFFER_SIZE = NumberOf_SYSX_OutBuffers * SIZE_OF_1_SYSX_OUT_BUFFER

    ReadOnly auxMhdr As MIDIHDR                              ' aux for sizeof, used for Input AND Output
    ReadOnly midihdr_size As Integer = Marshal.SizeOf(auxMhdr)
    ReadOnly midihdr_out_buffer_size As Integer = midihdr_size * NumberOf_SYSX_OutBuffers

    Private midihdr_out_buffer As IntPtr = Marshal.AllocHGlobal(midihdr_out_buffer_size)
    Private sysx_out_buffer As IntPtr = Marshal.AllocHGlobal(MIDI_OUT_BUFFER_SIZE)

    '---- circular buffer für lpMidiOutHdr(->ptr to sysxOutBuffer)

    Const SYSX_Out_MaxBufferNumber = NumberOf_SYSX_OutBuffers - 1

    Private ReadOnly MhdrsOut(NumberOf_SYSX_OutBuffers - 1) As IntPtr      'array of pointers to MIDIHDRS in midihdr_out_buffer
    Private MhdrsOut_ReadPos As Integer             'read position (0-63)   index, next free Mhdr-ptr
    Private MhdrsOut_WritePos As Integer            'write position (0-63)  index, where to store next returned Mhdr-ptr
    Private MhdrsOut_NumberOfFreeBuffers As Integer     'if 0 = all buffers in use (should not happen)


    '-------- Input --------
    '---- buffer for incoming MIDI-Mesages

    Private Const MidiIn_NumberOfMessages = 512
    Private Const MIDI_IN_MAX_MESSAGE_NR = MidiIn_NumberOfMessages - 1
    Private midi_in_buffer(MidiIn_NumberOfMessages) As MidiInMessage
    Private midi_in_read_ptr As Integer                              'msg-nr (0-511)
    Private midi_in_write_ptr As Integer                             'msg-nr (0-511)

    Private NumberOf_BufferFullEvents As Integer = 0                'for debug

    Private Structure MidiInMessage
        Dim wMsg As UInteger
        Dim dwInstance As UInt32
        Dim dwParam1 As UInt32
        Dim dwParam2 As UInt32
    End Structure

    '---- for sysx-in, each Input-Port has his own buffers 

    Const NumberOf_SYSX_IN_Buffers = 64        'SysxInBuffers <--> MidiHdrInBuffers (default=64)
    '                                       ' (1 MIDIHDR for each sysx-buffer)
    Const SIZE_OF_1_SYSX_IN_BUFFER = 256    'bytes
    Const MIDI_IN_BUFFER_SIZE = NumberOf_SYSX_IN_Buffers * SIZE_OF_1_SYSX_IN_BUFFER

    'ReadOnly midihdr_size As Integer = Marshal.SizeOf(auxMhdr)     'already defined for Output
    '                                                               'same Structure for Output and Input
    ReadOnly midihdr_in_buffer_size As Integer = midihdr_size * NumberOf_SYSX_IN_Buffers

    '------------------

    Public Sub New()

        Try
            Dim sp As New Security.Permissions.SecurityPermission(Security.Permissions.SecurityPermissionFlag.UnmanagedCode)
            sp.Demand()             ' exception if no permission to call unmanaged code
        Catch e As Exception
            MessageBox.Show(e.Message, "Midi_IO initialize error")
        End Try

        _Start()

    End Sub


    ''' <summary>
    '''  start the Midi_IO system
    '''   Returns FALSE if already started
    ''' </summary>
    ''' <returns></returns>
    Public Function _Start() As Boolean
        If IsRunning = True Then          'if already running
            Return False
        End If

        create_port_list()

        init_sysx_out_buffers()             'mhdr-buffer, sysx_out-buffer, MhdrsOut-Array

        _IsRunning = True                  'set running-flag
        Return True
    End Function

    ''' <summary>
    ''' stop the Midi_IO system.
    '''  Returns FALSE if already stopped
    ''' </summary>    
    Public Function _End() As Boolean

        If IsRunning = False Then          'if already stopped
            Return False
        End If

        DisposeManagedResources()
        DisposeUnmanagedResources()

        _IsRunning = False                  'clear running-flag
        Return True

    End Function

    Private Sub DisposeManagedResources()
        Dim hnd As UInteger

        '---- close all MidiInPorts

        For i = 1 To MidiInPorts.Count
            hnd = MidiInPorts(i - 1).hMidiIn
            CloseMidiInPort(hnd)
        Next

        '---- close all MidiOutPorts

        For i = 1 To MidiOutPorts.Count
            hnd = MidiOutPorts(i - 1).hMidiOut
            CloseMidiOutPort(hnd)
        Next

        '---- 

        'MidiInTracks.Clear()                'clear generic List's
        'MidiOutTracks.Clear()
    End Sub

    Private Sub DisposeUnmanagedResources()

        If midihdr_out_buffer <> IntPtr.Zero Then
            Marshal.FreeHGlobal(midihdr_out_buffer)
            midihdr_out_buffer = IntPtr.Zero
        End If

        If sysx_out_buffer <> IntPtr.Zero Then
            Marshal.FreeHGlobal(sysx_out_buffer)
            sysx_out_buffer = IntPtr.Zero
        End If

        '--- when Midi_IO was not finished with _end (which closes all MidiInPorts) then Free Memory here

        For i = 1 To MidiInPorts.Count
            If MidiInPorts(i - 1).pMidihdr_in_buffer <> IntPtr.Zero Then
                Marshal.FreeHGlobal(MidiInPorts(i - 1).pMidihdr_in_buffer)
                MidiInPorts(i - 1).pMidihdr_in_buffer = IntPtr.Zero
            End If
        Next

        For i = 1 To MidiInPorts.Count
            If MidiInPorts(i - 1).pSysx_in_buffer <> IntPtr.Zero Then
                Marshal.FreeHGlobal(MidiInPorts(i - 1).pSysx_in_buffer)
                MidiInPorts(i - 1).pSysx_in_buffer = IntPtr.Zero
            End If
        Next

    End Sub

    ''' <summary>
    ''' Closes all In- and Output Ports.
    ''' Updates the list of In- and Output Ports.
    ''' Useful if a device was connected or disconnected
    ''' </summary>
    Public Sub RefreshPortList()

        For Each port In MidiOutPorts
            If port.hMidiOut <> 0 Then
                CloseMidiOutPort(port.hMidiOut)
            End If
        Next

        For Each port In MidiInPorts
            If port.hMidiIn <> 0 Then
                CloseMidiInPort(port.hMidiIn)
            End If
        Next

        create_port_list()
    End Sub

    Private Sub create_port_list()

        NumberOfMidiInPorts = midiInGetNumDevs()
        NumberOfMidiOutPorts = midiOutGetNumDevs()

        MidiInPorts.Clear()                                 ' for repeated calls
        MidiOutPorts.Clear()                                ' for repeated calls

        'create port list

        Dim icaps As New MIDIINCAPS
        Dim ret_value As Integer

        '--- IN Ports
        For i = 0 To NumberOfMidiInPorts - 1
            MidiInPorts.Add(New MidiInPort)                 ' create new entry

            ret_value = midiInGetDevCapsA(i, icaps, Marshal.SizeOf(icaps))
            If Not ret_value = MMSYSERR_NOERROR Then        ' if invalid port
                MidiInPorts(i).invalidPort = True
            End If
            MidiInPorts(i).portName = icaps.szPname
            MidiInPorts(i).portNum = i
        Next

        '--- OUT Ports
        Dim ocaps As New MIDIOUTCAPS

        For i = 0 To NumberOfMidiOutPorts - 1
            MidiOutPorts.Add(New MidiOutPort)                 ' create new entry

            ret_value = midiOutGetDevCapsA(i, ocaps, Marshal.SizeOf(ocaps))
            If Not ret_value = MMSYSERR_NOERROR Then      'if invalid port
                MidiOutPorts(i).invalidPort = True
            End If
            MidiOutPorts(i).portName = ocaps.szPname
            MidiOutPorts(i).portNum = i
        Next

    End Sub

    Private Sub init_sysx_out_buffers()         'prepare circular buffer mhdr -> data-buffer

        Dim mh As MIDIHDR

        Dim mhdr_ptr As IntPtr = midihdr_out_buffer     'points to start of buffer
        Dim sysx_ptr As IntPtr = sysx_out_buffer        'points to start of buffer

        'setup all midihdrs, each midihdr points to his sysx-buffer
        '   also fill the circular buffer with the mhdr_ptr's

        For i = 1 To NumberOf_SYSX_OutBuffers

            mh.lpData = sysx_ptr                            'let .lpData pointing to corresponding sysx_buffer
            mh.dwBufferLength = SIZE_OF_1_SYSX_OUT_BUFFER   'set len
            mh.dwFlags = 0                                  'must be set to 0

            Marshal.StructureToPtr(mh, mhdr_ptr, False)     'copy MIDIHDR to midihdr_out_buffer

            MhdrsOut(i - 1) = mhdr_ptr                      'insert mhdr_ptr into circular-buffer

            sysx_ptr += SIZE_OF_1_SYSX_OUT_BUFFER           'to next sysx_out_buffer
            mhdr_ptr += midihdr_size                        'to next midihdr_out
        Next

        MhdrsOut_ReadPos = 0                                'init read position (in circular-buffer)
        MhdrsOut_WritePos = 0                               'init write position (in circular-buffer)
        MhdrsOut_NumberOfFreeBuffers = NumberOf_SYSX_OutBuffers   'init free-buffer-counter

    End Sub


#Region "Midi Output"
    Public Function OpenMidiOutPort(portName As String, ByRef hndRet As UInteger, dwInstance As Integer) As Boolean

        If IsRunning = False Then
            last_error_msg = "Midi IO System is not running"
            Return False
        End If

        If portName = Nothing Then
            last_error_msg = "empty port name"
            Return False
        End If

        Dim portNr As Integer

        portNr = get_PortNumberOut(portName)
        If portNr = MIO_ERR_NOTFOUND Then
            last_error = MIO_ERR_NOTFOUND
            last_error_msg = "port not found"
            Return False
        End If

        If MidiOutPorts(portNr).running = True Then            'if not already open
            hndRet = MidiOutPorts(portNr).hMidiOut
            Return True
        Else

            MidiOutPorts(portNr).dwInstance = dwInstance              'set value for instance            

            Dim ret As Integer
            ret = fMidiOutOpen(MidiOutPorts(portNr).hMidiOut, portNr)   'set .hMidiOut 
            If Not ret = MMSYSERR_NOERROR Then
                last_error = ret
                last_error_msg = "error OpenMidiOut"
                Return False
            End If

            hndRet = MidiOutPorts(portNr).hMidiOut
            MidiOutPorts(portNr).running = True
        End If

        Return True
    End Function

    Private Function fMidiOutOpen(ByRef lphmo As UInteger, ndx As Integer) As Integer
        With MidiOutPorts(ndx)
            Dim ret As Integer
            Dim IntPtr1 As IntPtr
            ret = midiOutOpen(IntPtr1, .portNum, fptrMidiOutProc, CType(.dwInstance, IntPtr), CALLBACK_FUNCTION)
            lphmo = CUInt(IntPtr1)
            Return ret
        End With
    End Function

    Public Sub CloseMidiOutPort(hMidiOut As UInteger)

        If hMidiOut = 0 Then Exit Sub

        Dim ndx As Integer
        ndx = findPortHandleOut(hMidiOut)

        If ndx = -1 Then Exit Sub

        midiOutReset(CType(MidiOutPorts(ndx).hMidiOut, IntPtr))
        midiOutClose(CType(MidiOutPorts(ndx).hMidiOut, IntPtr))                      'close port

        MidiOutPorts(ndx).hMidiOut = 0
        MidiOutPorts(ndx).running = False

    End Sub

    Private Function findPortHandleOut(hMidiOut As UInteger) As Integer

        For i = 1 To MidiOutPorts.Count
            If MidiOutPorts(i - 1).hMidiOut = hMidiOut Then
                Return i - 1
            End If
        Next

        Return -1
    End Function

    Private Function get_PortNumberOut(portName As String) As Integer

        For i = 1 To MidiOutPorts.Count
            If MidiOutPorts(i - 1).portName = portName Then
                If MidiOutPorts(i - 1).invalidPort = False Then         'skip invalid ports
                    Return MidiOutPorts(i - 1).portNum                  'return port number
                End If
            End If
        Next

        Return MIO_ERR_NOTFOUND
    End Function

    Public Function OutShortMsg(hmidiOut As UInteger, status As Integer, channel As Integer, data1 As Integer, data2 As Integer) As Integer
        ' separated input of status and channel 

        Dim msg As UInteger

        status = status And &HF0                        'mask high nibble
        channel = channel And &HF                       'mask low nibble

        data2 <<= 16
        data1 <<= 8

        msg = CUInt(status Or channel Or data1 Or data2)

        Return midiOutShortMsg(CType(hmidiOut, IntPtr), msg)    'empty,data2,data1,status/channel
    End Function

    Public Function OutShortMsg(hMidiOut As UInteger, status As Integer, data1 As Integer, data2 As Integer) As Integer
        ' combined input of status and channel (as in SMF)

        Dim msg As UInteger

        data2 <<= 16
        data1 <<= 8

        msg = CUInt(status Or data1 Or data2)

        Return midiOutShortMsg(CType(hMidiOut, IntPtr), msg)    'empty,data2,data1,status/channel
    End Function

    Public Function OutLongMsg(hMidiOut As UInteger, src As Byte()) As Integer

        ' check input
        If src Is Nothing Then Return 1                             'source is nothing
        If src.Length = 0 Then Return 2                             'source is empty
        If src.Length > SIZE_OF_1_SYSX_OUT_BUFFER Then Return 3     'source is too big
        ' split to multiple sysx-buffers ?

        If hMidiOut = 0 Then Return MMSYSERR_INVALHANDLE            'port is not open, 0 is invalid handle

        If MhdrsOut_NumberOfFreeBuffers = 0 Then Return MIO_ERR_NoOutBufferAvailable    'no buffer is available

        ' get Mhdr and copy sysx_data
        Dim mh As MIDIHDR
        Dim mhdr_ptr As IntPtr = midihdr_out_buffer                 'to start of buffer
        Dim sysx_ptr As IntPtr

        mhdr_ptr += MhdrsOut_ReadPos * midihdr_size
        mh = CType(Marshal.PtrToStructure(mhdr_ptr, GetType(MIDIHDR)), MIDIHDR)     'get MHDR
        sysx_ptr = mh.lpData                                                        'get sysx-ptr

        Marshal.Copy(src, 0, sysx_ptr, src.Length)                  'copy data to sysx-buffer

        ' needed (prevent midi-errors in destination port)
        mh.dwBufferLength = CUInt(src.Length)                       'used bytes (not max. size)
        Marshal.StructureToPtr(mh, mhdr_ptr, False)                 'write buffer back (with new Length)

        ' prepare Header
        Dim ret As Integer                                          'return value
        Dim mho As IntPtr = CType(hMidiOut, IntPtr)
        ret = midiOutPrepareHeader(mho, mhdr_ptr, midihdr_size)
        If ret <> MMSYSERR_NOERROR Then Return ret

        ' output message
        ret = midiOutLongMsg(mho, mhdr_ptr, midihdr_size)
        If ret <> MMSYSERR_NOERROR Then Return ret

        ' set pointer to next mhdr
        If MhdrsOut_ReadPos = NumberOf_SYSX_OutBuffers - 1 Then
            MhdrsOut_ReadPos = 0
        Else
            MhdrsOut_ReadPos += 1
        End If

        MhdrsOut_NumberOfFreeBuffers -= 1

        Return ret
    End Function

#End Region

#Region "Midi Input"

    Public Function OpenMidiInPort(portName As String, ByRef hndRet As UInteger, dwInstance As Integer) As Boolean

        If IsRunning = False Then
            last_error_msg = "Midi IO System is not running"
            Return False
        End If

        If portName = Nothing Then
            last_error_msg = "empty port name"
            Return False
        End If

        Dim portNr As Integer

        portNr = get_PortNumberIn(portName)
        If portNr = MIO_ERR_NOTFOUND Then
            last_error = MIO_ERR_NOTFOUND
            last_error_msg = "port not found"
            Return False
        End If

        If MidiInPorts(portNr).running = True Then            'if not already open
            hndRet = MidiInPorts(portNr).hMidiIn
            Return True
        Else

            MidiInPorts(portNr).dwInstance = dwInstance              'set value for instance            

            Dim ret As Integer
            ret = fMidiInOpen(MidiInPorts(portNr).hMidiIn, portNr)   'set .hMidiIn
            If Not ret = MMSYSERR_NOERROR Then
                last_error = ret
                last_error_msg = "error OpenMidiIn"
                Return False
            End If

            hndRet = MidiInPorts(portNr).hMidiIn

            prepare_sysx_in(portNr)                                     'all midihdrs and sysx_in buffers
            midiInStart(CType(MidiInPorts(portNr).hMidiIn, IntPtr))     'start recording (timestamp = 0)
            MidiInPorts(portNr).enable_Longdata = True                     'process MIM_LONGDATA
            MidiInPorts(portNr).running = True

            Return True
        End If

    End Function

    Private Function fMidiInOpen(ByRef lphmi As UInteger, ndx As Integer) As Integer
        With MidiInPorts(ndx)
            Dim ret As Integer
            Dim IntPtr1 As IntPtr
            ret = midiInOpen(IntPtr1, .portNum, fptrMidiInProc, CType(.dwInstance, IntPtr), CALLBACK_FUNCTION)
            lphmi = CUInt(IntPtr1)
            Return ret
        End With
    End Function

    Public Sub CloseMidiInPort(hMidiIn As UInteger)

        If hMidiIn = 0 Then Exit Sub

        Dim ndx As Integer
        ndx = findPortHandleIn(hMidiIn)

        If ndx = -1 Then Exit Sub


        midiInStop(CType(hMidiIn, IntPtr))

        MidiInPorts(ndx).enable_Longdata = False               'don't process MIM_LONGDATA anymore

        midiInReset(CType(MidiInPorts(ndx).hMidiIn, IntPtr))    'return all buffers (-> MIM_LONGDATA)

        unprepare_sysx_in(ndx)                              'all midihdrs and sysx_in buffers

        midiInClose(CType(MidiInPorts(ndx).hMidiIn, IntPtr))                      'close port


        MidiInPorts(ndx).hMidiIn = 0
        MidiInPorts(ndx).running = False

    End Sub

    Private Function findPortHandleIn(hMidiIn As UInteger) As Integer

        For i = 1 To MidiInPorts.Count
            If MidiInPorts(i - 1).hMidiIn = hMidiIn Then
                Return i - 1
            End If
        Next

        Return -1
    End Function

    Private Function get_PortNumberIn(portName As String) As Integer

        For i = 1 To MidiInPorts.Count
            If MidiInPorts(i - 1).portName = portName Then
                If MidiInPorts(i - 1).invalidPort = False Then          'skip invalid ports
                    Return MidiInPorts(i - 1).portNum                   'return port number
                End If
            End If
        Next

        Return MIO_ERR_NOTFOUND
    End Function

    Private Function prepare_sysx_in(ndx As Integer) As Boolean
        'called from mio_OpenMidiInPort
        Dim stat As Integer
        Dim mh As MIDIHDR

        Dim midihdr_ptr As IntPtr
        Dim sysx_ptr As IntPtr

        '--- alloc mem for mhdrs ---

        midihdr_ptr = Marshal.AllocHGlobal(midihdr_in_buffer_size)
        MidiInPorts(ndx).pMidihdr_in_buffer = midihdr_ptr           'ptr to start of mhdr-buffer

        '--- alloc mem for sysx-buffers ---

        sysx_ptr = Marshal.AllocHGlobal(MIDI_IN_BUFFER_SIZE)
        MidiInPorts(ndx).pSysx_in_buffer = sysx_ptr                 'ptr to start of sysx-buffer

        '--- prepare all midihdrs ---

        For i = 1 To NumberOf_SYSX_IN_Buffers

            mh.lpData = sysx_ptr
            mh.dwBufferLength = SIZE_OF_1_SYSX_IN_BUFFER
            mh.dwFlags = 0
            mh.dwUser = CUInt(MidiInPorts(ndx).dwInstance)            ' = port_nr (index)

            Marshal.StructureToPtr(mh, midihdr_ptr, False)              ' copy MIDIHDR to buffer

            stat = midiInPrepareHeader(CType(MidiInPorts(ndx).hMidiIn, IntPtr), midihdr_ptr, midihdr_size)
            'mh = CType(Marshal.PtrToStructure(midihdr_ptr, GetType(MIDIHDR)), MIDIHDR)  'xx debug
            stat = midiInAddBuffer(CType(MidiInPorts(ndx).hMidiIn, IntPtr), midihdr_ptr, midihdr_size)
            'mh = CType(Marshal.PtrToStructure(midihdr_ptr, GetType(MIDIHDR)), MIDIHDR)  'xx debug

            sysx_ptr += SIZE_OF_1_SYSX_IN_BUFFER
            midihdr_ptr += midihdr_size
        Next i

        Return True
    End Function

    Private Function unprepare_sysx_in(ndx As Integer) As Boolean
        'called from mio_CloseMidiInPort

        '--- unprepare all headers ---

        Dim stat As Integer
        Dim midihdr_ptr As IntPtr = MidiInPorts(ndx).pMidihdr_in_buffer

        For i = 1 To NumberOf_SYSX_IN_Buffers
            stat = midiInUnprepareHeader(CType(MidiInPorts(ndx).hMidiIn, IntPtr), midihdr_ptr, midihdr_size)
            midihdr_ptr += midihdr_size
        Next

        '--- free mem ---

        Marshal.FreeHGlobal(MidiInPorts(ndx).pMidihdr_in_buffer)    'free header mem
        Marshal.FreeHGlobal(MidiInPorts(ndx).pSysx_in_buffer)       'free header mem

        MidiInPorts(ndx).pMidihdr_in_buffer = Nothing               'invalidate ptr
        MidiInPorts(ndx).pSysx_in_buffer = Nothing                  'invalidate ptr

        Return True
    End Function


#End Region

#Region "Dispose"
    ' The remarks were taken from an example for the IDisposable Interface in the documentation

    ' Track whether Dispose has been called
    Private disposed As Boolean = False

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        ' This object will be cleaned up by the Dispose method.
        ' Therefore, you should call GC.SupressFinalize to
        ' take this object off the finalization queue
        ' and prevent finalization code for this object
        ' from executing a second time.
        GC.SuppressFinalize(Me)

    End Sub

    ' Dispose(bool disposing) executes in two distinct scenarios.
    ' If disposing equals true, the method has been called directly
    ' or indirectly by a user's code. Managed and unmanaged resources
    ' can be disposed.
    ' If disposing equals false, the method has been called by the
    ' runtime from inside the finalizer and you should not reference
    ' other objects. Only unmanaged resources can be disposed.
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposed Then

            If disposing = True Then
                ' dispose managed resources here
                DisposeManagedResources()
            End If
            ' dispose unmanaged resources here
            DisposeUnmanagedResources()

            disposed = True

        End If

    End Sub

    ' This finalizer will run only if the Dispose method
    ' does not get called.
    ' It gives your base class the opportunity to finalize.
    ' Do not provide finalize methods in types derived from this class.
    Protected Overrides Sub Finalize()
        Try
            ' Do not re-create Dispose clean-up code here.
            ' Calling Dispose(false) is optimal in terms of
            ' readability and maintainability.
            Dispose(False)
        Finally
            MyBase.Finalize()
        End Try

    End Sub

#End Region


End Class
