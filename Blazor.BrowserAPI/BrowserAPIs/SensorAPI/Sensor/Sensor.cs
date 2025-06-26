using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The Sensor interface of the Sensor APIs is the base class for all the other sensor interfaces.
/// This interface cannot be used directly.
/// Instead it provides properties, event handlers, and methods accessed by interfaces that inherit from it.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IAsyncDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class Sensor(IJSObjectReference sensorJS) : SensorBase(sensorJS), ISensor {
    /// <summary>
    /// Releases the JS instance for this service worker.
    /// </summary>
    public ValueTask DisposeAsync() {
        DisposeEventTrigger();
        return sensorJS.DisposeTrySync();
    }


    /// <summary>
    /// Returns a boolean value indicating whether the sensor is active.
    /// </summary>
    public ValueTask<bool> Activated => GetActivated(default);

    /// <summary>
    /// Returns a boolean value indicating whether the sensor is active.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetActivated(CancellationToken cancellationToken) => sensorJS.InvokeTrySync<bool>("getActivated", cancellationToken);


    /// <summary>
    /// Returns a boolean value indicating whether the sensor has a reading.
    /// </summary>
    public ValueTask<bool> HasReading => GetHasReading(default);

    /// <summary>
    /// Returns a boolean value indicating whether the sensor has a reading.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetHasReading(CancellationToken cancellationToken) => sensorJS.InvokeTrySync<bool>("getHasReading", cancellationToken);


    /// <summary>
    /// Returns the timestamp of the latest sensor reading.
    /// </summary>
    public ValueTask<double> Timestamp => GetTimestamp(default);

    /// <summary>
    /// Returns the timestamp of the latest sensor reading.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetTimestamp(CancellationToken cancellationToken) => sensorJS.InvokeTrySync<double>("getTimestamp", cancellationToken);



    /// <summary>
    /// Activates one of the sensors based on Sensor.
    /// </summary>
    /// <returns></returns>
    public ValueTask Start(CancellationToken cancellationToken = default) => sensorJS.InvokeVoidTrySync("start", cancellationToken);

    /// <summary>
    /// Deactivates one of the sensors based on Sensor.
    /// </summary>
    /// <returns></returns>
    public ValueTask Stop(CancellationToken cancellationToken = default) => sensorJS.InvokeVoidTrySync("stop", cancellationToken);
}
