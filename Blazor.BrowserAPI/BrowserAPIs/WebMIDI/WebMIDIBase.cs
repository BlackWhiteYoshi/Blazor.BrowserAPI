using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// Base interface of <see cref="IWebMIDI"/> and <see cref="IWebMIDIInProcess"/>.<br/>
/// It contains common functionality for both interfaces.<br/>
/// It is not intended to use this interface directly.
/// </summary>
/// <typeparam name="TJSObjectReference"></typeparam>
/// <typeparam name="TMIDIAccess"></typeparam>
/// <typeparam name="TMIDIPort"></typeparam>
/// <param name="moduleManager"></param>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class WebMIDIBase<TJSObjectReference, TMIDIAccess, TMIDIPort>(IModuleManager moduleManager)
    where TJSObjectReference : IJSObjectReference
    where TMIDIAccess : IMIDIAccessBase<TJSObjectReference, TMIDIPort>
    where TMIDIPort : IMIDIPortBase<TJSObjectReference> {
    private protected IModuleManager moduleManager = moduleManager;

    /// <summary>
    /// <para>
    /// Represents a request for access to MIDI devices on a user's system.
    /// This method is part of the Web MIDI API, which provides a means for accessing, enumerating, and manipulating MIDI devices.
    /// </para>
    /// <para>
    /// This method may prompt the user for access to MIDI devices available to their system, or it may use a previously established preference to grant or deny access.
    /// If permission is granted then the Promise resolves and a MIDIAccess object is returned.
    /// </para>
    /// </summary>
    /// <param name="sysex">If set to true, allows the ability to send and receive system exclusive (sysex) messages. The default value is false.</param>
    /// <param name="software">If set to true, allows the system to utilize any installed software synthesizers. The default value is false.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<TMIDIAccess> RequestMIDIAccess(bool sysex = false, bool software = false, CancellationToken cancellationToken = default) {
        TJSObjectReference midiAccess = await moduleManager.InvokeAsync<TJSObjectReference>("WebMIDIAPI.requestMIDIAccess", cancellationToken, [sysex, software]);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference))
            return (TMIDIAccess)(IMIDIAccess)new MIDIAccess(midiAccess);
        else
            return (TMIDIAccess)(IMIDIAccessInProcess)new MIDIAccessInProcess((IJSInProcessObjectReference)midiAccess);
    }
}
