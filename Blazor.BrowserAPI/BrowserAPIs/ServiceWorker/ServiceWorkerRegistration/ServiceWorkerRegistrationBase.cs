using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// Base interface of <see cref="IServiceWorkerRegistration"/> and <see cref="IServiceWorkerRegistrationInProcess"/>.<br/>
/// It contains common functionality for both interfaces.<br/>
/// It is not intended to use this interface directly.
/// </summary>
/// <typeparam name="TJSObjectReference"></typeparam>
/// <typeparam name="TServiceWorkerRegistration"></typeparam>
/// <typeparam name="TNotification"></typeparam>
/// <param name="serviceWorkerRegistrationJS"></param>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class ServiceWorkerRegistrationBase<TJSObjectReference, TServiceWorkerRegistration, TNotification>(TJSObjectReference serviceWorkerRegistrationJS)
    where TJSObjectReference : IJSObjectReference
    where TServiceWorkerRegistration : IServiceWorkerRegistrationBase<TJSObjectReference, TServiceWorkerRegistration, TNotification>
    where TNotification : INotificationBase<TJSObjectReference> {
    private protected TJSObjectReference serviceWorkerRegistrationJS = serviceWorkerRegistrationJS;


    /// <summary>
    /// Attempts to update the service worker.
    /// It fetches the worker's script URL, and if the new worker is not byte-by-byte identical to the current worker, it installs the new worker.
    /// The fetch of the worker bypasses any browser caches if the previous fetch occurred over 24 hours ago.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<TServiceWorkerRegistration> Update(CancellationToken cancellationToken = default) {
        TJSObjectReference serviceWorkerRegistration = await serviceWorkerRegistrationJS.InvokeAsync<TJSObjectReference>("update", cancellationToken);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference))
            return (TServiceWorkerRegistration)(IServiceWorkerRegistration)new ServiceWorkerRegistration(serviceWorkerRegistration);
        else
            return (TServiceWorkerRegistration)(IServiceWorkerRegistrationInProcess)new ServiceWorkerRegistrationInProcess((IJSInProcessObjectReference)serviceWorkerRegistration);
    }

    /// <summary>
    /// Unregisters the service worker registration and returns a Promise.
    /// The promise will resolve to false if no registration was found, otherwise it resolves to true irrespective of whether unregistration happened or not (it may not unregister if someone else just called ServiceWorkerContainer.register() with the same scope.)
    /// The service worker will finish any ongoing operations before it is unregistered.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>false if no registration was found, otherwise true (irrespective of whether unregistration happened or not)</returns>
    public ValueTask<bool> Unregister(CancellationToken cancellationToken = default) => serviceWorkerRegistrationJS.InvokeAsync<bool>("unregister", cancellationToken);

    /// <summary>
    /// <para>Creates a notification on an active service worker.</para>
    /// <para>This is a persistent notification, it remains interactive beyond the lifetime of an individual page.</para>
    /// </summary>
    /// <param name="title">Defines a title for the notification, which is shown at the top of the notification window.</param>
    /// <param name="actions">An array of actions to display in the notification, for which the default is an empty array.</param>
    /// <param name="badge">Containing the URL of a small icon representing the web application itself. The badge is used by the platform when there is not enough space to display the full notification — for example, in a status bar. It should have less visual priority than the icon and image options. On Android, the badge should accommodate up to 4x display resolution (about 96×96px), and the image will be automatically masked to a monochrome silhouette.</param>
    /// <param name="body">Representing the body text of the notification, which is displayed below the title. The default is the empty string.</param>
    /// <param name="data">Arbitrary data that you want associated with the notification. This can be of any structured-clonable data type. The default is null.</param>
    /// <param name="dir">The direction in which to display the notification. It defaults to <b>"auto"</b>, which just adopts the browser's language setting behavior, but you can override that behavior by setting values of <b>"ltr"</b> and <b>"rtl"</b> (although most browsers seem to ignore these settings.)</param>
    /// <param name="icon">Containing the URL of a small image that reinforces the notification — for example, an app logo or a photo of the message sender. It is displayed alongside the notification title and body.</param>
    /// <param name="image">Containing the URL of a large image displayed as part of the notification's content body — for example, a news photo or product thumbnail. It has the highest visual priority of the three image options (image, icon, badge). See <see href="https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerRegistration/showNotification#notifications_with_different_images">Notifications with different images</see> for a comparison of these three image options.</param>
    /// <param name="lang">The notification's language, as specified using a string representing a BCP 47 language tag. The default is the empty string.</param>
    /// <param name="navigate">Containing a URL to navigate to when the user activates the notification. When set, the user agent navigates to this URL instead of firing the notificationclick event. The value is parsed relative to the base URL of the service worker. See <see cref="INotificationInProcess.Navigate"/> for more information.</param>
    /// <param name="renotify">Specifies whether the user should be notified after a new notification replaces an old one. The default is false, which means they won't be notified. If true, tag must also be set.</param>
    /// <param name="requireInteraction">Indicates that a notification should remain active until the user clicks or dismisses it, rather than closing automatically. The default value is false.</param>
    /// <param name="silent">Specifies whether the notification is silent (no sounds or vibrations issued), regardless of the device settings. The default, null, means to respect device defaults. If true, then vibrate must not be present.</param>
    /// <param name="tag">Representing an identifying tag for the notification. The default is the empty string.</param>
    /// <param name="timestamp">A timestamp, given as Unix time in milliseconds, representing the time associated with the notification. This could be in the past when a notification is used for a message that couldn't immediately be delivered because the device was offline, or in the future for a meeting that is about to start.</param>
    /// <param name="vibrate">A vibration pattern for the device's vibration hardware to emit with the notification. If specified, silent must not be true.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask ShowNotification(string title, NotificationAction[]? actions = null, string? badge = null, string body = "", Dictionary<string, object?>? data = null, string dir = "auto", string? icon = null, string? image = null, string lang = "", string? navigate = null, bool renotify = false, bool requireInteraction = false, bool? silent = null, string tag = "", long? timestamp = null, int[]? vibrate = null, CancellationToken cancellationToken = default)
        => serviceWorkerRegistrationJS.InvokeVoidAsync("showNotification", cancellationToken, [title, actions, badge, body, data, dir, icon, image, lang, navigate, renotify, requireInteraction, silent, tag, timestamp, vibrate]);

    /// <summary>
    /// Returns a list of the notifications in the order that they were created from the current origin via the current service worker registration.
    /// Origins can have many active but differently-scoped service worker registrations.
    /// Notifications created by one service worker on the same origin will not be available to other active service workers on that same origin.
    /// </summary>
    /// <remarks>Do not forget to <i>Dispse</i> all notification object when you done with it.</remarks>
    /// <param name="tag">Represents a notification tag. If specified, only notifications that have this tag will be returned.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<TNotification[]> GetNotifications(string? tag = null, CancellationToken cancellationToken = default) {
        TJSObjectReference[] notifications = await serviceWorkerRegistrationJS.InvokeAsync<TJSObjectReference[]>("getNotifications", cancellationToken, [tag]);

        TNotification[] result = new TNotification[notifications.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = typeof(TJSObjectReference) == typeof(IJSObjectReference)
                ? (TNotification)(INotification)new Notification(notifications[i])
                : (TNotification)(INotificationInProcess)new NotificationInProcess((IJSInProcessObjectReference)notifications[i]);
        return result;
    }


    #region Events

    [method: DynamicDependency(nameof(InvokeUpdateFound))]
    private sealed class EventTrigger(ServiceWorkerRegistrationBase<TJSObjectReference, TServiceWorkerRegistration, TNotification> serviceWorkerRegistration) {
        [JSInvokable]
        public void InvokeUpdateFound() => serviceWorkerRegistration._onUpdateFound?.Invoke();
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return serviceWorkerRegistrationJS.InvokeVoidTrySync("initEvents", [_objectReferenceEventTrigger]);
    }

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await serviceWorkerRegistrationJS.InvokeVoidTrySync(jsMethodName);
    }

    private ValueTask DeactivateJSEvent(string jsMethodName) => serviceWorkerRegistrationJS.InvokeVoidTrySync(jsMethodName);


    // Events

    private Action? _onUpdateFound;
    /// <summary>
    /// Is fired any time the <i>ServiceWorkerRegistration.installing</i> property acquires a new service worker.
    /// </summary>
    public event Action OnUpdateFound {
        add {
            if (_onUpdateFound == null)
                _ = ActivateJSEvent("activateOnupdatefound").Preserve();
            _onUpdateFound += value;
        }
        remove {
            _onUpdateFound -= value;
            if (_onUpdateFound == null)
                _ = DeactivateJSEvent("deactivateOnupdatefound").Preserve();
            ;
        }
    }

    #endregion
}
