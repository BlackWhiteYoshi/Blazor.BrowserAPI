using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The <i>Magnetometer</i> interface of the Sensor APIs provides information about the magnetic field as detected by the device's primary magnetometer sensor.</para>
/// <para>To use this sensor, the user must grant permission to the 'magnetometer' device sensor through the Permissions API.</para>
/// <para>Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.</para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(ISensor)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class Magnetometer(IJSObjectReference magnetometer) : Sensor, IMagnetometer {
    private protected override IJSObjectReference SensorJS => magnetometer;


    /// <summary>
    /// Returns a double containing the magnetic field around the device's x axis.
    /// </summary>
    public ValueTask<double> X => GetX(default);

    /// <summary>
    /// Returns a double containing the magnetic field around the device's x axis.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetX(CancellationToken cancellationToken) => magnetometer.InvokeTrySync<double>("getX", cancellationToken);


    /// <summary>
    /// Returns a double containing the magnetic field around the device's y axis.
    /// </summary>
    public ValueTask<double> Y => GetY(default);

    /// <summary>
    /// Returns a double containing the magnetic field around the device's y axis.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetY(CancellationToken cancellationToken) => magnetometer.InvokeTrySync<double>("getY", cancellationToken);


    /// <summary>
    /// Returns a double containing the magnetic field around the device's z axis.
    /// </summary>
    public ValueTask<double> Z => GetZ(default);

    /// <summary>
    /// Returns a double containing the magnetic field around the device's z axis.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetZ(CancellationToken cancellationToken) => magnetometer.InvokeTrySync<double>("getZ", cancellationToken);
}
