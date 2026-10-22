using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The Notification interface of the Notifications API is used to configure and display desktop notifications to the user.</para>
/// <para>These notifications' appearance and specific functionality vary across platforms but generally they provide a way to asynchronously provide information to the user.</para>
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to dispose this object when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(INotificationBase<IJSObjectReference>), typeof(IAsyncDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class Notification(IJSObjectReference notificationJS) : NotificationBase<IJSObjectReference>(notificationJS), INotification {
    /// <summary>
    /// Releases the JS instance for this notification.
    /// </summary>
    /// <returns></returns>
    public ValueTask DisposeAsync() {
        DisposeEventTrigger();
        return notificationJS.DisposeTrySync();
    }


    /// <summary>
    /// Provides the actions available for users to select when interacting with the notification.
    /// </summary>
    public ValueTask<NotificationAction[]> Actions => GetActions(CancellationToken.None);

    /// <inheritdoc cref="Actions" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<NotificationAction[]> GetActions(CancellationToken cancellationToken) => notificationJS.InvokeTrySync<NotificationAction[]>("getActions", cancellationToken);


    /// <summary>
    /// <para>
    /// Contains the URL of a small icon representing the web application itself.
    /// The badge is used by the platform when there is not enough space to display the full notification — for example, in a status bar.
    /// On Android, the badge should accommodate up to 4x display resolution (about 96×96px), and the image will be automatically masked to a monochrome silhouette.
    /// </para>
    /// <para>See <see href="https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerRegistration/showNotification#notifications_with_different_images">Notifications with different images</see> for a comparison of the three image options.</para>
    /// </summary>
    public ValueTask<string> Badge => GetBadge(CancellationToken.None);

    /// <inheritdoc cref="Badge" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetBadge(CancellationToken cancellationToken) => notificationJS.InvokeTrySync<string>("getBadge", cancellationToken);


    /// <summary>
    /// Indicates the body string of the notification, as specified in the body option of the <see cref="INotificationsAPI.CreateNotification">Notification constructor</see>.
    /// </summary>
    public ValueTask<string> Body => GetBody(CancellationToken.None);

    /// <inheritdoc cref="Body" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetBody(CancellationToken cancellationToken) => notificationJS.InvokeTrySync<string>("getBody", cancellationToken);


    /// <summary>
    /// <para>Returns a structured clone of the notification's data, as specified in the data option of the <see cref="INotificationsAPI.CreateNotification">Notification constructor</see>.</para>
    /// <para>The notification's data can be any arbitrary data that you want associated with the notification.</para>
    /// </summary>
    public ValueTask<Dictionary<string, object?>?> Data => GetData(CancellationToken.None);

    /// <inheritdoc cref="Data" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<Dictionary<string, object?>?> GetData(CancellationToken cancellationToken) => notificationJS.InvokeTrySync<Dictionary<string, object?>?>("getData", cancellationToken);


    /// <summary>
    /// <para>Indicates the text direction of the notification, as specified in the dir option of the <see cref="INotificationsAPI.CreateNotification">Notification constructor</see>.</para>
    /// <para>
    /// Possible values are:<br/>
    /// - "auto": adopts the browser's language setting behavior (the default).<br/>
    /// - "ltr": left to right.<br/>
    /// - "rtl": right to left.
    /// </para>
    /// </summary>
    public ValueTask<string> Dir => GetDir(CancellationToken.None);

    /// <inheritdoc cref="Dir" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetDir(CancellationToken cancellationToken) => notificationJS.InvokeTrySync<string>("getDir", cancellationToken);


    /// <summary>
    /// <para>Contains the URL of a small image that reinforces the notification — for example, an app logo or a photo of the message sender. It is displayed alongside the notification title and body.</para>
    /// <para>See <see href="https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerRegistration/showNotification#notifications_with_different_images">Notifications with different images</see> for a comparison of the three image options.</para>
    /// </summary>
    public ValueTask<string> Icon => GetIcon(CancellationToken.None);

    /// <inheritdoc cref="Icon" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetIcon(CancellationToken cancellationToken) => notificationJS.InvokeTrySync<string>("getIcon", cancellationToken);


    /// <summary>
    /// <para>Contains the URL of a large image displayed as part of the notification's content body — for example, a news photo or product thumbnail. It has the highest visual priority of the three image options (image, icon, badge).</para>
    /// <para>See <see href="https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerRegistration/showNotification#notifications_with_different_images">Notifications with different images</see> for a comparison of the three image options.</para>
    /// </summary>
    public ValueTask<string> Image => GetImage(CancellationToken.None);

    /// <inheritdoc cref="Image" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetImage(CancellationToken cancellationToken) => notificationJS.InvokeTrySync<string>("getImage", cancellationToken);


    /// <summary>
    /// <para>Indicates the language used in the notification, as specified in the lang option of the <see cref="INotificationsAPI.CreateNotification">Notification constructor</see>.</para>
    /// <para>The language itself is specified using a string representing a <see href="https://developer.mozilla.org/en-US/docs/Glossary/BCP_47_language_tag">BCP 47 language tag</see>.</para>
    /// </summary>
    public ValueTask<string> Lang => GetLang(CancellationToken.None);

    /// <inheritdoc cref="Lang" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetLang(CancellationToken cancellationToken) => notificationJS.InvokeTrySync<string>("getLang", cancellationToken);


    /// <summary>
    /// <para>Contains the URL the user agent will navigate to when the user activates the notification.</para>
    /// <para>This is the resolved value of the URL, if any, that was specified in the navigate option of the <see cref="INotificationsAPI.CreateNotification">Notification constructor</see> or <see cref="IServiceWorkerRegistrationBase{IJSObjectReference, IServiceWorkerRegistration, INotification}.ShowNotification"/>.</para>
    /// <para>
    /// Normally, activating a non-persistent notification fires the <see cref="INotificationBase{IJSObjectReference}.OnClick">click event</see> on its <see cref="INotification">Notification</see> object,
    /// and activating a persistent notification fires the <see href="https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerGlobalScope/notificationclick_event">notificationclick event</see> on the <see href="https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerGlobalScope">ServiceWorkerGlobalScope</see>.
    /// </para>
    /// <para>
    /// When a notification with a navigation URL is activated by the user, the user agent navigates to the specified URL instead of firing either of these events.
    /// This allows notifications to direct users to a specific page without requiring an event handler.
    /// </para>
    /// </summary>
    public ValueTask<string> Navigate => GetNavigate(CancellationToken.None);

    /// <inheritdoc cref="Navigate" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetNavigate(CancellationToken cancellationToken) => notificationJS.InvokeTrySync<string>("getNavigate", cancellationToken);


    /// <summary>
    /// <para>Specifies whether the user should be notified after a new notification replaces an old one, as specified in the renotify option of the <see cref="INotificationsAPI.CreateNotification">Notification constructor</see>.</para>
    /// <para>false is the default; true makes the notification renotify the user.</para>
    /// </summary>
    public ValueTask<bool> Renotify => GetRenotify(CancellationToken.None);

    /// <inheritdoc cref="Renotify" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetRenotify(CancellationToken cancellationToken) => notificationJS.InvokeTrySync<bool>("getRenotify", cancellationToken);


    /// <summary>
    /// Returns a boolean value indicating that a notification should remain active until the user clicks or dismisses it, rather than closing automatically.
    /// </summary>
    public ValueTask<bool> RequireInteraction => GetRequireInteraction(CancellationToken.None);

    /// <inheritdoc cref="RequireInteraction" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> GetRequireInteraction(CancellationToken cancellationToken) => notificationJS.InvokeTrySync<bool>("getRequireInteraction", cancellationToken);


    /// <summary>
    /// <para>
    /// Specifies whether the notification should be silent, i.e., no sounds or vibrations should be issued regardless of the device settings.
    /// This is controlled via the silent option of the <see cref="INotificationsAPI.CreateNotification">Notification constructor</see>.
    /// </para>
    /// <para>If set to true, the notification is silent; if set to null (the default value), the device's default settings are respected.</para>
    /// </summary>
    public ValueTask<bool?> Silent => GetSilent(CancellationToken.None);

    /// <inheritdoc cref="Silent" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool?> GetSilent(CancellationToken cancellationToken) {
        int silent = await notificationJS.InvokeTrySync<int>("getSilent", cancellationToken);
        return silent switch {
            0 => false,
            1 => true,
            2 => null,
            _ => throw new JSException($"Invalid result from JS function getSilent(): {silent}. Only 0 (false), 1 (true), 2 (null) are allowed.")
        };
    }


    /// <summary>
    /// <para>Signifies an identifying tag for the notification, as specified in the tag option of the <see cref="INotificationsAPI.CreateNotification">Notification constructor</see>.</para>
    /// <para>
    /// The idea of notification tags is that more than one notification can share the same tag, linking them together.
    /// One notification can then be programmatically replaced with another to avoid the users' screen being filled up with a huge number of similar notifications.
    /// </para>
    /// </summary>
    public ValueTask<string> Tag => GetTag(CancellationToken.None);

    /// <inheritdoc cref="Tag" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetTag(CancellationToken cancellationToken) => notificationJS.InvokeTrySync<string>("getTag", cancellationToken);


    /// <summary>
    /// <para>Returns a number, as specified in the timestamp option of the <see cref="INotificationsAPI.CreateNotification">Notification constructor</see>.</para>
    /// <para>
    /// The notification's timestamp can represent the time, in milliseconds since 00:00:00 UTC on 1 January 1970, of the event for which the notification was created,
    /// or it can be an arbitrary timestamp that you want associated with the notification.
    /// For example, a timestamp for an upcoming meeting could be set in the future, whereas a timestamp for a missed message could be set in the past.
    /// </para>
    /// </summary>
    public ValueTask<long> Timestamp => GetTimestamp(CancellationToken.None);

    /// <inheritdoc cref="Timestamp" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<long> GetTimestamp(CancellationToken cancellationToken) => notificationJS.InvokeTrySync<long>("getTimestamp", cancellationToken);


    /// <summary>
    /// Indicates the title of the notification, as specified in the title parameter of the <see cref="INotificationsAPI.CreateNotification">Notification constructor</see>.
    /// </summary>
    public ValueTask<string> Title => GetTitle(CancellationToken.None);

    /// <inheritdoc cref="Title" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetTitle(CancellationToken cancellationToken) => notificationJS.InvokeTrySync<string>("getTitle", cancellationToken);


    /// <summary>
    /// Specifies a vibration pattern for the device's vibration hardware to emit when the notification fires.
    /// This is specified in the vibrate option of the <see cref="INotificationsAPI.CreateNotification">Notification constructor</see>.
    /// </summary>
    public ValueTask<int[]> Vibrate => GetVibrate(CancellationToken.None);

    /// <inheritdoc cref="Vibrate" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<int[]> GetVibrate(CancellationToken cancellationToken) => notificationJS.InvokeTrySync<int[]>("getVibrate", cancellationToken);



    /// <summary>
    /// Closes/Removes a previously displayed notification.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Close(CancellationToken cancellationToken = default) => notificationJS.InvokeVoidTrySync("close", cancellationToken);
}
