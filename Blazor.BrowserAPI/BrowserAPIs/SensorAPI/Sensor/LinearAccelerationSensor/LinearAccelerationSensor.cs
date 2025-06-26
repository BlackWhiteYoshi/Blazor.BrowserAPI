using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The <i>LinearAccelerationSensor</i> interface of the Sensor APIs provides on each reading the acceleration applied to the device along all three axes, but without the contribution of gravity.</para>
/// <para>To use this sensor, the user must grant permission to the 'accelerometer' device sensor through the Permissions API.</para>
/// <para>Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.</para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(ISensor)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
internal class LinearAccelerationSensor(IJSObjectReference linearAccelerationSensor) : Sensor(linearAccelerationSensor), ILinearAccelerationSensor {
    /// <summary>
    /// Returns a double containing the acceleration of the device along the device's x axis.
    /// </summary>
    public ValueTask<double> X => GetX(default);

    /// <summary>
    /// Returns a double containing the acceleration of the device along the device's x axis.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetX(CancellationToken cancellationToken) => sensorJS.InvokeTrySync<double>("getX", cancellationToken);


    /// <summary>
    /// Returns a double containing the acceleration of the device along the device's y axis.
    /// </summary>
    public ValueTask<double> Y => GetY(default);

    /// <summary>
    /// Returns a double containing the acceleration of the device along the device's y axis.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetY(CancellationToken cancellationToken) => sensorJS.InvokeTrySync<double>("getY", cancellationToken);


    /// <summary>
    /// Returns a double containing the acceleration of the device along the device's z axis.
    /// </summary>
    public ValueTask<double> Z => GetZ(default);

    /// <summary>
    /// Returns a double containing the acceleration of the device along the device's z axis.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetZ(CancellationToken cancellationToken) => sensorJS.InvokeTrySync<double>("getZ", cancellationToken);
}
