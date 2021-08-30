Imports System.Runtime.InteropServices
Imports Midi_IO.Midi_IO_Constants
Public Class Midi_IO_Structures

    <StructLayout(LayoutKind.Sequential, Pack:=1, CharSet:=CharSet.Ansi)>
    Structure MIDIOUTCAPS
        Dim wMid As UInt16
        Dim wPid As UInt16
        Dim vDriverVersion As UInt32
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAXPNAMELEN)> Dim szPname As String
        Dim wTechnology As UInt16
        Dim wVoices As UInt16
        Dim wNotes As UInt16
        Dim wChannelMask As Int16
        Dim dwSupport As UInt32
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1, CharSet:=CharSet.Ansi)>
    Structure MIDIINCAPS
        Dim wMid As UInt16
        Dim wPid As UInt16
        Dim vDriverVersion As UInt32
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAXPNAMELEN)> Dim szPname As String
        Dim dwSupport As UInt32
    End Structure

    Structure MIDISHORTMSG
        Dim empty As Byte
        Dim data2 As Byte
        Dim data1 As Byte
        Dim Status As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1, CharSet:=CharSet.Ansi)>
    Structure MIDIHDR
        Dim lpData As IntPtr                'pointer to locked data block
        Dim dwBufferLength As UInt32        'length of data in data block
        Dim dwBytesRecorded As UInt32       'used for input only
        Dim dwUser As UInt32                'for client's use
        Dim dwFlags As UInt32               'assorted flags (see defines)
        Dim lpNext As UInt32                'reserved for driver
        Dim reserved As UInt32              'reserved for driver
        Dim dwOffset As UInt32              'Callback offset into buffer
        Dim dwReserved1 As UInt32           'Reserved for MMSYSTEM (8)
        Dim dwReserved2 As UInt32
        Dim dwReserved3 As UInt32
        Dim dwReserved4 As UInt32
        Dim dwReserved5 As UInt32           ' 4 Dwords reserved in Documentation, 8 Dwords in SDK header
        Dim dwReserved6 As UInt32
        Dim dwReserved7 As UInt32
        Dim dwReserved8 As UInt32
    End Structure

    Public Class MidiInPort
        Public portName As String                   ' from mio_OpenMidiInPort
        Public portNum As Integer                   ' for MidiInOpen
        Public invalidPort As Boolean               ' if midiInGetDevCapsA returns error
        Public dwInstance As Integer                ' user define value
        Public hMidiIn As UInteger                  ' received from MidiInOpen
        Public running As Boolean                   ' status of port
        Public enable_Longdata As Boolean           ' status of sysx-part of port        
        Friend pMidihdr_in_buffer As IntPtr         'ptr to unmanaged memory
        Friend pSysx_in_buffer As IntPtr            'ptr to unmanaged memory
    End Class

    Public Class MidiOutPort
        Public portName As String                   ' from mio_OpenMidiOutPort
        Public portNum As Integer                   ' for MidiOutOpen (port identifier)
        Public invalidPort As Boolean               ' if midiOutGetDevCapsA returns error
        Public dwInstance As Integer                ' user defined value
        Public hMidiOut As UInteger                 ' received from MidiOutOpen
        Public running As Boolean                   ' status              
    End Class

End Class