using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class WindowManagementInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    //private const string JS_FAKE_EVENT_TRIGGER = """
    //    window.getScreenDetails = () => Promise.resolve({
    //        currentScreen: {
    //            orientation: {
    //                addEventListener: (type, listener) => window.setTimeout(listener, 100),
    //                removeEventListener: (type, listener) => { }
    //            },
    //            addEventListener: (type, listener) => window.setTimeout(listener, 100),
    //            removeEventListener: (type, listener) => { }
    //        },
    //        addEventListener: (type, listener) => window.setTimeout(listener, 100),
    //        removeEventListener: (type, listener) => { }
    //    });
    //    """;

    //public override async Task SetUp() {
    //    await base.SetUp();
    //    await BrowserContext.GrantPermissionsAsync(["window-management"]);
    //}


    #region Screen

    [Test]
    public async Task Screen_GetWidth() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_SCREEN_GET_WIDTH);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task Screen_GetHeight() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_SCREEN_GET_HEIGHT);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task Screen_GetAvailWidth() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_SCREEN_GET_AVAIL_WIDTH);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task Screen_GetAvailHeight() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_SCREEN_GET_AVAIL_HEIGHT);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task Screen_GetColorDepth() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_SCREEN_GET_COLOR_DEPTH);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task Screen_GetPixelDepth() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_SCREEN_GET_PIXEL_DEPTH);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task Screen_GetIsExtended() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_SCREEN_GET_IS_EXTENDED);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result is "True" or "False").IsTrue();
    }


    // orientation

    [Test]
    public async Task Screen_GetOrientationType() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_SCREEN_GET_ORIENTATION_TYPE);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }

    [Test]
    public async Task Screen_GetOrientationAngle() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_SCREEN_GET_ORIENTATION_ANGLE);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task Screen_LockOrientation() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_SCREEN_LOCK_ORIENTATION);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result is WindowManagementInProcessGroup.TEST_SCREEN_LOCK_ORIENTATION_RESULT or WindowManagementInProcessGroup.TEST_SCREEN_LOCK_ORIENTATION_NOT_SUPPOERTED).IsTrue();
    }

    [Test]
    public async Task Screen_UnlockOrientation() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_SCREEN_UNLOCK_ORIENTATION);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowManagementInProcessGroup.TEST_SCREEN_UNLOCK_ORIENTATION_RESULT);
    }


    // events

    [Test]
    public async Task Screen_RegisterOnChange() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_SCREEN_REGISTER_ON_CHANGE);
        await Page.EvaluateAsync("window.screen.dispatchEvent(new Event('change'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowManagementInProcessGroup.TEST_SCREEN_CHANGE_EVENT);
    }

    [Test]
    public async Task Screen_RegisterOnOrientationChange() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_SCREEN_REGISTER_ON_ORIENTATION_CHANGE);
        await Page.EvaluateAsync("window.screen.orientation.dispatchEvent(new Event('change'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowManagementInProcessGroup.TEST_SCREEN_ORIENTATION_CHANGE_EVENT);
    }

    #endregion


    /* PlayWright does not support permission "window-management"

    #region Window Management

    [Test]
    public async Task GetScreenDetails() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_GET_SCREEN_DETAILS);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task Open() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_OPEN);

        IPage page = BrowserContext.Pages.First((IPage page) => page.Url.EndsWith("/null"));
        await Assert.That(page).IsNotNull();
        await page.CloseAsync();
    }


    [Test]
    public async Task GetCurrentScreen() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_GET_CURRENT_SCREEN);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetScreens() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_GET_SCREENS);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task RegisterOnCurrentScreenChange() {
        await Page.EvaluateAsync(JS_FAKE_EVENT_TRIGGER);
        await Task.Delay(STANDARD_WAIT_TIME);
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_REGISTER_ON_CURRENT_SCREEN_CHANGE);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowManagementInProcessGroup.TEST_EVENT_ON_CURRENT_SCREEN_CHANGE);
    }

    [Test]
    public async Task RegisterOnScreensChange() {
        await Page.EvaluateAsync(JS_FAKE_EVENT_TRIGGER);
        await Task.Delay(STANDARD_WAIT_TIME);
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_REGISTER_ON_SCREENS_CHANGE);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowManagementInProcessGroup.TEST_EVENT_ON_SCREENS_CHANGE);
    }


    // ScreenDetailed

    [Test]
    public async Task GetLeft() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_REGISTER_GET_LEFT);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetTop() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_REGISTER_GET_TOP);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetAvailLeft() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_REGISTER_GET_AVAIL_LEFT);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetAvailTop() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_REGISTER_GET_AVAIL_TOP);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetLabel() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_REGISTER_GET_LABEL);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }

    [Test]
    public async Task GetDevicePixelRatio() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_REGISTER_GET_DEVICE_PIXEL_RATIO);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetIsPrimary() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_REGISTER_GET_IS_PRIMARY);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result is "True" or "False").IsTrue();
    }

    [Test]
    public async Task GetIsInternal() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_REGISTER_GET_IS_INTERNAL);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result is "True" or "False").IsTrue();
    }


    [Test]
    public async Task GetWidth() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_GET_WIDTH);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetHeight() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_GET_HEIGHT);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetAvailWidth() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_GET_AVAIL_WIDTH);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetAvailHeight() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_GET_AVAIL_HEIGHT);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetColorDepth() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_GET_COLOR_DEPTH);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetPixelDepth() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_GET_PIXEL_DEPTH);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetIsExtended() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_GET_IS_EXTENDED);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result is "True" or "False").IsTrue();
    }


    [Test]
    public async Task GetOrientationType() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_GET_ORIENTATION_TYPE);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }

    [Test]
    public async Task GetOrientationAngle() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_GET_ORIENTATION_ANGLE);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task LockOrientation() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_LOCK_ORIENTATION);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result is WindowManagementInProcessGroup.TEST_LOCK_ORIENTATION_RESULT or WindowManagementInProcessGroup.TEST_LOCK_ORIENTATION_NOT_SUPPOERTED).IsTrue();
    }

    [Test]
    public async Task UnlockOrientation() {
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_UNLOCK_ORIENTATION);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowManagementInProcessGroup.TEST_UNLOCK_ORIENTATION_RESULT);
    }


    [Test]
    public async Task RegisterOnChange() {
        await Page.EvaluateAsync(JS_FAKE_EVENT_TRIGGER);
        await Task.Delay(STANDARD_WAIT_TIME);
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_REGISTER_ON_CHANGE);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowManagementInProcessGroup.TEST_CHANGE_EVENT);
    }

    [Test]
    public async Task RegisterOnOrientationChange() {
        await Page.EvaluateAsync(JS_FAKE_EVENT_TRIGGER);
        await Task.Delay(STANDARD_WAIT_TIME);
        await ExecuteTest(WindowManagementInProcessGroup.BUTTON_REGISTER_ON_ORIENTATION_CHANGE);

        string? result = await Page.GetByTestId(WindowManagementInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowManagementInProcessGroup.TEST_ORIENTATION_CHANGE_EVENT);
    }

    #endregion

    */
}
