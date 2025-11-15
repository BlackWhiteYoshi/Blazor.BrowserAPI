using BrowserAPI.Test.Client;
using TUnit.Core.Interfaces;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class NavigatorInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    public override Task InitializeAsync()
        => (TestContext.Current as ITestMetadata)?.DisplayName switch {
            nameof(GetAutoplayPolicy_String)
            or nameof(GetAutoplayPolicy_Element) => NewPage(BrowserId.Firefox),
            _ => NewPage(BrowserId.Chromium)
        };


    // Properties

    [Test]
    public async Task GetLanguage() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_GET_LANGUAGE);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }

    [Test]
    public async Task GetLanguages() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_GET_LANGUAGES);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }


    [Test]
    public async Task GetUserAgent() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_GET_USER_AGENT);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }

    [Test]
    public async Task GetWebdriver() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_GET_WEBDRIVER);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetUserActivationIsActive() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_GET_USER_ACTIVATION_IS_ACTIVE);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetUserActivationHasBeenActive() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_GET_USER_ACTIVATION_HAS_BEEN_ACTIVE);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetCookieEnabled() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_GET_COOKIE_ENABLED);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool resultIsBool = bool.TryParse(result, out _);
        await Assert.That(resultIsBool).IsTrue();
    }

    [Test]
    public async Task GetPdfViewerEnabled() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_GET_PDF_VIEWER_ENABLED);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool resultIsBool = bool.TryParse(result, out _);
        await Assert.That(resultIsBool).IsTrue();
    }


    [Test]
    public async Task GetMaxTouchPoints() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_GET_MAX_TOUCH_POINTS);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool resultIsNumber = int.TryParse(result, out _);
        await Assert.That(resultIsNumber).IsTrue();
    }

    [Test]
    public async Task GetHardwareConcurrency() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_GET_HARDWARE_CONCURRENCY);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool resultIsNumber = int.TryParse(result, out _);
        await Assert.That(resultIsNumber).IsTrue();
    }

    [Test]
    public async Task GetDeviceMemory() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_GET_DEVICE_MEMORY);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool resultIsNumber = double.TryParse(result, out _);
        await Assert.That(resultIsNumber).IsTrue();
    }



    /* Does not work in headless mode

    [Test]
    public async Task CanShare() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_CAN_SHARE);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task Share() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_SHARE);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NavigatorInProcessGroup.TEST_SHARE);
    }

    */


    [Test]
    public async Task SetAppBadge() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_SET_APP_BADGE);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NavigatorInProcessGroup.TEST_SET_APP_BADGE);
    }

    [Test]
    public async Task ClearAppBadge() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_CLEAR_APP_BADGE);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NavigatorInProcessGroup.TEST_CLEAR_APP_BADGE);
    }


    [Test]
    public async Task RegisterProtocolHandler() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_REGISTER_PROTOCOL_HANDLER);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NavigatorInProcessGroup.TEST_REGISTER_PROTOCOL_HANDLER);
    }

    [Test]
    public async Task UnregisterProtocolHandler() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_UNREGISTER_PROTOCOL_HANDLER);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NavigatorInProcessGroup.TEST_UNREGISTER_PROTOCOL_HANDLER);
    }


    [Test]
    public async Task SendBeacon_String() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_SEND_BEACON_STRING);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task SendBeacon_Bytes() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_SEND_BEACON_BYTES);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task Vibrate() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_VIBRATE);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetAutoplayPolicy_String() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_GET_AUTOPLAY_POLICY_STRING);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("allowed");
    }

    [Test]
    public async Task GetAutoplayPolicy_Element() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_GET_AUTOPLAY_POLICY_ELEMENT);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("allowed");
    }

    [Test]
    public async Task GetInstalledRelatedApps() {
        await ExecuteTest(NavigatorInProcessGroup.BUTTON_GET_INSTALLED_RELATED_APPS);

        string? result = await Page.GetByTestId(NavigatorInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NavigatorInProcessGroup.TEST_NO_INSTALLED_RELATED_APPS);
    }
}
