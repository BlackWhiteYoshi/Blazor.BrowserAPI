using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class MediaDevicesInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    public override async Task InitializeAsync() {
        await base.InitializeAsync();
        await BrowserContext.GrantPermissionsAsync(["camera", "microphone"]);
    }


    // Media Devices

    [Test]
    public async Task EnumerateDevices() {
        await ExecuteTest(MediaDevicesInProcessGroup.BUTTON_ENUMERATE_DEVICES);

        string? result = await Page.GetByTestId(MediaDevicesInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MediaDeviceInfo");
    }

    [Test]
    public async Task GetSupportedConstraints() {
        await ExecuteTest(MediaDevicesInProcessGroup.BUTTON_GET_SUPPORTED_CONSTRAINTS);

        string? result = await Page.GetByTestId(MediaDevicesInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MediaTrackSupportedConstraint");
    }

    /* Does not work headless

    [Test]
    public async Task GetUserMedia() {
        await ExecuteTest(MediaDevicesInProcessGroup.BUTTON_GET_USER_MEDIA);
        // an assertion happens in DisposeAsync()
    }

    [Test]
    public async Task GetUserMediaWithConstraint() {
        await ExecuteTest(MediaDevicesInProcessGroup.BUTTON_GET_USER_MEDIA_WITH_CONSTRAINT);
        // an assertion happens in DisposeAsync()
    }

    [Test]
    public async Task GetDisplayMedia() {
        await ExecuteTest(MediaDevicesInProcessGroup.BUTTON_GET_DISPLAY_MEDIA);
        // an assertion happens in DisposeAsync()
    }

    [Test]
    public async Task GetDisplayMediaWithConstraint() {
        await ExecuteTest(MediaDevicesInProcessGroup.BUTTON_GET_DISPLAY_MEDIA_WITH_CONSTRAINT);
        // an assertion happens in DisposeAsync()
    }

    */


    // MediaStream and MediaRecorder tests need GetUserMedia() be working
}
