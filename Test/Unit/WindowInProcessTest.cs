using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class WindowInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    // Properties

    [Test]
    public async Task GetInnerWidth() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_GET_INNER_WIDTH);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetInnerHeight() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_GET_INNER_HEIGHT);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetOuterWidth() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_GET_OUTER_WIDTH);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetOuterHeight() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_GET_OUTER_HEIGHT);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetDevicePixelRatio() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_GET_DEVICE_PIXEL_RATIO);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetScrollX() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_GET_SCROLL_X);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetScrollY() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_GET_SCROLL_Y);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetScreenX() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_GET_SCREEN_X);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetScreenY() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_GET_SCREEN_Y);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetOrigin() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_GET_ORIGIN);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("https://localhost:5000");
    }

    [Test]
    public async Task GetName() {
        await Page.EvaluateAsync($"window.name = '{WindowInProcessGroup.TEST_NAME}';");

        await ExecuteTest(WindowInProcessGroup.BUTTON_GET_NAME);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_NAME);
    }

    [Test]
    public async Task SetName() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_SET_NAME);

        string result = await Page.EvaluateAsync<string>("window.name;");
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_NAME);
    }


    [Test]
    public async Task GetClosed() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_GET_CLOSED);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetCredentialless() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_GET_CREDENTIALLESS);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetCrossOriginIsolated() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_GET_CROSS_ORIGIN_ISOLATED);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetIsSecureContext() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_GET_IS_SECURE_CONTEXT);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetOriginAgentCluster() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_GET_ORIGIN_AGENT_CLUSTER);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetMenubar() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_GET_MENUBAR);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetFrameElement() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_GET_FRAME_ELEMENT);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }
}
