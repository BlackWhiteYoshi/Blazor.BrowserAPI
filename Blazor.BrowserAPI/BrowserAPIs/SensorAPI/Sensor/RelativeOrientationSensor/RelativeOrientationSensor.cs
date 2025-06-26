using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The <i>RelativeOrientationSensor</i> interface of the Sensor APIs describes the device's physical orientation without regard to the Earth's reference coordinate system.</para>
/// <para>To use this sensor, the user must grant permission to the 'accelerometer', and 'gyroscope' device sensors through the Permissions API.</para>
/// <para>Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.</para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(ISensor)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class RelativeOrientationSensor(IJSObjectReference relativeOrientationSensor) : Sensor(relativeOrientationSensor), IRelativeOrientationSensor {
    /// <summary>
    /// Returns a unit quaternion representing the device's orientation.
    /// </summary>
    public ValueTask<Quaternion> Quaternion => GetQuaternion(default);

    /// <summary>
    /// Returns a four element Array whose elements contain the components of the unit quaternion representing the device's orientation.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<Quaternion> GetQuaternion(CancellationToken cancellationToken) {
        float[] quaternion = await sensorJS.InvokeTrySync<float[]>("getQuaternion", cancellationToken);
        return new Quaternion(quaternion[0], quaternion[1], quaternion[2], quaternion[3]);
    }


    /// <summary>
    /// Returns a rotation matrix based on the latest sensor reading.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<Matrix4x4> PopulateMatrix(CancellationToken cancellationToken = default) {
        float[] matrix4x4 = await sensorJS.InvokeTrySync<float[]>("populateMatrix", cancellationToken);
        return new Matrix4x4(
            matrix4x4[0],
            matrix4x4[1],
            matrix4x4[2],
            matrix4x4[3],
            matrix4x4[4],
            matrix4x4[5],
            matrix4x4[6],
            matrix4x4[7],
            matrix4x4[8],
            matrix4x4[9],
            matrix4x4[10],
            matrix4x4[11],
            matrix4x4[12],
            matrix4x4[13],
            matrix4x4[14],
            matrix4x4[15]
        );
    }
}
