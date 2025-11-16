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
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(ISensor)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class UncalibratedMagnetometer(IJSObjectReference uncalibratedMagnetometer) : Sensor(uncalibratedMagnetometer), IUncalibratedMagnetometer {
    /// <summary>
    /// Returns a double containing the uncalibrated magnetic field around the device's x axis.
    /// </summary>
    public ValueTask<double> X => GetX(CancellationToken.None);

    /// <inheritdoc cref="X" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetX(CancellationToken cancellationToken) => sensorJS.InvokeTrySync<double>("getX", cancellationToken);


    /// <summary>
    /// Returns a double containing the uncalibrated magnetic field around the device's y axis.
    /// </summary>
    public ValueTask<double> Y => GetY(CancellationToken.None);

    /// <inheritdoc cref="Y" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetY(CancellationToken cancellationToken) => sensorJS.InvokeTrySync<double>("getY", cancellationToken);


    /// <summary>
    /// Returns a double containing the uncalibrated magnetic field around the device's z axis.
    /// </summary>
    public ValueTask<double> Z => GetZ(CancellationToken.None);

    /// <inheritdoc cref="Z" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetZ(CancellationToken cancellationToken) => sensorJS.InvokeTrySync<double>("getZ", cancellationToken);



    /// <summary>
    /// Returns a double representing the hard iron distortion correction around x axis.
    /// </summary>
    public ValueTask<double> XBias => GetXBias(CancellationToken.None);

    /// <inheritdoc cref="XBias" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetXBias(CancellationToken cancellationToken) => sensorJS.InvokeTrySync<double>("getXBias", cancellationToken);


    /// <summary>
    /// Returns a double representing the hard iron distortion correction around y axis.
    /// </summary>
    public ValueTask<double> YBias => GetYBias(CancellationToken.None);

    /// <inheritdoc cref="YBias" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetYBias(CancellationToken cancellationToken) => sensorJS.InvokeTrySync<double>("getYBias", cancellationToken);


    /// <summary>
    /// Returns a double representing the hard iron distortion correction around z axis.
    /// </summary>
    public ValueTask<double> ZBias => GetZBias(CancellationToken.None);

    /// <inheritdoc cref="ZBias" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetZBias(CancellationToken cancellationToken) => sensorJS.InvokeTrySync<double>("getZBias", cancellationToken);
}
