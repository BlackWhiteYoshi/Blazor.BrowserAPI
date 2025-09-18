# Sensor API

The Sensor APIs are a set of interfaces built to a common design that expose device sensors in a consistent way to the web platform.


<br><br />
## Example

```csharp
public sealed partial class ExampleComponent : ComponentBase, IAsyncDisposable {
    [Inject]
    public required ISensorAPI SensorAPI { private get; init; }

    private IGyroscope? gyroscope;


    protected override async Task OnInitializedAsync() {
        gyroscope = await SensorAPI.CreateGyroscope(frequency: 20);
        if (gyroscope is null) {
            Console.WriteLine("gyroscope is not supported");
            return;
        }

        gyroscope.OnError += Console.WriteLine;
        gyroscope.OnReading += ReadSensor;
        await gyroscope.Start();
    }

    public async ValueTask DisposeAsync() {
        if (gyroscope is null)
            return;

        await gyroscope.Stop();
        gyroscope.OnReading -= ReadSensor;
        gyroscope.OnError -= Console.WriteLine;

        await gyroscope.DisposeAsync();
    }


    private void ReadSensor() {
        _ = RunAsync();
        async Task RunAsync() {
            double x = await gyroscope!.X;
            double y = await gyroscope.Y;
            double z = await gyroscope.Z;
            Console.WriteLine($"Angular velocity: ({x}, {y}, {z})");
        };
    }
}
```


<br><br />
## Members

### ISensorAPI

The Sensor APIs are a set of interfaces built to a common design that expose device sensors in a consistent way to the web platform.

#### Methods

