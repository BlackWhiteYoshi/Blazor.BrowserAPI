using BrowserAPI.Test.Client;
using Microsoft.Playwright;

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


    // Methods

    [Test]
    public async Task Open() {
        await ExecuteTest(WindowGroup.BUTTON_OPEN);

        IPage page = BrowserContext.Pages.First((IPage page) => page.Url.EndsWith("/null"));
        await Assert.That(page).IsNotNull();
        await page.CloseAsync();
    }

    [Test]
    public async Task Close() {
        string result = "no warning output in console";
        void OnConsoleMessage(object? sender, IConsoleMessage message) {
            if (message.Type is "warning")
                result = message.Text;
        }

        Page.Console += OnConsoleMessage;
        await ExecuteTest(WindowGroup.BUTTON_CLOSE);
        Page.Console -= OnConsoleMessage;

        await Assert.That(result).IsEqualTo("Scripts may close only the windows that were opened by them.");
    }

    [Test]
    public async Task Stop() {
        await ExecuteTest(WindowGroup.BUTTON_STOP);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_STOP);
    }

    [Test]
    public async Task Focus() {
        await ExecuteTest(WindowGroup.BUTTON_FOCUS);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_FOCUS);
    }

    [Test]
    public async Task Print() {
        await ExecuteTest(WindowGroup.BUTTON_PRINT);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_PRINT);
    }

    [Test]
    public async Task ReportError() {
        await ExecuteTest(WindowGroup.BUTTON_REPORT_ERROR);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_REPORT_ERROR);
    }

    [Test]
    public async Task Prompt() {
        await ExecuteTest(WindowGroup.BUTTON_PROMPT);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_PROMPT_RESULT);
    }

    [Test]
    public async Task Confirm() {
        await ExecuteTest(WindowGroup.BUTTON_CONFIRM);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task Alert() {
        await ExecuteTest(WindowGroup.BUTTON_ALERT);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_ALERT);
    }


    [Test]
    public async Task MoveBy() {
        await ExecuteTest(WindowGroup.BUTTON_MOVE_BY);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_MOVE_BY);
    }

    [Test]
    public async Task MoveTo() {
        await ExecuteTest(WindowGroup.BUTTON_MOVE_TO);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_MOVE_TO);
    }

    [Test]
    public async Task ResizeBy() {
        await ExecuteTest(WindowGroup.BUTTON_RESIZE_BY);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_RESIZE_BY);
    }

    [Test]
    public async Task ResizeTo() {
        await ExecuteTest(WindowGroup.BUTTON_RESIZE_TO);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_RESIZE_TO);
    }

    [Test]
    public async Task Scroll() {
        await ExecuteTest(WindowGroup.BUTTON_SCROLL);

        int result = await Page.EvaluateAsync<int>("window.scrollY");
        await Assert.That(result).IsEqualTo(10);
    }

    [Test]
    public async Task ScrollTo() {
        await ExecuteTest(WindowGroup.BUTTON_SCROLL_TO);

        int result = await Page.EvaluateAsync<int>("window.scrollY");
        await Assert.That(result).IsEqualTo(10);
    }

    [Test]
    public async Task ScrollBy() {
        await Page.GetByTestId(WindowGroup.BUTTON_SCROLL_BY).HoverAsync();
        await Task.Delay(STANDARD_WAIT_TIME);
        int startPosition = await Page.EvaluateAsync<int>("window.scrollY");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(WindowGroup.BUTTON_SCROLL_BY);

        int endPosition = await Page.EvaluateAsync<int>("window.scrollY");
        int result = endPosition - startPosition;
        await Assert.That(result).IsEqualTo(10);
    }


    [Test]
    public async Task SetTimeout() {
        await ExecuteTest(WindowGroup.BUTTON_SET_TIMEOUT);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_SET_TIMEOUT);
    }

    [Test]
    public async Task ClearTimeout() {
        await ExecuteTest(WindowGroup.BUTTON_CLEAR_TIMEOUT);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_CLEAR_TIMEOUT);
    }

    [Test]
    public async Task SetInterval() {
        await ExecuteTest(WindowGroup.BUTTON_SET_INTERVAL);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_SET_INTERVAL);
    }

    [Test]
    public async Task ClearInterval() {
        await ExecuteTest(WindowGroup.BUTTON_CLEAR_INTERVAL);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_CLEAR_INTERVAL);
    }

    [Test]
    public async Task RequestAnimationFrame() {
        await ExecuteTest(WindowGroup.BUTTON_REQUEST_ANIMATION_FRAME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_REQUEST_ANIMATION_FRAME);
    }

    [Test]
    public async Task CancelAnimationFrame() {
        await ExecuteTest(WindowGroup.BUTTON_CANCEL_ANIMATION_FRAME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_CANCEL_ANIMATION_FRAME);
    }

    [Test]
    public async Task RequestIdleCallback() {
        await ExecuteTest(WindowGroup.BUTTON_REQUEST_IDLE_CALLBACK);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_REQUEST_IDLE_CALLBACK);
    }

    [Test]
    public async Task CancelIdleCallback() {
        await ExecuteTest(WindowGroup.BUTTON_CANCEL_IDLE_CALLBACK);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_CANCEL_IDLE_CALLBACK);
    }

    [Test]
    public async Task QueueMicrotask() {
        await ExecuteTest(WindowGroup.BUTTON_QUEUE_MICROTASK);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_QUEUE_MICROTASK);
    }


    [Test]
    public async Task Atob() {
        await ExecuteTest(WindowGroup.BUTTON_ATOB);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_BASE64);
    }

    [Test]
    public async Task Btoa() {
        await ExecuteTest(WindowGroup.BUTTON_BTOA);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(WindowGroup.TEST_BASE64)));
    }

    [Test]
    public async Task PostMessage() {
        string result = "no info output in console";
        void OnConsoleMessage(object? sender, IConsoleMessage message) {
            if (message.Type is "warning")
                result = message.Text;
        }

        await Page.EvaluateAsync("window.onmessage = (event) => console.warn(event?.data);");
        await Task.Delay(STANDARD_WAIT_TIME);

        Page.Console += OnConsoleMessage;
        await ExecuteTest(WindowGroup.BUTTON_POST_MESSAGE);
        Page.Console -= OnConsoleMessage;

        await Assert.That(result).IsEqualTo(WindowGroup.TEST_POST_MESSAGE);
    }

    [Test]
    public async Task StructuredClone() {
        await ExecuteTest(WindowGroup.BUTTON_STRUCTURED_CLONE);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_STRUCTURED_CLONE);
    }
}
