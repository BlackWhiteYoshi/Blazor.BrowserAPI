using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class NotificationsAPIInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    // NotificationsAPI

    [Test]
    public async Task Permission() {
        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_PERMISSION);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsIn(["default", "denied"]);
    }

    [Test]
    public async Task MaxActions() {
        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_MAX_ACTIONS);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("2");
    }


    [Test]
    public async Task RequestPermission() {
        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_REQUEST_PERMISSION);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsIn(["default", "denied"]);
    }

    [Test]
    public async Task CreateNotification() {
        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_CREATE_NOTIFICATION);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    // Notification

    [Test]
    public async Task Actions() {
        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_ACTIONS);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("0");
    }

    [Test]
    public async Task Badge() {
        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_BADGE);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIInProcessGroup.TEST_NOTIFICATION_BADGE);
    }

    [Test]
    public async Task Body() {
        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_BODY);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIInProcessGroup.TEST_NOTIFICATION_BODY);
    }

    [Test]
    public async Task Data() {
        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_DATA);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIInProcessGroup.Test_Notification_Data.Count.ToString());
    }

    [Test]
    public async Task Dir() {
        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_DIR);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("auto");
    }

    [Test]
    public async Task Icon() {
        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_ICON);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIInProcessGroup.TEST_NOTIFICATION_ICON);
    }

    [Test]
    public async Task Image() {
        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_IMAGE);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIInProcessGroup.TEST_NOTIFICATION_IMAGE);
    }

    [Test]
    public async Task Lang() {
        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_LANG);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIInProcessGroup.TEST_NOTIFICATION_LANG);
    }

    [Test]
    public async Task Navigate() {
        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_NAVIGATE);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsIn([NotificationsAPIInProcessGroup.TEST_NOTIFICATION_NAVIGATE, "null"]);
    }

    [Test]
    public async Task Renotify() {
        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_RENOTIFY);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task RequireInteraction() {
        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_REQUIRE_INTERACTION);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task Silent() {
        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_SILENT);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task Tag() {
        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_TAG);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIInProcessGroup.TEST_NOTIFICATION_TAG);
    }

    [Test]
    public async Task Timestamp() {
        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_TIMESTAMP);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIInProcessGroup.TEST_NOTIFICATION_TIMESTAMP.ToString());
    }

    [Test]
    public async Task Title() {
        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_TITLE);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIInProcessGroup.TEST_NOTIFICATION_TITLE);
    }

    [Test]
    public async Task Vibrate() {
        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_VIBRATE);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIInProcessGroup.Test_Notification_Vibrate.Length.ToString());
    }


    [Test]
    public async Task Close() {
        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_CLOSE);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIInProcessGroup.TEST_CLOSE);
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

        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_REGISTER_ON_CLICK);
        await Page.EvaluateAsync("window.notification.dispatchEvent(new Event('click'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIInProcessGroup.TEST_EVENT_CLICK);
    }

    [Test]
    public async Task RegisterOnClose() {
        await Page.EvaluateAsync(MONKEY_PATCH_NOTIFICATION_CONSTRUCTOR);

        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_REGISTER_ON_CLOSE);
        await Page.EvaluateAsync("window.notification.dispatchEvent(new Event('close'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIInProcessGroup.TEST_EVENT_CLOSE);
    }

    [Test]
    public async Task RegisterOnError() {
        await Page.EvaluateAsync(MONKEY_PATCH_NOTIFICATION_CONSTRUCTOR);

        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_REGISTER_ON_ERROR);
        await Page.EvaluateAsync("window.notification.dispatchEvent(new Event('error'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIInProcessGroup.TEST_EVENT_ERROR);
    }

    [Test]
    public async Task RegisterOnShow() {
        await Page.EvaluateAsync(MONKEY_PATCH_NOTIFICATION_CONSTRUCTOR);

        await ExecuteTest(NotificationsAPIInProcessGroup.BUTTON_REGISTER_ON_SHOW);
        await Page.EvaluateAsync("window.notification.dispatchEvent(new Event('show'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(NotificationsAPIInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NotificationsAPIInProcessGroup.TEST_EVENT_SHOW);
    }
}
