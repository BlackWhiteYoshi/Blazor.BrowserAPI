using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// Provides methods for listing MIDI input and output devices, and obtaining access to those devices.
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to dispose this object when you are done with it.</remarks>
/// <param name="midiAccessJs"></param>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IMIDIAccessBase<IJSInProcessObjectReference, IMIDIPortInProcess>), typeof(IDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class MIDIAccessInProcess(IJSInProcessObjectReference midiAccessJs) : MIDIAccessBase<IJSInProcessObjectReference, IMIDIPortInProcess>(midiAccessJs), IMIDIAccessInProcess {
    /// <summary>
    /// Releases the JS instance for this notification.
    /// </summary>
    /// <returns></returns>
    public void Dispose() {
        DisposeEventTrigger();
        midiAccessJs.Dispose();
    }


    /// <summary>
    /// Provides access to any available MIDI input ports.
    /// </summary>
    public IMIDIInputInProcess[] Inputs {
        get {
            IJSInProcessObjectReference[] midiInputs = midiAccessJs.Invoke<IJSInProcessObjectReference[]>("getInputs");

            MIDIInputInProcess[] result = new MIDIInputInProcess[midiInputs.Length];
            for (int i = 0; i < midiInputs.Length; i++)
                result[i] = new MIDIInputInProcess(midiInputs[i]);
            return result;
        }
    }

    /// <summary>
    /// Provides access to any available MIDI output ports.
    /// </summary>
    public IMIDIOutputInProcess[] Outputs {
        get {
            IJSInProcessObjectReference[] midiOutputs = midiAccessJs.Invoke<IJSInProcessObjectReference[]>("getOutputs");

            MIDIOutputInProcess[] result = new MIDIOutputInProcess[midiOutputs.Length];
            for (int i = 0; i < midiOutputs.Length; i++)
                result[i] = new MIDIOutputInProcess(midiOutputs[i]);
            return result;
        }
    }

    /// <summary>
    /// Indicates whether system exclusive support is enabled on the current MIDIAccess instance.
    /// </summary>
    public bool SysexEnabled => midiAccessJs.Invoke<bool>("getSysexEnabled");
}
