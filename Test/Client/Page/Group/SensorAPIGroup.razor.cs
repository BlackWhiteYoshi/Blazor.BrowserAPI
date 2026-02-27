using Microsoft.AspNetCore.Components;
using System.Numerics;
using System.Text.Json;

namespace BrowserAPI.Test.Client;

public sealed partial class SensorAPIGroup {
    public const string TEST_SENSOR_START = "sensor started";
    public const string TEST_SENSOR_STOP = "sensor stopped";
    public const string TEST_SENSOR_ERROR_EVENT = "error event";
    public const string TEST_SENSOR_ACTIVATE_EVENT = "activate event";
    public const string TEST_SENSOR_READING_EVENT = "reading event";


    [Inject]
    public required ISensorAPI SensorAPI { private get; init; }


    public const string OUTPUT = "sensor-api-output";
    private string output = string.Empty;


    // Sensor Properties

    public const string BUTTON_GET_ACTIVATED_PROPERTY = "sensor-api-get-activated-property";
    private async Task GetActivated_Property() {
        await using IGyroscope? gyroscope = await SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            output = "not supported";
            return;
        }

        bool activated = await gyroscope.Activated;
        output = activated.ToString();
    }

    public const string BUTTON_GET_ACTIVATED_METHOD = "sensor-api-get-activated-method";
    private async Task GetActivated_Method() {
        await using IGyroscope? gyroscope = await SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            output = "not supported";
            return;
        }

        bool activated = await gyroscope.GetActivated(CancellationToken.None);
        output = activated.ToString();
    }


    public const string BUTTON_GET_HAS_READING_PROPERTY = "sensor-api-get-has-reading-property";
    private async Task GetHasReading_Property() {
        await using IGyroscope? gyroscope = await SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            output = "not supported";
            return;
        }

        bool hasReading = await gyroscope.HasReading;
        output = hasReading.ToString();
    }

    public const string BUTTON_GET_HAS_READING_METHOD = "sensor-api-get-has-reading-method";
    private async Task GetHasReading_Method() {
        await using IGyroscope? gyroscope = await SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            output = "not supported";
            return;
        }

        bool hasReading = await gyroscope.GetHasReading(CancellationToken.None);
        output = hasReading.ToString();
    }


    public const string BUTTON_GET_TIMESTAMP_PROPERTY = "sensor-api-get-timestamp-property";
    private async Task GetTimestamp_Property() {
        await using IGyroscope? gyroscope = await SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            output = "not supported";
            return;
        }

        double timestamp = await gyroscope.Timestamp;
        output = timestamp.ToString();
    }

    public const string BUTTON_GET_TIMESTAMP_METHOD = "sensor-api-get-timestamp-method";
    private async Task GetTimestamp_Method() {
        await using IGyroscope? gyroscope = await SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            output = "not supported";
            return;
        }

        double timestamp = await gyroscope.GetTimestamp(CancellationToken.None);
        output = timestamp.ToString();
    }


    // Sensor Methods

    public const string BUTTON_START = "sensor-api-start";
    private async Task Start() {
        await using IGyroscope? gyroscope = await SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            output = "not supported";
            return;
        }

        await gyroscope.Start();
        output = TEST_SENSOR_START;
    }

    public const string BUTTON_STOP = "sensor-api-stop";
    private async Task Stop() {
        await using IGyroscope? gyroscope = await SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            output = "not supported";
            return;
        }

        await gyroscope.Stop();
        output = TEST_SENSOR_STOP;
    }


    // Sensor Events

    public const string BUTTON_REGISTER_ON_ERROR = "sensor-api-error-event";
    private async Task RegisterOnError() {
        IGyroscope? gyroscope = await SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            output = "not supported";
            return;
        }

        gyroscope.OnError += OnError;
        void OnError(JsonElement error) {
            output = TEST_SENSOR_ERROR_EVENT;
            StateHasChanged();
            gyroscope.OnError -= OnError;
            _ = gyroscope.DisposeAsync().Preserve();
        }
    }

    public const string BUTTON_REGISTER_ON_ACTIVATE = "sensor-api-activate-event";
    private async Task RegisterOnActivate() {
        IGyroscope? gyroscope = await SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            output = "not supported";
            return;
        }

        gyroscope.OnActivate += OnActivate;
        void OnActivate() {
            output = TEST_SENSOR_ACTIVATE_EVENT;
            StateHasChanged();
            gyroscope.OnActivate -= OnActivate;
            _ = gyroscope.DisposeAsync().Preserve();
        }
    }

    public const string BUTTON_REGISTER_ON_READING = "sensor-api-reading-event";
    private async Task RegisterOnReading() {
        IGyroscope? gyroscope = await SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            output = "not supported";
            return;
        }

        gyroscope.OnReading += OnReading;
        void OnReading() {
            output = TEST_SENSOR_READING_EVENT;
            StateHasChanged();
            gyroscope.OnReading -= OnReading;
            _ = gyroscope.DisposeAsync().Preserve();
        }
    }


    // Window Events

    public const string BUTTON_REGISTER_ON_DEVICE_MOTION = "sensor-api-device-motion-event";
    private void RegisterOnDeviceMotion() {
        SensorAPI.OnDeviceMotion += (DeviceMotionEvent deviceMotionEvent) => {
            output = deviceMotionEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_DEVICE_ORIENTATION = "sensor-api-device-orientation-event";
    private void RegisterOnDeviceOrientation() {
        SensorAPI.OnDeviceOrientation += (DeviceOrientationEvent deviceOrientationEvent) => {
            output = deviceOrientationEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_DEVICE_ORIENTATION_ABSOLUTE = "sensor-api-device-orientation-absolute-event";
    private void RegisterOnDeviceOrientationAbsolute() {
        SensorAPI.OnDeviceOrientationAbsolute += (DeviceOrientationEvent deviceOrientationEvent) => {
            output = deviceOrientationEvent.ToString();
            StateHasChanged();
        };
    }


    // AmbientLightSensor

    public const string BUTTON_AMBIENT_LIGHT_SENSOR_GET_ILLUMINANCE_PROPERTY = "sensor-api-ambient-light-sensor-get-illuminance-property";
    private async Task AmbientLightSensorGetIlluminance_Property() {
        await using IAmbientLightSensor? ambientLightSensor = await SensorAPI.CreateAmbientLightSensor();
        if (ambientLightSensor == null) {
            output = "not supported";
            return;
        }

        double illuminance = await ambientLightSensor.Illuminance;
        output = illuminance.ToString();
    }

    public const string BUTTON_AMBIENT_LIGHT_SENSOR_GET_ILLUMINANCE_METHOD = "sensor-api-ambient-light-sensor-get-illuminance-method";
    private async Task AmbientLightSensorGetIlluminance_Method() {
        await using IAmbientLightSensor? ambientLightSensor = await SensorAPI.CreateAmbientLightSensor();
        if (ambientLightSensor == null) {
            output = "not supported";
            return;
        }

        double illuminance = await ambientLightSensor.GetIlluminance(CancellationToken.None);
        output = illuminance.ToString();
    }


    // Gyroscope

    public const string BUTTON_GYROSCOPE_GET_X_PROPERTY = "sensor-api-gyroscope-get-x-property";
    private async Task GyroscopeGetX_Property() {
        await using IGyroscope? gyroscope = await SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            output = "not supported";
            return;
        }

        double x = await gyroscope.X;
        output = x.ToString();
    }

    public const string BUTTON_GYROSCOPE_GET_X_METHOD = "sensor-api-gyroscope-get-x-method";
    private async Task GyroscopeGetX_Method() {
        await using IGyroscope? gyroscope = await SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            output = "not supported";
            return;
        }

        double x = await gyroscope.GetX(CancellationToken.None);
        output = x.ToString();
    }


    public const string BUTTON_GYROSCOPE_GET_Y_PROPERTY = "sensor-api-gyroscope-get-y-property";
    private async Task GyroscopeGetY_Property() {
        await using IGyroscope? gyroscope = await SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            output = "not supported";
            return;
        }

        double y = await gyroscope.Y;
        output = y.ToString();
    }

    public const string BUTTON_GYROSCOPE_GET_Y_METHOD = "sensor-api-gyroscope-get-y-method";
    private async Task GyroscopeGetY_Method() {
        await using IGyroscope? gyroscope = await SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            output = "not supported";
            return;
        }

        double y = await gyroscope.GetY(CancellationToken.None);
        output = y.ToString();
    }


    public const string BUTTON_GYROSCOPE_GET_Z_PROPERTY = "sensor-api-gyroscope-get-z-property";
    private async Task GyroscopeGetZ_Property() {
        await using IGyroscope? gyroscope = await SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            output = "not supported";
            return;
        }

        double z = await gyroscope.Z;
        output = z.ToString();
    }

    public const string BUTTON_GYROSCOPE_GET_Z_METHOD = "sensor-api-gyroscope-get-z-method";
    private async Task GyroscopeGetZ_Method() {
        await using IGyroscope? gyroscope = await SensorAPI.CreateGyroscope();
        if (gyroscope == null) {
            output = "not supported";
            return;
        }

        double z = await gyroscope.GetZ(CancellationToken.None);
        output = z.ToString();
    }


    // Accelerometer

    public const string BUTTON_ACCELEROMETER_GET_X_PROPERTY = "sensor-api-accelerometer-get-x-property";
    private async Task AccelerometerGetX_Property() {
        await using IAccelerometer? accelerometer = await SensorAPI.CreateAccelerometer();
        if (accelerometer == null) {
            output = "not supported";
            return;
        }

        double x = await accelerometer.X;
        output = x.ToString();
    }

    public const string BUTTON_ACCELEROMETER_GET_X_METHOD = "sensor-api-accelerometer-get-x-method";
    private async Task AccelerometerGetX_Method() {
        await using IAccelerometer? accelerometer = await SensorAPI.CreateAccelerometer();
        if (accelerometer == null) {
            output = "not supported";
            return;
        }

        double x = await accelerometer.GetX(CancellationToken.None);
        output = x.ToString();
    }


    public const string BUTTON_ACCELEROMETER_GET_Y_PROPERTY = "sensor-api-accelerometer-get-y-property";
    private async Task AccelerometerGetY_Property() {
        await using IAccelerometer? accelerometer = await SensorAPI.CreateAccelerometer();
        if (accelerometer == null) {
            output = "not supported";
            return;
        }

        double y = await accelerometer.Y;
        output = y.ToString();
    }

    public const string BUTTON_ACCELEROMETER_GET_Y_METHOD = "sensor-api-accelerometer-get-y-method";
    private async Task AccelerometerGetY_Method() {
        await using IAccelerometer? accelerometer = await SensorAPI.CreateAccelerometer();
        if (accelerometer == null) {
            output = "not supported";
            return;
        }

        double y = await accelerometer.GetY(CancellationToken.None);
        output = y.ToString();
    }


    public const string BUTTON_ACCELEROMETER_GET_Z_PROPERTY = "sensor-api-accelerometer-get-z-property";
    private async Task AccelerometerGetZ_Property() {
        await using IAccelerometer? accelerometer = await SensorAPI.CreateAccelerometer();
        if (accelerometer == null) {
            output = "not supported";
            return;
        }

        double z = await accelerometer.Z;
        output = z.ToString();
    }

    public const string BUTTON_ACCELEROMETER_GET_Z_METHOD = "sensor-api-accelerometer-get-z-method";
    private async Task AccelerometerGetZ_Method() {
        await using IAccelerometer? accelerometer = await SensorAPI.CreateAccelerometer();
        if (accelerometer == null) {
            output = "not supported";
            return;
        }

        double z = await accelerometer.GetZ(CancellationToken.None);
        output = z.ToString();
    }


    // LinearAccelerationSensor

    public const string BUTTON_LINEAR_ACCELERATION_SENSOR_GET_X_PROPERTY = "sensor-api-linear-acceleration-sensor-get-x-property";
    private async Task LinearAccelerationSensorGetX_Property() {
        await using ILinearAccelerationSensor? linearAccelerationSensor = await SensorAPI.CreateLinearAccelerationSensor();
        if (linearAccelerationSensor == null) {
            output = "not supported";
            return;
        }

        double x = await linearAccelerationSensor.X;
        output = x.ToString();
    }

    public const string BUTTON_LINEAR_ACCELERATION_SENSOR_GET_X_METHOD = "sensor-api-linear-acceleration-sensor-get-x-method";
    private async Task LinearAccelerationSensorGetX_Method() {
        await using ILinearAccelerationSensor? linearAccelerationSensor = await SensorAPI.CreateLinearAccelerationSensor();
        if (linearAccelerationSensor == null) {
            output = "not supported";
            return;
        }

        double x = await linearAccelerationSensor.GetX(CancellationToken.None);
        output = x.ToString();
    }


    public const string BUTTON_LINEAR_ACCELERATION_SENSOR_GET_Y_PROPERTY = "sensor-api-linear-acceleration-sensor-get-y-property";
    private async Task LinearAccelerationSensorGetY_Property() {
        await using ILinearAccelerationSensor? linearAccelerationSensor = await SensorAPI.CreateLinearAccelerationSensor();
        if (linearAccelerationSensor == null) {
            output = "not supported";
            return;
        }

        double y = await linearAccelerationSensor.Y;
        output = y.ToString();
    }

    public const string BUTTON_LINEAR_ACCELERATION_SENSOR_GET_Y_METHOD = "sensor-api-linear-acceleration-sensor-get-y-method";
    private async Task LinearAccelerationSensorGetY_Method() {
        await using ILinearAccelerationSensor? linearAccelerationSensor = await SensorAPI.CreateLinearAccelerationSensor();
        if (linearAccelerationSensor == null) {
            output = "not supported";
            return;
        }

        double y = await linearAccelerationSensor.GetY(CancellationToken.None);
        output = y.ToString();
    }


    public const string BUTTON_LINEAR_ACCELERATION_SENSOR_GET_Z_PROPERTY = "sensor-api-linear-acceleration-sensor-get-z-property";
    private async Task LinearAccelerationSensorGetZ_Property() {
        await using ILinearAccelerationSensor? linearAccelerationSensor = await SensorAPI.CreateLinearAccelerationSensor();
        if (linearAccelerationSensor == null) {
            output = "not supported";
            return;
        }

        double z = await linearAccelerationSensor.Z;
        output = z.ToString();
    }

    public const string BUTTON_LINEAR_ACCELERATION_SENSOR_GET_Z_METHOD = "sensor-api-linear-acceleration-sensor-get-z-method";
    private async Task LinearAccelerationSensorGetZ_Method() {
        await using ILinearAccelerationSensor? linearAccelerationSensor = await SensorAPI.CreateLinearAccelerationSensor();
        if (linearAccelerationSensor == null) {
            output = "not supported";
            return;
        }

        double z = await linearAccelerationSensor.GetZ(CancellationToken.None);
        output = z.ToString();
    }


    // GravitySensor

    public const string BUTTON_GRAVITY_SENSOR_GET_X_PROPERTY = "sensor-api-gravity-sensor-get-x-property";
    private async Task GravitySensorGetX_Property() {
        await using IGravitySensor? gravitySensor = await SensorAPI.CreateGravitySensor();
        if (gravitySensor == null) {
            output = "not supported";
            return;
        }

        double x = await gravitySensor.X;
        output = x.ToString();
    }

    public const string BUTTON_GRAVITY_SENSOR_GET_X_METHOD = "sensor-api-gravity-sensor-get-x-method";
    private async Task GravitySensorGetX_Method() {
        await using IGravitySensor? gravitySensor = await SensorAPI.CreateGravitySensor();
        if (gravitySensor == null) {
            output = "not supported";
            return;
        }

        double x = await gravitySensor.GetX(CancellationToken.None);
        output = x.ToString();
    }


    public const string BUTTON_GRAVITY_SENSOR_GET_Y_PROPERTY = "sensor-api-gravity-sensor-get-y-property";
    private async Task GravitySensorGetY_Property() {
        await using IGravitySensor? gravitySensor = await SensorAPI.CreateGravitySensor();
        if (gravitySensor == null) {
            output = "not supported";
            return;
        }

        double y = await gravitySensor.Y;
        output = y.ToString();
    }

    public const string BUTTON_GRAVITY_SENSOR_GET_Y_METHOD = "sensor-api-gravity-sensor-get-y-method";
    private async Task GravitySensorGetY_Method() {
        await using IGravitySensor? gravitySensor = await SensorAPI.CreateGravitySensor();
        if (gravitySensor == null) {
            output = "not supported";
            return;
        }

        double y = await gravitySensor.GetY(CancellationToken.None);
        output = y.ToString();
    }


    public const string BUTTON_GRAVITY_SENSOR_GET_Z_PROPERTY = "sensor-api-gravity-sensor-get-z-property";
    private async Task GravitySensorGetZ_Property() {
        await using IGravitySensor? gravitySensor = await SensorAPI.CreateGravitySensor();
        if (gravitySensor == null) {
            output = "not supported";
            return;
        }

        double z = await gravitySensor.Z;
        output = z.ToString();
    }

    public const string BUTTON_GRAVITY_SENSOR_GET_Z_METHOD = "sensor-api-gravity-sensor-get-z-method";
    private async Task GravitySensorGetZ_Method() {
        await using IGravitySensor? gravitySensor = await SensorAPI.CreateGravitySensor();
        if (gravitySensor == null) {
            output = "not supported";
            return;
        }

        double z = await gravitySensor.GetZ(CancellationToken.None);
        output = z.ToString();
    }


    // AbsoluteOrientationSensor

    public const string BUTTON_ABSOLUTE_ORIENTATION_SENSOR_GET_QUATERNION_PROPERTY = "sensor-api-absolute-orientation-sensor-get-quaternion-property";
    private async Task AbsoluteOrientationSensorGetQuaternion_Property() {
        await using IAbsoluteOrientationSensor? absoluteOrientationSensor = await SensorAPI.CreateAbsoluteOrientationSensor();
        if (absoluteOrientationSensor == null) {
            output = "not supported";
            return;
        }

        Quaternion quaternion = await absoluteOrientationSensor.Quaternion;
        output = quaternion.ToString();
    }

    public const string BUTTON_ABSOLUTE_ORIENTATION_SENSOR_GET_QUATERNION_METHOD = "sensor-api-absolute-orientation-sensor-get-quaternion-method";
    private async Task AbsoluteOrientationSensorGetQuaternion_Method() {
        await using IAbsoluteOrientationSensor? absoluteOrientationSensor = await SensorAPI.CreateAbsoluteOrientationSensor();
        if (absoluteOrientationSensor == null) {
            output = "not supported";
            return;
        }

        Quaternion quaternion = await absoluteOrientationSensor.GetQuaternion(CancellationToken.None);
        output = quaternion.ToString();
    }


    public const string BUTTON_ABSOLUTE_ORIENTATION_SENSOR_POPULATE_MATRIX = "sensor-api-absolute-orientation-sensor-populate-matrix";
    private async Task AbsoluteOrientationSensorPopulateMatrix() {
        await using IAbsoluteOrientationSensor? absoluteOrientationSensor = await SensorAPI.CreateAbsoluteOrientationSensor();
        if (absoluteOrientationSensor == null) {
            output = "not supported";
            return;
        }

        Matrix4x4 rotationMatrix = await absoluteOrientationSensor.PopulateMatrix();
        output = rotationMatrix.ToString();
    }


    // RelativeOrientationSensor

    public const string BUTTON_RELATIVE_ORIENTATION_SENSOR_GET_QUATERNION_PROPERTY = "sensor-api-relative-orientation-sensor-get-quaternion-property";
    private async Task RelativeOrientationSensorGetQuaternion_Property() {
        await using IRelativeOrientationSensor? relativeOrientationSensor = await SensorAPI.CreateRelativeOrientationSensor();
        if (relativeOrientationSensor == null) {
            output = "not supported";
            return;
        }

        Quaternion quaternion = await relativeOrientationSensor.Quaternion;
        output = quaternion.ToString();
    }

    public const string BUTTON_RELATIVE_ORIENTATION_SENSOR_GET_QUATERNION_METHOD = "sensor-api-relative-orientation-sensor-get-quaternion-method";
    private async Task RelativeOrientationSensorGetQuaternion_Method() {
        await using IRelativeOrientationSensor? relativeOrientationSensor = await SensorAPI.CreateRelativeOrientationSensor();
        if (relativeOrientationSensor == null) {
            output = "not supported";
            return;
        }

        Quaternion quaternion = await relativeOrientationSensor.GetQuaternion(CancellationToken.None);
        output = quaternion.ToString();
    }


    public const string BUTTON_RELATIVE_ORIENTATION_SENSOR_POPULATE_MATRIX = "sensor-api-relative-orientation-sensor-populate-matrix";
    private async Task RelativeOrientationSensorPopulateMatrix() {
        await using IRelativeOrientationSensor? relativeOrientationSensor = await SensorAPI.CreateRelativeOrientationSensor();
        if (relativeOrientationSensor == null) {
            output = "not supported";
            return;
        }

        Matrix4x4 rotationMatrix = await relativeOrientationSensor.PopulateMatrix();
        output = rotationMatrix.ToString();
    }


    // Magnetometer

    public const string BUTTON_MAGNETOMETER_GET_X_PROPERTY = "sensor-api-magnetometer-get-x-property";
    private async Task MagnetometerGetX_Property() {
        await using IMagnetometer? magnetometer = await SensorAPI.CreateMagnetometer();
        if (magnetometer == null) {
            output = "not supported";
            return;
        }

        double x = await magnetometer.X;
        output = x.ToString();
    }

    public const string BUTTON_MAGNETOMETER_GET_X_METHOD = "sensor-api-magnetometer-get-x-method";
    private async Task MagnetometerGetX_Method() {
        await using IMagnetometer? magnetometer = await SensorAPI.CreateMagnetometer();
        if (magnetometer == null) {
            output = "not supported";
            return;
        }

        double x = await magnetometer.GetX(CancellationToken.None);
        output = x.ToString();
    }


    public const string BUTTON_MAGNETOMETER_GET_Y_PROPERTY = "sensor-api-magnetometer-get-y-property";
    private async Task MagnetometerGetY_Property() {
        await using IMagnetometer? magnetometer = await SensorAPI.CreateMagnetometer();
        if (magnetometer == null) {
            output = "not supported";
            return;
        }

        double y = await magnetometer.Y;
        output = y.ToString();
    }

    public const string BUTTON_MAGNETOMETER_GET_Y_METHOD = "sensor-api-magnetometer-get-y-method";
    private async Task MagnetometerGetY_Method() {
        await using IMagnetometer? magnetometer = await SensorAPI.CreateMagnetometer();
        if (magnetometer == null) {
            output = "not supported";
            return;
        }

        double y = await magnetometer.GetY(CancellationToken.None);
        output = y.ToString();
    }


    public const string BUTTON_MAGNETOMETER_GET_Z_PROPERTY = "sensor-api-magnetometer-get-z-property";
    private async Task MagnetometerGetZ_Property() {
        await using IMagnetometer? magnetometer = await SensorAPI.CreateMagnetometer();
        if (magnetometer == null) {
            output = "not supported";
            return;
        }

        double z = await magnetometer.Z;
        output = z.ToString();
    }

    public const string BUTTON_MAGNETOMETER_GET_Z_METHOD = "sensor-api-magnetometer-get-z-method";
    private async Task MagnetometerGetZ_Method() {
        await using IMagnetometer? magnetometer = await SensorAPI.CreateMagnetometer();
        if (magnetometer == null) {
            output = "not supported";
            return;
        }

        double z = await magnetometer.GetZ(CancellationToken.None);
        output = z.ToString();
    }


    // UncalibratedMagnetometer

    public const string BUTTON_UNCALIBRATED_MAGNETOMETER_GET_X_PROPERTY = "sensor-api-uncalibrated-magnetometer-get-x-property";
    private async Task UncalibratedMagnetometerGetX_Property() {
        await using IUncalibratedMagnetometer? uncalibratedMagnetometer = await SensorAPI.CreateUncalibratedMagnetometer();
        if (uncalibratedMagnetometer == null) {
            output = "not supported";
            return;
        }

        double x = await uncalibratedMagnetometer.X;
        output = x.ToString();
    }

    public const string BUTTON_UNCALIBRATED_MAGNETOMETER_GET_X_METHOD = "sensor-api-uncalibrated-magnetometer-get-x-method";
    private async Task UncalibratedMagnetometerGetX_Method() {
        await using IUncalibratedMagnetometer? uncalibratedMagnetometer = await SensorAPI.CreateUncalibratedMagnetometer();
        if (uncalibratedMagnetometer == null) {
            output = "not supported";
            return;
        }

        double x = await uncalibratedMagnetometer.GetX(CancellationToken.None);
        output = x.ToString();
    }


    public const string BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Y_PROPERTY = "sensor-api-uncalibrated-magnetometer-get-y-property";
    private async Task UncalibratedMagnetometerGetY_Property() {
        await using IUncalibratedMagnetometer? uncalibratedMagnetometer = await SensorAPI.CreateUncalibratedMagnetometer();
        if (uncalibratedMagnetometer == null) {
            output = "not supported";
            return;
        }

        double y = await uncalibratedMagnetometer.Y;
        output = y.ToString();
    }

    public const string BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Y_METHOD = "sensor-api-uncalibrated-magnetometer-get-y-method";
    private async Task UncalibratedMagnetometerGetY_Method() {
        await using IUncalibratedMagnetometer? uncalibratedMagnetometer = await SensorAPI.CreateUncalibratedMagnetometer();
        if (uncalibratedMagnetometer == null) {
            output = "not supported";
            return;
        }

        double y = await uncalibratedMagnetometer.GetY(CancellationToken.None);
        output = y.ToString();
    }


    public const string BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Z_PROPERTY = "sensor-api-uncalibrated-magnetometer-get-z-property";
    private async Task UncalibratedMagnetometerGetZ_Property() {
        await using IUncalibratedMagnetometer? uncalibratedMagnetometer = await SensorAPI.CreateUncalibratedMagnetometer();
        if (uncalibratedMagnetometer == null) {
            output = "not supported";
            return;
        }

        double z = await uncalibratedMagnetometer.Z;
        output = z.ToString();
    }

    public const string BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Z_METHOD = "sensor-api-uncalibrated-magnetometer-get-z-method";
    private async Task UncalibratedMagnetometerGetZ_Method() {
        await using IUncalibratedMagnetometer? uncalibratedMagnetometer = await SensorAPI.CreateUncalibratedMagnetometer();
        if (uncalibratedMagnetometer == null) {
            output = "not supported";
            return;
        }

        double z = await uncalibratedMagnetometer.GetZ(CancellationToken.None);
        output = z.ToString();
    }


    public const string BUTTON_UNCALIBRATED_MAGNETOMETER_GET_X_BIAS_PROPERTY = "sensor-api-uncalibrated-magnetometer-get-x-bias-property";
    private async Task UncalibratedMagnetometerGetXBias_Property() {
        await using IUncalibratedMagnetometer? uncalibratedMagnetometer = await SensorAPI.CreateUncalibratedMagnetometer();
        if (uncalibratedMagnetometer == null) {
            output = "not supported";
            return;
        }

        double x = await uncalibratedMagnetometer.XBias;
        output = x.ToString();
    }

    public const string BUTTON_UNCALIBRATED_MAGNETOMETER_GET_X_BIAS_METHOD = "sensor-api-uncalibrated-magnetometer-get-x-bias-method";
    private async Task UncalibratedMagnetometerGetXBias_Method() {
        await using IUncalibratedMagnetometer? uncalibratedMagnetometer = await SensorAPI.CreateUncalibratedMagnetometer();
        if (uncalibratedMagnetometer == null) {
            output = "not supported";
            return;
        }

        double x = await uncalibratedMagnetometer.GetXBias(CancellationToken.None);
        output = x.ToString();
    }


    public const string BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Y_BIAS_PROPERTY = "sensor-api-uncalibrated-magnetometer-get-y-bias-property";
    private async Task UncalibratedMagnetometerGetYBias_Property() {
        await using IUncalibratedMagnetometer? uncalibratedMagnetometer = await SensorAPI.CreateUncalibratedMagnetometer();
        if (uncalibratedMagnetometer == null) {
            output = "not supported";
            return;
        }

        double y = await uncalibratedMagnetometer.YBias;
        output = y.ToString();
    }

    public const string BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Y_BIAS_METHOD = "sensor-api-uncalibrated-magnetometer-get-y-bias-method";
    private async Task UncalibratedMagnetometerGetYBias_Method() {
        await using IUncalibratedMagnetometer? uncalibratedMagnetometer = await SensorAPI.CreateUncalibratedMagnetometer();
        if (uncalibratedMagnetometer == null) {
            output = "not supported";
            return;
        }

        double y = await uncalibratedMagnetometer.GetYBias(CancellationToken.None);
        output = y.ToString();
    }


    public const string BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Z_BIAS_PROPERTY = "sensor-api-uncalibrated-magnetometer-get-z-bias-property";
    private async Task UncalibratedMagnetometerGetZBias_Property() {
        await using IUncalibratedMagnetometer? uncalibratedMagnetometer = await SensorAPI.CreateUncalibratedMagnetometer();
        if (uncalibratedMagnetometer == null) {
            output = "not supported";
            return;
        }

        double z = await uncalibratedMagnetometer.ZBias;
        output = z.ToString();
    }

    public const string BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Z_BIAS_METHOD = "sensor-api-uncalibrated-magnetometer-get-z-bias-method";
    private async Task UncalibratedMagnetometerGetZBias_Method() {
        await using IUncalibratedMagnetometer? uncalibratedMagnetometer = await SensorAPI.CreateUncalibratedMagnetometer();
        if (uncalibratedMagnetometer == null) {
            output = "not supported";
            return;
        }

        double z = await uncalibratedMagnetometer.GetZBias(CancellationToken.None);
        output = z.ToString();
    }
}
