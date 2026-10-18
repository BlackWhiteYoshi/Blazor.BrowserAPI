namespace BrowserAPI;

/// <summary>
/// <para>
/// Notification actions are buttons or controls that appear within persistent notifications.
/// They are set using the actions option of the second argument of the <see cref="IServiceWorkerRegistrationBase{IJSObjectReference, IServiceWorkerRegistration, INotification}.ShowNotification"/> method.
/// Note that actions are not available for non-persistent notifications.
/// If you pass an options object with an actions property that is anything other than null to the Notification() constructor, a TypeError is thrown.
/// </para>
/// <para>
/// Clicking the button associated with an action navigates to the URL set in the navigate option if one is specified.
/// Otherwise, it fires a notificationclick event on the service worker that includes the action that was selected (and the associated Notification instance),
/// so the worker can handle it without the user ever switching to your page.
/// </para>
/// </summary>
/// <param name="Action">Identifies a user action to be displayed on the notification.</param>
/// <param name="Title">Contains action text to be shown to the user.</param>
/// <param name="Icon">Contains the URL of an icon to display with the action.</param>
/// <param name="Navigate">Contains a URL to navigate to when the user activates this action. When set, the user agent navigates to this URL instead of firing the notificationclick event. See <see cref="INotification.Navigate"/> for more information.</param>
public readonly record struct NotificationAction(string Action, string Title, string? Icon = null, string? Navigate = null);
