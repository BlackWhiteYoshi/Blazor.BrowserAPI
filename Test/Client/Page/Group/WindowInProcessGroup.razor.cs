using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class WindowInProcessGroup : ComponentBase {
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
    public required IWindowInProcess Window { private get; init; }


    public const string LABEL_OUTPUT = "window-inprocess-output";
    private string labelOutput = string.Empty;


    // Properties

    public const string BUTTON_GET_INNER_WIDTH = "window-inprocess-get-inner-width";
    private void GetInnerWidth() {
        int innerWidth = Window.InnerWidth;
        labelOutput = innerWidth.ToString();
    }

    public const string BUTTON_GET_INNER_HEIGHT = "window-inprocess-get-inner-height";
    private void GetInnerHeight() {
        int innerHeight = Window.InnerHeight;
        labelOutput = innerHeight.ToString();
    }

    public const string BUTTON_GET_OUTER_WIDTH = "window-inprocess-get-outer-width";
    private void GetOuterWidth() {
        int outerWidth = Window.OuterWidth;
        labelOutput = outerWidth.ToString();
    }

    public const string BUTTON_GET_OUTER_HEIGHT = "window-inprocess-get-outer-height";
    private void GetOuterHeight() {
        int outerHeight = Window.OuterHeight;
        labelOutput = outerHeight.ToString();
    }

    public const string BUTTON_GET_DEVICE_PIXEL_RATIO = "window-inprocess-get-device-pixel-ratio";
    private void GetDevicePixelRatio() {
        double devicePixelRatio = Window.DevicePixelRatio;
        labelOutput = devicePixelRatio.ToString();
    }


    public const string BUTTON_GET_SCROLL_X = "window-inprocess-get-scroll-x";
    private void GetScrollX() {
        double scrollX = Window.ScrollX;
        labelOutput = scrollX.ToString();
    }

    public const string BUTTON_GET_SCROLL_Y = "window-inprocess-get-scroll-y";
    private void GetScrollY() {
        double scrollY = Window.ScrollY;
        labelOutput = scrollY.ToString();
    }

    public const string BUTTON_GET_SCREEN_X = "window-inprocess-get-screen-x";
    private void GetScreenX() {
        int screenX = Window.ScreenX;
        labelOutput = screenX.ToString();
    }

    public const string BUTTON_GET_SCREEN_Y = "window-inprocess-get-screen-y";
    private void GetScreenY() {
        int screenY = Window.ScreenY;
        labelOutput = screenY.ToString();
    }


    public const string BUTTON_GET_ORIGIN = "window-inprocess-get-origin";
    private void GetOrigin() {
        string origin = Window.Origin;
        labelOutput = origin;
    }

    public const string BUTTON_GET_NAME = "window-inprocess-get-name";
    private void GetName() {
        string name = Window.Name;
        labelOutput = name;
    }

    public const string BUTTON_SET_NAME = "window-inprocess-set-name";
    private void SetName() {
        Window.Name = TEST_NAME;
    }


    public const string BUTTON_GET_CLOSED = "window-inprocess-get-closed";
    private void GetClosed() {
        bool closed = Window.Closed;
        labelOutput = closed.ToString();
    }

    public const string BUTTON_GET_CREDENTIALLESS = "window-inprocess-get-credentialless";
    private void GetCredentialless() {
        bool credentialless = Window.Credentialless;
        labelOutput = credentialless.ToString();
    }

    public const string BUTTON_GET_CROSS_ORIGIN_ISOLATED = "window-inprocess-get-cross-origin-isolated";
    private void GetCrossOriginIsolated() {
        bool crossOriginIsolated = Window.CrossOriginIsolated;
        labelOutput = crossOriginIsolated.ToString();
    }

    public const string BUTTON_GET_IS_SECURE_CONTEXT = "window-inprocess-get-is-secure-context";
    private void GetIsSecureContext() {
        bool isSecureContext = Window.IsSecureContext;
        labelOutput = isSecureContext.ToString();
    }

    public const string BUTTON_GET_ORIGIN_AGENT_CLUSTER = "window-inprocess-get-origin-agent-cluster";
    private void GetOriginAgentCluster() {
        bool originAgentCluster = Window.OriginAgentCluster;
        labelOutput = originAgentCluster.ToString();
    }

    public const string BUTTON_GET_MENUBAR = "window-inprocess-get-menubar";
    private void GetMenubar() {
        bool menubar = Window.Menubar;
        labelOutput = menubar.ToString();
    }


    public const string BUTTON_GET_FRAME_ELEMENT = "window-inprocess-get-frame-element";
    private void GetFrameElement() {
        using IHTMLElementInProcess? frameElement = Window.FrameElement;
        labelOutput = (frameElement is not null).ToString();
    }


    // Methods

    public const string BUTTON_OPEN = "window-inprocess-open";
    private void Open() {
        IWindowInProcess? window = Window.Open();
        labelOutput = (window is not null).ToString();
    }

    public const string BUTTON_CLOSE = "window-inprocess-close";
    private void Close() {
        Window.Close();
    }

    public const string BUTTON_STOP = "window-inprocess-stop";
    private void Stop() {
        Window.Stop();
        labelOutput = TEST_STOP;
    }

    public const string BUTTON_FOCUS = "window-inprocess-focus";
    private void Focus() {
        Window.Focus();
        labelOutput = TEST_FOCUS;
    }

    public const string BUTTON_PRINT = "window-inprocess-print";
    private void Print() {
        Window.Print();
        labelOutput = TEST_PRINT;
    }

    public const string BUTTON_REPORT_ERROR = "window-inprocess-report-error";
    private void ReportError() {
        Window.ReportError(TEST_REPORT_ERROR);
        labelOutput = TEST_REPORT_ERROR;
    }

    public const string BUTTON_PROMPT = "window-inprocess-prompt";
    private void Prompt() {
        string? result = Window.Prompt("P message", "answer");
        labelOutput = result ?? TEST_PROMPT_RESULT;
    }

    public const string BUTTON_CONFIRM = "window-inprocess-confirm";
    private void Confirm() {
        bool result = Window.Confirm("C message");
        labelOutput = result.ToString();
    }

    public const string BUTTON_ALERT = "window-inprocess-alert";
    private void Alert() {
        Window.Alert("A message");
        labelOutput = TEST_ALERT;
    }


    public const string BUTTON_MOVE_BY = "window-inprocess-move-by";
    private void MoveBy() {
        Window.MoveBy(10, 10);
        labelOutput = TEST_MOVE_BY;
    }

    public const string BUTTON_MOVE_TO = "window-inprocess-move-to";
    private void MoveTo() {
        Window.MoveTo(10, 10);
        labelOutput = TEST_MOVE_TO;
    }

    public const string BUTTON_RESIZE_BY = "window-inprocess-resize-by";
    private void ResizeBy() {
        Window.ResizeBy(10, 10);
        labelOutput = TEST_RESIZE_BY;
    }

    public const string BUTTON_RESIZE_TO = "window-inprocess-resize-to";
    private void ResizeTo() {
        Window.ResizeTo(10, 10);
        labelOutput = TEST_RESIZE_TO;
    }

    public const string BUTTON_SCROLL = "window-inprocess-scroll";
    private void Scroll() {
        Window.Scroll(0, 10, "instant");
    }

    public const string BUTTON_SCROLL_TO = "window-inprocess-scroll-to";
    private void ScrollTo() {
        Window.ScrollTo(0, 10, "instant");
    }

    public const string BUTTON_SCROLL_BY = "window-inprocess-scroll-by";
    private void ScrollBy() {
        Window.ScrollBy(0, 10, "instant");
    }


    public const string BUTTON_SET_TIMEOUT = "window-inprocess-set-timeout";
    private void SetTimeout() {
        Window.SetTimeout(() => {
            labelOutput = TEST_SET_TIMEOUT;
            StateHasChanged();
        }, 100);
    }

    public const string BUTTON_CLEAR_TIMEOUT = "window-inprocess-clear-timeout";
    private void ClearTimeout() {
        labelOutput = TEST_CLEAR_TIMEOUT;
        TimeoutHandle timeoutHandle = Window.SetTimeout(() => {
            labelOutput = TEST_SET_TIMEOUT;
            StateHasChanged();
        }, 100);
        Window.ClearTimeout(timeoutHandle);
    }

    public const string BUTTON_SET_INTERVAL = "window-inprocess-set-interval";
    private void SetInterval() {
        Window.SetInterval(() => {
            labelOutput = TEST_SET_INTERVAL;
            StateHasChanged();
        }, 100);
    }

    public const string BUTTON_CLEAR_INTERVAL = "window-inprocess-clear-interval";
    private void ClearInterval() {
        labelOutput = TEST_CLEAR_INTERVAL;
        IntervalHandle intervalHandle = Window.SetInterval(() => {
            labelOutput = TEST_SET_INTERVAL;
            StateHasChanged();
        }, 100);
        Window.ClearInterval(intervalHandle);
    }

    public const string BUTTON_REQUEST_ANIMATION_FRAME = "window-inprocess-request-animation-frame";
    private void RequestAnimationFrame() {
        Window.RequestAnimationFrame((double timestamp) => {
            labelOutput = TEST_REQUEST_ANIMATION_FRAME;
            StateHasChanged();
        });
    }

    public const string BUTTON_CANCEL_ANIMATION_FRAME = "window-inprocess-cancel-animation-frame";
    private void CancelAnimationFrame() {
        labelOutput = TEST_CANCEL_ANIMATION_FRAME;
        AnimationFrameHandle animationFrameHandle = Window.RequestAnimationFrame((double timestamp) => {
            labelOutput = TEST_REQUEST_ANIMATION_FRAME;
            StateHasChanged();
        });
        Window.CancelAnimationFrame(animationFrameHandle);
    }

    public const string BUTTON_REQUEST_IDLE_CALLBACK = "window-inprocess-request-idle-callback";
    private void RequestIdleCallback() {
        Window.RequestIdleCallback(() => {
            labelOutput = TEST_REQUEST_IDLE_CALLBACK;
            StateHasChanged();
        });
    }

    public const string BUTTON_CANCEL_IDLE_CALLBACK = "window-inprocess-cancel-idle-callback";
    private void CancelIdleCallback() {
        IdleCallbackHandle idleCallbackHandle = Window.RequestIdleCallback(() => {
            labelOutput = TEST_REQUEST_IDLE_CALLBACK;
            StateHasChanged();
        });
        Window.CancelIdleCallback(idleCallbackHandle);
        labelOutput = TEST_CANCEL_IDLE_CALLBACK; // test is actually not really correct, but more consistent
    }

    public const string BUTTON_QUEUE_MICROTASK = "window-inprocess-queue-microtask";
    private void QueueMicrotask() {
        Window.QueueMicrotask(() => {
            labelOutput = TEST_QUEUE_MICROTASK;
            StateHasChanged();
        });
    }


    public const string BUTTON_ATOB = "window-inprocess-atob";
    private void Atob() {
        string base64 = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(TEST_BASE64));
        string text = Window.Atob(base64);
        labelOutput = text;
    }

    public const string BUTTON_BTOA = "window-inprocess-btoa";
    private void Btoa() {
        string base64 = Window.Btoa(TEST_BASE64);
        labelOutput = base64;
    }

    public const string BUTTON_POST_MESSAGE = "window-inprocess-post-message";
    private void PostMessage() {
        Window.PostMessage(TEST_POST_MESSAGE, "*");
    }

    public const string BUTTON_STRUCTURED_CLONE = "window-inprocess-structured-clone";
    private void StructuredClone() {
        string clonedMessage = Window.StructuredClone(TEST_STRUCTURED_CLONE);
        labelOutput = clonedMessage;
    }
}
