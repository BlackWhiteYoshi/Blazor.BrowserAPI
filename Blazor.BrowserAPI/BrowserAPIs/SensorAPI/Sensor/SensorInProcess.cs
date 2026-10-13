using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The Sensor interface of the Sensor APIs is the base class for all the other sensor interfaces.
/// This interface cannot be used directly.
/// Instead it provides properties, event handlers, and methods accessed by interfaces that inherit from it.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(ISensorBase<IJSInProcessObjectReference>), typeof(IDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class SensorInProcess(IJSInProcessObjectReference sensorJS) : SensorBase<IJSInProcessObjectReference>(sensorJS), ISensorInProcess {
    /// <summary>
    /// Releases the JS instance for this service worker.
    /// </summary>
    public void Dispose() {
        DisposeEventTrigger();
        sensorJS.Dispose();
    }


    /// <summary>
    /// Returns a boolean value indicating whether the sensor is active.
    /// </summary>
    public bool Activated => sensorJS.Invoke<bool>("getActivated");

    /// <summary>
    /// Returns a boolean value indicating whether the sensor has a reading.
    /// </summary>
    public bool HasReading => sensorJS.Invoke<bool>("getHasReading");

    /// <summary>
    /// Returns the timestamp of the latest sensor reading.
    /// </summary>
    public double Timestamp => sensorJS.Invoke<double>("getTimestamp");


    /// <summary>
    /// Activates one of the sensors based on Sensor.
    /// </summary>
    public void Start() => sensorJS.InvokeVoid("start");

    /// <summary>
    /// Deactivates one of the sensors based on Sensor.
    /// </summary>
    public void Stop() => sensorJS.InvokeVoid("stop");
}
