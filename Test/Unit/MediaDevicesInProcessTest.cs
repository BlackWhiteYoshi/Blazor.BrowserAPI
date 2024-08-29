using BrowserAPI.Test.Client;
using Xunit;

namespace BrowserAPI.UnitTest;

[Collection("PlayWright")]
public sealed class MediaDevicesInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    public override async Task InitializeAsync() {
        await base.InitializeAsync();
        await Context.GrantPermissionsAsync(["camera", "microphone"]);
    }


    // Media Devices

    [Fact]
    public async Task EnumerateDevices() {
        await Page.GetByTestId(MediaDevicesGroup.BUTTON_ENUMERATE_DEVICES_INPROCESS).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith("MediaDeviceInfo", result);
    }

    [Fact]
    public async Task GetSupportedConstraints() {
        await Page.GetByTestId(MediaDevicesGroup.BUTTON_GET_SUPPORTED_CONSTRAINTS_INPROCESS).ClickAsync();

        string? result = await Page.GetByTestId(MediaDevicesGroup.LABEL_OUTPUT).TextContentAsync();
        Assert.StartsWith("MediaTrackSupportedConstraint", result);
    }

    // Does not work headless
    //[Fact]
    //public async Task GetUserMedia() {
    //    await Page.GetByTestId(MediaDevicesGroup.BUTTON_GET_USER_MEDIA_INPROCESS).ClickAsync();
    //    // an assertion happens in DisposeAsync()
    //}

    // Does not work headless
    //[Fact]
    //public async Task GetUserMediaWithConstraint() {
    //    await Page.GetByTestId(MediaDevicesGroup.BUTTON_GET_USER_MEDIA_WITH_CONSTRAINT_INPROCESS).ClickAsync();
    //    // an assertion happens in DisposeAsync()
    //}

    // Does not work headless
    //[Fact]
    //public async Task GetDisplayMedia() {
    //    await Page.GetByTestId(MediaDevicesGroup.BUTTON_GET_DISPLAY_MEDIA_INPROCESS).ClickAsync();
    //    // an assertion happens in DisposeAsync()
    //}

    // Does not work headless
    //[Fact]
    //public async Task GetDisplayMediaWithConstraint() {
    //    await Page.GetByTestId(MediaDevicesGroup.BUTTON_GET_DISPLAY_MEDIA_WITH_CONSTRAINT_INPROCESS).ClickAsync();
    //    // an assertion happens in DisposeAsync()
    //}



    // MediaStream and MediaRecorder tests need GetUserMedia() be working
}
