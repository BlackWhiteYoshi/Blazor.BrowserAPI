# Gamepad API

The *Gamepad API* is a way for developers to access and respond to signals from gamepads and other game controllers in a simple, consistent way.
It contains three interfaces, two events and one specialist function, to respond to gamepads being connected and disconnected,
and to access other information about the gamepads themselves, and what buttons and other controls are currently being pressed.


<br><br />
## Example

```csharp
public sealed partial class ExampleComponent : ComponentBase, IAsyncDisposable {
    [Inject]
    public required IGamepadAPI GamepadAPI { private get; init; }

    private IGamepad? gamepad = null;


    protected override async Task OnInitializedAsync() {
        IGamepad[] gamepads = await GamepadAPI.GetGamepads();
        if (gamepads.Length > 0) {
            // this example only uses one gamepad
            gamepad = gamepads[0];
            // dispose all other gamepads, if any
            for (int i = 1; i < gamepads.Length; i++)
                await gamepads[i].DisposeAsync();
        }

        GamepadAPI.OnGamepadConnected += OnGamepadConnected;
        GamepadAPI.OnGamepadDisconnected += OnGamepadDisconnected;
    }

    public void OnGamepadConnected(IGamepad gamepad) {
        if (this.gamepad is null)
            this.gamepad = gamepad;
        else
            _ = gamepad.DisposeAsync().Preserve();
    }

    public void OnGamepadDisconnected(IGamepad gamepad) {
        _ = RunAsync().Preserve();
        async ValueTask RunAsync() {
            await gamepad.DisposeAsync();

            if (this.gamepad is not null && await this.gamepad.Connected is false) {
                await this.gamepad.DisposeAsync();
                this.gamepad = null;
            }
        }
    }

    public ValueTask DisposeAsync() => gamepad?.DisposeAsync() ?? ValueTask.CompletedTask;


    private async Task ReadGamepadInput() {
        if (gamepad is null)
            return;

        double[] axes = await gamepad.Axes;
        GamepadButton[] buttons = await gamepad.Buttons;

        Console.WriteLine($"axes: {string.Join(", ", axes)}");
        Console.WriteLine($"buttons: {string.Join(", ", buttons)}");
    }
}
```


<br><br />
## Members

### IGamepadAPI

The *Gamepad API* is a way for developers to access and respond to signals from gamepads and other game controllers in a simple, consistent way.
It contains three interfaces, two events and one specialist function, to respond to gamepads being connected and disconnected,
and to access other information about the gamepads themselves, and what buttons and other controls are currently being pressed.

#### Methods

