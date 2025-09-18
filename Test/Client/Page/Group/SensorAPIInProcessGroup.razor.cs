using Microsoft.AspNetCore.Components;
using System.Numerics;
using System.Text.Json;

namespace BrowserAPI.Test.Client;

public sealed partial class SensorAPIInProcessGroup {
    public const string TEST_SENSOR_START = "sensor started";
    public const string TEST_SENSOR_STOP = "sensor stopped";
    public const string TEST_SENSOR_ERROR_EVENT = "error event";
    public const string TEST_SENSOR_ACTIVATE_EVENT = "activate event";
    public const string TEST_SENSOR_READING_EVENT = "reading event";


    [Inject]
    public required ISensorAPIInProcess SensorAPI { private get; init; }


    public const string LABEL_OUTPUT = "sensor-api-inprocess-output";
    private string labelOutput = string.Empty;


    // Sensor Properties

    public const string BUTTON_GET_ACTIVATED = "sensor-api-inprocess-get-activated-property";
    private void GetActivated() {
        using IGyroscopeInProcess? gyroscope = SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            labelOutput = "not supported";
            return;
        }

        bool activated = gyroscope.Activated;
        labelOutput = activated.ToString();
    }

    public const string BUTTON_GET_HAS_READING = "sensor-api-inprocess-get-has-reading-property";
    private void GetHasReading() {
        using IGyroscopeInProcess? gyroscope = SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            labelOutput = "not supported";
            return;
        }

        bool hasReading = gyroscope.HasReading;
        labelOutput = hasReading.ToString();
    }

    public const string BUTTON_GET_TIMESTAMP = "sensor-api-inprocess-get-timestamp-property";
    private void GetTimestamp() {
        using IGyroscopeInProcess? gyroscope = SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            labelOutput = "not supported";
            return;
        }

        double timestamp = gyroscope.Timestamp;
        labelOutput = timestamp.ToString();
    }


    // Sensor Methods

    public const string BUTTON_START = "sensor-api-inprocess-start";
    private void Start() {
        using IGyroscopeInProcess? gyroscope = SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            labelOutput = "not supported";
            return;
        }

        gyroscope.Start();
        labelOutput = TEST_SENSOR_START;
    }

    public const string BUTTON_STOP = "sensor-api-inprocess-stop";
    private void Stop() {
        using IGyroscopeInProcess? gyroscope = SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            labelOutput = "not supported";
            return;
        }

        gyroscope.Stop();
        labelOutput = TEST_SENSOR_STOP;
    }


    // Sensor Events

    public const string BUTTON_REGISTER_ON_ERROR = "sensor-api-inprocess-error-event";
    private void RegisterOnError() {
        IGyroscopeInProcess? gyroscope = SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            labelOutput = "not supported";
            return;
        }

        gyroscope.OnError += OnError;
        void OnError(JsonElement error) {
            labelOutput = TEST_SENSOR_ERROR_EVENT;
            StateHasChanged();
            gyroscope.OnError -= OnError;
            gyroscope.Dispose();
        }
    }

    public const string BUTTON_REGISTER_ON_ACTIVATE = "sensor-api-inprocess-activate-event";
    private void RegisterOnActivate() {
        IGyroscopeInProcess? gyroscope = SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            labelOutput = "not supported";
            return;
        }

        gyroscope.OnActivate += OnActivate;
        void OnActivate() {
            labelOutput = TEST_SENSOR_ACTIVATE_EVENT;
            StateHasChanged();
            gyroscope.OnActivate -= OnActivate;
            gyroscope.Dispose();
        }
    }

    public const string BUTTON_REGISTER_ON_READING = "sensor-api-inprocess-reading-event";
    private void RegisterOnReading() {
        IGyroscopeInProcess? gyroscope = SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            labelOutput = "not supported";
            return;
        }

        gyroscope.OnReading += OnReading;
        void OnReading() {
            labelOutput = TEST_SENSOR_READING_EVENT;
            StateHasChanged();
            gyroscope.OnReading -= OnReading;
            gyroscope.Dispose();
        }
    }


    // Window Events

    public const string BUTTON_REGISTER_ON_DEVICE_MOTION = "sensor-api-inprocess-device-motion-event";
    private void RegisterOnDeviceMotion() {
        SensorAPI.OnDeviceMotion += (DeviceMotionEvent deviceMotionEvent) => {
            labelOutput = deviceMotionEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_DEVICE_ORIENTATION = "sensor-api-inprocess-device-orientation-event";
    private void RegisterOnDeviceOrientation() {
        SensorAPI.OnDeviceOrientation += (DeviceOrientationEvent deviceOrientationEvent) => {
            labelOutput = deviceOrientationEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_DEVICE_ORIENTATION_ABSOLUTE = "sensor-api-inprocess-device-orientation-absolute-event";
    private void RegisterOnDeviceOrientationAbsolute() {
        SensorAPI.OnDeviceOrientationAbsolute += (DeviceOrientationEvent deviceOrientationEvent) => {
            labelOutput = deviceOrientationEvent.ToString();
            StateHasChanged();
        };
    }


    // AmbientLightSensor

    public const string BUTTON_AMBIENT_LIGHT_SENSOR_GET_ILLUMINANCE = "sensor-api-inprocess-ambient-light-sensor-get-illuminance-property";
    private void AmbientLightSensorGetIlluminance() {
        using IAmbientLightSensorInProcess? ambientLightSensor = SensorAPI.CreateAmbientLightSensor();
        if (ambientLightSensor == null) {
            labelOutput = "not supported";
            return;
        }

        double illuminance = ambientLightSensor.Illuminance;
        labelOutput = illuminance.ToString();
    }


    // Gyroscope

    public const string BUTTON_GYROSCOPE_GET_X = "sensor-api-inprocess-gyroscope-get-x-property";
    private void GyroscopeGetX() {
        using IGyroscopeInProcess? gyroscope = SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            labelOutput = "not supported";
            return;
        }

        double x = gyroscope.X;
        labelOutput = x.ToString();
    }

    public const string BUTTON_GYROSCOPE_GET_Y = "sensor-api-inprocess-gyroscope-get-y-property";
    private void GyroscopeGetY() {
        using IGyroscopeInProcess? gyroscope = SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            labelOutput = "not supported";
            return;
        }

        double y = gyroscope.Y;
        labelOutput = y.ToString();
    }

    public const string BUTTON_GYROSCOPE_GET_Z = "sensor-api-inprocess-gyroscope-get-z-property";
    private void GyroscopeGetZ() {
        using IGyroscopeInProcess? gyroscope = SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            labelOutput = "not supported";
            return;
        }

        double z = gyroscope.Z;
        labelOutput = z.ToString();
    }

    // Accelerometer

    public const string BUTTON_ACCELEROMETER_GET_X = "sensor-api-inprocess-accelerometer-get-x-property";
    private void AccelerometerGetX() {
        using IAccelerometerInProcess? accelerometer = SensorAPI.CreateAccelerometer();
        if (accelerometer == null) {
            labelOutput = "not supported";
            return;
        }

        double x = accelerometer.X;
        labelOutput = x.ToString();
    }

    public const string BUTTON_ACCELEROMETER_GET_Y = "sensor-api-inprocess-accelerometer-get-y-property";
    private void AccelerometerGetY() {
        using IAccelerometerInProcess? accelerometer = SensorAPI.CreateAccelerometer();
        if (accelerometer == null) {
            labelOutput = "not supported";
            return;
        }

        double y = accelerometer.Y;
        labelOutput = y.ToString();
    }

    public const string BUTTON_ACCELEROMETER_GET_Z = "sensor-api-inprocess-accelerometer-get-z-property";
    private void AccelerometerGetZ() {
        using IAccelerometerInProcess? accelerometer = SensorAPI.CreateAccelerometer();
        if (accelerometer == null) {
            labelOutput = "not supported";
            return;
        }

        double z = accelerometer.Z;
        labelOutput = z.ToString();
    }


    // LinearAccelerationSensor

    public const string BUTTON_LINEAR_ACCELERATION_SENSOR_GET_X = "sensor-api-inprocess-linear-acceleration-sensor-get-x-property";
    private void LinearAccelerationSensorGetX() {
        using ILinearAccelerationSensorInProcess? linearAccelerationSensor = SensorAPI.CreateLinearAccelerationSensor();
        if (linearAccelerationSensor == null) {
            labelOutput = "not supported";
            return;
        }

        double x = linearAccelerationSensor.X;
        labelOutput = x.ToString();
    }

    public const string BUTTON_LINEAR_ACCELERATION_SENSOR_GET_Y = "sensor-api-inprocess-linear-acceleration-sensor-get-y-property";
    private void LinearAccelerationSensorGetY() {
        using ILinearAccelerationSensorInProcess? linearAccelerationSensor = SensorAPI.CreateLinearAccelerationSensor();
        if (linearAccelerationSensor == null) {
            labelOutput = "not supported";
            return;
        }

        double y = linearAccelerationSensor.Y;
        labelOutput = y.ToString();
    }

    public const string BUTTON_LINEAR_ACCELERATION_SENSOR_GET_Z = "sensor-api-inprocess-linear-acceleration-sensor-get-z-property";
    private void LinearAccelerationSensorGetZ() {
        using ILinearAccelerationSensorInProcess? linearAccelerationSensor = SensorAPI.CreateLinearAccelerationSensor();
        if (linearAccelerationSensor == null) {
            labelOutput = "not supported";
            return;
        }

        double z = linearAccelerationSensor.Z;
        labelOutput = z.ToString();
    }


    // GravitySensor

    public const string BUTTON_GRAVITY_SENSOR_GET_X = "sensor-api-inprocess-gravity-sensor-get-x-property";
    private void GravitySensorGetX() {
        using IGravitySensorInProcess? gravitySensor = SensorAPI.CreateGravitySensor();
        if (gravitySensor == null) {
            labelOutput = "not supported";
            return;
        }

        double x = gravitySensor.X;
        labelOutput = x.ToString();
    }

    public const string BUTTON_GRAVITY_SENSOR_GET_Y = "sensor-api-inprocess-gravity-sensor-get-y-property";
    private void GravitySensorGetY() {
        using IGravitySensorInProcess? gravitySensor = SensorAPI.CreateGravitySensor();
        if (gravitySensor == null) {
            labelOutput = "not supported";
            return;
        }

        double y = gravitySensor.Y;
        labelOutput = y.ToString();
    }

    public const string BUTTON_GRAVITY_SENSOR_GET_Z = "sensor-api-inprocess-gravity-sensor-get-z-property";
    private void GravitySensorGetZ() {
        using IGravitySensorInProcess? gravitySensor = SensorAPI.CreateGravitySensor();
        if (gravitySensor == null) {
            labelOutput = "not supported";
            return;
        }

        double z = gravitySensor.Z;
        labelOutput = z.ToString();
    }


    // AbsoluteOrientationSensor

    public const string BUTTON_ABSOLUTE_ORIENTATION_SENSOR_GET_QUATERNION = "sensor-api-inprocess-absolute-orientation-sensor-get-quaternion-property";
    private void AbsoluteOrientationSensorGetQuaternion() {
        using IAbsoluteOrientationSensorInProcess? absoluteOrientationSensor = SensorAPI.CreateAbsoluteOrientationSensor();
        if (absoluteOrientationSensor == null) {
            labelOutput = "not supported";
            return;
        }

        Quaternion quaternion = absoluteOrientationSensor.Quaternion;
        labelOutput = quaternion.ToString();
    }

    public const string BUTTON_ABSOLUTE_ORIENTATION_SENSOR_POPULATE_MATRIX = "sensor-api-inprocess-absolute-orientation-sensor-populate-matrix";
    private void AbsoluteOrientationSensorPopulateMatrix() {
        using IAbsoluteOrientationSensorInProcess? absoluteOrientationSensor = SensorAPI.CreateAbsoluteOrientationSensor();
        if (absoluteOrientationSensor == null) {
            labelOutput = "not supported";
            return;
        }

        Matrix4x4 rotationMatrix = absoluteOrientationSensor.PopulateMatrix();
        labelOutput = rotationMatrix.ToString();
    }


    // RelativeOrientationSensor

    public const string BUTTON_RELATIVE_ORIENTATION_SENSOR_GET_QUATERNION = "sensor-api-inprocess-relative-orientation-sensor-get-quaternion-property";
    private void RelativeOrientationSensorGetQuaternion() {
        using IRelativeOrientationSensorInProcess? relativeOrientationSensor = SensorAPI.CreateRelativeOrientationSensor();
        if (relativeOrientationSensor == null) {
            labelOutput = "not supported";
            return;
        }

        Quaternion quaternion = relativeOrientationSensor.Quaternion;
        labelOutput = quaternion.ToString();
    }

    public const string BUTTON_RELATIVE_ORIENTATION_SENSOR_POPULATE_MATRIX = "sensor-api-inprocess-relative-orientation-sensor-populate-matrix";
    private void RelativeOrientationSensorPopulateMatrix() {
        using IRelativeOrientationSensorInProcess? relativeOrientationSensor = SensorAPI.CreateRelativeOrientationSensor();
        if (relativeOrientationSensor == null) {
            labelOutput = "not supported";
            return;
        }

        Matrix4x4 rotationMatrix = relativeOrientationSensor.PopulateMatrix();
        labelOutput = rotationMatrix.ToString();
    }


    // Magnetometer

    public const string BUTTON_MAGNETOMETER_GET_X = "sensor-api-inprocess-magnetometer-get-x-property";
    private void MagnetometerGetX() {
        using IMagnetometerInProcess? magnetometer = SensorAPI.CreateMagnetometer();
        if (magnetometer == null) {
            labelOutput = "not supported";
            return;
        }

        double x = magnetometer.X;
        labelOutput = x.ToString();
    }

    public const string BUTTON_MAGNETOMETER_GET_Y = "sensor-api-inprocess-magnetometer-get-y-property";
    private void MagnetometerGetY() {
        using IMagnetometerInProcess? magnetometer = SensorAPI.CreateMagnetometer();
        if (magnetometer == null) {
            labelOutput = "not supported";
            return;
        }

        double y = magnetometer.Y;
        labelOutput = y.ToString();
    }

    public const string BUTTON_MAGNETOMETER_GET_Z = "sensor-api-inprocess-magnetometer-get-z-property";
    private void MagnetometerGetZ() {
        using IMagnetometerInProcess? magnetometer = SensorAPI.CreateMagnetometer();
        if (magnetometer == null) {
            labelOutput = "not supported";
            return;
        }

        double z = magnetometer.Z;
        labelOutput = z.ToString();
    }


    // UncalibratedMagnetometer

    public const string BUTTON_UNCALIBRATED_MAGNETOMETER_GET_X = "sensor-api-inprocess-uncalibrated-magnetometer-get-x-property";
    private void UncalibratedMagnetometerGetX() {
        using IUncalibratedMagnetometerInProcess? uncalibratedMagnetometer = SensorAPI.CreateUncalibratedMagnetometer();
        if (uncalibratedMagnetometer == null) {
            labelOutput = "not supported";
            return;
        }

        double x = uncalibratedMagnetometer.X;
        labelOutput = x.ToString();
    }

    public const string BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Y = "sensor-api-inprocess-uncalibrated-magnetometer-get-y-property";
    private void UncalibratedMagnetometerGetY() {
        using IUncalibratedMagnetometerInProcess? uncalibratedMagnetometer = SensorAPI.CreateUncalibratedMagnetometer();
        if (uncalibratedMagnetometer == null) {
            labelOutput = "not supported";
            return;
        }

        double y = uncalibratedMagnetometer.Y;
        labelOutput = y.ToString();
    }

    public const string BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Z = "sensor-api-inprocess-uncalibrated-magnetometer-get-z-property";
    private void UncalibratedMagnetometerGetZ() {
        using IUncalibratedMagnetometerInProcess? uncalibratedMagnetometer = SensorAPI.CreateUncalibratedMagnetometer();
        if (uncalibratedMagnetometer == null) {
            labelOutput = "not supported";
            return;
        }

        double z = uncalibratedMagnetometer.Z;
        labelOutput = z.ToString();
    }

    public const string BUTTON_UNCALIBRATED_MAGNETOMETER_GET_X_BIAS = "sensor-api-inprocess-uncalibrated-magnetometer-get-x-bias-property";
    private void UncalibratedMagnetometerGetXBias() {
        using IUncalibratedMagnetometerInProcess? uncalibratedMagnetometer = SensorAPI.CreateUncalibratedMagnetometer();
        if (uncalibratedMagnetometer == null) {
            labelOutput = "not supported";
            return;
        }

        double x = uncalibratedMagnetometer.XBias;
        labelOutput = x.ToString();
    }

    public const string BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Y_BIAS = "sensor-api-inprocess-uncalibrated-magnetometer-get-y-bias-property";
    private void UncalibratedMagnetometerGetYBias() {
        using IUncalibratedMagnetometerInProcess? uncalibratedMagnetometer = SensorAPI.CreateUncalibratedMagnetometer();
        if (uncalibratedMagnetometer == null) {
            labelOutput = "not supported";
            return;
        }

        double y = uncalibratedMagnetometer.YBias;
        labelOutput = y.ToString();
    }

    public const string BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Z_BIAS = "sensor-api-inprocess-uncalibrated-magnetometer-get-z-bias-property";
    private void UncalibratedMagnetometerGetZBias() {
        using IUncalibratedMagnetometerInProcess? uncalibratedMagnetometer = SensorAPI.CreateUncalibratedMagnetometer();
        if (uncalibratedMagnetometer == null) {
            labelOutput = "not supported";
            return;
        }

        double z = uncalibratedMagnetometer.ZBias;
        labelOutput = z.ToString();
    }
}
