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
/// <para>Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.</para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(ISensor)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class UncalibratedMagnetometer(IJSObjectReference uncalibratedMagnetometer) : Sensor, IUncalibratedMagnetometer {
    private protected override IJSObjectReference SensorJS => uncalibratedMagnetometer;


    /// <summary>
    /// Returns a double containing the uncalibrated magnetic field around the device's x axis.
    /// </summary>
    public ValueTask<double> X => GetX(default);

    /// <summary>
    /// Returns a double containing the uncalibrated magnetic field around the device's x axis.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetX(CancellationToken cancellationToken) => uncalibratedMagnetometer.InvokeTrySync<double>("getX", cancellationToken);


    /// <summary>
    /// Returns a double containing the uncalibrated magnetic field around the device's y axis.
    /// </summary>
    public ValueTask<double> Y => GetY(default);

    /// <summary>
    /// Returns a double containing the uncalibrated magnetic field around the device's y axis
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetY(CancellationToken cancellationToken) => uncalibratedMagnetometer.InvokeTrySync<double>("getY", cancellationToken);


    /// <summary>
    /// Returns a double containing the uncalibrated magnetic field around the device's z axis.
    /// </summary>
    public ValueTask<double> Z => GetZ(default);

    /// <summary>
    /// Returns a double containing the uncalibrated magnetic field around the device's z axis.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetZ(CancellationToken cancellationToken) => uncalibratedMagnetometer.InvokeTrySync<double>("getZ", cancellationToken);



    /// <summary>
    /// Returns a double representing the hard iron distortion correction around x axis.
    /// </summary>
    public ValueTask<double> XBias => GetXBias(default);

    /// <summary>
    /// Returns a double representing the hard iron distortion correction around x axis.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetXBias(CancellationToken cancellationToken) => uncalibratedMagnetometer.InvokeTrySync<double>("getXBias", cancellationToken);


    /// <summary>
    /// Returns a double representing the hard iron distortion correction around y axis.
    /// </summary>
    public ValueTask<double> YBias => GetYBias(default);

    /// <summary>
    /// Returns a double representing the hard iron distortion correction around y axis.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetYBias(CancellationToken cancellationToken) => uncalibratedMagnetometer.InvokeTrySync<double>("getYBias", cancellationToken);


    /// <summary>
    /// Returns a double representing the hard iron distortion correction around z axis.
    /// </summary>
    public ValueTask<double> ZBias => GetZBias(default);

    /// <summary>
    /// Returns a double representing the hard iron distortion correction around z axis.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetZBias(CancellationToken cancellationToken) => uncalibratedMagnetometer.InvokeTrySync<double>("getZBias", cancellationToken);
}
