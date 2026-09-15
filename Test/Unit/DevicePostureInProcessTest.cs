using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class DevicePostureInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    public new async Task GetType() {
        await ExecuteTest(DevicePostureInProcessGroup.BUTTON_GET_TYPE);

        string? result = await Page.GetByTestId(DevicePostureInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("continuous");
    }


    [Test]
    public async Task RegisterOnChange() {
        await ExecuteTest(DevicePostureInProcessGroup.BUTTON_REGISTER_ON_CHANGE);
        await Page.EvaluateAsync("navigator.devicePosture.dispatchEvent(new Event('change'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DevicePostureInProcessGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("continuous");
    }
}
