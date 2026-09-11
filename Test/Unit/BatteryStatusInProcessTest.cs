using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class BatteryStatusInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    public async Task GetBattery() {
        await ExecuteTest(BatteryStatusInProcessGroup.BUTTON_GET_BATTERY);

        string? result = await Page.GetByTestId(BatteryStatusInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    // Properties

    [Test]
    public async Task GetCharging_Property() {
        await ExecuteTest(BatteryStatusInProcessGroup.BUTTON_GET_CHARGING);

        string? result = await Page.GetByTestId(BatteryStatusInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetChargingTime_Property() {
        await ExecuteTest(BatteryStatusInProcessGroup.BUTTON_GET_CHARGING_TIME);

        string? result = await Page.GetByTestId(BatteryStatusInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("0");
    }

    [Test]
    public async Task GetDischargingTime_Property() {
        await ExecuteTest(BatteryStatusInProcessGroup.BUTTON_GET_DISCHARGING_TIME);

        string? result = await Page.GetByTestId(BatteryStatusInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Infinity");
    }

    [Test]
    public async Task GetLevel_Property() {
        await ExecuteTest(BatteryStatusInProcessGroup.BUTTON_GET_LEVEL);

        string? result = await Page.GetByTestId(BatteryStatusInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }


    // Events

    [Test]
    public async Task RegisterOnChargingChange() {
        await ExecuteTest(BatteryStatusInProcessGroup.BUTTON_REGISTER_ON_CHARGING_CHANGE);
        await Page.EvaluateAsync("async () => (await navigator.getBattery()).dispatchEvent(new Event('chargingchange'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(BatteryStatusInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task RegisterOnChargingTimeChange() {
        await ExecuteTest(BatteryStatusInProcessGroup.BUTTON_REGISTER_ON_CHARGING_TIME_CHANGE);
        await Page.EvaluateAsync("async () => (await navigator.getBattery()).dispatchEvent(new Event('chargingtimechange'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(BatteryStatusInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("0");
    }

    [Test]
    public async Task RegisterOnDischargingTimeChange() {
        await ExecuteTest(BatteryStatusInProcessGroup.BUTTON_REGISTER_ON_DISCHARGING_TIME_CHANGE);
        await Page.EvaluateAsync("async () => (await navigator.getBattery()).dispatchEvent(new Event('dischargingtimechange'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(BatteryStatusInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Infinity");
    }

    [Test]
    public async Task RegisterOnLevelChange() {
        await ExecuteTest(BatteryStatusInProcessGroup.BUTTON_REGISTER_ON_LEVEL_CHANGE);
        await Page.EvaluateAsync("async () => (await navigator.getBattery()).dispatchEvent(new Event('levelchange'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(BatteryStatusInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1");
    }
}
