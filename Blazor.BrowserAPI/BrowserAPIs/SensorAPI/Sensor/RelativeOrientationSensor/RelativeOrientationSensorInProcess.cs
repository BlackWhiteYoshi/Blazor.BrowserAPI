﻿using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace BrowserAPI.Implementation;


/// <summary>
/// <para>The <i>RelativeOrientationSensor</i> interface of the Sensor APIs describes the device's physical orientation without regard to the Earth's reference coordinate system.</para>
/// <para>To use this sensor, the user must grant permission to the 'accelerometer', and 'gyroscope' device sensors through the Permissions API.</para>
/// <para>Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.</para>
/// </summary>
/// <param name="relativeOrientationSensor"></param>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(ISensorInProcess)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class RelativeOrientationSensorInProcess(IJSInProcessObjectReference relativeOrientationSensor) : SensorInProcess, IRelativeOrientationSensorInProcess {
    private protected override IJSInProcessObjectReference SensorJSInProcess => relativeOrientationSensor;


    /// <summary>
    /// Returns a unit quaternion representing the device's orientation.
    /// </summary>
    public Quaternion Quaternion {
        get {
            float[] quaternion = SensorJSInProcess.Invoke<float[]>("getQuaternion");
            return new Quaternion(quaternion[0], quaternion[1], quaternion[2], quaternion[3]);
        }
    }


    /// <summary>
    /// Returns a rotation matrix based on the latest sensor reading.
    /// </summary>
    /// <returns></returns>
    public Matrix4x4 PopulateMatrix() {
        float[] matrix4x4 = SensorJSInProcess.Invoke<float[]>("populateMatrix");
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