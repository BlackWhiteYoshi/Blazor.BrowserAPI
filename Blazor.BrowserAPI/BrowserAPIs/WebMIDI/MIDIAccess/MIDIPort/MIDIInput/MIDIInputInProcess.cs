using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The MIDIInput interface of the Web MIDI API receives messages from a MIDI input port.
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to dispose this object when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IMIDIPortInProcess)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class MIDIInputInProcess(IJSInProcessObjectReference midiInputJs) : MIDIPortInProcess(midiInputJs), IMIDIInputInProcess {
    /// <inheritdoc cref="MIDIPortBase{TJSInProcessObjectReference}.OnMIDIMessage" />
    public new event Action<byte[]?> OnMIDIMessage {
        add { base.OnMIDIMessage += value; }
        remove { base.OnMIDIMessage -= value; }
    }
}
