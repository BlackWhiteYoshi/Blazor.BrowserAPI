using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The Web MIDI API connects to and interacts with Musical Instrument Digital Interface (MIDI) Devices.</para>
/// <para>
/// The interfaces deal with the practical aspects of sending and receiving MIDI messages.
/// Therefore, the API can be used for musical and non-musical uses, with any MIDI device connected to your computer.
/// </para>
/// </summary>
/// <param name="moduleManager"></param>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IWebMIDIBase<IJSObjectReference, IMIDIAccess, IMIDIPort>)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class WebMIDI(IModuleManager moduleManager) : WebMIDIBase<IJSObjectReference, IMIDIAccess, IMIDIPort>(moduleManager), IWebMIDI;
