using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The <i>GravitySensor</i> interface of the Sensor APIs provides on each reading the gravity applied to the device along all three axes.</para>
/// <para>To use this sensor, the user must grant permission to the 'accelerometer' device sensor through the Permissions API.</para>
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(ISensorInProcess)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class GravitySensorInProcess(IJSInProcessObjectReference gravitySensor) : SensorInProcess(gravitySensor), IGravitySensorInProcess {
    /// <summary>
    /// Returns a double containing the acceleration of the device along the device's x axis.
    /// </summary>
    public double X => SensorJS.Invoke<double>("getX");

    /// <summary>
    /// Returns a double containing the acceleration of the device along the device's y axis.
    /// </summary>
    public double Y => SensorJS.Invoke<double>("getY");

    /// <summary>
    /// Returns a double containing the acceleration of the device along the device's z axis.
    /// </summary>
    public double Z => SensorJS.Invoke<double>("getZ");
}
