using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class NetworkInformationInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    public async Task GetOnLine() {
        await ExecuteTest(NetworkInformationInProcessGroup.BUTTON_GET_ON_LINE);

        string? result = await Page.GetByTestId(NetworkInformationInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetDownlink() {
        await ExecuteTest(NetworkInformationInProcessGroup.BUTTON_GET_DOWNLINK);

        string? result = await Page.GetByTestId(NetworkInformationInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetDownlinkMax() {
        await ExecuteTest(NetworkInformationInProcessGroup.BUTTON_GET_DOWNLINK_MAX);

        string? result = await Page.GetByTestId(NetworkInformationInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetEffectiveType() {
        await ExecuteTest(NetworkInformationInProcessGroup.BUTTON_GET_EFFECTIVE_TYPE);

        string? result = await Page.GetByTestId(NetworkInformationInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }

    [Test]
    public new async Task GetType() {
        await ExecuteTest(NetworkInformationInProcessGroup.BUTTON_GET_TYPE);

        string? result = await Page.GetByTestId(NetworkInformationInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NetworkInformationInProcessGroup.MISSING_BROWSER_SUPPOERT);
    }

    [Test]
    public async Task GetRTT() {
        await ExecuteTest(NetworkInformationInProcessGroup.BUTTON_GET_RTT);

        string? result = await Page.GetByTestId(NetworkInformationInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetSaveData() {
        await ExecuteTest(NetworkInformationInProcessGroup.BUTTON_GET_SAVE_DATA);

        string? result = await Page.GetByTestId(NetworkInformationInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }


    [Test]
    public async Task RegisterOnOnline() {
        await ExecuteTest(NetworkInformationInProcessGroup.BUTTON_REGISTER_ON_ONLINE);
        await BrowserContext.SetOfflineAsync(true);
        await Task.Delay(SMALL_WAIT_TIME);
        await BrowserContext.SetOfflineAsync(false);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(NetworkInformationInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NetworkInformationInProcessGroup.TEST_ONLINE_EVENT);
    }

    [Test]
    public async Task RegisterOnOffline() {
        await ExecuteTest(NetworkInformationInProcessGroup.BUTTON_REGISTER_ON_OFFLINE);
        await BrowserContext.SetOfflineAsync(true);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(NetworkInformationInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NetworkInformationInProcessGroup.TEST_OFFLINE_EVENT);
    }

    [Test]
    public async Task RegisterOnChange() {
        await ExecuteTest(NetworkInformationInProcessGroup.BUTTON_REGISTER_ON_CHANGE);
        await BrowserContext.SetOfflineAsync(true);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(NetworkInformationInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NetworkInformationInProcessGroup.TEST_CHANGE_EVENT);
    }
}
