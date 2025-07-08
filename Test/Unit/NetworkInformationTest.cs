using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class NetworkInformationTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    public async Task GetOnLine_Property() {
        await ExecuteTest(NetworkInformationGroup.BUTTON_GET_ON_LINE_PROPERTY);

        string? result = await Page.GetByTestId(NetworkInformationGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetOnLine_Method() {
        await ExecuteTest(NetworkInformationGroup.BUTTON_GET_ON_LINE_METHOD);

        string? result = await Page.GetByTestId(NetworkInformationGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetDownlink_Property() {
        await ExecuteTest(NetworkInformationGroup.BUTTON_GET_DOWNLINK_PROPERTY);

        string? result = await Page.GetByTestId(NetworkInformationGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetDownlink_Method() {
        await ExecuteTest(NetworkInformationGroup.BUTTON_GET_DOWNLINK_METHOD);

        string? result = await Page.GetByTestId(NetworkInformationGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetDownlinkMax_Property() {
        await ExecuteTest(NetworkInformationGroup.BUTTON_GET_DOWNLINK_MAX_PROPERTY);

        string? result = await Page.GetByTestId(NetworkInformationGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetDownlinkMax_Method() {
        await ExecuteTest(NetworkInformationGroup.BUTTON_GET_DOWNLINK_MAX_METHOD);

        string? result = await Page.GetByTestId(NetworkInformationGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetEffectiveType_Property() {
        await ExecuteTest(NetworkInformationGroup.BUTTON_GET_EFFECTIVE_TYPE_PROPERTY);

        string? result = await Page.GetByTestId(NetworkInformationGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }

    [Test]
    public async Task GetEffectiveType_Method() {
        await ExecuteTest(NetworkInformationGroup.BUTTON_GET_EFFECTIVE_TYPE_METHOD);

        string? result = await Page.GetByTestId(NetworkInformationGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsNotEmpty();
    }

    [Test]
    public async Task GetType_Property() {
        await ExecuteTest(NetworkInformationGroup.BUTTON_GET_TYPE_PROPERTY);

        string? result = await Page.GetByTestId(NetworkInformationGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NetworkInformationGroup.MISSING_BROWSER_SUPPOERT);
    }

    [Test]
    public async Task GetType_Method() {
        await ExecuteTest(NetworkInformationGroup.BUTTON_GET_TYPE_METHOD);

        string? result = await Page.GetByTestId(NetworkInformationGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NetworkInformationGroup.MISSING_BROWSER_SUPPOERT);
    }

    [Test]
    public async Task GetRTT_Property() {
        await ExecuteTest(NetworkInformationGroup.BUTTON_GET_RTT_PROPERTY);

        string? result = await Page.GetByTestId(NetworkInformationGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetRTT_Method() {
        await ExecuteTest(NetworkInformationGroup.BUTTON_GET_RTT_METHOD);

        string? result = await Page.GetByTestId(NetworkInformationGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetSaveData_Property() {
        await ExecuteTest(NetworkInformationGroup.BUTTON_GET_SAVE_DATA_PROPERTY);

        string? result = await Page.GetByTestId(NetworkInformationGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetSaveData_Method() {
        await ExecuteTest(NetworkInformationGroup.BUTTON_GET_SAVE_DATA_METHOD);

        string? result = await Page.GetByTestId(NetworkInformationGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }


    [Test]
    public async Task RegisterOnOnline() {
        await ExecuteTest(NetworkInformationGroup.BUTTON_REGISTER_ON_ONLINE);
        await BrowserContext.SetOfflineAsync(true);
        await Task.Delay(SMALL_WAIT_TIME);
        await BrowserContext.SetOfflineAsync(false);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(NetworkInformationGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NetworkInformationGroup.TEST_ONLINE_EVENT);
    }

    [Test]
    public async Task RegisterOnOffline() {
        await ExecuteTest(NetworkInformationGroup.BUTTON_REGISTER_ON_OFFLINE);
        await BrowserContext.SetOfflineAsync(true);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(NetworkInformationGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NetworkInformationGroup.TEST_OFFLINE_EVENT);
    }

    [Test]
    public async Task RegisterOnChange() {
        await ExecuteTest(NetworkInformationGroup.BUTTON_REGISTER_ON_CHANGE);
        await BrowserContext.SetOfflineAsync(true);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(NetworkInformationGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(NetworkInformationGroup.TEST_CHANGE_EVENT);
    }
}
