using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BrowserAPI.Demo.Client;

public sealed partial class SensorAPI : ComponentBase, IAsyncDisposable {
    [Inject]
    public required ISensorAPI PSensorAPI { private get; init; }

    public async ValueTask DisposeAsync() {
        try {
            if (ambientLightSensor is not null)
                await DestroyAmbientLightSensor();

            if (gyroscope is not null)
                await DestroyGyroscope();
            if (accelerometer is not null)
                await DestroyAccelerometer();
            if (linearAccelerationSensor is not null)
                await DestroyLinearAccelerationSensor();
            if (gravitySensor is not null)
                await DestroyGravitySensor();

            if (absoluteOrientationSensor is not null)
                await DestroyAbsoluteOrientationSensor();
            if (relativeOrientationSensor is not null)
                await DestroyRelativeOrientationSensor();

            if (magnetometer is not null)
                await DestroyMagnetometer();
            if (uncalibratedMagnetometer is not null)
                await DestroyUncalibratedMagnetometer();
        }
        catch (JSDisconnectedException) { }
    }


    #region Light

    private IAmbientLightSensor? ambientLightSensor = null;
    private bool noAmbientLightSensor = false;
    private async Task CreateAmbientLightSensor() {
        ambientLightSensor = await PSensorAPI.CreateAmbientLightSensor();
        if (ambientLightSensor is null) {
            noAmbientLightSensor = true;
            return;
        }

        await ambientLightSensor.Start();
        ambientLightSensor.OnReading += OnAmbientLightSensor;
    }

    private async Task DestroyAmbientLightSensor() {
        await ambientLightSensor!.Stop();
        ambientLightSensor.OnReading -= OnAmbientLightSensor;
        await ambientLightSensor.DisposeAsync();
        ambientLightSensor = null;
    }

    private double illuminance;
    private void OnAmbientLightSensor() {
        _ = DoAsync().Preserve();
        async ValueTask DoAsync() {
            illuminance = await ambientLightSensor!.Illuminance;
        }
    }

    #endregion


    #region Movement

    private IGyroscope? gyroscope = null;
    private bool noGyroscope = false;
    private async Task CreateGyroscope() {
        gyroscope = await PSensorAPI.CreateGyroscope() ?? throw new JSException(string.Empty);
        if (gyroscope is null) {
            noGyroscope = true;
            return;
        }

        await gyroscope.Start();
        gyroscope.OnReading += OnGyroscope;
    }

    private async Task DestroyGyroscope() {
        await gyroscope!.Stop();
        gyroscope.OnReading -= OnGyroscope;
        await gyroscope.DisposeAsync();
        gyroscope = null;
    }

    private double gyroscopeX;
    private double gyroscopeY;
    private double gyroscopeZ;
    private void OnGyroscope() {
        _ = DoAsync().Preserve();
        async ValueTask DoAsync() {
            gyroscopeX = await gyroscope!.X;
            gyroscopeY = await gyroscope!.Y;
            gyroscopeZ = await gyroscope!.Z;
        }
    }


    private IAccelerometer? accelerometer = null;
    private bool noAccelerometer = false;
    private async Task CreateAccelerometer() {
        accelerometer = await PSensorAPI.CreateAccelerometer();
        if (accelerometer is null) {
            noAccelerometer = true;
            return;
        }

        await accelerometer.Start();
        accelerometer.OnReading += OnAccelerometer;
    }

    private async Task DestroyAccelerometer() {
        await accelerometer!.Stop();
        accelerometer.OnReading -= OnAccelerometer;
        await accelerometer.DisposeAsync();
        accelerometer = null;
    }

    private double accelerometerX;
    private double accelerometerY;
    private double accelerometerZ;
    private void OnAccelerometer() {
        _ = DoAsync().Preserve();
        async ValueTask DoAsync() {
            accelerometerX = await accelerometer!.X;
            accelerometerY = await accelerometer!.Y;
            accelerometerZ = await accelerometer!.Z;
        }
    }


    private ILinearAccelerationSensor? linearAccelerationSensor = null;
    private bool noLinearAccelerationSensor = false;
    private async Task CreateLinearAccelerationSensor() {
        linearAccelerationSensor = await PSensorAPI.CreateLinearAccelerationSensor();
        if (linearAccelerationSensor is null) {
            noLinearAccelerationSensor = true;
            return;
        }

        await linearAccelerationSensor.Start();
        linearAccelerationSensor.OnReading += OnLinearAccelerationSensor;
    }

    private async Task DestroyLinearAccelerationSensor() {
        await linearAccelerationSensor!.Stop();
        linearAccelerationSensor.OnReading -= OnLinearAccelerationSensor;
        await linearAccelerationSensor.DisposeAsync();
        linearAccelerationSensor = null;
    }

    private double linearAccelerationSensorX;
    private double linearAccelerationSensorY;
    private double linearAccelerationSensorZ;
    private void OnLinearAccelerationSensor() {
        _ = DoAsync().Preserve();
        async ValueTask DoAsync() {
            linearAccelerationSensorX = await linearAccelerationSensor!.X;
            linearAccelerationSensorY = await linearAccelerationSensor!.Y;
            linearAccelerationSensorZ = await linearAccelerationSensor!.Z;
        }
    }


    private IGravitySensor? gravitySensor = null;
    private bool noGravitySensor = false;
    private async Task CreateGravitySensor() {
        gravitySensor = await PSensorAPI.CreateGravitySensor();
        if (gravitySensor is null) {
            noGravitySensor = true;
            return;
        }

        await gravitySensor.Start();
        gravitySensor.OnReading += OnGravitySensor;
    }

