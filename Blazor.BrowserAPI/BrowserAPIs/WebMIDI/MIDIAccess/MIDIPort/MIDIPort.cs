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
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IMIDIPortBase<IJSObjectReference>), typeof(IAsyncDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class MIDIPort(IJSObjectReference midiPortJs) : MIDIPortBase<IJSObjectReference>(midiPortJs), IMIDIPort {
    /// <summary>
    /// Releases the JS instance for this notification.
    /// </summary>
    /// <returns></returns>
    public ValueTask DisposeAsync() {
        DisposeEventTrigger();
        return midiPortJs.DisposeTrySync();
    }


    /// <summary>
    /// Contains the unique ID of the port.
    /// </summary>
    public ValueTask<string> Id => GetId(CancellationToken.None);

    /// <inheritdoc cref="Id" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetId(CancellationToken cancellationToken) => midiPortJs.InvokeTrySync<string>("getId", cancellationToken);


    /// <summary>
    /// Contains the manufacturer of the port.
    /// </summary>
    public ValueTask<string> Manufacturer => GetManufacturer(CancellationToken.None);

    /// <inheritdoc cref="Manufacturer" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetManufacturer(CancellationToken cancellationToken) => midiPortJs.InvokeTrySync<string>("getManufacturer", cancellationToken);


    /// <summary>
    /// Contains the system name of the port.
    /// </summary>
    public ValueTask<string> Name => GetName(CancellationToken.None);

    /// <inheritdoc cref="Name" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetName(CancellationToken cancellationToken) => midiPortJs.InvokeTrySync<string>("getName", cancellationToken);


    /// <summary>
    /// Contains the type of the port, one of:<br/>
    /// - "input": The MIDIPort is an input port.<br/>
    /// - "output": The MIDIPort is an output port.
    /// </summary>
    public ValueTask<string> Type => GetType(CancellationToken.None);

    /// <inheritdoc cref="Type" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetType(CancellationToken cancellationToken) => midiPortJs.InvokeTrySync<string>("getType", cancellationToken);


    /// <summary>
    /// Contains the version of the port.
    /// </summary>
    public ValueTask<string> Version => GetVersion(CancellationToken.None);

    /// <inheritdoc cref="Version" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetVersion(CancellationToken cancellationToken) => midiPortJs.InvokeTrySync<string>("getVersion", cancellationToken);


    /// <summary>
    /// Contains the state of the port, one of:<br/>
    /// - "connected": The device that this MIDIPort represents is currently connected.<br/>
    /// - "disconnected": The device that this MIDIPort represents is disconnected from the system.
    /// </summary>
    public ValueTask<string> State => GetState(CancellationToken.None);

    /// <inheritdoc cref="State" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetState(CancellationToken cancellationToken) => midiPortJs.InvokeTrySync<string>("getState", cancellationToken);


    /// <summary>
    /// Contains the connection state of the port, one of:<br/>
    /// - "open": The device that this MIDIPort represents has been opened and is available.<br/>
    /// - "closed": The device that this MIDIPort represents has not been opened, or has been closed.<br/>
    /// - "pending": The device that this MIDIPort represents has been opened but has subsequently disconnected.
    /// </summary>
    public ValueTask<string> Connection => GetConnection(CancellationToken.None);

    /// <inheritdoc cref="Connection" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetConnection(CancellationToken cancellationToken) => midiPortJs.InvokeTrySync<string>("getConnection", cancellationToken);
}
