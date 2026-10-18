using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class NotificationsAPIGroup : ComponentBase {
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
    public required INotificationsAPI NotificationsAPI { private get; init; }


    public const string OUTPUT = "notificationsapi-output";
    private string output = string.Empty;


    // NotificationsAPI

    public const string BUTTON_PERMISSION_PROPERTY = "notificationsapi-permission-property";
    private async Task Permission_Property() {
        output = await NotificationsAPI.Permission;
    }

    public const string BUTTON_PERMISSION_METHOD = "notificationsapi-permission-method";
    private async Task Permission_Method() {
        output = await NotificationsAPI.GetPermission(CancellationToken.None);
    }

    public const string BUTTON_MAX_ACTIONS_PROPERTY = "notificationsapi-max-actions-property";
    private async Task MaxActions_Property() {
        int maxActions = await NotificationsAPI.MaxActions;
        output = maxActions.ToString();
    }

    public const string BUTTON_MAX_ACTIONS_METHOD = "notificationsapi-max-actions-method";
    private async Task MaxActions_Method() {
        int maxActions = await NotificationsAPI.GetMaxActions(CancellationToken.None);
        output = maxActions.ToString();
    }


    public const string BUTTON_REQUEST_PERMISSION = "notificationsapi-request-permission";
    private async Task RequestPermission() {
        output = await NotificationsAPI.RequestPermission();
    }

    public const string BUTTON_CREATE_NOTIFICATION = "notificationsapi-create-notification";
    private async Task CreateNotification() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);
        output = (notification is not null).ToString();
    }


    // Notification

    public const string BUTTON_ACTIONS_PROPERTY = "notificationsapi-actions-property";
    private async Task Actions_Property() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);
        NotificationAction[] actions = await notification.Actions;
        output = actions.Length.ToString();
    }

    public const string BUTTON_ACTIONS_METHOD = "notificationsapi-actions-method";
    private async Task Actions_Method() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);
        NotificationAction[] actions = await notification.GetActions(CancellationToken.None);
        output = actions.Length.ToString();
    }

    public const string BUTTON_BADGE_PROPERTY = "notificationsapi-badge-property";
    private async Task Badge_Property() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, badge: TEST_NOTIFICATION_BADGE);
        output = await notification.Badge;
    }

    public const string BUTTON_BADGE_METHOD = "notificationsapi-badge-method";
    private async Task Badge_Method() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, badge: TEST_NOTIFICATION_BADGE);
        output = await notification.GetBadge(CancellationToken.None);
    }

    public const string BUTTON_BODY_PROPERTY = "notificationsapi-body-property";
    private async Task Body_Property() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, body: TEST_NOTIFICATION_BODY);
        output = await notification.Body;
    }

    public const string BUTTON_BODY_METHOD = "notificationsapi-body-method";
    private async Task Body_Method() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, body: TEST_NOTIFICATION_BODY);
        output = await notification.GetBody(CancellationToken.None);
    }

    public const string BUTTON_DATA_PROPERTY = "notificationsapi-data-property";
    private async Task Data_Property() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, data: Test_Notification_Data);
        Dictionary<string, object?>? data = await notification.Data;
        output = data?.Count.ToString() ?? "null";
    }

    public const string BUTTON_DATA_METHOD = "notificationsapi-data-method";
    private async Task Data_Method() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, data: Test_Notification_Data);
        Dictionary<string, object?>? data = await notification.GetData(CancellationToken.None);
        output = data?.Count.ToString() ?? "null";
    }

    public const string BUTTON_DIR_PROPERTY = "notificationsapi-dir-property";
    private async Task Dir_Property() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);
        output = await notification.Dir;
    }

    public const string BUTTON_DIR_METHOD = "notificationsapi-dir-method";
    private async Task Dir_Method() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);
        output = await notification.GetDir(CancellationToken.None);
    }

    public const string BUTTON_ICON_PROPERTY = "notificationsapi-icon-property";
    private async Task Icon_Property() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, icon: TEST_NOTIFICATION_ICON);
        output = await notification.Icon;
    }

    public const string BUTTON_ICON_METHOD = "notificationsapi-icon-method";
    private async Task Icon_Method() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, icon: TEST_NOTIFICATION_ICON);
        output = await notification.GetIcon(CancellationToken.None);
    }

    public const string BUTTON_IMAGE_PROPERTY = "notificationsapi-image-property";
    private async Task Image_Property() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, image: TEST_NOTIFICATION_IMAGE);
        output = await notification.Image;
    }

    public const string BUTTON_IMAGE_METHOD = "notificationsapi-image-method";
    private async Task Image_Method() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, image: TEST_NOTIFICATION_IMAGE);
        output = await notification.GetImage(CancellationToken.None);
    }

    public const string BUTTON_LANG_PROPERTY = "notificationsapi-lang-property";
    private async Task Lang_Property() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, lang: TEST_NOTIFICATION_LANG);
        output = await notification.Lang;
    }

    public const string BUTTON_LANG_METHOD = "notificationsapi-lang-method";
    private async Task Lang_Method() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, lang: TEST_NOTIFICATION_LANG);
        output = await notification.GetLang(CancellationToken.None);
    }

    public const string BUTTON_NAVIGATE_PROPERTY = "notificationsapi-navigate-property";
    private async Task Navigate_Property() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, navigate: TEST_NOTIFICATION_NAVIGATE);
        output = await notification.Navigate ?? "null";
    }

    public const string BUTTON_NAVIGATE_METHOD = "notificationsapi-navigate-method";
    private async Task Navigate_Method() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, navigate: TEST_NOTIFICATION_NAVIGATE);
        output = await notification.GetNavigate(CancellationToken.None) ?? "null";
    }

    public const string BUTTON_RENOTIFY_PROPERTY = "notificationsapi-renotify-property";
    private async Task Renotify_Property() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);
        bool renotify = await notification.Renotify;
        output = renotify.ToString();
    }

    public const string BUTTON_RENOTIFY_METHOD = "notificationsapi-renotify-method";
    private async Task Renotify_Method() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);
        bool renotify = await notification.GetRenotify(CancellationToken.None);
        output = renotify.ToString();
    }

    public const string BUTTON_REQUIRE_INTERACTION_PROPERTY = "notificationsapi-require-interaction-property";
    private async Task RequireInteraction_Property() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);
        bool requireInteraction = await notification.RequireInteraction;
        output = requireInteraction.ToString();
    }

    public const string BUTTON_REQUIRE_INTERACTION_METHOD = "notificationsapi-require-interaction-method";
    private async Task RequireInteraction_Method() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);
        bool requireInteraction = await notification.GetRequireInteraction(CancellationToken.None);
        output = requireInteraction.ToString();
    }

    public const string BUTTON_SILENT_PROPERTY = "notificationsapi-silent-property";
    private async Task Silent_Property() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);
        bool? silent = await notification.Silent;
        output = silent?.ToString() ?? "null";
    }

    public const string BUTTON_SILENT_METHOD = "notificationsapi-silent-method";
    private async Task Silent_Method() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);
        bool? silent = await notification.GetSilent(CancellationToken.None);
        output = silent?.ToString() ?? "null";
    }

    public const string BUTTON_TAG_PROPERTY = "notificationsapi-tag-property";
    private async Task Tag_Property() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, tag: TEST_NOTIFICATION_TAG);
        output = await notification.Tag;
    }

    public const string BUTTON_TAG_METHOD = "notificationsapi-tag-method";
    private async Task Tag_Method() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, tag: TEST_NOTIFICATION_TAG);
        output = await notification.GetTag(CancellationToken.None);
    }

    public const string BUTTON_TIMESTAMP_PROPERTY = "notificationsapi-timestamp-property";
    private async Task Timestamp_Property() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, timestamp: TEST_NOTIFICATION_TIMESTAMP);
        long timestamp = await notification.Timestamp;
        output = timestamp.ToString();
    }

    public const string BUTTON_TIMESTAMP_METHOD = "notificationsapi-timestamp-method";
    private async Task Timestamp_Method() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, timestamp: TEST_NOTIFICATION_TIMESTAMP);
        long timestamp = await notification.GetTimestamp(CancellationToken.None);
        output = timestamp.ToString();
    }

    public const string BUTTON_TITLE_PROPERTY = "notificationsapi-title-property";
    private async Task Title_Property() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);
        output = await notification.Title;
    }

    public const string BUTTON_TITLE_METHOD = "notificationsapi-title-method";
    private async Task Title_Method() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);
        output = await notification.GetTitle(CancellationToken.None);
    }

    public const string BUTTON_VIBRATE_PROPERTY = "notificationsapi-vibrate-property";
    private async Task Vibrate_Property() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, vibrate: Test_Notification_Vibrate);
        int[] vibrate = await notification.Vibrate;
        output = vibrate.Length.ToString();
    }

    public const string BUTTON_VIBRATE_METHOD = "notificationsapi-vibrate-method";
    private async Task Vibrate_Method() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE, vibrate: Test_Notification_Vibrate);
        int[] vibrate = await notification.GetVibrate(CancellationToken.None);
        output = vibrate.Length.ToString();
    }


    public const string BUTTON_CLOSE = "notificationsapi-close";
    private async Task Close() {
        await using INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);
        await notification.Close();
        output = TEST_CLOSE;
    }


    // Events

    public const string BUTTON_REGISTER_ON_CLICK = "notificationsapi-click-event";
    private async Task RegisterOnClick() {
        INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);

        notification.OnClick += OnClick;
        void OnClick() {
            output = TEST_EVENT_CLICK;
            StateHasChanged();
            notification.OnClick -= OnClick;
            _ = notification.DisposeAsync().Preserve();
        }
    }

    public const string BUTTON_REGISTER_ON_CLOSE = "notificationsapi-close-event";
    private async Task RegisterOnClose() {
        INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);

        notification.OnClose += OnClose;
        void OnClose() {
            output = TEST_EVENT_CLOSE;
            StateHasChanged();
            notification.OnClose -= OnClose;
            _ = notification.DisposeAsync().Preserve();
        }
    }

    public const string BUTTON_REGISTER_ON_ERROR = "notificationsapi-error-event";
    private async Task RegisterOnError() {
        INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);

        notification.OnError += OnError;
        void OnError() {
            output = TEST_EVENT_ERROR;
            StateHasChanged();
            notification.OnError -= OnError;
            _ = notification.DisposeAsync().Preserve();
        }
    }

    public const string BUTTON_REGISTER_ON_SHOW = "notificationsapi-show-event";
    private async Task RegisterOnShow() {
        INotification notification = await NotificationsAPI.CreateNotification(TEST_NOTIFICATION_TITLE);

        notification.OnShow += OnShow;
        void OnShow() {
            output = TEST_EVENT_SHOW;
            StateHasChanged();
            notification.OnShow -= OnShow;
            _ = notification.DisposeAsync().Preserve();
        }
    }
}
