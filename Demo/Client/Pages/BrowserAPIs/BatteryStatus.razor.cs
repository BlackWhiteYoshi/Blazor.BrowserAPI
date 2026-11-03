using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BrowserAPI.Demo.Client;

public sealed partial class BatteryStatus : ComponentBase, IAsyncDisposable {
    [Inject]
    public required IBatteryStatus PBatteryStatus { private get; init; }

    private Task<IBatteryManager>? _batteryManagerTask;
    private Task<IBatteryManager> BatteryManagerTask => _batteryManagerTask ??= PBatteryStatus.GetBattery().AsTask();

    public async ValueTask DisposeAsync() {
        if (_batteryManagerTask is not null) {
            try {
                IBatteryManager batteryManager = await _batteryManagerTask;

                if (isListeningOnChargingChange)
                    batteryManager.OnChargingChange -= OnChargingChange;
                if (isListeningOnChargingTimeChange)
                    batteryManager.OnChargingTimeChange -= OnChargingTimeChange;
                if (isListeningOnDischargingTimeChange)
                    batteryManager.OnDischargingTimeChange -= OnDischargingTimeChange;
                if (isListeningOnLevelChange)
                    batteryManager.OnLevelChange -= OnLevelChange;

                await batteryManager.DisposeAsync();
            }
            catch (JSDisconnectedException) { }
        }
    }


    private bool? isCharging;
    private double? chargingTime;
    private double? dischargingTime;
    private double? chargeLevel;


    private async Task ReadBatteryInfo() {
        IBatteryManager batteryManager = await BatteryManagerTask;

        isCharging = await batteryManager.Charging;
        chargingTime = await batteryManager.ChargingTime;
        dischargingTime = await batteryManager.DischargingTime;
        chargeLevel = await batteryManager.Level;
    }


    // OnChargingChange

    private bool isListeningOnChargingChange = false;
    
    private async Task ListenOnChargingChange() {
        isListeningOnChargingChange = true;
        (await BatteryManagerTask).OnChargingChange += OnChargingChange;
    }

    private async Task RemoveOnChargingChange() {
        isListeningOnChargingChange = false;
        (await BatteryManagerTask).OnChargingChange -= OnChargingChange;
    }

    private void OnChargingChange() {
        _ = DoAsync().Preserve();
        async ValueTask DoAsync() {
            IBatteryManager batteryManager = await BatteryManagerTask;
            isCharging = await batteryManager.Charging;
            await InvokeAsync(StateHasChanged);
        }
    }


    // OnChargingTimeChange

    private bool isListeningOnChargingTimeChange = false;
    
    private async Task ListenOnChargingTimeChange() {
        isListeningOnChargingTimeChange = true;
        (await BatteryManagerTask).OnChargingTimeChange += OnChargingTimeChange;
    }

    private async Task RemoveOnChargingTimeChange() {
        isListeningOnChargingTimeChange = false;
        (await BatteryManagerTask).OnChargingTimeChange -= OnChargingTimeChange;
    }

    private void OnChargingTimeChange() {
        _ = DoAsync().Preserve();
        async ValueTask DoAsync() {
            IBatteryManager batteryManager = await BatteryManagerTask;
            chargingTime = await batteryManager.ChargingTime;
            await InvokeAsync(StateHasChanged);
        }
    }


    // OnDischargingTimeChange

    private bool isListeningOnDischargingTimeChange = false;
    
    private async Task ListenOnDischargingTimeChange() {
        isListeningOnDischargingTimeChange = true;
        (await BatteryManagerTask).OnDischargingTimeChange += OnDischargingTimeChange;
    }

    private async Task RemoveOnDischargingTimeChange() {
        isListeningOnDischargingTimeChange = false;
        (await BatteryManagerTask).OnDischargingTimeChange -= OnDischargingTimeChange;
    }

    private void OnDischargingTimeChange() {
        _ = DoAsync().Preserve();
        async ValueTask DoAsync() {
            IBatteryManager batteryManager = await BatteryManagerTask;
            dischargingTime = await batteryManager.DischargingTime;
            await InvokeAsync(StateHasChanged);
        }
    }


    // OnLevelChange

    private bool isListeningOnLevelChange = false;
    
    private async Task ListenOnLevelChange() {
        isListeningOnLevelChange = true;
        (await BatteryManagerTask).OnLevelChange += OnLevelChange;
    }

    private async Task RemoveOnLevelChange() {
        isListeningOnLevelChange = false;
        (await BatteryManagerTask).OnLevelChange -= OnLevelChange;
    }

    private void OnLevelChange() {
        _ = DoAsync().Preserve();
        async ValueTask DoAsync() {
            IBatteryManager batteryManager = await BatteryManagerTask;
            chargeLevel = await batteryManager.Level;
            await InvokeAsync(StateHasChanged);
        }
    }
}
