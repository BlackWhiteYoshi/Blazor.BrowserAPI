using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class ScreenInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    public async Task GetWidth() {
        await ExecuteTest(ScreenInProcessGroup.BUTTON_GET_WIDTH);

        string? result = await Page.GetByTestId(ScreenInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetHeight() {
        await ExecuteTest(ScreenInProcessGroup.BUTTON_GET_HEIGHT);

        string? result = await Page.GetByTestId(ScreenInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetAvailWidth() {
        await ExecuteTest(ScreenInProcessGroup.BUTTON_GET_AVAIL_WIDTH);

        string? result = await Page.GetByTestId(ScreenInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetAvailHeight() {
        await ExecuteTest(ScreenInProcessGroup.BUTTON_GET_AVAIL_HEIGHT);

        string? result = await Page.GetByTestId(ScreenInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetColorDepth() {
        await ExecuteTest(ScreenInProcessGroup.BUTTON_GET_COLOR_DEPTH);

        string? result = await Page.GetByTestId(ScreenInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetPixelDepth() {
        await ExecuteTest(ScreenInProcessGroup.BUTTON_GET_PIXEL_DEPTH);

        string? result = await Page.GetByTestId(ScreenInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetIsExtended() {
        await ExecuteTest(ScreenInProcessGroup.BUTTON_GET_IS_EXTENDED);

        string? result = await Page.GetByTestId(ScreenInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }


    // orientation

    [Test]
    public async Task GetOrientationType() {
        await ExecuteTest(ScreenInProcessGroup.BUTTON_GET_ORIENTATION_TYPE);

        string? result = await Page.GetByTestId(ScreenInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("landscape-primary");
    }

    [Test]
    public async Task GetOrientationAngle() {
        await ExecuteTest(ScreenInProcessGroup.BUTTON_GET_ORIENTATION_ANGLE);

        string? result = await Page.GetByTestId(ScreenInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task LockOrientation() {
        await ExecuteTest(ScreenInProcessGroup.BUTTON_LOCK_ORIENTATION);

        string? result = await Page.GetByTestId(ScreenInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result is ScreenInProcessGroup.TEST_LOCK_ORIENTATION_RESULT or ScreenInProcessGroup.TEST_LOCK_ORIENTATION_NOT_SUPPOERTED).IsTrue();
    }

    [Test]
    public async Task UnlockOrientation() {
        await ExecuteTest(ScreenInProcessGroup.BUTTON_UNLOCK_ORIENTATION);

        string? result = await Page.GetByTestId(ScreenInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(ScreenInProcessGroup.TEST_UNLOCK_ORIENTATION_RESULT);
    }


    // events

    [Test]
    public async Task RegisterOnChange() {
        await ExecuteTest(ScreenInProcessGroup.BUTTON_REGISTER_ON_CHANGE);
        await Page.EvaluateAsync("window.screen.dispatchEvent(new Event('change'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(ScreenInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(ScreenInProcessGroup.TEST_CHANGE_EVENT);
    }

    [Test]
    public async Task RegisterOnOrientationChange() {
        await ExecuteTest(ScreenInProcessGroup.BUTTON_REGISTER_ON_ORIENTATION_CHANGE);
        await Page.EvaluateAsync("window.screen.orientation.dispatchEvent(new Event('change'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(ScreenInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(ScreenInProcessGroup.TEST_ORIENTATION_CHANGE_EVENT);
    }
}