| **Name**                        | **Parameters**                                                                                              | **ReturnType**                                                              | **Description**                                                                                                                                                                                                                 |
| ------------------------------- | ----------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| CreateAmbientLightSensor        | [double frequency = 0], [CancellationToken cancellationToken = default]                                     | ValueTask&lt;[IAmbientLightSensor](#iambientlightsensor)?&gt;               | The *AmbientLightSensor()* constructor creates a new AmbientLightSensor object, which returns the current light level or illuminance of the ambient light around the hosting device.                                            |
| CreateGyroscope                 | [double frequency = 0], [string referenceFrame = "device"], [CancellationToken cancellationToken = default] | ValueTask&lt;[IGyroscope](#igyroscope)?&gt;                                 | The *Gyroscope()* constructor creates a new Gyroscope object which provides on each reading the angular velocity of the device along all three axes.                                                                            |
| CreateAccelerometer             | [double frequency = 0], [string referenceFrame = "device"], [CancellationToken cancellationToken = default] | ValueTask&lt;[IAccelerometer](#iaccelerometer)?&gt;                         | The *Accelerometer()* constructor creates a new Accelerometer object which returns the acceleration of the device along all three axes at the time it is read.                                                                  |
| CreateLinearAccelerationSensor  | [double frequency = 0], [string referenceFrame = "device"], [CancellationToken cancellationToken = default] | ValueTask&lt;[ILinearAccelerationSensor](#ilinearaccelerationsensor)?&gt;   | The *LinearAccelerationSensor()* constructor creates a new LinearAccelerationSensor object which provides on each reading the acceleration applied to the device along all three axes, but without the contribution of gravity. |
| CreateGravitySensor             | [double frequency = 0], [string referenceFrame = "device"], [CancellationToken cancellationToken = default] | ValueTask&lt;[IGravitySensor](#igravitysensor)?&gt;                         | The *GravitySensor()* constructor creates a new GravitySensor object which provides on each reading the gravity applied to the device along all three axes.                                                                     |
| CreateAbsoluteOrientationSensor | [double frequency = 0], [string referenceFrame = "device"], [CancellationToken cancellationToken = default] | ValueTask&lt;[IAbsoluteOrientationSensor](#iabsoluteorientationsensor)?&gt; | The *AbsoluteOrientationSensor()* constructor creates a new AbsoluteOrientationSensor object which describes the device's physical orientation in relation to the Earth's reference coordinate system.                          |
| CreateRelativeOrientationSensor | [double frequency = 0], [string referenceFrame = "device"], [CancellationToken cancellationToken = default] | ValueTask&lt;[IRelativeOrientationSensor](#irelativeorientationsensor)?&gt; | The *RelativeOrientationSensor()* constructor creates a new RelativeOrientationSensor object which describes the device's physical orientation.                                                                                 |
| CreateMagnetometer              | [double frequency = 0], [string referenceFrame = "device"], [CancellationToken cancellationToken = default] | ValueTask&lt;[IMagnetometer](#imagnetometer)?&gt;                           | The *Magnetometer()* constructor creates a new Magnetometer object which returns information about the magnetic field as detected by a device's primary magnetometer sensor.                                                    |
| CreateUncalibratedMagnetometer  | [double frequency = 0], [string referenceFrame = "device"], [CancellationToken cancellationToken = default] | ValueTask&lt;[IUncalibratedMagnetometer](#iuncalibratedmagnetometer)?&gt;   | The *UncalibratedMagnetometer()* constructor creates a new UncalibratedMagnetometer object which returns information about the uncalibrated magnetic field as detected by a device's primary magnetometer sensor.               |

#### Events

| **Name**                    | **Type**                             | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| --------------------------- | ------------------------------------ | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnDeviceMotion              | Action&lt;DeviceMotionEvent&gt;      | Is fired at a regular interval and indicates the acceleration rate of the device with/without the contribution of the gravity force at that time. It also provides information about the rate of rotation, if available.<br/>This event is not cancelable and does not bubble.                                                                                                                                                                            |
| OnDeviceOrientation         | Action&lt;DeviceOrientationEvent&gt; | Is fired when fresh data is available from an orientation sensor about the current orientation of the device as compared to the Earth coordinate frame. This data is gathered from a magnetometer inside the device.<br/>See [Orientation and motion data explained](https://developer.mozilla.org/en-US/docs/Web/API/Device_orientation_events/Orientation_and_motion_data_explained) for details.<br/>This event is not cancelable and does not bubble. |
| OnDeviceOrientationAbsolute | Action&lt;DeviceOrientationEvent&gt; | Is fired when absolute device orientation changes.<br/>This event is not cancelable and does not bubble.                                                                                                                                                                                                                                                                                                                                                  |


<br></br>
### ISensor

The Sensor interface of the Sensor APIs is the base class for all the other sensor interfaces.
This interface cannot be used directly.
Instead it provides properties, event handlers, and methods accessed by interfaces that inherit from it.

#### Properties

| **Name**   | **Type**                | get/set | **Description**                                                      |
| ---------- | ----------------------- | ------- | -------------------------------------------------------------------- |
| Activated  | ValueTask&lt;bool&gt;   | get     | Returns a boolean value indicating whether the sensor is active.     |
| HasReading | ValueTask&lt;bool&gt;   | get     | Returns a boolean value indicating whether the sensor has a reading. |
| Timestamp  | ValueTask&lt;double&gt; | get     | Returns the timestamp of the latest sensor reading.                  |

#### Methods

| **Name**      | **Parameters**                        | **ReturnType**          | **Description**                                 |
| ------------- | ------------------------------------- | ----------------------- | ----------------------------------------------- |
| GetActivated  | CancellationToken cancellationToken   | ValueTask&lt;bool&gt;   | see Property *Activated*                        |
| GetHasReading | CancellationToken cancellationToken   | ValueTask&lt;bool&gt;   | see Property *HasReading*                       |
| GetTimestamp  | CancellationToken cancellationToken   | ValueTask&lt;double&gt; | see Property *Timestamp*                        |
| Start         | [CancellationToken cancellationToken] | ValueTask               | Activates one of the sensors based on Sensor.   |
| Stop          | [CancellationToken cancellationToken] | ValueTask               | Deactivates one of the sensors based on Sensor. |

#### Events

| **Name**   | **Type**                  | **Description**                                                                                                                                                                                                                                                                    |
| ---------- | ------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnError    | Action&lt;JsonElement&gt; | Is fired when an exception occurs on a sensor. After this event has occurred, the Sensor object becomes idle. If the sensor was reading values, it will stop until it restarts.<br />Parameter is of type [Event](https://developer.mozilla.org/en-US/docs/Web/API/Event) as JSON. |
| OnActivate | Action                    | Is fired when a sensor becomes activated. It means that it will start obtaining readings.                                                                                                                                                                                          |
| OnReading  | Action                    | Is fired when a new reading is available on a sensor.                                                                                                                                                                                                                              |


<br></br>
### IAmbientLightSensor

The *AmbientLightSensor* interface of the Sensor APIs returns the current light level or illuminance of the ambient light around the hosting device.

To use this sensor, the user must grant permission to the 'ambient-light-sensor' device sensor through the Permissions API.

Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.

#### Inheritance

- [ISensor](#isensor)

#### Properties

| **Name**    | **Type**                | get/set | **Description**                                                                              |
| ----------- | ----------------------- | ------- | -------------------------------------------------------------------------------------------- |
| Illuminance | ValueTask&lt;double&gt; | get     | Returns the current light level in lux of the ambient light level around the hosting device. |

#### Methods

| **Name**       | **Parameters**                      | **ReturnType**          | **Description**            |
| -------------- | ----------------------------------- | ----------------------- | -------------------------- |
| GetIlluminance | CancellationToken cancellationToken | ValueTask&lt;double&gt; | see Property *Illuminance* |


<br></br>
### IGyroscope

The *Gyroscope* interface of the Sensor APIs provides on each reading the angular velocity of the device along all three axes.

To use this sensor, the user must grant permission to the 'gyroscope' device sensor through the Permissions API.

Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.

#### Inheritance

- [ISensor](#isensor)

#### Properties

| **Name** | **Type**                | get/set | **Description**                                                                            |
| -------- | ----------------------- | ------- | ------------------------------------------------------------------------------------------ |
| X        | ValueTask&lt;double&gt; | get     | Returns a double, containing the angular velocity of the device along the device's x axis. |
| Y        | ValueTask&lt;double&gt; | get     | Returns a double, containing the angular velocity of the device along the device's y axis. |
| Z        | ValueTask&lt;double&gt; | get     | Returns a double, containing the angular velocity of the device along the device's z axis. |

#### Methods

| **Name** | **Parameters**                      | **ReturnType**          | **Description**  |
| -------- | ----------------------------------- | ----------------------- | ---------------- |
| GetX     | CancellationToken cancellationToken | ValueTask&lt;double&gt; | see Property *X* |
| GetY     | CancellationToken cancellationToken | ValueTask&lt;double&gt; | see Property *Y* |
| GetZ     | CancellationToken cancellationToken | ValueTask&lt;double&gt; | see Property *Z* |


<br></br>
### IAccelerometer

The *Accelerometer* interface of the Sensor APIs provides on each reading the acceleration applied to the device along all three axes.

To use this sensor, the user must grant permission to the 'accelerometer', device sensor through the Permissions API.

Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.

#### Inheritance

- [ISensor](#isensor)

#### Properties

| **Name** | **Type**                | get/set | **Description**                                                                       |
| -------- | ----------------------- | ------- | ------------------------------------------------------------------------------------- |
| X        | ValueTask&lt;double&gt; | get     | Returns a double containing the acceleration of the device along the device's x axis. |
| Y        | ValueTask&lt;double&gt; | get     | Returns a double containing the acceleration of the device along the device's y axis. |
| Z        | ValueTask&lt;double&gt; | get     | Returns a double containing the acceleration of the device along the device's z axis. |

#### Methods

| **Name** | **Parameters**                      | **ReturnType**          | **Description**  |
| -------- | ----------------------------------- | ----------------------- | ---------------- |
| GetX     | CancellationToken cancellationToken | ValueTask&lt;double&gt; | see Property *X* |
| GetY     | CancellationToken cancellationToken | ValueTask&lt;double&gt; | see Property *Y* |
| GetZ     | CancellationToken cancellationToken | ValueTask&lt;double&gt; | see Property *Z* |


<br></br>
### ILinearAccelerationSensor

The *LinearAccelerationSensor* interface of the Sensor APIs provides on each reading the acceleration applied to the device along all three axes, but without the contribution of gravity.

To use this sensor, the user must grant permission to the 'accelerometer' device sensor through the Permissions API.

Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.

#### Inheritance

- [ISensor](#isensor)

#### Properties

| **Name** | **Type**                | get/set | **Description**                                                                       |
| -------- | ----------------------- | ------- | ------------------------------------------------------------------------------------- |
| X        | ValueTask&lt;double&gt; | get     | Returns a double containing the acceleration of the device along the device's x axis. |
| Y        | ValueTask&lt;double&gt; | get     | Returns a double containing the acceleration of the device along the device's y axis. |
| Z        | ValueTask&lt;double&gt; | get     | Returns a double containing the acceleration of the device along the device's z axis. |

#### Methods

| **Name** | **Parameters**                      | **ReturnType**          | **Description**  |
| -------- | ----------------------------------- | ----------------------- | ---------------- |
| GetX     | CancellationToken cancellationToken | ValueTask&lt;double&gt; | see Property *X* |
| GetY     | CancellationToken cancellationToken | ValueTask&lt;double&gt; | see Property *Y* |
| GetZ     | CancellationToken cancellationToken | ValueTask&lt;double&gt; | see Property *Z* |


<br></br>
### IGravitySensor

The *GravitySensor* interface of the Sensor APIs provides on each reading the gravity applied to the device along all three axes.

To use this sensor, the user must grant permission to the 'accelerometer' device sensor through the Permissions API.

Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.

#### Inheritance

- [ISensor](#isensor)

#### Properties

| **Name** | **Type**                | get/set | **Description**                                                                       |
| -------- | ----------------------- | ------- | ------------------------------------------------------------------------------------- |
| X        | ValueTask&lt;double&gt; | get     | Returns a double containing the acceleration of the device along the device's x axis. |
| Y        | ValueTask&lt;double&gt; | get     | Returns a double containing the acceleration of the device along the device's y axis. |
| Z        | ValueTask&lt;double&gt; | get     | Returns a double containing the acceleration of the device along the device's z axis. |

#### Methods

| **Name** | **Parameters**                      | **ReturnType**          | **Description**  |
| -------- | ----------------------------------- | ----------------------- | ---------------- |
| GetX     | CancellationToken cancellationToken | ValueTask&lt;double&gt; | see Property *X* |
| GetY     | CancellationToken cancellationToken | ValueTask&lt;double&gt; | see Property *Y* |
| GetZ     | CancellationToken cancellationToken | ValueTask&lt;double&gt; | see Property *Z* |


<br></br>
### IAbsoluteOrientationSensor

The *AbsoluteOrientationSensor* interface of the Sensor APIs describes the device's physical orientation in relation to the Earth's reference coordinate system.

To use this sensor, the user must grant permission to the 'accelerometer', 'gyroscope', and 'magnetometer' device sensors through the Permissions API.

Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.

#### Inheritance

- [ISensor](#isensor)

#### Properties

| **Name**   | **Type**                                                                                                | get/set | **Description**                                                  |
| ---------- | ------------------------------------------------------------------------------------------------------- | ------- | ---------------------------------------------------------------- |
| Quaternion | ValueTask&lt;[Quaternion](https://learn.microsoft.com/en-us//dotnet/api/system.numerics.quaternion)&gt; | get     | Returns a unit quaternion representing the device's orientation. |

#### Methods

| **Name**       | **Parameters**                                  | **ReturnType**                                                                                          | **Description**                                                  |
| -------------- | ----------------------------------------------- | ------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------- |
| GetQuaternion  | CancellationToken cancellationToken             | ValueTask&lt;[Quaternion](https://learn.microsoft.com/en-us//dotnet/api/system.numerics.quaternion)&gt; | see Property *Quaternion*                                        |
| PopulateMatrix | [CancellationToken cancellationToken = default] | ValueTask&lt;[Matrix4x4](https://learn.microsoft.com/en-us//dotnet/api/system.numerics.matrix4x4)&gt;   | Returns a rotation matrix based on the latest sensor reading.    |


<br></br>
### IRelativeOrientationSensor

The *RelativeOrientationSensor* interface of the Sensor APIs describes the device's physical orientation without regard to the Earth's reference coordinate system.

To use this sensor, the user must grant permission to the 'accelerometer', and 'gyroscope' device sensors through the Permissions API.

Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.

#### Inheritance

- [ISensor](#isensor)

#### Properties

| **Name**   | **Type**                                                                                                | get/set | **Description**                                                  |
| ---------- | ------------------------------------------------------------------------------------------------------- | ------- | ---------------------------------------------------------------- |
| Quaternion | ValueTask&lt;[Quaternion](https://learn.microsoft.com/en-us//dotnet/api/system.numerics.quaternion)&gt; | get     | Returns a unit quaternion representing the device's orientation. |

#### Methods

| **Name**       | **Parameters**                                  | **ReturnType**                                                                                          | **Description**                                               |
| -------------- | ----------------------------------------------- | ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------- |
| GetQuaternion  | CancellationToken cancellationToken             | ValueTask&lt;[Quaternion](https://learn.microsoft.com/en-us//dotnet/api/system.numerics.quaternion)&gt; | see Property *Quaternion*                                     |
| PopulateMatrix | [CancellationToken cancellationToken = default] | ValueTask&lt;[Matrix4x4](https://learn.microsoft.com/en-us//dotnet/api/system.numerics.matrix4x4)&gt;   | Returns a rotation matrix based on the latest sensor reading. |


<br></br>
### IMagnetometer

The *Magnetometer* interface of the Sensor APIs provides information about the magnetic field as detected by the device's primary magnetometer sensor.

To use this sensor, the user must grant permission to the 'magnetometer' device sensor through the Permissions API.

Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.

#### Inheritance

- [ISensor](#isensor)

#### Properties

| **Name** | **Type**                | get/set | **Description**                                                            |
| -------- | ----------------------- | ------- | -------------------------------------------------------------------------- |
| X        | ValueTask&lt;double&gt; | get     | Returns a double containing the magnetic field around the device's x axis. |
| Y        | ValueTask&lt;double&gt; | get     | Returns a double containing the magnetic field around the device's y axis. |
| Z        | ValueTask&lt;double&gt; | get     | Returns a double containing the magnetic field around the device's z axis. |

#### Methods

| **Name** | **Parameters**                      | **ReturnType**          | **Description**  |
| -------- | ----------------------------------- | ----------------------- | ---------------- |
| GetX     | CancellationToken cancellationToken | ValueTask&lt;double&gt; | see Property *X* |
| GetY     | CancellationToken cancellationToken | ValueTask&lt;double&gt; | see Property *Y* |
| GetZ     | CancellationToken cancellationToken | ValueTask&lt;double&gt; | see Property *Z* |


<br></br>
### IUncalibratedMagnetometer

The *UncalibratedMagnetometer* interface of the Sensor APIs provides information about the uncalibrated magnetic field as detected by the device's primary magnetometer sensor.

To use this sensor, the user must grant permission to the 'magnetometer' device sensor through the Permissions API.

*Hard iron distortion* is created by objects that produce a magnetic field, such as magnetized iron.  
*Soft iron distortion* stretches or distorts the magnetic field and is caused by metals such as nickel and iron.  
The *calibrated magnetic field* is a magnetic field with hard iron distortion and soft iron distortion correction applied.  
The *uncalibrated magnetic field* is the magnetic field without hard iron distortion correction and with soft iron distortion correction applied, and as such reports changes in the magnetic field caused by magnetized objects moving near the magnetometer.

Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.

#### Inheritance

- [ISensor](#isensor)

#### Properties

| **Name** | **Type**                | get/set | **Description**                                                                         |
| -------- | ----------------------- | ------- | --------------------------------------------------------------------------------------- |
| X        | ValueTask&lt;double&gt; | get     | Returns a double containing the uncalibrated magnetic field around the device's x axis. |
| Y        | ValueTask&lt;double&gt; | get     | Returns a double containing the uncalibrated magnetic field around the device's y axis. |
| Z        | ValueTask&lt;double&gt; | get     | Returns a double containing the uncalibrated magnetic field around the device's z axis. |
| XBias    | ValueTask&lt;double&gt; | get     | Returns a double representing the hard iron distortion correction around x axis.        |
| YBias    | ValueTask&lt;double&gt; | get     | Returns a double representing the hard iron distortion correction around y axis.        |
| ZBias    | ValueTask&lt;double&gt; | get     | Returns a double representing the hard iron distortion correction around z axis.        |

#### Methods

| **Name** | **Parameters**                      | **ReturnType**          | **Description**      |
| -------- | ----------------------------------- | ----------------------- | -------------------- |
| GetX     | CancellationToken cancellationToken | ValueTask&lt;double&gt; | see Property *X*     |
| GetY     | CancellationToken cancellationToken | ValueTask&lt;double&gt; | see Property *Y*     |
| GetZ     | CancellationToken cancellationToken | ValueTask&lt;double&gt; | see Property *Z*     |
| GetXBias | CancellationToken cancellationToken | ValueTask&lt;double&gt; | see Property *XBias* |
| GetYBias | CancellationToken cancellationToken | ValueTask&lt;double&gt; | see Property *YBias* |
| GetZBias | CancellationToken cancellationToken | ValueTask&lt;double&gt; | see Property *ZBias* |



<br></br>
### ISensorAPIInProcess

The Sensor APIs are a set of interfaces built to a common design that expose device sensors in a consistent way to the web platform.

#### Methods

| **Name**                        | **Parameters**                                             | **ReturnType**                                                               | **Description**                                                                                                                                                                                                                 |
| ------------------------------- | ---------------------------------------------------------- | ---------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| CreateAmbientLightSensor        | [double frequency = 0]                                     | [IAmbientLightSensorInProcess](#iambientlightsensorinprocess)?               | The *AmbientLightSensor()* constructor creates a new AmbientLightSensor object, which returns the current light level or illuminance of the ambient light around the hosting device.                                            |
| CreateGyroscope                 | [double frequency = 0], [string referenceFrame = "device"] | [IGyroscopeInProcess](#igyroscopeinprocess)?                                 | The *Gyroscope()* constructor creates a new Gyroscope object which provides on each reading the angular velocity of the device along all three axes.                                                                            |
| CreateAccelerometer             | [double frequency = 0], [string referenceFrame = "device"] | [IAccelerometerInProcess](#iaccelerometerinprocess)?                         | The *Accelerometer()* constructor creates a new Accelerometer object which returns the acceleration of the device along all three axes at the time it is read.                                                                  |
| CreateLinearAccelerationSensor  | [double frequency = 0], [string referenceFrame = "device"] | [ILinearAccelerationSensorInProcess](#ilinearaccelerationsensorinprocess)?   | The *LinearAccelerationSensor()* constructor creates a new LinearAccelerationSensor object which provides on each reading the acceleration applied to the device along all three axes, but without the contribution of gravity. |
| CreateGravitySensor             | [double frequency = 0], [string referenceFrame = "device"] | [IGravitySensorInProcess](#igravitysensorinprocess)?                         | The *GravitySensor()* constructor creates a new GravitySensor object which provides on each reading the gravity applied to the device along all three axes.                                                                     |
| CreateAbsoluteOrientationSensor | [double frequency = 0], [string referenceFrame = "device"] | [IAbsoluteOrientationSensorInProcess](#iabsoluteorientationsensorinprocess)? | The *AbsoluteOrientationSensor()* constructor creates a new AbsoluteOrientationSensor object which describes the device's physical orientation in relation to the Earth's reference coordinate system.                          |
| CreateRelativeOrientationSensor | [double frequency = 0], [string referenceFrame = "device"] | [IRelativeOrientationSensorInProcess](#irelativeorientationsensorinprocess)? | The *RelativeOrientationSensor()* constructor creates a new RelativeOrientationSensor object which describes the device's physical orientation.                                                                                 |
| CreateMagnetometer              | [double frequency = 0], [string referenceFrame = "device"] | [IMagnetometerInProcess](#imagnetometerinprocess)?                           | The *Magnetometer()* constructor creates a new Magnetometer object which returns information about the magnetic field as detected by a device's primary magnetometer sensor.                                                    |
| CreateUncalibratedMagnetometer  | [double frequency = 0], [string referenceFrame = "device"] | [IUncalibratedMagnetometerInProcess](#iuncalibratedmagnetometerinprocess)?   | The *UncalibratedMagnetometer()* constructor creates a new UncalibratedMagnetometer object which returns information about the uncalibrated magnetic field as detected by a device's primary magnetometer sensor.               |

#### Events

| **Name**                    | **Type**                             | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| --------------------------- | ------------------------------------ | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnDeviceMotion              | Action&lt;DeviceMotionEvent&gt;      | Is fired at a regular interval and indicates the acceleration rate of the device with/without the contribution of the gravity force at that time. It also provides information about the rate of rotation, if available.<br/>This event is not cancelable and does not bubble.                                                                                                                                                                            |
| OnDeviceOrientation         | Action&lt;DeviceOrientationEvent&gt; | Is fired when fresh data is available from an orientation sensor about the current orientation of the device as compared to the Earth coordinate frame. This data is gathered from a magnetometer inside the device.<br/>See [Orientation and motion data explained](https://developer.mozilla.org/en-US/docs/Web/API/Device_orientation_events/Orientation_and_motion_data_explained) for details.<br/>This event is not cancelable and does not bubble. |
| OnDeviceOrientationAbsolute | Action&lt;DeviceOrientationEvent&gt; | Is fired when absolute device orientation changes.<br/>This event is not cancelable and does not bubble.                                                                                                                                                                                                                                                                                                                                                  |


<br></br>
### ISensorInProcess

The Sensor interface of the Sensor APIs is the base class for all the other sensor interfaces.
This interface cannot be used directly.
Instead it provides properties, event handlers, and methods accessed by interfaces that inherit from it.

#### Properties

| **Name**   | **Type** | get/set | **Description**                                                      |
| ---------- | -------- | ------- | -------------------------------------------------------------------- |
| Activated  | bool     | get     | Returns a boolean value indicating whether the sensor is active.     |
| HasReading | bool     | get     | Returns a boolean value indicating whether the sensor has a reading. |
| Timestamp  | double   | get     | Returns the timestamp of the latest sensor reading.                  |

#### Methods

| **Name** | **Parameters** | **ReturnType** | **Description**                                 |
| -------- | -------------- | -------------- | ----------------------------------------------- |
| Start    | *empty*        | void           | Activates one of the sensors based on Sensor.   |
| Stop     | *empty*        | void           | Deactivates one of the sensors based on Sensor. |

#### Events

| **Name**   | **Type**                  | **Description**                                                                                                                                                                                                                                                                    |
| ---------- | ------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnError    | Action&lt;JsonElement&gt; | Is fired when an exception occurs on a sensor. After this event has occurred, the Sensor object becomes idle. If the sensor was reading values, it will stop until it restarts.<br />Parameter is of type [Event](https://developer.mozilla.org/en-US/docs/Web/API/Event) as JSON. |
| OnActivate | Action                    | Is fired when a sensor becomes activated. It means that it will start obtaining readings.                                                                                                                                                                                          |
| OnReading  | Action                    | Is fired when a new reading is available on a sensor.                                                                                                                                                                                                                              |


<br></br>
### IAmbientLightSensorInProcess

The *AmbientLightSensor* interface of the Sensor APIs returns the current light level or illuminance of the ambient light around the hosting device.

To use this sensor, the user must grant permission to the 'ambient-light-sensor' device sensor through the Permissions API.

Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.

#### Inheritance

- [ISensorInProcess](#isensorinprocess)

#### Properties

| **Name**    | **Type** | get/set | **Description**                                                                              |
| ----------- | -------- | ------- | -------------------------------------------------------------------------------------------- |
| Illuminance | double   | get     | Returns the current light level in lux of the ambient light level around the hosting device. |


<br></br>
### IGyroscopeInProcess

The *Gyroscope* interface of the Sensor APIs provides on each reading the angular velocity of the device along all three axes.

To use this sensor, the user must grant permission to the 'gyroscope' device sensor through the Permissions API.

Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.

#### Inheritance

- [ISensorInProcess](#isensorinprocess)

#### Properties

| **Name** | **Type** | get/set | **Description**                                                                            |
| -------- | -------- | ------- | ------------------------------------------------------------------------------------------ |
| X        | double   | get     | Returns a double, containing the angular velocity of the device along the device's x axis. |
| Y        | double   | get     | Returns a double, containing the angular velocity of the device along the device's y axis. |
| Z        | double   | get     | Returns a double, containing the angular velocity of the device along the device's z axis. |


<br></br>
### IAccelerometerInProcess

The *Accelerometer* interface of the Sensor APIs provides on each reading the acceleration applied to the device along all three axes.

To use this sensor, the user must grant permission to the 'accelerometer', device sensor through the Permissions API.

Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.

#### Inheritance

- [ISensorInProcess](#isensorinprocess)

#### Properties

| **Name** | **Type** | get/set | **Description**                                                                       |
| -------- | -------- | ------- | ------------------------------------------------------------------------------------- |
| X        | double   | get     | Returns a double containing the acceleration of the device along the device's x axis. |
| Y        | double   | get     | Returns a double containing the acceleration of the device along the device's y axis. |
| Z        | double   | get     | Returns a double containing the acceleration of the device along the device's z axis. |


<br></br>
### ILinearAccelerationSensorInProcess

The *LinearAccelerationSensor* interface of the Sensor APIs provides on each reading the acceleration applied to the device along all three axes, but without the contribution of gravity.

To use this sensor, the user must grant permission to the 'accelerometer' device sensor through the Permissions API.

Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.

#### Inheritance

- [ISensorInProcess](#isensorinprocess)

#### Properties

| **Name** | **Type** | get/set | **Description**                                                                       |
| -------- | -------- | ------- | ------------------------------------------------------------------------------------- |
| X        | double   | get     | Returns a double containing the acceleration of the device along the device's x axis. |
| Y        | double   | get     | Returns a double containing the acceleration of the device along the device's y axis. |
| Z        | double   | get     | Returns a double containing the acceleration of the device along the device's z axis. |


<br></br>
### IGravitySensorInProcess

The *GravitySensor* interface of the Sensor APIs provides on each reading the gravity applied to the device along all three axes.

To use this sensor, the user must grant permission to the 'accelerometer' device sensor through the Permissions API.

Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.

#### Inheritance

- [ISensorInProcess](#isensorinprocess)

#### Properties

| **Name** | **Type** | get/set | **Description**                                                                       |
| -------- | -------- | ------- | ------------------------------------------------------------------------------------- |
| X        | double   | get     | Returns a double containing the acceleration of the device along the device's x axis. |
| Y        | double   | get     | Returns a double containing the acceleration of the device along the device's y axis. |
| Z        | double   | get     | Returns a double containing the acceleration of the device along the device's z axis. |


<br></br>
### IAbsoluteOrientationSensorInProcess

The *AbsoluteOrientationSensor* interface of the Sensor APIs describes the device's physical orientation in relation to the Earth's reference coordinate system.

To use this sensor, the user must grant permission to the 'accelerometer', 'gyroscope', and 'magnetometer' device sensors through the Permissions API.

Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.

#### Inheritance

- [ISensorInProcess](#isensorinprocess)

#### Properties

| **Name**   | **Type**                                                                               | get/set | **Description**                                                  |
| ---------- | -------------------------------------------------------------------------------------- | ------- | ---------------------------------------------------------------- |
| Quaternion | [Quaternion](https://learn.microsoft.com/en-us//dotnet/api/system.numerics.quaternion) | get     | Returns a unit quaternion representing the device's orientation. |

#### Methods

| **Name**       | **Parameters** | **ReturnType**                                                                       | **Description**                                               |
| -------------- | -------------- | ------------------------------------------------------------------------------------ | ------------------------------------------------------------- |
| PopulateMatrix | *empty*        | [Matrix4x4](https://learn.microsoft.com/en-us//dotnet/api/system.numerics.matrix4x4) | Returns a rotation matrix based on the latest sensor reading. |


<br></br>
### IRelativeOrientationSensorInProcess

The *RelativeOrientationSensor* interface of the Sensor APIs describes the device's physical orientation without regard to the Earth's reference coordinate system.

To use this sensor, the user must grant permission to the 'accelerometer', and 'gyroscope' device sensors through the Permissions API.

Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.

#### Inheritance

- [ISensorInProcess](#isensorinprocess)

#### Properties

| **Name**   | **Type**                                                                               | get/set | **Description**                                                  |
| ---------- | -------------------------------------------------------------------------------------- | ------- | ---------------------------------------------------------------- |
| Quaternion | [Quaternion](https://learn.microsoft.com/en-us//dotnet/api/system.numerics.quaternion) | get     | Returns a unit quaternion representing the device's orientation. |

#### Methods

| **Name**       | **Parameters** | **ReturnType**                                                                       | **Description**                                                  |
| -------------- | -------------- | ------------------------------------------------------------------------------------ | ---------------------------------------------------------------- |
| PopulateMatrix | *empty*        | [Matrix4x4](https://learn.microsoft.com/en-us//dotnet/api/system.numerics.matrix4x4) | Returns a rotation matrix based on the latest sensor reading.    |


<br></br>
### IMagnetometerInProcess

The *Magnetometer* interface of the Sensor APIs provides information about the magnetic field as detected by the device's primary magnetometer sensor.

To use this sensor, the user must grant permission to the 'magnetometer' device sensor through the Permissions API.

Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.

#### Inheritance

- [ISensorInProcess](#isensorinprocess)

#### Properties

| **Name** | **Type** | get/set | **Description**                                                            |
| -------- | -------- | ------- | -------------------------------------------------------------------------- |
| X        | double   | get     | Returns a double containing the magnetic field around the device's x axis. |
| Y        | double   | get     | Returns a double containing the magnetic field around the device's y axis. |
| Z        | double   | get     | Returns a double containing the magnetic field around the device's z axis. |


<br></br>
### IUncalibratedMagnetometerInProcess

The *UncalibratedMagnetometer* interface of the Sensor APIs provides information about the uncalibrated magnetic field as detected by the device's primary magnetometer sensor.

To use this sensor, the user must grant permission to the 'magnetometer' device sensor through the Permissions API.

*Hard iron distortion* is created by objects that produce a magnetic field, such as magnetized iron.  
*Soft iron distortion* stretches or distorts the magnetic field and is caused by metals such as nickel and iron.  
The *calibrated magnetic field* is a magnetic field with hard iron distortion and soft iron distortion correction applied.  
The *uncalibrated magnetic field* is the magnetic field without hard iron distortion correction and with soft iron distortion correction applied, and as such reports changes in the magnetic field caused by magnetized objects moving near the magnetometer.

Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.

#### Inheritance

- [ISensorInProcess](#isensorinprocess)

#### Properties

| **Name** | **Type** | get/set | **Description**                                                                         |
| -------- | -------- | ------- | --------------------------------------------------------------------------------------- |
| X        | double   | get     | Returns a double containing the uncalibrated magnetic field around the device's x axis. |
| Y        | double   | get     | Returns a double containing the uncalibrated magnetic field around the device's y axis. |
| Z        | double   | get     | Returns a double containing the uncalibrated magnetic field around the device's z axis. |
| XBias    | double   | get     | Returns a double representing the hard iron distortion correction around x axis.        |
| YBias    | double   | get     | Returns a double representing the hard iron distortion correction around y axis.        |
| ZBias    | double   | get     | Returns a double representing the hard iron distortion correction around z axis.        |
