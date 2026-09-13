using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class BatteryStatusGroup : ComponentBase {
    [Inject]
    public required IBatteryStatus BatteryStatus { private get; init; }


    public const string OUTPUT = "battery-status-output";
    private string output = string.Empty;


    public const string BUTTON_GET_BATTERY = "battery-status-get-battery";
    private async Task GetBattery() {
        await using IBatteryManager batteryManager = await BatteryStatus.GetBattery();
        output = (batteryManager is not null).ToString();
    }


    // Properties

    public const string BUTTON_GET_CHARGING_PROPERTY = "battery-status-get-charging-property";
    private async Task GetCharging_Property() {
        await using IBatteryManager batteryManager = await BatteryStatus.GetBattery();
        bool charging = await batteryManager.Charging;
        output = charging.ToString();
    }

    public const string BUTTON_GET_CHARGING_METHOD = "battery-status-get-charging-method";
    private async Task GetCharging_Method() {
        await using IBatteryManager batteryManager = await BatteryStatus.GetBattery();
        bool charging = await batteryManager.GetCharging(CancellationToken.None);
        output = charging.ToString();
    }

    public const string BUTTON_GET_CHARGING_TIME_PROPERTY = "battery-status-get-charging-time-property";
    private async Task GetChargingTime_Property() {
        await using IBatteryManager batteryManager = await BatteryStatus.GetBattery();
        double chargingTime = await batteryManager.ChargingTime;
        output = chargingTime.ToString();
    }

    public const string BUTTON_GET_CHARGING_TIME_METHOD = "battery-status-get-charging-time-method";
    private async Task GetChargingTime_Method() {
        await using IBatteryManager batteryManager = await BatteryStatus.GetBattery();
        double chargingTime = await batteryManager.GetChargingTime(CancellationToken.None);
        output = chargingTime.ToString();
    }

    public const string BUTTON_GET_DISCHARGING_TIME_PROPERTY = "battery-status-get-discharging-time-property";
    private async Task GetDischargingTime_Property() {
        await using IBatteryManager batteryManager = await BatteryStatus.GetBattery();
        double dischargingTime = await batteryManager.DischargingTime;
        output = dischargingTime.ToString();
    }

    public const string BUTTON_GET_DISCHARGING_TIME_METHOD = "battery-status-get-discharging-time-method";
    private async Task GetDischargingTime_Method() {
        await using IBatteryManager batteryManager = await BatteryStatus.GetBattery();
        double dischargingTime = await batteryManager.GetDischargingTime(CancellationToken.None);
        output = dischargingTime.ToString();
    }

    public const string BUTTON_GET_LEVEL_PROPERTY = "battery-status-get-level-property";
    private async Task GetLevel_Property() {
        await using IBatteryManager batteryManager = await BatteryStatus.GetBattery();
        double level = await batteryManager.Level;
        output = level.ToString();
    }

    public const string BUTTON_GET_LEVEL_METHOD = "battery-status-get-level-method";
    private async Task GetLevel_Method() {
        IBatteryManager batteryManager = await BatteryStatus.GetBattery();
        double level = await batteryManager.GetLevel(CancellationToken.None);
        output = level.ToString();
    }


    // Events

    public const string BUTTON_REGISTER_ON_CHARGING_CHANGE = "battery-status-charging-change-event";
    private async Task RegisterOnChargingChange() {
        IBatteryManager batteryManager = await BatteryStatus.GetBattery();
        batteryManager.OnChargingChange += async () => {
            bool charging = await batteryManager.Charging;
            output = charging.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CHARGING_TIME_CHANGE = "battery-status-charging-time-change-event";
    private async Task RegisterOnChargingTimeChange() {
        IBatteryManager batteryManager = await BatteryStatus.GetBattery();
        batteryManager.OnChargingTimeChange += async () => {
            double chargingTime = await batteryManager.ChargingTime;
            output = chargingTime.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_DISCHARGING_TIME_CHANGE = "battery-status-discharging-time-change-event";
    private async Task RegisterOnDisChargingTimeChange() {
        IBatteryManager batteryManager = await BatteryStatus.GetBattery();
        batteryManager.OnDischargingTimeChange += async () => {
            double dischargingTime = await batteryManager.DischargingTime;
            output = dischargingTime.ToString();
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_LEVEL_CHANGE = "battery-status-level-change-event";
    private async Task RegisterOnLevelChange() {
        IBatteryManager batteryManager = await BatteryStatus.GetBattery();
        batteryManager.OnLevelChange += async () => {
            double level = await batteryManager.Level;
            output = level.ToString();
            StateHasChanged();
        };
    }
}
