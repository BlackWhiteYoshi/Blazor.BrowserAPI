# DevicePosture

The DevicePosture interface of the Device Posture API represents the device's posture, that is, whether the viewport is in a flat or folded state.  
It allows developers to create user interfaces that adapt to a foldable device's posture and respond to posture changes.


<br><br />
## Example

```csharp
public sealed partial class ExampleComponent : ComponentBase, IDisposable {
    [Inject]
    public required IDevicePosture DevicePosture { private get; init; }

    protected override void OnInitialized() {
        DisplayDevicePosture();
        DevicePosture.OnChange += DisplayDevicePosture;
    }

    public void Dispose() {
        DevicePosture.OnChange -= DisplayDevicePosture;
    }


    private void DisplayDevicePosture() {
        DoAsync().Preserve();
        async ValueTask DoAsync() {
            Console.WriteLine($"Current posture: {await DevicePosture.Type}");
        }
    }
}
```


<br><br />
## Members

### IDevicePosture

#### Properties

| **Name** | **Type**                | get/set | **Description**                                                                                                                                                                                                                                                                                                                                                                                                        |
| -------- | ----------------------- | ------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Type     | ValueTask&lt;string&gt; | get     | A string representing the device's current posture. The value can be one of:<br />- "continuous": Indicates a flat screen posture — this can include a foldable device while it is being used flat, a seamless curved display, or a standard desktop, laptop, tablet or mobile screen.<br />- "folded"; Indicates a folded screen posture — this can include a foldable device being used in a book or laptop posture. |

#### Events

| **Name** | **Type** | **Description**                                                                                                     |
| -------- | -------- | ------------------------------------------------------------------------------------------------------------------- |
| OnChange | Action   | Fires when the device's posture changes, for example when a foldable device goes from folded to continuous posture. |



<br></br>
### IDevicePostureInProcess

#### Properties

| **Name** | **Type** | get/set | **Description**                                                                                                                                                                                                                                                                                                                                                                                                        |
| -------- | -------- | ------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Type     | string   | get     | A string representing the device's current posture. The value can be one of:<br />- "continuous": Indicates a flat screen posture — this can include a foldable device while it is being used flat, a seamless curved display, or a standard desktop, laptop, tablet or mobile screen.<br />- "folded"; Indicates a folded screen posture — this can include a foldable device being used in a book or laptop posture. |

#### Events

| **Name** | **Type** | **Description**                                                                                                     |
| -------- | -------- | ------------------------------------------------------------------------------------------------------------------- |
| OnChange | Action   | Fires when the device's posture changes, for example when a foldable device goes from folded to continuous posture. |
