using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IBatteryManager")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IBatteryManagerInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class BatteryManagerBase(IJSObjectReference batteryManagerJS) {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IJSObjectReference batteryManagerJS = batteryManagerJS;


    #region Events

    [method: DynamicDependency(nameof(InvokeChargingChange))]
    [method: DynamicDependency(nameof(InvokeChargingTimeChange))]
    [method: DynamicDependency(nameof(InvokeDischargingTimeChange))]
    [method: DynamicDependency(nameof(InvokeLevelChange))]
    private sealed class EventTrigger(BatteryManagerBase batteryManager) {
        [JSInvokable] public void InvokeChargingChange() => batteryManager._onChargingChange?.Invoke();
        [JSInvokable] public void InvokeChargingTimeChange() => batteryManager._onChargingTimeChange?.Invoke();
        [JSInvokable] public void InvokeDischargingTimeChange() => batteryManager._onDischargingTimeChange?.Invoke();
        [JSInvokable] public void InvokeLevelChange() => batteryManager._onLevelChange?.Invoke();
    }

    private DotNetObjectReference<EventTrigger>? _objectReferenceEventTrigger;

    private ValueTask InitEventTrigger() {
        if (_objectReferenceEventTrigger is not null)
            return ValueTask.CompletedTask;

        _objectReferenceEventTrigger = DotNetObjectReference.Create(new EventTrigger(this));
        return batteryManagerJS.InvokeVoidTrySync("initEvents", [_objectReferenceEventTrigger]);
    }

    /// <summary>
    /// Derived class should implement <see cref="IDisposable"/> or <see cref="IAsyncDisposable"/> and call this method.
    /// </summary>
    private protected void DisposeEventTrigger() => _objectReferenceEventTrigger?.Dispose();


    private protected async ValueTask ActivateJSEvent(string jsMethodName) {
        await InitEventTrigger();
        await batteryManagerJS.InvokeVoidTrySync(jsMethodName);
    }

    private protected ValueTask DeactivateJSEvent(string jsMethodName) => batteryManagerJS.InvokeVoidTrySync(jsMethodName);


    // Events

    private Action? _onChargingChange;
    /// <summary>
    /// Fired when the battery charging state (<see cref="IBatteryManager.Charging"/>/<see cref="IBatteryManagerInProcess.Charging"/>) is updated.
    /// </summary>
    public event Action OnChargingChange {
        add {
            if (_onChargingChange == null)
                _ = ActivateJSEvent("activateOnchargingchange").Preserve();
            _onChargingChange += value;
        }
        remove {
            _onChargingChange -= value;
            if (_onChargingChange == null)
                _ = DeactivateJSEvent("deactivateOnchargingchange").Preserve();
        }
    }

    private Action? _onChargingTimeChange;
    /// <summary>
    /// Fired when the battery charging time (<see cref="IBatteryManager.ChargingTime"/>/<see cref="IBatteryManagerInProcess.ChargingTime"/>) is updated.
    /// </summary>
    public event Action OnChargingTimeChange {
        add {
            if (_onChargingTimeChange == null)
                _ = ActivateJSEvent("activateOnchargingtimechange").Preserve();
            _onChargingTimeChange += value;
        }
        remove {
            _onChargingTimeChange -= value;
            if (_onChargingTimeChange == null)
                _ = DeactivateJSEvent("deactivateOnchargingtimechange").Preserve();
        }
    }

    private Action? _onDischargingTimeChange;
    /// <summary>
    /// Fired when the battery discharging time (<see cref="IBatteryManager.DischargingTime"/>/<see cref="IBatteryManagerInProcess.DischargingTime"/>) is updated.
    /// </summary>
    public event Action OnDischargingTimeChange {
        add {
            if (_onDischargingTimeChange == null)
                _ = ActivateJSEvent("activateOndischargingtimechange").Preserve();
            _onDischargingTimeChange += value;
        }
        remove {
            _onDischargingTimeChange -= value;
            if (_onDischargingTimeChange == null)
                _ = DeactivateJSEvent("deactivateOndischargingtimechange").Preserve();
        }
    }

    private Action? _onLevelChange;
    /// <summary>
    /// Fired when the battery level (<see cref="IBatteryManager.Level"/>/<see cref="IBatteryManagerInProcess.Level"/>) is updated.
    /// </summary>
    public event Action OnLevelChange {
        add {
            if (_onLevelChange == null)
                _ = ActivateJSEvent("activateOnlevelchange").Preserve();
            _onLevelChange += value;
        }
        remove {
            _onLevelChange -= value;
            if (_onLevelChange == null)
                _ = DeactivateJSEvent("deactivateOnlevelchange").Preserve();
        }
    }

    #endregion
}
