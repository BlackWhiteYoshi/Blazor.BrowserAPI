using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The Sensor APIs are a set of interfaces built to a common design that expose device sensors in a consistent way to the web platform.
/// </summary>
/// <param name="moduleManager"></param>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class SensorAPIInProcess(IModuleManager moduleManager) : ISensorAPIInProcess {
    /// <summary>
    /// The <i>AmbientLightSensor()</i> constructor creates a new AmbientLightSensor object, which returns the current light level or illuminance of the ambient light around the hosting device.
    /// </summary>
    /// <param name="frequency">The desired number of times per second a sample should be taken, meaning the number of times per second the reading event will be called.</param>
    /// <returns>If not available (not supported by the browser or any other error), it returns null.</returns>
    public IAmbientLightSensorInProcess? CreateAmbientLightSensor(double frequency = 0) {
        try {
            IJSInProcessObjectReference ambientLightSensorJS = moduleManager.InvokeSync<IJSInProcessObjectReference>("AmbientLightSensorAPI.create", [frequency]);
            return new AmbientLightSensorInProcess(ambientLightSensorJS);
        }
        catch (JSException) {
            return null;
        }
    }


    /// <summary>
    /// The <i>Gyroscope()</i> constructor creates a new Gyroscope object which provides on each reading the angular velocity of the device along all three axes.
    /// </summary>
    /// <param name="frequency">The desired number of times per second a sample should be taken, meaning the number of times per second the reading event will be called.</param>
    /// <param name="referenceFrame">Either 'device' or 'screen'. The default is 'device'.</param>
    /// <returns>If not available (not supported by the browser or any other error), it returns null.</returns>
    public IGyroscopeInProcess? CreateGyroscope(double frequency = 0, string referenceFrame = "device") {
        try {
            IJSInProcessObjectReference gyroscopeJS = moduleManager.InvokeSync<IJSInProcessObjectReference>("GyroscopeAPI.create", [frequency, referenceFrame]);
            return new GyroscopeInProcess(gyroscopeJS);
        }
        catch (JSException) {
            return null;
        }
    }


    /// <summary>
    /// The <i>Accelerometer()</i> constructor creates a new Accelerometer object which returns the acceleration of the device along all three axes at the time it is read.
    /// </summary>
    /// <param name="frequency">The desired number of times per second a sample should be taken, meaning the number of times per second the reading event will be called.</param>
    /// <param name="referenceFrame">Either 'device' or 'screen'. The default is 'device'.</param>
    /// <returns>If not available (not supported by the browser or any other error), it returns null.</returns>
    public IAccelerometerInProcess? CreateAccelerometer(double frequency = 0, string referenceFrame = "device") {
        try {
            IJSInProcessObjectReference accelerometerJS = moduleManager.InvokeSync<IJSInProcessObjectReference>("AccelerometerAPI.create", [frequency, referenceFrame]);
            return new AccelerometerInProcess(accelerometerJS);
        }
        catch (JSException) {
            return null;
        }
    }

    /// <summary>
    /// The <i>LinearAccelerationSensor()</i> constructor creates a new LinearAccelerationSensor object which provides on each reading the acceleration applied to the device along all three axes, but without the contribution of gravity.
    /// </summary>
    /// <param name="frequency">The desired number of times per second a sample should be taken, meaning the number of times per second the reading event will be called.</param>
    /// <param name="referenceFrame">Either 'device' or 'screen'. The default is 'device'.</param>
    /// <returns>If not available (not supported by the browser or any other error), it returns null.</returns>
    public ILinearAccelerationSensorInProcess? CreateLinearAccelerationSensor(double frequency = 0, string referenceFrame = "device") {
        try {
            IJSInProcessObjectReference linearAccelerationSensorJS = moduleManager.InvokeSync<IJSInProcessObjectReference>("LinearAccelerationSensorAPI.create", [frequency, referenceFrame]);
            return new LinearAccelerationSensorInProcess(linearAccelerationSensorJS);
        }
        catch (JSException) {
            return null;
        }
    }

    /// <summary>
    /// The <i>GravitySensor()</i> constructor creates a new GravitySensor object which provides on each reading the gravity applied to the device along all three axes.
    /// </summary>
    /// <param name="frequency">The desired number of times per second a sample should be taken, meaning the number of times per second the reading event will be called.</param>
    /// <param name="referenceFrame">Either 'device' or 'screen'. The default is 'device'.</param>
    /// <returns>If not available (not supported by the browser or any other error), it returns null.</returns>
    public IGravitySensorInProcess? CreateGravitySensor(double frequency = 0, string referenceFrame = "device") {
        try {
            IJSInProcessObjectReference gravitySensorJS = moduleManager.InvokeSync<IJSInProcessObjectReference>("GravitySensorAPI.create", [frequency, referenceFrame]);
            return new GravitySensorInProcess(gravitySensorJS);
        }
        catch (JSException) {
            return null;
        }
    }


    /// <summary>
    /// The <i>AbsoluteOrientationSensor()</i> constructor creates a new AbsoluteOrientationSensor object which describes the device's physical orientation in relation to the Earth's reference coordinate system.
    /// </summary>
    /// <param name="frequency">The desired number of times per second a sample should be taken, meaning the number of times per second the reading event will be called.</param>
    /// <param name="referenceFrame">Either 'device' or 'screen'. The default is 'device'.</param>
    /// <returns>If not available (not supported by the browser or any other error), it returns null.</returns>
    public IAbsoluteOrientationSensorInProcess? CreateAbsoluteOrientationSensor(double frequency = 0, string referenceFrame = "device") {
        try {
            IJSInProcessObjectReference absoluteOrientationSensorJS = moduleManager.InvokeSync<IJSInProcessObjectReference>("AbsoluteOrientationSensorAPI.create", [frequency, referenceFrame]);
            return new AbsoluteOrientationSensorInProcess(absoluteOrientationSensorJS);
        }
        catch (JSException) {
            return null;
        }
    }

    /// <summary>
    /// The <i>RelativeOrientationSensor()</i> constructor creates a new RelativeOrientationSensor object which describes the device's physical orientation.
    /// </summary>
    /// <param name="frequency">The desired number of times per second a sample should be taken, meaning the number of times per second the reading event will be called.</param>
    /// <param name="referenceFrame">Either 'device' or 'screen'. The default is 'device'.</param>
    /// <returns>If not available (not supported by the browser or any other error), it returns null.</returns>
    public IRelativeOrientationSensorInProcess? CreateRelativeOrientationSensor(double frequency = 0, string referenceFrame = "device") {
        try {
            IJSInProcessObjectReference relativeOrientationSensorJS = moduleManager.InvokeSync<IJSInProcessObjectReference>("RelativeOrientationSensorAPI.create", [frequency, referenceFrame]);
            return new RelativeOrientationSensorInProcess(relativeOrientationSensorJS);
        }
        catch (JSException) {
            return null;
        }
    }


    /// <summary>
    /// The <i>Magnetometer()</i> constructor creates a new Magnetometer object which returns information about the magnetic field as detected by a device's primary magnetometer sensor.
    /// </summary>
    /// <param name="frequency">The desired number of times per second a sample should be taken, meaning the number of times per second the reading event will be called.</param>
    /// <param name="referenceFrame">Either 'device' or 'screen'. The default is 'device'.</param>
    /// <returns>If not available (not supported by the browser or any other error), it returns null.</returns>
    public IMagnetometerInProcess? CreateMagnetometer(double frequency = 0, string referenceFrame = "device") {
        try {
            IJSInProcessObjectReference magnetometerJS = moduleManager.InvokeSync<IJSInProcessObjectReference>("MagnetometerAPI.create", [frequency, referenceFrame]);
            return new MagnetometerInProcess(magnetometerJS);
        }
        catch (JSException) {
            return null;
        }
    }

    /// <summary>
    /// <para>The <i>UncalibratedMagnetometer()</i> constructor creates a new UncalibratedMagnetometer object which returns information about the uncalibrated magnetic field as detected by a device's primary magnetometer sensor.</para>
    /// <para>
    /// <i>Hard iron distortion</i> is created by objects that produce a magnetic field, such as magnetized iron.<br />
    /// <i>Soft iron distortion</i> stretches or distorts the magnetic field and is caused by metals such as nickel and iron.<br />
    /// The <i>calibrated magnetic field</i> is a magnetic field with hard iron distortion and soft iron distortion correction applied.<br />
    /// The <i>uncalibrated magnetic field</i> is the magnetic field without hard iron distortion correction and with soft iron distortion correction applied, and as such reports changes in the magnetic field caused by magnetized objects moving near the magnetometer.
    /// </para>
    /// </summary>
    /// <param name="frequency">The desired number of times per second a sample should be taken, meaning the number of times per second the reading event will be called.</param>
    /// <param name="referenceFrame">Either 'device' or 'screen'. The default is 'device'.</param>
    /// <returns>If not available (not supported by the browser or any other error), it returns null.</returns>
    public IUncalibratedMagnetometerInProcess? CreateUncalibratedMagnetometer(double frequency = 0, string referenceFrame = "device") {
        try {
            IJSInProcessObjectReference uncalibratedMagnetometerJS = moduleManager.InvokeSync<IJSInProcessObjectReference>("UncalibratedMagnetometerAPI.create", [frequency, referenceFrame]);
            return new UncalibratedMagnetometerInProcess(uncalibratedMagnetometerJS);
        }
        catch (JSException) {
            return null;
        }
    }
}
