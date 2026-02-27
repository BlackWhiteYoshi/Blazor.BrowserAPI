using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace BrowserAPI.Test.Client;

public sealed partial class WindowGroup : ComponentBase {
    public const string TEST_NAME = "somw window name";
    // methods
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
    // events
    public const string TEST_EVENT_LANGUAGE_CHANGE = "language changed test";
    public const string TEST_EVENT_RESIZE = "resize test";
    public const string TEST_EVENT_FOCUS = "focus test";
    public const string TEST_EVENT_BLUR = "blur test";
    public const string TEST_EVENT_LOAD = "load test";
    public const string TEST_EVENT_BEFORE_UNLOAD = "before unload test";
    public const string TEST_EVENT_APP_INSTALLED = "app installed test";
    public const string TEST_EVENT_BEFORE_INSTALL_PROMPT = "before install prompt test";
    public const string TEST_EVENT_AFTER_PRINT = "after print test";
    public const string TEST_EVENT_BEFORE_PRINT = "before print test";
    // events - HTMLElement
    public const string TEST_EVENT_SCROLL = "scroll event";
    public const string TEST_EVENT_SCROLL_END = "scroll end event";
    public const string TEST_EVENT_CHANGE = "change event";
    // events - Element
    public const string TEST_EVENT_BEFORE_MATCH = "before-match-event-test";
    public const string TEST_EVENT_SCROLL_START = "scroll-start-event-test";
    public const string TEST_EVENT_FOCUS_IN = "focus-in-event-test";
    public const string TEST_EVENT_FOCUS_OUT = "focus-out-event-test";
    public const string TEST_EVENT_COPY = "copy-event-test";
    public const string TEST_EVENT_PASTE = "paste-event-test";
    public const string TEST_EVENT_CUT = "cut-event-test";
    public const string TEST_EVENT_TRANSITION_START = "transition-start-event-test";
    public const string TEST_EVENT_TRANSITION_END = "transition-end-event-test";
    public const string TEST_EVENT_TRANSITION_RUN = "transition-run-event-test";
    public const string TEST_EVENT_TRANSITION_CANCEL = "transition-cancel-event-test";
    public const string TEST_EVENT_ANIMATION_START = "animation-start-event-test";
    public const string TEST_EVENT_ANIMATION_END = "animation-end-event-test";
    public const string TEST_EVENT_ANIMATION_ITERATION = "animation-iteration-event-test";
    public const string TEST_EVENT_ANIMATION_CANCEL = "animation-cancel-event-test";
    // events - HTMLMediaElement
    public const string TEST_EVENT_CAN_PLAY = "CanPlay event";
    public const string TEST_EVENT_CAN_PLAY_THROUGH = "CanPlayThrough event";
    public const string TEST_EVENT_PLAYING = "Playing event";
    public const string TEST_EVENT_LOAD_START = "LoadStart event";
    public const string TEST_EVENT_PROGRESS = "Progress event";
    public const string TEST_EVENT_LOADED_DATA = "LoadedData event";
    public const string TEST_EVENT_LOADED_METADATA = "LoadedMetadata event";
    public const string TEST_EVENT_STALLED = "stalled event";
    public const string TEST_EVENT_SUSPEND = "Suspend event";
    public const string TEST_EVENT_WAITING = "Waiting event";
    public const string TEST_EVENT_ABORT = "Abort event";
    public const string TEST_EVENT_EMPTIED = "Emptied event";
    public const string TEST_EVENT_PLAY = "Play event";
    public const string TEST_EVENT_PAUSE = "Pause event";
    public const string TEST_EVENT_ENDED = "Ended event";
    public const string TEST_EVENT_SEEKING = "Seeking event";
    public const string TEST_EVENT_SEEKED = "Seeked event";
    public const string TEST_EVENT_TIME_UPDATE = "TimeUpdate event";
    public const string TEST_EVENT_VOLUME_CHANGE = "VolumeChange event";
    public const string TEST_EVENT_RATE_CHANGE = "RateChange event";
    public const string TEST_EVENT_DURATION_CHANGE = "DurationChange event";
    // events - HTMLDialogElement
    public const string TEST_EVENT_CLOSE = "close-event-test";
    public const string TEST_EVENT_CANCEL = "cancel-event-test";


    [Inject]
    public required IWindow Window { private get; init; }


    public const string OUTPUT = "window-output";
    private string output = string.Empty;


    // Properties

    public const string BUTTON_GET_INNER_WIDTH_PROPERTY = "window-get-inner-width-property";
    private async Task GetInnerWidth_Property() {
        int innerWidth = await Window.InnerWidth;
        output = innerWidth.ToString();
    }

    public const string BUTTON_GET_INNER_WIDTH_METHOD = "window-get-inner-width-method";
    private async Task GetInnerWidth_Method() {
        int innerWidth = await Window.GetInnerWidth(CancellationToken.None);
        output = innerWidth.ToString();
    }

