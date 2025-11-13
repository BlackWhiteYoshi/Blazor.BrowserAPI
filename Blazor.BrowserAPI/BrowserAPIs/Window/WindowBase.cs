using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IWindow")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IWindowInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class WindowBase(IModuleManager moduleManager) : IDisposable {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IModuleManager moduleManager = moduleManager;
    private protected IJSObjectReference? windowJS;

    /// <summary>
    /// Releases the <see cref="EventTrigger"/> object used to trigger the events.
    /// </summary>
    public void Dispose() => _objectReferenceEventTrigger?.Dispose();


    /// <summary>
    /// <para>Contains a callback with no parameter and no return value.</para>
    /// <para>Used for <see cref="Window.SetTimeout"/>, <see cref="Window.SetInterval"/>, <see cref="Window.RequestIdleCallback"/> and <see cref="Window.QueueMicrotask"/>.</para>
    /// </summary>
    /// <param name="handler">callback function given as argument.</param>
    [method: DynamicDependency(nameof(Handler))]
    internal sealed class VoidCallback(Action handler) {
        public Action HandlerValue { get; set; } = handler;

        [JSInvokable]
        public void Handler() => HandlerValue();
    }

    /// <summary>
    /// <para>Contains a callback with a timestamp parameter and no return value.</para>
    /// <para>Used for <see cref="Window.RequestAnimationFrame"/>.</para>
    /// </summary>
    /// <param name="handler">callback function given as argument. The parameter is the timeStamp.</param>
    [method: DynamicDependency(nameof(Handler))]
    internal sealed class AnimationFrameCallback(Action<double> handler) {
        public Action<double> HandlerValue { get; set; } = handler;

        [JSInvokable]
        public void Handler(double timeStamp) => HandlerValue(timeStamp);
    }


    #region Events

    [method: DynamicDependency(nameof(InvokeError))]
    [method: DynamicDependency(nameof(InvokeLanguageChange))]
    [method: DynamicDependency(nameof(InvokeResize))]
    [method: DynamicDependency(nameof(InvokeStorage))]

    [method: DynamicDependency(nameof(InvokeFocus))]
    [method: DynamicDependency(nameof(InvokeBlur))]
    [method: DynamicDependency(nameof(InvokeLoad))]
    [method: DynamicDependency(nameof(InvokeBeforeUnload))]
    [method: DynamicDependency(nameof(InvokeAppInstalled))]
    [method: DynamicDependency(nameof(InvokeBeforeInstallPrompt))]
    [method: DynamicDependency(nameof(InvokeMessage))]
    [method: DynamicDependency(nameof(InvokeMessageError))]
    [method: DynamicDependency(nameof(InvokeAfterPrint))]
    [method: DynamicDependency(nameof(InvokeBeforePrint))]
    [method: DynamicDependency(nameof(InvokeRejectionHandled))]
    [method: DynamicDependency(nameof(InvokeUnhandledRejection))]

    // HTMLElement
    [method: DynamicDependency(nameof(InvokeScroll))]
    [method: DynamicDependency(nameof(InvokeScrollEnd))]
    [method: DynamicDependency(nameof(InvokeChange))]

    [method: DynamicDependency(nameof(InvokeDrag))]
    [method: DynamicDependency(nameof(InvokeDragStart))]
    [method: DynamicDependency(nameof(InvokeDragEnd))]
    [method: DynamicDependency(nameof(InvokeDragEnter))]
    [method: DynamicDependency(nameof(InvokeDragLeave))]
    [method: DynamicDependency(nameof(InvokeDragOver))]
    [method: DynamicDependency(nameof(InvokeDrop))]

    [method: DynamicDependency(nameof(InvokeToggle))]
    [method: DynamicDependency(nameof(InvokeBeforeToggle))]

    // Element
    [method: DynamicDependency(nameof(InvokeInput))]
    [method: DynamicDependency(nameof(InvokeBeforeInput))]
    [method: DynamicDependency(nameof(InvokeBeforeMatch))]

    [method: DynamicDependency(nameof(InvokeKeyDown))]
    [method: DynamicDependency(nameof(InvokeKeyUp))]

    [method: DynamicDependency(nameof(InvokeClick))]
    [method: DynamicDependency(nameof(InvokeDblClick))]
    [method: DynamicDependency(nameof(InvokeAuxClick))]
    [method: DynamicDependency(nameof(InvokeContextMenu))]
    [method: DynamicDependency(nameof(InvokeMouseDown))]
    [method: DynamicDependency(nameof(InvokeMouseUp))]
    [method: DynamicDependency(nameof(InvokeWheel))]
    [method: DynamicDependency(nameof(InvokeMouseMove))]
    [method: DynamicDependency(nameof(InvokeMouseOver))]
    [method: DynamicDependency(nameof(InvokeMouseOut))]
    [method: DynamicDependency(nameof(InvokeMouseEnter))]
    [method: DynamicDependency(nameof(InvokeMouseLeave))]

    [method: DynamicDependency(nameof(InvokeTouchStart))]
    [method: DynamicDependency(nameof(InvokeTouchEnd))]
    [method: DynamicDependency(nameof(InvokeTouchMove))]
    [method: DynamicDependency(nameof(InvokeTouchCancel))]

    [method: DynamicDependency(nameof(InvokePointerDown))]
    [method: DynamicDependency(nameof(InvokePointerUp))]
    [method: DynamicDependency(nameof(InvokePointerMove))]
    [method: DynamicDependency(nameof(InvokePointerOver))]
    [method: DynamicDependency(nameof(InvokePointerOut))]
    [method: DynamicDependency(nameof(InvokePointerEnter))]
    [method: DynamicDependency(nameof(InvokePointerLeave))]
    [method: DynamicDependency(nameof(InvokePointerCancel))]
    [method: DynamicDependency(nameof(InvokePointerRawUpdate))]
    [method: DynamicDependency(nameof(InvokeGotPointerCapture))]
    [method: DynamicDependency(nameof(InvokeLostPointerCapture))]

    [method: DynamicDependency(nameof(InvokeFocusIn))]
    [method: DynamicDependency(nameof(InvokeFocusOut))]

    [method: DynamicDependency(nameof(InvokeCopy))]
    [method: DynamicDependency(nameof(InvokePaste))]
    [method: DynamicDependency(nameof(InvokeCut))]

    [method: DynamicDependency(nameof(InvokeTransitionStart))]
    [method: DynamicDependency(nameof(InvokeTransitionEnd))]
    [method: DynamicDependency(nameof(InvokeTransitionRun))]
    [method: DynamicDependency(nameof(InvokeTransitionCancel))]

    [method: DynamicDependency(nameof(InvokeAnimationStart))]
    [method: DynamicDependency(nameof(InvokeAnimationEnd))]
    [method: DynamicDependency(nameof(InvokeAnimationIteration))]
    [method: DynamicDependency(nameof(InvokeAnimationCancel))]

    // HTMLMediaElement - Ready
    [method: DynamicDependency(nameof(InvokeCanPlay))]
    [method: DynamicDependency(nameof(InvokeCanPlayThrough))]
    [method: DynamicDependency(nameof(InvokePlaying))]
    // HTMLMediaElement - Data
    [method: DynamicDependency(nameof(InvokeLoadStart))]
    [method: DynamicDependency(nameof(InvokeProgress))]
    [method: DynamicDependency(nameof(InvokeLoadedData))]
    [method: DynamicDependency(nameof(InvokeLoadedMetadata))]
    [method: DynamicDependency(nameof(InvokeStalled))]
    [method: DynamicDependency(nameof(InvokeSuspend))]
    [method: DynamicDependency(nameof(InvokeWaiting))]
    [method: DynamicDependency(nameof(InvokeAbort))]
    [method: DynamicDependency(nameof(InvokeEmptied))]
    // HTMLMediaElement - Timing
    [method: DynamicDependency(nameof(InvokePlay))]
    [method: DynamicDependency(nameof(InvokePause))]
    [method: DynamicDependency(nameof(InvokeEnded))]
    [method: DynamicDependency(nameof(InvokeSeeking))]
    [method: DynamicDependency(nameof(InvokeSeeked))]
    [method: DynamicDependency(nameof(InvokeTimeUpdate))]
    // HTMLMediaElement - Setting
    [method: DynamicDependency(nameof(InvokeVolumeChange))]
    [method: DynamicDependency(nameof(InvokeRateChange))]
    [method: DynamicDependency(nameof(InvokeDurationChange))]

    // HTMLDialogElement
    [method: DynamicDependency(nameof(InvokeClose))]
    [method: DynamicDependency(nameof(InvokeCancel))]
    private sealed class EventTrigger(WindowBase window) {
        [JSInvokable] public void InvokeError(JsonElement error) => window._onError?.Invoke(error);
        [JSInvokable] public void InvokeLanguageChange() => window._onLanguageChange?.Invoke();
        [JSInvokable] public void InvokeResize() => window._onResize?.Invoke();
        [JSInvokable] public void InvokeStorage(StorageEvent storageEvent) => window._onStorage?.Invoke(storageEvent);

        [JSInvokable] public void InvokeFocus() => window._onFocus?.Invoke();
        [JSInvokable] public void InvokeBlur() => window._onBlur?.Invoke();
        [JSInvokable] public void InvokeLoad() => window._onLoad?.Invoke();
        [JSInvokable] public void InvokeBeforeUnload() => window._onBeforeUnload?.Invoke();
        [JSInvokable] public void InvokeAppInstalled() => window._onAppInstalled?.Invoke();
        [JSInvokable] public void InvokeBeforeInstallPrompt() => window._onBeforeInstallPrompt?.Invoke();
        [JSInvokable] public void InvokeMessage(JsonElement data, string origin, string lastEventId) => window._onMessage?.Invoke(data, origin, lastEventId);
        [JSInvokable] public void InvokeMessageError(JsonElement data, string origin, string lastEventId) => window._onMessageError?.Invoke(data, origin, lastEventId);
        [JSInvokable] public void InvokeAfterPrint() => window._onAfterPrint?.Invoke();
        [JSInvokable] public void InvokeBeforePrint() => window._onBeforePrint?.Invoke();
        [JSInvokable] public void InvokeRejectionHandled(object? reason) => window._onRejectionHandled?.Invoke((JsonElement?)reason);
        [JSInvokable] public void InvokeUnhandledRejection(object? reason) => window._onUnhandledRejection?.Invoke((JsonElement?)reason);

        // HTMLElement
        [JSInvokable] public void InvokeScroll() => window._onScroll?.Invoke();
        [JSInvokable] public void InvokeScrollEnd() => window._onScrollEnd?.Invoke();
        [JSInvokable] public void InvokeChange() => window._onChange?.Invoke();

        [JSInvokable] public void InvokeDrag(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => window.InvokeDrag(dropEffect, effectAllowed, types, files);
        [JSInvokable] public void InvokeDragStart(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => window.InvokeDragStart(dropEffect, effectAllowed, types, files);
        [JSInvokable] public void InvokeDragEnd(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => window.InvokeDragEnd(dropEffect, effectAllowed, types, files);
        [JSInvokable] public void InvokeDragEnter(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => window.InvokeDragEnter(dropEffect, effectAllowed, types, files);
        [JSInvokable] public void InvokeDragLeave(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => window.InvokeDragLeave(dropEffect, effectAllowed, types, files);
        [JSInvokable] public void InvokeDragOver(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => window.InvokeDragOver(dropEffect, effectAllowed, types, files);
        [JSInvokable] public void InvokeDrop(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => window.InvokeDrop(dropEffect, effectAllowed, types, files);

        [JSInvokable] public void InvokeToggle(string oldState, string newState) => window._onToggle?.Invoke(oldState, newState);
        [JSInvokable] public void InvokeBeforeToggle(string oldState, string newState) => window._onBeforeToggle?.Invoke(oldState, newState);

        // Element
        [JSInvokable] public void InvokeInput(string? data, string? inputType, bool isComposing) => window._onInput?.Invoke(data, inputType, isComposing);
        [JSInvokable] public void InvokeBeforeInput(string? data, string? inputType, bool isComposing) => window._onBeforeInput?.Invoke(data, inputType, isComposing);
        [JSInvokable] public void InvokeBeforeMatch() => window._onBeforeMatch?.Invoke();

        [JSInvokable] public void InvokeKeyDown(KeyboardEvent keyboardEvent) => window._onKeyDown?.Invoke(keyboardEvent);
        [JSInvokable] public void InvokeKeyUp(KeyboardEvent keyboardEvent) => window._onKeyUp?.Invoke(keyboardEvent);

        [JSInvokable] public void InvokeClick(MouseEvent mouseEvent) => window._onClick?.Invoke(mouseEvent);
        [JSInvokable] public void InvokeDblClick(MouseEvent mouseEvent) => window._onDblClick?.Invoke(mouseEvent);
        [JSInvokable] public void InvokeAuxClick(MouseEvent mouseEvent) => window._onAuxClick?.Invoke(mouseEvent);
        [JSInvokable] public void InvokeContextMenu(MouseEvent mouseEvent) => window._onContextMenu?.Invoke(mouseEvent);
        [JSInvokable] public void InvokeMouseDown(MouseEvent mouseEvent) => window._onMouseDown?.Invoke(mouseEvent);
        [JSInvokable] public void InvokeMouseUp(MouseEvent mouseEvent) => window._onMouseUp?.Invoke(mouseEvent);
        [JSInvokable] public void InvokeWheel(WheelEvent wheelEvent) => window._onWheel?.Invoke(wheelEvent);
        [JSInvokable] public void InvokeMouseMove(MouseEvent mouseEvent) => window._onMouseMove?.Invoke(mouseEvent);
        [JSInvokable] public void InvokeMouseOver(MouseEvent mouseEvent) => window._onMouseOver?.Invoke(mouseEvent);
        [JSInvokable] public void InvokeMouseOut(MouseEvent mouseEvent) => window._onMouseOut?.Invoke(mouseEvent);
        [JSInvokable] public void InvokeMouseEnter(MouseEvent mouseEvent) => window._onMouseEnter?.Invoke(mouseEvent);
        [JSInvokable] public void InvokeMouseLeave(MouseEvent mouseEvent) => window._onMouseLeave?.Invoke(mouseEvent);

        [JSInvokable] public void InvokeTouchStart(TouchEvent touchEvent) => window._onTouchStart?.Invoke(touchEvent);
        [JSInvokable] public void InvokeTouchEnd(TouchEvent touchEvent) => window._onTouchEnd?.Invoke(touchEvent);
        [JSInvokable] public void InvokeTouchMove(TouchEvent touchEvent) => window._onTouchMove?.Invoke(touchEvent);
        [JSInvokable] public void InvokeTouchCancel(TouchEvent touchEvent) => window._onTouchCancel?.Invoke(touchEvent);

        [JSInvokable] public void InvokePointerDown(PointerEvent pointerEvent) => window._onPointerDown?.Invoke(pointerEvent);
        [JSInvokable] public void InvokePointerUp(PointerEvent pointerEvent) => window._onPointerUp?.Invoke(pointerEvent);
        [JSInvokable] public void InvokePointerMove(PointerEvent pointerEvent) => window._onPointerMove?.Invoke(pointerEvent);
        [JSInvokable] public void InvokePointerOver(PointerEvent pointerEvent) => window._onPointerOver?.Invoke(pointerEvent);
        [JSInvokable] public void InvokePointerOut(PointerEvent pointerEvent) => window._onPointerOut?.Invoke(pointerEvent);
        [JSInvokable] public void InvokePointerEnter(PointerEvent pointerEvent) => window._onPointerEnter?.Invoke(pointerEvent);
        [JSInvokable] public void InvokePointerLeave(PointerEvent pointerEvent) => window._onPointerLeave?.Invoke(pointerEvent);
        [JSInvokable] public void InvokePointerCancel(PointerEvent pointerEvent) => window._onPointerCancel?.Invoke(pointerEvent);
        [JSInvokable] public void InvokePointerRawUpdate(PointerEvent pointerEvent) => window._onPointerRawUpdate?.Invoke(pointerEvent);
        [JSInvokable] public void InvokeGotPointerCapture(PointerEvent pointerEvent) => window._onGotPointerCapture?.Invoke(pointerEvent);
        [JSInvokable] public void InvokeLostPointerCapture(PointerEvent pointerEvent) => window._onLostPointerCapture?.Invoke(pointerEvent);

        [JSInvokable] public void InvokeFocusIn() => window._onFocusIn?.Invoke();
        [JSInvokable] public void InvokeFocusOut() => window._onFocusOut?.Invoke();

        [JSInvokable] public void InvokeCopy() => window._onCopy?.Invoke();
        [JSInvokable] public void InvokePaste() => window._onPaste?.Invoke();
        [JSInvokable] public void InvokeCut() => window._onCut?.Invoke();

        [JSInvokable] public void InvokeTransitionStart(string propertyName, double elapsedTime, string pseudoElement) => window._onTransitionStart?.Invoke(propertyName, elapsedTime, pseudoElement);
        [JSInvokable] public void InvokeTransitionEnd(string propertyName, double elapsedTime, string pseudoElement) => window._onTransitionEnd?.Invoke(propertyName, elapsedTime, pseudoElement);
        [JSInvokable] public void InvokeTransitionRun(string propertyName, double elapsedTime, string pseudoElement) => window._onTransitionRun?.Invoke(propertyName, elapsedTime, pseudoElement);
        [JSInvokable] public void InvokeTransitionCancel(string propertyName, double elapsedTime, string pseudoElement) => window._onTransitionCancel?.Invoke(propertyName, elapsedTime, pseudoElement);

        [JSInvokable] public void InvokeAnimationStart(string animationName, double elapsedTime, string pseudoElement) => window._onAnimationStart?.Invoke(animationName, elapsedTime, pseudoElement);
        [JSInvokable] public void InvokeAnimationEnd(string animationName, double elapsedTime, string pseudoElement) => window._onAnimationEnd?.Invoke(animationName, elapsedTime, pseudoElement);
        [JSInvokable] public void InvokeAnimationIteration(string animationName, double elapsedTime, string pseudoElement) => window._onAnimationIteration?.Invoke(animationName, elapsedTime, pseudoElement);
        [JSInvokable] public void InvokeAnimationCancel(string animationName, double elapsedTime, string pseudoElement) => window._onAnimationCancel?.Invoke(animationName, elapsedTime, pseudoElement);

        // HTMLMediaElement - Ready
        [JSInvokable] public void InvokeCanPlay() => window._onCanPlay?.Invoke();
        [JSInvokable] public void InvokeCanPlayThrough() => window._onCanPlayThrough?.Invoke();
        [JSInvokable] public void InvokePlaying() => window._onPlaying?.Invoke();
        // HTMLMediaElement - Data
        [JSInvokable] public void InvokeLoadStart() => window._onLoadStart?.Invoke();
        [JSInvokable] public void InvokeProgress() => window._onProgress?.Invoke();
        [JSInvokable] public void InvokeLoadedData() => window._onLoadedData?.Invoke();
        [JSInvokable] public void InvokeLoadedMetadata() => window._onLoadedMetadata?.Invoke();
        [JSInvokable] public void InvokeStalled() => window._onStalled?.Invoke();
        [JSInvokable] public void InvokeSuspend() => window._onSuspend?.Invoke();
        [JSInvokable] public void InvokeWaiting() => window._onWaiting?.Invoke();
        [JSInvokable] public void InvokeAbort() => window._onAbort?.Invoke();
        [JSInvokable] public void InvokeEmptied() => window._onEmptied?.Invoke();
        // HTMLMediaElement - Timing
        [JSInvokable] public void InvokePlay() => window._onPlay?.Invoke();
        [JSInvokable] public void InvokePause() => window._onPause?.Invoke();
        [JSInvokable] public void InvokeEnded() => window._onEnded?.Invoke();
        [JSInvokable] public void InvokeSeeking() => window._onSeeking?.Invoke();
        [JSInvokable] public void InvokeSeeked() => window._onSeeked?.Invoke();
        [JSInvokable] public void InvokeTimeUpdate() => window._onTimeUpdate?.Invoke();
        // HTMLMediaElement - Setting
        [JSInvokable] public void InvokeVolumeChange() => window._onVolumeChange?.Invoke();
        [JSInvokable] public void InvokeRateChange() => window._onRateChange?.Invoke();
        [JSInvokable] public void InvokeDurationChange() => window._onDurationChange?.Invoke();

        // HTMLDialogElement
        [JSInvokable] public void InvokeClose() => window._onClose?.Invoke();
        [JSInvokable] public void InvokeCancel() => window._onCancel?.Invoke();
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private async ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        if (windowJS is null)
            windowJS = await moduleManager.InvokeTrySync<IJSObjectReference>("WindowAPI.createInstanceAndInitEvents", default, [_objectReferenceEventTrigger]);
        else
            await windowJS.InvokeVoidTrySync("WindowAPI.initEvents", default, [_objectReferenceEventTrigger]);
    }


    private protected async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await windowJS!.InvokeVoidTrySync(jsMethodName);
    }

    private protected ValueTask DeactivateJSEvent(string jsMethodName) => windowJS!.InvokeVoidTrySync(jsMethodName);


    // Window - Events

    private Action<JsonElement>? _onError;
    /// <summary>
    /// <para>Is fired on a Window object when a resource failed to load or couldn't be used — for example if a script has an execution error.</para>
    /// <para>
    /// This event is only generated for script errors thrown synchronously, such as during initial loading or within event handlers.
    /// If a promise was rejected (including an uncaught throw within an async function) and no rejection handlers were attached, an unhandledrejection event is fired instead.
    /// </para>
    /// </summary>
    public event Action<JsonElement> OnError {
        add {
            if (_onError == null)
                _ = ActivateJSEvent("activateOnerror").Preserve();
            _onError += value;
        }
        remove {
            _onError -= value;
            if (_onError == null)
                _ = DeactivateJSEvent("deactivateOnerror").Preserve();
        }
    }

    private Action? _onLanguageChange;
    /// <summary>
    /// Is fired at the global scope object when the user's preferred language changes.
    /// </summary>
    public event Action OnLanguageChange {
        add {
            if (_onLanguageChange == null)
                _ = ActivateJSEvent("activateOnlanguagechange").Preserve();
            _onLanguageChange += value;
        }
        remove {
            _onLanguageChange -= value;
            if (_onLanguageChange == null)
                _ = DeactivateJSEvent("deactivateOnlanguagechange").Preserve();
        }
    }

    private Action? _onResize;
    /// <summary>
    /// <para>Fires when the document view (window) has been resized.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// <para>
    /// In some earlier browsers it was possible to register resize event handlers on any HTML element.
    /// It is still possible to set onresize attributes or use addEventListener() to set a handler on any element.
    /// However, resize events are only fired on the window object (i.e., returned by document.defaultView).
    /// Only handlers registered on the window object will receive resize events.
    /// </para>
    /// <para>While the resize event fires only for the window nowadays, you can get resize notifications for other elements using the ResizeObserver API.</para>
    /// <para>
    /// If the resize event is triggered too many times for your application,
    /// see <see href="https://bencentra.com/code/2015/02/27/optimizing-window-resize.html">Optimizing window.onresize</see> to control the time after which the event fires.
    /// </para>
    /// </summary>
    public event Action OnResize {
        add {
            if (_onResize == null)
                _ = ActivateJSEvent("activateOnresize").Preserve();
            _onResize += value;
        }
        remove {
            _onResize -= value;
            if (_onResize == null)
                _ = DeactivateJSEvent("deactivateOnresize").Preserve();
        }
    }

    private Action<StorageEvent>? _onStorage;
    /// <summary>
    /// <para>
    /// Fires when another document that shares the same storage area (either localStorage or sessionStorage) as the current window updates that storage area.
    /// The event is not fired on the window that made the change.<br />
    /// - For localStorage, the event is fired in all other browsing contexts that are in the same origin as the initiating document.
    /// This includes other tabs with the same origin.<br />
    /// - For sessionStorage, the event is fired in all other browsing contexts that are in the same origin and the same top-level browsing context as the initiating document.
    /// This only includes embedded iframes, if any, in the same tab, and not other tabs.
    /// </para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action<StorageEvent> OnStorage {
        add {
            if (_onStorage == null)
                _ = ActivateJSEvent("activateOnstorage").Preserve();
            _onStorage += value;
        }
        remove {
            _onStorage -= value;
            if (_onStorage == null)
                _ = DeactivateJSEvent("deactivateOnstorage").Preserve();
        }
    }


    private Action? _onFocus;
    /// <summary>
    /// <para>Fires when thw window has received focus.</para>
    /// <para>The opposite of focus is blur.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnFocus {
        add {
            if (_onFocus == null)
                _ = ActivateJSEvent("activateOnfocus").Preserve();
            _onFocus += value;
        }
        remove {
            _onFocus -= value;
            if (_onFocus == null)
                _ = DeactivateJSEvent("deactivateOnfocus").Preserve();
        }
    }

    private Action? _onBlur;
    /// <summary>
    /// <para>Fires when the window has lost focus.</para>
    /// <para>The opposite of blur is focus.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnBlur {
        add {
            if (_onBlur == null)
                _ = ActivateJSEvent("activateOnblur").Preserve();
            _onBlur += value;
        }
        remove {
            _onBlur -= value;
            if (_onBlur == null)
                _ = DeactivateJSEvent("deactivateOnblur").Preserve();
        }
    }

    private Action? _onLoad;
    /// <summary>
    /// <para>
    /// Is fired when the whole page has loaded, including all dependent resources such as stylesheets, scripts (including async, deferred, and module scripts), iframes, and images, except those that are loaded lazily.
    /// This is in contrast to DOMContentLoaded, which is fired as soon as the page DOM has been loaded, without waiting for resources to finish loading.
    /// </para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    /// <remarks>
    /// <para>Note: All events named load will not propagate to Window, even with bubbles initialized to true. To catch load events on the window, that load event must be dispatched directly to the window.</para>
    /// <para>
    /// Note: The load event that is dispatched when the main document has loaded is dispatched on the window, but has two mutated properties: target is document, and path is undefined.
    /// These two properties are mutated due to legacy conformance.
    /// </para>
    /// </remarks>
    public event Action OnLoad {
        add {
            if (_onLoad == null)
                _ = ActivateJSEvent("activateOnload").Preserve();
            _onLoad += value;
        }
        remove {
            _onLoad -= value;
            if (_onLoad == null)
                _ = DeactivateJSEvent("deactivateOnload").Preserve();
        }
    }

    private Action? _onBeforeUnload;
    /// <summary>
    /// <para>Is fired when the current window, contained document, and associated resources are about to be unloaded. The document is still visible and the event is still cancelable at this point.</para>
    /// <para>
    /// The main use case for this event is to trigger a browser-generated confirmation dialog that asks users to confirm if they really want to leave the page when they try to close or reload it,
    /// or navigate somewhere else.
    /// This is intended to help prevent loss of unsaved data.
    /// </para>
    /// <para>
    /// The dialog can be triggered in the following ways:<br />
    /// - Calling the event object's preventDefault() method.<br />
    /// - Setting the event object's returnValue property to a non-empty string value or any other truthy value.<br />
    /// - Returning any truthy value from the event handler function, e.g., return "string".<br />
    /// Note that this only works when the function is attached via the onbeforeunload property, not the addEventListener() method.
    /// This behavior is consistent across modern versions of Firefox, Safari, and Chrome.<br />
    /// The last two mechanisms are legacy features; best practice is to trigger the dialog by invoking preventDefault() on the event object, while also setting returnValue to support legacy cases.
    /// </para>
    /// </summary>
    public event Action OnBeforeUnload {
        add {
            if (_onBeforeUnload == null)
                _ = ActivateJSEvent("activateOnbeforeunload").Preserve();
            _onBeforeUnload += value;
        }
        remove {
            _onBeforeUnload -= value;
            if (_onBeforeUnload == null)
                _ = DeactivateJSEvent("deactivateOnbeforeunload").Preserve();
        }
    }

    private Action? _onAppInstalled;
    /// <summary>
    /// <para>Is fired when the browser has successfully installed a page as an application.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnAppInstalled {
        add {
            if (_onAppInstalled == null)
                _ = ActivateJSEvent("activateOnappinstalled").Preserve();
            _onAppInstalled += value;
        }
        remove {
            _onAppInstalled -= value;
            if (_onAppInstalled == null)
                _ = DeactivateJSEvent("deactivateOnappinstalled").Preserve();
        }
    }

    private Action? _onBeforeInstallPrompt;
    /// <summary>
    /// <para>Fires when the browser has detected that a website can be installed as a Progressive Web App.</para>
    /// <para>There's no guaranteed time this event is fired, but it usually happens on page load.</para>
    /// <para>
    /// The typical use for this event is when a web app wants to provide its own in-app UI inviting the user to install the app, rather than the generic one provided by the browser.
    /// This enables the app to provide more context about the app, explaining to the user why they might want to install it.
    /// </para>
    /// <para>
    /// In this scenario, the handler for this event will:<br />
    /// - Keep a reference to the BeforeInstallPromptEvent object that's passed into it<br />
    /// - Reveal its in-app installation UI (this should be hidden by default, because not all browsers will support installation).
    /// </para>
    /// <para>When the user uses the in-app installation UI to install the app, the in-app installation UI calls the prompt() method of the retained BeforeInstallPromptEvent object to show the installation prompt.</para>
    /// </summary>
    public event Action OnBeforeInstallPrompt {
        add {
            if (_onBeforeInstallPrompt == null)
                _ = ActivateJSEvent("activateOnbeforeinstallprompt").Preserve();
            _onBeforeInstallPrompt += value;
        }
        remove {
            _onBeforeInstallPrompt -= value;
            if (_onBeforeInstallPrompt == null)
                _ = DeactivateJSEvent("deactivateOnbeforeinstallprompt").Preserve();
        }
    }

    private Action<JsonElement, string, string>? _onMessage;
    /// <summary>
    /// <para>Is fired on a Window object when the window receives a message, for example from a call to Window.postMessage() from another browsing context.</para>
    /// <para>This event is not cancellable and does not bubble.</para>
    /// </summary>
    public event Action<JsonElement, string, string> OnMessage {
        add {
            if (_onMessage == null)
                _ = ActivateJSEvent("activateOnmessage").Preserve();
            _onMessage += value;
        }
        remove {
            _onMessage -= value;
            if (_onMessage == null)
                _ = DeactivateJSEvent("deactivateOnmessage").Preserve();
        }
    }

    private Action<JsonElement, string, string>? _onMessageError;
    /// <summary>
    /// <para>Is fired on a Window object when it receives a message that can't be deserialized.</para>
    /// <para>This event is not cancellable and does not bubble.</para>
    /// </summary>
    public event Action<JsonElement, string, string> OnMessageError {
        add {
            if (_onMessageError == null)
                _ = ActivateJSEvent("activateOnmessageerror").Preserve();
            _onMessageError += value;
        }
        remove {
            _onMessageError -= value;
            if (_onMessageError == null)
                _ = DeactivateJSEvent("deactivateOnmessageerror").Preserve();
        }
    }

    private Action? _onAfterPrint;
    /// <summary>
    /// <para>Is fired after the associated document has started printing or the print preview has been closed.</para>
    /// <para>
    /// The beforeprint and afterprint events allow pages to change their content before printing starts (perhaps to remove a banner, for example) and then revert those changes after printing has completed.
    /// In general, you should prefer the use of a @media print CSS at-rule, but it may be necessary to use these events in some cases.
    /// </para>
    /// </summary>
    public event Action OnAfterPrint {
        add {
            if (_onAfterPrint == null)
                _ = ActivateJSEvent("activateOnafterprint").Preserve();
            _onAfterPrint += value;
        }
        remove {
            _onAfterPrint -= value;
            if (_onAfterPrint == null)
                _ = DeactivateJSEvent("deactivateOnafterprint").Preserve();
        }
    }

    private Action? _onBeforePrint;
    /// <summary>
    /// <para>Is fired when the associated document is about to be printed or previewed for printing.</para>
    /// <para>
    /// The afterprint and beforeprint events allow pages to change their content before printing starts (perhaps to remove a banner, for example) and then revert those changes after printing has completed.
    /// In general, you should prefer the use of a @media print CSS at-rule, but it may be necessary to use these events in some cases.
    /// </para>
    /// </summary>
    public event Action OnBeforePrint {
        add {
            if (_onBeforePrint == null)
                _ = ActivateJSEvent("activateOnbeforeprint").Preserve();
            _onBeforePrint += value;
        }
        remove {
            _onBeforePrint -= value;
            if (_onBeforePrint == null)
                _ = DeactivateJSEvent("deactivateOnbeforeprint").Preserve();
        }
    }

    private Action<JsonElement?>? _onRejectionHandled;
    /// <summary>
    /// <para>
    /// Is sent to the script's global scope (usually window but also Worker) whenever a rejected JavaScript Promise is handled late,
    /// i.e., when a handler is attached to the promise after its rejection had caused an unhandledrejection event.
    /// </para>
    /// <para>
    /// This can be used in debugging and for general application resiliency, in tandem with the unhandledrejection event,
    /// which is sent when a promise is rejected but there is no handler for the rejection at the time.
    /// </para>
    /// </summary>
    public event Action<JsonElement?> OnRejectionHandled {
        add {
            if (_onRejectionHandled == null)
                _ = ActivateJSEvent("activateOnrejectionhandled").Preserve();
            _onRejectionHandled += value;
        }
        remove {
            _onRejectionHandled -= value;
            if (_onRejectionHandled == null)
                _ = DeactivateJSEvent("deactivateOnrejectionhandled").Preserve();
        }
    }

    private Action<JsonElement?>? _onUnhandledRejection;
    /// <summary>
    /// <para>Is sent to the global scope of a script when a JavaScript Promise that has no rejection handler is rejected; typically, this is the window, but may also be a Worker.</para>
    /// <para>This is useful for debugging and for providing fallback error handling for unexpected situations.</para>
    /// </summary>
    public event Action<JsonElement?> OnUnhandledRejection {
        add {
            if (_onUnhandledRejection == null)
                _ = ActivateJSEvent("activateOnunhandledrejection").Preserve();
            _onUnhandledRejection += value;
        }
        remove {
            _onUnhandledRejection -= value;
            if (_onUnhandledRejection == null)
                _ = DeactivateJSEvent("deactivateOnunhandledrejection").Preserve();
        }
    }


    // HTMLElement - Events

    private Action? _onScroll;
    /// <summary>
    /// Fires when an element has been scrolled. To detect when scrolling has completed, see the <see cref="OnScrollEnd">scrollend event</see> of Element.
    /// </summary>
    public event Action OnScroll {
        add {
            if (_onScroll == null)
                _ = ActivateJSEvent("activateOnscroll").Preserve();
            _onScroll += value;
        }
        remove {
            _onScroll -= value;
            if (_onScroll == null)
                _ = DeactivateJSEvent("deactivateOnscroll").Preserve();
        }
    }

    private Action? _onScrollEnd;
    /// <summary>
    /// <para>Fires when element scrolling has completed. Scrolling is considered completed when the scroll position has no more pending updates and the user has completed their gesture.</para>
    /// <para>
    /// Scroll position updates include smooth or instant mouse wheel scrolling, keyboard scrolling, scroll-snap events, or other APIs and gestures which cause the scroll position to update.
    /// User gestures like touch panning or trackpad scrolling aren't complete until pointers or keys have released.
    /// If the scroll position did not change, then no scrollend event fires.
    /// </para>
    /// <para>For detecting when scrolling inside a Document is complete, see <see cref="IDocument.OnScrollEnd">the scrollend event of Document</see>.</para>
    /// </summary>
    public event Action OnScrollEnd {
        add {
            if (_onScrollEnd == null)
                _ = ActivateJSEvent("activateOnscrollend").Preserve();
            _onScrollEnd += value;
        }
        remove {
            _onScrollEnd -= value;
            if (_onScrollEnd == null)
                _ = DeactivateJSEvent("deactivateOnscrollend").Preserve();
        }
    }

    private Action? _onChange;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// Is fired for &lt;input&gt;, &lt;select&gt;, and &lt;textarea&gt; elements when the user modifies the element's value.
    /// Unlike the input event, the change event is not necessarily fired for each alteration to an element's value.
    /// </para>
    /// <para>
    /// Depending on the kind of element being changed and the way the user interacts with the element, the change event fires at a different moment:<br />
    /// - When a &lt;input type="checkbox"&gt; element is checked or unchecked (by clicking or using the keyboard);<br />
    /// - When a &lt;input type="radio"&gt; element is checked (but not when unchecked);<br />
    /// - When the user commits the change explicitly (e.g., by selecting a value from a &lt;select&gt;'s dropdown with a mouse click, by selecting a date from a date picker for &lt;input type="date"&gt;, by selecting a file in the file picker for &lt;input type="file"&gt;, etc.);<br />
    /// - When the element loses focus after its value was changed: for elements where the user's interaction is typing rather than selection, such as a &lt;textarea&gt; or the text, search, url, tel, email, or password types of the &lt;input&gt; element.
    /// </para>
    /// </summary>
    public event Action OnChange {
        add {
            if (_onChange == null)
                _ = ActivateJSEvent("activateOnchange").Preserve();
            _onChange += value;
        }
        remove {
            _onChange -= value;
            if (_onChange == null)
                _ = DeactivateJSEvent("deactivateOnchange").Preserve();
        }
    }


    // (IFile | IFileInProcess)[] files
    private protected abstract void InvokeDrag(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files);

    // (IFile | IFileInProcess)[] files
    private protected abstract void InvokeDragStart(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files);

    // (IFile | IFileInProcess)[] files
    private protected abstract void InvokeDragEnd(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files);

    // (IFile | IFileInProcess)[] files
    private protected abstract void InvokeDragEnter(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files);

    // (IFile | IFileInProcess)[] files
    private protected abstract void InvokeDragLeave(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files);

    // (IFile | IFileInProcess)[] files
    private protected abstract void InvokeDragOver(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files);

    // (IFile | IFileInProcess)[] files
    private protected abstract void InvokeDrop(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files);


    private Action<string, string>? _onToggle;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// Fires on a popover element, &lt;dialog&gt; element, or &lt;details&gt; element just after it is shown or hidden.<br />
    /// - If the element is transitioning from hidden to showing, the event.oldState property will be set to closed and the event.newState property will be set to open.<br />
    /// - If the element is transitioning from showing to hidden, then event.oldState will be open and event.newState will be closed.
    /// </para>
    /// <para>This event is not cancelable.</para>
    /// <para>
    /// <b>Parameters</b><br />
    /// - string <i>oldState</i>: either "open" or "closed", representing the state the element is transitioning to.<br />
    /// - string <i>newState</i>: either "open" or "closed", representing the state the element is transitioning from.
    /// </para>
    /// </summary>
    public event Action<string, string> OnToggle {
        add {
            if (_onToggle == null)
                _ = ActivateJSEvent("activateOntoggle").Preserve();
            _onToggle += value;
        }
        remove {
            _onToggle -= value;
            if (_onToggle == null)
                _ = DeactivateJSEvent("deactivateOntoggle").Preserve();
        }
    }

    private Action<string, string>? _onBeforeToggle;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// Fires on a popover or &lt;dialog&gt; element just before it is shown or hidden.<br />
    /// - If the element is transitioning from hidden to showing, the event.oldState property will be set to closed and the event.newState property will be set to open.<br />
    /// - If the element is transitioning from showing to hidden, then event.oldState will be open and event.newState will be closed.
    /// </para>
    /// <para>This event is cancelable when an element is toggled to open ("show") but not when the element is closing.</para>
    /// <para>
    /// Among other things, this event can be used to:<br />
    /// - prevent an element from being shown.<br />
    /// - add or remove classes or properties from the element or associated elements, for example to control the animation behavior of a dialog as it is opened and closed.<br />
    /// - clear the state of the element before it is opened or after it is hidden, for example to reset a dialog form and return value to an empty state, or hide any nested manual popovers when reopening a popup.
    /// </para>
    /// <para>
    /// <b>Parameters</b><br />
    /// - string <i>oldState</i>: either "open" or "closed", representing the state the element is transitioning to.<br />
    /// - string <i>newState</i>: either "open" or "closed", representing the state the element is transitioning from.
    /// </para>
    /// </summary>
    public event Action<string, string> OnBeforeToggle {
        add {
            if (_onBeforeToggle == null)
                _ = ActivateJSEvent("activateOnbeforetoggle").Preserve();
            _onBeforeToggle += value;
        }
        remove {
            _onBeforeToggle -= value;
            if (_onBeforeToggle == null)
                _ = DeactivateJSEvent("deactivateOnbeforetoggle").Preserve();
        }
    }


    // Element - Events

    private Action<string?, string?, bool>? _onInput;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fires when the value of an &lt;input&gt;, &lt;select&gt;, or &lt;textarea&gt; element has been changed as a direct result of a user action (such as typing in a textbox or checking a checkbox).</para>
    /// <para>
    /// The event also applies to elements with contenteditable enabled, and to any element when designMode is turned on.
    /// In the case of contenteditable and designMode, the event target is the editing host.
    /// If these properties apply to multiple elements, the editing host is the nearest ancestor element whose parent isn't editable.
    /// </para>
    /// <para>
    /// For &lt;input&gt; elements with type=checkbox or type=radio, the input event should fire whenever a user toggles the control, per the HTML Living Standard specification.
    /// However, historically this has not always been the case.
    /// Check compatibility, or use the change event instead for elements of these types.
    /// </para>
    /// <para>For &lt;textarea&gt; and &lt;input&gt; elements that accept text input (type=text, type=tel, etc.), the interface is InputEvent; for others, the interface is Event.</para>
    /// <para>
    /// The input event is fired every time the value of the element changes.
    /// This is unlike the change event, which only fires when the value is committed, such as by pressing the enter key or selecting a value from a list of options.
    /// Note that the input event is not fired when JavaScript changes an element's value programmatically.
    /// </para>
    /// <para>
    /// <b>Parameters</b><br />
    /// - string? <i>data</i>: Holds the inserted characters. This may be an empty string if the change doesn't insert text (for example, when deleting characters).<br />
    /// - string? <i>inputType</i>: The type of change for editable content such as, for example, inserting, deleting, or formatting text.<br />
    /// - bool <i>isComposing</i>: Indicates if the event is fired after compositionstart and before compositionend.
    /// </para>
    /// </summary>
    /// <remarks>
    /// Note: If the received event parameter is a generic Event, the parameter values will be 'null', 'null', 'false'.
    /// If the received event parameter is a InputEvent, the parameter inputType will be a string.
    /// So checking inputType for null distinguishes InputEvent from Event.
    /// </remarks>
    public event Action<string?, string?, bool> OnInput {
        add {
            if (_onInput == null)
                _ = ActivateJSEvent("activateOninput").Preserve();
            _onInput += value;
        }
        remove {
            _onInput -= value;
            if (_onInput == null)
                _ = DeactivateJSEvent("deactivateOninput").Preserve();
        }
    }

    private Action<string?, string?, bool>? _onBeforeInput;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// Fires when the value of an &lt;input&gt; or &lt;textarea&gt; element is about to be modified.
    /// But in contrast to the input event, it does not fire on the &lt;select&gt; element.
    /// The event also applies to elements with contenteditable enabled, and to any element when designMode is turned on.
    /// </para>
    /// <para>This allows web apps to override text edit behavior before the browser modifies the DOM tree, and provides more control over input events to improve performance.</para>
    /// <para>
    /// In the case of contenteditable and designMode, the event target is the editing host.
    /// If these properties apply to multiple elements, the editing host is the nearest ancestor element whose parent isn't editable.
    /// </para>
    /// <para>
    /// <b>Parameters</b><br />
    /// - string? <i>data</i>: Holds the inserted characters. This may be an empty string if the change doesn't insert text (for example, when deleting characters).<br />
    /// - string? <i>inputType</i>: The type of change for editable content such as, for example, inserting, deleting, or formatting text.<br />
    /// - bool <i>isComposing</i>: Indicates if the event is fired after compositionstart and before compositionend.
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Note: Not every user modification results in beforeinput firing.
    /// Also the event may fire but be non-cancelable.
    /// This may happen when the modification is done by autocomplete, by accepting a correction from a spell checker, by password manager autofill, by IME, or in other ways.
    /// The details vary by browser and OS.
    /// To override the edit behavior in all situations, the code needs to handle the input event and possibly revert any modifications that were not handled by the beforeinput handler.
    /// See bugs <see href="https://bugzil.la/1673558">1673558</see> and <see href="https://bugzil.la/1763669">1763669</see>
    /// </para>
    /// <para>
    /// Note: If the received event parameter is a generic Event, the parameter values will be 'null', 'null', 'false'.
    /// If the received event parameter is a InputEvent, the parameter inputType will be a string.
    /// So checking inputType for null distinguishes InputEvent from Event.
    /// </para>
    /// </remarks>
    public event Action<string?, string?, bool> OnBeforeInput {
        add {
            if (_onBeforeInput == null)
                _ = ActivateJSEvent("activateOnbeforeinput").Preserve();
            _onBeforeInput += value;
        }
        remove {
            _onBeforeInput -= value;
            if (_onBeforeInput == null)
                _ = DeactivateJSEvent("deactivateOnbeforeinput").Preserve();
        }
    }

    private Action? _onBeforeMatch;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// An element receives a beforematch event when it is in the hidden until found state and the browser is about to reveal its content
    /// because the user has found the content through the "find in page" feature or through fragment navigation.
    /// </summary>
    public event Action OnBeforeMatch {
        add {
            if (_onBeforeMatch == null)
                _ = ActivateJSEvent("activateOnbeforematch").Preserve();
            _onBeforeMatch += value;
        }
        remove {
            _onBeforeMatch -= value;
            if (_onBeforeMatch == null)
                _ = DeactivateJSEvent("deactivateOnbeforematch").Preserve();
        }
    }


    private Action<KeyboardEvent>? _onKeyDown;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired when a key is pressed.</para>
    /// <para>Unlike the deprecated keypress event, the keydown event is fired for all keys, regardless of whether they produce a character value.</para>
    /// <para>
    /// The keydown and keyup events provide a code indicating which key is pressed, while keypress indicates which character was entered.
    /// For example, a lowercase "a" will be reported as 65 by keydown and keyup, but as 97 by keypress. An uppercase "A" is reported as 65 by all events.
    /// </para>
    /// <para>
    /// The event target of a key event is the currently focused element which is processing the keyboard activity.
    /// This includes: &lt;input&gt;, &lt;textarea&gt;, anything that is contentEditable, and anything else that can be interacted with the keyboard, such as &lt;a&gt;, &lt;button&gt;, and &lt;summary&gt;.
    /// If no suitable element is in focus, the event target will be the &lt;body&gt; or the root. The event bubbles. It can reach Document and Window.
    /// </para>
    /// <para>
    /// The event target might change between different key events.
    /// For example, the keydown target for pressing the Tab key would be different from the keyup target, because the focus has changed.
    /// </para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent">KeyboardEvent</see> interface.</para>
    /// </summary>
    public event Action<KeyboardEvent> OnKeyDown {
        add {
            if (_onKeyDown == null)
                _ = ActivateJSEvent("activateOnkeydown").Preserve();
            _onKeyDown += value;
        }
        remove {
            _onKeyDown -= value;
            if (_onKeyDown == null)
                _ = DeactivateJSEvent("deactivateOnkeydown").Preserve();
        }
    }

    private Action<KeyboardEvent>? _onKeyUp;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired when a key is released.</para>
    /// <para>
    /// The keydown and keyup events provide a code indicating which key is pressed, while keypress indicates which character was entered.
    /// For example, a lowercase "a" will be reported as 65 by keydown and keyup, but as 97 by keypress. An uppercase "A" is reported as 65 by all events.
    /// </para>
    /// <para>
    /// The event target of a key event is the currently focused element which is processing the keyboard activity.
    /// This includes: &lt;input&gt;, &lt;textarea&gt;, anything that is contentEditable, and anything else that can be interacted with the keyboard, such as &lt;a&gt;, &lt;button&gt;, and &lt;summary&gt;.
    /// If no suitable element is in focus, the event target will be the &lt;body&gt; or the root. The event bubbles. It can reach Document and Window.
    /// </para>
    /// <para>
    /// The event target might change between different key events.
    /// For example, the keydown target for pressing the Tab key would be different from the keyup target, because the focus has changed.
    /// </para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent">KeyboardEvent</see> interface.</para>
    /// </summary>
    public event Action<KeyboardEvent> OnKeyUp {
        add {
            if (_onKeyUp == null)
                _ = ActivateJSEvent("activateOnkeyup").Preserve();
            _onKeyUp += value;
        }
        remove {
            _onKeyUp -= value;
            if (_onKeyUp == null)
                _ = DeactivateJSEvent("deactivateOnkeyup").Preserve();
        }
    }


    private Action<MouseEvent>? _onClick;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// An element receives a click event when any of the following occurs:<br />
    /// - A pointing-device button (such as a mouse's primary button) is both pressed and released while the pointer is located inside the element.<br />
    /// - A touch gesture is performed on the element.<br />
    /// - Any user interaction that is equivalent to a click, such as pressing the Space key or Enter key while the element is focused.<br />
    /// Note that this only applies to elements with a default key event handler, and therefore, excludes other elements that have been made focusable by setting the tabindex attribute.
    /// </para>
    /// <para>
    /// If the button is pressed on one element and the pointer is moved outside the element before the button is released,
    /// the event is fired on the most specific ancestor element that contained both elements.
    /// </para>
    /// <para>click fires after both the mousedown and mouseup events have fired, in that order.</para>
    /// <para>The event is a device-independent event — meaning it can be activated by touch, keyboard, mouse, and any other mechanism provided by assistive technology.</para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/MouseEvent">MouseEvent</see> interface.</para>
    /// </summary>
    public event Action<MouseEvent> OnClick {
        add {
            if (_onClick == null)
                _ = ActivateJSEvent("activateOnclick").Preserve();
            _onClick += value;
        }
        remove {
            _onClick -= value;
            if (_onClick == null)
                _ = DeactivateJSEvent("deactivateOnclick").Preserve();
        }
    }

    private Action<MouseEvent>? _onDblClick;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fires when a pointing device button (such as a mouse's primary button) is double-clicked; that is, when it's rapidly clicked twice on a single element within a very short span of time.</para>
    /// <para>dblclick fires after two click events (and by extension, after two pairs of mousedown and mouseup events).</para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/MouseEvent">MouseEvent</see> interface.</para>
    /// </summary>
    public event Action<MouseEvent> OnDblClick {
        add {
            if (_onDblClick == null)
                _ = ActivateJSEvent("activateOndblclick").Preserve();
            _onDblClick += value;
        }
        remove {
            _onDblClick -= value;
            if (_onDblClick == null)
                _ = DeactivateJSEvent("deactivateOndblclick").Preserve();
        }
    }

    private Action<MouseEvent>? _onAuxClick;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired at an Element when a non-primary pointing device button (any mouse button other than the primary—usually leftmost—button) has been pressed and released both within the same element.</para>
    /// <para>auxclick is fired after the mousedown and mouseup events have been fired, in that order.</para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/MouseEvent">MouseEvent</see> interface.</para>
    /// </summary>
    public event Action<MouseEvent> OnAuxClick {
        add {
            if (_onAuxClick == null)
                _ = ActivateJSEvent("activateOnauxclick").Preserve();
            _onAuxClick += value;
        }
        remove {
            _onAuxClick -= value;
            if (_onAuxClick == null)
                _ = DeactivateJSEvent("deactivateOnauxclick").Preserve();
        }
    }

    private Action<MouseEvent>? _onContextMenu;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fires when the user attempts to open a context menu. This event is typically triggered by clicking the right mouse button, or by pressing the context menu key.</para>
    /// <para>
    /// In the latter case, the context menu is displayed at the bottom left of the focused element,
    /// unless the element is a tree, in which case the context menu is displayed at the bottom left of the current row.
    /// </para>
    /// <para>Any right-click event that is not disabled (by calling the click event's preventDefault() method) will result in a contextmenu event being fired at the targeted element.</para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/MouseEvent">MouseEvent</see> interface.</para>
    /// </summary>
    /// <remarks>Note: An exception to this in Firefox: if the user holds down the Shift key while right-clicking, then the context menu will be shown without a contextmenu event being fired.</remarks>
    public event Action<MouseEvent> OnContextMenu {
        add {
            if (_onContextMenu == null)
                _ = ActivateJSEvent("activateOncontextmenu").Preserve();
            _onContextMenu += value;
        }
        remove {
            _onContextMenu -= value;
            if (_onContextMenu == null)
                _ = DeactivateJSEvent("deactivateOncontextmenu").Preserve();
        }
    }

    private Action<MouseEvent>? _onMouseDown;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired at an Element when a pointing device button is pressed while the pointer is inside the element.</para>
    /// <para>
    /// This differs from the click event in that click is fired after a full click action occurs;
    /// that is, the mouse button is pressed and released while the pointer remains inside the same element.
    /// mousedown is fired the moment the button is initially pressed.
    /// </para>
    /// <para>
    /// This behavior is different from pointerdown events.
    /// When using a physical mouse, mousedown events fire whenever any button on a mouse is pressed down.
    /// pointerdown events fire only upon the first button press; subsequent button presses don't fire pointerdown events.
    /// </para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/MouseEvent">MouseEvent</see> interface.</para>
    /// </summary>
    public event Action<MouseEvent> OnMouseDown {
        add {
            if (_onMouseDown == null)
                _ = ActivateJSEvent("activateOnmousedown").Preserve();
            _onMouseDown += value;
        }
        remove {
            _onMouseDown -= value;
            if (_onMouseDown == null)
                _ = DeactivateJSEvent("deactivateOnmousedown").Preserve();
        }
    }

    private Action<MouseEvent>? _onMouseUp;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired at an Element when a button on a pointing device (such as a mouse or trackpad) is released while the pointer is located inside it.</para>
    /// <para>mouseup events are the counterpoint to mousedown events.</para>
    /// <para>
    /// This behavior is different from pointerup events.
    /// When using a physical mouse, mouseup events fire whenever any button on a mouse is released.
    /// pointerup events fire only upon the last button release; previous button releases, while other buttons are held down, don't fire pointerup events.
    /// </para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/MouseEvent">MouseEvent</see> interface.</para>
    /// </summary>
    public event Action<MouseEvent> OnMouseUp {
        add {
            if (_onMouseUp == null)
                _ = ActivateJSEvent("activateOnmouseup").Preserve();
            _onMouseUp += value;
        }
        remove {
            _onMouseUp -= value;
            if (_onMouseUp == null)
                _ = DeactivateJSEvent("deactivateOnmouseup").Preserve();
        }
    }

    private Action<WheelEvent>? _onWheel;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fires when the user rotates a wheel button on a pointing device (typically a mouse). It is also fired for related devices that simulate wheel actions, such as trackpads and mouse balls.</para>
    /// <para>This event replaces the non-standard deprecated mousewheel event.</para>
    /// <para>
    /// Don't confuse the wheel event with the scroll event:<br />
    /// - A wheel event doesn't necessarily dispatch a scroll event. For example, the element may be unscrollable at all. Zooming actions using the wheel or trackpad also fire wheel events (with ctrlKey set to true).<br />
    /// - A scroll event isn't necessarily triggered by a wheel event. Elements can also be scrolled by using the keyboard, dragging a scrollbar, or using JavaScript.<br />
    /// - Even when the wheel event does trigger scrolling, the delta* values in the wheel event don't necessarily reflect the content's scrolling direction.<br />
    /// Therefore, do not rely on the wheel event's delta* properties to get the scrolling direction. Instead, detect value changes of scrollLeft and scrollTop of the target in the scroll event.
    /// </para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/WheelEvent">WheelEvent</see> interface.</para>
    /// </summary>
    public event Action<WheelEvent> OnWheel {
        add {
            if (_onWheel == null)
                _ = ActivateJSEvent("activateOnwheel").Preserve();
            _onWheel += value;
        }
        remove {
            _onWheel -= value;
            if (_onWheel == null)
                _ = DeactivateJSEvent("deactivateOnwheel").Preserve();
        }
    }

    private Action<MouseEvent>? _onMouseMove;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired at an element when a pointing device (usually a mouse) is moved while the cursor's hotspot is inside it.</para>
    /// <para>
    /// These events happen whether or not any mouse buttons are pressed.
    /// They can fire at a very high rate, depends on how fast the user moves the mouse, how fast the machine is, what other tasks and processes are happening, etc.
    /// </para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/MouseEvent">MouseEvent</see> interface.</para>
    /// </summary>
    public event Action<MouseEvent> OnMouseMove {
        add {
            if (_onMouseMove == null)
                _ = ActivateJSEvent("activateOnmousemove").Preserve();
            _onMouseMove += value;
        }
        remove {
            _onMouseMove -= value;
            if (_onMouseMove == null)
                _ = DeactivateJSEvent("deactivateOnmousemove").Preserve();
        }
    }

    private Action<MouseEvent>? _onMouseOver;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired at an Element when a pointing device (such as a mouse or trackpad) is used to move the cursor onto the element or one of its child elements.</para>
    /// <para>
    /// If the target element has child elements, mouseout and mouseover events fire as the mouse moves over the boundaries of these elements too, not just the target element itself.
    /// Usually, mouseenter and mouseleave events' behavior is more sensible, because they are not affected by moving into child elements.
    /// </para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/MouseEvent">MouseEvent</see> interface.</para>
    /// </summary>
    public event Action<MouseEvent> OnMouseOver {
        add {
            if (_onMouseOver == null)
                _ = ActivateJSEvent("activateOnmouseover").Preserve();
            _onMouseOver += value;
        }
        remove {
            _onMouseOver -= value;
            if (_onMouseOver == null)
                _ = DeactivateJSEvent("deactivateOnmouseover").Preserve();
        }
    }

    private Action<MouseEvent>? _onMouseOut;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired at an Element when a pointing device (usually a mouse) is used to move the cursor so that it is no longer contained within the element or one of its children.</para>
    /// <para>mouseout is also delivered to an element if the cursor enters a child element, because the child element obscures the visible area of the element.</para>
    /// <para>
    /// If the target element has child elements, mouseout and mouseover events fire as the mouse moves over the boundaries of these elements too, not just the target element itself.
    /// Usually, mouseenter and mouseleave events' behavior is more sensible, because they are not affected by moving into child elements.
    /// </para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/MouseEvent">MouseEvent</see> interface.</para>
    /// </summary>
    public event Action<MouseEvent> OnMouseOut {
        add {
            if (_onMouseOut == null)
                _ = ActivateJSEvent("activateOnmouseout").Preserve();
            _onMouseOut += value;
        }
        remove {
            _onMouseOut -= value;
            if (_onMouseOut == null)
                _ = DeactivateJSEvent("deactivateOnmouseout").Preserve();
        }
    }

    private Action<MouseEvent>? _onMouseEnter;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired at an Element when a pointing device (usually a mouse) is initially moved so that its hotspot is within the element at which the event was fired.</para>
    /// <para>
    /// Note that "moving into an element" refers to the element's position in the DOM tree, not to its visual position.
    /// For example, if a child element is positioned so it is placed outside its parent,
    /// then moving into the child element will trigger mouseenter on the parent element, even though the pointer is still outside the bounds of the parent element.
    /// </para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/MouseEvent">MouseEvent</see> interface.</para>
    /// </summary>
    public event Action<MouseEvent> OnMouseEnter {
        add {
            if (_onMouseEnter == null)
                _ = ActivateJSEvent("activateOnmouseenter").Preserve();
            _onMouseEnter += value;
        }
        remove {
            _onMouseEnter -= value;
            if (_onMouseEnter == null)
                _ = DeactivateJSEvent("deactivateOnmouseenter").Preserve();
        }
    }

    private Action<MouseEvent>? _onMouseLeave;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired at an Element when the cursor of a pointing device (usually a mouse) is moved out of it.</para>
    /// <para>
    /// mouseleave and mouseout are similar but differ in that mouseleave does not bubble and mouseout does.
    /// This means that mouseleave is fired when the pointer has exited the element and all of its descendants,
    /// whereas mouseout is fired when the pointer leaves the element or leaves one of the element's descendants, because of bubbling (even if the pointer is still within the element).
    /// Other than that, leave and out events for the same situation are dispatched at the same time, if appropriate.
    /// </para>
    /// <para>The mouseleave and mouseout events will not be triggered when the element is replaced or removed from the DOM.</para>
    /// <para>
    /// Note that "moving out of an element" refers to the element's position in the DOM tree, not to its visual position.
    /// For example, if two sibling elements are positioned so one is placed inside the other,
    /// then moving from the outer element into the inner element will trigger mouseleave on the outer element, even though the pointer is still in the bounds of the outer element.
    /// </para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/MouseEvent">MouseEvent</see> interface.</para>
    /// </summary>
    public event Action<MouseEvent> OnMouseLeave {
        add {
            if (_onMouseLeave == null)
                _ = ActivateJSEvent("activateOnmouseleave").Preserve();
            _onMouseLeave += value;
        }
        remove {
            _onMouseLeave -= value;
            if (_onMouseLeave == null)
                _ = DeactivateJSEvent("deactivateOnmouseleave").Preserve();
        }
    }


    private Action<TouchEvent>? _onTouchStart;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired when one or more touch points are placed on the touch surface.</para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/TouchEvent">TouchEvent</see> interface.</para>
    /// </summary>
    public event Action<TouchEvent> OnTouchStart {
        add {
            if (_onTouchStart == null)
                _ = ActivateJSEvent("activateOntouchstart").Preserve();
            _onTouchStart += value;
        }
        remove {
            _onTouchStart -= value;
            if (_onTouchStart == null)
                _ = DeactivateJSEvent("deactivateOntouchstart").Preserve();
        }
    }

    private Action<TouchEvent>? _onTouchEnd;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fires when one or more touch points are removed from the touch surface. Remember that it is possible to get a touchcancel event instead.</para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/TouchEvent">TouchEvent</see> interface.</para>
    /// </summary>
    public event Action<TouchEvent> OnTouchEnd {
        add {
            if (_onTouchEnd == null)
                _ = ActivateJSEvent("activateOntouchend").Preserve();
            _onTouchEnd += value;
        }
        remove {
            _onTouchEnd -= value;
            if (_onTouchEnd == null)
                _ = DeactivateJSEvent("deactivateOntouchend").Preserve();
        }
    }

    private Action<TouchEvent>? _onTouchMove;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired when one or more touch points are moved along the touch surface.</para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/TouchEvent">TouchEvent</see> interface.</para>
    /// </summary>
    public event Action<TouchEvent> OnTouchMove {
        add {
            if (_onTouchMove == null)
                _ = ActivateJSEvent("activateOntouchmove").Preserve();
            _onTouchMove += value;
        }
        remove {
            _onTouchMove -= value;
            if (_onTouchMove == null)
                _ = DeactivateJSEvent("deactivateOntouchmove").Preserve();
        }
    }

    private Action<TouchEvent>? _onTouchCancel;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired when one or more touch points have been disrupted in an implementation-specific manner.</para>
    /// <para>
    /// Some examples of situations that will trigger a touchcancel event:<br />
    /// - A hardware event occurs that cancels the touch activities.
    /// This may include, for example, the user switching applications using an application switcher interface or the "home" button on a mobile device.<br />
    /// - The device's screen orientation is changed while the touch is active.<br />
    /// - The browser decides that the user started touch input accidentally.
    /// This can happen if, for example, the hardware supports palm rejection to prevent a hand resting on the display while using a stylus from accidentally triggering events.<br />
    /// - The touch-action CSS property prevents the input from continuing.<br />
    /// - When the user interacts with too many fingers simultaneously, the browser can fire this event for all existing pointers (even if the user is still touching the screen).
    /// </para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/TouchEvent">TouchEvent</see> interface.</para>
    /// </summary>
    public event Action<TouchEvent> OnTouchCancel {
        add {
            if (_onTouchCancel == null)
                _ = ActivateJSEvent("activateOntouchcancel").Preserve();
            _onTouchCancel += value;
        }
        remove {
            _onTouchCancel -= value;
            if (_onTouchCancel == null)
                _ = DeactivateJSEvent("deactivateOntouchcancel").Preserve();
        }
    }


    private Action<PointerEvent>? _onPointerDown;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// Is fired when a pointer becomes active.
    /// For mouse, it is fired when the device transitions from no buttons pressed to at least one button pressed.
    /// For touch, it is fired when physical contact is made with the digitizer.
    /// For pen, it is fired when the stylus makes physical contact with the digitizer.
    /// </para>
    /// <para>
    /// This behavior is different from mousedown events.
    /// When using a physical mouse, mousedown events fire whenever any button on a mouse is pressed down.
    /// pointerdown events fire only upon the first button press; subsequent button presses don't fire pointerdown events.
    /// </para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/PointerEvent">PointerEvent</see> interface.</para>
    /// </summary>
    /// <remarks>
    /// Note: For touchscreen browsers that allow direct manipulation,
    /// a pointerdown event triggers implicit pointer capture, which causes the target to capture all subsequent pointer events as if they were occurring over the capturing target.
    /// Accordingly, pointerover, pointerenter, pointerleave, and pointerout will not fire as long as this capture is set.
    /// The capture can be released manually by calling element.releasePointerCapture on the target element, or it will be implicitly released after a pointerup or pointercancel event.
    /// </remarks>
    public event Action<PointerEvent> OnPointerDown {
        add {
            if (_onPointerDown == null)
                _ = ActivateJSEvent("activateOnpointerdown").Preserve();
            _onPointerDown += value;
        }
        remove {
            _onPointerDown -= value;
            if (_onPointerDown == null)
                _ = DeactivateJSEvent("deactivateOnpointerdown").Preserve();
        }
    }

    private Action<PointerEvent>? _onPointerUp;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired when a pointer is no longer active. Remember that it is possible to get a pointercancel event instead.</para>
    /// <para>
    /// This behavior is different from mouseup events.
    /// When using a physical mouse, mouseup events fire whenever any button on a mouse is released.
    /// pointerup events fire only upon the last button release; previous button releases, while other buttons are held down, don't fire pointerup events.
    /// </para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/PointerEvent">PointerEvent</see> interface.</para>
    /// </summary>
    public event Action<PointerEvent> OnPointerUp {
        add {
            if (_onPointerUp == null)
                _ = ActivateJSEvent("activateOnpointerup").Preserve();
            _onPointerUp += value;
        }
        remove {
            _onPointerUp -= value;
            if (_onPointerUp == null)
                _ = DeactivateJSEvent("deactivateOnpointerup").Preserve();
        }
    }

    private Action<PointerEvent>? _onPointerMove;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// Is fired when a pointer changes coordinates, and the pointer has not been canceled by a browser touch-action.
    /// It's very similar to the mousemove event, but with more features.
    /// </para>
    /// <para>
    /// These events happen whether or not any pointer buttons are pressed.
    /// They can fire at a very high rate, depends on how fast the user moves the pointer, how fast the machine is, what other tasks and processes are happening, etc.
    /// </para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/PointerEvent">PointerEvent</see> interface.</para>
    /// </summary>
    public event Action<PointerEvent> OnPointerMove {
        add {
            if (_onPointerMove == null)
                _ = ActivateJSEvent("activateOnpointermove").Preserve();
            _onPointerMove += value;
        }
        remove {
            _onPointerMove -= value;
            if (_onPointerMove == null)
                _ = DeactivateJSEvent("deactivateOnpointermove").Preserve();
        }
    }

    private Action<PointerEvent>? _onPointerOver;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired when a pointing device is moved into an element's hit test boundaries.</para>
    /// <para>
    /// pointerover events have the same problems as mouseover.
    /// If the target element has child elements, pointerout and pointerover events fire as the pointer moves over the boundaries of these elements too, not just the target element itself.
    /// Usually, pointerenter and pointerleave events' behavior is more sensible, because they are not affected by moving into child elements.
    /// </para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/PointerEvent">PointerEvent</see> interface.</para>
    /// </summary>
    public event Action<PointerEvent> OnPointerOver {
        add {
            if (_onPointerOver == null)
                _ = ActivateJSEvent("activateOnpointerover").Preserve();
            _onPointerOver += value;
        }
        remove {
            _onPointerOver -= value;
            if (_onPointerOver == null)
                _ = DeactivateJSEvent("deactivateOnpointerover").Preserve();
        }
    }

    private Action<PointerEvent>? _onPointerOut;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// Is fired for several reasons including:<br />
    /// - pointing device is moved out of the hit test boundaries of an element<br />
    /// - firing the pointerup event for a device that does not support hover (see pointerup)<br />
    /// - after firing the pointercancel event (see pointercancel)<br />
    /// - when a pen stylus leaves the hover range detectable by the digitizer.
    /// </para>
    /// <para>
    /// pointerout events have the same problems as mouseout.
    /// If the target element has child elements, pointerout and pointerover events fire as the pointer moves over the boundaries of these elements too, not just the target element itself.
    /// Usually, pointerenter and pointerleave events' behavior is more sensible, because they are not affected by moving into child elements.
    /// </para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/PointerEvent">PointerEvent</see> interface.</para>
    /// </summary>
    public event Action<PointerEvent> OnPointerOut {
        add {
            if (_onPointerOut == null)
                _ = ActivateJSEvent("activateOnpointerout").Preserve();
            _onPointerOut += value;
        }
        remove {
            _onPointerOut -= value;
            if (_onPointerOut == null)
                _ = DeactivateJSEvent("deactivateOnpointerout").Preserve();
        }
    }

    private Action<PointerEvent>? _onPointerEnter;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// Fires when a pointing device is moved into the hit test boundaries of an element or one of its descendants,
    /// including as a result of a pointerdown event from a device that does not support hover (see pointerdown).
    /// Otherwise, pointerenter works the same as mouseenter, and are dispatched at the same time.
    /// They are also dispatched at the same time as mouseover and pointerover events, if appropriate.
    /// </para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/PointerEvent">PointerEvent</see> interface.</para>
    /// </summary>
    public event Action<PointerEvent> OnPointerEnter {
        add {
            if (_onPointerEnter == null)
                _ = ActivateJSEvent("activateOnpointerenter").Preserve();
            _onPointerEnter += value;
        }
        remove {
            _onPointerEnter -= value;
            if (_onPointerEnter == null)
                _ = DeactivateJSEvent("deactivateOnpointerenter").Preserve();
        }
    }

    private Action<PointerEvent>? _onPointerLeave;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// Is fired when a pointing device is moved out of the hit test boundaries of an element.
    /// For pen devices, this event is fired when the stylus leaves the hover range detectable by the digitizer.
    /// Otherwise, pointerleave works the same as mouseleave, and are dispatched at the same time.
    /// They are also dispatched at the same time as mouseout and pointerout events, if appropriate.
    /// </para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/PointerEvent">PointerEvent</see> interface.</para>
    /// </summary>
    public event Action<PointerEvent> OnPointerLeave {
        add {
            if (_onPointerLeave == null)
                _ = ActivateJSEvent("activateOnpointerleave").Preserve();
            _onPointerLeave += value;
        }
        remove {
            _onPointerLeave -= value;
            if (_onPointerLeave == null)
                _ = DeactivateJSEvent("deactivateOnpointerleave").Preserve();
        }
    }

    private Action<PointerEvent>? _onPointerCancel;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// Is fired when the browser determines that there are unlikely to be any more pointer events,
    /// or if after the pointerdown event is fired, the pointer is then used to manipulate the viewport by panning, zooming, or scrolling.
    /// </para>
    /// <para>
    /// Some examples of situations that will trigger a pointercancel event:<br />
    /// - A hardware event occurs that cancels the pointer activities.
    /// This may include, for example, the user switching applications using an application switcher interface or the "home" button on a mobile device.<br />
    /// - The device's screen orientation is changed while the pointer is active.<br />
    /// - The browser decides that the user started pointer input accidentally.
    /// This can happen if, for example, the hardware supports palm rejection to prevent a hand resting on the display while using a stylus from accidentally triggering events.<br />
    /// - The touch-action CSS property prevents the input from continuing.<br />
    /// - When the user interacts with too many simultaneous pointers, the browser can fire this event for all existing pointers (even if the user is still touching the screen).
    /// </para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/PointerEvent">PointerEvent</see> interface.</para>
    /// </summary>
    public event Action<PointerEvent> OnPointerCancel {
        add {
            if (_onPointerCancel == null)
                _ = ActivateJSEvent("activateOnpointercancel").Preserve();
            _onPointerCancel += value;
        }
        remove {
            _onPointerCancel -= value;
            if (_onPointerCancel == null)
                _ = DeactivateJSEvent("deactivateOnpointercancel").Preserve();
        }
    }

    private Action<PointerEvent>? _onPointerRawUpdate;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired when a pointer changes any properties that don't fire pointerdown or pointerup events. See pointermove for a list of these properties.</para>
    /// <para>
    /// The pointerrawupdate event may have coalesced events if there is already another pointerrawupdate event with the same pointer ID that hasn't been dispatched in the event loop.
    /// For information on coalesced events, see the <see href="https://developer.mozilla.org/en-US/docs/Web/API/PointerEvent/getCoalescedEvents">PointerEvent.getCoalescedEvents()</see> documentation.
    /// </para>
    /// <para>
    /// pointerrawupdate is intended for applications that require high-precision input handling and cannot achieve smooth interaction using coalesced pointermove events alone.
    /// However, because listening to pointerrawupdate events can affect performance,
    /// you should add these listeners only if your JavaScript needs high-frequency events and can handle them as quickly as they are dispatched.
    /// For most use cases, other pointer event types should suffice.
    /// </para>
    /// <para>This event bubbles and is composed, but is not cancelable and has no default action.</para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/PointerEvent">PointerEvent</see> interface.</para>
    /// </summary>
    public event Action<PointerEvent> OnPointerRawUpdate {
        add {
            if (_onPointerRawUpdate == null)
                _ = ActivateJSEvent("activateOnpointerrawupdate").Preserve();
            _onPointerRawUpdate += value;
        }
        remove {
            _onPointerRawUpdate -= value;
            if (_onPointerRawUpdate == null)
                _ = DeactivateJSEvent("deactivateOnpointerrawupdate").Preserve();
        }
    }

    private Action<PointerEvent>? _onGotPointerCapture;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired when an element captures a pointer using <i>SetPointerCapture()</i>.</para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/PointerEvent">PointerEvent</see> interface.</para>
    /// </summary>
    public event Action<PointerEvent> OnGotPointerCapture {
        add {
            if (_onGotPointerCapture == null)
                _ = ActivateJSEvent("activateOngotpointercapture").Preserve();
            _onGotPointerCapture += value;
        }
        remove {
            _onGotPointerCapture -= value;
            if (_onGotPointerCapture == null)
                _ = DeactivateJSEvent("deactivateOngotpointercapture").Preserve();
        }
    }

    private Action<PointerEvent>? _onLostPointerCapture;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired when a captured pointer is released.</para>
    /// <para>The parameter represents the <see href="https://developer.mozilla.org/en-US/docs/Web/API/PointerEvent">PointerEvent</see> interface.</para>
    /// </summary>
    public event Action<PointerEvent> OnLostPointerCapture {
        add {
            if (_onLostPointerCapture == null)
                _ = ActivateJSEvent("activateOnlostpointercapture").Preserve();
            _onLostPointerCapture += value;
        }
        remove {
            _onLostPointerCapture -= value;
            if (_onLostPointerCapture == null)
                _ = DeactivateJSEvent("deactivateOnlostpointercapture").Preserve();
        }
    }


    private Action? _onFocusIn;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fires when an element has received focus, after the focus event. The two events differ in that focusin bubbles, while focus does not.</para>
    /// <para>The opposite of focusin is the focusout event, which fires when the element has lost focus.</para>
    /// <para>The focusin event is not cancelable.</para>
    /// </summary>
    public event Action OnFocusIn {
        add {
            if (_onFocusIn == null)
                _ = ActivateJSEvent("activateOnfocusin").Preserve();
            _onFocusIn += value;
        }
        remove {
            _onFocusIn -= value;
            if (_onFocusIn == null)
                _ = DeactivateJSEvent("deactivateOnfocusin").Preserve();
        }
    }

    private Action? _onFocusOut;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fires when an element has lost focus, after the blur event. The two events differ in that focusout bubbles, while blur does not.</para>
    /// <para>The opposite of focusout is the focusin event, which fires when the element has received focus.</para>
    /// <para>The focusout event is not cancelable.</para>
    /// </summary>
    public event Action OnFocusOut {
        add {
            if (_onFocusOut == null)
                _ = ActivateJSEvent("activateOnfocusout").Preserve();
            _onFocusOut += value;
        }
        remove {
            _onFocusOut -= value;
            if (_onFocusOut == null)
                _ = DeactivateJSEvent("deactivateOnfocusout").Preserve();
        }
    }


    private Action? _onCopy;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fires when the user initiates a copy action through the browser's user interface.</para>
    /// <para>The event's default action is to copy the selection (if any) to the clipboard.</para>
    /// <para>However, the handler cannot read the clipboard data.</para>
    /// <para>
    /// It's possible to construct and dispatch a <see href="https://developer.mozilla.org/en-US/docs/Web/API/Document_Object_Model/Events#creating_and_dispatching_events">synthetic</see> copy event,
    /// but this will not affect the system clipboard.
    /// </para>
    /// <para>This event bubbles up the DOM tree, eventually to Document and Window, is cancelable and is composed.</para>
    /// </summary>
    public event Action OnCopy {
        add {
            if (_onCopy == null)
                _ = ActivateJSEvent("activateOncopy").Preserve();
            _onCopy += value;
        }
        remove {
            _onCopy -= value;
            if (_onCopy == null)
                _ = DeactivateJSEvent("deactivateOncopy").Preserve();
        }
    }

    private Action? _onPaste;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired when the user has initiated a "paste" action through the browser's user interface.</para>
    /// <para>
    /// If the cursor is in an editable context (for example, in a &lt;textarea&gt; or an element with contenteditable attribute set to true)
    /// then the default action is to insert the contents of the clipboard into the document at the cursor position.
    /// </para>
    /// <para>
    /// It's possible to construct and dispatch a <see href="https://developer.mozilla.org/en-US/docs/Web/API/Document_Object_Model/Events#creating_and_dispatching_events">synthetic</see> paste event,
    /// but this will not affect the document's contents.
    /// </para>
    /// <para>This event bubbles up the DOM tree, eventually to Document and Window, is cancelable and is composed.</para>
    /// </summary>
    public event Action OnPaste {
        add {
            if (_onPaste == null)
                _ = ActivateJSEvent("activateOnpaste").Preserve();
            _onPaste += value;
        }
        remove {
            _onPaste -= value;
            if (_onPaste == null)
                _ = DeactivateJSEvent("deactivateOnpaste").Preserve();
        }
    }

    private Action? _onCut;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired when the user has initiated a "cut" action through the browser's user interface.</para>
    /// <para>If the user attempts a cut action on uneditable content, the cut event still fires but the event object contains no data.</para>
    /// <para>The event's default action is to copy the current selection (if any) to the system clipboard and remove it from the document.</para>
    /// <para>The handler cannot read the clipboard data.</para>
    /// <para>
    /// It's possible to construct and dispatch a <see href="https://developer.mozilla.org/en-US/docs/Web/API/Document_Object_Model/Events#creating_and_dispatching_events">synthetic</see> cut event,
    /// but this will not affect the system clipboard or the document's contents.
    /// </para>
    /// <para>This event bubbles up the DOM tree, eventually to Document and Window, is cancelable and is composed.</para>
    /// </summary>
    public event Action OnCut {
        add {
            if (_onCut == null)
                _ = ActivateJSEvent("activateOncut").Preserve();
            _onCut += value;
        }
        remove {
            _onCut -= value;
            if (_onCut == null)
                _ = DeactivateJSEvent("deactivateOncut").Preserve();
        }
    }


    private Action<string, double, string>? _onTransitionStart;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired when a CSS transition has actually started, i.e., after any transition-delay has ended.</para>
    /// <para>This event is not cancelable.</para>
    /// <para>
    /// <b>Parameters</b><br />
    /// - string <i>propertyName</i>: A string containing the name CSS property associated with the transition.<br />
    /// - double <i>elapsedTime</i>: A float giving the amount of time the transition has been running, in seconds, when this event fired. This value is not affected by the transition-delay property.<br />
    /// - string <i>pseudoElement</i>: A string, starting with '::', containing the name of the pseudo-element the animation runs on. If the transition doesn't run on a pseudo-element but on the element, an empty string.
    /// </para>
    /// </summary>
    public event Action<string, double, string> OnTransitionStart {
        add {
            if (_onTransitionStart == null)
                _ = ActivateJSEvent("activateOntransitionstart").Preserve();
            _onTransitionStart += value;
        }
        remove {
            _onTransitionStart -= value;
            if (_onTransitionStart == null)
                _ = DeactivateJSEvent("deactivateOntransitionstart").Preserve();
        }
    }

    private Action<string, double, string>? _onTransitionEnd;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// Is fired when a CSS transition has completed.
    /// In the case where a transition is removed before completion, such as if the transition-property is removed or display is set to none, then the event will not be generated.
    /// </para>
    /// <para>
    /// The <i>transitionend</i> event is fired in both directions - as it finishes transitioning to the transitioned state, and when it fully reverts to the default or non-transitioned state.
    /// If there is no transition delay or duration, if both are 0s or neither is declared, there is no transition, and none of the transition events are fired.
    /// If the transitioncancel event is fired, the transitionend event will not fire.
    /// </para>
    /// <para>This event is not cancelable.</para>
    /// <para>
    /// <b>Parameters</b><br />
    /// - string <i>propertyName</i>: A string containing the name CSS property associated with the transition.<br />
    /// - double <i>elapsedTime</i>: A float giving the amount of time the transition has been running, in seconds, when this event fired. This value is not affected by the transition-delay property.<br />
    /// - string <i>pseudoElement</i>: A string, starting with '::', containing the name of the pseudo-element the animation runs on. If the transition doesn't run on a pseudo-element but on the element, an empty string.
    /// </para>
    /// </summary>
    public event Action<string, double, string> OnTransitionEnd {
        add {
            if (_onTransitionEnd == null)
                _ = ActivateJSEvent("activateOntransitionend").Preserve();
            _onTransitionEnd += value;
        }
        remove {
            _onTransitionEnd -= value;
            if (_onTransitionEnd == null)
                _ = DeactivateJSEvent("deactivateOntransitionend").Preserve();
        }
    }

    private Action<string, double, string>? _onTransitionRun;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired when a CSS transition is first created, i.e. before any transition-delay has begun.</para>
    /// <para>This event is not cancelable.</para>
    /// <para>
    /// <b>Parameters</b><br />
    /// - string <i>propertyName</i>: A string containing the name CSS property associated with the transition.<br />
    /// - double <i>elapsedTime</i>: A float giving the amount of time the transition has been running, in seconds, when this event fired. This value is not affected by the transition-delay property.<br />
    /// - string <i>pseudoElement</i>: A string, starting with '::', containing the name of the pseudo-element the animation runs on. If the transition doesn't run on a pseudo-element but on the element, an empty string.
    /// </para>
    /// </summary>
    public event Action<string, double, string> OnTransitionRun {
        add {
            if (_onTransitionRun == null)
                _ = ActivateJSEvent("activateOntransitionrun").Preserve();
            _onTransitionRun += value;
        }
        remove {
            _onTransitionRun -= value;
            if (_onTransitionRun == null)
                _ = DeactivateJSEvent("deactivateOntransitionrun").Preserve();
        }
    }

    private Action<string, double, string>? _onTransitionCancel;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Is fired when a CSS transition is canceled.</para>
    /// <para>
    /// <b>Parameters</b><br />
    /// - string <i>propertyName</i>: A string containing the name CSS property associated with the transition.<br />
    /// - double <i>elapsedTime</i>: A float giving the amount of time the transition has been running, in seconds, when this event fired. This value is not affected by the transition-delay property.<br />
    /// - string <i>pseudoElement</i>: A string, starting with '::', containing the name of the pseudo-element the animation runs on. If the transition doesn't run on a pseudo-element but on the element, an empty string.
    /// </para>
    /// </summary>
    public event Action<string, double, string> OnTransitionCancel {
        add {
            if (_onTransitionCancel == null)
                _ = ActivateJSEvent("activateOntransitioncancel").Preserve();
            _onTransitionCancel += value;
        }
        remove {
            _onTransitionCancel -= value;
            if (_onTransitionCancel == null)
                _ = DeactivateJSEvent("deactivateOntransitioncancel").Preserve();
        }
    }


    private Action<string, double, string>? _onAnimationStart;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// Is fired when a CSS Animation has started.
    /// If there is an animation-delay, this event will fire once the delay period has expired.
    /// A negative delay will cause the event to fire with an elapsedTime equal to the absolute value of the delay (and, correspondingly, the animation will begin playing at that time index into the sequence).
    /// </para>
    /// <para>
    /// <b>Parameters</b><br />
    /// - string <i>animationName</i>: A string containing the value of the animation-name that generated the animation.<br />
    /// - double <i>elapsedTime</i>: A float giving the amount of time the animation has been running, in seconds, when this event fired, excluding any time the animation was paused.
    /// For an animationstart event, elapsedTime is 0.0 unless there was a negative value for animation-delay, in which case the event will be fired with elapsedTime containing (-1 * delay).<br />
    /// - string <i>pseudoElement</i>: A string, starting with '::', containing the name of the pseudo-element the animation runs on. If the transition doesn't run on a pseudo-element but on the element, an empty string.
    /// </para>
    /// </summary>
    public event Action<string, double, string> OnAnimationStart {
        add {
            if (_onAnimationStart == null)
                _ = ActivateJSEvent("activateOnanimationstart").Preserve();
            _onAnimationStart += value;
        }
        remove {
            _onAnimationStart -= value;
            if (_onAnimationStart == null)
                _ = DeactivateJSEvent("deactivateOnanimationstart").Preserve();
        }
    }

    private Action<string, double, string>? _onAnimationEnd;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// Is fired when a CSS Animation has completed.
    /// If the animation aborts before reaching completion, such as if the element is removed from the DOM or the animation is removed from the element, the animationend event is not fired.
    /// </para>
    /// <para>
    /// <b>Parameters</b><br />
    /// - string <i>animationName</i>: A string containing the value of the animation-name that generated the animation.<br />
    /// - double <i>elapsedTime</i>: A float giving the amount of time the animation has been running, in seconds, when this event fired, excluding any time the animation was paused.
    /// For an animationstart event, elapsedTime is 0.0 unless there was a negative value for animation-delay, in which case the event will be fired with elapsedTime containing (-1 * delay).<br />
    /// - string <i>pseudoElement</i>: A string, starting with '::', containing the name of the pseudo-element the animation runs on. If the transition doesn't run on a pseudo-element but on the element, an empty string.
    /// </para>
    /// </summary>
    public event Action<string, double, string> OnAnimationEnd {
        add {
            if (_onAnimationEnd == null)
                _ = ActivateJSEvent("activateOnanimationend").Preserve();
            _onAnimationEnd += value;
        }
        remove {
            _onAnimationEnd -= value;
            if (_onAnimationEnd == null)
                _ = DeactivateJSEvent("deactivateOnanimationend").Preserve();
        }
    }

    private Action<string, double, string>? _onAnimationIteration;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// Is fired when an iteration of a CSS Animation ends, and another one begins.
    /// This event does not occur at the same time as the animationend event, and therefore does not occur for animations with an animation-iteration-count of one.
    /// </para>
    /// <para>
    /// <b>Parameters</b><br />
    /// - string <i>animationName</i>: A string containing the value of the animation-name that generated the animation.<br />
    /// - double <i>elapsedTime</i>: A float giving the amount of time the animation has been running, in seconds, when this event fired, excluding any time the animation was paused.
    /// For an animationstart event, elapsedTime is 0.0 unless there was a negative value for animation-delay, in which case the event will be fired with elapsedTime containing (-1 * delay).<br />
    /// - string <i>pseudoElement</i>: A string, starting with '::', containing the name of the pseudo-element the animation runs on. If the transition doesn't run on a pseudo-element but on the element, an empty string.
    /// </para>
    /// </summary>
    public event Action<string, double, string> OnAnimationIteration {
        add {
            if (_onAnimationIteration == null)
                _ = ActivateJSEvent("activateOnanimationiteration").Preserve();
            _onAnimationIteration += value;
        }
        remove {
            _onAnimationIteration -= value;
            if (_onAnimationIteration == null)
                _ = DeactivateJSEvent("deactivateOnanimationiteration").Preserve();
        }
    }

    private Action<string, double, string>? _onAnimationCancel;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>
    /// Is fired when a CSS Animation unexpectedly aborts.
    /// In other words, any time it stops running without sending an animationend event.
    /// This might happen when the animation-name is changed such that the animation is removed, or when the animating node is hidden using CSS.
    /// Therefore, either directly or because any of its containing nodes are hidden.
    /// </para>
    /// <para>An event handler for this event can be added by setting the onanimationcancel property, or using addEventListener().</para>
    /// <para>
    /// <b>Parameters</b><br />
    /// - string <i>animationName</i>: A string containing the value of the animation-name that generated the animation.<br />
    /// - double <i>elapsedTime</i>: A float giving the amount of time the animation has been running, in seconds, when this event fired, excluding any time the animation was paused.
    /// For an animationstart event, elapsedTime is 0.0 unless there was a negative value for animation-delay, in which case the event will be fired with elapsedTime containing (-1 * delay).<br />
    /// - string <i>pseudoElement</i>: A string, starting with '::', containing the name of the pseudo-element the animation runs on. If the transition doesn't run on a pseudo-element but on the element, an empty string.
    /// </para>
    /// </summary>
    public event Action<string, double, string> OnAnimationCancel {
        add {
            if (_onAnimationCancel == null)
                _ = ActivateJSEvent("activateOnanimationcancel").Preserve();
            _onAnimationCancel += value;
        }
        remove {
            _onAnimationCancel -= value;
            if (_onAnimationCancel == null)
                _ = DeactivateJSEvent("deactivateOnanimationcancel").Preserve();
        }
    }


    // HTMLMediaElement - Ready Events

    private Action? _onCanPlay;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fired when the user agent can play the media, but estimates that not enough data has been loaded to play the media up to its end without having to stop for further buffering of content.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnCanPlay {
        add {
            if (_onCanPlay == null)
                _ = ActivateJSEvent("activateOncanplay").Preserve();
            _onCanPlay += value;
        }
        remove {
            _onCanPlay -= value;
            if (_onCanPlay == null)
                _ = DeactivateJSEvent("deactivateOncanplay").Preserve();
        }
    }

    private Action? _onCanPlayThrough;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fired when the user agent can play the media, and estimates that enough data has been loaded to play the media up to its end without having to stop for further buffering of content.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnCanPlayThrough {
        add {
            if (_onCanPlayThrough == null)
                _ = ActivateJSEvent("activateOncanplaythrough").Preserve();
            _onCanPlayThrough += value;
        }
        remove {
            _onCanPlayThrough -= value;
            if (_onCanPlayThrough == null)
                _ = DeactivateJSEvent("deactivateOncanplaythrough").Preserve();
        }
    }

    private Action? _onPlaying;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fired after playback is first started, and whenever it is restarted. For example it is fired when playback resumes after having been paused or delayed due to lack of data.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnPlaying {
        add {
            if (_onPlaying == null)
                _ = ActivateJSEvent("activateOnplaying").Preserve();
            _onPlaying += value;
        }
        remove {
            _onPlaying -= value;
            if (_onPlaying == null)
                _ = DeactivateJSEvent("deactivateOnplaying").Preserve();
        }
    }

    // HTMLMediaElement - Data Events

    private Action? _onLoadStart;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// Fired when the browser has started to load a resource.
    /// </summary>
    public event Action OnLoadStart {
        add {
            if (_onLoadStart == null)
                _ = ActivateJSEvent("activateOnloadstart").Preserve();
            _onLoadStart += value;
        }
        remove {
            _onLoadStart -= value;
            if (_onLoadStart == null)
                _ = DeactivateJSEvent("deactivateOnloadstart").Preserve();
        }
    }

    private Action? _onProgress;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fired periodically as the browser loads a resource.></para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnProgress {
        add {
            if (_onProgress == null)
                _ = ActivateJSEvent("activateOnprogress").Preserve();
            _onProgress += value;
        }
        remove {
            _onProgress -= value;
            if (_onProgress == null)
                _ = DeactivateJSEvent("deactivateOnprogress").Preserve();
        }
    }

    private Action? _onLoadedData;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// Fired when the first frame of the media has finished loading; often the first frame.
    /// </summary>
    public event Action OnLoadedData {
        add {
            if (_onLoadedData == null)
                _ = ActivateJSEvent("activateOnloadeddata").Preserve();
            _onLoadedData += value;
        }
        remove {
            _onLoadedData -= value;
            if (_onLoadedData == null)
                _ = DeactivateJSEvent("deactivateOnloadeddata").Preserve();
        }
    }

    private Action? _onLoadedMetadata;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// Fired when the metadata has been loaded.
    /// </summary>
    public event Action OnLoadedMetadata {
        add {
            if (_onLoadedMetadata == null)
                _ = ActivateJSEvent("activateOnloadedmetadata").Preserve();
            _onLoadedMetadata += value;
        }
        remove {
            _onLoadedMetadata -= value;
            if (_onLoadedMetadata == null)
                _ = DeactivateJSEvent("deactivateOnloadedmetadata").Preserve();
        }
    }

    private Action? _onStalled;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fired when the user agent is trying to fetch media data, but data is unexpectedly not forthcoming.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnStalled {
        add {
            if (_onStalled == null)
                _ = ActivateJSEvent("activateOnstalled").Preserve();
            _onStalled += value;
        }
        remove {
            _onStalled -= value;
            if (_onStalled == null)
                _ = DeactivateJSEvent("deactivateOnstalled").Preserve();
        }
    }

    private Action? _onSuspend;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fired when the media data loading has been suspended.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnSuspend {
        add {
            if (_onSuspend == null)
                _ = ActivateJSEvent("activateOnsuspend").Preserve();
            _onSuspend += value;
        }
        remove {
            _onSuspend -= value;
            if (_onSuspend == null)
                _ = DeactivateJSEvent("deactivateOnsuspend").Preserve();
        }
    }

    private Action? _onWaiting;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fired when playback has stopped because of a temporary lack of data.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnWaiting {
        add {
            if (_onWaiting == null)
                _ = ActivateJSEvent("activateOnwaiting").Preserve();
            _onWaiting += value;
        }
        remove {
            _onWaiting -= value;
            if (_onWaiting == null)
                _ = DeactivateJSEvent("deactivateOnwaiting").Preserve();
        }
    }

    private Action? _onAbort;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fired when the resource was not fully loaded, but not as the result of an error.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnAbort {
        add {
            if (_onAbort == null)
                _ = ActivateJSEvent("activateOnabort").Preserve();
            _onAbort += value;
        }
        remove {
            _onAbort -= value;
            if (_onAbort == null)
                _ = DeactivateJSEvent("deactivateOnabort").Preserve();
        }
    }

    private Action? _onEmptied;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fired when the media has become empty; for example, when the media has already been loaded (or partially loaded), and the <see cref="HTMLMediaElement.Load">Load()</see> method is called to reload it.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnEmptied {
        add {
            if (_onEmptied == null)
                _ = ActivateJSEvent("activateOnemptied").Preserve();
            _onEmptied += value;
        }
        remove {
            _onEmptied -= value;
            if (_onEmptied == null)
                _ = DeactivateJSEvent("deactivateOnemptied").Preserve();
        }
    }

    // HTMLMediaElement - Timing Events

    private Action? _onPlay;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fired when the paused property is changed from true to false, as a result of the <see cref="IHTMLMediaElement.Play">Play()</see> method, or the autoplay attribute.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnPlay {
        add {
            if (_onPlay == null)
                _ = ActivateJSEvent("activateOnplay").Preserve();
            _onPlay += value;
        }
        remove {
            _onPlay -= value;
            if (_onPlay == null)
                _ = DeactivateJSEvent("deactivateOnplay").Preserve();
        }
    }

    private Action? _onPause;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fired when a request to pause play is handled and the activity has entered its paused state, most commonly occurring when the media's <see cref="HTMLMediaElement.Pause">Pause()</see> method is called.</para>
    /// <para>The event is sent once the <see cref="HTMLMediaElement.Pause">Pause()</see> method returns and after the media element's paused property has been changed to true.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnPause {
        add {
            if (_onPause == null)
                _ = ActivateJSEvent("activateOnpause").Preserve();
            _onPause += value;
        }
        remove {
            _onPause -= value;
            if (_onPause == null)
                _ = DeactivateJSEvent("deactivateOnpause").Preserve();
        }
    }

    private Action? _onEnded;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fired when playback stops when end of the media (&lt;audio&gt; and &lt;video&gt;) is reached or because no further data is available.</para>
    /// <para>This event occurs based upon HTMLMediaElement (&lt;audio&gt; and &lt;video&gt;) fire ended when playback reaches the end of the media.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnEnded {
        add {
            if (_onEnded == null)
                _ = ActivateJSEvent("activateOnended").Preserve();
            _onEnded += value;
        }
        remove {
            _onEnded -= value;
            if (_onEnded == null)
                _ = DeactivateJSEvent("deactivateOnended").Preserve();
        }
    }

    private Action? _onSeeking;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fired when a seek operation starts, meaning the Boolean seeking attribute has changed to true and the media is seeking a new position.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnSeeking {
        add {
            if (_onSeeking == null)
                _ = ActivateJSEvent("activateOnseeking").Preserve();
            _onSeeking += value;
        }
        remove {
            _onSeeking -= value;
            if (_onSeeking == null)
                _ = DeactivateJSEvent("deactivateOnseeking").Preserve();
        }
    }

    private Action? _onSeeked;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fired when a seek operation completed, the current playback position has changed, and the Boolean seeking attribute is changed to false.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnSeeked {
        add {
            if (_onSeeked == null)
                _ = ActivateJSEvent("activateOnseeked").Preserve();
            _onSeeked += value;
        }
        remove {
            _onSeeked -= value;
            if (_onSeeked == null)
                _ = DeactivateJSEvent("deactivateOnseeked").Preserve();
        }
    }

    private Action? _onTimeUpdate;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fired when the time indicated by the currentTime attribute has been updated.</para>
    /// <para>
    /// The event frequency is dependent on the system load, but will be thrown between about 4Hz and 66Hz (assuming the event handlers don't take longer than 250ms to run).
    /// User agents are encouraged to vary the frequency of the event based on the system load and the average cost of processing the event each time,
    /// so that the UI updates are not any more frequent than the user agent can comfortably handle while decoding the video.
    /// </para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnTimeUpdate {
        add {
            if (_onTimeUpdate == null)
                _ = ActivateJSEvent("activateOntimeupdate").Preserve();
            _onTimeUpdate += value;
        }
        remove {
            _onTimeUpdate -= value;
            if (_onTimeUpdate == null)
                _ = DeactivateJSEvent("deactivateOntimeupdate").Preserve();
        }
    }

    // HTMLMediaElement - Setting Events

    private Action? _onVolumeChange;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fired when either the volume attribute or the muted attribute has changed.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnVolumeChange {
        add {
            if (_onVolumeChange == null)
                _ = ActivateJSEvent("activateOnvolumechange").Preserve();
            _onVolumeChange += value;
        }
        remove {
            _onVolumeChange -= value;
            if (_onVolumeChange == null)
                _ = DeactivateJSEvent("deactivateOnvolumechange").Preserve();
        }
    }

    private Action? _onRateChange;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// <para>Fired when the playback rate has changed.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    public event Action OnRateChange {
        add {
            if (_onRateChange == null)
                _ = ActivateJSEvent("activateOnratechange").Preserve();
            _onRateChange += value;
        }
        remove {
            _onRateChange -= value;
            if (_onRateChange == null)
                _ = DeactivateJSEvent("deactivateOnratechange").Preserve();
        }
    }

    private Action? _onDurationChange;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// Fired when the duration attribute has been updated.
    /// </summary>
    public event Action OnDurationChange {
        add {
            if (_onDurationChange == null)
                _ = ActivateJSEvent("activateOndurationchange").Preserve();
            _onDurationChange += value;
        }
        remove {
            _onDurationChange -= value;
            if (_onDurationChange == null)
                _ = DeactivateJSEvent("deactivateOndurationchange").Preserve();
        }
    }


    // HTMLDialogElement

    private Action? _onClose;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// Is fired on an HTMLDialogElement object when the &lt;dialog&gt; it represents has been closed.
    /// </summary>
    public event Action OnClose {
        add {
            if (_onClose == null)
                _ = ActivateJSEvent("activateOnclose").Preserve();
            _onClose += value;
        }
        remove {
            _onClose -= value;
            if (_onClose == null)
                _ = DeactivateJSEvent("deactivateOnclose").Preserve();
        }
    }

    private Action? _onCancel;
    /// <summary>
    /// <para>Bubbled event invoked from child elements.</para>
    /// Fires on a &lt;dialog&gt; when the user instructs the browser that they wish to dismiss the current open dialog. The browser fires this event when the user presses the Esc key.
    /// </summary>
    public event Action OnCancel {
        add {
            if (_onCancel == null)
                _ = ActivateJSEvent("activateOncancel").Preserve();
            _onCancel += value;
        }
        remove {
            _onCancel -= value;
            if (_onCancel == null)
                _ = DeactivateJSEvent("deactivateOncancel").Preserve();
        }
    }

    #endregion
}
