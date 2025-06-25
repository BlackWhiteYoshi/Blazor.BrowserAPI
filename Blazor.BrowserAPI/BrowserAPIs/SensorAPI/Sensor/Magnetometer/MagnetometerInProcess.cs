using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The <i>Magnetometer</i> interface of the Sensor APIs provides information about the magnetic field as detected by the device's primary magnetometer sensor.</para>
/// <para>To use this sensor, the user must grant permission to the 'magnetometer' device sensor through the Permissions API.</para>
/// <para>Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.</para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(ISensorInProcess)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class MagnetometerInProcess(IJSInProcessObjectReference magnetometer) : SensorInProcess, IMagnetometerInProcess {
    private protected override IJSInProcessObjectReference SensorJSInProcess => magnetometer;


    /// <summary>
    /// Returns a double containing the magnetic field around the device's x axis.
    /// </summary>
    public double X => SensorJSInProcess.Invoke<double>("getX");

    /// <summary>
    /// Returns a double containing the magnetic field around the device's y axis.
    /// </summary>
    public double Y => SensorJSInProcess.Invoke<double>("getY");

    /// <summary>
    /// Returns a double containing the magnetic field around the device's z axis.
    /// </summary>
    public double Z => SensorJSInProcess.Invoke<double>("getZ");
}