    public const string BUTTON_GET_INNER_HEIGHT_PROPERTY = "window-get-inner-height-property";
    private async Task GetInnerHeight_Property() {
        int innerHeight = await Window.InnerHeight;
        output = innerHeight.ToString();
    }

    public const string BUTTON_GET_INNER_HEIGHT_METHOD = "window-get-inner-height-method";
    private async Task GetInnerHeight_Method() {
        int innerHeight = await Window.GetInnerHeight(CancellationToken.None);
        output = innerHeight.ToString();
    }

    public const string BUTTON_GET_OUTER_WIDTH_PROPERTY = "window-get-outer-width-property";
    private async Task GetOuterWidth_Property() {
        int outerWidth = await Window.OuterWidth;
        output = outerWidth.ToString();
    }

    public const string BUTTON_GET_OUTER_WIDTH_METHOD = "window-get-outer-width-method";
    private async Task GetOuterWidth_Method() {
        int outerWidth = await Window.GetOuterWidth(CancellationToken.None);
        output = outerWidth.ToString();
    }

    public const string BUTTON_GET_OUTER_HEIGHT_PROPERTY = "window-get-outer-height-property";
    private async Task GetOuterHeight_Property() {
        int outerHeight = await Window.OuterHeight;
        output = outerHeight.ToString();
    }

    public const string BUTTON_GET_OUTER_HEIGHT_METHOD = "window-get-outer-height-method";
    private async Task GetOuterHeight_Method() {
        int outerHeight = await Window.GetOuterHeight(CancellationToken.None);
        output = outerHeight.ToString();
    }

    public const string BUTTON_GET_DEVICE_PIXEL_RATIO_PROPERTY = "window-get-device-pixel-ratio-property";
    private async Task GetDevicePixelRatio_Property() {
        double devicePixelRatio = await Window.DevicePixelRatio;
        output = devicePixelRatio.ToString();
    }

    public const string BUTTON_GET_DEVICE_PIXEL_RATIO_METHOD = "window-get-device-pixel-ratio-method";
    private async Task GetDevicePixelRatio_Method() {
        double devicePixelRatio = await Window.GetDevicePixelRatio(CancellationToken.None);
        output = devicePixelRatio.ToString();
    }


    public const string BUTTON_GET_SCROLL_X_PROPERTY = "window-get-scroll-x-property";
    private async Task GetScrollX_Property() {
        double scrollX = await Window.ScrollX;
        output = scrollX.ToString();
    }

    public const string BUTTON_GET_SCROLL_X_METHOD = "window-get-scroll-x-method";
    private async Task GetScrollX_Method() {
        double scrollX = await Window.GetScrollX(CancellationToken.None);
        output = scrollX.ToString();
    }

    public const string BUTTON_GET_SCROLL_Y_PROPERTY = "window-get-scroll-y-property";
    private async Task GetScrollY_Property() {
        double scrollY = await Window.ScrollY;
        output = scrollY.ToString();
    }

    public const string BUTTON_GET_SCROLL_Y_METHOD = "window-get-scroll-y-method";
    private async Task GetScrollY_Method() {
        double scrollY = await Window.GetScrollY(CancellationToken.None);
        output = scrollY.ToString();
    }

    public const string BUTTON_GET_SCREEN_X_PROPERTY = "window-get-screen-x-property";
    private async Task GetScreenX_Property() {
        int screenX = await Window.ScreenX;
        output = screenX.ToString();
    }

    public const string BUTTON_GET_SCREEN_X_METHOD = "window-get-screen-x-method";
    private async Task GetScreenX_Method() {
        int screenX = await Window.GetScreenX(CancellationToken.None);
        output = screenX.ToString();
    }

    public const string BUTTON_GET_SCREEN_Y_PROPERTY = "window-get-screen-y-property";
    private async Task GetScreenY_Property() {
        int screenY = await Window.ScreenY;
        output = screenY.ToString();
    }

    public const string BUTTON_GET_SCREEN_Y_METHOD = "window-get-screen-y-method";
    private async Task GetScreenY_Method() {
        int screenY = await Window.GetScreenY(CancellationToken.None);
        output = screenY.ToString();
    }


    public const string BUTTON_GET_ORIGIN_PROPERTY = "window-get-origin-property";
    private async Task GetOrigin_Property() {
        string origin = await Window.Origin;
        output = origin;
    }

    public const string BUTTON_GET_ORIGIN_METHOD = "window-get-origin-method";
    private async Task GetOrigin_Method() {
        string origin = await Window.GetOrigin(CancellationToken.None);
        output = origin;
    }

    public const string BUTTON_GET_NAME_PROPERTY = "window-get-name-property";
    private async Task GetName_Property() {
        string name = await Window.Name;
        output = name;
    }

    public const string BUTTON_GET_NAME_METHOD = "window-get-name-method";
    private async Task GetName_Method() {
        string name = await Window.GetName(CancellationToken.None);
        output = name;
    }

    public const string BUTTON_SET_NAME = "window-set-name";
    private async Task SetName() {
        await Window.SetName(TEST_NAME);
    }


