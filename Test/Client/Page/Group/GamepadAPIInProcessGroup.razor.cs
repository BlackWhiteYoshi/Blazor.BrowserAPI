using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class GamepadAPIInProcessGroup : ComponentBase {
    public const string TEST_GAMEPAD_CONNECTED_EVENT = "gamepad connected";
    public const string TEST_GAMEPAD_DISCONNECTED_EVENT = "gamepad disconnected";


    [Inject]
    public required IGamepadAPIInProcess GamepadAPI { private get; init; }


    public const string LABEL_OUTPUT = "gamepad-inprocess-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_GET_GAMEPADS = "gamepad-inprocess-get-gamepads";
    private void GetGamepads() {
        IGamepadInProcess?[] gamepadSlots = GamepadAPI.GetGamepads();
        IGamepadInProcess[] gamepads = [.. gamepadSlots.OfType<IGamepadInProcess>()];
        labelOutput = $"Slots = {gamepadSlots.Length}, Connected = {gamepads.Length}";

        gamepads.Dispose();
    }

    public const string BUTTON_REGISTER_ON_GAMEPAD_CONNECTED = "gamepad-inprocess-gamepad-connected-event";
    private void RegisterOnGamepadConnected() {
        GamepadAPI.OnGamepadConnected += (IGamepadInProcess gamepad) => {
            labelOutput = TEST_GAMEPAD_CONNECTED_EVENT;
            StateHasChanged();

            gamepad.Dispose();
        };
    }

    public const string BUTTON_REGISTER_ON_GAMEPAD_DISCONNECTED = "gamepad-inprocess-gamepad-disconnected-event";
    private void RegisterOnGamepadDisconnected() {
        GamepadAPI.OnGamepadDisconnected += (IGamepadInProcess gamepad) => {
            labelOutput = TEST_GAMEPAD_DISCONNECTED_EVENT;
            StateHasChanged();

            gamepad.Dispose();
        };
    }


    public const string BUTTON_GET_AXES = "gamepad-inprocess-get-axes";
    private void GetAxes() {
        IGamepadInProcess?[] gamepadSlots = GamepadAPI.GetGamepads();
        IGamepadInProcess[] gamepads = [.. gamepadSlots.OfType<IGamepadInProcess>()];
        if (gamepads.Length == 0)
            return;
        IGamepadInProcess gamepad = gamepads[0];

        double[] axes = gamepad.Axes;
        labelOutput = $"({axes.Length}): [{string.Join(", ", axes)}]";

        gamepads.Dispose();
    }

    public const string BUTTON_GET_BUTTONS = "gamepad-inprocess-get-buttons";
    private void GetButtons() {
        IGamepadInProcess?[] gamepadSlots = GamepadAPI.GetGamepads();
        IGamepadInProcess[] gamepads = [.. gamepadSlots.OfType<IGamepadInProcess>()];
        if (gamepads.Length == 0)
            return;
        IGamepadInProcess gamepad = gamepads[0];

        GamepadButton[] buttons = gamepad.Buttons;
        labelOutput = $"({buttons.Length}): [{string.Join(", ", buttons)}]";

        gamepads.Dispose();
    }


    public const string BUTTON_GET_CONNECTED = "gamepad-inprocess-get-connected";
    private void GetConnected() {
        IGamepadInProcess?[] gamepadSlots = GamepadAPI.GetGamepads();
        IGamepadInProcess[] gamepads = [.. gamepadSlots.OfType<IGamepadInProcess>()];
        if (gamepads.Length == 0)
            return;
        IGamepadInProcess gamepad = gamepads[0];

        bool connected = gamepad.Connected;
        labelOutput = connected.ToString();

        gamepads.Dispose();
    }

    public const string BUTTON_GET_ID = "gamepad-inprocess-get-id";
    private void GetId() {
        IGamepadInProcess?[] gamepadSlots = GamepadAPI.GetGamepads();
        IGamepadInProcess[] gamepads = [.. gamepadSlots.OfType<IGamepadInProcess>()];
        if (gamepads.Length == 0)
            return;
        IGamepadInProcess gamepad = gamepads[0];

        string id = gamepad.Id;
        labelOutput = id;

        gamepads.Dispose();
    }

    public const string BUTTON_GET_INDEX = "gamepad-inprocess-get-index";
    private void GetIndex() {
        IGamepadInProcess?[] gamepadSlots = GamepadAPI.GetGamepads();
        IGamepadInProcess[] gamepads = [.. gamepadSlots.OfType<IGamepadInProcess>()];
        if (gamepads.Length == 0)
            return;
        IGamepadInProcess gamepad = gamepads[0];

        int index = gamepad.Index;
        labelOutput = index.ToString();

        gamepads.Dispose();
    }

    public const string BUTTON_GET_MAPPING = "gamepad-inprocess-get-mapping";
    private void GetMapping() {
        IGamepadInProcess?[] gamepadSlots = GamepadAPI.GetGamepads();
        IGamepadInProcess[] gamepads = [.. gamepadSlots.OfType<IGamepadInProcess>()];
        if (gamepads.Length == 0)
            return;
        IGamepadInProcess gamepad = gamepads[0];

        string mapping = gamepad.Mapping;
        labelOutput = mapping;

        gamepads.Dispose();
    }

    public const string BUTTON_GET_TIMESTAMP = "gamepad-inprocess-get-timestamp";
    private void GetTimestamp() {
        IGamepadInProcess?[] gamepadSlots = GamepadAPI.GetGamepads();
        IGamepadInProcess[] gamepads = [.. gamepadSlots.OfType<IGamepadInProcess>()];
        if (gamepads.Length == 0)
            return;
        IGamepadInProcess gamepad = gamepads[0];

        double timestamp = gamepad.Timestamp;
        labelOutput = timestamp.ToString();

        gamepads.Dispose();
    }


    public const string BUTTON_GET_VIBRATION_ACTUATOR_EFFECTS = "gamepad-inprocess-get-vibration-actuator-effects";
    private void GetVibrationActuatorEffects() {
        IGamepadInProcess?[] gamepadSlots = GamepadAPI.GetGamepads();
        IGamepadInProcess[] gamepads = [.. gamepadSlots.OfType<IGamepadInProcess>()];
        if (gamepads.Length == 0)
            return;
        IGamepadInProcess gamepad = gamepads[0];

        string[] vibrationEffects = gamepad.VibrationActuatorEffects;
        labelOutput = $"({vibrationEffects.Length}): [{string.Join(", ", vibrationEffects)}]";

        gamepads.Dispose();
    }

    public const string BUTTON_PLAY_VIBRATION_ACTUATOR_EFFECT = "gamepad-inprocess-play-vibration-actuator-effect";
    private async Task PlayVibrationActuatorEffect() {
        IGamepadInProcess?[] gamepadSlots = GamepadAPI.GetGamepads();
        IGamepadInProcess[] gamepads = [.. gamepadSlots.OfType<IGamepadInProcess>()];
        if (gamepads.Length == 0)
            return;
        IGamepadInProcess gamepad = gamepads[0];

        string rumbleResult = await gamepad.PlayVibrationActuatorEffect("dual-rumble", duration: 300);
        labelOutput = rumbleResult;

        gamepads.Dispose();
    }

    public const string BUTTON_RESET_VIBRATION_ACTUATOR = "gamepad-inprocess-reset-vibration-actuator";
    private async Task ResetVibrationActuator() {
        IGamepadInProcess?[] gamepadSlots = GamepadAPI.GetGamepads();
        IGamepadInProcess[] gamepads = [.. gamepadSlots.OfType<IGamepadInProcess>()];
        if (gamepads.Length == 0)
            return;
        IGamepadInProcess gamepad = gamepads[0];

        string rumbleResetResult = await gamepad.ResetVibrationActuator();
        labelOutput = rumbleResetResult;

        gamepads.Dispose();
    }
}
