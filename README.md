## Midi_IO

Midi_IO is a .Net library for Midi Input/Output based on Windows WINMM.
It simplifies the calls to the C++ style functions in WINMM and handles the required buffers in unmanaged memory.

Midi_IO provides functions and raises events for
- Enumerating Input and Output ports
- Opening and closing Input and Output ports
- Sending and receiving short and long (sysx) Midi messages
- Receiving informative Midi messages

There is 
- NO support for midiStreamOut
- NO support for other WINMM audio functions


### Test Midi_IO

Test application for the Midi_IO library. Can also be used as a simple Midi In/Out monitor in raw hexadecimal format.

![small Test Midi_IO](https://user-images.githubusercontent.com/88147904/131333949-76a5511d-d5ac-4f9f-aa75-04eba167641d.png)



### Test Minimum

The minimum required controls and code to play a Note.

---

## Programming details

### Documentation of winmm

The underlying documentation for winmm can be found at:
- docs.microsoft.com/ ... /windows/win32/api/mmeapi
- docs.microsoft.com/ ... /windows/win32/multimedia/musical-instrument-digital-interface--midi

### Functions

The usual way to create an instance of Midi_IO is:

```
Private WithEvents MIO As New Midi_IO.Midi_IO
```

- _Start
  - Is called from NEW 
 
- _End
  - Should be called when the application closes, especially when MidiInPorts were used.
        It closes forgotten In- and Out ports and frees unmanaged memory.

- OpenMidiInPort
- OpenMidiOutPort
```
(portName As String, ByRef hndRet As UInteger, dwInstance As Integer) As Boolean
```
- 
  - in: portName is a .portName in the MidiOutPorts list
  - in: dwInstance is a user defined value, can be 0
  - returns TRUE if Open was successful, hndRet is set to the handle value
       
- CloseMidiInPort
  - MidiInPorts can be considered as recording / listening. They need more care than the MidiOutPorts.
        Internally midiInStop and midiInReset is called.

- CloseMidiOutPort

- OutShortMsg
  - Sends a 3-byte message to an OutpuPort. Usually (Status, data1, data2). 
  - Overloaded with (Status, Channel, data1, data2) to internally merge Status and channel.
- OutLongMsg
  - Sends a SystemExclusive message to an OutputPort. The massage has variable length in a byte() buffer.
        It begins with &hF0 and ends with &hF7. Data bytes between are limited to 7 bit. (<= 127, &h7F)

- RefreshPortList
  - Useful when a device was connected/disconnected while the application is running.
        The function has to close all open ports, in case a device was disconnected / powered off.

### Events
```
Public Event MidiInData(hMidiIn As UInteger, dwInstance As UInteger, status As Byte, data1 As Byte, data2 As Byte, dwTimestamp As UInteger)
```
Handles the MIM_DATA message.

```    
Public Event MidiInLongdata(hMidiIn As UInteger, dwInstance As UInteger, buffer As Byte(), dwTimestamp As UInteger)
```
Handles the MIM_LONGDATA message. Buffer() is filled with the message bytes. Buffer.Length contains the number of bytes in the message
   
```
Public Event MidiInCallbackMsg(hMidiIn As UInteger, wMsg As UInteger, dwInstance As UInteger, dwParam1 As UInteger, dwParam2 As UInteger)
```
Informative messages about the state of a Midi-In Port. MIM_OPEN, MIM_CLOSE,... 
   
```   
Public Event MidiOutCallbackMsg(hMidiOut As UInteger, wMsg As UInteger, dwInstance As UInteger, dwParam1 As UInteger, dwParam2 As UInteger)
```
   Informative messages about the state of a Midi-Out Port. MOM_OPEN, MOM_CLOSE, MOM_DONE,.. 


### Properties

- MidiIn_filter_ActiveSense
- MidiIn_filter_TimingClock

Set the corresponig property to FALSE to receive the message as MidiInData event.

### Fields

- MidiInPorts
- MidiOutPorts

Enumeration of the Ports after NEW or RefreshPortList


