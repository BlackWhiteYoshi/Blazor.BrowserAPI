using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class NotificationsAPIInProcessGroup : ComponentBase {
    public const string TEST_NOTIFICATION_TITLE = "test Notification";
    public const string TEST_NOTIFICATION_BADGE = "https://localhost/test-badge";
    public const string TEST_NOTIFICATION_BODY = "test body";
    public static readonly Dictionary<string, object?> Test_Notification_Data = new(3) { ["string-test"] = "test", ["null-test"] = null, ["number-test"] = 5 };
    public const string TEST_NOTIFICATION_ICON = "https://localhost/test-icon";
    public const string TEST_NOTIFICATION_IMAGE = "https://localhost/test-image";
    public const string TEST_NOTIFICATION_LANG = "en-US";
    public const string TEST_NOTIFICATION_NAVIGATE = "https://localhost/test-navigate";
    public const string TEST_NOTIFICATION_TAG = "test tag";
    public const long TEST_NOTIFICATION_TIMESTAMP = 5L;
    public static readonly int[] Test_Notification_Vibrate = [200, 100, 200];
    public const string TEST_CLOSE = "notification closed";
    public const string TEST_EVENT_CLICK = "click-event-test";
    public const string TEST_EVENT_CLOSE = "close-event-test";
    public const string TEST_EVENT_ERROR = "error-event-test";
    public const string TEST_EVENT_SHOW = "show-event-test";


    [Inject]
    public required INotificationsAPIInProcess NotificationsAPI { private get; init; }


    public const string OUTPUT = "notificationsapi-inprocess-output";
    private string output = string.Empty;


    // NotificationsAPI

    public const string BUTTON_PERMISSION = "notificationsapi-inprocess-permission";
    private void Permission() {
        output = NotificationsAPI.Permission;
    }

    public const string BUTTON_MAX_ACTIONS = "notificationsapi-inprocess-max-actions";
    private void MaxActions() {
        int maxActions = NotificationsAPI.MaxActions;
        output = maxActions.ToString();
    }


    public const string BUTTON_REQUEST_PERMISSION = "notificationsapi-inprocess-request-permission";
    private async Task RequestPermission() {
        output = await NotificationsAPI.RequestPermission();
    }

    public const string BUTTON_CREATE_NOTIFICATION = "notificationsapi-inprocess-create-notification";
    private void CreateNotification() {
        using INotificationInProcess notification = NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);
        output = (notification is not null).ToString();
    }


    // Notification

    public const string BUTTON_ACTIONS = "notificationsapi-inprocess-actions";
    private void Actions() {
        using INotificationInProcess notification = NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);
        NotificationAction[] actions = notification.Actions;
        output = actions.Length.ToString();
    }

    public const string BUTTON_BADGE = "notificationsapi-inprocess-badge";
    private void Badge() {
        using INotificationInProcess notification = NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, badge: TEST_NOTIFICATION_BADGE);
        output = notification.Badge;
    }

    public const string BUTTON_BODY = "notificationsapi-inprocess-body";
    private void Body() {
        using INotificationInProcess notification = NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, body: TEST_NOTIFICATION_BODY);
        output = notification.Body;
    }

    public const string BUTTON_DATA = "notificationsapi-inprocess-data";
    private void Data() {
        using INotificationInProcess notification = NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, data: Test_Notification_Data);
        Dictionary<string, object?>? data = notification.Data;
        output = data?.Count.ToString() ?? "null";
    }

    public const string BUTTON_DIR = "notificationsapi-inprocess-dir";
    private void Dir() {
        using INotificationInProcess notification = NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);
        output = notification.Dir;
    }

    public const string BUTTON_ICON = "notificationsapi-inprocess-icon";
    private void Icon() {
        using INotificationInProcess notification = NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, icon: TEST_NOTIFICATION_ICON);
        output = notification.Icon;
    }

    public const string BUTTON_IMAGE = "notificationsapi-inprocess-image";
    private void Image() {
        using INotificationInProcess notification = NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, image: TEST_NOTIFICATION_IMAGE);
        output = notification.Image;
    }

    public const string BUTTON_LANG = "notificationsapi-inprocess-lang";
    private void Lang() {
        using INotificationInProcess notification = NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, lang: TEST_NOTIFICATION_LANG);
        output = notification.Lang;
    }

    public const string BUTTON_NAVIGATE = "notificationsapi-inprocess-navigate";
    private void Navigate() {
        using INotificationInProcess notification = NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, navigate: TEST_NOTIFICATION_NAVIGATE);
        output = notification.Navigate ?? "null";
    }

    public const string BUTTON_RENOTIFY = "notificationsapi-inprocess-renotify";
    private void Renotify() {
        using INotificationInProcess notification = NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);
        bool renotify = notification.Renotify;
        output = renotify.ToString();
    }

    public const string BUTTON_REQUIRE_INTERACTION = "notificationsapi-inprocess-require-interaction";
    private void RequireInteraction() {
        using INotificationInProcess notification = NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);
        bool requireInteraction = notification.RequireInteraction;
        output = requireInteraction.ToString();
    }

    public const string BUTTON_SILENT = "notificationsapi-inprocess-silent";
    private void Silent() {
        using INotificationInProcess notification = NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);
        bool? silent = notification.Silent;
        output = silent?.ToString() ?? "null";
    }

    public const string BUTTON_TAG = "notificationsapi-inprocess-tag";
    private void Tag() {
        using INotificationInProcess notification = NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, tag: TEST_NOTIFICATION_TAG);
        output = notification.Tag;
    }

    public const string BUTTON_TIMESTAMP = "notificationsapi-inprocess-timestamp";
    private void Timestamp() {
        using INotificationInProcess notification = NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, timestamp: TEST_NOTIFICATION_TIMESTAMP);
        long timestamp = notification.Timestamp;
        output = timestamp.ToString();
    }

    public const string BUTTON_TITLE = "notificationsapi-inprocess-title";
    private void Title() {
        using INotificationInProcess notification = NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);
        output = notification.Title;
    }

    public const string BUTTON_VIBRATE = "notificationsapi-inprocess-vibrate";
    private void Vibrate() {
        using INotificationInProcess notification = NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, vibrate: Test_Notification_Vibrate);
        int[] vibrate = notification.Vibrate;
        output = vibrate.Length.ToString();
    }


    public const string BUTTON_CLOSE = "notificationsapi-inprocess-close";
    private void Close() {
        using INotificationInProcess notification = NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);
        notification.Close();
        output = TEST_CLOSE;
    }


    // Events

    public const string BUTTON_REGISTER_ON_CLICK = "notificationsapi-inprocess-click-event";
    private void RegisterOnClick() {
        INotificationInProcess notification = NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);

        notification.OnClick += OnClick;
        void OnClick() {
            output = TEST_EVENT_CLICK;
            StateHasChanged();
            notification.OnClick -= OnClick;
            notification.Dispose();
        }
    }

    public const string BUTTON_REGISTER_ON_CLOSE = "notificationsapi-inprocess-close-event";
    private void RegisterOnClose() {
        INotificationInProcess notification = NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);

        notification.OnClose += OnClose;
        void OnClose() {
            output = TEST_EVENT_CLOSE;
            StateHasChanged();
            notification.OnClose -= OnClose;
            notification.Dispose();
        }
    }

    public const string BUTTON_REGISTER_ON_ERROR = "notificationsapi-inprocess-error-event";
    private void RegisterOnError() {
        INotificationInProcess notification = NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);

        notification.OnError += OnError;
        void OnError() {
            output = TEST_EVENT_ERROR;
            StateHasChanged();
            notification.OnError -= OnError;
            notification.Dispose();
        }
    }

    public const string BUTTON_REGISTER_ON_SHOW = "notificationsapi-inprocess-show-event";
    private void RegisterOnShow() {
        INotificationInProcess notification = NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);

        notification.OnShow += OnShow;
        void OnShow() {
            output = TEST_EVENT_SHOW;
            StateHasChanged();
            notification.OnShow -= OnShow;
            notification.Dispose();
        }
    }
}
