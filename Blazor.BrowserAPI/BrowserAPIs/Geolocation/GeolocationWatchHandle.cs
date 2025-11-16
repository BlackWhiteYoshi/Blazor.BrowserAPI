using BrowserAPI.Implementation;
using Microsoft.JSInterop;

namespace BrowserAPI;

/// <summary>
/// <para>
/// The return value of <see cref="IGeolocation.WatchPosition"/> or <see cref="IGeolocationInProcess.WatchPosition"/>.<br />
/// It can be used to call <see cref="IGeolocation.ClearWatch"/> / <see cref="IGeolocationInProcess.ClearWatch"/>.
/// </para>
/// <para>It contains the watch id as well as the function handler.</para>
/// </summary>
public readonly struct GeolocationWatchHandle {
    internal readonly int id;
    internal readonly DotNetObjectReference<GeolocationBase.Callback> callback;
    internal GeolocationWatchHandle(int id, DotNetObjectReference<GeolocationBase.Callback> callback) => (this.id, this.callback) = (id, callback);

    /// <summary>
    /// An integer ID that identifies the registered handler. The ID can be passed to the clearWatch() to unregister the handler.
    /// </summary>
    public int Id => id;

    /// <summary>
    /// The callback handler that was used as parameter for the success case on the <see cref="IGeolocation.WatchPosition"/> / <see cref="IGeolocationInProcess.WatchPosition"/> call.
    /// </summary>
    public Action<GeolocationCoordinates> SuccessCallback => callback.Value.SuccessHandler;

    /// <summary>
    /// The callback handler that was used as parameter for the error case on the <see cref="IGeolocation.WatchPosition"/> / <see cref="IGeolocationInProcess.WatchPosition"/> call.
    /// </summary>
    public Action<int, string>? ErrorCallback => callback.Value.ErrorHandler;
}
