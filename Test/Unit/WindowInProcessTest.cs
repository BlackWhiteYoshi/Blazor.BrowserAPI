using BrowserAPI.Test.Client;
using Microsoft.Playwright;

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


    // Methods

    [Test]
    public async Task Open() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_OPEN);

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
        await ExecuteTest(WindowInProcessGroup.BUTTON_CLOSE);
        Page.Console -= OnConsoleMessage;

        await Assert.That(result).IsEqualTo("Scripts may close only the windows that were opened by them.");
    }

    [Test]
    public async Task Stop() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_STOP);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_STOP);
    }

    [Test]
    public async Task Focus() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_FOCUS);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_FOCUS);
    }

    [Test]
    public async Task Print() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_PRINT);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_PRINT);
    }

    [Test]
    public async Task ReportError() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_REPORT_ERROR);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_REPORT_ERROR);
    }

    [Test]
    public async Task Prompt() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_PROMPT);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_PROMPT_RESULT);
    }

    [Test]
    public async Task Confirm() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_CONFIRM);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task Alert() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_ALERT);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_ALERT);
    }


    [Test]
    public async Task MoveBy() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_MOVE_BY);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_MOVE_BY);
    }

    [Test]
    public async Task MoveTo() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_MOVE_TO);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_MOVE_TO);
    }

    [Test]
    public async Task ResizeBy() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_RESIZE_BY);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_RESIZE_BY);
    }

    [Test]
    public async Task ResizeTo() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_RESIZE_TO);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_RESIZE_TO);
    }

    [Test]
    public async Task Scroll() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_SCROLL);

        int result = await Page.EvaluateAsync<int>("window.scrollY");
        await Assert.That(result).IsEqualTo(10);
    }

    [Test]
    public async Task ScrollTo() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_SCROLL_TO);

        int result = await Page.EvaluateAsync<int>("window.scrollY");
        await Assert.That(result).IsEqualTo(10);
    }

    [Test]
    public async Task ScrollBy() {
        await Page.GetByTestId(WindowInProcessGroup.BUTTON_SCROLL_BY).HoverAsync();
        await Task.Delay(STANDARD_WAIT_TIME);
        int startPosition = await Page.EvaluateAsync<int>("window.scrollY");
        await Task.Delay(STANDARD_WAIT_TIME);

        await ExecuteTest(WindowInProcessGroup.BUTTON_SCROLL_BY);

        int endPosition = await Page.EvaluateAsync<int>("window.scrollY");
        int result = endPosition - startPosition;
        await Assert.That(result).IsEqualTo(10);
    }


    [Test]
    public async Task SetTimeout() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_SET_TIMEOUT);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_SET_TIMEOUT);
    }

    [Test]
    public async Task ClearTimeout() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_CLEAR_TIMEOUT);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_CLEAR_TIMEOUT);
    }

    [Test]
    public async Task SetInterval() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_SET_INTERVAL);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_SET_INTERVAL);
    }

    [Test]
    public async Task ClearInterval() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_CLEAR_INTERVAL);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_CLEAR_INTERVAL);
    }

    [Test]
    public async Task RequestAnimationFrame() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_REQUEST_ANIMATION_FRAME);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_REQUEST_ANIMATION_FRAME);
    }

    [Test]
    public async Task CancelAnimationFrame() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_CANCEL_ANIMATION_FRAME);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_CANCEL_ANIMATION_FRAME);
    }

    [Test]
    public async Task RequestIdleCallback() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_REQUEST_IDLE_CALLBACK);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_REQUEST_IDLE_CALLBACK);
    }

    [Test]
    public async Task CancelIdleCallback() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_CANCEL_IDLE_CALLBACK);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_CANCEL_IDLE_CALLBACK);
    }

    [Test]
    public async Task QueueMicrotask() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_QUEUE_MICROTASK);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_QUEUE_MICROTASK);
    }


    [Test]
    public async Task Atob() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_ATOB);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_BASE64);
    }

    [Test]
    public async Task Btoa() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_BTOA);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(WindowInProcessGroup.TEST_BASE64)));
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
        await ExecuteTest(WindowInProcessGroup.BUTTON_POST_MESSAGE);
        Page.Console -= OnConsoleMessage;

        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_POST_MESSAGE);
    }

    [Test]
    public async Task StructuredClone() {
        await ExecuteTest(WindowInProcessGroup.BUTTON_STRUCTURED_CLONE);

        string? result = await Page.GetByTestId(WindowInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowInProcessGroup.TEST_STRUCTURED_CLONE);
    }
}
