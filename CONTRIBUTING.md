### Midi_IO
I just want to have a reliable and easy-to-access library for sending and receiving short and long Midi messages. Functionality beside the basic I/O should reside outside. It's a logical decision that should help keeping the overview.

#### Device or Port
The Winmm documentation uses sometimes the term 'device'. In my opinion, a device is a piece of hardware or software that can have one ore more connections to a computer. I prefer to use the term 'Port' for such a connection.

### Test Midi_IO
Was written to test the library. The monitorig functionality is a side effect and should not be much more expanded.

Playing notes on the computer keyboard is only for testing polyphonic sound. It can not be used for playing songs.
People who wants to play music should use a Midi master keyboard.


