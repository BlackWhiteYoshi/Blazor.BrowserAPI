using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The <i>AmbientLightSensor</i> interface of the Sensor APIs returns the current light level or illuminance of the ambient light around the hosting device.</para>
/// <para>To use this sensor, the user must grant permission to the 'ambient-light-sensor' device sensor through the Permissions API.</para>
/// <para>Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.</para>
/// </summary>
/// <param name="ambientLightSensor"></param>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(ISensorInProcess)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class AmbientLightSensorInProcess(IJSInProcessObjectReference ambientLightSensor) : SensorInProcess, IAmbientLightSensorInProcess {
    private protected override IJSInProcessObjectReference SensorJSInProcess => ambientLightSensor;


    /// <summary>
    /// Returns the current light level in lux of the ambient light level around the hosting device.
    /// </summary>
    public double Illuminance => ambientLightSensor.Invoke<double>("getIlluminance");
}
