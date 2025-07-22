using AutoInterfaceAttributes;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IGeolocation")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IGeolocationInProcess")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class GeolocationBase(IModuleManager moduleManager) {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IModuleManager moduleManager = moduleManager;


    /// <summary>
    /// Is used to get the current position of the device.
    /// </summary>
    /// <param name="maximumAge">
    /// A positive long value indicating the maximum age in milliseconds of a possible cached position that is acceptable to return.
    /// If set to 0, it means that the device cannot use a cached position and must attempt to retrieve the real current position.
    /// If set to a value less than zero the device must return a cached position regardless of its age.
    /// Default: 0.
    /// </param>
    /// <param name="timeout">
    /// A positive long value representing the maximum length of time (in milliseconds) the device is allowed to take in order to return a position.
    /// The default value is -1, meaning that getCurrentPosition() won't return until the position is available.
    /// </param>
    /// <param name="enableHighAccuracy">
    /// A boolean value that indicates the application would like to receive the best possible results.
    /// If true and if the device is able to provide a more accurate position, it will do so.
    /// Note that this can result in slower response times or increased power consumption (with a GPS chip on a mobile device for example).
    /// On the other hand, if false, the device can take the liberty to save resources by responding more quickly and/or using less power.
    /// Default: false.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// <para>If successful, a <see cref="GeolocationCoordinates"/> object and a <see cref="long"/> timestamp.</para>
    /// <para>
    /// GeolocationCoordinates:<br />
    /// The GeolocationCoordinates interface represents the position and altitude of the device on Earth, as well as the accuracy with which these properties are calculated.
    /// The geographic position information is provided in terms of World Geodetic System coordinates (WGS84).
    /// </para>
    /// <para>
    /// timestamp:<br />
    /// Returns a timestamp, given as Unix time in milliseconds, representing the time at which the location was retrieved.
    /// </para>
    /// <para>If error, an object is returned containing an <see cref="int"/> errorCode and <see cref="string"/> message.</para>
    /// <para>
    /// errorCode:<br />
    /// Returns an unsigned short representing the error code.
    /// The following values are possible:<br />
    /// 1: PERMISSION_DENIED - The acquisition of the geolocation information failed because the page didn't have the necessary permissions, for example because it is blocked by a Permissions Policy<br />
    /// 2: POSITION_UNAVAILABLE - The acquisition of the geolocation failed because at least one internal source of position returned an internal error.<br />
    /// 3: TIMEOUT - The time allowed to acquire the geolocation was reached before the information was obtained.
    /// </para>
    /// <para>
    /// message:<br />
    /// Returns a human-readable string describing the details of the error.
    /// Specifications note that this is primarily intended for debugging use and not to be shown directly in a user interface.
    /// </para>
    /// </returns>
    public ValueTask<GeolocationCoordinates> GetCurrentPositionAsync(long maximumAge = 0, long timeout = -1, bool enableHighAccuracy = false, CancellationToken cancellationToken = default) {
        return moduleManager.InvokeAsync<GeolocationCoordinates>("GeolocationAPI.getCurrentPositionAsync", cancellationToken, [maximumAge, timeout, enableHighAccuracy]);
    }
}
