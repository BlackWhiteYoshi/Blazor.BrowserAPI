using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// Base interface of <see cref="IMIDIAccess"/> and <see cref="IMIDIAccessInProcess"/>.<br/>
/// It contains common functionality for both interfaces.<br/>
/// It is not intended to use this interface directly.
/// </summary>
/// <typeparam name="TJSObjectReference"></typeparam>
/// <typeparam name="TMIDIPort"></typeparam>
/// <param name="midiAccessJs"></param>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class MIDIAccessBase<TJSObjectReference, TMIDIPort>(TJSObjectReference midiAccessJs)
    where TJSObjectReference : IJSObjectReference
    where TMIDIPort : IMIDIPortBase<TJSObjectReference> {
    private protected TJSObjectReference midiAccessJs = midiAccessJs;


    #region Events

    [method: DynamicDependency(nameof(InvokeStateChange))]
    [RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
    private sealed class EventTrigger(MIDIAccessBase<TJSObjectReference, TMIDIPort> midiAccess) {
        [JSInvokable] public void InvokeStateChange(bool isInputPort, TJSObjectReference midiPortJs) {
            TMIDIPort midiPort = (isInputPort, typeof(TJSObjectReference) == typeof(IJSObjectReference)) switch {
                (true, true) => (TMIDIPort)(IMIDIInput)new MIDIInput(midiPortJs),
                (true, false) => (TMIDIPort)(IMIDIInputInProcess)new MIDIInputInProcess((IJSInProcessObjectReference)midiPortJs),
                (false, true) => (TMIDIPort)(IMIDIOutput)new MIDIOutput(midiPortJs),
                (false, false) => (TMIDIPort)(IMIDIOutputInProcess)new MIDIOutputInProcess((IJSInProcessObjectReference)midiPortJs)
            };
            midiAccess._onStateChange?.Invoke(midiPort);
        }
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return midiAccessJs.InvokeVoidTrySync("initEvents", [_objectReferenceEventTrigger]);
    }

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await midiAccessJs.InvokeVoidTrySync(jsMethodName);
    }

    private ValueTask DeactivateJSEvent(string jsMethodName) => midiAccessJs.InvokeVoidTrySync(jsMethodName);


    // Events

    private Action<TMIDIPort>? _onStateChange;
    /// <summary>
    /// <para>Fired when a new MIDI port is added or when an existing port changes state.</para>
    /// <para>
    /// Parameter is the MIDIPort instance for a port that has been connected or disconnected.<br />
    /// Note: Dispose the given MIDIPort instance when you are done with it.
    /// </para>
    /// </summary>
    public event Action<TMIDIPort> OnStateChange {
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

    #endregion
}
