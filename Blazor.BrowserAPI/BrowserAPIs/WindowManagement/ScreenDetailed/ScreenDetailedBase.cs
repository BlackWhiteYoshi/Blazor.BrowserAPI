using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IScreenDetailed")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IScreenDetailedInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class ScreenDetailedBase(IJSObjectReference screenDetailedJS) {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IJSObjectReference screenDetailedJS = screenDetailedJS;


    /// <inheritdoc cref="ScreenBase.LockOrientation" />
    /// <param name="orientation"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask LockOrientation(string orientation, CancellationToken cancellationToken = default) => screenDetailedJS.InvokeVoidAsync("lockOrientation", cancellationToken, [orientation]);


    #region Events

    [method: DynamicDependency(nameof(InvokeChange))]
    [method: DynamicDependency(nameof(InvokeOrientationChange))]
    private sealed class EventTrigger(ScreenDetailedBase screenDetailed) {
        [JSInvokable] public void InvokeChange() => screenDetailed._onChange?.Invoke();
        [JSInvokable] public void InvokeOrientationChange() => screenDetailed._onOrientationChange?.Invoke();
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return screenDetailedJS.InvokeVoidTrySync("initEvents", [_objectReferenceEventTrigger]);
    }

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await screenDetailedJS.InvokeVoidTrySync(jsMethodName);
    }

    private ValueTask DeactivateJSEvent(string jsMethodName) => screenDetailedJS.InvokeVoidTrySync(jsMethodName);


    private Action? _onChange;
    /// <inheritdoc cref="ScreenBase.OnChange" />
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

    private Action? _onOrientationChange;
    /// <inheritdoc cref="ScreenBase.OnOrientationChange" />
    public event Action OnOrientationChange {
        add {
            if (_onOrientationChange == null)
                _ = ActivateJSEvent("activateOnorientationchange").Preserve();
            _onOrientationChange += value;
        }
        remove {
            _onOrientationChange -= value;
            if (_onOrientationChange == null)
                _ = DeactivateJSEvent("deactivateOnorientationchange").Preserve();
        }
    }

    #endregion
}
