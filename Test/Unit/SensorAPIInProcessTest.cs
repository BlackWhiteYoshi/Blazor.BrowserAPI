using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class SensorAPIInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    public override async Task InitializeAsync() {
        await base.InitializeAsync();
        await Context.GrantPermissionsAsync(["ambient-light-sensor", "gyroscope", "accelerometer", "magnetometer"]);
    }


    // Sensor Properties

    [Test]
    [Retry(3)]
    public async Task GetActivated() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_GET_ACTIVATED).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task GetHasReading() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_GET_HAS_READING).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task GetTimestamp() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_GET_TIMESTAMP).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // Sensor Methods

    [Test]
    [Retry(3)]
    public async Task Start() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_START).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task Stop() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_STOP).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsEmpty();
    }


    // Sensor Events

    [Test]
    [Retry(3)]
    public async Task RegisterOnError() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_REGISTER_ON_ERROR).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task RegisterOnActivate() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_REGISTER_ON_ACTIVATE).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task RegisterOnReading() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_REGISTER_ON_READING).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsEmpty();
    }


    // AmbientLightSensor

    [Test]
    [Retry(3)]
    public async Task AmbientLightSensorGetIlluminance() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_AMBIENT_LIGHT_SENSOR_GET_ILLUMINANCE).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // Gyroscope

    [Test]
    [Retry(3)]
    public async Task GyroscopeGetX() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_GYROSCOPE_GET_X).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task GyroscopeGetY() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_GYROSCOPE_GET_Y).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task GyroscopeGetZ() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_GYROSCOPE_GET_Z).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // Accelerometer

    [Test]
    [Retry(3)]
    public async Task AccelerometerGetX() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_ACCELEROMETER_GET_X).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task AccelerometerGetY() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_ACCELEROMETER_GET_Y).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task AccelerometerGetZ() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_ACCELEROMETER_GET_Z).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // LinearAccelerationSensor

    [Test]
    [Retry(3)]
    public async Task LinearAccelerationSensorGetX() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_LINEAR_ACCELERATION_SENSOR_GET_X).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task LinearAccelerationSensorGetY() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_LINEAR_ACCELERATION_SENSOR_GET_Y).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task LinearAccelerationSensorGetZ() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_LINEAR_ACCELERATION_SENSOR_GET_Z).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // GravitySensor

    [Test]
    [Retry(3)]
    public async Task GravitySensorGetX() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_GRAVITY_SENSOR_GET_X).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task GravitySensorGetY() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_GRAVITY_SENSOR_GET_Y).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task GravitySensorGetZ() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_GRAVITY_SENSOR_GET_Z).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // AbsoluteOrientationSensor

    [Test]
    [Retry(3)]
    public async Task AbsoluteOrientationSensorGetQuaternion() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_ABSOLUTE_ORIENTATION_SENSOR_GET_QUATERNION).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task AbsoluteOrientationSensorPopulateMatrix() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_ABSOLUTE_ORIENTATION_SENSOR_POPULATE_MATRIX).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // RelativeOrientationSensor

    [Test]
    [Retry(3)]
    public async Task RelativeOrientationSensorGetQuaternion() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_RELATIVE_ORIENTATION_SENSOR_GET_QUATERNION).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task RelativeOrientationSensorPopulateMatrix() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_RELATIVE_ORIENTATION_SENSOR_POPULATE_MATRIX).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // Magnetometer

    [Test]
    [Retry(3)]
    public async Task MagnetometerGetX() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_MAGNETOMETER_GET_X).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task MagnetometerGetY() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_MAGNETOMETER_GET_Y).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task MagnetometerGetZ() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_MAGNETOMETER_GET_Z).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }


    // UncalibratedMagnetometer

    [Test]
    [Retry(3)]
    public async Task UncalibratedMagnetometerGetX() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_X).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task UncalibratedMagnetometerGetY() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Y).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task UncalibratedMagnetometerGetZ() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Z).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task UncalibratedMagnetometerGetXBias() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_X_BIAS).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task UncalibratedMagnetometerGetYBias() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Y_BIAS).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }

    [Test]
    [Retry(3)]
    public async Task UncalibratedMagnetometerGetZBias() {
        await Page.GetByTestId(SensorAPIInProcessGroup.BUTTON_UNCALIBRATED_MAGNETOMETER_GET_Z_BIAS).ClickAsync();

        string? result = await Page.GetByTestId(SensorAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result!).IsNotEmpty();
    }
}
