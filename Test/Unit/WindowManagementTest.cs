using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class WindowManagementTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
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
    public async Task Screen_GetWidth_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_SCREEN_GET_WIDTH_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task Screen_GetWidth_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_SCREEN_GET_WIDTH_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task Screen_GetHeight_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_SCREEN_GET_HEIGHT_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task Screen_GetHeight_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_SCREEN_GET_HEIGHT_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task Screen_GetAvailWidth_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_SCREEN_GET_AVAIL_WIDTH_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task Screen_GetAvailWidth_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_SCREEN_GET_AVAIL_WIDTH_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task Screen_GetAvailHeight_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_SCREEN_GET_AVAIL_HEIGHT_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task Screen_GetAvailHeight_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_SCREEN_GET_AVAIL_HEIGHT_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task Screen_GetColorDepth_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_SCREEN_GET_COLOR_DEPTH_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task Screen_GetColorDepth_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_SCREEN_GET_COLOR_DEPTH_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task Screen_GetPixelDepth_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_SCREEN_GET_PIXEL_DEPTH_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task Screen_GetPixelDepth_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_SCREEN_GET_PIXEL_DEPTH_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task Screen_GetIsExtended_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_SCREEN_GET_IS_EXTENDED_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result is "True" or "False").IsTrue();
    }

    [Test]
    public async Task Screen_GetIsExtended_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_SCREEN_GET_IS_EXTENDED_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result is "True" or "False").IsTrue();
    }


    // orientation

    [Test]
    public async Task Screen_GetOrientationType_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_SCREEN_GET_ORIENTATION_TYPE_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }

    [Test]
    public async Task Screen_GetOrientationType_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_SCREEN_GET_ORIENTATION_TYPE_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }


    [Test]
    public async Task Screen_GetOrientationAngle_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_SCREEN_GET_ORIENTATION_ANGLE_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task Screen_GetOrientationAngle_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_SCREEN_GET_ORIENTATION_ANGLE_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task Screen_LockOrientation() {
        await ExecuteTest(WindowManagementGroup.BUTTON_SCREEN_LOCK_ORIENTATION);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result is WindowManagementGroup.TEST_SCREEN_LOCK_ORIENTATION_RESULT or WindowManagementGroup.TEST_SCREEN_LOCK_ORIENTATION_NOT_SUPPOERTED).IsTrue();
    }

    [Test]
    public async Task Screen_UnlockOrientation() {
        await ExecuteTest(WindowManagementGroup.BUTTON_SCREEN_UNLOCK_ORIENTATION);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowManagementGroup.TEST_SCREEN_UNLOCK_ORIENTATION_RESULT);
    }


    // events

    [Test]
    public async Task Screen_RegisterOnChange() {
        await ExecuteTest(WindowManagementGroup.BUTTON_SCREEN_REGISTER_ON_CHANGE);
        await Page.EvaluateAsync("window.screen.dispatchEvent(new Event('change'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowManagementGroup.TEST_SCREEN_CHANGE_EVENT);
    }

    [Test]
    public async Task Screen_RegisterOnOrientationChange() {
        await ExecuteTest(WindowManagementGroup.BUTTON_SCREEN_REGISTER_ON_ORIENTATION_CHANGE);
        await Page.EvaluateAsync("window.screen.orientation.dispatchEvent(new Event('change'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowManagementGroup.TEST_SCREEN_ORIENTATION_CHANGE_EVENT);
    }

    #endregion


    /* PlayWright does not support permission "window-management"

    #region Window Management

    [Test]
    public async Task GetScreenDetails() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_SCREEN_DETAILS);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetCurrentScreen_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_CURRENT_SCREEN_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetCurrentScreen_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_CURRENT_SCREEN_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetScreens_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_SCREENS_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetScreens_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_SCREENS_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task RegisterOnCurrentScreenChange() {
        await Page.EvaluateAsync(JS_FAKE_EVENT_TRIGGER);
        await Task.Delay(STANDARD_WAIT_TIME);
        await ExecuteTest(WindowManagementGroup.BUTTON_REGISTER_ON_CURRENT_SCREEN_CHANGE);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowManagementGroup.TEST_EVENT_ON_CURRENT_SCREEN_CHANGE);
    }

    [Test]
    public async Task RegisterOnScreensChange() {
        await Page.EvaluateAsync(JS_FAKE_EVENT_TRIGGER);
        await Task.Delay(STANDARD_WAIT_TIME);
        await ExecuteTest(WindowManagementGroup.BUTTON_REGISTER_ON_SCREENS_CHANGE);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowManagementGroup.TEST_EVENT_ON_SCREENS_CHANGE);
    }


    // ScreenDetailed

    [Test]
    public async Task GetLeft_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_REGISTER_GET_LEFT_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetLeft_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_REGISTER_GET_LEFT_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetTop_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_REGISTER_GET_TOP_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetTop_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_REGISTER_GET_TOP_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetAvailLeft_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_REGISTER_GET_AVAIL_LEFT_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetAvailLeft_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_REGISTER_GET_AVAIL_LEFT_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetAvailTop_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_REGISTER_GET_AVAIL_TOP_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetAvailTop_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_REGISTER_GET_AVAIL_TOP_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetLabel_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_REGISTER_GET_LABEL_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }

    [Test]
    public async Task GetLabel_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_REGISTER_GET_LABEL_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }


    [Test]
    public async Task GetDevicePixelRatio_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_REGISTER_GET_DEVICE_PIXEL_RATIO_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetDevicePixelRatio_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_REGISTER_GET_DEVICE_PIXEL_RATIO_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetIsPrimary_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_REGISTER_GET_IS_PRIMARY_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result is "True" or "False").IsTrue();
    }

    [Test]
    public async Task GetIsPrimary_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_REGISTER_GET_IS_PRIMARY_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result is "True" or "False").IsTrue();
    }


    [Test]
    public async Task GetIsInternal_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_REGISTER_GET_IS_INTERNAL_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result is "True" or "False").IsTrue();
    }

    [Test]
    public async Task GetIsInternal_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_REGISTER_GET_IS_INTERNAL_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result is "True" or "False").IsTrue();
    }



    [Test]
    public async Task GetWidth_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_WIDTH_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetWidth_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_WIDTH_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetHeight_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_HEIGHT_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetHeight_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_HEIGHT_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetAvailWidth_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_AVAIL_WIDTH_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetAvailWidth_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_AVAIL_WIDTH_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetAvailHeight_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_AVAIL_HEIGHT_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetAvailHeight_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_AVAIL_HEIGHT_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetColorDepth_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_COLOR_DEPTH_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetColorDepth_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_COLOR_DEPTH_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetPixelDepth_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_PIXEL_DEPTH_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetPixelDepth_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_PIXEL_DEPTH_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetIsExtended_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_IS_EXTENDED_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result is "True" or "False").IsTrue();
    }

    [Test]
    public async Task GetIsExtended_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_IS_EXTENDED_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result is "True" or "False").IsTrue();
    }



    [Test]
    public async Task GetOrientationType_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_ORIENTATION_TYPE_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }

    [Test]
    public async Task GetOrientationType_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_ORIENTATION_TYPE_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }


    [Test]
    public async Task GetOrientationAngle_Property() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_ORIENTATION_ANGLE_PROPERTY);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetOrientationAngle_Method() {
        await ExecuteTest(WindowManagementGroup.BUTTON_GET_ORIENTATION_ANGLE_METHOD);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task LockOrientation() {
        await ExecuteTest(WindowManagementGroup.BUTTON_LOCK_ORIENTATION);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result is WindowManagementGroup.TEST_LOCK_ORIENTATION_RESULT or WindowManagementGroup.TEST_LOCK_ORIENTATION_NOT_SUPPOERTED).IsTrue();
    }

    [Test]
    public async Task UnlockOrientation() {
        await ExecuteTest(WindowManagementGroup.BUTTON_UNLOCK_ORIENTATION);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowManagementGroup.TEST_UNLOCK_ORIENTATION_RESULT);
    }



    [Test]
    public async Task RegisterOnChange() {
        await Page.EvaluateAsync(JS_FAKE_EVENT_TRIGGER);
        await Task.Delay(STANDARD_WAIT_TIME);
        await ExecuteTest(WindowManagementGroup.BUTTON_REGISTER_ON_CHANGE);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowManagementGroup.TEST_CHANGE_EVENT);
    }

    [Test]
    public async Task RegisterOnOrientationChange() {
        await Page.EvaluateAsync(JS_FAKE_EVENT_TRIGGER);
        await Task.Delay(STANDARD_WAIT_TIME);
        await ExecuteTest(WindowManagementGroup.BUTTON_REGISTER_ON_ORIENTATION_CHANGE);

        string? result = await Page.GetByTestId(WindowManagementGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowManagementGroup.TEST_ORIENTATION_CHANGE_EVENT);
    }

    #endregion

    */
}