    private async Task DestroyGravitySensor() {
        await gravitySensor!.Stop();
        gravitySensor.OnReading -= OnGravitySensor;
        await gravitySensor.DisposeAsync();
        gravitySensor = null;
    }

    private double gravitySensorX;
    private double gravitySensorY;
    private double gravitySensorZ;
    private void OnGravitySensor() {
        _ = DoAsync().Preserve();
        async ValueTask DoAsync() {
            gravitySensorX = await gravitySensor!.X;
            gravitySensorY = await gravitySensor!.Y;
            gravitySensorZ = await gravitySensor!.Z;
        }
    }

    #endregion


    #region Orientation

    private IAbsoluteOrientationSensor? absoluteOrientationSensor = null;
    private bool noAbsoluteOrientationSensor = false;
    private async Task CreateAbsoluteOrientationSensor() {
        absoluteOrientationSensor = await PSensorAPI.CreateAbsoluteOrientationSensor();
        if (absoluteOrientationSensor is null) {
            noAbsoluteOrientationSensor = true;
            return;
        }

        await absoluteOrientationSensor.Start();
        absoluteOrientationSensor.OnReading += OnAbsoluteOrientationSensor;
    }

    private async Task DestroyAbsoluteOrientationSensor() {
        await absoluteOrientationSensor!.Stop();
        absoluteOrientationSensor.OnReading -= OnAbsoluteOrientationSensor;
        await absoluteOrientationSensor.DisposeAsync();
        absoluteOrientationSensor = null;
    }

    private System.Numerics.Quaternion absoluteQuaternion;
    private void OnAbsoluteOrientationSensor() {
        _ = DoAsync().Preserve();
        async ValueTask DoAsync() {
            absoluteQuaternion = await absoluteOrientationSensor!.Quaternion;
        }
    }


    private IRelativeOrientationSensor? relativeOrientationSensor = null;
    private bool noRelativeOrientationSensor = false;
    private async Task CreateRelativeOrientationSensor() {
        relativeOrientationSensor = await PSensorAPI.CreateRelativeOrientationSensor();
        if (relativeOrientationSensor is null) {
            noRelativeOrientationSensor = true;
            return;
        }

        await relativeOrientationSensor.Start();
        relativeOrientationSensor.OnReading += OnRelativeOrientationSensor;
    }

    private async Task DestroyRelativeOrientationSensor() {
        await relativeOrientationSensor!.Stop();
        relativeOrientationSensor.OnReading -= OnRelativeOrientationSensor;
        await relativeOrientationSensor.DisposeAsync();
        relativeOrientationSensor = null;
    }

    private System.Numerics.Quaternion relativeQuaternion;
    private void OnRelativeOrientationSensor() {
        _ = DoAsync().Preserve();
        async ValueTask DoAsync() {
            relativeQuaternion = await relativeOrientationSensor!.Quaternion;
        }
    }

    #endregion


    #region Magnetometer

    private IMagnetometer? magnetometer = null;
    private bool noMagnetometer = false;
    private async Task CreateMagnetometer() {
        magnetometer = await PSensorAPI.CreateMagnetometer();
        if (magnetometer is null) {
            noMagnetometer = true;
            return;
        }

        await magnetometer.Start();
        magnetometer.OnReading += OnMagnetometer;
    }

    private async Task DestroyMagnetometer() {
        await magnetometer!.Stop();
        magnetometer.OnReading -= OnMagnetometer;
        await magnetometer.DisposeAsync();
        magnetometer = null;
    }

    private double magnetometerX;
    private double magnetometerY;
    private double magnetometerZ;
    private void OnMagnetometer() {
        _ = DoAsync().Preserve();
        async ValueTask DoAsync() {
            magnetometerX = await magnetometer!.X;
            magnetometerY = await magnetometer!.Y;
            magnetometerZ = await magnetometer!.Z;
        }
    }


    private IUncalibratedMagnetometer? uncalibratedMagnetometer = null;
    private bool noUncalibratedMagnetometer = false;
    private async Task CreateUncalibratedMagnetometer() {
        uncalibratedMagnetometer = await PSensorAPI.CreateUncalibratedMagnetometer();
        if (uncalibratedMagnetometer is null) {
            noUncalibratedMagnetometer = true;
            return;
        }

        await uncalibratedMagnetometer.Start();
        uncalibratedMagnetometer.OnReading += OnUncalibratedMagnetometer;
    }

    private async Task DestroyUncalibratedMagnetometer() {
        await uncalibratedMagnetometer!.Stop();
        uncalibratedMagnetometer.OnReading -= OnUncalibratedMagnetometer;
        await uncalibratedMagnetometer.DisposeAsync();
        uncalibratedMagnetometer = null;
    }

    private double uncalibratedMagnetometerX;
    private double uncalibratedMagnetometerY;
    private double uncalibratedMagnetometerZ;
    private double uncalibratedMagnetometerXBias;
    private double uncalibratedMagnetometerYBias;
    private double uncalibratedMagnetometerZBias;
    private void OnUncalibratedMagnetometer() {
        _ = DoAsync().Preserve();
        async ValueTask DoAsync() {
            uncalibratedMagnetometerX = await uncalibratedMagnetometer!.X;
            uncalibratedMagnetometerY = await uncalibratedMagnetometer!.Y;
            uncalibratedMagnetometerZ = await uncalibratedMagnetometer!.Z;
            uncalibratedMagnetometerXBias = await uncalibratedMagnetometer!.XBias;
            uncalibratedMagnetometerYBias = await uncalibratedMagnetometer!.YBias;
            uncalibratedMagnetometerZBias = await uncalibratedMagnetometer!.ZBias;
        }
    }

    #endregion
}
