using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class DevicePostureTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    public async Task GetType_Property() {
        await ExecuteTest(DevicePostureGroup.BUTTON_GET_TYPE_PROPERTY);

        string? result = await Page.GetByTestId(DevicePostureGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("continuous");
    }

    [Test]
    public async Task GetType_Method() {
        await ExecuteTest(DevicePostureGroup.BUTTON_GET_TYPE_METHOD);

        string? result = await Page.GetByTestId(DevicePostureGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("continuous");
    }


    [Test]
    public async Task RegisterOnChange() {
        await ExecuteTest(DevicePostureGroup.BUTTON_REGISTER_ON_CHANGE);
        await Page.EvaluateAsync("navigator.devicePosture.dispatchEvent(new Event('change'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(DevicePostureGroup.OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("continuous");
    }
}
