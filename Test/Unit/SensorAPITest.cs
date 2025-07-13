using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class SensorAPITest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    public override async Task SetUp() {
        await base.SetUp();
        await BrowserContext.GrantPermissionsAsync(["ambient-light-sensor", "gyroscope", "accelerometer", "magnetometer"]);
    }


    // Sensor Properties

    [Test]
    public async Task GetActivated_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_GET_ACTIVATED_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task GetActivated_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_GET_ACTIVATED_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    public async Task GetHasReading_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_GET_HAS_READING_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task GetHasReading_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_GET_HAS_READING_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    public async Task GetTimestamp_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_GET_TIMESTAMP_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task GetTimestamp_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_GET_TIMESTAMP_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // Sensor Methods

    [Test]
    public async Task Start() {
        await ExecuteTest(SensorAPIGroup.BUTTON_START);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(SensorAPIGroup.TEST_SENSOR_START);
    }

    [Test]
    public async Task Stop() {
        await ExecuteTest(SensorAPIGroup.BUTTON_STOP);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(SensorAPIGroup.TEST_SENSOR_STOP);
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
        await ExecuteTest(SensorAPIGroup.BUTTON_REGISTER_ON_ERROR);
        await Page.EvaluateAsync("sensor.dispatchEvent(new Event('error'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
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
        await ExecuteTest(SensorAPIGroup.BUTTON_REGISTER_ON_ACTIVATE);
        await Page.EvaluateAsync("sensor.dispatchEvent(new Event('activate'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
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
        await ExecuteTest(SensorAPIGroup.BUTTON_REGISTER_ON_READING);
        await Page.EvaluateAsync("sensor.dispatchEvent(new Event('reading'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(SensorAPIGroup.TEST_SENSOR_READING_EVENT);
    }


    // AmbientLightSensor

    [Test]
    public async Task AmbientLightSensorGetIlluminance_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_AMBIENT_LIGHT_SENSOR_GET_ILLUMINANCE_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task AmbientLightSensorGetIlluminance_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_AMBIENT_LIGHT_SENSOR_GET_ILLUMINANCE_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // Gyroscope

    [Test]
    public async Task GyroscopeGetX_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_GYROSCOPE_GET_X_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task GyroscopeGetX_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_GYROSCOPE_GET_X_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    public async Task GyroscopeGetY_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_GYROSCOPE_GET_Y_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task GyroscopeGetY_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_GYROSCOPE_GET_Y_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    public async Task GyroscopeGetZ_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_GYROSCOPE_GET_Z_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task GyroscopeGetZ_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_GYROSCOPE_GET_Z_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // Accelerometer

    [Test]
    public async Task AccelerometerGetX_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_ACCELEROMETER_GET_X_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task AccelerometerGetX_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_ACCELEROMETER_GET_X_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    public async Task AccelerometerGetY_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_ACCELEROMETER_GET_Y_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task AccelerometerGetY_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_ACCELEROMETER_GET_Y_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    public async Task AccelerometerGetZ_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_ACCELEROMETER_GET_Z_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task AccelerometerGetZ_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_ACCELEROMETER_GET_Z_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // LinearAccelerationSensor

    [Test]
    public async Task LinearAccelerationSensorGetX_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_LINEAR_ACCELERATION_SENSOR_GET_X_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task LinearAccelerationSensorGetX_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_LINEAR_ACCELERATION_SENSOR_GET_X_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    public async Task LinearAccelerationSensorGetY_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_LINEAR_ACCELERATION_SENSOR_GET_Y_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task LinearAccelerationSensorGetY_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_LINEAR_ACCELERATION_SENSOR_GET_Y_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    public async Task LinearAccelerationSensorGetZ_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_LINEAR_ACCELERATION_SENSOR_GET_Z_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task LinearAccelerationSensorGetZ_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_LINEAR_ACCELERATION_SENSOR_GET_Z_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // GravitySensor

    [Test]
    public async Task GravitySensorGetX_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_GRAVITY_SENSOR_GET_X_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task GravitySensorGetX_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_GRAVITY_SENSOR_GET_X_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    public async Task GravitySensorGetY_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_GRAVITY_SENSOR_GET_Y_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task GravitySensorGetY_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_GRAVITY_SENSOR_GET_Y_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    public async Task GravitySensorGetZ_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_GRAVITY_SENSOR_GET_Z_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task GravitySensorGetZ_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_GRAVITY_SENSOR_GET_Z_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // AbsoluteOrientationSensor

    [Test]
    public async Task AbsoluteOrientationSensorGetQuaternion_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_ABSOLUTE_ORIENTATION_SENSOR_GET_QUATERNION_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task AbsoluteOrientationSensorGetQuaternion_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_ABSOLUTE_ORIENTATION_SENSOR_GET_QUATERNION_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    public async Task AbsoluteOrientationSensorPopulateMatrix() {
        await ExecuteTest(SensorAPIGroup.BUTTON_ABSOLUTE_ORIENTATION_SENSOR_POPULATE_MATRIX);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // RelativeOrientationSensor

    [Test]
    public async Task RelativeOrientationSensorGetQuaternion_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_RELATIVE_ORIENTATION_SENSOR_GET_QUATERNION_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task RelativeOrientationSensorGetQuaternion_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_RELATIVE_ORIENTATION_SENSOR_GET_QUATERNION_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    public async Task RelativeOrientationSensorPopulateMatrix() {
        await ExecuteTest(SensorAPIGroup.BUTTON_RELATIVE_ORIENTATION_SENSOR_POPULATE_MATRIX);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // Magnetometer

    [Test]
    public async Task MagnetometerGetX_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_MAGNETOMETER_GET_X_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task MagnetometerGetX_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_MAGNETOMETER_GET_X_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    public async Task MagnetometerGetY_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_MAGNETOMETER_GET_Y_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task MagnetometerGetY_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_MAGNETOMETER_GET_Y_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    public async Task MagnetometerGetZ_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_MAGNETOMETER_GET_Z_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task MagnetometerGetZ_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_MAGNETOMETER_GET_Z_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // UncalibratedMagnetometer

    [Test]
    public async Task UncalibratedMagnetometerGetX_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_X_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task UncalibratedMagnetometerGetX_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_X_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    public async Task UncalibratedMagnetometerGetY_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Y_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task UncalibratedMagnetometerGetY_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Y_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    public async Task UncalibratedMagnetometerGetZ_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Z_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task UncalibratedMagnetometerGetZ_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Z_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    public async Task UncalibratedMagnetometerGetXBias_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_X_BIAS_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task UncalibratedMagnetometerGetXBias_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_X_BIAS_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    public async Task UncalibratedMagnetometerGetYBias_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Y_BIAS_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task UncalibratedMagnetometerGetYBias_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Y_BIAS_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    public async Task UncalibratedMagnetometerGetZBias_Property() {
        await ExecuteTest(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Z_BIAS_PROPERTY);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    public async Task UncalibratedMagnetometerGetZBias_Method() {
        await ExecuteTest(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Z_BIAS_METHOD);

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }
}
