using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The <i>UncalibratedMagnetometer</i> interface of the Sensor APIs provides information about the uncalibrated magnetic field as detected by the device's primary magnetometer sensor.</para>
/// <para>To use this sensor, the user must grant permission to the 'magnetometer' device sensor through the Permissions API.</para>
/// <para>
/// <i>Hard iron distortion</i> is created by objects that produce a magnetic field, such as magnetized iron.<br />
/// <i>Soft iron distortion</i> stretches or distorts the magnetic field and is caused by metals such as nickel and iron.<br />
/// The <i>calibrated magnetic field</i> is a magnetic field with hard iron distortion and soft iron distortion correction applied.<br />
/// The <i>uncalibrated magnetic field</i> is the magnetic field without hard iron distortion correction and with soft iron distortion correction applied, and as such reports changes in the magnetic field caused by magnetized objects moving near the magnetometer.
/// </para>
/// <para>Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.</para>
/// </summary>
/// <param name="uncalibratedMagnetometer"></param>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(ISensorInProcess)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class UncalibratedMagnetometerInProcess(IJSInProcessObjectReference uncalibratedMagnetometer) : SensorInProcess, IUncalibratedMagnetometerInProcess {
    private protected override IJSInProcessObjectReference SensorJSInProcess => uncalibratedMagnetometer;


    /// <summary>
    /// Returns a double containing the uncalibrated magnetic field around the device's x axis.
    /// </summary>
    public double X => SensorJSInProcess.Invoke<double>("getX");

    /// <summary>
    /// Returns a double containing the uncalibrated magnetic field around the device's y axis.
    /// </summary>
    public double Y => SensorJSInProcess.Invoke<double>("getY");

    /// <summary>
    /// Returns a double containing the uncalibrated magnetic field around the device's z axis.
    /// </summary>
    public double Z => SensorJSInProcess.Invoke<double>("getZ");


    /// <summary>
    /// Returns a double representing the hard iron distortion correction around x axis.
    /// </summary>
    public double XBias => SensorJSInProcess.Invoke<double>("getXBias");

    /// <summary>
    /// Returns a double representing the hard iron distortion correction around y axis.
    /// </summary>
    public double YBias => SensorJSInProcess.Invoke<double>("getYBias");

    /// <summary>
    /// Returns a double representing the hard iron distortion correction around z axis.
    /// </summary>
    public double ZBias => SensorJSInProcess.Invoke<double>("getZBias");
}
