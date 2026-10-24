using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// Provides methods for listing MIDI input and output devices, and obtaining access to those devices.
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to dispose this object when you are done with it.</remarks>
/// <param name="midiAccessJs"></param>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IMIDIAccessBase<IJSObjectReference, IMIDIPort>), typeof(IAsyncDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class MIDIAccess(IJSObjectReference midiAccessJs) : MIDIAccessBase<IJSObjectReference, IMIDIPort>(midiAccessJs), IMIDIAccess {
    /// <summary>
    /// Releases the JS instance for this notification.
    /// </summary>
    /// <returns></returns>
    public ValueTask DisposeAsync() {
        DisposeEventTrigger();
        return midiAccessJs.DisposeTrySync();
    }


    /// <summary>
    /// Provides access to any available MIDI input ports.
    /// </summary>
    public ValueTask<IMIDIInput[]> Inputs => GetInputs(CancellationToken.None);

    /// <inheritdoc cref="Inputs" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IMIDIInput[]> GetInputs(CancellationToken cancellationToken) {
        IJSObjectReference[] midiInputs = await midiAccessJs.InvokeTrySync<IJSObjectReference[]>("getInputs", cancellationToken);

        MIDIInput[] result = new MIDIInput[midiInputs.Length];
        for (int i = 0; i <  midiInputs.Length; i++)
            result[i] = new MIDIInput(midiInputs[i]);
        return result;
    }


    /// <summary>
    /// Provides access to any available MIDI output ports.
    /// </summary>
    public ValueTask<IMIDIOutput[]> Outputs => GetOutputs(CancellationToken.None);

    /// <inheritdoc cref="Outputs" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IMIDIOutput[]> GetOutputs(CancellationToken cancellationToken) {
        IJSObjectReference[] midiOutputs = await midiAccessJs.InvokeTrySync<IJSObjectReference[]>("getOutputs", cancellationToken);

        MIDIOutput[] result = new MIDIOutput[midiOutputs.Length];
        for (int i = 0; i < midiOutputs.Length; i++)
            result[i] = new MIDIOutput(midiOutputs[i]);
        return result;
    }


    /// <summary>
    /// Indicates whether system exclusive support is enabled on the current MIDIAccess instance.
    /// </summary>
    public ValueTask<bool> SysexEnabled => GetSysexEnabled(CancellationToken.None);

    /// <inheritdoc cref="SysexEnabled" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetSysexEnabled(CancellationToken cancellationToken) => midiAccessJs.InvokeTrySync<bool>("getSysexEnabled", cancellationToken);
}
