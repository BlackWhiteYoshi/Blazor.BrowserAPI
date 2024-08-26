using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IHTMLElement")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IHTMLElementInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class HTMLElementBase {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected abstract Task<IJSObjectReference> HTMLElementTask { get; }


    /// <summary>
    /// <para>The <i>Element.requestFullscreen()</i> method issues an asynchronous request to make the element be displayed in fullscreen mode.</para>
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
    public async ValueTask RequestFullscreen(string navigationUI = "auto", CancellationToken cancellationToken = default) => await (await HTMLElementTask).InvokeVoidAsync("requestFullscreen", cancellationToken, [navigationUI]);


    #region Events

    [method: DynamicDependency(nameof(InvokeTransitionstart))]
    [method: DynamicDependency(nameof(InvokeTransitionend))]
    [method: DynamicDependency(nameof(InvokeTransitionrun))]
    [method: DynamicDependency(nameof(InvokeTransitioncancel))]

    [method: DynamicDependency(nameof(InvokeAnimationstart))]
    [method: DynamicDependency(nameof(InvokeAnimationend))]
    [method: DynamicDependency(nameof(InvokeAnimationiteration))]
    [method: DynamicDependency(nameof(InvokeAnimationcancel))]
    private sealed class EventTrigger(HTMLElementBase htmlElement) {
        [JSInvokable] public void InvokeTransitionstart(string propertyName, double elapsedTime, string pseudoElement) => htmlElement._onTransitionstart?.Invoke(propertyName, elapsedTime, pseudoElement);
        [JSInvokable] public void InvokeTransitionend(string propertyName, double elapsedTime, string pseudoElement) => htmlElement._onTransitionend?.Invoke(propertyName, elapsedTime, pseudoElement);
        [JSInvokable] public void InvokeTransitionrun(string propertyName, double elapsedTime, string pseudoElement) => htmlElement._onTransitionrun?.Invoke(propertyName, elapsedTime, pseudoElement);
        [JSInvokable] public void InvokeTransitioncancel(string propertyName, double elapsedTime, string pseudoElement) => htmlElement._onTransitioncancel?.Invoke(propertyName, elapsedTime, pseudoElement);

        [JSInvokable] public void InvokeAnimationstart(string animationName, double elapsedTime, string pseudoElement) => htmlElement._onAnimationstart?.Invoke(animationName, elapsedTime, pseudoElement);
        [JSInvokable] public void InvokeAnimationend(string animationName, double elapsedTime, string pseudoElement) => htmlElement._onAnimationend?.Invoke(animationName, elapsedTime, pseudoElement);
        [JSInvokable] public void InvokeAnimationiteration(string animationName, double elapsedTime, string pseudoElement) => htmlElement._onAnimationiteration?.Invoke(animationName, elapsedTime, pseudoElement);
        [JSInvokable] public void InvokeAnimationcancel(string animationName, double elapsedTime, string pseudoElement) => htmlElement._onAnimationcancel?.Invoke(animationName, elapsedTime, pseudoElement);
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;
    private DotNetObjectReference<EventTrigger> ObjectReferenceEventTrigger => _objectReferenceEventTrigger ??= DotNetObjectReference.Create(new EventTrigger(this));

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    #region Transition Events

    private Action<string, double, string>? _onTransitionstart;
    /// <summary>
    /// <para>The <i>transitionstart</i> event is fired when a CSS transition has actually started, i.e., after any transition-delay has ended.</para>
    /// <para>This event is not cancelable.</para>
    /// <para>
    /// <b>Parameters</b><br />
    /// - string <i>propertyName</i>: A string containing the name CSS property associated with the transition.<br />
    /// - double <i>elapsedTime</i>: A float giving the amount of time the transition has been running, in seconds, when this event fired. This value is not affected by the transition-delay property.<br />
    /// - string <i>pseudoElement</i>: A string, starting with '::', containing the name of the pseudo-element the animation runs on. If the transition doesn't run on a pseudo-element but on the element, an empty string.
    /// </para>
    /// </summary>
    public event Action<string, double, string> OnTransitionstart {
        add {
            if (_onTransitionstart == null)
                Task.Factory.StartNew(async () => await (await HTMLElementTask).InvokeVoidTrySync("activateOntransitionstart", [ObjectReferenceEventTrigger]));
            _onTransitionstart += value;
        }
        remove {
            _onTransitionstart -= value;
            if (_onTransitionstart == null)
                Task.Factory.StartNew(async () => await (await HTMLElementTask).InvokeVoidTrySync("deactivateOntransitionstart"));
        }
    }

    private Action<string, double, string>? _onTransitionend;
    /// <summary>
    /// <para>
    /// The <i>transitionend</i> event is fired when a CSS transition has completed.
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
    public event Action<string, double, string> OnTransitionend {
        add {
            if (_onTransitionend == null)
                Task.Factory.StartNew(async () => await (await HTMLElementTask).InvokeVoidTrySync("activateOntransitionend", [ObjectReferenceEventTrigger]));
            _onTransitionend += value;
        }
        remove {
            _onTransitionend -= value;
            if (_onTransitionend == null)
                Task.Factory.StartNew(async () => await (await HTMLElementTask).InvokeVoidTrySync("deactivateOntransitionend"));
        }
    }

    private Action<string, double, string>? _onTransitionrun;
    /// <summary>
    /// <para>The <i>transitionrun</i> event is fired when a CSS transition is first created, i.e. before any transition-delay has begun.</para>
    /// <para>This event is not cancelable.</para>
    /// <para>
    /// <b>Parameters</b><br />
    /// - string <i>propertyName</i>: A string containing the name CSS property associated with the transition.<br />
    /// - double <i>elapsedTime</i>: A float giving the amount of time the transition has been running, in seconds, when this event fired. This value is not affected by the transition-delay property.<br />
    /// - string <i>pseudoElement</i>: A string, starting with '::', containing the name of the pseudo-element the animation runs on. If the transition doesn't run on a pseudo-element but on the element, an empty string.
    /// </para>
    /// </summary>
    public event Action<string, double, string> OnTransitionrun {
        add {
            if (_onTransitionrun == null)
                Task.Factory.StartNew(async () => await (await HTMLElementTask).InvokeVoidTrySync("activateOntransitionrun", [ObjectReferenceEventTrigger]));
            _onTransitionrun += value;
        }
        remove {
            _onTransitionrun -= value;
            if (_onTransitionrun == null)
                Task.Factory.StartNew(async () => await (await HTMLElementTask).InvokeVoidTrySync("deactivateOntransitionrun"));
        }
    }

    private Action<string, double, string>? _onTransitioncancel;
    /// <summary>
    /// <para>The <i>transitioncancel</i> event is fired when a CSS transition is canceled.</para>
    /// <para>
    /// <b>Parameters</b><br />
    /// - string <i>propertyName</i>: A string containing the name CSS property associated with the transition.<br />
    /// - double <i>elapsedTime</i>: A float giving the amount of time the transition has been running, in seconds, when this event fired. This value is not affected by the transition-delay property.<br />
    /// - string <i>pseudoElement</i>: A string, starting with '::', containing the name of the pseudo-element the animation runs on. If the transition doesn't run on a pseudo-element but on the element, an empty string.
    /// </para>
    /// </summary>
    public event Action<string, double, string> OnTransitioncancel {
        add {
            if (_onTransitioncancel == null)
                Task.Factory.StartNew(async () => await (await HTMLElementTask).InvokeVoidTrySync("activateOntransitioncancel", [ObjectReferenceEventTrigger]));
            _onTransitioncancel += value;
        }
        remove {
            _onTransitioncancel -= value;
            if (_onTransitioncancel == null)
                Task.Factory.StartNew(async () => await (await HTMLElementTask).InvokeVoidTrySync("deactivateOntransitioncancel"));
        }
    }

    #endregion


    #region Animation Events

    private Action<string, double, string>? _onAnimationstart;
    /// <summary>
    /// <para>
    /// The <i>animationstart</i> event is fired when a CSS Animation has started.
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
    public event Action<string, double, string> OnAnimationstart {
        add {
            if (_onAnimationstart == null)
                Task.Factory.StartNew(async () => await (await HTMLElementTask).InvokeVoidTrySync("activateOnanimationstart", [ObjectReferenceEventTrigger]));
            _onAnimationstart += value;
        }
        remove {
            _onAnimationstart -= value;
            if (_onAnimationstart == null)
                Task.Factory.StartNew(async () => await (await HTMLElementTask).InvokeVoidTrySync("deactivateOnanimationstart"));
        }
    }

    private Action<string, double, string>? _onAnimationend;
    /// <summary>
    /// <para>
    /// The <i>animationend</i> event is fired when a CSS Animation has completed.
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
    public event Action<string, double, string> OnAnimationend {
        add {
            if (_onAnimationend == null)
                Task.Factory.StartNew(async () => await (await HTMLElementTask).InvokeVoidTrySync("activateOnanimationend", [ObjectReferenceEventTrigger]));
            _onAnimationend += value;
        }
        remove {
            _onAnimationend -= value;
            if (_onAnimationend == null)
                Task.Factory.StartNew(async () => await (await HTMLElementTask).InvokeVoidTrySync("deactivateOnanimationend"));
        }
    }

    private Action<string, double, string>? _onAnimationiteration;
    /// <summary>
    /// <para>
    /// The <i>animationiteration</i> event is fired when an iteration of a CSS Animation ends, and another one begins.
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
    public event Action<string, double, string> OnAnimationiteration {
        add {
            if (_onAnimationiteration == null)
                Task.Factory.StartNew(async () => await (await HTMLElementTask).InvokeVoidTrySync("activateOnanimationiteration", [ObjectReferenceEventTrigger]));
            _onAnimationiteration += value;
        }
        remove {
            _onAnimationiteration -= value;
            if (_onAnimationiteration == null)
                Task.Factory.StartNew(async () => await (await HTMLElementTask).InvokeVoidTrySync("deactivateOnanimationiteration"));
        }
    }

    private Action<string, double, string>? _onAnimationcancel;
    /// <summary>
    /// <para>
    /// The <i>animationcancel</i> event is fired when a CSS Animation unexpectedly aborts.
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
    public event Action<string, double, string> OnAnimationcancel {
        add {
            if (_onAnimationcancel == null)
                Task.Factory.StartNew(async () => await (await HTMLElementTask).InvokeVoidTrySync("activateOnanimationcancel", [ObjectReferenceEventTrigger]));
            _onAnimationcancel += value;
        }
        remove {
            _onAnimationcancel -= value;
            if (_onAnimationcancel == null)
                Task.Factory.StartNew(async () => await (await HTMLElementTask).InvokeVoidTrySync("deactivateOnanimationcancel"));
        }
    }

    #endregion

    #endregion
}
