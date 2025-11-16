using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The <i>Magnetometer</i> interface of the Sensor APIs provides information about the magnetic field as detected by the device's primary magnetometer sensor.</para>
/// <para>To use this sensor, the user must grant permission to the 'magnetometer' device sensor through the Permissions API.</para>
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(ISensor)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class Magnetometer(IJSObjectReference magnetometer) : Sensor(magnetometer), IMagnetometer {
    /// <summary>
    /// Returns a double containing the magnetic field around the device's x axis.
    /// </summary>
    public ValueTask<double> X => GetX(CancellationToken.None);

    /// <inheritdoc cref="X" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetX(CancellationToken cancellationToken) => sensorJS.InvokeTrySync<double>("getX", cancellationToken);


    /// <summary>
    /// Returns a double containing the magnetic field around the device's y axis.
    /// </summary>
    public ValueTask<double> Y => GetY(CancellationToken.None);

    /// <inheritdoc cref="Y" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetY(CancellationToken cancellationToken) => sensorJS.InvokeTrySync<double>("getY", cancellationToken);


    /// <summary>
    /// Returns a double containing the magnetic field around the device's z axis.
    /// </summary>
    public ValueTask<double> Z => GetZ(CancellationToken.None);

    /// <inheritdoc cref="Z" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetZ(CancellationToken cancellationToken) => sensorJS.InvokeTrySync<double>("getZ", cancellationToken);
}