    public const string BUTTON_GET_CLOSED_PROPERTY = "window-get-closed-property";
    private async Task GetClosed_Property() {
        bool closed = await Window.Closed;
        output = closed.ToString();
    }

    public const string BUTTON_GET_CLOSED_METHOD = "window-get-closed-method";
    private async Task GetClosed_Method() {
        bool closed = await Window.GetClosed(CancellationToken.None);
        output = closed.ToString();
    }

    public const string BUTTON_GET_CREDENTIALLESS_PROPERTY = "window-get-credentialless-property";
    private async Task GetCredentialless_Property() {
        bool credentialless = await Window.Credentialless;
        output = credentialless.ToString();
    }

    public const string BUTTON_GET_CREDENTIALLESS_METHOD = "window-get-credentialless-method";
    private async Task GetCredentialless_Method() {
        bool credentialless = await Window.GetCredentialless(CancellationToken.None);
        output = credentialless.ToString();
    }

    public const string BUTTON_GET_CROSS_ORIGIN_ISOLATED_PROPERTY = "window-get-cross-origin-isolated-property";
    private async Task GetCrossOriginIsolated_Property() {
        bool crossOriginIsolated = await Window.CrossOriginIsolated;
        output = crossOriginIsolated.ToString();
    }

    public const string BUTTON_GET_CROSS_ORIGIN_ISOLATED_METHOD = "window-get-cross-origin-isolated-method";
    private async Task GetCrossOriginIsolated_Method() {
        bool crossOriginIsolated = await Window.GetCrossOriginIsolated(CancellationToken.None);
        output = crossOriginIsolated.ToString();
    }

    public const string BUTTON_GET_IS_SECURE_CONTEXT_PROPERTY = "window-get-is-secure-context-property";
    private async Task GetIsSecureContext_Property() {
        bool isSecureContext = await Window.IsSecureContext;
        output = isSecureContext.ToString();
    }

    public const string BUTTON_GET_IS_SECURE_CONTEXT_METHOD = "window-get-is-secure-context-method";
    private async Task GetIsSecureContext_Method() {
        bool isSecureContext = await Window.GetIsSecureContext(CancellationToken.None);
        output = isSecureContext.ToString();
    }

    public const string BUTTON_GET_ORIGIN_AGENT_CLUSTER_PROPERTY = "window-get-origin-agent-cluster-property";
    private async Task GetOriginAgentCluster_Property() {
        bool originAgentCluster = await Window.OriginAgentCluster;
        output = originAgentCluster.ToString();
    }

    public const string BUTTON_GET_ORIGIN_AGENT_CLUSTER_METHOD = "window-get-origin-agent-cluster-method";
    private async Task GetOriginAgentCluster_Method() {
        bool originAgentCluster = await Window.GetOriginAgentCluster(CancellationToken.None);
        output = originAgentCluster.ToString();
    }

    public const string BUTTON_GET_MENUBAR_PROPERTY = "window-get-menubar-property";
    private async Task GetMenubar_Property() {
        bool menubar = await Window.Menubar;
        output = menubar.ToString();
    }

    public const string BUTTON_GET_MENUBAR_METHOD = "window-get-menubar-method";
    private async Task GetMenubar_Method() {
        bool menubar = await Window.GetMenubar(CancellationToken.None);
        output = menubar.ToString();
    }


    public const string BUTTON_GET_FRAME_ELEMENT_PROPERTY = "window-get-frame-element-property";
    private async Task GetFrameElement_Property() {
        await using IHTMLElement? frameElement = await Window.FrameElement;
        output = (frameElement is not null).ToString();
    }

    public const string BUTTON_GET_FRAME_ELEMENT_METHOD = "window-get-frame-element-method";
    private async Task GetFrameElement_Method() {
        await using IHTMLElement? frameElement = await Window.GetFrameElement(CancellationToken.None);
        output = (frameElement is not null).ToString();
    }


    // Methods

    public const string BUTTON_OPEN = "window-open";
    private async Task Open() {
        IWindow? window = await Window.Open();
        output = (window is not null).ToString();
    }

    public const string BUTTON_CLOSE = "window-close";
    private async Task Close() {
        await Window.Close();
    }

    public const string BUTTON_STOP = "window-stop";
    private async Task Stop() {
        await Window.Stop();
        output = TEST_STOP;
    }

    public const string BUTTON_FOCUS = "window-focus";
    private async Task Focus() {
        await Window.Focus();
        output = TEST_FOCUS;
    }

    public const string BUTTON_PRINT = "window-print";
    private async Task Print() {
        await Window.Print();
        output = TEST_PRINT;
    }

    public const string BUTTON_REPORT_ERROR = "window-report-error";
    private async Task ReportError() {
        await Window.ReportError(TEST_REPORT_ERROR);
        output = TEST_REPORT_ERROR;
    }

