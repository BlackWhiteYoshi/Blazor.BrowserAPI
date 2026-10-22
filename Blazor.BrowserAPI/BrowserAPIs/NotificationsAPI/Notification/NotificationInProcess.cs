using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The Notification interface of the Notifications API is used to configure and display desktop notifications to the user.</para>
/// <para>These notifications' appearance and specific functionality vary across platforms but generally they provide a way to asynchronously provide information to the user.</para>
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to dispose this object when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(INotificationBase<IJSInProcessObjectReference>), typeof(IDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class NotificationInProcess(IJSInProcessObjectReference notificationJS) : NotificationBase<IJSInProcessObjectReference>(notificationJS), INotificationInProcess {
    /// <summary>
    /// Releases the JS instance for this notification.
    /// </summary>
    /// <returns></returns>
    public void Dispose() {
        DisposeEventTrigger();
        notificationJS.Dispose();
    }


    /// <summary>
    /// Provides the actions available for users to select when interacting with the notification.
    /// </summary>
    public NotificationAction[] Actions => notificationJS.Invoke<NotificationAction[]>("getActions");

    /// <summary>
    /// <para>
    /// Contains the URL of a small icon representing the web application itself.
    /// The badge is used by the platform when there is not enough space to display the full notification — for example, in a status bar.
    /// On Android, the badge should accommodate up to 4x display resolution (about 96×96px), and the image will be automatically masked to a monochrome silhouette.
    /// </para>
    /// <para>See <see href="https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerRegistration/showNotification#notifications_with_different_images">Notifications with different images</see> for a comparison of the three image options.</para>
    /// </summary>
    public string Badge => notificationJS.Invoke<string>("getBadge");

    /// <summary>
    /// Indicates the body string of the notification, as specified in the body option of the <see cref="INotificationsAPIInProcess.CreateNotification">Notification constructor</see>.
    /// </summary>
    public string Body => notificationJS.Invoke<string>("getBody");

    /// <summary>
    /// <para>Returns a structured clone of the notification's data, as specified in the data option of the <see cref="INotificationsAPIInProcess.CreateNotification">Notification constructor</see>.</para>
    /// <para>The notification's data can be any arbitrary data that you want associated with the notification.</para>
    /// </summary>
    public Dictionary<string, object?>? Data => notificationJS.Invoke<Dictionary<string, object?>?>("getData");

    /// <summary>
    /// <para>Indicates the text direction of the notification, as specified in the dir option of the <see cref="INotificationsAPIInProcess.CreateNotification">Notification constructor</see>.</para>
    /// <para>
    /// Possible values are:<br/>
    /// - "auto": adopts the browser's language setting behavior (the default).<br/>
    /// - "ltr": left to right.<br/>
    /// - "rtl": right to left.
    /// </para>
    /// </summary>
    public string Dir => notificationJS.Invoke<string>("getDir");

    /// <summary>
    /// <para>Contains the URL of a small image that reinforces the notification — for example, an app logo or a photo of the message sender. It is displayed alongside the notification title and body.</para>
    /// <para>See <see href="https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerRegistration/showNotification#notifications_with_different_images">Notifications with different images</see> for a comparison of the three image options.</para>
    /// </summary>
    public string Icon => notificationJS.Invoke<string>("getIcon");

    /// <summary>
    /// <para>Contains the URL of a large image displayed as part of the notification's content body — for example, a news photo or product thumbnail. It has the highest visual priority of the three image options (image, icon, badge).</para>
    /// <para>See <see href="https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerRegistration/showNotification#notifications_with_different_images">Notifications with different images</see> for a comparison of the three image options.</para>
    /// </summary>
    public string Image => notificationJS.Invoke<string>("getImage");

    /// <summary>
    /// <para>Indicates the language used in the notification, as specified in the lang option of the <see cref="INotificationsAPIInProcess.CreateNotification">Notification constructor</see>.</para>
    /// <para>The language itself is specified using a string representing a <see href="https://developer.mozilla.org/en-US/docs/Glossary/BCP_47_language_tag">BCP 47 language tag</see>.</para>
    /// </summary>
    public string Lang => notificationJS.Invoke<string>("getLang");

    /// <summary>
    /// <para>Contains the URL the user agent will navigate to when the user activates the notification.</para>
    /// <para>This is the resolved value of the URL, if any, that was specified in the navigate option of the <see cref="INotificationsAPIInProcess.CreateNotification">Notification constructor</see> or <see cref="IServiceWorkerRegistrationBase{IJSInProcessObjectReference, IServiceWorkerRegistrationInProcess, INotificationInProcess}.ShowNotification"/>.</para>
    /// <para>
    /// Normally, activating a non-persistent notification fires the <see cref="INotificationBase{IJSInProcessObjectReference}.OnClick">click event</see> on its <see cref="INotificationInProcess">Notification</see> object,
    /// and activating a persistent notification fires the <see href="https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerGlobalScope/notificationclick_event">notificationclick event</see> on the <see href="https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerGlobalScope">ServiceWorkerGlobalScope</see>.
    /// </para>
    /// <para>
    /// When a notification with a navigation URL is activated by the user, the user agent navigates to the specified URL instead of firing either of these events.
    /// This allows notifications to direct users to a specific page without requiring an event handler.
    /// </para>
    /// </summary>
    public string Navigate => notificationJS.Invoke<string>("getNavigate");

    /// <summary>
    /// <para>Specifies whether the user should be notified after a new notification replaces an old one, as specified in the renotify option of the <see cref="INotificationsAPIInProcess.CreateNotification">Notification constructor</see>.</para>
    /// <para>false is the default; true makes the notification renotify the user.</para>
    /// </summary>
    public bool Renotify => notificationJS.Invoke<bool>("getRenotify");

    /// <summary>
    /// Returns a boolean value indicating that a notification should remain active until the user clicks or dismisses it, rather than closing automatically.
    /// </summary>
    public bool RequireInteraction => notificationJS.Invoke<bool>("getRequireInteraction");

    /// <summary>
    /// <para>
    /// Specifies whether the notification should be silent, i.e., no sounds or vibrations should be issued regardless of the device settings.
    /// This is controlled via the silent option of the <see cref="INotificationsAPIInProcess.CreateNotification">Notification constructor</see>.
    /// </para>
    /// <para>If set to true, the notification is silent; if set to null (the default value), the device's default settings are respected.</para>
    /// </summary>
    public bool? Silent {
        get {
            int silent = notificationJS.Invoke<int>("getSilent");
            return silent switch {
                0 => false,
                1 => true,
                2 => null,
                _ => throw new JSException($"Invalid result from JS function getSilent(): {silent}. Only 0 (false), 1 (true), 2 (null) are allowed.")
            };
        }
    }

    /// <summary>
    /// <para>Signifies an identifying tag for the notification, as specified in the tag option of the <see cref="INotificationsAPIInProcess.CreateNotification">Notification constructor</see>.</para>
    /// <para>
    /// The idea of notification tags is that more than one notification can share the same tag, linking them together.
    /// One notification can then be programmatically replaced with another to avoid the users' screen being filled up with a huge number of similar notifications.
    /// </para>
    /// </summary>
    public string Tag => notificationJS.Invoke<string>("getTag");

    /// <summary>
    /// <para>Returns a number, as specified in the timestamp option of the <see cref="INotificationsAPIInProcess.CreateNotification">Notification constructor</see>.</para>
    /// <para>
    /// The notification's timestamp can represent the time, in milliseconds since 00:00:00 UTC on 1 January 1970, of the event for which the notification was created,
    /// or it can be an arbitrary timestamp that you want associated with the notification.
    /// For example, a timestamp for an upcoming meeting could be set in the future, whereas a timestamp for a missed message could be set in the past.
    /// </para>
    /// </summary>
    public long Timestamp => notificationJS.Invoke<long>("getTimestamp");

    /// <summary>
    /// Indicates the title of the notification, as specified in the title parameter of the <see cref="INotificationsAPIInProcess.CreateNotification">Notification constructor</see>.
    /// </summary>
    public string Title => notificationJS.Invoke<string>("getTitle");

    /// <summary>
    /// Specifies a vibration pattern for the device's vibration hardware to emit when the notification fires.
    /// This is specified in the vibrate option of the <see cref="INotificationsAPIInProcess.CreateNotification">Notification constructor</see>.
    /// </summary>
    public int[] Vibrate => notificationJS.Invoke<int[]>("getVibrate");


    /// <summary>
    /// Closes/Removes a previously displayed notification.
    /// </summary>
    public void Close() => notificationJS.InvokeVoid("close");
}
