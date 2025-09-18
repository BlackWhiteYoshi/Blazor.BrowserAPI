namespace BrowserAPI;

/// <summary>
/// Provides web developers with information about the speed of changes for the device's position and orientation.
/// </summary>
/// <remarks>Warning: Currently, Firefox and Chrome do not handle the coordinates the same way. Take care about this while using them.</remarks>
/// <param name="AccelerationX">
/// <para></para>Returns the acceleration recorded by the device, in meters per second squared (m/s²).
/// <para>The value represents the acceleration along the x axis.</para>
/// </param>
/// <param name="AccelerationY">
/// <para></para>Returns the acceleration recorded by the device, in meters per second squared (m/s²).
/// <para>The value represents the acceleration along the y axis.</para>
/// </param>
/// <param name="AccelerationZ">
/// <para></para>Returns the acceleration recorded by the device, in meters per second squared (m/s²).
/// <para>The value represents the acceleration along the z axis.</para>
/// </param>
/// <param name="AccelerationIncludingGravityX">
/// <para>
/// Returns the amount of acceleration recorded by the device, in meters per second squared (m/s²).<br />
/// Unlike <see cref="AccelerationX"/> which compensates for the influence of gravity,
/// its value is the sum of the acceleration of the device as induced by the user and an acceleration equal and opposite to that caused by gravity.
/// In other words, it measures the g-force.
/// In practice, this value represents the raw data measured by an accelerometer.
/// </para>
/// <para>The value represents the acceleration upon the x axis which is the west to east axis.</para>
/// </param>
/// <param name="AccelerationIncludingGravityY">
/// <para>
/// Returns the amount of acceleration recorded by the device, in meters per second squared (m/s²).<br />
/// Unlike <see cref="AccelerationY"/> which compensates for the influence of gravity,
/// its value is the sum of the acceleration of the device as induced by the user and an acceleration equal and opposite to that caused by gravity.
/// In other words, it measures the g-force.
/// In practice, this value represents the raw data measured by an accelerometer.
/// </para>
/// <para>The value represents the acceleration upon the y axis which is the west to east axis.</para>
/// </param>
/// <param name="AccelerationIncludingGravityZ">
/// <para>
/// Returns the amount of acceleration recorded by the device, in meters per second squared (m/s²).<br />
/// Unlike <see cref="AccelerationZ"/> which compensates for the influence of gravity,
/// its value is the sum of the acceleration of the device as induced by the user and an acceleration equal and opposite to that caused by gravity.
/// In other words, it measures the g-force.
/// In practice, this value represents the raw data measured by an accelerometer.
/// </para>
/// <para>The value represents the acceleration upon the z axis which is the west to east axis.</para>
/// </param>
/// <param name="RotationRateAlpha">
/// <para>Returns the rate at which the device is rotating around each of its axes in degrees per second.</para>
/// <para>The value represents the rate at which the device is rotating about its Z axis; that is, being twisted about a line perpendicular to the screen.</para>
/// </param>
/// <param name="RotationRateBeta">
/// <para>Returns the rate at which the device is rotating around each of its axes in degrees per second.</para>
/// <para>The value represents the rate at which the device is rotating about its X axis; that is, front to back.</para>
/// </param>
/// <param name="RotationRateGamma">
/// <para>Returns the rate at which the device is rotating around each of its axes in degrees per second.</para>
/// <para>The value represents the rate at which the device is rotating about its Y axis; that is, side to side.</para>
/// </param>
/// <param name="Interval">Returns the interval, in milliseconds, at which data is obtained from the underlying hardware. You can use this to determine the granularity of motion events.</param>
public readonly record struct DeviceMotionEvent(
    double? AccelerationX, double? AccelerationY, double? AccelerationZ,
    double? AccelerationIncludingGravityX, double? AccelerationIncludingGravityY, double? AccelerationIncludingGravityZ,
    double? RotationRateAlpha, double? RotationRateBeta, double? RotationRateGamma,
    int Interval);

/// <summary>
/// Provides web developers with information from the physical orientation of the device running the web page.
/// </summary>
/// <param name="absolute">Indicates whether or not the device is providing orientation data absolutely.</param>
/// <param name="alpha">Represents the motion of the device around the z axis, express in degrees with values ranging from 0 (inclusive) to 360 (exclusive).</param>
/// <param name="beta">
/// Represents the motion of the device around the x axis, express in degrees with values ranging from -180 (inclusive) to 180 (exclusive).
/// This represents a front to back motion of the device.
/// </param>
/// <param name="gamma">
/// Represents the motion of the device around the y axis, express in degrees with values ranging from -90 (inclusive) to 90 (exclusive).
/// This represents a left to right motion of the device.
/// </param>
public readonly record struct DeviceOrientationEvent(bool absolute, double? alpha, double? beta, double? gamma);
