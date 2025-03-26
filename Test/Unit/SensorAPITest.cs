using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class SensorAPITest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    public override async Task InitializeAsync() {
        await base.InitializeAsync();
        await Context.GrantPermissionsAsync(["ambient-light-sensor", "gyroscope", "accelerometer", "magnetometer"]);
    }


    // Sensor Properties

    [Test]
    [Retry(3)]
    public async Task GetActivated_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_GET_ACTIVATED_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task GetActivated_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_GET_ACTIVATED_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    [Retry(3)]
    public async Task GetHasReading_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_GET_HAS_READING_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task GetHasReading_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_GET_HAS_READING_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    [Retry(3)]
    public async Task GetTimestamp_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_GET_TIMESTAMP_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task GetTimestamp_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_GET_TIMESTAMP_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // Sensor Methods

    [Test]
    [Retry(3)]
    public async Task Start() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_START).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task Stop() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_STOP).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsEmpty();
    }


    // Sensor Events

    [Test]
    [Retry(3)]
    public async Task RegisterOnError() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_REGISTER_ON_ERROR).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task RegisterOnActivate() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_REGISTER_ON_ACTIVATE).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task RegisterOnReading() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_REGISTER_ON_READING).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsEmpty();
    }


    // AmbientLightSensor

    [Test]
    [Retry(3)]
    public async Task AmbientLightSensorGetIlluminance_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_AMBIENT_LIGHT_SENSOR_GET_ILLUMINANCE_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task AmbientLightSensorGetIlluminance_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_AMBIENT_LIGHT_SENSOR_GET_ILLUMINANCE_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // Gyroscope

    [Test]
    [Retry(3)]
    public async Task GyroscopeGetX_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_GYROSCOPE_GET_X_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task GyroscopeGetX_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_GYROSCOPE_GET_X_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    [Retry(3)]
    public async Task GyroscopeGetY_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_GYROSCOPE_GET_Y_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task GyroscopeGetY_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_GYROSCOPE_GET_Y_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    [Retry(3)]
    public async Task GyroscopeGetZ_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_GYROSCOPE_GET_Z_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task GyroscopeGetZ_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_GYROSCOPE_GET_Z_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // Accelerometer

    [Test]
    [Retry(3)]
    public async Task AccelerometerGetX_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_ACCELEROMETER_GET_X_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task AccelerometerGetX_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_ACCELEROMETER_GET_X_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    [Retry(3)]
    public async Task AccelerometerGetY_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_ACCELEROMETER_GET_Y_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task AccelerometerGetY_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_ACCELEROMETER_GET_Y_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    [Retry(3)]
    public async Task AccelerometerGetZ_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_ACCELEROMETER_GET_Z_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task AccelerometerGetZ_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_ACCELEROMETER_GET_Z_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // LinearAccelerationSensor

    [Test]
    [Retry(3)]
    public async Task LinearAccelerationSensorGetX_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_LINEAR_ACCELERATION_SENSOR_GET_X_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task LinearAccelerationSensorGetX_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_LINEAR_ACCELERATION_SENSOR_GET_X_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    [Retry(3)]
    public async Task LinearAccelerationSensorGetY_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_LINEAR_ACCELERATION_SENSOR_GET_Y_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task LinearAccelerationSensorGetY_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_LINEAR_ACCELERATION_SENSOR_GET_Y_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    [Retry(3)]
    public async Task LinearAccelerationSensorGetZ_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_LINEAR_ACCELERATION_SENSOR_GET_Z_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task LinearAccelerationSensorGetZ_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_LINEAR_ACCELERATION_SENSOR_GET_Z_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // GravitySensor

    [Test]
    [Retry(3)]
    public async Task GravitySensorGetX_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_GRAVITY_SENSOR_GET_X_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task GravitySensorGetX_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_GRAVITY_SENSOR_GET_X_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    [Retry(3)]
    public async Task GravitySensorGetY_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_GRAVITY_SENSOR_GET_Y_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task GravitySensorGetY_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_GRAVITY_SENSOR_GET_Y_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    [Retry(3)]
    public async Task GravitySensorGetZ_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_GRAVITY_SENSOR_GET_Z_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task GravitySensorGetZ_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_GRAVITY_SENSOR_GET_Z_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // AbsoluteOrientationSensor

    [Test]
    [Retry(3)]
    public async Task AbsoluteOrientationSensorGetQuaternion_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_ABSOLUTE_ORIENTATION_SENSOR_GET_QUATERNION_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task AbsoluteOrientationSensorGetQuaternion_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_ABSOLUTE_ORIENTATION_SENSOR_GET_QUATERNION_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    [Retry(3)]
    public async Task AbsoluteOrientationSensorPopulateMatrix() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_ABSOLUTE_ORIENTATION_SENSOR_POPULATE_MATRIX).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // RelativeOrientationSensor

    [Test]
    [Retry(3)]
    public async Task RelativeOrientationSensorGetQuaternion_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_RELATIVE_ORIENTATION_SENSOR_GET_QUATERNION_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task RelativeOrientationSensorGetQuaternion_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_RELATIVE_ORIENTATION_SENSOR_GET_QUATERNION_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    [Retry(3)]
    public async Task RelativeOrientationSensorPopulateMatrix() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_RELATIVE_ORIENTATION_SENSOR_POPULATE_MATRIX).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // Magnetometer

    [Test]
    [Retry(3)]
    public async Task MagnetometerGetX_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_MAGNETOMETER_GET_X_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task MagnetometerGetX_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_MAGNETOMETER_GET_X_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    [Retry(3)]
    public async Task MagnetometerGetY_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_MAGNETOMETER_GET_Y_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task MagnetometerGetY_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_MAGNETOMETER_GET_Y_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    [Retry(3)]
    public async Task MagnetometerGetZ_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_MAGNETOMETER_GET_Z_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task MagnetometerGetZ_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_MAGNETOMETER_GET_Z_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // UncalibratedMagnetometer

    [Test]
    [Retry(3)]
    public async Task UncalibratedMagnetometerGetX_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_X_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task UncalibratedMagnetometerGetX_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_X_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    [Retry(3)]
    public async Task UncalibratedMagnetometerGetY_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Y_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task UncalibratedMagnetometerGetY_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Y_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    [Retry(3)]
    public async Task UncalibratedMagnetometerGetZ_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Z_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task UncalibratedMagnetometerGetZ_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Z_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    [Retry(3)]
    public async Task UncalibratedMagnetometerGetXBias_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_X_BIAS_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task UncalibratedMagnetometerGetXBias_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_X_BIAS_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    [Retry(3)]
    public async Task UncalibratedMagnetometerGetYBias_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Y_BIAS_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task UncalibratedMagnetometerGetYBias_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Y_BIAS_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    [Test]
    [Retry(3)]
    public async Task UncalibratedMagnetometerGetZBias_Property() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Z_BIAS_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task UncalibratedMagnetometerGetZBias_Method() {
        await Page.GetByTestId(SensorAPIGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Z_BIAS_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }
}
