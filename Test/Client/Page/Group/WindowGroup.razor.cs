using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class WindowGroup : ComponentBase {
    public const string TEST_NAME = "somw window name";
    public const string TEST_STOP = "stop test";
    public const string TEST_FOCUS = "focus test";
    public const string TEST_PRINT = "print test";
    public const string TEST_REPORT_ERROR = "error test";
    public const string TEST_PROMPT_RESULT = "prompt canceled";
    public const string TEST_ALERT = "alert test";
    public const string TEST_MOVE_BY = "move by test";
    public const string TEST_MOVE_TO = "move to test";
    public const string TEST_RESIZE_BY = "resize by test";
    public const string TEST_RESIZE_TO = "resize to test";
    public const string TEST_SET_TIMEOUT = "set timeout test";
    public const string TEST_CLEAR_TIMEOUT = "clear timeout test";
    public const string TEST_SET_INTERVAL = "set interval test";
    public const string TEST_CLEAR_INTERVAL = "clear interval test";
    public const string TEST_REQUEST_ANIMATION_FRAME = "request animation frame test";
    public const string TEST_CANCEL_ANIMATION_FRAME = "cancel animation frame test";
    public const string TEST_REQUEST_IDLE_CALLBACK = "request idle callback test";
    public const string TEST_CANCEL_IDLE_CALLBACK = "cancel idle callback test";
    public const string TEST_QUEUE_MICROTASK = "queue microtask test";
    public const string TEST_BASE64 = "base64 test";
    public const string TEST_POST_MESSAGE = "window message test";
    public const string TEST_STRUCTURED_CLONE = "cloned message";


    [Inject]
    public required IWindow Window { private get; init; }


    public const string LABEL_OUTPUT = "window-output";
    private string labelOutput = string.Empty;


    // Properties

    public const string BUTTON_GET_INNER_WIDTH_PROPERTY = "window-get-inner-width-property";
    private async Task GetInnerWidth_Property() {
        int innerWidth = await Window.InnerWidth;
        labelOutput = innerWidth.ToString();
    }

    public const string BUTTON_GET_INNER_WIDTH_METHOD = "window-get-inner-width-method";
    private async Task GetInnerWidth_Method() {
        int innerWidth = await Window.GetInnerWidth(default);
        labelOutput = innerWidth.ToString();
    }

    public const string BUTTON_GET_INNER_HEIGHT_PROPERTY = "window-get-inner-height-property";
    private async Task GetInnerHeight_Property() {
        int innerHeight = await Window.InnerHeight;
        labelOutput = innerHeight.ToString();
    }

    public const string BUTTON_GET_INNER_HEIGHT_METHOD = "window-get-inner-height-method";
    private async Task GetInnerHeight_Method() {
        int innerHeight = await Window.GetInnerHeight(default);
        labelOutput = innerHeight.ToString();
    }

    public const string BUTTON_GET_OUTER_WIDTH_PROPERTY = "window-get-outer-width-property";
    private async Task GetOuterWidth_Property() {
        int outerWidth = await Window.OuterWidth;
        labelOutput = outerWidth.ToString();
    }

    public const string BUTTON_GET_OUTER_WIDTH_METHOD = "window-get-outer-width-method";
    private async Task GetOuterWidth_Method() {
        int outerWidth = await Window.GetOuterWidth(default);
        labelOutput = outerWidth.ToString();
    }

    public const string BUTTON_GET_OUTER_HEIGHT_PROPERTY = "window-get-outer-height-property";
    private async Task GetOuterHeight_Property() {
        int outerHeight = await Window.OuterHeight;
        labelOutput = outerHeight.ToString();
    }

    public const string BUTTON_GET_OUTER_HEIGHT_METHOD = "window-get-outer-height-method";
    private async Task GetOuterHeight_Method() {
        int outerHeight = await Window.GetOuterHeight(default);
        labelOutput = outerHeight.ToString();
    }

    public const string BUTTON_GET_DEVICE_PIXEL_RATIO_PROPERTY = "window-get-device-pixel-ratio-property";
    private async Task GetDevicePixelRatio_Property() {
        double devicePixelRatio = await Window.DevicePixelRatio;
        labelOutput = devicePixelRatio.ToString();
    }

    public const string BUTTON_GET_DEVICE_PIXEL_RATIO_METHOD = "window-get-device-pixel-ratio-method";
    private async Task GetDevicePixelRatio_Method() {
        double devicePixelRatio = await Window.GetDevicePixelRatio(default);
        labelOutput = devicePixelRatio.ToString();
    }


    public const string BUTTON_GET_SCROLL_X_PROPERTY = "window-get-scroll-x-property";
    private async Task GetScrollX_Property() {
        double scrollX = await Window.ScrollX;
        labelOutput = scrollX.ToString();
    }

    public const string BUTTON_GET_SCROLL_X_METHOD = "window-get-scroll-x-method";
    private async Task GetScrollX_Method() {
        double scrollX = await Window.GetScrollX(default);
        labelOutput = scrollX.ToString();
    }

    public const string BUTTON_GET_SCROLL_Y_PROPERTY = "window-get-scroll-y-property";
    private async Task GetScrollY_Property() {
        double scrollY = await Window.ScrollY;
        labelOutput = scrollY.ToString();
    }

    public const string BUTTON_GET_SCROLL_Y_METHOD = "window-get-scroll-y-method";
    private async Task GetScrollY_Method() {
        double scrollY = await Window.GetScrollY(default);
        labelOutput = scrollY.ToString();
    }

    public const string BUTTON_GET_SCREEN_X_PROPERTY = "window-get-screen-x-property";
    private async Task GetScreenX_Property() {
        int screenX = await Window.ScreenX;
        labelOutput = screenX.ToString();
    }

    public const string BUTTON_GET_SCREEN_X_METHOD = "window-get-screen-x-method";
    private async Task GetScreenX_Method() {
        int screenX = await Window.GetScreenX(default);
        labelOutput = screenX.ToString();
    }

    public const string BUTTON_GET_SCREEN_Y_PROPERTY = "window-get-screen-y-property";
    private async Task GetScreenY_Property() {
        int screenY = await Window.ScreenY;
        labelOutput = screenY.ToString();
    }

    public const string BUTTON_GET_SCREEN_Y_METHOD = "window-get-screen-y-method";
    private async Task GetScreenY_Method() {
        int screenY = await Window.GetScreenY(default);
        labelOutput = screenY.ToString();
    }


    public const string BUTTON_GET_ORIGIN_PROPERTY = "window-get-origin-property";
    private async Task GetOrigin_Property() {
        string origin = await Window.Origin;
        labelOutput = origin;
    }

    public const string BUTTON_GET_ORIGIN_METHOD = "window-get-origin-method";
    private async Task GetOrigin_Method() {
        string origin = await Window.GetOrigin(default);
        labelOutput = origin;
    }

    public const string BUTTON_GET_NAME_PROPERTY = "window-get-name-property";
    private async Task GetName_Property() {
        string name = await Window.Name;
        labelOutput = name;
    }

    public const string BUTTON_GET_NAME_METHOD = "window-get-name-method";
    private async Task GetName_Method() {
        string name = await Window.GetName(default);
        labelOutput = name;
    }

    public const string BUTTON_SET_NAME = "window-set-name";
    private async Task SetName() {
        await Window.SetName(TEST_NAME);
    }


    public const string BUTTON_GET_CLOSED_PROPERTY = "window-get-closed-property";
    private async Task GetClosed_Property() {
        bool closed = await Window.Closed;
        labelOutput = closed.ToString();
    }

    public const string BUTTON_GET_CLOSED_METHOD = "window-get-closed-method";
    private async Task GetClosed_Method() {
        bool closed = await Window.GetClosed(default);
        labelOutput = closed.ToString();
    }

    public const string BUTTON_GET_CREDENTIALLESS_PROPERTY = "window-get-credentialless-property";
    private async Task GetCredentialless_Property() {
        bool credentialless = await Window.Credentialless;
        labelOutput = credentialless.ToString();
    }

    public const string BUTTON_GET_CREDENTIALLESS_METHOD = "window-get-credentialless-method";
    private async Task GetCredentialless_Method() {
        bool credentialless = await Window.GetCredentialless(default);
        labelOutput = credentialless.ToString();
    }

    public const string BUTTON_GET_CROSS_ORIGIN_ISOLATED_PROPERTY = "window-get-cross-origin-isolated-property";
    private async Task GetCrossOriginIsolated_Property() {
        bool crossOriginIsolated = await Window.CrossOriginIsolated;
        labelOutput = crossOriginIsolated.ToString();
    }

    public const string BUTTON_GET_CROSS_ORIGIN_ISOLATED_METHOD = "window-get-cross-origin-isolated-method";
    private async Task GetCrossOriginIsolated_Method() {
        bool crossOriginIsolated = await Window.GetCrossOriginIsolated(default);
        labelOutput = crossOriginIsolated.ToString();
    }

    public const string BUTTON_GET_IS_SECURE_CONTEXT_PROPERTY = "window-get-is-secure-context-property";
    private async Task GetIsSecureContext_Property() {
        bool isSecureContext = await Window.IsSecureContext;
        labelOutput = isSecureContext.ToString();
    }

    public const string BUTTON_GET_IS_SECURE_CONTEXT_METHOD = "window-get-is-secure-context-method";
    private async Task GetIsSecureContext_Method() {
        bool isSecureContext = await Window.GetIsSecureContext(default);
        labelOutput = isSecureContext.ToString();
    }

    public const string BUTTON_GET_ORIGIN_AGENT_CLUSTER_PROPERTY = "window-get-origin-agent-cluster-property";
    private async Task GetOriginAgentCluster_Property() {
        bool originAgentCluster = await Window.OriginAgentCluster;
        labelOutput = originAgentCluster.ToString();
    }

    public const string BUTTON_GET_ORIGIN_AGENT_CLUSTER_METHOD = "window-get-origin-agent-cluster-method";
    private async Task GetOriginAgentCluster_Method() {
        bool originAgentCluster = await Window.GetOriginAgentCluster(default);
        labelOutput = originAgentCluster.ToString();
    }

    public const string BUTTON_GET_MENUBAR_PROPERTY = "window-get-menubar-property";
    private async Task GetMenubar_Property() {
        bool menubar = await Window.Menubar;
        labelOutput = menubar.ToString();
    }

    public const string BUTTON_GET_MENUBAR_METHOD = "window-get-menubar-method";
    private async Task GetMenubar_Method() {
        bool menubar = await Window.GetMenubar(default);
        labelOutput = menubar.ToString();
    }


    public const string BUTTON_GET_FRAME_ELEMENT_PROPERTY = "window-get-frame-element-property";
    private async Task GetFrameElement_Property() {
        await using IHTMLElement? frameElement = await Window.FrameElement;
        labelOutput = (frameElement is not null).ToString();
    }

    public const string BUTTON_GET_FRAME_ELEMENT_METHOD = "window-get-frame-element-method";
    private async Task GetFrameElement_Method() {
        await using IHTMLElement? frameElement = await Window.GetFrameElement(default);
        labelOutput = (frameElement is not null).ToString();
    }


    // Methods

    public const string BUTTON_OPEN = "window-open";
    private async Task Open() {
        IWindow? window = await Window.Open();
        labelOutput = (window is not null).ToString();
    }

    public const string BUTTON_CLOSE = "window-close";
    private async Task Close() {
        await Window.Close();
    }

    public const string BUTTON_STOP = "window-stop";
    private async Task Stop() {
        await Window.Stop();
        labelOutput = TEST_STOP;
    }

    public const string BUTTON_FOCUS = "window-focus";
    private async Task Focus() {
        await Window.Focus();
        labelOutput = TEST_FOCUS;
    }

    public const string BUTTON_PRINT = "window-print";
    private async Task Print() {
        await Window.Print();
        labelOutput = TEST_PRINT;
    }

    public const string BUTTON_REPORT_ERROR = "window-report-error";
    private async Task ReportError() {
        await Window.ReportError(TEST_REPORT_ERROR);
        labelOutput = TEST_REPORT_ERROR;
    }

    public const string BUTTON_PROMPT = "window-prompt";
    private async Task Prompt() {
        string? result = await Window.Prompt("P message", "answer");
        labelOutput = result ?? TEST_PROMPT_RESULT;
    }

    public const string BUTTON_CONFIRM = "window-confirm";
    private async Task Confirm() {
        bool result = await Window.Confirm("C message");
        labelOutput = result.ToString();
    }

    public const string BUTTON_ALERT = "window-alert";
    private async Task Alert() {
        await Window.Alert("A message");
        labelOutput = TEST_ALERT;
    }


    public const string BUTTON_MOVE_BY = "window-move-by";
    private async Task MoveBy() {
        await Window.MoveBy(10, 10);
        labelOutput = TEST_MOVE_BY;
    }

    public const string BUTTON_MOVE_TO = "window-move-to";
    private async Task MoveTo() {
        await Window.MoveTo(10, 10);
        labelOutput = TEST_MOVE_TO;
    }

    public const string BUTTON_RESIZE_BY = "window-resize-by";
    private async Task ResizeBy() {
        await Window.ResizeBy(10, 10);
        labelOutput = TEST_RESIZE_BY;
    }

    public const string BUTTON_RESIZE_TO = "window-resize-to";
    private async Task ResizeTo() {
        await Window.ResizeTo(10, 10);
        labelOutput = TEST_RESIZE_TO;
    }

    public const string BUTTON_SCROLL = "window-scroll";
    private async Task Scroll() {
        await Window.Scroll(0, 10, "instant");
    }

    public const string BUTTON_SCROLL_TO = "window-scroll-to";
    private async Task ScrollTo() {
        await Window.ScrollTo(0, 10, "instant");
    }

    public const string BUTTON_SCROLL_BY = "window-scroll-by";
    private async Task ScrollBy() {
        await Window.ScrollBy(0, 10, "instant");
    }


    public const string BUTTON_SET_TIMEOUT = "window-set-timeout";
    private async Task SetTimeout() {
        await Window.SetTimeout(() => {
            labelOutput = TEST_SET_TIMEOUT;
            StateHasChanged();
        }, 100);
    }

    public const string BUTTON_CLEAR_TIMEOUT = "window-clear-timeout";
    private async Task ClearTimeout() {
        labelOutput = TEST_CLEAR_TIMEOUT;
        TimeoutHandle timeoutHandle = await Window.SetTimeout(() => {
            labelOutput = TEST_SET_TIMEOUT;
            StateHasChanged();
        }, 100);
        await Window.ClearTimeout(timeoutHandle);
    }

    public const string BUTTON_SET_INTERVAL = "window-set-interval";
    private async Task SetInterval() {
        await Window.SetInterval(() => {
            labelOutput = TEST_SET_INTERVAL;
            StateHasChanged();
        }, 100);
    }

    public const string BUTTON_CLEAR_INTERVAL = "window-clear-interval";
    private async Task ClearInterval() {
        labelOutput = TEST_CLEAR_INTERVAL;
        IntervalHandle intervalHandle = await Window.SetInterval(() => {
            labelOutput = TEST_SET_INTERVAL;
            StateHasChanged();
        }, 100);
        await Window.ClearInterval(intervalHandle);
    }

    public const string BUTTON_REQUEST_ANIMATION_FRAME = "window-request-animation-frame";
    private async Task RequestAnimationFrame() {
        await Window.RequestAnimationFrame((double timestamp) => {
            labelOutput = TEST_REQUEST_ANIMATION_FRAME;
            StateHasChanged();
        });
    }

    public const string BUTTON_CANCEL_ANIMATION_FRAME = "window-cancel-animation-frame";
    private async Task CancelAnimationFrame() {
        labelOutput = TEST_CANCEL_ANIMATION_FRAME;
        AnimationFrameHandle animationFrameHandle = await Window.RequestAnimationFrame((double timestamp) => {
            labelOutput = TEST_REQUEST_ANIMATION_FRAME;
            StateHasChanged();
        });
        await Window.CancelAnimationFrame(animationFrameHandle);
    }

    public const string BUTTON_REQUEST_IDLE_CALLBACK = "window-request-idle-callback";
    private async Task RequestIdleCallback() {
        await Window.RequestIdleCallback(() => {
            labelOutput = TEST_REQUEST_IDLE_CALLBACK;
            StateHasChanged();
        });
    }

    public const string BUTTON_CANCEL_IDLE_CALLBACK = "window-cancel-idle-callback";
    private async Task CancelIdleCallback() {
        IdleCallbackHandle idleCallbackHandle = await Window.RequestIdleCallback(() => {
            labelOutput = TEST_REQUEST_IDLE_CALLBACK;
            StateHasChanged();
        });
        await Window.CancelIdleCallback(idleCallbackHandle);
        labelOutput = TEST_CANCEL_IDLE_CALLBACK; // test is actually not really correct, but more consistent
    }

    public const string BUTTON_QUEUE_MICROTASK = "window-queue-microtask";
    private async Task QueueMicrotask() {
        await Window.QueueMicrotask(() => {
            labelOutput = TEST_QUEUE_MICROTASK;
            StateHasChanged();
        });
    }


    public const string BUTTON_ATOB = "window-atob";
    private async Task Atob() {
        string base64 = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(TEST_BASE64));
        string text = await Window.Atob(base64);
        labelOutput = text;
    }

    public const string BUTTON_BTOA = "window-btoa";
    private async Task Btoa() {
        string base64 = await Window.Btoa(TEST_BASE64);
        labelOutput = base64;
    }

    public const string BUTTON_POST_MESSAGE = "window-post-message";
    private async Task PostMessage() {
        await Window.PostMessage(TEST_POST_MESSAGE, "*");
    }

    public const string BUTTON_STRUCTURED_CLONE = "window-structured-clone";
    private async Task StructuredClone() {
        string clonedMessage = await Window.StructuredClone(TEST_STRUCTURED_CLONE);
        labelOutput = clonedMessage;
    }
}
