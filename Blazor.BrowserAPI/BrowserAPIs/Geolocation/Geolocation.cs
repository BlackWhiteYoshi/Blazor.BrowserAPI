using AutoInterfaceAttributes;
using Microsoft.JSInterop;

namespace BrowserAPI.Implementation;

/// <summary>
/// The Geolocation API allows the user to provide their location to web applications if they so desire. For privacy reasons, the user is asked for permission to report location information.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
public sealed class Geolocation(IModuleManager moduleManager) : GeolocationBase(moduleManager), IGeolocation {
    /// <summary>
    /// Is used to get the current position of the device.
    /// </summary>
    /// <param name="successCallback">
    /// <para>A callback function that takes a <see cref="GeolocationCoordinates"/> object and a <see cref="long"/> timestamp  as its input parameter.</para>
    /// <para>
    /// GeolocationCoordinates:<br />
    /// The GeolocationCoordinates interface represents the position and altitude of the device on Earth, as well as the accuracy with which these properties are calculated.
    /// The geographic position information is provided in terms of World Geodetic System coordinates (WGS84).<br />
    /// The timestamp is also included.
    /// </para>
    /// </param>
    /// <param name="errorCallback">
    /// <para>An optional callback function that takes an <see cref="int"/> errorCode and <see cref="string"/> message as its input parameter.</para>
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
    /// </param>
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
    /// <returns></returns>
    public ValueTask GetCurrentPosition(Action<GeolocationCoordinates> successCallback, Action<int, string>? errorCallback = null, long maximumAge = 0, long timeout = -1, bool enableHighAccuracy = false, CancellationToken cancellationToken = default) {
        DotNetObjectReference<Callback> callbackGeolocation = DotNetObjectReference.Create(new Callback(null!));
        callbackGeolocation.Value.SuccessHandler = (GeolocationCoordinates geolocationCoordinates) => {
            successCallback(geolocationCoordinates);
            callbackGeolocation.Dispose();
        };
        callbackGeolocation.Value.ErrorHandler = (int errorCode, string message) => {
            errorCallback?.Invoke(errorCode, message);
            callbackGeolocation.Dispose();
        };

        return moduleManager.InvokeTrySync("GeolocationAPI.getCurrentPosition", cancellationToken, [callbackGeolocation,  maximumAge, timeout, enableHighAccuracy]);
    }


    /// <summary>
    /// Is used to register a handler function that will be called automatically each time the position of the device changes.
    /// You can also, optionally, specify an error handling callback function.
    /// </summary>
    /// <param name="successCallback">
    /// <para>A callback function that takes a <see cref="GeolocationCoordinates"/> object and a <see cref="long"/> timestamp  as its input parameter.</para>
    /// <para>
    /// GeolocationCoordinates:<br />
    /// The GeolocationCoordinates interface represents the position and altitude of the device on Earth, as well as the accuracy with which these properties are calculated.
    /// The geographic position information is provided in terms of World Geodetic System coordinates (WGS84).
    /// </para>
    /// <para>
    /// timestamp:<br />
    /// Returns a timestamp, given as Unix time in milliseconds, representing the time at which the location was retrieved.
    /// </para>
    /// </param>
    /// <param name="errorCallback">
    /// <para>An optional callback function that takes an <see cref="int"/> errorCode and <see cref="string"/> message as its input parameter.</para>
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
    /// </param>
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
    /// <returns>WatchId - can be used to <see cref="ClearWatch">clear</see> this registration.</returns>
    public async ValueTask<GeolocationWatchHandle> WatchPosition(Action<GeolocationCoordinates> successCallback, Action<int, string>? errorCallback = null, long maximumAge = 0, long timeout = -1, bool enableHighAccuracy = false, CancellationToken cancellationToken = default) {
        DotNetObjectReference<Callback> callbackGeolocation = DotNetObjectReference.Create(new Callback(successCallback, errorCallback));
        int watchId = await moduleManager.InvokeTrySync<int>("GeolocationAPI.watchPosition", cancellationToken, [callbackGeolocation, maximumAge, timeout, enableHighAccuracy]);
        return new GeolocationWatchHandle(watchId, callbackGeolocation);
    }

    /// <summary>
    /// Is used to unregister location/error monitoring handlers previously installed using <see cref="WatchPosition"/>.
    /// </summary>
    /// <param name="watchId">The id of the registration from <see cref="WatchPosition"/></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask ClearWatch(GeolocationWatchHandle geolocationWatchHandle, CancellationToken cancellationToken = default) {
        await moduleManager.InvokeTrySync("GeolocationAPI.clearWatch", cancellationToken, [geolocationWatchHandle.id]);
        geolocationWatchHandle.callback.Dispose();
    }
}
