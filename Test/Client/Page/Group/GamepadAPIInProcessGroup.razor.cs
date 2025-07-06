using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class GamepadAPIInProcessGroup : ComponentBase {
    public const string GAMEPAD_CONNECTED = "gamepad connected";
    public const string GAMEPAD_DISCONNECTED = "gamepad disconnected";


    [Inject]
    public required IGamepadAPIInProcess GamepadAPI { private get; init; }


    public const string LABEL_OUTPUT = "gamepad-inprocess-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_GET_GAMEPADS = "gamepad-inprocess-get-gamepads";
    private void GetGamepads() {
        IGamepadInProcess[] gamepads = GamepadAPI.GetGamepads();
        labelOutput = gamepads.Length.ToString();

        gamepads.Dispose();
    }

    public const string BUTTON_REGISTER_ON_GAMEPAD_CONNECTED = "gamepad-inprocess-gamepad-connected-event";
    private void RegisterOnGamepadConnected() {
        GamepadAPI.OnGamepadConnected += (IGamepadInProcess gamepad) => {
            labelOutput = GAMEPAD_CONNECTED;
            StateHasChanged();

            gamepad.Dispose();
        };
    }

    public const string BUTTON_REGISTER_ON_GAMEPAD_DISCONNECTED = "gamepad-inprocess-gamepad-disconnected-event";
    private void RegisterOnGamepadDisconnected() {
        GamepadAPI.OnGamepadDisconnected += (IGamepadInProcess gamepad) => {
            labelOutput = GAMEPAD_DISCONNECTED;
            StateHasChanged();

            gamepad.Dispose();
        };
    }


    public const string BUTTON_GET_AXES = "gamepad-inprocess-get-axes";
    private void GetAxes() {
        IGamepadInProcess[] gamepads = GamepadAPI.GetGamepads();
        if (gamepads.Length == 0)
            return;
        IGamepadInProcess gamepad = gamepads[0];

        double[] axes = gamepad.Axes;
        labelOutput = $"({axes.Length}): [{string.Join(", ", axes)}]";

        gamepads.Dispose();
    }

    public const string BUTTON_GET_BUTTONS = "gamepad-inprocess-get-buttons";
    private void GetButtons() {
        IGamepadInProcess[] gamepads = GamepadAPI.GetGamepads();
        if (gamepads.Length == 0)
            return;
        IGamepadInProcess gamepad = gamepads[0];

        GamepadButton[] buttons = gamepad.Buttons;
        labelOutput = $"({buttons.Length}): {string.Join(", ", buttons)}";

        gamepads.Dispose();
    }


    public const string BUTTON_GET_CONNECTED = "gamepad-get-connected";
    public void GetConnected() {
        IGamepadInProcess[] gamepads = GamepadAPI.GetGamepads();
        if (gamepads.Length == 0)
            return;
        IGamepadInProcess gamepad = gamepads[0];

        bool connected = gamepad.Connected;
        labelOutput = connected.ToString();

        gamepads.Dispose();
    }

    public const string BUTTON_GET_ID = "gamepad-get-id";
    public void GetId() {
        IGamepadInProcess[] gamepads = GamepadAPI.GetGamepads();
        if (gamepads.Length == 0)
            return;
        IGamepadInProcess gamepad = gamepads[0];

        string id = gamepad.Id;
        labelOutput = id;

        gamepads.Dispose();
    }

    public const string BUTTON_GET_INDEX = "gamepad-get-index";
    public void GetIndex() {
        IGamepadInProcess[] gamepads = GamepadAPI.GetGamepads();
        if (gamepads.Length == 0)
            return;
        IGamepadInProcess gamepad = gamepads[0];

        int index = gamepad.Index;
        labelOutput = index.ToString();

        gamepads.Dispose();
    }

    public const string BUTTON_GET_MAPPING = "gamepad-get-mapping";
    public void GetMapping() {
        IGamepadInProcess[] gamepads = GamepadAPI.GetGamepads();
        if (gamepads.Length == 0)
            return;
        IGamepadInProcess gamepad = gamepads[0];

        string mapping = gamepad.Mapping;
        labelOutput = mapping;

        gamepads.Dispose();
    }

    public const string BUTTON_GET_TIMESTAMP = "gamepad-get-timestamp";
    public void GetTimestamp() {
        IGamepadInProcess[] gamepads = GamepadAPI.GetGamepads();
        if (gamepads.Length == 0)
            return;
        IGamepadInProcess gamepad = gamepads[0];

        double timestamp = gamepad.Timestamp;
        labelOutput = timestamp.ToString();

        gamepads.Dispose();
    }


    public const string BUTTON_GET_VIBRATION_ACTUATOR_EFFECTS = "gamepad-get-vibration-actuator-effects";
    public void GetVibrationActuatorEffects() {
        IGamepadInProcess[] gamepads = GamepadAPI.GetGamepads();
        if (gamepads.Length == 0)
            return;
        IGamepadInProcess gamepad = gamepads[0];

        string[] vibrationEffects = gamepad.VibrationActuatorEffects;
        labelOutput = $"({vibrationEffects.Length}): [{string.Join(", ", vibrationEffects)}]";

        gamepads.Dispose();
    }

    public const string BUTTON_PLAY_VIBRATION_ACTUATOR_EFFECT = "gamepad-play-vibration-actuator-effect";
    public async Task PlayVibrationActuatorEffect() {
        IGamepadInProcess[] gamepads = GamepadAPI.GetGamepads();
        if (gamepads.Length == 0)
            return;
        IGamepadInProcess gamepad = gamepads[0];

        string rumbleResult = await gamepad.PlayVibrationActuatorEffect("dual-rumble", duration: 300);
        labelOutput = rumbleResult;

        gamepads.Dispose();
    }

    public const string BUTTON_RESET_VIBRATION_ACTUATOR = "gamepad-reset-vibration-actuator";
    public async Task ResetVibrationActuator() {
        IGamepadInProcess[] gamepads = GamepadAPI.GetGamepads();
        if (gamepads.Length == 0)
            return;
        IGamepadInProcess gamepad = gamepads[0];

        string rumbleResetResult = await gamepad.ResetVibrationActuator();
        labelOutput = rumbleResetResult;

        gamepads.Dispose();
    }
}
