using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class MediaDevicesTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    public override async Task InitializeAsync() {
        await base.InitializeAsync();
        await Context.GrantPermissionsAsync(["camera", "microphone"]);
    }


    // Media Devices

    [Test]
    [Retry(3)]
    public async Task EnumerateDevices() {
        await Page.GetByTestId(MediaDevicesGroup.BUTTON_ENUMERATE_DEVICES).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MediaDeviceInfo");
    }

    [Test]
    [Retry(3)]
    public async Task GetSupportedConstraints_Property() {
        await Page.GetByTestId(MediaDevicesGroup.BUTTON_GET_SUPPORTED_CONSTRAINTS_PROPERTY).ClickAsync();

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MediaTrackSupportedConstraint");
    }

    [Test]
    [Retry(3)]
    public async Task GetSupportedConstraints_Method() {
        await Page.GetByTestId(MediaDevicesGroup.BUTTON_GET_SUPPORTED_CONSTRAINTS_METHOD).ClickAsync();

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MediaTrackSupportedConstraint");
    }

    // Does not work headless
    //[Test]
    //[Retry(3)]
    //public async Task GetUserMedia() {
    //    await Page.GetByTestId(MediaDevicesGroup.BUTTON_GET_USER_MEDIA).ClickAsync();
    //    // an assertion happens in DisposeAsync()
    //}

    // Does not work headless
    //[Test]
    //[Retry(3)]
    //public async Task GetUserMediaWithConstraint() {
    //    await Page.GetByTestId(MediaDevicesGroup.BUTTON_GET_USER_MEDIA_WITH_CONSTRAINT).ClickAsync();
    //    // an assertion happens in DisposeAsync()
    //}

    // Does not work headless
    //[Test]
    //[Retry(3)]
    //public async Task GetDisplayMedia() {
    //    await Page.GetByTestId(MediaDevicesGroup.BUTTON_GET_DISPLAY_MEDIA).ClickAsync();
    //    // an assertion happens in DisposeAsync()
    //}

    // Does not work headless
    //[Test]
    //[Retry(3)]
    //public async Task GetDisplayMediaWithConstraint() {
    //    await Page.GetByTestId(MediaDevicesGroup.BUTTON_GET_DISPLAY_MEDIA_WITH_CONSTRAINT).ClickAsync();
    //    // an assertion happens in DisposeAsync()
    //}



    // MediaStream and MediaRecorder tests need GetUserMedia() be working
}
