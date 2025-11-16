using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IPermissionStatus")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IPermissionStatusInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class PermissionStatusBase(IJSObjectReference permissionStatusJS) {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IJSObjectReference permissionStatusJS = permissionStatusJS;


    #region Events

    [method: DynamicDependency(nameof(InvokeChange))]
    private sealed class EventTrigger(PermissionStatusBase permissionStatus) {
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
