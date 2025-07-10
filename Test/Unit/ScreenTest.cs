using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class ScreenTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    public async Task GetWidth_Property() {
        await ExecuteTest(ScreenGroup.BUTTON_GET_WIDTH_PROPERTY);

        string? result = await Page.GetByTestId(ScreenGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetWidth_Method() {
        await ExecuteTest(ScreenGroup.BUTTON_GET_WIDTH_METHOD);

        string? result = await Page.GetByTestId(ScreenGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetHeight_Property() {
        await ExecuteTest(ScreenGroup.BUTTON_GET_HEIGHT_PROPERTY);

        string? result = await Page.GetByTestId(ScreenGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetHeight_Method() {
        await ExecuteTest(ScreenGroup.BUTTON_GET_HEIGHT_METHOD);

        string? result = await Page.GetByTestId(ScreenGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetAvailWidth_Property() {
        await ExecuteTest(ScreenGroup.BUTTON_GET_AVAIL_WIDTH_PROPERTY);

        string? result = await Page.GetByTestId(ScreenGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetAvailWidth_Method() {
        await ExecuteTest(ScreenGroup.BUTTON_GET_AVAIL_WIDTH_METHOD);

        string? result = await Page.GetByTestId(ScreenGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetAvailHeight_Property() {
        await ExecuteTest(ScreenGroup.BUTTON_GET_AVAIL_HEIGHT_PROPERTY);

        string? result = await Page.GetByTestId(ScreenGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetAvailHeight_Method() {
        await ExecuteTest(ScreenGroup.BUTTON_GET_AVAIL_HEIGHT_METHOD);

        string? result = await Page.GetByTestId(ScreenGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetColorDepth_Property() {
        await ExecuteTest(ScreenGroup.BUTTON_GET_COLOR_DEPTH_PROPERTY);

        string? result = await Page.GetByTestId(ScreenGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetColorDepth_Method() {
        await ExecuteTest(ScreenGroup.BUTTON_GET_COLOR_DEPTH_METHOD);

        string? result = await Page.GetByTestId(ScreenGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetPixelDepth_Property() {
        await ExecuteTest(ScreenGroup.BUTTON_GET_PIXEL_DEPTH_PROPERTY);

        string? result = await Page.GetByTestId(ScreenGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetPixelDepth_Method() {
        await ExecuteTest(ScreenGroup.BUTTON_GET_PIXEL_DEPTH_METHOD);

        string? result = await Page.GetByTestId(ScreenGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetIsExtended_Property() {
        await ExecuteTest(ScreenGroup.BUTTON_GET_IS_EXTENDED_PROPERTY);

        string? result = await Page.GetByTestId(ScreenGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetIsExtended_Method() {
        await ExecuteTest(ScreenGroup.BUTTON_GET_IS_EXTENDED_METHOD);

        string? result = await Page.GetByTestId(ScreenGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }


    // orientation

    [Test]
    public async Task GetOrientationType_Property() {
        await ExecuteTest(ScreenGroup.BUTTON_GET_ORIENTATION_TYPE_PROPERTY);

        string? result = await Page.GetByTestId(ScreenGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("landscape-primary");
    }

    [Test]
    public async Task GetOrientationType_Method() {
        await ExecuteTest(ScreenGroup.BUTTON_GET_ORIENTATION_TYPE_METHOD);

        string? result = await Page.GetByTestId(ScreenGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("landscape-primary");
    }


    [Test]
    public async Task GetOrientationAngle_Property() {
        await ExecuteTest(ScreenGroup.BUTTON_GET_ORIENTATION_ANGLE_PROPERTY);

        string? result = await Page.GetByTestId(ScreenGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetOrientationAngle_Method() {
        await ExecuteTest(ScreenGroup.BUTTON_GET_ORIENTATION_ANGLE_METHOD);

        string? result = await Page.GetByTestId(ScreenGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task LockOrientation() {
        await ExecuteTest(ScreenGroup.BUTTON_LOCK_ORIENTATION);

        string? result = await Page.GetByTestId(ScreenGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result is ScreenGroup.TEST_LOCK_ORIENTATION_RESULT or ScreenGroup.TEST_LOCK_ORIENTATION_NOT_SUPPOERTED).IsTrue();
    }

    [Test]
    public async Task UnlockOrientation() {
        await ExecuteTest(ScreenGroup.BUTTON_UNLOCK_ORIENTATION);

        string? result = await Page.GetByTestId(ScreenGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(ScreenGroup.TEST_UNLOCK_ORIENTATION_RESULT);
    }


    // events

    [Test]
    public async Task RegisterOnChange() {
        await ExecuteTest(ScreenGroup.BUTTON_REGISTER_ON_CHANGE);
        await Page.EvaluateAsync("window.screen.dispatchEvent(new Event('change'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(ScreenGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(ScreenGroup.TEST_CHANGE_EVENT);
    }

    [Test]
    public async Task RegisterOnOrientationChange() {
        await ExecuteTest(ScreenGroup.BUTTON_REGISTER_ON_ORIENTATION_CHANGE);
        await Page.EvaluateAsync("window.screen.orientation.dispatchEvent(new Event('change'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(ScreenGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(ScreenGroup.TEST_ORIENTATION_CHANGE_EVENT);
    }
}
