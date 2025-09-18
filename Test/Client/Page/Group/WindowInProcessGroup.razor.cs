using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace BrowserAPI.Test.Client;

public sealed partial class WindowInProcessGroup : ComponentBase {
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


    // Events

    public const string BUTTON_REGISTER_ON_ERROR = "window-inprocess-error-event";
    private void RegisterOnError() {
        Window.OnError += (JsonElement error) => {
            labelOutput = error.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LANGUAGE_CHANGE = "window-inprocess-language-change-event";
    private void RegisterOnLanguageChange() {
        Window.OnLanguageChange += () => {
            labelOutput = TEST_EVENT_LANGUAGE_CHANGE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_RESIZE = "window-inprocess-resize-event";
    private void RegisterOnResize() {
        Window.OnResize += () => {
            labelOutput = TEST_EVENT_RESIZE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_STORAGE = "window-inprocess-storage-event";
    private void RegisterOnStorage() {
        Window.OnStorage += (StorageEvent storageEvent) => {
            labelOutput = storageEvent.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_FOCUS = "window-inprocess-focus-event";
    private void RegisterOnFocus() {
        Window.OnFocus += () => {
            labelOutput = TEST_EVENT_FOCUS;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BLUR = "window-inprocess-blur-event";
    private void RegisterOnBlur() {
        Window.OnBlur += () => {
            labelOutput = TEST_EVENT_BLUR;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOAD = "window-inprocess-load-event";
    private void RegisterOnLoad() {
        Window.OnLoad += () => {
            labelOutput = TEST_EVENT_LOAD;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BEFORE_UNLOAD = "window-inprocess-before-unload-event";
    private void RegisterOnBeforeUnload() {
        Window.OnBeforeUnload += () => {
            labelOutput = TEST_EVENT_BEFORE_UNLOAD;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_APP_INSTALLED = "window-inprocess-app-installed-event";
    private void RegisterOnAppInstalled() {
        Window.OnAppInstalled += () => {
            labelOutput = TEST_EVENT_APP_INSTALLED;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BEFORE_INSTALL_PROMPT = "window-inprocess-before-install-prompt-event";
    private void RegisterOnBeforeInstallPrompt() {
        Window.OnBeforeInstallPrompt += () => {
            labelOutput = TEST_EVENT_BEFORE_INSTALL_PROMPT;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MESSAGE = "window-inprocess-message-event";
    private void RegisterOnMessage() {
        Window.OnMessage += (JsonElement data, string origin, string lastEventId) => {
            labelOutput = $"data = {data}, origin = {origin}, lastEventId = {lastEventId}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MESSAGE_ERROR = "window-inprocess-message-error-event";
    private void RegisterOnMessageError() {
        Window.OnMessageError += (JsonElement data, string origin, string lastEventId) => {
            labelOutput = $"data = {data}, origin = {origin}, lastEventId = {lastEventId}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_AFTER_PRINT = "window-inprocess-after-print-event";
    private void RegisterOnAfterPrint() {
        Window.OnAfterPrint += () => {
            labelOutput = TEST_EVENT_AFTER_PRINT;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BEFORE_PRINT = "window-inprocess-before-print-event";
    private void RegisterOnBeforePrint() {
        Window.OnBeforePrint += () => {
            labelOutput = TEST_EVENT_BEFORE_PRINT;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_REJECTION_HANDLED = "window-inprocess-rejection-handled-event";
    private void RegisterOnRejectionHandled() {
        Window.OnRejectionHandled += (JsonElement? reason) => {
            labelOutput = reason switch {
                JsonElement => reason.ToString() switch {
                    string str => str,
                    _ => "(text representation of reason is null)"
                },
                _ => "(no reason)"
            };
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_UNHANDLED_REJECTION = "window-inprocess-unhandled-rejection-event";
    private void RegisterOnUnhandledRejection() {
        Window.OnUnhandledRejection += (JsonElement? reason) => {
            labelOutput = reason switch {
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

    public const string BUTTON_REGISTER_ON_SCROLL = "window-inprocess-scroll-event";
    private void RegisterOnScroll() {
        Window.OnScroll += () => {
            labelOutput = TEST_EVENT_SCROLL;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SCROLL_END = "window-inprocess-scroll-end-event";
    private void RegisterOnScrollEnd() {
        Window.OnScrollEnd += () => {
            labelOutput = TEST_EVENT_SCROLL_END;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CHANGE = "window-inprocess-change-event";
    private void RegisterOnChange() {
        Window.OnChange += () => {
            labelOutput = TEST_EVENT_CHANGE;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_DRAG = "window-inprocess-drag-event";
    private void RegisterOnDrag() {
        Window.OnDrag += (DragEventInProcess dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                dragEvent.Files.Dispose();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DRAG_START = "window-inprocess-drag-start-event";
    private void RegisterOnDragStart() {
        Window.OnDragStart += (DragEventInProcess dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                dragEvent.Files.Dispose();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DRAG_END = "window-inprocess-drag-end-event";
    private void RegisterOnDragEnd() {
        Window.OnDragEnd += (DragEventInProcess dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                dragEvent.Files.Dispose();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DRAG_ENTER = "window-inprocess-drag-enter-event";
    private void RegisterOnDragEnter() {
        Window.OnDragEnter += (DragEventInProcess dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                dragEvent.Files.Dispose();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DRAG_LEAVE = "window-inprocess-drag-leave-event";
    private void RegisterOnDragLeave() {
        Window.OnDragLeave += (DragEventInProcess dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                dragEvent.Files.Dispose();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DRAG_OVER = "window-inprocess-drag-over-event";
    private void RegisterOnDragOver() {
        Window.OnDragOver += (DragEventInProcess dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                dragEvent.Files.Dispose();
            }
        };
    }

    public const string BUTTON_REGISTER_ON_DROP = "window-inprocess-drop-event";
    private void RegisterOnDrop() {
        Window.OnDrop += (DragEventInProcess dragEvent) => {
            _ = DoAsync();
            async Task DoAsync() {
                string[] content = new string[dragEvent.Files.Length];
                for (int i = 0; i < content.Length; i++)
                    content[i] = await dragEvent.Files[i].Text();

                labelOutput = $"dropEffect='{dragEvent.DropEffect}', effectAllowed='{dragEvent.EffectAllowed}', types='[{string.Join(';', dragEvent.Types)}]', files='[{string.Join(';', content)}]'";
                StateHasChanged();
                dragEvent.Files.Dispose();
            }
        };
    }


    public const string BUTTON_REGISTER_ON_TOGGLE = "window-inprocess-toggle-event";
    private void RegisterOnToggle() {
        Window.OnToggle += (string oldState, string newState) => {
            labelOutput = $"oldState='{oldState}', newState='{newState}'";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BEFORE_TOGGLE = "window-inprocess-before-toggle-event";
    private void RegisterOnBeforeToggle() {
        Window.OnBeforeToggle += (string oldState, string newState) => {
            labelOutput = $"oldState='{oldState}', newState='{newState}'";
            StateHasChanged();
        };
    }


    // events - Element

    public const string BUTTON_REGISTER_ON_INPUT = "window-inprocess-input-event";
    private void RegisterOnInput() {
        Window.OnInput += (string? data, string? inputType, bool isComposing) => {
            labelOutput = $"data={data ?? "(null)"}, inputType={inputType ?? "(null)"}, isComposing={isComposing}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BEFORE_INPUT = "window-inprocess-before-input-event";
    private void RegisterOnBeforeInput() {
        Window.OnBeforeInput += (string? data, string? inputType, bool isComposing) => {
            labelOutput = $"data={data ?? "(null)"}, inputType={inputType ?? "(null)"}, isComposing={isComposing}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_BEFORE_MATCH = "window-inprocess-before-match-event";
    private void RegisterOnBeforeMatch() {
        Window.OnBeforeMatch += () => {
            labelOutput = TEST_EVENT_BEFORE_MATCH;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_KEY_DOWN = "window-inprocess-key-down-event";
    private void RegisterOnKeyDown() {
        Window.OnKeyDown += (KeyboardEvent keyboardEvent) => {
            labelOutput = keyboardEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_KEY_UP = "window-inprocess-key-up-event";
    private void RegisterOnKeyUp() {
        Window.OnKeyUp += (KeyboardEvent keyboardEvent) => {
            labelOutput = keyboardEvent.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_CLICK = "window-inprocess-click-event";
    private void RegisterOnClick() {
        Window.OnClick += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_DBL_CLICK = "window-inprocess-dbl-click-event";
    private void RegisterOnDblClick() {
        Window.OnDblClick += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_AUX_CLICK = "window-inprocess-aux-click-event";
    private void RegisterOnAuxClick() {
        Window.OnAuxClick += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CONTEXT_MENU = "window-inprocess-context-menu-event";
    private void RegisterOnContextMenu() {
        Window.OnContextMenu += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_DOWN = "window-inprocess-mouse-down-event";
    private void RegisterOnMouseDown() {
        Window.OnMouseDown += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_UP = "window-inprocess-mouse-up-event";
    private void RegisterOnMouseUp() {
        Window.OnMouseUp += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_WHEEL = "window-inprocess-wheel-event";
    private void RegisterOnWheel() {
        Window.OnWheel += (WheelEvent wheelEvent) => {
            labelOutput = wheelEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_MOVE = "window-inprocess-mouse-move-event";
    private void RegisterOnMouseMove() {
        Window.OnMouseMove += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_OVER = "window-inprocess-mouse-over-event";
    private void RegisterOnMouseOver() {
        Window.OnMouseOver += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_OUT = "window-inprocess-mouse-out-event";
    private void RegisterOnMouseOut() {
        Window.OnMouseOut += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_ENTER = "window-inprocess-mouse-enter-event";
    private void RegisterOnMouseEnter() {
        Window.OnMouseEnter += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_MOUSE_LEAVE = "window-inprocess-mouse-leave-event";
    private void RegisterOnMouseLeave() {
        Window.OnMouseLeave += (MouseEvent mouseEvent) => {
            labelOutput = mouseEvent.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_TOUCH_START = "window-inprocess-touch-start-event";
    private void RegisterOnTouchStart() {
        Window.OnTouchStart += (TouchEvent touchEvent) => {
            labelOutput = touchEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TOUCH_END = "window-inprocess-touch-end-event";
    private void RegisterOnTouchEnd() {
        Window.OnTouchEnd += (TouchEvent touchEvent) => {
            labelOutput = touchEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TOUCH_MOVE = "window-inprocess-touch-move-event";
    private void RegisterOnTouchMove() {
        Window.OnTouchMove += (TouchEvent touchEvent) => {
            labelOutput = touchEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TOUCH_CANCEL = "window-inprocess-touch-cancel-event";
    private void RegisterOnTouchCancel() {
        Window.OnTouchCancel += (TouchEvent touchEvent) => {
            labelOutput = touchEvent.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_POINTER_DOWN = "window-inprocess-pointer-down-event";
    private void RegisterOnPointerDown() {
        Window.OnPointerDown += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_UP = "window-inprocess-pointer-up-event";
    private void RegisterOnPointerUp() {
        Window.OnPointerUp += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_MOVE = "window-inprocess-pointer-move-event";
    private void RegisterOnPointerMove() {
        Window.OnPointerMove += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_OVER = "window-inprocess-pointer-over-event";
    private void RegisterOnPointerOver() {
        Window.OnPointerOver += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_OUT = "window-inprocess-pointer-out-event";
    private void RegisterOnPointerOut() {
        Window.OnPointerOut += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_ENTER = "window-inprocess-pointer-enter-event";
    private void RegisterOnPointerEnter() {
        Window.OnPointerEnter += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_LEAVE = "window-inprocess-pointer-leave-event";
    private void RegisterOnPointerLeave() {
        Window.OnPointerLeave += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_CANCEL = "window-inprocess-pointer-cancel-event";
    private void RegisterOnPointerCancel() {
        Window.OnPointerCancel += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_POINTER_RAW_UPDATE = "window-inprocess-pointer-raw-update-event";
    private void RegisterOnPointerRawUpdate() {
        Window.OnPointerRawUpdate += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_GOT_POINTER_CAPTURE = "window-inprocess-got-pointer-capture-event";
    private void RegisterOnGotPointerCapture() {
        Window.OnGotPointerCapture += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOST_POINTER_CAPTURE = "window-inprocess-lost-pointer-capture-event";
    private void RegisterOnLostPointerCapture() {
        Window.OnLostPointerCapture += (PointerEvent pointerEvent) => {
            labelOutput = pointerEvent.ToString();
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_FOCUS_IN = "window-inprocess-focus-in-event";
    private void RegisterOnFocusIn() {
        Window.OnFocusIn += () => {
            labelOutput = TEST_EVENT_FOCUS_IN;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_FOCUS_OUT = "window-inprocess-focus-out-event";
    private void RegisterOnFocusOut() {
        Window.OnFocusOut += () => {
            labelOutput = TEST_EVENT_FOCUS_OUT;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_COPY = "window-inprocess-copy-event";
    private void RegisterOnCopy() {
        Window.OnCopy += () => {
            labelOutput = TEST_EVENT_COPY;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PASTE = "window-inprocess-paste-event";
    private void RegisterOnPaste() {
        Window.OnPaste += () => {
            labelOutput = TEST_EVENT_PASTE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CUT = "window-inprocess-cut-event";
    private void RegisterOnCut() {
        Window.OnCut += () => {
            labelOutput = TEST_EVENT_CUT;
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_TRANSITION_START = "window-inprocess-transition-start-event";
    private void RegisterOnTransitionStart() {
        Window.OnTransitionStart += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_TRANSITION_START}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITION_END = "window-inprocess-transition-end-event";
    private void RegisterOnTransitionEnd() {
        Window.OnTransitionEnd += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_TRANSITION_END}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITION_RUN = "window-inprocess-transition-run-event";
    private void RegisterOnTransitionRun() {
        Window.OnTransitionRun += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_TRANSITION_RUN}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TRANSITION_CANCEL = "window-inprocess-transition-cancel-event";
    private void RegisterOnTransitionCancel() {
        Window.OnTransitionCancel += (string propertyName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_TRANSITION_CANCEL}; propertyName={propertyName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }


    public const string BUTTON_REGISTER_ON_ANIMATION_START = "window-inprocess-animation-start-event";
    private void RegisterOnAnimationStart() {
        Window.OnAnimationStart += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_ANIMATION_START}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATION_END = "window-inprocess-animation-end-event";
    private void RegisterOnAnimationEnd() {
        Window.OnAnimationEnd += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_ANIMATION_END}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATION_ITERATION = "window-inprocess-animation-iteration-event";
    private void RegisterOnAnimationIteration() {
        Window.OnAnimationIteration += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_ANIMATION_ITERATION}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ANIMATION_CANCEL = "window-inprocess-animation-cancel-event";
    private void RegisterOnAnimationCancel() {
        Window.OnAnimationCancel += (string animationName, double elapsedTime, string pseudoElement) => {
            labelOutput = $"{TEST_EVENT_ANIMATION_CANCEL}; animationName={animationName}, elapsedTime={elapsedTime}, pseudoElement={pseudoElement}";
            StateHasChanged();
        };
    }


    // events - HTMLMediaElement Ready

    public const string BUTTON_REGISTER_ON_CAN_PLAY = "window-inprocess-can-play-event";
    private void RegisterOnCanPlay() {
        Window.OnCanPlay += () => {
            labelOutput = TEST_EVENT_CAN_PLAY;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CAN_PLAY_THROUGH = "window-inprocess-can-play-through-event";
    private void RegisterOnCanPlayThrough() {
        Window.OnCanPlayThrough += () => {
            labelOutput = TEST_EVENT_CAN_PLAY_THROUGH;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PLAYING = "window-inprocess-playing-event";
    private void RegisterOnPlaying() {
        Window.OnPlaying += () => {
            labelOutput = TEST_EVENT_PLAYING;
            StateHasChanged();
        };
    }

    // events - HTMLMediaElement Data

    public const string BUTTON_REGISTER_ON_LOAD_START = "window-inprocess-load-start-event";
    private void RegisterOnLoadStart() {
        Window.OnLoadStart += () => {
            labelOutput = TEST_EVENT_LOAD_START;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PROGRESS = "window-inprocess-progress-event";
    private void RegisterOnProgress() {
        Window.OnProgress += () => {
            labelOutput = TEST_EVENT_PROGRESS;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOADED_DATA = "window-inprocess-loaded-data-event";
    private void RegisterOnLoadedData() {
        Window.OnLoadedData += () => {
            labelOutput = TEST_EVENT_LOADED_DATA;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LOADED_METADATA = "window-inprocess-loaded-metadata-event";
    private void RegisterOnLoadedMetadata() {
        Window.OnLoadedMetadata += () => {
            labelOutput = TEST_EVENT_LOADED_METADATA;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_STALLED = "window-inprocess-stalled-event";
    private void RegisterOnStalled() {
        Window.OnStalled += () => {
            labelOutput = TEST_EVENT_STALLED;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SUSPEND = "window-inprocess-suspend-event";
    private void RegisterOnSuspend() {
        Window.OnSuspend += () => {
            labelOutput = TEST_EVENT_SUSPEND;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_WAITING = "window-inprocess-waiting-event";
    private void RegisterOnWaiting() {
        Window.OnWaiting += () => {
            labelOutput = TEST_EVENT_WAITING;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ABORT = "window-inprocess-abort-event";
    private void RegisterOnAbort() {
        Window.OnAbort += () => {
            labelOutput = TEST_EVENT_ABORT;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_EMPTIED = "window-inprocess-emptied-event";
    private void RegisterOnEmptied() {
        Window.OnEmptied += () => {
            labelOutput = TEST_EVENT_EMPTIED;
            StateHasChanged();
        };
    }

    // events - HTMLMediaElement Timing

    public const string BUTTON_REGISTER_ON_PLAY = "window-inprocess-play-event";
    private void RegisterOnPlay() {
        Window.OnPlay += () => {
            labelOutput = TEST_EVENT_PLAY;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_PAUSE = "window-inprocess-pause-event";
    private void RegisterOnPause() {
        Window.OnPause += () => {
            labelOutput = TEST_EVENT_PAUSE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ENDED = "window-inprocess-ended-event";
    private void RegisterOnEnded() {
        Window.OnEnded += () => {
            labelOutput = TEST_EVENT_ENDED;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SEEKING = "window-inprocess-seeking-event";
    private void RegisterOnSeeking() {
        Window.OnSeeking += () => {
            labelOutput = TEST_EVENT_SEEKING;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_SEEKED = "window-inprocess-seeked-event";
    private void RegisterOnSeeked() {
        Window.OnSeeked += () => {
            labelOutput = TEST_EVENT_SEEKED;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_TIME_UPDATE = "window-inprocess-time-update-event";
    private void RegisterOnTimeUpdate() {
        Window.OnTimeUpdate += () => {
            labelOutput = TEST_EVENT_TIME_UPDATE;
            StateHasChanged();
        };
    }

    // events - HTMLMediaElement Setting

    public const string BUTTON_REGISTER_ON_VOLUME_CHANGE = "window-inprocess-volume-change-event";
    private void RegisterOnVolumeChange() {
        Window.OnVolumeChange += () => {
            labelOutput = TEST_EVENT_VOLUME_CHANGE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_RATE_CHANGE = "window-inprocess-rate-change-event";
    private void RegisterOnRateChange() {
        Window.OnRateChange += () => {
            labelOutput = TEST_EVENT_RATE_CHANGE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_DURATION_CHANGE = "window-inprocess-duration-change-event";
    private void RegisterOnDurationChange() {
        Window.OnDurationChange += () => {
            labelOutput = TEST_EVENT_DURATION_CHANGE;
            StateHasChanged();
        };
    }


    // events - HTMLDialogElement

    public const string BUTTON_REGISTER_ON_CLOSE = "window-inprocess-close-event";
    private void RegisterOnClose() {
        Window.OnClose += () => {
            labelOutput = TEST_EVENT_CLOSE;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CANCEL = "window-inprocess-cancel-event";
    private void RegisterOnCancel() {
        Window.OnCancel += () => {
            labelOutput = TEST_EVENT_CANCEL;
            StateHasChanged();
        };
    }
}