    public const string BUTTON_PROMPT = "window-prompt";
    private async Task Prompt() {
        string? result = await Window.Prompt("P message", "answer");
        output = result ?? TEST_PROMPT_RESULT;
    }

    public const string BUTTON_CONFIRM = "window-confirm";
    private async Task Confirm() {
        bool result = await Window.Confirm("C message");
        output = result.ToString();
    }

    public const string BUTTON_ALERT = "window-alert";
    private async Task Alert() {
        await Window.Alert("A message");
        output = TEST_ALERT;
    }


    public const string BUTTON_MOVE_BY = "window-move-by";
    private async Task MoveBy() {
        await Window.MoveBy(10, 10);
        output = TEST_MOVE_BY;
    }

    public const string BUTTON_MOVE_TO = "window-move-to";
    private async Task MoveTo() {
        await Window.MoveTo(10, 10);
        output = TEST_MOVE_TO;
    }

    public const string BUTTON_RESIZE_BY = "window-resize-by";
    private async Task ResizeBy() {
        await Window.ResizeBy(10, 10);
        output = TEST_RESIZE_BY;
    }

    public const string BUTTON_RESIZE_TO = "window-resize-to";
    private async Task ResizeTo() {
        await Window.ResizeTo(10, 10);
        output = TEST_RESIZE_TO;
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
            output = TEST_SET_TIMEOUT;
            StateHasChanged();
        }, 100);
    }

    public const string BUTTON_CLEAR_TIMEOUT = "window-clear-timeout";
    private async Task ClearTimeout() {
        output = TEST_CLEAR_TIMEOUT;
        TimeoutHandle timeoutHandle = await Window.SetTimeout(() => {
            output = TEST_SET_TIMEOUT;
            StateHasChanged();
        }, 100);
        await Window.ClearTimeout(timeoutHandle);
    }

    public const string BUTTON_SET_INTERVAL = "window-set-interval";
    private async Task SetInterval() {
        await Window.SetInterval(() => {
            output = TEST_SET_INTERVAL;
            StateHasChanged();
        }, 100);
    }

    public const string BUTTON_CLEAR_INTERVAL = "window-clear-interval";
    private async Task ClearInterval() {
        output = TEST_CLEAR_INTERVAL;
        IntervalHandle intervalHandle = await Window.SetInterval(() => {
            output = TEST_SET_INTERVAL;
            StateHasChanged();
        }, 100);
        await Window.ClearInterval(intervalHandle);
    }

    public const string BUTTON_REQUEST_ANIMATION_FRAME = "window-request-animation-frame";
    private async Task RequestAnimationFrame() {
        await Window.RequestAnimationFrame((double timestamp) => {
            output = TEST_REQUEST_ANIMATION_FRAME;
            StateHasChanged();
        });
    }

    public const string BUTTON_CANCEL_ANIMATION_FRAME = "window-cancel-animation-frame";
    private async Task CancelAnimationFrame() {
        output = TEST_CANCEL_ANIMATION_FRAME;
        AnimationFrameHandle animationFrameHandle = await Window.RequestAnimationFrame((double timestamp) => {
            output = TEST_REQUEST_ANIMATION_FRAME;
            StateHasChanged();
        });
        await Window.CancelAnimationFrame(animationFrameHandle);
    }

    public const string BUTTON_REQUEST_IDLE_CALLBACK = "window-request-idle-callback";
    private async Task RequestIdleCallback() {
        await Window.RequestIdleCallback(() => {
            output = TEST_REQUEST_IDLE_CALLBACK;
            StateHasChanged();
        });
    }

    public const string BUTTON_CANCEL_IDLE_CALLBACK = "window-cancel-idle-callback";
    private async Task CancelIdleCallback() {
        IdleCallbackHandle idleCallbackHandle = await Window.RequestIdleCallback(() => {
            output = TEST_REQUEST_IDLE_CALLBACK;
            StateHasChanged();
        });
        await Window.CancelIdleCallback(idleCallbackHandle);
        output = TEST_CANCEL_IDLE_CALLBACK; // test is actually not really correct, but more consistent
    }

    public const string BUTTON_QUEUE_MICROTASK = "window-queue-microtask";
    private async Task QueueMicrotask() {
        await Window.QueueMicrotask(() => {
            output = TEST_QUEUE_MICROTASK;
            StateHasChanged();
        });
    }


    public const string BUTTON_ATOB = "window-atob";
    private async Task Atob() {
        string base64 = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(TEST_BASE64));
        string text = await Window.Atob(base64);
        output = text;
    }

    public const string BUTTON_BTOA = "window-btoa";
    private async Task Btoa() {
        string base64 = await Window.Btoa(TEST_BASE64);
        output = base64;
    }

    public const string BUTTON_POST_MESSAGE = "window-post-message";
    private async Task PostMessage() {
        await Window.PostMessage(TEST_POST_MESSAGE, "*");
    }

    public const string BUTTON_STRUCTURED_CLONE = "window-structured-clone";
    private async Task StructuredClone() {
        string clonedMessage = await Window.StructuredClone(TEST_STRUCTURED_CLONE);
        output = clonedMessage;
    }


    // Events

    public const string BUTTON_REGISTER_ON_ERROR = "window-error-event";
    private void RegisterOnError() {
        Window.OnError += (JsonElement error) => {
            output = error.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LANGUAGE_CHANGE = "window-language-change-event";
    private void RegisterOnLanguageChange() {
        Window.OnLanguageChange += () => {
            output = TEST_EVENT_LANGUAGE_CHANGE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_RESIZE = "window-resize-event";
    private void RegisterOnResize() {
        Window.OnResize += () => {
            output = TEST_EVENT_RESIZE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_STORAGE = "window-storage-event";
    private void RegisterOnStorage() {
        Window.OnStorage += (StorageEvent storageEvent) => {
            output = storageEvent.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_FOCUS = "window-focus-event";
    private void RegisterOnFocus() {
        Window.OnFocus += () => {
            output = TEST_EVENT_FOCUS;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BLUR = "window-blur-event";
    private void RegisterOnBlur() {
        Window.OnBlur += () => {
            output = TEST_EVENT_BLUR;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOAD = "window-load-event";
    private void RegisterOnLoad() {
        Window.OnLoad += () => {
            output = TEST_EVENT_LOAD;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BEFORE_UNLOAD = "window-before-unload-event";
    private void RegisterOnBeforeUnload() {
        Window.OnBeforeUnload += () => {
            output = TEST_EVENT_BEFORE_UNLOAD;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_APP_INSTALLED = "window-app-installed-event";
    private void RegisterOnAppInstalled() {
        Window.OnAppInstalled += () => {
            output = TEST_EVENT_APP_INSTALLED;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BEFORE_INSTALL_PROMPT = "window-before-install-prompt-event";
    private void RegisterOnBeforeInstallPrompt() {
        Window.OnBeforeInstallPrompt += () => {
            output = TEST_EVENT_BEFORE_INSTALL_PROMPT;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MESSAGE = "window-message-event";
    private void RegisterOnMessage() {
        Window.OnMessage += (JsonElement data, string origin, string lastEventId) => {
            output = $"data = {data}, origin = {origin}, lastEventId = {lastEventId}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MESSAGE_ERROR = "window-message-error-event";
    private void RegisterOnMessageError() {
        Window.OnMessageError += (JsonElement data, string origin, string lastEventId) => {
            output = $"data = {data}, origin = {origin}, lastEventId = {lastEventId}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_AFTER_PRINT = "window-after-print-event";
    private void RegisterOnAfterPrint() {
        Window.OnAfterPrint += () => {
            output = TEST_EVENT_AFTER_PRINT;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BEFORE_PRINT = "window-before-print-event";
    private void RegisterOnBeforePrint() {
        Window.OnBeforePrint += () => {
            output = TEST_EVENT_BEFORE_PRINT;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_REJECTION_HANDLED = "window-rejection-handled-event";
    private void RegisterOnRejectionHandled() {
        Window.OnRejectionHandled += (JsonElement? reason) => {
            output = reason switch {
                JsonElement => reason.ToString() switch {
                    string str => str,
                    _ => "(text representation of reason is null)"
                },
                _ => "(no reason)"
            };
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_UNHANDLED_REJECTION = "window-unhandled-rejection-event";
    private void RegisterOnUnhandledRejection() {
        Window.OnUnhandledRejection += (JsonElement? reason) => {
            output = reason switch {
                JsonElement => reason.ToString() switch {
                    string str => str,
                    _ => "(text representation of reason is null)"
                },
                _ => "(no reason)"
            };
            StateHasChanged();
        };
    }


    // events - HTMLElement

    public const string BUTTON_REGISTER_ON_SCROLL = "window-scroll-event";
    private void RegisterOnScroll() {
        Window.OnScroll += () => {
            output = TEST_EVENT_SCROLL;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SCROLL_END = "window-scroll-end-event";
    private void RegisterOnScrollEnd() {
        Window.OnScrollEnd += () => {
            output = TEST_EVENT_SCROLL_END;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CHANGE = "window-change-event";
    private void RegisterOnChange() {
        Window.OnChange += () => {
            output = TEST_EVENT_CHANGE;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_DRAG = "window-drag-event";
    private void RegisterOnDrag() {
        Window.OnDrag += (DragEvent dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                output = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                await dragEvent.Files.DisposeAsync();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DRAG_START = "window-drag-start-event";
    private void RegisterOnDragStart() {
        Window.OnDragStart += (DragEvent dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                output = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                await dragEvent.Files.DisposeAsync();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DRAG_END = "window-drag-end-event";
    private void RegisterOnDragEnd() {
        Window.OnDragEnd += (DragEvent dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                output = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                await dragEvent.Files.DisposeAsync();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DRAG_ENTER = "window-drag-enter-event";
    private void RegisterOnDragEnter() {
        Window.OnDragEnter += (DragEvent dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                output = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                await dragEvent.Files.DisposeAsync();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DRAG_LEAVE = "window-drag-leave-event";
    private void RegisterOnDragLeave() {
        Window.OnDragLeave += (DragEvent dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                output = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                await dragEvent.Files.DisposeAsync();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DRAG_OVER = "window-drag-over-event";
    private void RegisterOnDragOver() {
        Window.OnDragOver += (DragEvent dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                output = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                await dragEvent.Files.DisposeAsync();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DROP = "window-drop-event";
    private void RegisterOnDrop() {
        Window.OnDrop += (DragEvent dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                output = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                await dragEvent.Files.DisposeAsync();
            }
        };
    }


    public const string BUTTON_REGISTER_ON_TOGGLE = "window-toggle-event";
    private void RegisterOnToggle() {
        Window.OnToggle += (string oldState, string newState) => {
            output = $"oldState='{oldState}', newState='{newState}'";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BEFORE_TOGGLE = "window-before-toggle-event";
    private void RegisterOnBeforeToggle() {
        Window.OnBeforeToggle += (string oldState, string newState) => {
            output = $"oldState='{oldState}', newState='{newState}'";
            StateHasChanged();
        };
    }


    // events - Element

    public const string BUTTON_REGISTER_ON_INPUT = "window-input-event";
    private void RegisterOnInput() {
        Window.OnInput += (string? data, string? inputType, bool isComposing) => {
            output = $"data={data ?? "(null)"}, inputType={inputType ?? "(null)"}, isComposing={isComposing}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BEFORE_INPUT = "window-before-input-event";
    private void RegisterOnBeforeInput() {
        Window.OnBeforeInput += (string? data, string? inputType, bool isComposing) => {
            output = $"data={data ?? "(null)"}, inputType={inputType ?? "(null)"}, isComposing={isComposing}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BEFORE_MATCH = "window-before-match-event";
    private void RegisterOnBeforeMatch() {
        Window.OnBeforeMatch += () => {
            output = TEST_EVENT_BEFORE_MATCH;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_KEY_DOWN = "window-key-down-event";
    private void RegisterOnKeyDown() {
        Window.OnKeyDown += (KeyboardEvent keyboardEvent) => {
            output = keyboardEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_KEY_UP = "window-key-up-event";
    private void RegisterOnKeyUp() {
        Window.OnKeyUp += (KeyboardEvent keyboardEvent) => {
            output = keyboardEvent.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_CLICK = "window-click-event";
    private void RegisterOnClick() {
        Window.OnClick += (MouseEvent mouseEvent) => {
            output = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_DBL_CLICK = "window-dbl-click-event";
    private void RegisterOnDblClick() {
        Window.OnDblClick += (MouseEvent mouseEvent) => {
            output = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_AUX_CLICK = "window-aux-click-event";
    private void RegisterOnAuxClick() {
        Window.OnAuxClick += (MouseEvent mouseEvent) => {
            output = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CONTEXT_MENU = "window-context-menu-event";
    private void RegisterOnContextMenu() {
        Window.OnContextMenu += (MouseEvent mouseEvent) => {
            output = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_DOWN = "window-mouse-down-event";
    private void RegisterOnMouseDown() {
        Window.OnMouseDown += (MouseEvent mouseEvent) => {
            output = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_UP = "window-mouse-up-event";
    private void RegisterOnMouseUp() {
        Window.OnMouseUp += (MouseEvent mouseEvent) => {
            output = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_WHEEL = "window-wheel-event";
    private void RegisterOnWheel() {
        Window.OnWheel += (WheelEvent wheelEvent) => {
            output = wheelEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_MOVE = "window-mouse-move-event";
    private void RegisterOnMouseMove() {
        Window.OnMouseMove += (MouseEvent mouseEvent) => {
            output = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_OVER = "window-mouse-over-event";
    private void RegisterOnMouseOver() {
        Window.OnMouseOver += (MouseEvent mouseEvent) => {
            output = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_OUT = "window-mouse-out-event";
    private void RegisterOnMouseOut() {
        Window.OnMouseOut += (MouseEvent mouseEvent) => {
            output = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_ENTER = "window-mouse-enter-event";
    private void RegisterOnMouseEnter() {
        Window.OnMouseEnter += (MouseEvent mouseEvent) => {
            output = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_LEAVE = "window-mouse-leave-event";
    private void RegisterOnMouseLeave() {
        Window.OnMouseLeave += (MouseEvent mouseEvent) => {
            output = mouseEvent.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_TOUCH_START = "window-touch-start-event";
    private void RegisterOnTouchStart() {
        Window.OnTouchStart += (TouchEvent touchEvent) => {
            output = touchEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TOUCH_END = "window-touch-end-event";
    private void RegisterOnTouchEnd() {
        Window.OnTouchEnd += (TouchEvent touchEvent) => {
            output = touchEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TOUCH_MOVE = "window-touch-move-event";
    private void RegisterOnTouchMove() {
        Window.OnTouchMove += (TouchEvent touchEvent) => {
            output = touchEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TOUCH_CANCEL = "window-touch-cancel-event";
    private void RegisterOnTouchCancel() {
        Window.OnTouchCancel += (TouchEvent touchEvent) => {
            output = touchEvent.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_POINTER_DOWN = "window-pointer-down-event";
    private void RegisterOnPointerDown() {
        Window.OnPointerDown += (PointerEvent pointerEvent) => {
            output = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_UP = "window-pointer-up-event";
    private void RegisterOnPointerUp() {
        Window.OnPointerUp += (PointerEvent pointerEvent) => {
            output = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_MOVE = "window-pointer-move-event";
    private void RegisterOnPointerMove() {
        Window.OnPointerMove += (PointerEvent pointerEvent) => {
            output = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_OVER = "window-pointer-over-event";
    private void RegisterOnPointerOver() {
        Window.OnPointerOver += (PointerEvent pointerEvent) => {
            output = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_OUT = "window-pointer-out-event";
    private void RegisterOnPointerOut() {
        Window.OnPointerOut += (PointerEvent pointerEvent) => {
            output = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_ENTER = "window-pointer-enter-event";
    private void RegisterOnPointerEnter() {
        Window.OnPointerEnter += (PointerEvent pointerEvent) => {
            output = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_LEAVE = "window-pointer-leave-event";
    private void RegisterOnPointerLeave() {
        Window.OnPointerLeave += (PointerEvent pointerEvent) => {
            output = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_CANCEL = "window-pointer-cancel-event";
    private void RegisterOnPointerCancel() {
        Window.OnPointerCancel += (PointerEvent pointerEvent) => {
            output = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_RAW_UPDATE = "window-pointer-raw-update-event";
    private void RegisterOnPointerRawUpdate() {
        Window.OnPointerRawUpdate += (PointerEvent pointerEvent) => {
            output = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_GOT_POINTER_CAPTURE = "window-got-pointer-capture-event";
    private void RegisterOnGotPointerCapture() {
        Window.OnGotPointerCapture += (PointerEvent pointerEvent) => {
            output = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOST_POINTER_CAPTURE = "window-lost-pointer-capture-event";
    private void RegisterOnLostPointerCapture() {
        Window.OnLostPointerCapture += (PointerEvent pointerEvent) => {
            output = pointerEvent.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_FOCUS_IN = "window-focus-in-event";
    private void RegisterOnFocusIn() {
        Window.OnFocusIn += () => {
            output = TEST_EVENT_FOCUS_IN;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_FOCUS_OUT = "window-focus-out-event";
    private void RegisterOnFocusOut() {
        Window.OnFocusOut += () => {
            output = TEST_EVENT_FOCUS_OUT;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_COPY = "window-copy-event";
    private void RegisterOnCopy() {
        Window.OnCopy += () => {
            output = TEST_EVENT_COPY;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PASTE = "window-paste-event";
    private void RegisterOnPaste() {
        Window.OnPaste += () => {
            output = TEST_EVENT_PASTE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CUT = "window-cut-event";
    private void RegisterOnCut() {
        Window.OnCut += () => {
            output = TEST_EVENT_CUT;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_TRANSITION_START = "window-transition-start-event";
    private void RegisterOnTransitionStart() {
        Window.OnTransitionStart += (string propertyName, double elapsedTime, string pseudoElement) => {
            output = $"{TEST_EVENT_TRANSITION_START}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITION_END = "window-transition-end-event";
    private void RegisterOnTransitionEnd() {
        Window.OnTransitionEnd += (string propertyName, double elapsedTime, string pseudoElement) => {
            output = $"{TEST_EVENT_TRANSITION_END}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITION_RUN = "window-transition-run-event";
    private void RegisterOnTransitionRun() {
        Window.OnTransitionRun += (string propertyName, double elapsedTime, string pseudoElement) => {
            output = $"{TEST_EVENT_TRANSITION_RUN}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITION_CANCEL = "window-transition-cancel-event";
    private void RegisterOnTransitionCancel() {
        Window.OnTransitionCancel += (string propertyName, double elapsedTime, string pseudoElement) => {
            output = $"{TEST_EVENT_TRANSITION_CANCEL}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_ANIMATION_START = "window-animation-start-event";
    private void RegisterOnAnimationStart() {
        Window.OnAnimationStart += (string animationName, double elapsedTime, string pseudoElement) => {
            output = $"{TEST_EVENT_ANIMATION_START}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATION_END = "window-animation-end-event";
    private void RegisterOnAnimationEnd() {
        Window.OnAnimationEnd += (string animationName, double elapsedTime, string pseudoElement) => {
            output = $"{TEST_EVENT_ANIMATION_END}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATION_ITERATION = "window-animation-iteration-event";
    private void RegisterOnAnimationIteration() {
        Window.OnAnimationIteration += (string animationName, double elapsedTime, string pseudoElement) => {
            output = $"{TEST_EVENT_ANIMATION_ITERATION}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATION_CANCEL = "window-animation-cancel-event";
    private void RegisterOnAnimationCancel() {
        Window.OnAnimationCancel += (string animationName, double elapsedTime, string pseudoElement) => {
            output = $"{TEST_EVENT_ANIMATION_CANCEL}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }


    // events - HTMLMediaElement Ready

    public const string BUTTON_REGISTER_ON_CAN_PLAY = "window-can-play-event";
    private void RegisterOnCanPlay() {
        Window.OnCanPlay += () => {
            output = TEST_EVENT_CAN_PLAY;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CAN_PLAY_THROUGH = "window-can-play-through-event";
    private void RegisterOnCanPlayThrough() {
        Window.OnCanPlayThrough += () => {
            output = TEST_EVENT_CAN_PLAY_THROUGH;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PLAYING = "window-playing-event";
    private void RegisterOnPlaying() {
        Window.OnPlaying += () => {
            output = TEST_EVENT_PLAYING;
            StateHasChanged();
        };
    }

    // events - HTMLMediaElement Data

    public const string BUTTON_REGISTER_ON_LOAD_START = "window-load-start-event";
    private void RegisterOnLoadStart() {
        Window.OnLoadStart += () => {
            output = TEST_EVENT_LOAD_START;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PROGRESS = "window-progress-event";
    private void RegisterOnProgress() {
        Window.OnProgress += () => {
            output = TEST_EVENT_PROGRESS;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOADED_DATA = "window-loaded-data-event";
    private void RegisterOnLoadedData() {
        Window.OnLoadedData += () => {
            output = TEST_EVENT_LOADED_DATA;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOADED_METADATA = "window-loaded-metadata-event";
    private void RegisterOnLoadedMetadata() {
        Window.OnLoadedMetadata += () => {
            output = TEST_EVENT_LOADED_METADATA;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_STALLED = "window-stalled-event";
    private void RegisterOnStalled() {
        Window.OnStalled += () => {
            output = TEST_EVENT_STALLED;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SUSPEND = "window-suspend-event";
    private void RegisterOnSuspend() {
        Window.OnSuspend += () => {
            output = TEST_EVENT_SUSPEND;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_WAITING = "window-waiting-event";
    private void RegisterOnWaiting() {
        Window.OnWaiting += () => {
            output = TEST_EVENT_WAITING;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ABORT = "window-abort-event";
    private void RegisterOnAbort() {
        Window.OnAbort += () => {
            output = TEST_EVENT_ABORT;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_EMPTIED = "window-emptied-event";
    private void RegisterOnEmptied() {
        Window.OnEmptied += () => {
            output = TEST_EVENT_EMPTIED;
            StateHasChanged();
        };
    }

    // events - HTMLMediaElement Timing

    public const string BUTTON_REGISTER_ON_PLAY = "window-play-event";
    private void RegisterOnPlay() {
        Window.OnPlay += () => {
            output = TEST_EVENT_PLAY;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PAUSE = "window-pause-event";
    private void RegisterOnPause() {
        Window.OnPause += () => {
            output = TEST_EVENT_PAUSE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ENDED = "window-ended-event";
    private void RegisterOnEnded() {
        Window.OnEnded += () => {
            output = TEST_EVENT_ENDED;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SEEKING = "window-seeking-event";
    private void RegisterOnSeeking() {
        Window.OnSeeking += () => {
            output = TEST_EVENT_SEEKING;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SEEKED = "window-seeked-event";
    private void RegisterOnSeeked() {
        Window.OnSeeked += () => {
            output = TEST_EVENT_SEEKED;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TIME_UPDATE = "window-time-update-event";
    private void RegisterOnTimeUpdate() {
        Window.OnTimeUpdate += () => {
            output = TEST_EVENT_TIME_UPDATE;
            StateHasChanged();
        };
    }

    // events - HTMLMediaElement Setting

    public const string BUTTON_REGISTER_ON_VOLUME_CHANGE = "window-volume-change-event";
    private void RegisterOnVolumeChange() {
        Window.OnVolumeChange += () => {
            output = TEST_EVENT_VOLUME_CHANGE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_RATE_CHANGE = "window-rate-change-event";
    private void RegisterOnRateChange() {
        Window.OnRateChange += () => {
            output = TEST_EVENT_RATE_CHANGE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_DURATION_CHANGE = "window-duration-change-event";
    private void RegisterOnDurationChange() {
        Window.OnDurationChange += () => {
            output = TEST_EVENT_DURATION_CHANGE;
            StateHasChanged();
        };
    }


    // events - HTMLDialogElement

    public const string BUTTON_REGISTER_ON_CLOSE = "window-close-event";
    private void RegisterOnClose() {
        Window.OnClose += () => {
            output = TEST_EVENT_CLOSE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CANCEL = "window-cancel-event";
    private void RegisterOnCancel() {
        Window.OnCancel += () => {
            output = TEST_EVENT_CANCEL;
            StateHasChanged();
        };
    }
}
