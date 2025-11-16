using BrowserAPI.Test.Client;
using TUnit.Core.Interfaces;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class NavigatorTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    public override Task InitializeAsync()
        => (TestContext.Current as ITestMetadata)?.DisplayName switch {
            nameof(GetAutoplayPolicy_String)
            or nameof(GetAutoplayPolicy_Element) => NewPage(BrowserId.Firefox),
            _ => NewPage(BrowserId.Chromium)
        };


    // Properties

    [Test]
    public async Task GetLanguage_Property() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_LANGUAGE_PROPERTY);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }

    [Test]
    public async Task GetLanguage_Method() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_LANGUAGE_METHOD);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }

    [Test]
    public async Task GetLanguages_Property() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_LANGUAGES_PROPERTY);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }

    [Test]
    public async Task GetLanguages_Method() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_LANGUAGES_METHOD);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }


    [Test]
    public async Task GetUserAgent_Property() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_USER_AGENT_PROPERTY);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }

    [Test]
    public async Task GetUserAgent_Method() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_USER_AGENT_METHOD);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }

    [Test]
    public async Task GetWebdriver_Property() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_WEBDRIVER_PROPERTY);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetWebdriver_Method() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_WEBDRIVER_METHOD);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetUserActivationIsActive_Property() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_USER_ACTIVATION_IS_ACTIVE_PROPERTY);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetUserActivationIsActive_Method() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_USER_ACTIVATION_IS_ACTIVE_METHOD);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetUserActivationHasBeenActive_Property() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_USER_ACTIVATION_HAS_BEEN_ACTIVE_PROPERTY);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetUserActivationHasBeenActive_Method() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_USER_ACTIVATION_HAS_BEEN_ACTIVE_METHOD);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetCookieEnabled_Property() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_COOKIE_ENABLED_PROPERTY);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        bool resultIsBool = bool.TryParse(result, out _);
        await Assert.That(resultIsBool).IsTrue();
    }

    [Test]
    public async Task GetCookieEnabled_Method() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_COOKIE_ENABLED_METHOD);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        bool resultIsBool = bool.TryParse(result, out _);
        await Assert.That(resultIsBool).IsTrue();
    }

    [Test]
    public async Task GetPdfViewerEnabled_Property() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_PDF_VIEWER_ENABLED_PROPERTY);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        bool resultIsBool = bool.TryParse(result, out _);
        await Assert.That(resultIsBool).IsTrue();
    }

    [Test]
    public async Task GetPdfViewerEnabled_Method() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_PDF_VIEWER_ENABLED_METHOD);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        bool resultIsBool = bool.TryParse(result, out _);
        await Assert.That(resultIsBool).IsTrue();
    }


    [Test]
    public async Task GetMaxTouchPoints_Property() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_MAX_TOUCH_POINTS_PROPERTY);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        bool resultIsNumber = int.TryParse(result, out _);
        await Assert.That(resultIsNumber).IsTrue();
    }

    [Test]
    public async Task GetMaxTouchPoints_Method() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_MAX_TOUCH_POINTS_METHOD);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        bool resultIsNumber = int.TryParse(result, out _);
        await Assert.That(resultIsNumber).IsTrue();
    }

    [Test]
    public async Task GetHardwareConcurrency_Property() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_HARDWARE_CONCURRENCY_PROPERTY);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        bool resultIsNumber = int.TryParse(result, out _);
        await Assert.That(resultIsNumber).IsTrue();
    }

    [Test]
    public async Task GetHardwareConcurrency_Method() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_HARDWARE_CONCURRENCY_METHOD);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        bool resultIsNumber = int.TryParse(result, out _);
        await Assert.That(resultIsNumber).IsTrue();
    }

    [Test]
    public async Task GetDeviceMemory_Property() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_DEVICE_MEMORY_PROPERTY);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        bool resultIsNumber = double.TryParse(result, out _);
        await Assert.That(resultIsNumber).IsTrue();
    }

    [Test]
    public async Task GetDeviceMemory_Method() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_DEVICE_MEMORY_METHOD);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        bool resultIsNumber = double.TryParse(result, out _);
        await Assert.That(resultIsNumber).IsTrue();
    }



    /* Does not work in headless mode

    [Test]
    public async Task CanShare() {
        await ExecuteTest(NavigatorGroup.BUTTON_CAN_SHARE);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task Share() {
        await ExecuteTest(NavigatorGroup.BUTTON_SHARE);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NavigatorGroup.TEST_SHARE);
    }

    */


    [Test]
    public async Task SetAppBadge() {
        await ExecuteTest(NavigatorGroup.BUTTON_SET_APP_BADGE);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NavigatorGroup.TEST_SET_APP_BADGE);
    }

    [Test]
    public async Task ClearAppBadge() {
        await ExecuteTest(NavigatorGroup.BUTTON_CLEAR_APP_BADGE);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NavigatorGroup.TEST_CLEAR_APP_BADGE);
    }


    [Test]
    public async Task RegisterProtocolHandler() {
        await ExecuteTest(NavigatorGroup.BUTTON_REGISTER_PROTOCOL_HANDLER);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NavigatorGroup.TEST_REGISTER_PROTOCOL_HANDLER);
    }

    [Test]
    public async Task UnregisterProtocolHandler() {
        await ExecuteTest(NavigatorGroup.BUTTON_UNREGISTER_PROTOCOL_HANDLER);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NavigatorGroup.TEST_UNREGISTER_PROTOCOL_HANDLER);
    }


    [Test]
    public async Task SendBeacon_String() {
        await ExecuteTest(NavigatorGroup.BUTTON_SEND_BEACON_STRING);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task SendBeacon_Bytes() {
        await ExecuteTest(NavigatorGroup.BUTTON_SEND_BEACON_BYTES);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task Vibrate() {
        await ExecuteTest(NavigatorGroup.BUTTON_VIBRATE);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetAutoplayPolicy_String() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_AUTOPLAY_POLICY_STRING);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("allowed");
    }

    [Test]
    public async Task GetAutoplayPolicy_Element() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_AUTOPLAY_POLICY_ELEMENT);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("allowed");
    }

    [Test]
    public async Task GetInstalledRelatedApps() {
        await ExecuteTest(NavigatorGroup.BUTTON_GET_INSTALLED_RELATED_APPS);

        string? result = await Page.GetByTestId(NavigatorGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NavigatorGroup.TEST_NO_INSTALLED_RELATED_APPS);
    }
}