| **Name**    | **Parameters**                                  | **ReturnType**               | **Description**                                                                                                                                                                                                             |
| ----------- | ----------------------------------------------- | ---------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetGamepads | [CancellationToken cancellationToken = default] | ValueTask&lt;IGamepad?[]&gt; | Returns an array of [IGamepad](#igamepad) objects, one for each connected gamepad.<br/>Elements in the array may be *null* if a gamepad disconnects during a session, so that the remaining gamepads retain the same index. |

#### Events

| **Name**              | **Type**               | **Description**                                                                                                                                                                                                                                                                                                                                                              |
| --------------------- | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnGamepadConnected    | Action&lt;IGamepad&gt; | Is fired when the browser detects that a gamepad has been connected or the first time a button/axis of the gamepad is used. The event will not fire if disallowed by the document's gamepad Permissions Policy. This event is not cancelable and does not bubble.<br />Parameter is the connected Gamepad. Note: Dispose the given Gamepad object when you are done with it. |
| OnGamepadDisconnected | Action&lt;IGamepad&gt; | Is fired when the browser detects that a gamepad has been disconnected. The event will not fire if disallowed by the document's gamepad Permissions Policy. This event is not cancelable and does not bubble.<br />Parameter is the disconnected Gamepad. Note: Dispose the given Gamepad object when you are done with it.                                                  |


<br></br>
### IGamepad

#### Properties

| **Name**                 | **Type**                         | get/set | **Description**                                                                                                                                                                                                                                                                                                                                                          |
| ------------------------ | -------------------------------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Axes                     | ValueTask&lt;double[]&gt;        | get     | An array representing the controls with axes present on the device (e.g., analog thumb sticks).<br />Each entry in the array is a floating point value in the range -1.0 – 1.0, representing the axis position from the lowest value (-1.0) to the highest value (1.0).                                                                                                  |
| Buttons                  | ValueTask&lt;GamepadButton[]&gt; | get     | An array of *GamepadButton* objects representing the buttons present on the device.<br />Each entry in the array is 0 if the button is not pressed, and non-zero (typically 1.0) if the button is pressed.                                                                                                                                                               |
| Connected                | ValueTask&lt;bool&gt;            | get     | A boolean indicating whether the gamepad is still connected to the system.<br />If the gamepad is connected, the value is true; if not, it is false.                                                                                                                                                                                                                     |
| Id                       | ValueTask&lt;string&gt;          | get     | A string containing identifying information about the controller.<br />This information is intended to allow you to find a mapping for the controls on the device as well as display useful feedback to the user.                                                                                                                                                        |
| Index                    | ValueTask&lt;int&gt;             | get     | An integer that is auto-incremented to be unique for each device currently connected to the system.<br />This can be used to distinguish multiple controllers; a gamepad that is disconnected and reconnected will retain the same index.                                                                                                                                |
| Mapping                  | ValueTask&lt;string&gt;          | get     | A string indicating whether the browser has remapped the controls on the device to a known layout.<br />The currently supported known layouts are:<br />- "standard" for the [standard gamepad](https://w3c.github.io/gamepad/#remapping).<br />- "xr-standard for the [standard XR gamepad](https://immersive-web.github.io/webxr-gamepads-module/#xr-standard-headin). |
| Timestamp                | ValueTask&lt;double&gt;          | get     | A [DOMHighResTimeStamp](https://developer.mozilla.org/en-US/docs/Web/API/DOMHighResTimeStamp) representing the last time the data for this gamepad was updated.<br />Note: This property is not currently supported anywhere.                                                                                                                                            |
| VibrationActuatorEffects | ValueTask&lt;string[]&gt;        | get     | Returns an array of enumerated values representing the different haptic effects that the actuator supports.<br />Possible included values are: "dual-rumble", "trigger-rumble", "vibration"<br />If no vibration is supported, an empty array is returned.                                                                                                               |

#### Methods

| **Name**                    | **Parameters**                                                                                                                                                                                                                          | **ReturnType**                   | **Description**                                                                                                                                                                                                                                                                                 |
| --------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetAxes                     | CancellationToken cancellationToken                                                                                                                                                                                                     | ValueTask&lt;double[]&gt;        | see Property *Axes*                                                                                                                                                                                                                                                                             |
| GetButtons                  | CancellationToken cancellationToken                                                                                                                                                                                                     | ValueTask&lt;GamepadButton[]&gt; | see Property *Buttons*                                                                                                                                                                                                                                                                          |
| GetConnected                | CancellationToken cancellationToken                                                                                                                                                                                                     | ValueTask&lt;bool&gt;            | see Property *Connected*                                                                                                                                                                                                                                                                        |
| GetId                       | CancellationToken cancellationToken                                                                                                                                                                                                     | ValueTask&lt;string&gt;          | see Property *Id*                                                                                                                                                                                                                                                                               |
| GetIndex                    | CancellationToken cancellationToken                                                                                                                                                                                                     | ValueTask&lt;int&gt;             | see Property *Index*                                                                                                                                                                                                                                                                            |
| GetMapping                  | CancellationToken cancellationToken                                                                                                                                                                                                     | ValueTask&lt;string&gt;          | see Property *Mapping*                                                                                                                                                                                                                                                                          |
| GetTimestamp                | CancellationToken cancellationToken                                                                                                                                                                                                     | ValueTask&lt;double&gt;          | see Property *Timestamp*                                                                                                                                                                                                                                                                        |
| GetVibrationActuatorEffects | CancellationToken cancellationToken                                                                                                                                                                                                     | ValueTask&lt;string[]&gt;        | see Property *VibrationActuatorEffects*                                                                                                                                                                                                                                                         |
| PlayVibrationActuatorEffect | string type, [double duration = 0.0], [double startDelay = 0.0], [double strongMagnitude = 0.0], [double weakMagnitude = 0.0], [double leftTrigger = 0.0], [double rightTrigger = 0.0], [CancellationToken cancellationToken = default] | ValueTask&lt;string&gt;          | Causes the hardware to play a specific vibration effect.<br />Returns a promise that resolves with<br />- "complete": When the effect successfully completes.<br />- "preempted": If the current effect is stopped or replaced by another effect.<br />- "none": If vibration is not supported. |
| ResetVibrationActuator      | [CancellationToken cancellationToken = default]                                                                                                                                                                                         | ValueTask&lt;string&gt;          | Stops the hardware from playing an active vibration effect.<br />Returns a promise that resolves with<br />- "complete": If the effect is successfully reset.<br />- "preempted": If the effect was stopped or replaced by another effect.<br />- "none": If vibration is not supported.        |



<br></br>
### IGamepadAPIInProcess

The *Gamepad API* is a way for developers to access and respond to signals from gamepads and other game controllers in a simple, consistent way.
It contains three interfaces, two events and one specialist function, to respond to gamepads being connected and disconnected,
and to access other information about the gamepads themselves, and what buttons and other controls are currently being pressed.

#### Methods

| **Name**    | **Parameters** | **ReturnType**       | **Description**                                                                                                                                                                                                                               |
| ----------- | -------------- | -------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetGamepads | *empty*        | IGamepadInProcess?[] | Returns an array of [IGamepadInProcess](#igamepadinprocess) objects, one for each connected gamepad.<br/>Elements in the array may be *null* if a gamepad disconnects during a session, so that the remaining gamepads retain the same index. |

#### Events

| **Name**              | **Type**                        | **Description**                                                                                                                                                                                                                                                                                                                                                              |
| --------------------- | ------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnGamepadConnected    | Action&lt;IGamepadInProcess&gt; | Is fired when the browser detects that a gamepad has been connected or the first time a button/axis of the gamepad is used. The event will not fire if disallowed by the document's gamepad Permissions Policy. This event is not cancelable and does not bubble.<br />Parameter is the connected Gamepad. Note: Dispose the given Gamepad object when you are done with it. |
| OnGamepadDisconnected | Action&lt;IGamepadInProcess&gt; | Is fired when the browser detects that a gamepad has been disconnected. The event will not fire if disallowed by the document's gamepad Permissions Policy. This event is not cancelable and does not bubble.<br />Parameter is the disconnected Gamepad. Note: Dispose the given Gamepad object when you are done with it.                                                  |


<br></br>
### IGamepadInProcess

#### Properties

| **Name**                 | **Type**        | get/set | **Description**                                                                                                                                                                                                                                                                                                                                                          |
| ------------------------ | --------------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Axes                     | double[]        | get     | An array representing the controls with axes present on the device (e.g., analog thumb sticks).<br />Each entry in the array is a floating point value in the range -1.0 – 1.0, representing the axis position from the lowest value (-1.0) to the highest value (1.0).                                                                                                  |
| Buttons                  | GamepadButton[] | get     | An array of *GamepadButton* objects representing the buttons present on the device.<br />Each entry in the array is 0 if the button is not pressed, and non-zero (typically 1.0) if the button is pressed.                                                                                                                                                               |
| Connected                | bool            | get     | A boolean indicating whether the gamepad is still connected to the system.<br />If the gamepad is connected, the value is true; if not, it is false.                                                                                                                                                                                                                     |
| Id                       | string          | get     | A string containing identifying information about the controller.<br />This information is intended to allow you to find a mapping for the controls on the device as well as display useful feedback to the user.                                                                                                                                                        |
| Index                    | int             | get     | An integer that is auto-incremented to be unique for each device currently connected to the system.<br />This can be used to distinguish multiple controllers; a gamepad that is disconnected and reconnected will retain the same index.                                                                                                                                |
| Mapping                  | string          | get     | A string indicating whether the browser has remapped the controls on the device to a known layout.<br />The currently supported known layouts are:<br />- "standard" for the [standard gamepad](https://w3c.github.io/gamepad/#remapping).<br />- "xr-standard for the [standard XR gamepad](https://immersive-web.github.io/webxr-gamepads-module/#xr-standard-headin). |
| Timestamp                | double          | get     | A [DOMHighResTimeStamp](https://developer.mozilla.org/en-US/docs/Web/API/DOMHighResTimeStamp) representing the last time the data for this gamepad was updated.<br />Note: This property is not currently supported anywhere.                                                                                                                                            |
| VibrationActuatorEffects | string[]        | get     | Returns an array of enumerated values representing the different haptic effects that the actuator supports.<br />Possible included values are: "dual-rumble", "trigger-rumble", "vibration"<br />If no vibration is supported, an empty array is returned.                                                                                                               |

#### Methods

| **Name**                    | **Parameters**                                                                                                                                                                                                                          | **ReturnType**          | **Description**                                                                                                                                                                                                                                                                                 |
| --------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| PlayVibrationActuatorEffect | string type, [double duration = 0.0], [double startDelay = 0.0], [double strongMagnitude = 0.0], [double weakMagnitude = 0.0], [double leftTrigger = 0.0], [double rightTrigger = 0.0], [CancellationToken cancellationToken = default] | ValueTask&lt;string&gt; | Causes the hardware to play a specific vibration effect.<br />Returns a promise that resolves with<br />- "complete": When the effect successfully completes.<br />- "preempted": If the current effect is stopped or replaced by another effect.<br />- "none": If vibration is not supported. |
| ResetVibrationActuator      | [CancellationToken cancellationToken = default]                                                                                                                                                                                         | ValueTask&lt;string&gt; | Stops the hardware from playing an active vibration effect.<br />Returns a promise that resolves with<br />- "complete": If the effect is successfully reset.<br />- "preempted": If the effect was stopped or replaced by another effect.<br />- "none": If vibration is not supported.        |
