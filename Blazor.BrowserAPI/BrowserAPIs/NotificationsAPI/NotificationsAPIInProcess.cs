using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The Notifications API allows web pages to control the display of system notifications to the end user.
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class NotificationsAPIInProcess(IModuleManager moduleManager) : NotificationsAPIBase(moduleManager), INotificationsAPIInProcess {
    /// <summary>Creates a new instance of the Notification object.</summary>
    /// <remarks>
    /// Warning<br/>
    /// This creates a <i>Non-persistent notification</i>:<br/>
    /// Their lifetime is tied to the lifetime of the page — if the page is closed, the notification can no longer be interacted with.
    /// Also, it throws a TypeError when called in nearly all mobile browsers.<br/>
    /// Consider creating a <i>Persistent notification</i>: Instead, you need to register a service worker and use <see cref="IServiceWorkerRegistrationBase{IJSInProcessObjectReference, IServiceWorkerRegistrationInProcess, INotificationInProcess}.ShowNotification"/>.<br/>
    /// For more information, see <see href="https://developer.mozilla.org/en-US/docs/Web/API/Notifications_API#persistent_and_non-persistent_notifications">Persistent and non-persistent notifications</see>.
    /// </remarks>
    /// <param name="title">Defines a title for the notification, which is shown at the top of the notification window.</param>
    /// <param name="badge">Containing the URL of a small icon representing the web application itself. The badge is used by the platform when there is not enough space to display the full notification — for example, in a status bar. It should have less visual priority than the icon and image options. On Android, the badge should accommodate up to 4x display resolution (about 96×96px), and the image will be automatically masked to a monochrome silhouette.</param>
    /// <param name="body">Representing the body text of the notification, which is displayed below the title. The default is the empty string.</param>
    /// <param name="data">Arbitrary data that you want associated with the notification. This can be of any structured-clonable data type. The default is null.</param>
    /// <param name="dir">The direction in which to display the notification. It defaults to <b>"auto"</b>, which just adopts the browser's language setting behavior, but you can override that behavior by setting values of <b>"ltr"</b> and <b>"rtl"</b> (although most browsers seem to ignore these settings.)</param>
    /// <param name="icon">Containing the URL of a small image that reinforces the notification — for example, an app logo or a photo of the message sender. It is displayed alongside the notification title and body.</param>
    /// <param name="image">Containing the URL of a large image displayed as part of the notification's content body — for example, a news photo or product thumbnail. It has the highest visual priority of the three image options (image, icon, badge). See <see href="https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerRegistration/showNotification#notifications_with_different_images">Notifications with different images</see> for a comparison of these three image options.</param>
    /// <param name="lang">The notification's language, as specified using a string representing a BCP 47 language tag. The default is the empty string.</param>
    /// <param name="navigate">Containing a URL to navigate to when the user activates the notification. When set, the user agent navigates to this URL instead of firing the <see cref="INotificationBase{IJSInProcessObjectReference}.OnClick">click event</see>. The value is parsed relative to the base URL of the page. See <see cref="INotificationInProcess.Navigate"/> for more information.</param>
    /// <param name="renotify">Specifies whether the user should be notified after a new notification replaces an old one. The default is false, which means they won't be notified. If true, tag must also be set.</param>
    /// <param name="requireInteraction">Indicates that a notification should remain active until the user clicks or dismisses it, rather than closing automatically. The default value is false.</param>
    /// <param name="silent">Specifies whether the notification should be silent, i.e., no sounds or vibrations should be issued regardless of the device settings. If set to true, the notification is silent; if set to null (the default value), the device's default settings are respected.</param>
    /// <param name="tag">Representing an identifying tag for the notification. The default is the empty string.</param>
    /// <param name="timestamp">A timestamp, given as Unix time in milliseconds, representing the time associated with the notification. This could be in the past when a notification is used for a message that couldn't immediately be delivered because the device was offline, or in the future for a meeting that is about to start.</param>
    /// <param name="vibrate">A vibration pattern for the device's vibration hardware to emit with the notification. If specified, silent must not be true.</param>
    /// <returns>An instance of the Notification object.</returns>
    public INotificationInProcess CreateNotification(string title, string? badge = null, string body = "", Dictionary<string, object?>? data = null, string dir = "auto", string? icon = null, string? image = null, string lang = "", string? navigate = null, bool renotify = false, bool requireInteraction = false, bool? silent = null, string tag = "", long? timestamp = null, int[]? vibrate = null) {
        IJSInProcessObjectReference notificationJS = moduleManager.InvokeSync<IJSInProcessObjectReference>("NotificationsAPI.create", [title, badge, body, data, dir, icon, image, lang, navigate, renotify, requireInteraction, silent, tag, timestamp, vibrate]);
        return new NotificationInProcess(notificationJS);
    }


    /// <summary>
    /// <para>Representing the current permission to display notifications.</para>
    /// <para>
    /// Possible values are:<br/>
    /// - "denied": The user refuses to have notifications displayed.<br/>
    /// - "granted": The user accepts having notifications displayed.<br/>
    /// - "default": The user choice is unknown and therefore the browser will act as if the value were denied.
    /// </para>
    /// </summary>
    public string Permission => moduleManager.InvokeSync<string>("NotificationsAPI.getPermission");

    /// <summary>
    /// <para>The maximum number of actions that can be displayed in a notification.</para>
    /// <para>Notification actions are buttons or controls that appear within persistent notifications. Actions are set using the actions option of the second argument of the <see cref="IServiceWorkerRegistrationBase{IJSInProcessObjectReference, IServiceWorkerRegistrationInProcess, INotificationInProcess}.ShowNotification"/> method.</para>
    /// <para>Browsers typically limit the maximum number of actions they will display for a particular notification. The maxActions property returns that limit, which is the maximum number of elements in the Notification.actions array that will be respected by the user agent.</para>
    /// </summary>
    public int MaxActions => moduleManager.InvokeSync<int>("NotificationsAPI.getMaxActions");
}
