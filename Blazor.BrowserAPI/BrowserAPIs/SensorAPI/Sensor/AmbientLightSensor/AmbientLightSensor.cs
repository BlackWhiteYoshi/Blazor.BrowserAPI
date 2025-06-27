using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The <i>AmbientLightSensor</i> interface of the Sensor APIs returns the current light level or illuminance of the ambient light around the hosting device.</para>
/// <para>To use this sensor, the user must grant permission to the 'ambient-light-sensor' device sensor through the Permissions API.</para>
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(ISensor)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class AmbientLightSensor(IJSObjectReference ambientLightSensor) : Sensor(ambientLightSensor), IAmbientLightSensor {
    /// <summary>
    /// Returns the current light level in lux of the ambient light level around the hosting device.
    /// </summary>
    public ValueTask<double> Illuminance => GetIlluminance(default);

    /// <summary>
    /// Returns the current light level in lux of the ambient light level around the hosting device.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<double> GetIlluminance(CancellationToken cancellationToken) => sensorJS.InvokeTrySync<double>("getIlluminance", cancellationToken);
}
