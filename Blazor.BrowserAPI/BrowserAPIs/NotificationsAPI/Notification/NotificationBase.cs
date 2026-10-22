using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// Base interface of <see cref="INotification"/> and <see cref="INotificationInProcess"/>.<br/>
/// It contains common functionality for both interfaces.<br/>
/// It is not intended to use this interface directly.
/// </summary>
/// <typeparam name="TJSObjectReference"></typeparam>
/// <param name="notificationJS"></param>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class NotificationBase<TJSObjectReference>(TJSObjectReference notificationJS) where TJSObjectReference : IJSObjectReference {
    private protected TJSObjectReference notificationJS = notificationJS;


    #region Events

    [method: DynamicDependency(nameof(InvokeClick))]
    [method: DynamicDependency(nameof(InvokeClose))]
    [method: DynamicDependency(nameof(InvokeError))]
    [method: DynamicDependency(nameof(InvokeShow))]
    private sealed class EventTrigger(NotificationBase<TJSObjectReference> notification) {
        [JSInvokable] public void InvokeClick() => notification._onClick?.Invoke();
        [JSInvokable] public void InvokeClose() => notification._onClose?.Invoke();
        [JSInvokable] public void InvokeError() => notification._onError?.Invoke();
        [JSInvokable] public void InvokeShow() => notification._onShow?.Invoke();
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return notificationJS.InvokeVoidTrySync("initEvents", [_objectReferenceEventTrigger]);
    }

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await notificationJS.InvokeVoidTrySync(jsMethodName);
    }

    private ValueTask DeactivateJSEvent(string jsMethodName) => notificationJS.InvokeVoidTrySync(jsMethodName);


    // Events

    private Action? _onClick;
    /// <summary>
    /// <para>Fires when the user clicks on displayed Notification.</para>
    /// <para>The default behavior is to move the focus to the viewport of the notification's related browsing context. If you don't want that behavior, call preventDefault() on the event object.</para>
    /// </summary>
    public event Action OnClick {
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

    private Action? _onClose;
    /// <summary>
    /// Fires when a Notification is closed.
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

    private Action? _onError;
    /// <summary>
    /// Fires when something goes wrong with a Notification (in many cases an error preventing the notification from being displayed.)
    /// </summary>
    public event Action OnError {
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

    private Action? _onShow;
    /// <summary>
    /// Fires when a Notification is displayed.
    /// </summary>
    public event Action OnShow {
        add {
            if (_onShow == null)
                _ = ActivateJSEvent("activateOnshow").Preserve();
            _onShow += value;
        }
        remove {
            _onShow -= value;
            if (_onShow == null)
                _ = DeactivateJSEvent("deactivateOnshow").Preserve();
        }
    }

    #endregion
}
