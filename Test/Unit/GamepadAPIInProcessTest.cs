using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class GamepadAPIInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    private const string GAMEPAD_ID = "fake-controller";
    private const string GAMEPAD_INDEX = "0";
    private const string GAMEPAD_MAPPING = "standard";
    private const string GAMEPAD_TIMESTAMP = "1750000000000";
    private const string GAMEPAD_VIBRATION_ACTUATOR_EFFECT = "dual-rumble";
    private const string GAMEPAD_VIBRATION_ACTUATOR_RESULT = "complete";

    private const string JS_GAMEPAD_OBJECT = $$"""
        {
            axes: [0.0, 1.0],
            buttons: [
                { pressed: true, touched: true, value: 1.0 },
                { pressed: false, touched: false, value: 0 },
                { pressed: false, touched: false, value: 0 }
            ],
            connected: true,
            id: "{{GAMEPAD_ID}}",
            index: {{GAMEPAD_INDEX}},
            mapping: "{{GAMEPAD_MAPPING}}",
            timestamp: {{GAMEPAD_TIMESTAMP}},
            vibrationActuator: {
                effects: ["{{GAMEPAD_VIBRATION_ACTUATOR_EFFECT}}"],
                playEffect: (type, params) => Promise.resolve("{{GAMEPAD_VIBRATION_ACTUATOR_RESULT}}"),
                reset: () => Promise.resolve("{{GAMEPAD_VIBRATION_ACTUATOR_RESULT}}")
            }
        }
        """;

    public override async Task SetUp() {
        await base.SetUp();
        await Page.EvaluateAsync($"navigator.getGamepads = () => [{JS_GAMEPAD_OBJECT}];");
        await Task.Delay(SMALL_WAIT_TIME);
    }


    [Test]
    public async Task GetGamepads() {
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_GET_GAMEPADS);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("Slots = 1, Connected = 1");
    }

    [Test]
    public async Task RegisterOnGamepadConnected() {
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_REGISTER_ON_GAMEPAD_CONNECTED);
        await Page.EvaluateAsync($"""
            const event = new Event("gamepadconnected");
            event.gamepad = {JS_GAMEPAD_OBJECT};
            window.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(GamepadAPIInProcessGroup.TEST_GAMEPAD_CONNECTED_EVENT);
    }

    [Test]
    public async Task RegisterOnGamepadDisconnected() {
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_REGISTER_ON_GAMEPAD_DISCONNECTED);
        await Page.EvaluateAsync($"""
            const event = new Event("gamepaddisconnected");
            event.gamepad = {JS_GAMEPAD_OBJECT};
            window.dispatchEvent(event);
            """);
        await Task.Delay(STANDARD_WAIT_TIME);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(GamepadAPIInProcessGroup.TEST_GAMEPAD_DISCONNECTED_EVENT);
    }


    [Test]
    public async Task GetAxes() {
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_GET_AXES);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("(2): [0, 1]");
    }

    [Test]
    public async Task GetButtons() {
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_GET_BUTTONS);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("(3): [GamepadButton { Pressed = True, Touched = True, Value = 1 }, GamepadButton { Pressed = False, Touched = False, Value = 0 }, GamepadButton { Pressed = False, Touched = False, Value = 0 }]");
    }


    [Test]
    public async Task GetConnected() {
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_GET_CONNECTED);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetId() {
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_GET_ID);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(GAMEPAD_ID);
    }

    [Test]
    public async Task GetIndex() {
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_GET_INDEX);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(GAMEPAD_INDEX);
    }

    [Test]
    public async Task GetMapping() {
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_GET_MAPPING);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(GAMEPAD_MAPPING);
    }

    [Test]
    public async Task GetTimestamp() {
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_GET_TIMESTAMP);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(GAMEPAD_TIMESTAMP);
    }


    [Test]
    public async Task GetVibrationActuatorEffects() {
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_GET_VIBRATION_ACTUATOR_EFFECTS);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo($"(1): [{GAMEPAD_VIBRATION_ACTUATOR_EFFECT}]");
    }

    [Test]
    public async Task PlayVibrationActuatorEffect() {
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_PLAY_VIBRATION_ACTUATOR_EFFECT);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(GAMEPAD_VIBRATION_ACTUATOR_RESULT);
    }

    [Test]
    public async Task ResetVibrationActuator() {
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_RESET_VIBRATION_ACTUATOR);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(GAMEPAD_VIBRATION_ACTUATOR_RESULT);
    }
}
