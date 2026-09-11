# BatteryStatus

The *Battery Status API*, more often referred to as the Battery API, provides information about the system's battery charge level
and lets you be notified by events that are sent when the battery level or charging status change.
This can be used to adjust your app's resource usage to reduce battery drain when the battery is low, or to save changes before the battery runs out in order to prevent data loss.


<br><br />
## Example

```csharp
public sealed partial class ExampleComponent : ComponentBase, IAsyncDisposable {
    [Inject]
    public required IBatteryStatus BatteryStatus { private get; init; }
    private Task<IBatteryManager> batteryManagerTask = null!;

    protected override void OnInitialized() {
        batteryManagerTask = BatteryStatus.GetBattery().AsTask();
    }

    public async ValueTask DisposeAsync() {
        IBatteryManager batteryManager = await batteryManagerTask;
        await batteryManager.DisposeAsync();
    }


    private async Task DisplayBatteryInfo() {
        IBatteryManager batteryManager = await batteryManagerTask;

        Console.WriteLine($"Charging: {await batteryManager.Charging}");
        Console.WriteLine($"Time until full: {await batteryManager.ChargingTime} secs");
        Console.WriteLine($"Time until empty: {await batteryManager.DischargingTime} secs");
        Console.WriteLine($"Charge level: {await batteryManager.Level}");
    }
}
```


<br><br />
## Members

### IBatteryStatus

#### Methods

| **Name**   | **Parameters**                                  | **ReturnType**                   | **Description**                                                                                                                                                                                                             |
| ---------- | ----------------------------------------------- | -------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetBattery | [CancellationToken cancellationToken = default] | ValueTask&lt;IBatteryManager&gt; | Provides information about the system's battery. It returns a battery promise, which resolves with a BatteryManager object providing some properties to get the battery status also some events you can handle to monitor the battery status.<br />Each method call produces a new instance that should be disposed when you are done with it. |


<br></br>
### IBatteryManager

Provides information about the system's battery charge level.
The IBatteryStatus.GetBattery method returns a promise that resolves with a BatteryManager interface.

Since Chrome 103, the BatteryManager interface of Battery Status API only expose to secure context.

#### Properties

| **Name**        | **Type**                | get/set | **Description**                                                                                                                                                                                                                                                                                                                                                          |
| --------------- | ----------------------- | ------- | ---------------------------------------------------------------------------------------------------------------------------- |
| Charging        | ValueTask&lt;bool&gt;   | get     | Indicating whether the battery is currently being charged.                                                                   |
| ChargingTime    | ValueTask&lt;double&gt; | get     | Representing the remaining time in seconds until the battery is fully charged, or 0 if the battery is already fully charged. |
| DischargingTime | ValueTask&lt;double&gt; | get     | Representing the remaining time in seconds until the battery is completely discharged and the system suspends.               |
| Level           | ValueTask&lt;double&gt; | get     | Representing the system's battery charge level scaled to a value between 0.0 and 1.0.                                        |

#### Events

| **Name**                | **Type** | **Description**                                                                                                                                                                                                                                                                                                                                                              |
| ----------------------- | -------- | ---------------------------------------------------------------------------------------------- |
| OnChargingChange        | Action   | Fired when the battery charging state (IBatteryManager.Charging property) is updated.          |
| OnChargingTimeChange    | Action   | Fired when the battery charging time (IBatteryManager.ChargingTime property) is updated.       |
| OnDischargingTimeChange | Action   | Fired when the battery discharging time (IBatteryManager.DischargingTime property) is updated. |
| OnLevelChange           | Action   | Fired when the battery level (IBatteryManager.Level property) is updated.                      |



<br></br>
### IBatteryStatusInProcess

#### Methods

| **Name**   | **Parameters**                                  | **ReturnType**                            | **Description**                                                                                                                                                                                                             |
| ---------- | ----------------------------------------------- | ----------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetBattery | [CancellationToken cancellationToken = default] | ValueTask&lt;IBatteryManagerInProcess&gt; | Provides information about the system's battery. It returns a battery promise, which resolves with a BatteryManager object providing some properties to get the battery status also some events you can handle to monitor the battery status.<br />Each method call produces a new instance that should be disposed when you are done with it. |


<br></br>
### IBatteryManagerInProcess

Provides information about the system's battery charge level.
The IBatteryStatus.GetBattery method returns a promise that resolves with a BatteryManager interface.

Since Chrome 103, the BatteryManager interface of Battery Status API only expose to secure context.

#### Properties

| **Name**        | **Type** | get/set | **Description**                                                                                                                                                                                                                                                                                                                                                          |
| --------------- | -------- | ------- | ---------------------------------------------------------------------------------------------------------------------------- |
| Charging        | bool     | get     | Indicating whether the battery is currently being charged.                                                                   |
| ChargingTime    | double   | get     | Representing the remaining time in seconds until the battery is fully charged, or 0 if the battery is already fully charged. |
| DischargingTime | double   | get     | Representing the remaining time in seconds until the battery is completely discharged and the system suspends.               |
| Level           | double   | get     | Representing the system's battery charge level scaled to a value between 0.0 and 1.0.                                        |

#### Events

| **Name**                | **Type** | **Description**                                                                                                                                                                                                                                                                                                                                                              |
| ----------------------- | -------- | ---------------------------------------------------------------------------------------------- |
| OnChargingChange        | Action   | Fired when the battery charging state (IBatteryManager.Charging property) is updated.          |
| OnChargingTimeChange    | Action   | Fired when the battery charging time (IBatteryManager.ChargingTime property) is updated.       |
| OnDischargingTimeChange | Action   | Fired when the battery discharging time (IBatteryManager.DischargingTime property) is updated. |
| OnLevelChange           | Action   | Fired when the battery level (IBatteryManager.Level property) is updated.                      |
