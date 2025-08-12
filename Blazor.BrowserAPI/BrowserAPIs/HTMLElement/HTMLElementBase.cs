using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IHTMLElement")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IHTMLElementInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class HTMLElementBase(Task<IJSObjectReference> htmlElementTask) {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected Task<IJSObjectReference> htmlElementTask = htmlElementTask;


    /// <summary>
    /// <para>Issues an asynchronous request to make the element be displayed in fullscreen mode.</para>
    /// <para>
    /// It's not guaranteed that the element will be put into full screen mode.
    /// If permission to enter full screen mode is granted, the returned Promise will resolve and the element will receive a fullscreenchange event to let it know that it's now in full screen mode.
    /// If permission is denied, the promise is rejected and the element receives a fullscreenerror event instead.
    /// If the element has been detached from the original document, then the document receives these events instead.
    /// </para>
    /// </summary>
    /// <param name="navigationUI">
    /// Controls whether or not to show navigation UI while the element is in fullscreen mode.
    /// The default value is "auto", which indicates that the browser should decide what to do.<br />
    /// - "hide": The browser's navigation interface will be hidden and the entire dimensions of the screen will be allocated to the display of the element.<br />
    /// - "show": The browser will present page navigation controls and possibly other user interface;
    ///           the dimensions of the element (and the perceived size of the screen) will be clamped to leave room for this user interface..<br />
    /// - "auto": The browser will choose which of the above settings to apply. This is the default value.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask RequestFullscreen(string navigationUI = "auto", CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeVoidAsync("requestFullscreen", cancellationToken, [navigationUI]);

    /// <summary>
    /// Lets you asynchronously ask for the pointer to be locked on the given element.
    /// To track the success or failure of the request, it is necessary to listen for the pointerlockchange and pointerlockerror events at the Document level.
    /// </summary>
    /// <param name="unadjustedMovement">Disables OS-level adjustment for mouse acceleration, and accesses raw mouse input instead. The default value is false; setting it to true will disable mouse acceleration.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask RequestPointerLock(bool unadjustedMovement = false, CancellationToken cancellationToken = default)
        => await (await htmlElementTask).InvokeVoidAsync("requestPointerLock", cancellationToken, [unadjustedMovement]);


    #region Events

    [method: DynamicDependency(nameof(InvokeChange))]
    [method: DynamicDependency(nameof(InvokeCommand))]
    [method: DynamicDependency(nameof(InvokeLoad))]
    [method: DynamicDependency(nameof(InvokeError))]

    [method: DynamicDependency(nameof(InvokeDrag))]
    [method: DynamicDependency(nameof(InvokeDragStart))]
    [method: DynamicDependency(nameof(InvokeDragEnd))]
    [method: DynamicDependency(nameof(InvokeDragEnter))]
    [method: DynamicDependency(nameof(InvokeDragLeave))]
    [method: DynamicDependency(nameof(InvokeDragOver))]
    [method: DynamicDependency(nameof(InvokeDrop))]

    [method: DynamicDependency(nameof(InvokeToggle))]
    [method: DynamicDependency(nameof(InvokeBeforeToggle))]

    [method: DynamicDependency(nameof(InvokeTransitionStart))]
    [method: DynamicDependency(nameof(InvokeTransitionEnd))]
    [method: DynamicDependency(nameof(InvokeTransitionRun))]
    [method: DynamicDependency(nameof(InvokeTransitionCancel))]

    [method: DynamicDependency(nameof(InvokeAnimationStart))]
    [method: DynamicDependency(nameof(InvokeAnimationEnd))]
    [method: DynamicDependency(nameof(InvokeAnimationIteration))]
    [method: DynamicDependency(nameof(InvokeAnimationCancel))]
    private sealed class EventTrigger(HTMLElementBase htmlElement) {
        [JSInvokable] public void InvokeChange() => htmlElement._onChange?.Invoke();
        [JSInvokable] public void InvokeCommand(IJSObjectReference source, string command) => htmlElement.InvokeCommand(source, command);
        [JSInvokable] public void InvokeLoad() => htmlElement._onLoad?.Invoke();
        [JSInvokable] public void InvokeError(JsonElement errorEvent) => htmlElement._onError?.Invoke(errorEvent);

        [JSInvokable] public void InvokeDrag(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => htmlElement.InvokeDrag(dropEffect, effectAllowed, types, files);
        [JSInvokable] public void InvokeDragStart(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => htmlElement.InvokeDragStart(dropEffect, effectAllowed, types, files);
        [JSInvokable] public void InvokeDragEnd(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => htmlElement.InvokeDragEnd(dropEffect, effectAllowed, types, files);
        [JSInvokable] public void InvokeDragEnter(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => htmlElement.InvokeDragEnter(dropEffect, effectAllowed, types, files);
        [JSInvokable] public void InvokeDragLeave(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => htmlElement.InvokeDragLeave(dropEffect, effectAllowed, types, files);
        [JSInvokable] public void InvokeDragOver(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => htmlElement.InvokeDragOver(dropEffect, effectAllowed, types, files);
        [JSInvokable] public void InvokeDrop(string dropEffect, string effectAllowed, string[] types, IJSObjectReference[] files) => htmlElement.InvokeDrop(dropEffect, effectAllowed, types, files);

        [JSInvokable] public void InvokeToggle(string oldState, string newState) => htmlElement._onToggle?.Invoke(oldState, newState);
        [JSInvokable] public void InvokeBeforeToggle(string oldState, string newState) => htmlElement._onBeforeToggle?.Invoke(oldState, newState);

        [JSInvokable] public void InvokeTransitionStart(string propertyName, double elapsedTime, string pseudoElement) => htmlElement._onTransitionStart?.Invoke(propertyName, elapsedTime, pseudoElement);
        [JSInvokable] public void InvokeTransitionEnd(string propertyName, double elapsedTime, string pseudoElement) => htmlElement._onTransitionEnd?.Invoke(propertyName, elapsedTime, pseudoElement);
        [JSInvokable] public void InvokeTransitionRun(string propertyName, double elapsedTime, string pseudoElement) => htmlElement._onTransitionRun?.Invoke(propertyName, elapsedTime, pseudoElement);
        [JSInvokable] public void InvokeTransitionCancel(string propertyName, double elapsedTime, string pseudoElement) => htmlElement._onTransitionCancel?.Invoke(propertyName, elapsedTime, pseudoElement);

        [JSInvokable] public void InvokeAnimationStart(string animationName, double elapsedTime, string pseudoElement) => htmlElement._onAnimationStart?.Invoke(animationName, elapsedTime, pseudoElement);
        [JSInvokable] public void InvokeAnimationEnd(string animationName, double elapsedTime, string pseudoElement) => htmlElement._onAnimationEnd?.Invoke(animationName, elapsedTime, pseudoElement);
        [JSInvokable] public void InvokeAnimationIteration(string animationName, double elapsedTime, string pseudoElement) => htmlElement._onAnimationIteration?.Invoke(animationName, elapsedTime, pseudoElement);
        [JSInvokable] public void InvokeAnimationCancel(string animationName, double elapsedTime, string pseudoElement) => htmlElement._onAnimationCancel?.Invoke(animationName, elapsedTime, pseudoElement);
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger(IJSObjectReference htmlElement) {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return htmlElement.InvokeVoidTrySync("initEvents", [_objectReferenceEventTrigger, htmlElement is IJSInProcessObjectReference]);
    }

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private protected async ValueTask ActivateJSEvent(string jsMethodName) {
        IJSObjectReference htmlElement = await htmlElementTask;
        await InitEventTrigger(htmlElement);
        await htmlElement.InvokeVoidTrySync(jsMethodName);
    }

    private protected async ValueTask DeactivateJSEvent(string jsMethodName) {
        IJSObjectReference htmlElement = await htmlElementTask;
        await htmlElement.InvokeVoidTrySync(jsMethodName);
    }


    // HTMLElement - Events

    private Action? _onChange;
    /// <summary>
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

    // (IHTMLElement | IHTMLElementInProcess) source
    private protected abstract void InvokeCommand(IJSObjectReference source, string command);

    private Action? _onLoad;
    /// <summary>
    /// <para>
    /// Fires for elements containing a resource when the resource has successfully loaded.
    /// Currently, the list of supported HTML elements are: &lt;body&gt;, &lt;embed&gt;, &lt;iframe&gt;, &lt;img&gt;, &lt;link&gt;, &lt;object&gt;, &lt;script&gt;, &lt;style&gt;, and &lt;track&gt;.
    /// </para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// </summary>
    /// <remarks>
    /// Note: The load event on HTMLBodyElement is actually an alias for the window.onload event.
    /// Therefore, the load event will only fire on the &lt;body&gt; element once all of the document's resources have loaded or errored.
    /// However, for the sake of clarity, it is recommended that the event handler is attached to the window object directly rather than on HTMLBodyElement.
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

    private Action<JsonElement>? _onError;
    /// <summary>
    /// <para>Is fired on an element when a resource failed to load, or can't be used. For example, if a script has an execution error or an image can't be found or is invalid.</para>
    /// <para>This event is not cancelable and does not bubble.</para>
    /// <para>Parameter is of type <see href="https://developer.mozilla.org/en-US/docs/Web/API/Event">Event</see> as JSON.</para>
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

    private Action<string, double, string>? _onTransitionStart;
    /// <summary>
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

    #endregion
}
