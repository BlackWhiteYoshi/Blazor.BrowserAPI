using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class GamepadAPIGroup : ComponentBase {
    public const string TEST_GAMEPAD_CONNECTED_EVENT = "gamepad connected";
    public const string TEST_GAMEPAD_DISCONNECTED_EVENT = "gamepad disconnected";


    [Inject]
    public required IGamepadAPI GamepadAPI { private get; init; }


    public const string LABEL_OUTPUT = "gamepad-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_GET_GAMEPADS = "gamepad-get-gamepads";
    private async Task GetGamepads() {
        IGamepad?[] gamepadSlots = await GamepadAPI.GetGamepads();
        IGamepad[] gamepads = [.. gamepadSlots.OfType<IGamepad>()];
        labelOutput = $"Slots = {gamepadSlots.Length}, Connected = {gamepads.Length}";

        await gamepads.DisposeAsync();
    }

    public const string BUTTON_REGISTER_ON_GAMEPAD_CONNECTED = "gamepad-gamepad-connected-event";
    private void RegisterOnGamepadConnected() {
        GamepadAPI.OnGamepadConnected += (IGamepad gamepad) => {
            labelOutput = TEST_GAMEPAD_CONNECTED_EVENT;
            StateHasChanged();

            _ = gamepad.DisposeAsync().Preserve();
        };
    }

    public const string BUTTON_REGISTER_ON_GAMEPAD_DISCONNECTED = "gamepad-gamepad-disconnected-event";
    private void RegisterOnGamepadDisconnected() {
        GamepadAPI.OnGamepadDisconnected += (IGamepad gamepad) => {
            labelOutput = TEST_GAMEPAD_DISCONNECTED_EVENT;
            StateHasChanged();

            _ = gamepad.DisposeAsync().Preserve();
        };
    }


    public const string BUTTON_GET_AXES_PROPERTY = "gamepad-get-axes-property";
    private async Task GetAxes_Property() {
        IGamepad?[] gamepadSlots = await GamepadAPI.GetGamepads();
        IGamepad[] gamepads = [.. gamepadSlots.OfType<IGamepad>()];
        if (gamepads.Length == 0)
            return;
        IGamepad gamepad = gamepads[0];

        double[] axes = await gamepad.Axes;
        labelOutput = $"({axes.Length}): [{string.Join(", ", axes)}]";

        await gamepads.DisposeAsync();
    }

    public const string BUTTON_GET_AXES_METHOD = "gamepad-get-axes-method";
    private async Task GetAxes_Method() {
        IGamepad?[] gamepadSlots = await GamepadAPI.GetGamepads();
        IGamepad[] gamepads = [.. gamepadSlots.OfType<IGamepad>()];
        if (gamepads.Length == 0)
            return;
        IGamepad gamepad = gamepads[0];

        double[] axes = await gamepad.GetAxes(CancellationToken.None);
        labelOutput = $"({axes.Length}): [{string.Join(", ", axes)}]";

        await gamepads.DisposeAsync();
    }

    public const string BUTTON_GET_BUTTONS_PROPERTY = "gamepad-get-buttons-property";
    private async Task GetButtons_Property() {
        IGamepad?[] gamepadSlots = await GamepadAPI.GetGamepads();
        IGamepad[] gamepads = [.. gamepadSlots.OfType<IGamepad>()];
        if (gamepads.Length == 0)
            return;
        IGamepad gamepad = gamepads[0];

        GamepadButton[] buttons = await gamepad.Buttons;
        labelOutput = $"({buttons.Length}): [{string.Join(", ", buttons)}]";

        await gamepads.DisposeAsync();
    }

    public const string BUTTON_GET_BUTTONS_METHOD = "gamepad-get-buttons-method";
    private async Task GetButtons_Method() {
        IGamepad?[] gamepadSlots = await GamepadAPI.GetGamepads();
        IGamepad[] gamepads = [.. gamepadSlots.OfType<IGamepad>()];
        if (gamepads.Length == 0)
            return;
        IGamepad gamepad = gamepads[0];

        GamepadButton[] buttons = await gamepad.GetButtons(CancellationToken.None);
        labelOutput = $"({buttons.Length}): [{string.Join(", ", buttons)}]";

        await gamepads.DisposeAsync();
    }


    public const string BUTTON_GET_CONNECTED_PROPERTY = "gamepad-get-connected-property";
    private async Task GetConnected_Property() {
        IGamepad?[] gamepadSlots = await GamepadAPI.GetGamepads();
        IGamepad[] gamepads = [.. gamepadSlots.OfType<IGamepad>()];
        if (gamepads.Length == 0)
            return;
        IGamepad gamepad = gamepads[0];

        bool connected = await gamepad.Connected;
        labelOutput = connected.ToString();

        await gamepads.DisposeAsync();
    }

    public const string BUTTON_GET_CONNECTED_METHOD = "gamepad-get-connected-method";
    private async Task GetConnected_Method() {
        IGamepad?[] gamepadSlots = await GamepadAPI.GetGamepads();
        IGamepad[] gamepads = [.. gamepadSlots.OfType<IGamepad>()];
        if (gamepads.Length == 0)
            return;
        IGamepad gamepad = gamepads[0];

        bool connected = await gamepad.GetConnected(CancellationToken.None);
        labelOutput = connected.ToString();

        await gamepads.DisposeAsync();
    }

    public const string BUTTON_GET_ID_PROPERTY = "gamepad-get-id-property";
    private async Task GetId_Property() {
        IGamepad?[] gamepadSlots = await GamepadAPI.GetGamepads();
        IGamepad[] gamepads = [.. gamepadSlots.OfType<IGamepad>()];
        if (gamepads.Length == 0)
            return;
        IGamepad gamepad = gamepads[0];

        string id = await gamepad.Id;
        labelOutput = id;

        await gamepads.DisposeAsync();
    }

    public const string BUTTON_GET_ID_METHOD = "gamepad-get-id-method";
    private async Task GetId_Method() {
        IGamepad?[] gamepadSlots = await GamepadAPI.GetGamepads();
        IGamepad[] gamepads = [.. gamepadSlots.OfType<IGamepad>()];
        if (gamepads.Length == 0)
            return;
        IGamepad gamepad = gamepads[0];

        string id = await gamepad.GetId(CancellationToken.None);
        labelOutput = id;

        await gamepads.DisposeAsync();
    }

    public const string BUTTON_GET_INDEX_PROPERTY = "gamepad-get-index-property";
    private async Task GetIndex_Property() {
        IGamepad?[] gamepadSlots = await GamepadAPI.GetGamepads();
        IGamepad[] gamepads = [.. gamepadSlots.OfType<IGamepad>()];
        if (gamepads.Length == 0)
            return;
        IGamepad gamepad = gamepads[0];

        int index = await gamepad.Index;
        labelOutput = index.ToString();

        await gamepads.DisposeAsync();
    }

    public const string BUTTON_GET_INDEX_METHOD = "gamepad-get-index-method";
    private async Task GetIndex_Method() {
        IGamepad?[] gamepadSlots = await GamepadAPI.GetGamepads();
        IGamepad[] gamepads = [.. gamepadSlots.OfType<IGamepad>()];
        if (gamepads.Length == 0)
            return;
        IGamepad gamepad = gamepads[0];

        int index = await gamepad.GetIndex(CancellationToken.None);
        labelOutput = index.ToString();

        await gamepads.DisposeAsync();
    }

    public const string BUTTON_GET_MAPPING_PROPERTY = "gamepad-get-mapping-property";
    private async Task GetMapping_Property() {
        IGamepad?[] gamepadSlots = await GamepadAPI.GetGamepads();
        IGamepad[] gamepads = [.. gamepadSlots.OfType<IGamepad>()];
        if (gamepads.Length == 0)
            return;
        IGamepad gamepad = gamepads[0];

        string mapping = await gamepad.Mapping;
        labelOutput = mapping;

        await gamepads.DisposeAsync();
    }

    public const string BUTTON_GET_MAPPING_METHOD = "gamepad-get-mapping-method";
    private async Task GetMapping_Method() {
        IGamepad?[] gamepadSlots = await GamepadAPI.GetGamepads();
        IGamepad[] gamepads = [.. gamepadSlots.OfType<IGamepad>()];
        if (gamepads.Length == 0)
            return;
        IGamepad gamepad = gamepads[0];

        string mapping = await gamepad.GetMapping(CancellationToken.None);
        labelOutput = mapping;

        await gamepads.DisposeAsync();
    }

    public const string BUTTON_GET_TIMESTAMP_PROPERTY = "gamepad-get-timestamp-property";
    private async Task GetTimestamp_Property() {
        IGamepad?[] gamepadSlots = await GamepadAPI.GetGamepads();
        IGamepad[] gamepads = [.. gamepadSlots.OfType<IGamepad>()];
        if (gamepads.Length == 0)
            return;
        IGamepad gamepad = gamepads[0];

        double timestamp = await gamepad.Timestamp;
        labelOutput = timestamp.ToString();

        await gamepads.DisposeAsync();
    }

    public const string BUTTON_GET_TIMESTAMP_METHOD = "gamepad-get-timestamp-method";
    private async Task GetTimestamp_Method() {
        IGamepad?[] gamepadSlots = await GamepadAPI.GetGamepads();
        IGamepad[] gamepads = [.. gamepadSlots.OfType<IGamepad>()];
        if (gamepads.Length == 0)
            return;
        IGamepad gamepad = gamepads[0];

        double timestamp = await gamepad.GetTimestamp(CancellationToken.None);
        labelOutput = timestamp.ToString();

        await gamepads.DisposeAsync();
    }


    public const string BUTTON_GET_VIBRATION_ACTUATOR_EFFECTS_PROPERTY = "gamepad-get-vibration-actuator-effects-property";
    private async Task GetVibrationActuatorEffects_Property() {
        IGamepad?[] gamepadSlots = await GamepadAPI.GetGamepads();
        IGamepad[] gamepads = [.. gamepadSlots.OfType<IGamepad>()];
        if (gamepads.Length == 0)
            return;
        IGamepad gamepad = gamepads[0];

        string[] vibrationEffects = await gamepad.VibrationActuatorEffects;
        labelOutput = $"({vibrationEffects.Length}): [{string.Join(", ", vibrationEffects)}]";

        await gamepads.DisposeAsync();
    }

    public const string BUTTON_GET_VIBRATION_ACTUATOR_EFFECTS_METHOD = "gamepad-get-vibration-actuator-effects-method";
    private async Task GetVibrationActuatorEffects_Method() {
        IGamepad?[] gamepadSlots = await GamepadAPI.GetGamepads();
        IGamepad[] gamepads = [.. gamepadSlots.OfType<IGamepad>()];
        if (gamepads.Length == 0)
            return;
        IGamepad gamepad = gamepads[0];

        string[] vibrationEffects = await gamepad.GetVibrationActuatorEffects(CancellationToken.None);
        labelOutput = $"({vibrationEffects.Length}): [{string.Join(", ", vibrationEffects)}]";

        await gamepads.DisposeAsync();
    }

    public const string BUTTON_PLAY_VIBRATION_ACTUATOR_EFFECT = "gamepad-play-vibration-actuator-effect";
    private async Task PlayVibrationActuatorEffect() {
        IGamepad?[] gamepadSlots = await GamepadAPI.GetGamepads();
        IGamepad[] gamepads = [.. gamepadSlots.OfType<IGamepad>()];
        if (gamepads.Length == 0)
            return;
        IGamepad gamepad = gamepads[0];

        string rumbleResult = await gamepad.PlayVibrationActuatorEffect("dual-rumble", duration: 300);
        labelOutput = rumbleResult;

        await gamepads.DisposeAsync();
    }

    public const string BUTTON_RESET_VIBRATION_ACTUATOR = "gamepad-reset-vibration-actuator";
    private async Task ResetVibrationActuator() {
        IGamepad?[] gamepadSlots = await GamepadAPI.GetGamepads();
        IGamepad[] gamepads = [.. gamepadSlots.OfType<IGamepad>()];
        if (gamepads.Length == 0)
            return;
        IGamepad gamepad = gamepads[0];

        string rumbleResetResult = await gamepad.ResetVibrationActuator();
        labelOutput = rumbleResetResult;

        await gamepads.DisposeAsync();
    }
}
