using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class SensorAPIInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    public override async Task InitializeAsync() {
        await base.InitializeAsync();
        await BrowserContext.GrantPermissionsAsync(["ambient-light-sensor", "gyroscope", "accelerometer", "magnetometer"]);
    }


    // Sensor Properties

    [Test]
    public async Task GetActivated() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_GET_ACTIVATED);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task GetHasReading() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_GET_HAS_READING);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task GetTimestamp() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_GET_TIMESTAMP);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // Sensor Methods

    [Test]
    public async Task Start() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_START);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(SensorAPIInProcessGroup.TEST_SENSOR_START);
    }

    [Test]
    public async Task Stop() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_STOP);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(SensorAPIInProcessGroup.TEST_SENSOR_STOP);
    }


    // Sensor Events

    [Test]
    public async Task RegisterOnError() {
        await Page.EvaluateAsync("""
            var sensor;

            const OriginalGyroscope = Gyroscope;
            window.Gyroscope = function (options) {
                const instance = new OriginalGyroscope(options);
                sensor = instance;
                return instance;
            };
            Gyroscope.prototype = OriginalGyroscope.prototype;
            Object.setPrototypeOf(Gyroscope, OriginalGyroscope);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_REGISTER_ON_ERROR);
        await Page.EvaluateAsync("sensor.dispatchEvent(new Event('error'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(SensorAPIGroup.TEST_SENSOR_ERROR_EVENT);
    }

    [Test]
    public async Task RegisterOnActivate() {
        await Page.EvaluateAsync("""
            var sensor;

            const OriginalGyroscope = Gyroscope;
            window.Gyroscope = function (options) {
                const instance = new OriginalGyroscope(options);
                sensor = instance;
                return instance;
            };
            Gyroscope.prototype = OriginalGyroscope.prototype;
            Object.setPrototypeOf(Gyroscope, OriginalGyroscope);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_REGISTER_ON_ACTIVATE);
        await Page.EvaluateAsync("sensor.dispatchEvent(new Event('activate'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(SensorAPIGroup.TEST_SENSOR_ACTIVATE_EVENT);
    }

    [Test]
    public async Task RegisterOnReading() {
        await Page.EvaluateAsync("""
            var sensor;

            const OriginalGyroscope = Gyroscope;
            window.Gyroscope = function (options) {
                const instance = new OriginalGyroscope(options);
                sensor = instance;
                return instance;
            };
            Gyroscope.prototype = OriginalGyroscope.prototype;
            Object.setPrototypeOf(Gyroscope, OriginalGyroscope);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_REGISTER_ON_READING);
        await Page.EvaluateAsync("sensor.dispatchEvent(new Event('reading'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(SensorAPIGroup.TEST_SENSOR_READING_EVENT);
    }


    // Window Events

    [Test]
    public async Task RegisterOnDeviceMotion() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_REGISTER_ON_DEVICE_MOTION);
        await Page.EvaluateAsync("""
            const event = new Event("devicemotion");
            event.acceleration = { x: 1, y: 2, z: 3 };
            event.accelerationIncludingGravity = { x: 4, y: 5, z: 6 };
            event.rotationRate = { alpha: 7, beta: 8, gamma: 9 };
            event.interval = 10;
            window.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(nameof(DeviceMotionEvent));
    }

    [Test]
    public async Task RegisterOnDeviceOrientation() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_REGISTER_ON_DEVICE_ORIENTATION);
        await Page.EvaluateAsync("""
            const event = new Event("deviceorientation");
            event.absolute = false;
            event.alpha = 1;
            event.beta = 2;
            event.gamma = 3;
            window.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(nameof(DeviceOrientationEvent));
    }

    [Test]
    public async Task RegisterOnDeviceOrientationAbsolute() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_REGISTER_ON_DEVICE_ORIENTATION_ABSOLUTE);
        await Page.EvaluateAsync("""
            const event = new Event("deviceorientationabsolute");
            event.absolute = true;
            event.alpha = 1;
            event.beta = 2;
            event.gamma = 3;
            window.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(nameof(DeviceOrientationEvent));
    }


    // AmbientLightSensor

    [Test]
    public async Task AmbientLightSensorGetIlluminance() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_AMBIENT_LIGHT_SENSOR_GET_ILLUMINANCE);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // Gyroscope

    [Test]
    public async Task GyroscopeGetX() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_GYROSCOPE_GET_X);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task GyroscopeGetY() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_GYROSCOPE_GET_Y);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task GyroscopeGetZ() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_GYROSCOPE_GET_Z);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // Accelerometer

    [Test]
    public async Task AccelerometerGetX() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_ACCELEROMETER_GET_X);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task AccelerometerGetY() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_ACCELEROMETER_GET_Y);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task AccelerometerGetZ() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_ACCELEROMETER_GET_Z);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // LinearAccelerationSensor

    [Test]
    public async Task LinearAccelerationSensorGetX() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_LINEAR_ACCELERATION_SENSOR_GET_X);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task LinearAccelerationSensorGetY() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_LINEAR_ACCELERATION_SENSOR_GET_Y);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task LinearAccelerationSensorGetZ() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_LINEAR_ACCELERATION_SENSOR_GET_Z);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // GravitySensor

    [Test]
    public async Task GravitySensorGetX() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_GRAVITY_SENSOR_GET_X);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task GravitySensorGetY() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_GRAVITY_SENSOR_GET_Y);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task GravitySensorGetZ() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_GRAVITY_SENSOR_GET_Z);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // AbsoluteOrientationSensor

    [Test]
    public async Task AbsoluteOrientationSensorGetQuaternion() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_ABSOLUTE_ORIENTATION_SENSOR_GET_QUATERNION);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task AbsoluteOrientationSensorPopulateMatrix() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_ABSOLUTE_ORIENTATION_SENSOR_POPULATE_MATRIX);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // RelativeOrientationSensor

    [Test]
    public async Task RelativeOrientationSensorGetQuaternion() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_RELATIVE_ORIENTATION_SENSOR_GET_QUATERNION);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task RelativeOrientationSensorPopulateMatrix() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_RELATIVE_ORIENTATION_SENSOR_POPULATE_MATRIX);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // Magnetometer

    [Test]
    public async Task MagnetometerGetX() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_MAGNETOMETER_GET_X);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task MagnetometerGetY() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_MAGNETOMETER_GET_Y);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task MagnetometerGetZ() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_MAGNETOMETER_GET_Z);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // UncalibratedMagnetometer

    [Test]
    public async Task UncalibratedMagnetometerGetX() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_X);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task UncalibratedMagnetometerGetY() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Y);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task UncalibratedMagnetometerGetZ() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Z);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task UncalibratedMagnetometerGetXBias() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_X_BIAS);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task UncalibratedMagnetometerGetYBias() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Y_BIAS);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task UncalibratedMagnetometerGetZBias() {
        await ExecuteTest(SensorAPIInProcessGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Z_BIAS);

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }
}
