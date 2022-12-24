Module Module1

    ''' <summary>
    ''' Returns the GM VoiceName from GM VoiceNumber
    ''' </summary>
    ''' <param name="VoiceNum"></param>
    ''' <returns></returns>
    Public Function GetVoiceName(VoiceNum As Byte) As String

        Dim str As String = ""

        If GM_VoiceNames.TryGetValue(VoiceNum, str) = True Then
            Return str
        Else

            Return VoiceNum & " - unknown Voice"
        End If

    End Function

    ''' <summary>
    ''' GemeralMidi VoiceNames sorted by VoiceNumber
    ''' </summary>
    Public ReadOnly GM_VoiceNames As New SortedList(Of Integer, String) From
          {
{0, "Acoustic Grand Piano"},
{1, "Bright Acoustic Piano"},
{2, "Electric Grand Piano"},
{3, "Honky-tonk Piano"},
{4, "Electric Piano 1"},
{5, "Electric Piano 2"},
{6, "Harpsichord"},
{7, "Clavi"},
{8, "Celesta"},
{9, "Glockenspiel"},
{10, "Music Box"},
{11, "Vibraphone"},
{12, "Marimba"},
{13, "Xylophone"},
{14, "Tubular Bells"},
{15, "Dulcimer"},
{16, "Drawbar Organ"},
{17, "Percussive Organ"},
{18, "Rock Organ"},
{19, "Church Organ"},
{20, "Reed Organ"},
{21, "Accordion"},
{22, "Harmonica"},
{23, "Tango Accordion"},
{24, "Acoustic Guitar (nylon)"},
{25, "Acoustic Guitar (steel)"},
{26, "Electric Guitar (jazz)"},
{27, "Electric Guitar (clean)"},
{28, "Electric Guitar (muted"},
{29, "Overdriven Guitar"},
{30, "Distortion Guitar"},
{31, "Guitar harmonics"},
{32, "Acoustic Bass"},
{33, "Electric Bass (finger)"},
{34, "Electric Bass (pick)"},
{35, "Fretless Bass"},
{36, "Slap Bass 1"},
{37, "Slap Bass 2"},
{38, "Synth Bass 1"},
{39, "Synth Bass 2"},
{40, "Violin"},
{41, "Viola"},
{42, "Cello"},
{43, "Contrabass"},
{44, "Tremolo Strings"},
{45, "Pizzicato Strings"},
{46, "Orchestral Harp"},
{47, "Timpani"},
{48, "String Ensemble 1"},
{49, "String Ensemble 2"},
{50, "SynthStrings 1"},
{51, "SynthStrings 2"},
{52, "Choir Aahs"},
{53, "Voice Oohs"},
{54, "Synth Voice"},
{55, "Orchestra Hit"},
{56, "Trumpet"},
{57, "Trombone"},
{58, "Tuba"},
{59, "Muted Trumpet"},
{60, "French Horn"},
{61, "Brass Section"},
{62, "SynthBrass 1"},
{63, "SynthBrass 2"},
{64, "Soprano Sax"},
{65, "Alto Sax"},
{66, "Tenor Sax"},
{67, "Baritone Sax"},
{68, "Oboe"},
{69, "English Horn"},
{70, "Bassoon"},
{71, "Clarinet"},
{72, "Piccolo"},
{73, "Flute"},
{74, "Recorder"},
{75, "Pan Flute"},
{76, "Blown Bottle"},
{77, "Shakuhachi"},
{78, "Whistle"},
{79, "Ocarina"},
{80, "Lead 1 (square)"},
{81, "Lead 2 (sawtooth)"},
{82, "Lead 3 (calliope)"},
{83, "Lead 4 (chiff)"},
{84, "Lead 5 (charang)"},
{85, "Lead 6 (voice)"},
{86, "Lead 7 (fifths)"},
{87, "Lead 8 (bass + lead)"},
{88, "Pad 1 (New age)"},
{89, "Pad 2 (warm)"},
{90, "Pad 3 (polysynth)"},
{91, "Pad 4 (choir)"},
{92, "Pad 5 (bowed)"},
{93, "Pad 6 (metallic)"},
{94, "Pad 7 (halo)"},
{95, "Pad 8 (sweep)"},
{96, "FX 1 (rain)"},
{97, "FX 2 (soundtrack)"},
{98, "FX 3 (crystal)"},
{99, "FX 4 (atmosphere)"},
{100, "FX 5 (brightness)"},
{101, "FX 6 (goblins)"},
{102, "FX 7 (echoes)"},
{103, "FX 8 (sci-fi)"},
{104, "Sitar"},
{105, "Banjo"},
{106, "Shamisen"},
{107, "Koto"},
{108, "Kalimba"},
{109, "Bag pipe"},
{110, "Fiddle"},
{111, "Shanai"},
{112, "Tinkle Bell"},
{113, "Agogo"},
{114, "Steel Drums"},
{115, "Woodblock"},
{116, "Taiko Drum"},
{117, "Melodic Tom"},
{118, "Synth Drum"},
{119, "Reverse Cymbal"},
{120, "Guitar Fret Noise"},
{121, "Breath Noise"},
{122, "Seashore"},
{123, "Bird Tweet"},
{124, "Telephone Ring"},
{125, "Helicopter"},
{126, "Applause"},
{127, "Gunshot"}
}

    '--- Voice ---
    '
    ' output for keyboard-voice on channel 0

    Friend Sub KbdNoteOn(keycode As Byte)
        If keycode >= 48 AndAlso keycode <= 90 Then
            Dim kstate As New KbdNoteState
            If KeycodeToNote.TryGetValue(keycode, kstate) = True Then
                If kstate.IsPlaying = False Then
                    Form1.MidiOutShortMsg(Form1.hMidiOut, &H90, kstate.NoteNumber, 100)     ' note on
                    kstate.IsPlaying = True
                End If
            End If
        End If
    End Sub

    Friend Sub KbdNoteOff(keycode As Byte)
        If keycode >= 48 AndAlso keycode <= 90 Then
            Dim kstate As New KbdNoteState
            If KeycodeToNote.TryGetValue(keycode, kstate) = True Then
                If kstate.IsPlaying = True Then
                    Form1.MidiOutShortMsg(Form1.hMidiOut, &H90, kstate.NoteNumber, 0)   ' note off
                    kstate.IsPlaying = False
                End If
            End If
        End If
    End Sub

    Friend Sub KbdNotes_AllNotesOff()

        Form1.MidiOutShortMsg(Form1.hMidiOut, &HB0, &H7B, 0)        ' All Notes Off (B0, 7B, 0) on channel 0
        ' turn all states off
        For Each kstate In KeycodeToNote
            kstate.Value.IsPlaying = False
        Next

    End Sub

    Private Class KbdNoteState
        Public NoteNumber As Byte
        Public IsPlaying As Boolean
    End Class

    ' keycode, noteNumber, isPlaying
    Private ReadOnly KeycodeToNote As New SortedList(Of Byte, KbdNoteState) From
        {
        {89, New KbdNoteState With {.NoteNumber = 48}},
        {83, New KbdNoteState With {.NoteNumber = 49}},
        {88, New KbdNoteState With {.NoteNumber = 50}},
        {68, New KbdNoteState With {.NoteNumber = 51}},
        {67, New KbdNoteState With {.NoteNumber = 52}},
        {86, New KbdNoteState With {.NoteNumber = 53}},
        {71, New KbdNoteState With {.NoteNumber = 54}},
        {66, New KbdNoteState With {.NoteNumber = 55}},
        {72, New KbdNoteState With {.NoteNumber = 56}},
        {78, New KbdNoteState With {.NoteNumber = 57}},
        {74, New KbdNoteState With {.NoteNumber = 58}},
        {77, New KbdNoteState With {.NoteNumber = 59}},
        {81, New KbdNoteState With {.NoteNumber = 60}},
        {50, New KbdNoteState With {.NoteNumber = 61}},
        {87, New KbdNoteState With {.NoteNumber = 62}},
        {51, New KbdNoteState With {.NoteNumber = 63}},
        {69, New KbdNoteState With {.NoteNumber = 64}},
        {82, New KbdNoteState With {.NoteNumber = 65}},
        {53, New KbdNoteState With {.NoteNumber = 66}},
        {84, New KbdNoteState With {.NoteNumber = 67}},
        {54, New KbdNoteState With {.NoteNumber = 68}},
        {90, New KbdNoteState With {.NoteNumber = 69}},
        {55, New KbdNoteState With {.NoteNumber = 70}},
        {85, New KbdNoteState With {.NoteNumber = 71}},
        {73, New KbdNoteState With {.NoteNumber = 72}},
        {57, New KbdNoteState With {.NoteNumber = 73}},
        {79, New KbdNoteState With {.NoteNumber = 74}},
        {48, New KbdNoteState With {.NoteNumber = 75}},
        {80, New KbdNoteState With {.NoteNumber = 76}}
    }

    '--- Drums ---
    '
    ' Drums are on Channel 9    
    ' Even if Drum sounds are usually single-shot, it is recommended to send a Note-off too.
    ' Quote: The MIDI Specification requires that all Note-On commands have a corresponding Note-Off command,
    ' And it Is assumed that all MIDI transmitters will comply with this requirement) Quote End
    ' Generally, retriggering a Note that is aready on can affect the sound quality.


    Friend Sub KbdDrumNoteOn(keycode As Byte)
        If keycode >= 48 AndAlso keycode <= 90 Then
            Dim kstate As New KbdNoteState
            If KeycodeToDrumNote.TryGetValue(keycode, kstate) = True Then
                If kstate.IsPlaying = False Then
                    Form1.MidiOutShortMsg(Form1.hMidiOut, &H99, kstate.NoteNumber, 100)     ' note on
                    kstate.IsPlaying = True
                End If
            End If
        End If
    End Sub

    Friend Sub KbdDrumNoteOff(keycode As Byte)
        If keycode >= 48 AndAlso keycode <= 90 Then
            Dim kstate As New KbdNoteState
            If KeycodeToDrumNote.TryGetValue(keycode, kstate) = True Then
                If kstate.IsPlaying = True Then
                    Form1.MidiOutShortMsg(Form1.hMidiOut, &H99, kstate.NoteNumber, 0)   ' note off
                    kstate.IsPlaying = False
                End If
            End If
        End If
    End Sub

    Friend Sub KbdDrumNotes_AllNotesOff()

        Form1.MidiOutShortMsg(Form1.hMidiOut, &HB9, &H7B, 0)        ' All Notes Off (B9, 7B, 0) on channel 9
        ' turn all states off
        For Each kstate In KeycodeToDrumNote
            kstate.Value.IsPlaying = False
        Next

    End Sub

    Private ReadOnly KeycodeToDrumNote As New SortedList(Of Byte, KbdNoteState) From
        {
        {89, New KbdNoteState With {.NoteNumber = 27}},
        {88, New KbdNoteState With {.NoteNumber = 28}},
        {67, New KbdNoteState With {.NoteNumber = 29}},
        {86, New KbdNoteState With {.NoteNumber = 30}},
        {66, New KbdNoteState With {.NoteNumber = 31}},
        {78, New KbdNoteState With {.NoteNumber = 32}},
        {77, New KbdNoteState With {.NoteNumber = 33}},
        {65, New KbdNoteState With {.NoteNumber = 34}},
        {83, New KbdNoteState With {.NoteNumber = 35}},
        {68, New KbdNoteState With {.NoteNumber = 36}},
        {70, New KbdNoteState With {.NoteNumber = 37}},
        {71, New KbdNoteState With {.NoteNumber = 38}},
        {72, New KbdNoteState With {.NoteNumber = 39}},
        {74, New KbdNoteState With {.NoteNumber = 40}},
        {75, New KbdNoteState With {.NoteNumber = 41}},
        {76, New KbdNoteState With {.NoteNumber = 42}},
        {81, New KbdNoteState With {.NoteNumber = 43}},
        {87, New KbdNoteState With {.NoteNumber = 44}},
        {69, New KbdNoteState With {.NoteNumber = 45}},
        {82, New KbdNoteState With {.NoteNumber = 46}},
        {84, New KbdNoteState With {.NoteNumber = 47}},
        {90, New KbdNoteState With {.NoteNumber = 48}},
        {85, New KbdNoteState With {.NoteNumber = 49}},
        {73, New KbdNoteState With {.NoteNumber = 50}},
        {79, New KbdNoteState With {.NoteNumber = 51}},
        {80, New KbdNoteState With {.NoteNumber = 52}},
        {49, New KbdNoteState With {.NoteNumber = 53}},
        {50, New KbdNoteState With {.NoteNumber = 54}},
        {51, New KbdNoteState With {.NoteNumber = 55}},
        {52, New KbdNoteState With {.NoteNumber = 56}},
        {53, New KbdNoteState With {.NoteNumber = 57}},
        {54, New KbdNoteState With {.NoteNumber = 58}},
        {55, New KbdNoteState With {.NoteNumber = 59}},
        {56, New KbdNoteState With {.NoteNumber = 60}},
        {57, New KbdNoteState With {.NoteNumber = 61}},
        {48, New KbdNoteState With {.NoteNumber = 62}}
    }

    '--- Drum Voice Names

    ''' <summary>
    ''' Returns the GM DrumVoiceName from GM DrumKeyNumber
    ''' </summary>
    ''' <param name="KeyNum"></param>
    ''' <returns></returns>
    Public Function GetDrumVoiceName(KeyNum As Byte) As String

        Dim str As String = ""

        If GM_DrumVoiceNames.TryGetValue(KeyNum, str) = True Then
            Return str
        Else

            Return KeyNum & " - not listed"
        End If

    End Function

    ''' <summary>
    ''' GemeralMidi VoiceNames sorted by VoiceNumber
    ''' </summary>
    Public ReadOnly GM_DrumVoiceNames As New SortedList(Of Integer, String) From
          {
{35, "Acoustic Bass Drum"},
{36, "Bass Drum 1"},
{37, "Side Stick"},
{38, "Acoustic Snare"},
{39, "Hand Clap"},
{40, "Electric Snare"},
{41, "Low Floor Tom"},
{42, "Closed Hi Hat"},
{43, "High Floor Tom"},
{44, "Pedal Hi-Hat"},
{45, "Low Tom"},
{46, "Open Hi-Hat"},
{47, "Low-Mid Tom"},
{48, "Hi Mid Tom"},
{49, "Crash Cymbal 1"},
{50, "High Tom"},
{51, "Ride Cymbal 1"},
{52, "Chinese Cymbal"},
{53, "Ride Bell"},
{54, "Tambourine"},
{55, "Splash Cymbal"},
{56, "Cowbell"},
{57, "Crash Cymbal 2"},
{58, "Vibraslap"},
{59, "Ride Cymbal 2"},
{60, "Hi Bongo"},
{61, "Low Bongo"},
{62, "Mute Hi Conga"},
{63, "Open Hi Conga"},
{64, "Low Conga"},
{65, "High Timbale"},
{66, "Low Timbale"},
{67, "High Agogo"},
{68, "Low Agogo"},
{69, "Cabasa"},
{70, "Maracas"},
{71, "Short Whistle"},
{72, "Long Whistle"},
{73, "Short Guiro"},
{74, "Long Guiro"},
{75, "Claves"},
{76, "Hi Wood Block"},
{77, "Low Wood Block"},
{78, "Mute Cuica"},
{79, "Open Cuica"},
{80, "Mute Triangle"},
{81, "Open Triangle"}
}



End Module
