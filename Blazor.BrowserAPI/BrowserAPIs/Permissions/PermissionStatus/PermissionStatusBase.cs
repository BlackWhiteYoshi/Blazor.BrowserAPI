using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// Base interface of <see cref="IPermissionStatus"/> and <see cref="IPermissionStatusInProcess"/>.<br/>
/// It contains common functionality for both interfaces.<br/>
/// It is not intended to use this interface directly.
/// </summary>
/// <typeparam name="TJSObjectReference"></typeparam>
/// <param name="permissionStatusJS"></param>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class PermissionStatusBase<TJSObjectReference>(TJSObjectReference permissionStatusJS) where TJSObjectReference : IJSObjectReference {
    private protected TJSObjectReference permissionStatusJS = permissionStatusJS;


    #region Events

    [method: DynamicDependency(nameof(InvokeChange))]
    private sealed class EventTrigger(PermissionStatusBase<TJSObjectReference> permissionStatus) {
        [JSInvokable] public void InvokeChange() => permissionStatus._onChange?.Invoke();
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return permissionStatusJS.InvokeVoidTrySync("initEvents", [_objectReferenceEventTrigger]);
    }

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await permissionStatusJS.InvokeVoidTrySync(jsMethodName);
    }

    private ValueTask DeactivateJSEvent(string jsMethodName) => permissionStatusJS.InvokeVoidTrySync(jsMethodName);


    // Events

    private Action? _onChange;
    /// <summary>
    /// Fires whenever the <i>State</i> property changes.
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

    #endregion
}
