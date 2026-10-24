using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// Base interface of <see cref="IMIDIPort"/> and <see cref="IMIDIPortInProcess"/>.<br/>
/// It contains common functionality for both interfaces.<br/>
/// It is not intended to use this interface directly.
/// </summary>
/// <typeparam name="TJSObjectReference"></typeparam>
/// <param name="midiPortJs"></param>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class MIDIPortBase<TJSObjectReference>(TJSObjectReference midiPortJs) where TJSObjectReference : IJSObjectReference {
    private protected TJSObjectReference midiPortJs = midiPortJs;


    /// <summary>
    /// <para>Makes the MIDI device connected to this MIDIPort explicitly available.</para>
    /// <para>
    /// If the port is successfully opened a new MIDIConnectionEvent is queued to the <see cref="IMIDIPortBase{TJSObjectReference}.OnStateChange">MIDIPort statechange</see>
    /// and <see cref="IMIDIAccessBase{TJSObjectReference, TMIDIPort}.OnStateChange">MIDIAccess statechange</see> events,
    /// and the <see cref="IMIDIPort.Connection">MIDIPort.connection</see> property is changed to "open".
    /// </para>
    /// <para>If the port is already open when this method is called, then the promise will resolve successfully.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Open(CancellationToken cancellationToken = default) => midiPortJs.InvokeVoidAsync("open", cancellationToken);

    /// <summary>
    /// <para>Makes the access to the MIDI device connected to this MIDIPort unavailable.</para>
    /// <para>
    /// If the port is successfully closed a new MIDIConnectionEvent is queued to the <see cref="IMIDIPortBase{TJSObjectReference}.OnStateChange">MIDIPort statechange</see>
    /// and <see cref="IMIDIAccessBase{TJSObjectReference, TMIDIPort}.OnStateChange">MIDIAccess statechange</see> events,
    /// and the <see cref="IMIDIPort.Connection">MIDIPort.connection</see> property is changed to "closed".
    /// </para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Close(CancellationToken cancellationToken = default) => midiPortJs.InvokeVoidAsync("close", cancellationToken);


    #region Events

    [method: DynamicDependency(nameof(InvokeStateChange))]
    [method: DynamicDependency(nameof(InvokeMIDIMessage))] // actually only needed for MIDIInput, not part of MIDIOutput (lack of multiple inheritance)
    private sealed class EventTrigger(MIDIPortBase<TJSObjectReference> midiPort) {
        [JSInvokable] public void InvokeStateChange() => midiPort._onStateChange?.Invoke();
        [JSInvokable] public void InvokeMIDIMessage(byte[]? data) => midiPort._onMIDIMessage?.Invoke(data); // actually only needed for MIDIInput, not part of MIDIOutput (lack of multiple inheritance)
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return midiPortJs.InvokeVoidTrySync("initEvents", [_objectReferenceEventTrigger]);
    }

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await midiPortJs.InvokeVoidTrySync(jsMethodName);
    }

    private ValueTask DeactivateJSEvent(string jsMethodName) => midiPortJs.InvokeVoidTrySync(jsMethodName);


    // Events

    private Action? _onStateChange;
    /// <summary>
    /// Fired when this port changes from open to closed, or closed to open.
    /// </summary>
    public event Action OnStateChange {
        add {
            if (_onStateChange == null)
                _ = ActivateJSEvent("activateOnstatechange").Preserve();
            _onStateChange += value;
        }
        remove {
            _onStateChange -= value;
            if (_onStateChange == null)
                _ = DeactivateJSEvent("deactivateOnstatechange").Preserve();
        }
    }

    // actually only needed for MIDIInput, not part of MIDIOutput (lack of multiple inheritance)
    private Action<byte[]?>? _onMIDIMessage;
    /// <summary>
    /// <para>
    /// Fired when the MIDI port corresponding to this MIDIInput finishes receiving one or more MIDI messages.
    /// An instance of MIDIMessageEvent containing the message that was received is passed to the event handler.
    /// </para>
    /// <para>Parameter contains the data bytes of a single MIDI message. See the <see href="https://midi.org/summary-of-midi-1-0-messages">MIDI specification</see> for more information on its form.</para>
    /// </summary>
    private protected event Action<byte[]?> OnMIDIMessage {
        add {
            if (_onMIDIMessage == null)
                _ = ActivateJSEvent("activateOnmidimessage").Preserve();
            _onMIDIMessage += value;
        }
        remove {
            _onMIDIMessage -= value;
            if (_onMIDIMessage == null)
                _ = DeactivateJSEvent("deactivateOnmidimessage").Preserve();
        }
    }

    #endregion
}
