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

        IPage? page = BrowserContext.Pages.FirstOrDefault((IPage page) => page.Url.EndsWith("/null"));
        if (page is not null)
            await page.CloseAsync();

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
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


    // Events

    [Test]
    public async Task RegisterOnError() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_ERROR);

        await Page.EvaluateAsync("""
            const event = new Event("error");
            event.message = "test";
            window.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).Contains(@"""message"":""test""");
    }

    [Test]
    public async Task RegisterOnLanguageChange() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_LANGUAGE_CHANGE);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('languagechange'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).Contains(WindowGroup.TEST_EVENT_LANGUAGE_CHANGE);
    }

    [Test]
    public async Task RegisterOnResize() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_RESIZE);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('resize'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).Contains(WindowGroup.TEST_EVENT_RESIZE);
    }

    [Test]
    public async Task RegisterOnStorage() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_STORAGE);

        await Page.EvaluateAsync("""
            const event = new Event("storage");
            event.url = "https://localhost:5000";
            event.key = "test-key";
            event.oldValue = null;
            event.newValue = "test-value";
            window.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("StorageEvent { Url = https://localhost:5000, Key = test-key, NewValue = test-value, OldValue =  }");
    }


    [Test]
    public async Task RegisterOnFocus() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_FOCUS);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('focus'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_FOCUS);
    }

    [Test]
    public async Task RegisterOnBlur() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_BLUR);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('blur'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_BLUR);
    }

    [Test]
    public async Task RegisterOnLoad() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_LOAD);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('load'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_LOAD);
    }

    [Test]
    public async Task RegisterOnBeforeUnLoad() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_BEFORE_UNLOAD);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('beforeunload'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_BEFORE_UNLOAD);
    }

    [Test]
    public async Task RegisterOnAppInstalled() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_APP_INSTALLED);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('appinstalled'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_APP_INSTALLED);
    }

    [Test]
    public async Task RegisterOnBeforeInstallPrompt() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_BEFORE_INSTALL_PROMPT);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('beforeinstallprompt'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_BEFORE_INSTALL_PROMPT);
    }

    [Test]
    public async Task RegisterOnMessage() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_MESSAGE);

        await Page.EvaluateAsync($"window.postMessage('{WindowGroup.TEST_POST_MESSAGE}', '*');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo($"data = {WindowGroup.TEST_POST_MESSAGE}, origin = https://localhost:5000, lastEventId = ");
    }

    [Test]
    public async Task RegisterOnMessageError() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_MESSAGE_ERROR);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('messageerror'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("data = , origin = , lastEventId = ");
    }

    [Test]
    public async Task RegisterOnAfterPrint() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_AFTER_PRINT);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('afterprint'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_AFTER_PRINT);
    }

    [Test]
    public async Task RegisterOnBeforePrint() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_BEFORE_PRINT);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('beforeprint'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_BEFORE_PRINT);
    }

    [Test]
    public async Task RegisterOnRejectionHandled() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_REJECTION_HANDLED);

        await Page.EvaluateAsync("""
            setTimeout(() => {
                const promise = new Promise((resolve, reject) => reject());
                setTimeout(() => promise.catch(() => {}), 100);
            }, 0);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("(no reason)");
    }

    [Test]
    public async Task RegisterOnUnhandledRejection() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_UNHANDLED_REJECTION);

        await Page.EvaluateAsync("setTimeout(() => new Promise((resolve, reject) => reject()), 0);");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("(no reason)");
    }


    // events - HTMLElement

    [Test]
    public async Task RegisterOnScroll() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_SCROLL);

        await Page.Mouse.WheelAsync(0, 1);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_SCROLL);
    }

    [Test]
    public async Task RegisterOnScrollEnd() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_SCROLL_END);

        await Page.Mouse.WheelAsync(0, 1);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_SCROLL_END);
    }

    [Test]
    public async Task RegisterOnChange() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_CHANGE);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("input");
            tempElement.setAttribute("data-testid", "temp");
            document.body.appendChild(tempElement);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").FillAsync("something");
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").BlurAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_CHANGE);
    }


    [Test]
    public async Task RegisterOnDrag() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_DRAG);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.setAttribute("draggable", "true");
            tempElement.textContent = "draggable";
            document.body.appendChild(tempElement);

            const dragTarget = document.createElement("div");
            dragTarget.setAttribute("data-testid", "dragTarget");
            dragTarget.textContent = "drag target";
            document.body.appendChild(dragTarget);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").DragToAsync(Page.GetByTestId("dragTarget"));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='uninitialized', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDragStart() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_DRAG_START);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.setAttribute("draggable", "true");
            tempElement.textContent = "draggable";
            document.body.appendChild(tempElement);

            const dragTarget = document.createElement("div");
            dragTarget.setAttribute("data-testid", "dragTarget");
            dragTarget.textContent = "drag target";
            document.body.appendChild(dragTarget);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").DragToAsync(Page.GetByTestId("dragTarget"));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='uninitialized', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDragEnd() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_DRAG_END);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.setAttribute("draggable", "true");
            tempElement.textContent = "draggable";
            document.body.appendChild(tempElement);

            const dragTarget = document.createElement("div");
            dragTarget.setAttribute("data-testid", "dragTarget");
            dragTarget.textContent = "drag target";
            document.body.appendChild(dragTarget);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").DragToAsync(Page.GetByTestId("dragTarget"));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='uninitialized', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDragEnter() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_DRAG_ENTER);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.setAttribute("draggable", "true");
            tempElement.textContent = "draggable";
            document.body.appendChild(tempElement);

            const dragTarget = document.createElement("div");
            dragTarget.setAttribute("data-testid", "dragTarget");
            dragTarget.textContent = "drag target";
            document.body.appendChild(dragTarget);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").DragToAsync(Page.GetByTestId("dragTarget"));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='all', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDragLeave() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_DRAG_LEAVE);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.setAttribute("draggable", "true");
            tempElement.textContent = "draggable";
            document.body.appendChild(tempElement);

            const dragTarget = document.createElement("div");
            dragTarget.setAttribute("data-testid", "dragTarget");
            dragTarget.textContent = "drag target";
            document.body.appendChild(dragTarget);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").DragToAsync(Page.GetByTestId("dragTarget"));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='all', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDragOver() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_DRAG_OVER);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.setAttribute("draggable", "true");
            tempElement.textContent = "draggable";
            document.body.appendChild(tempElement);

            const dragTarget = document.createElement("div");
            dragTarget.setAttribute("data-testid", "dragTarget");
            dragTarget.textContent = "drag target";
            document.body.appendChild(dragTarget);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").DragToAsync(Page.GetByTestId("dragTarget"));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='none', effectAllowed='all', types='[]', files='[]'");
    }

    [Test]
    public async Task RegisterOnDrop() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_DROP);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.setAttribute("draggable", "true");
            tempElement.textContent = "draggable";
            document.body.appendChild(tempElement);

            const dragTarget = document.createElement("div");
            dragTarget.setAttribute("data-testid", "dragTarget");
            dragTarget.textContent = "drag target";
            dragTarget.addEventListener("dragover", e => e.preventDefault());
            document.body.appendChild(dragTarget);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").DragToAsync(Page.GetByTestId("dragTarget"));
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("dropEffect='copy', effectAllowed='all', types='[]', files='[]'");
    }


    [Test]
    public async Task RegisterOnToggle() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_TOGGLE);

        await Page.EvaluateAsync("""
            const event = new Event("toggle");
            event.oldState = "closed";
            event.newState = "open";
            window.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("oldState='closed', newState='open'");
    }

    [Test]
    public async Task RegisterOnBeforeToggle() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_BEFORE_TOGGLE);

        await Page.EvaluateAsync("""
            const event = new Event("beforetoggle");
            event.oldState = "closed";
            event.newState = "open";
            window.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("oldState='closed', newState='open'");
    }


    // events - Element

    [Test]
    public async Task RegisterOnInput() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_INPUT);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("input");
            tempElement.setAttribute("data-testid", "temp");
            document.body.appendChild(tempElement);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").FillAsync("something");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("data=something, inputType=insertText, isComposing=False");
    }

    [Test]
    public async Task RegisterOnBeforeInput() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_BEFORE_INPUT);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("input");
            tempElement.setAttribute("data-testid", "temp");
            document.body.appendChild(tempElement);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").FillAsync("something");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("data=something, inputType=insertText, isComposing=False");
    }

    [Test]
    public async Task RegisterOnBeforeMatch() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_BEFORE_MATCH);

        await Page.EvaluateAsync("""
            const hiddenElement = document.createElement("div");
            hiddenElement.setAttribute("id", "htmlelement-fragment");
            hiddenElement.setAttribute("hidden", "until-found");
            document.body.appendChild(hiddenElement);

            const a = document.createElement("a");
            a.href = "#htmlelement-fragment";
            document.body.appendChild(a);
            a.click();
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_BEFORE_MATCH);
    }


    [Test]
    public async Task RegisterOnKeyDown() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_KEY_DOWN);

        await Page.Keyboard.PressAsync("a");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("KeyboardEvent { Key = a, Code = KeyA, Location = 0, CtrlKey = False, ShiftKey = False, AltKey = False, MetaKey = False, Repeat = False, IsComposing = False }");
    }

    [Test]
    public async Task RegisterOnKeyUp() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_KEY_UP);

        await Page.Keyboard.PressAsync("a");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("KeyboardEvent { Key = a, Code = KeyA, Location = 0, CtrlKey = False, ShiftKey = False, AltKey = False, MetaKey = False, Repeat = False, IsComposing = False }");
    }


    [Test]
    public async Task RegisterOnClick() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_CLICK);

        await Page.Mouse.ClickAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnDblClick() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_DBL_CLICK);

        await Page.Mouse.DblClickAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnAuxClick() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_AUX_CLICK);

        await Page.Mouse.ClickAsync(1.0f, 1.0f, new MouseClickOptions() { Button = MouseButton.Right });
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnContextMenu() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_CONTEXT_MENU);

        await Page.Mouse.ClickAsync(1.0f, 1.0f, new MouseClickOptions() { Button = MouseButton.Right });
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnMouseDown() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_MOUSE_DOWN);

        await Page.Mouse.ClickAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnMouseUp() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_MOUSE_UP);

        await Page.Mouse.ClickAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnWheel() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_WHEEL);

        await Page.Mouse.WheelAsync(0.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("WheelEvent { DeltaX = 0, DeltaY = 1, DeltaZ = 0, DeltaMode = 0 }");
    }

    [Test]
    public async Task RegisterOnMouseMove() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_MOUSE_MOVE);

        await Page.Mouse.MoveAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnMouseOver() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_MOUSE_OVER);

        await Page.Mouse.MoveAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnMouseOut() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_MOUSE_OUT);

        await Page.Mouse.MoveAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnMouseEnter() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_MOUSE_ENTER);

        await Page.EvaluateAsync("""
            const event = new Event("mouseenter");
            event.button = 0;
            event.buttons = 0;
            event.movementX = 0;
            event.movementY = 1;
            event.clientX = 1;
            event.clientY = 1;
            event.offsetX = 0;
            event.offsetY = 0;
            event.pageX = 0;
            event.pageY = 0;
            event.screenX = 0;
            event.screenY = 0;
            event.ctrlKey = true;
            event.shiftKey = false;
            event.altKey = false;
            event.metaKey = false;
            window.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }

    [Test]
    public async Task RegisterOnMouseLeave() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_MOUSE_LEAVE);

        await Page.EvaluateAsync("""
            const event = new Event("mouseleave");
            event.button = 0;
            event.buttons = 0;
            event.movementX = 0;
            event.movementY = 1;
            event.clientX = 1;
            event.clientY = 1;
            event.offsetX = 0;
            event.offsetY = 0;
            event.pageX = 0;
            event.pageY = 0;
            event.screenX = 0;
            event.screenY = 0;
            event.ctrlKey = true;
            event.shiftKey = false;
            event.altKey = false;
            event.metaKey = false;
            window.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("MouseEvent");
    }


    [Test]
    public async Task RegisterOnTouchStart() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_TOUCH_START);

        await Page.Touchscreen.TapAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("TouchEvent");
    }

    [Test]
    public async Task RegisterOnTouchEnd() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_TOUCH_END);

        await Page.Touchscreen.TapAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("TouchEvent");
    }

    [Test]
    public async Task RegisterOnTouchMove() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_TOUCH_MOVE);

        await Page.EvaluateAsync("""
            const event = new Event("touchmove");
            event.touches = [];
            event.targetTouches = [];
            event.changedTouches = [];
            event.ctrlKey = false;
            event.shiftKey = false;
            event.altKey = false;
            event.metaKey = false;
            window.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("TouchEvent");
    }

    [Test]
    public async Task RegisterOnTouchCancel() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_TOUCH_CANCEL);

        await Page.EvaluateAsync("""
            const event = new Event("touchcancel");
            event.touches = [];
            event.targetTouches = [];
            event.changedTouches = [];
            event.ctrlKey = false;
            event.shiftKey = false;
            event.altKey = false;
            event.metaKey = false;
            window.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("TouchEvent");
    }


    [Test]
    public async Task RegisterOnPointerDown() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_POINTER_DOWN);

        await Page.Mouse.ClickAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerUp() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_POINTER_UP);

        await Page.Mouse.ClickAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerMove() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_POINTER_MOVE);

        await Page.Mouse.MoveAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerOver() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_POINTER_OVER);

        await Page.Mouse.MoveAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerOut() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_POINTER_OUT);

        await Page.Mouse.MoveAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerEnter() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_POINTER_ENTER);

        await Page.EvaluateAsync("""
            const event = new Event("pointerenter");
            event.pointerId = 0;
            event.persistentDeviceId = 0;
            event.pointerType = "";
            event.width = 1;
            event.height = 1;
            event.pressure = 1;
            event.tangentialPressure = 0;
            event.twist = 0;
            event.tiltX = 0;
            event.tiltY = 0;
            event.altitudeAngle = 0;
            event.azimuthAngle = 0;
            event.isPrimary = true;
            event.button = 0;
            event.buttons = 0;
            event.movementX = 0;
            event.movementY = 0;
            event.clientX = 0;
            event.clientY = 0;
            event.offsetX = 0;
            event.offsetY = 0;
            event.pageX = 0;
            event.pageY = 0;
            event.screenX = 0;
            event.screenY = 0;
            event.ctrlKey = false;
            event.shiftKey = false;
            event.altKey = false;
            event.metaKey = false;
            window.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerLeave() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_POINTER_LEAVE);

        await Page.EvaluateAsync("""
            const event = new Event("pointerleave");
            event.pointerId = 0;
            event.persistentDeviceId = 0;
            event.pointerType = "";
            event.width = 1;
            event.height = 1;
            event.pressure = 1;
            event.tangentialPressure = 0;
            event.twist = 0;
            event.tiltX = 0;
            event.tiltY = 0;
            event.altitudeAngle = 0;
            event.azimuthAngle = 0;
            event.isPrimary = true;
            event.button = 0;
            event.buttons = 0;
            event.movementX = 0;
            event.movementY = 0;
            event.clientX = 0;
            event.clientY = 0;
            event.offsetX = 0;
            event.offsetY = 0;
            event.pageX = 0;
            event.pageY = 0;
            event.screenX = 0;
            event.screenY = 0;
            event.ctrlKey = false;
            event.shiftKey = false;
            event.altKey = false;
            event.metaKey = false;
            window.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerCancel() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_POINTER_CANCEL);

        await Page.EvaluateAsync("""
            const event = new Event("pointercancel");
            event.pointerId = 0;
            event.persistentDeviceId = 0;
            event.pointerType = "";
            event.width = 1;
            event.height = 1;
            event.pressure = 1;
            event.tangentialPressure = 0;
            event.twist = 0;
            event.tiltX = 0;
            event.tiltY = 0;
            event.altitudeAngle = 0;
            event.azimuthAngle = 0;
            event.isPrimary = true;
            event.button = 0;
            event.buttons = 0;
            event.movementX = 0;
            event.movementY = 0;
            event.clientX = 0;
            event.clientY = 0;
            event.offsetX = 0;
            event.offsetY = 0;
            event.pageX = 0;
            event.pageY = 0;
            event.screenX = 0;
            event.screenY = 0;
            event.ctrlKey = false;
            event.shiftKey = false;
            event.altKey = false;
            event.metaKey = false;
            window.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnPointerRawUpdate() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_POINTER_RAW_UPDATE);

        await Page.Mouse.MoveAsync(1.0f, 1.0f);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnGotPointerCapture() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_GOT_POINTER_CAPTURE);

        await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).EvaluateAsync("node => node.addEventListener('pointerdown', event => node.setPointerCapture(event.pointerId));");
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).ClickAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }

    [Test]
    public async Task RegisterOnLostPointerCapture() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_LOST_POINTER_CAPTURE);

        await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).EvaluateAsync("""
            node => {
                node.addEventListener("pointerdown", event => node.setPointerCapture(event.pointerId));
                node.addEventListener("pointerup", event => node.releasePointerCapture(event.pointerId));
            }
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).ClickAsync();
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith("PointerEvent");
    }


    [Test]
    public async Task RegisterOnFocusIn() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_FOCUS_IN);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('focusin'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_FOCUS_IN);
    }

    [Test]
    public async Task RegisterOnFocusOut() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_FOCUS_OUT);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('focusout'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_FOCUS_OUT);
    }


    [Test]
    public async Task RegisterOnCopy() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_COPY);

        await Page.Keyboard.PressAsync("Control+c");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_COPY);
    }

    [Test]
    public async Task RegisterOnPaste() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_PASTE);

        await Page.Keyboard.PressAsync("Control+v");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_PASTE);
    }

    [Test]
    public async Task RegisterOnCut() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_CUT);

        await Page.Keyboard.PressAsync("Control+x");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_CUT);
    }


    [Test]
    public async Task RegisterOnTransitionStart() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_TRANSITION_START);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.classList.add("html-element");
            document.body.appendChild(tempElement);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(WindowGroup.TEST_EVENT_TRANSITION_START);
    }

    [Test]
    public async Task RegisterOnTransitionEnd() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_TRANSITION_END);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.classList.add("html-element");
            document.body.appendChild(tempElement);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(WindowGroup.TEST_EVENT_TRANSITION_END);
    }

    [Test]
    public async Task RegisterOnTransitionRun() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_TRANSITION_RUN);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.classList.add("html-element");
            document.body.appendChild(tempElement);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").EvaluateAsync("node => node.style.backgroundColor = '#000';");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(WindowGroup.TEST_EVENT_TRANSITION_RUN);
    }

    [Test]
    public async Task RegisterOnTransitionCancel() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_TRANSITION_CANCEL);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.classList.add("html-element");
            tempElement.classList.add("long-transition");
            document.body.appendChild(tempElement);
            """);
        await Task.Delay(SMALL_WAIT_TIME);

        // fluctuating test -> do multiple times with different timings
        string? result = null;
        for (int i = 0; i < 60; i++) {
            char colorNumber = (i % 10).ToString()[0];
            await Page.GetByTestId("temp").EvaluateAsync($"node => node.style.backgroundColor = '#{colorNumber}{colorNumber}{colorNumber}';");
            await Task.Delay(i * SMALL_WAIT_TIME);

            result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
            if (result is not (null or ""))
                break;
        }

        await Assert.That(result).StartsWith(WindowGroup.TEST_EVENT_TRANSITION_CANCEL);
    }


    [Test]
    public async Task RegisterOnAnimationStart() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_ANIMATION_START);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.classList.add("html-element");
            document.body.appendChild(tempElement);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").EvaluateAsync("node => node.classList.add('animation-start');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(WindowGroup.TEST_EVENT_ANIMATION_START);
    }

    [Test]
    public async Task RegisterOnAnimationnEnd() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_ANIMATION_END);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.classList.add("html-element");
            document.body.appendChild(tempElement);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").EvaluateAsync("node => node.classList.add('animation-start');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(WindowGroup.TEST_EVENT_ANIMATION_END);
    }

    [Test]
    public async Task RegisterOnAnimationIteration() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_ANIMATION_ITERATION);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.classList.add("html-element");
            document.body.appendChild(tempElement);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").EvaluateAsync("node => node.classList.add('animation-start-infinite');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(WindowGroup.TEST_EVENT_ANIMATION_ITERATION);
    }

    [Test]
    public async Task RegisterOnAnimationCancel() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_ANIMATION_CANCEL);

        await Page.EvaluateAsync("""
            const tempElement = document.createElement("div");
            tempElement.setAttribute("data-testid", "temp");
            tempElement.classList.add("html-element");
            document.body.appendChild(tempElement);
            """);
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").EvaluateAsync("node => node.classList.add('animation-start-infinite');");
        await Task.Delay(SMALL_WAIT_TIME);
        await Page.GetByTestId("temp").EvaluateAsync("node => node.classList.remove('animation-start-infinite');");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).StartsWith(WindowGroup.TEST_EVENT_ANIMATION_CANCEL);
    }


    // HTMLMediaElement - Ready

    [Test]
    public async Task RegisterOnCanPlay() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_CAN_PLAY);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('canplay'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_CAN_PLAY);
    }

    [Test]
    public async Task RegisterOnCanPlayThrough() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_CAN_PLAY_THROUGH);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('canplaythrough'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_CAN_PLAY_THROUGH);
    }

    [Test]
    public async Task RegisterOnPlaying() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_PLAYING);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('playing'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_PLAYING);
    }

    // HTMLMediaElement - Data

    [Test]
    public async Task RegisterOnLoadStart() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_LOAD_START);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('loadstart'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_LOAD_START);
    }

    [Test]
    public async Task RegisterOnProgress() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_PROGRESS);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('progress'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_PROGRESS);
    }

    [Test]
    public async Task RegisterOnLoadedData() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_LOADED_DATA);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('loadeddata'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_LOADED_DATA);
    }

    [Test]
    public async Task RegisterOnLoadedMetadata() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_LOADED_METADATA);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('loadedmetadata'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_LOADED_METADATA);
    }

    [Test]
    public async Task RegisterOnStalled() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_STALLED);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('stalled'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_STALLED);
    }

    [Test]
    public async Task RegisterOnSuspend() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_SUSPEND);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('suspend'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_SUSPEND);
    }

    [Test]
    public async Task RegisterOnWaiting() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_WAITING);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('waiting'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_WAITING);
    }

    [Test]
    public async Task RegisterOnAbort() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_ABORT);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('abort'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_ABORT);
    }

    [Test]
    public async Task RegisterOnEmptied() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_EMPTIED);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('emptied'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_EMPTIED);
    }

    // HTMLMediaElement - Timing

    [Test]
    public async Task RegisterOnPlay() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_PLAY);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('play'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_PLAY);
    }

    [Test]
    public async Task RegisterOnPause() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_PAUSE);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('pause'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_PAUSE);
    }

    [Test]
    public async Task RegisterOnEnded() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_ENDED);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('ended'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_ENDED);
    }

    [Test]
    public async Task RegisterOnSeeking() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_SEEKING);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('seeking'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_SEEKING);
    }

    [Test]
    public async Task RegisterOnSeeked() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_SEEKED);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('seeked'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_SEEKED);
    }

    [Test]
    public async Task RegisterOnTimeUpdate() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_TIME_UPDATE);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('timeupdate'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_TIME_UPDATE);
    }

    // HTMLMediaElement - Setting

    [Test]
    public async Task RegisterOnVolumeChange() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_VOLUME_CHANGE);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('volumechange'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_VOLUME_CHANGE);
    }

    [Test]
    public async Task RegisterOnRateChange() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_RATE_CHANGE);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('ratechange'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_RATE_CHANGE);
    }

    [Test]
    public async Task RegisterOnDurationChange() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_DURATION_CHANGE);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('durationchange'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_DURATION_CHANGE);
    }


    // HTMLDialogElement

    [Test]
    public async Task RegisterOnClose() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_CLOSE);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('close'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_CLOSE);
    }

    [Test]
    public async Task RegisterOnCancel() {
        await ExecuteTest(WindowGroup.BUTTON_REGISTER_ON_CANCEL);

        await Page.EvaluateAsync("window.dispatchEvent(new Event('cancel'));");
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(WindowGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(WindowGroup.TEST_EVENT_CANCEL);
    }
}
