using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The MIDIOutput interface of the Web MIDI API provides methods to add messages to the queue of an output device, and to clear the queue of messages.
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to dispose this object when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IMIDIPort)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class MIDIOutput(IJSObjectReference midiOutputJs) : MIDIPort(midiOutputJs), IMIDIOutput {
    /// <summary>
    /// Queues messages for the corresponding MIDI port.
    /// The message can be sent immediately, or with an optional timestamp to delay sending.
    /// </summary>
    /// <param name="data">A sequence of one or more <see href="https://midi.org/about-midi-part-3midi-messages">valid MIDI messages</see>. Each entry represents a single byte of data.</param>
    /// <param name="timestamp">A DOMHighResTimestamp with the time in milliseconds when the message should be sent (relative to Performance.timeOrigin).</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Send(int[] data, long? timestamp = null, CancellationToken cancellationToken = default) {
        if (timestamp is null)
            return midiPortJs.InvokeVoidTrySync("send", cancellationToken, [data]);
        else
            return midiPortJs.InvokeVoidTrySync("send", cancellationToken, [data, timestamp]);
    }

    /// <summary>
    /// Clears the queue of messages being sent to the output device.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Clear(CancellationToken cancellationToken = default) => midiPortJs.InvokeVoidTrySync("clear", cancellationToken);
}
