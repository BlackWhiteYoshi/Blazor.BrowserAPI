using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BrowserAPI.Demo.Client;

public sealed partial class NotificationsAPI : ComponentBase, IAsyncDisposable {
    [Inject]
    public required INotificationsAPI PNotificationsAPI { private get; init; }

    [Inject]
    public required IServiceWorkerContainer ServiceWorkerContainer { private get; init; }

    private Task<IServiceWorkerRegistration>? _serviceWorkerRegistrationTask = null;
    private Task<IServiceWorkerRegistration> ServiceWorkerRegistrationTask => _serviceWorkerRegistrationTask ??= GetServiceWorkerRegistration();
    private async Task<IServiceWorkerRegistration> GetServiceWorkerRegistration() {
        await ServiceWorkerContainer.Register("service-worker.js");
        return await ServiceWorkerContainer.Ready; // waiting until service worker is in state "ready"
    }

    public async ValueTask DisposeAsync() {
        try {
            if (_serviceWorkerRegistrationTask is not null) {
                await using IServiceWorkerRegistration serviceWorkerRegistration = await _serviceWorkerRegistrationTask;
                await serviceWorkerRegistration.Unregister();
            }
        }
        catch (JSDisconnectedException) { }
    }


    private int? maxActions = null;
    private async Task GetMaxActions() => maxActions = await PNotificationsAPI.MaxActions;

    private string? permission = null;
    private async Task GetPermission() => permission = await PNotificationsAPI.Permission;
    private async Task RequestPermission() => permission = await PNotificationsAPI.RequestPermission();


    private string? notificationState = null;
    private async Task CreateNotification() {
        string permission = await PNotificationsAPI.Permission;
        if (permission != "granted") {
            notificationState = $"missing permission: '{permission}'";
            return;
        }

        await (await ServiceWorkerRegistrationTask).ShowNotification(
            title: "BlackWhiteYoshi",
            body: "Yoshi is green",
            actions: [
                new NotificationAction() { Action = "get", Title = "Get Yoshi", Navigate = "https://www.blackwhiteyoshi.com" },
                new NotificationAction() { Action = "dismiss", Title = "Don't Care" }
            ]
        );
        notificationState = "notification created";
    }

    private async Task CloseNotifications() {
        INotification[] notificationList = await (await ServiceWorkerRegistrationTask).GetNotifications();
        foreach (INotification notification in notificationList)
            await notification.Close();

        await notificationList.DisposeAsync();
        notificationState = null;
    }
}
