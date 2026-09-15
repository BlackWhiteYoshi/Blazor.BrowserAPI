using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IDevicePosture")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IDevicePostureInProcess")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class DevicePostureBase(IModuleManager moduleManager) : IDisposable {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IModuleManager moduleManager = moduleManager;

    /// <summary>
    /// Releases the <see cref="EventTrigger"/> object used to trigger the events.
    /// </summary>
    public void Dispose() => _objectReferenceEventTrigger?.Dispose();


    #region Events

    [method: DynamicDependency(nameof(InvokeChange))]
    private sealed class EventTrigger(DevicePostureBase devicePosture) {
        [JSInvokable] public void InvokeChange() => devicePosture._onChange?.Invoke();
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return moduleManager.InvokeTrySync("DevicePostureAPI.initEvents", CancellationToken.None, [_objectReferenceEventTrigger]);
    }


    private protected async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await moduleManager.InvokeTrySync(jsMethodName, CancellationToken.None);
    }

    private protected ValueTask DeactivateJSEvent(string jsMethodName) => moduleManager.InvokeTrySync(jsMethodName, CancellationToken.None);


    // Events

    private Action? _onChange;
    /// <summary>
    /// Fires when the device's posture changes, for example when a foldable device goes from folded to continuous posture.
    /// </summary>
    public event Action OnChange {
        add {
            if (_onChange == null)
                _ = ActivateJSEvent("DevicePostureAPI.activateOnchange").Preserve();
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
