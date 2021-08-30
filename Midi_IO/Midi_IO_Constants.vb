Public Class Midi_IO_Constants
    '-------- MIDI --------

    'MMSYSERR_BASE                        equ 0
    Public Const MMSYSERR_NOERROR = 0
    Public Const MMSYSERR_ERROR = 1
    Public Const MMSYSERR_BADDEVICEID = 2
    Public Const MMSYSERR_NOTENABLED = 3
    Public Const MMSYSERR_ALLOCATED = 4
    Public Const MMSYSERR_INVALHANDLE = 5
    Public Const MMSYSERR_NODRIVER = 6
    Public Const MMSYSERR_NOMEM = 7
    Public Const MMSYSERR_NOTSUPPORTED = 8
    Public Const MMSYSERR_BADERRNUM = 9
    Public Const MMSYSERR_INVALFLAG = 10
    Public Const MMSYSERR_INVALPARAM = 11
    Public Const MMSYSERR_HANDLEBUSY = 12
    Public Const MMSYSERR_INVALIDALIAS = 13
    Public Const MMSYSERR_LASTERROR = 13  '(13)
    Public Const MMSYSERR_BADDB = 14
    Public Const MMSYSERR_KEYNOTFOUND = 15
    Public Const MMSYSERR_READERROR = 16
    Public Const MMSYSERR_WRITEERROR = 17
    Public Const MMSYSERR_DELETEERROR = 18
    Public Const MMSYSERR_VALNOTFOUND = 19
    Public Const MMSYSERR_NODRIVERCB = 20

    'MIDIERR_BASE equ 64
    Public Const MIDIERR_UNPREPARED = 64   'header not prepared
    Public Const MIDIERR_STILLPLAYING = 65 'still something playing
    Public Const MIDIERR_NOMAP = 66        'no configured instruments
    Public Const MIDIERR_NOTREADY = 67     'hardware is still busy
    Public Const MIDIERR_NODEVICE = 68     'port no longer connected
    Public Const MIDIERR_INVALIDSETUP = 69 'invalid MIF
    Public Const MIDIERR_BADOPENMODE = 70  'operation unsupported w/ open mode
    Public Const MIDIERR_DONT_CONTINUE = 71 'thru device 'eating' a message
    Public Const MIDIERR_LASTERROR = 71     'last error in range



    ' wTechnology
    Public Const MOD_MIDIPORT = 1
    Public Const MOD_SYNTH = 2
    Public Const MOD_SQSYNTH = 3
    Public Const MOD_FMSYNTH = 4
    Public Const MOD_MAPPER = 5
    Public Const MOD_WAVETABLE = 6
    Public Const MOD_SWSYNTH = 7
    'dwSupport
    Public Const MIDICAPS_VOLUME = 1
    Public Const MIDICAPS_LRVOLUME = 2
    Public Const MIDICAPS_CACHE = 4
    Public Const MIDICAPS_STREAM = 8

    Public Const MAXPNAMELEN = 32
    Public Const MAXERRORLENGTH = 256   'max error text length (including NULL)

    'MMVERSION       equ  <DWORD>

    Public Const CALLBACK_NULL = 0             'no callback
    Public Const CALLBACK_WINDOW = &H10000     'dwCallback is a HWND
    Public Const CALLBACK_THREAD = &H20000     'dwCallback is a HTASK
    Public Const CALLBACK_FUNCTION = &H30000   'dwCallback is a FARPROC
    Public Const CALLBACK_EVENT = &H50000      'dwCallback is an EVENT Handle

    Public Const MIDI_IO_STATUS = &H20

    'MIDI Window Messages
    Public Const MM_MIM_OPEN = &H3C1            'MIDI input */
    Public Const MM_MIM_CLOSE = &H3C2
    Public Const MM_MIM_DATA = &H3C3
    Public Const MM_MIM_MOREDATA = &H3CC        'MIM_DONE w/ pending events */
    Public Const MM_MIM_LONGDATA = &H3C4
    Public Const MM_MIM_ERROR = &H3C5
    Public Const MM_MIM_LONGERROR = &H3C6

    Public Const MM_MOM_OPEN = &H3C7            'MIDI output */
    Public Const MM_MOM_CLOSE = &H3C8
    Public Const MM_MOM_DONE = &H3C9

    'MIDI callback messages
    Public Const MIM_OPEN = MM_MIM_OPEN
    Public Const MIM_CLOSE = MM_MIM_CLOSE
    Public Const MIM_DATA = MM_MIM_DATA
    Public Const MIM_MOREDATA = MM_MIM_MOREDATA
    Public Const MIM_LONGDATA = MM_MIM_LONGDATA
    Public Const MIM_ERROR = MM_MIM_ERROR
    Public Const MIM_LONGERROR = MM_MIM_LONGERROR
    Public Const MOM_OPEN = MM_MOM_OPEN
    Public Const MOM_CLOSE = MM_MOM_CLOSE
    Public Const MOM_DONE = MM_MOM_DONE

    'flags for dwFlags field of MIDIHDR structure
    Public Const MHDR_DONE = 1          'done bit
    Public Const MHDR_PREPARED = 2      'set if header prepared (after prepare)
    Public Const MHDR_INQUEUE = 4       'reserved for driver (after addBuffer)
    Public Const MHDR_ISSTRM = 8        'Buffer Is stream buffer

    '                                   ' 0 = init
    '                                   ' 1 = after MidiInReset (MIM_LONGDATA) ;uncertain
    '                                   ' 2 = after MidiInPrepare
    '                                   ' 3 = data (MIM_LONGDATA)
    '                                   ' 6 = after MidiInAddBuffer

    '-------- MIO Error codes --------

    Public Const MIO_ERR_NOTFOUND = 200
    Public Const MIO_ERR_NoOutBufferAvailable = 21

End Class
