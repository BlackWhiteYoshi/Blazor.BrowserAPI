using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>Callback class for <see cref="Geolocation.GetCurrentPosition"/> and <see cref="Geolocation.WatchPosition"/>.</para>
/// <para>It contains 2 callbacks: <see cref="Success"/> and <see cref="Error"/>.</para>
/// </summary>
/// <param name="successCallback">callback with parameters GeolocationCoordinates geolocationCoordinates, long timestamp</param>
/// <param name="errorCallback">callback with parameters int errorCode, string message</param>
[method: DynamicDependency(nameof(Success))]
[method: DynamicDependency(nameof(Error))]
internal sealed class CallbackGeolocation(Action<GeolocationCoordinates> successCallback, Action<int, string>? errorCallback = null) {
    public Action<GeolocationCoordinates> SuccessCallback { get; set; } = successCallback;
    public Action<int, string>? ErrorCallback { get; set; } = errorCallback;


    [JSInvokable]
    public void Success(GeolocationCoordinates geolocationCoordinates) => SuccessCallback(geolocationCoordinates);

    [JSInvokable]
    public void Error(int errorCode, string message) => ErrorCallback?.Invoke(errorCode, message);
}
