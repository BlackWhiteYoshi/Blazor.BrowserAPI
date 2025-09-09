using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class WindowTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    // Properties

    [Test]
    public async Task GetInnerWidth_Property() {
        await ExecuteTest(WindowGroup.BUTTON_GET_INNER_WIDTH_PROPERTY);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetInnerWidth_Method() {
        await ExecuteTest(WindowGroup.BUTTON_GET_INNER_WIDTH_METHOD);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetInnerHeight_Property() {
        await ExecuteTest(WindowGroup.BUTTON_GET_INNER_HEIGHT_PROPERTY);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetInnerHeight_Method() {
        await ExecuteTest(WindowGroup.BUTTON_GET_INNER_HEIGHT_METHOD);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetOuterWidth_Property() {
        await ExecuteTest(WindowGroup.BUTTON_GET_OUTER_WIDTH_PROPERTY);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetOuterWidth_Method() {
        await ExecuteTest(WindowGroup.BUTTON_GET_OUTER_WIDTH_METHOD);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetOuterHeight_Property() {
        await ExecuteTest(WindowGroup.BUTTON_GET_OUTER_HEIGHT_PROPERTY);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetOuterHeight_Method() {
        await ExecuteTest(WindowGroup.BUTTON_GET_OUTER_HEIGHT_METHOD);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetDevicePixelRatio_Property() {
        await ExecuteTest(WindowGroup.BUTTON_GET_DEVICE_PIXEL_RATIO_PROPERTY);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetDevicePixelRatio_Method() {
        await ExecuteTest(WindowGroup.BUTTON_GET_DEVICE_PIXEL_RATIO_METHOD);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetScrollX_Property() {
        await ExecuteTest(WindowGroup.BUTTON_GET_SCROLL_X_PROPERTY);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetScrollX_Method() {
        await ExecuteTest(WindowGroup.BUTTON_GET_SCROLL_X_METHOD);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetScrollY_Property() {
        await ExecuteTest(WindowGroup.BUTTON_GET_SCROLL_Y_PROPERTY);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetScrollY_Method() {
        await ExecuteTest(WindowGroup.BUTTON_GET_SCROLL_Y_METHOD);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = double.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetScreenX_Property() {
        await ExecuteTest(WindowGroup.BUTTON_GET_SCREEN_X_PROPERTY);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetScreenX_Method() {
        await ExecuteTest(WindowGroup.BUTTON_GET_SCREEN_X_METHOD);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetScreenY_Property() {
        await ExecuteTest(WindowGroup.BUTTON_GET_SCREEN_Y_PROPERTY);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }

    [Test]
    public async Task GetScreenY_Method() {
        await ExecuteTest(WindowGroup.BUTTON_GET_SCREEN_Y_METHOD);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out _);
        await Assert.That(isNumber).IsTrue();
    }


    [Test]
    public async Task GetOrigin_Property() {
        await ExecuteTest(WindowGroup.BUTTON_GET_ORIGIN_PROPERTY);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("https://localhost:5000");
    }

    [Test]
    public async Task GetOrigin_Method() {
        await ExecuteTest(WindowGroup.BUTTON_GET_ORIGIN_METHOD);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("https://localhost:5000");
    }

    [Test]
    public async Task GetName_Property() {
        await Page.EvaluateAsync($"window.name = '{WindowGroup.TEST_NAME}';");

        await ExecuteTest(WindowGroup.BUTTON_GET_NAME_PROPERTY);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_NAME);
    }

    [Test]
    public async Task GetName_Method() {
        await Page.EvaluateAsync($"window.name = '{WindowGroup.TEST_NAME}';");

        await ExecuteTest(WindowGroup.BUTTON_GET_NAME_METHOD);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_NAME);
    }

    [Test]
    public async Task SetName() {
        await ExecuteTest(WindowGroup.BUTTON_SET_NAME);

        string result = await Page.EvaluateAsync<string>("window.name;");
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_NAME);
    }


    [Test]
    public async Task GetClosed_Property() {
        await ExecuteTest(WindowGroup.BUTTON_GET_CLOSED_PROPERTY);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetClosed_Method() {
        await ExecuteTest(WindowGroup.BUTTON_GET_CLOSED_METHOD);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetCredentialless_Property() {
        await ExecuteTest(WindowGroup.BUTTON_GET_CREDENTIALLESS_PROPERTY);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetCredentialless_Method() {
        await ExecuteTest(WindowGroup.BUTTON_GET_CREDENTIALLESS_METHOD);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetCrossOriginIsolated_Property() {
        await ExecuteTest(WindowGroup.BUTTON_GET_CROSS_ORIGIN_ISOLATED_PROPERTY);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetCrossOriginIsolated_Method() {
        await ExecuteTest(WindowGroup.BUTTON_GET_CROSS_ORIGIN_ISOLATED_METHOD);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetIsSecureContext_Property() {
        await ExecuteTest(WindowGroup.BUTTON_GET_IS_SECURE_CONTEXT_PROPERTY);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetIsSecureContext_Method() {
        await ExecuteTest(WindowGroup.BUTTON_GET_IS_SECURE_CONTEXT_METHOD);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetOriginAgentCluster_Property() {
        await ExecuteTest(WindowGroup.BUTTON_GET_ORIGIN_AGENT_CLUSTER_PROPERTY);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetOriginAgentCluster_Method() {
        await ExecuteTest(WindowGroup.BUTTON_GET_ORIGIN_AGENT_CLUSTER_METHOD);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetMenubar_Property() {
        await ExecuteTest(WindowGroup.BUTTON_GET_MENUBAR_PROPERTY);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetMenubar_Method() {
        await ExecuteTest(WindowGroup.BUTTON_GET_MENUBAR_METHOD);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task GetFrameElement_Property() {
        await ExecuteTest(WindowGroup.BUTTON_GET_FRAME_ELEMENT_PROPERTY);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task GetFrameElement_Method() {
        await ExecuteTest(WindowGroup.BUTTON_GET_FRAME_ELEMENT_METHOD);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }
}
