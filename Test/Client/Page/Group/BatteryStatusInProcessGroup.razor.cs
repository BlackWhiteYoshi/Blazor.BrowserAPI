using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class BatteryStatusInProcessGroup : ComponentBase {
    [Inject]
    public required IBatteryStatusInProcess BatteryStatus { private get; init; }


    public const string OUTPUT = "battery-status-inprocess-output";
    private string output = string.Empty;


    public const string BUTTON_GET_BATTERY = "battery-status-inprocess-get-battery";
    private async Task GetBattery() {
        using IBatteryManagerInProcess batteryManager = await BatteryStatus.GetBattery();
        output = (batteryManager is not null).ToString();
    }


    // Properties

    public const string BUTTON_GET_CHARGING = "battery-status-inprocess-get-charging";
    private async Task GetCharging() {
        using IBatteryManagerInProcess batteryManager = await BatteryStatus.GetBattery();
        bool charging = batteryManager.Charging;
        output = charging.ToString();
    }

    public const string BUTTON_GET_CHARGING_TIME = "battery-status-inprocess-get-charging-time";
    private async Task GetChargingTime() {
        using IBatteryManagerInProcess batteryManager = await BatteryStatus.GetBattery();
        double chargingTime = batteryManager.ChargingTime;
        output = chargingTime.ToString();
    }

    public const string BUTTON_GET_DISCHARGING_TIME = "battery-status-inprocess-get-discharging-time";
    private async Task GetDischargingTime() {
        using IBatteryManagerInProcess batteryManager = await BatteryStatus.GetBattery();
        double dischargingTime = batteryManager.DischargingTime;
        output = dischargingTime.ToString();
    }

    public const string BUTTON_GET_LEVEL = "battery-status-inprocess-get-level";
    private async Task GetLevel() {
        using IBatteryManagerInProcess batteryManager = await BatteryStatus.GetBattery();
        double level = batteryManager.Level;
        output = level.ToString();
    }


    // Events

    public const string BUTTON_REGISTER_ON_CHARGING_CHANGE = "battery-status-inprocess-charging-change-event";
    private async Task RegisterOnChargingChange() {
        IBatteryManagerInProcess batteryManager = await BatteryStatus.GetBattery();
        batteryManager.OnChargingChange += () => {
            bool charging = batteryManager.Charging;
            output = charging.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CHARGING_TIME_CHANGE = "battery-status-inprocess-charging-time-change-event";
    private async Task RegisterOnChargingTimeChange() {
        IBatteryManagerInProcess batteryManager = await BatteryStatus.GetBattery();
        batteryManager.OnChargingTimeChange += () => {
            double chargingTime = batteryManager.ChargingTime;
            output = chargingTime.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_DISCHARGING_TIME_CHANGE = "battery-status-inprocess-discharging-time-change-event";
    private async Task RegisterOnDisChargingTimeChange() {
        IBatteryManagerInProcess batteryManager = await BatteryStatus.GetBattery();
        batteryManager.OnDischargingTimeChange += () => {
            double dischargingTime = batteryManager.DischargingTime;
            output = dischargingTime.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LEVEL_CHANGE = "battery-status-inprocess-level-change-event";
    private async Task RegisterOnLevelChange() {
        IBatteryManagerInProcess batteryManager = await BatteryStatus.GetBattery();
        batteryManager.OnLevelChange += () => {
            double level = batteryManager.Level;
            output = level.ToString();
            StateHasChanged();
        };
    }
}
