using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class NotificationsAPITest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    // NotificationsAPI

    [Test]
    public async Task Permission_Property() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_PERMISSION_PROPERTY);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsIn(["default", "denied"]);
    }

    [Test]
    public async Task Permission_Method() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_PERMISSION_METHOD);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsIn(["default", "denied"]);
    }

    [Test]
    public async Task MaxActions_Property() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_MAX_ACTIONS_PROPERTY);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("2");
    }

    [Test]
    public async Task MaxActions_Method() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_MAX_ACTIONS_METHOD);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("2");
    }


    [Test]
    public async Task RequestPermission() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_REQUEST_PERMISSION);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsIn(["default", "denied"]);
    }

    [Test]
    public async Task CreateNotification() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_CREATE_NOTIFICATION);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    // Notification

    [Test]
    public async Task Actions_Property() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_ACTIONS_PROPERTY);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("0");
    }

    [Test]
    public async Task Actions_Method() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_ACTIONS_METHOD);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("0");
    }

    [Test]
    public async Task Badge_Property() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_BADGE_PROPERTY);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.TEST_NOTIFICATION_BADGE);
    }

    [Test]
    public async Task Badge_Method() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_BADGE_METHOD);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.TEST_NOTIFICATION_BADGE);
    }

    [Test]
    public async Task Body_Property() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_BODY_PROPERTY);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.TEST_NOTIFICATION_BODY);
    }

    [Test]
    public async Task Body_Method() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_BODY_METHOD);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.TEST_NOTIFICATION_BODY);
    }

    [Test]
    public async Task Data_Property() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_DATA_PROPERTY);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.Test_Notification_Data.Count.ToString());
    }

    [Test]
    public async Task Data_Method() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_DATA_METHOD);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.Test_Notification_Data.Count.ToString());
    }

    [Test]
    public async Task Dir_Property() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_DIR_PROPERTY);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("auto");
    }

    [Test]
    public async Task Dir_Method() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_DIR_METHOD);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("auto");
    }

    [Test]
    public async Task Icon_Property() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_ICON_PROPERTY);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.TEST_NOTIFICATION_ICON);
    }

    [Test]
    public async Task Icon_Method() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_ICON_METHOD);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.TEST_NOTIFICATION_ICON);
    }

    [Test]
    public async Task Image_Property() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_IMAGE_PROPERTY);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.TEST_NOTIFICATION_IMAGE);
    }

    [Test]
    public async Task Image_Method() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_IMAGE_METHOD);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.TEST_NOTIFICATION_IMAGE);
    }

    [Test]
    public async Task Lang_Property() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_LANG_PROPERTY);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.TEST_NOTIFICATION_LANG);
    }

    [Test]
    public async Task Lang_Method() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_LANG_METHOD);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.TEST_NOTIFICATION_LANG);
    }

    [Test]
    public async Task Navigate_Property() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_NAVIGATE_PROPERTY);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsIn([NotificationsAPIGroup.TEST_NOTIFICATION_NAVIGATE, "null"]);
    }

    [Test]
    public async Task Navigate_Method() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_NAVIGATE_METHOD);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsIn([NotificationsAPIGroup.TEST_NOTIFICATION_NAVIGATE, "null"]);
    }

    [Test]
    public async Task Renotify_Property() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_RENOTIFY_PROPERTY);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task Renotify_Method() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_RENOTIFY_METHOD);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task RequireInteraction_Property() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_REQUIRE_INTERACTION_PROPERTY);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task RequireInteraction_Method() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_REQUIRE_INTERACTION_METHOD);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task Silent_Property() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_SILENT_PROPERTY);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task Silent_Method() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_SILENT_METHOD);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task Tag_Property() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_TAG_PROPERTY);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.TEST_NOTIFICATION_TAG);
    }

    [Test]
    public async Task Tag_Method() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_TAG_METHOD);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.TEST_NOTIFICATION_TAG);
    }

    [Test]
    public async Task Timestamp_Property() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_TIMESTAMP_PROPERTY);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.TEST_NOTIFICATION_TIMESTAMP.ToString());
    }

    [Test]
    public async Task Timestamp_Method() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_TIMESTAMP_METHOD);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.TEST_NOTIFICATION_TIMESTAMP.ToString());
    }

    [Test]
    public async Task Title_Property() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_TITLE_PROPERTY);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.TEST_NOTIFICATION_TITLE);
    }

    [Test]
    public async Task Title_Method() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_TITLE_METHOD);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.TEST_NOTIFICATION_TITLE);
    }

    [Test]
    public async Task Vibrate_Property() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_VIBRATE_PROPERTY);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.Test_Notification_Vibrate.Length.ToString());
    }

    [Test]
    public async Task Vibrate_Method() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_VIBRATE_METHOD);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.Test_Notification_Vibrate.Length.ToString());
    }


    [Test]
    public async Task Close() {
        await ExecuteTest(NotificationsAPIGroup.BUTTON_CLOSE);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.TEST_CLOSE);
    }


    // Events

    private const string MONKEY_PATCH_NOTIFICATION_CONSTRUCTOR = """
        const OriginalNotification = window.Notification;
        window.Notification = function (...args) {
            const instance = new OriginalNotification(...args);
            window.notification = instance;
            return instance;
        };
        """;

    [Test]
    public async Task RegisterOnClick() {
        await Page.EvaluateAsync(MONKEY_PATCH_NOTIFICATION_CONSTRUCTOR);

        await ExecuteTest(NotificationsAPIGroup.BUTTON_REGISTER_ON_CLICK);
        await Page.EvaluateAsync("window.notification.dispatchEvent(new Event('click'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.TEST_EVENT_CLICK);
    }

    [Test]
    public async Task RegisterOnClose() {
        await Page.EvaluateAsync(MONKEY_PATCH_NOTIFICATION_CONSTRUCTOR);

        await ExecuteTest(NotificationsAPIGroup.BUTTON_REGISTER_ON_CLOSE);
        await Page.EvaluateAsync("window.notification.dispatchEvent(new Event('close'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.TEST_EVENT_CLOSE);
    }

    [Test]
    public async Task RegisterOnError() {
        await Page.EvaluateAsync(MONKEY_PATCH_NOTIFICATION_CONSTRUCTOR);

        await ExecuteTest(NotificationsAPIGroup.BUTTON_REGISTER_ON_ERROR);
        await Page.EvaluateAsync("window.notification.dispatchEvent(new Event('error'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.TEST_EVENT_ERROR);
    }

    [Test]
    public async Task RegisterOnShow() {
        await Page.EvaluateAsync(MONKEY_PATCH_NOTIFICATION_CONSTRUCTOR);

        await ExecuteTest(NotificationsAPIGroup.BUTTON_REGISTER_ON_SHOW);
        await Page.EvaluateAsync("window.notification.dispatchEvent(new Event('show'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(NotificationsAPIGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIGroup.TEST_EVENT_SHOW);
    }
}
