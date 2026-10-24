using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>Represents a MIDI input or output port.</para>
/// <para>A MIDIPort instance is created when a new MIDI device is connected. Therefore it has no constructor.</para>
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to dispose this object when you are done with it.</remarks>
/// <param name="midiPortJs"></param>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IMIDIPortBase<IJSInProcessObjectReference>), typeof(IDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class MIDIPortInProcess(IJSInProcessObjectReference midiPortJs) : MIDIPortBase<IJSInProcessObjectReference>(midiPortJs), IMIDIPortInProcess {
    /// <summary>
    /// Releases the JS instance for this notification.
    /// </summary>
    /// <returns></returns>
    public void Dispose() {
        DisposeEventTrigger();
        midiPortJs.Dispose();
    }


    /// <summary>
    /// Contains the unique ID of the port.
    /// </summary>
    public string Id => midiPortJs.Invoke<string>("getId");

    /// <summary>
    /// Contains the manufacturer of the port.
    /// </summary>
    public string Manufacturer => midiPortJs.Invoke<string>("getManufacturer");

    /// <summary>
    /// Contains the system name of the port.
    /// </summary>
    public string Name => midiPortJs.Invoke<string>("getName");

    /// <summary>
    /// Contains the type of the port, one of:<br/>
    /// - "input": The MIDIPort is an input port.<br/>
    /// - "output": The MIDIPort is an output port.
    /// </summary>
    public string Type => midiPortJs.Invoke<string>("getType");

    /// <summary>
    /// Contains the version of the port.
    /// </summary>
    public string Version => midiPortJs.Invoke<string>("getVersion");

    /// <summary>
    /// Contains the state of the port, one of:<br/>
    /// - "connected": The device that this MIDIPort represents is currently connected.<br/>
    /// - "disconnected": The device that this MIDIPort represents is disconnected from the system.
    /// </summary>
    public string State => midiPortJs.Invoke<string>("getState");

    /// <summary>
    /// Contains the connection state of the port, one of:<br/>
    /// - "open": The device that this MIDIPort represents has been opened and is available.<br/>
    /// - "closed": The device that this MIDIPort represents has not been opened, or has been closed.<br/>
    /// - "pending": The device that this MIDIPort represents has been opened but has subsequently disconnected.
    /// </summary>
    public string Connection => midiPortJs.Invoke<string>("getConnection");
}
