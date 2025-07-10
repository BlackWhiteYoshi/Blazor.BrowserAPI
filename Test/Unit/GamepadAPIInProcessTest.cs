using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class GamepadAPIInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    private const string JS_GAMEPAD_OBJECT = """
        {
            axes: [0.0, 1.0],
            buttons: [
                { pressed: true, touched: true, value: 1.0 },
                { pressed: false, touched: false, value: 0 },
                { pressed: false, touched: false, value: 0 }
            ],
            connected: true,
            id: "fake-controller",
            index: 0,
            mapping: "standard",
            timestamp: 1750000000000,
            vibrationActuator: {
                effects: ["dual-rumble"],
                playEffect: (type, params) => new Promise((resolve) => resolve("complete")),
                reset: () => new Promise((resolve) => resolve("complete"))
            }
        }
        """;


    [Test]
    public async Task GetGamepads() {
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_GET_GAMEPADS);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        bool isNumber = int.TryParse(result, out int resultAsNumber);
        await Assert.That(isNumber).IsTrue();
        await Assert.That(resultAsNumber).IsGreaterThanOrEqualTo(0);
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
        await Page.EvaluateAsync($"navigator.getGamepads = () => [{JS_GAMEPAD_OBJECT}];");
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_GET_AXES);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("(2): [0, 1]");
    }

    [Test]
    public async Task GetButtons() {
        await Page.EvaluateAsync($"navigator.getGamepads = () => [{JS_GAMEPAD_OBJECT}];");
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_GET_BUTTONS);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("(3): [GamepadButton { Pressed = True, Touched = True, Value = 1 }, GamepadButton { Pressed = False, Touched = False, Value = 0 }, GamepadButton { Pressed = False, Touched = False, Value = 0 }]");
    }


    [Test]
    public async Task GetConnected() {
        await Page.EvaluateAsync($"navigator.getGamepads = () => [{JS_GAMEPAD_OBJECT}];");
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_GET_CONNECTED);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task GetId() {
        await Page.EvaluateAsync($"navigator.getGamepads = () => [{JS_GAMEPAD_OBJECT}];");
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_GET_ID);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("fake-controller");
    }

    [Test]
    public async Task GetIndex() {
        await Page.EvaluateAsync($"navigator.getGamepads = () => [{JS_GAMEPAD_OBJECT}];");
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_GET_INDEX);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("0");
    }

    [Test]
    public async Task GetMapping() {
        await Page.EvaluateAsync($"navigator.getGamepads = () => [{JS_GAMEPAD_OBJECT}];");
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_GET_MAPPING);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("standard");
    }

    [Test]
    public async Task GetTimestamp() {
        await Page.EvaluateAsync($"navigator.getGamepads = () => [{JS_GAMEPAD_OBJECT}];");
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_GET_TIMESTAMP);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("1750000000000");
    }


    [Test]
    public async Task GetVibrationActuatorEffects() {
        await Page.EvaluateAsync($"navigator.getGamepads = () => [{JS_GAMEPAD_OBJECT}];");
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_GET_VIBRATION_ACTUATOR_EFFECTS);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("(1): [dual-rumble]");
    }

    [Test]
    public async Task PlayVibrationActuatorEffect() {
        await Page.EvaluateAsync($"navigator.getGamepads = () => [{JS_GAMEPAD_OBJECT}];");
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_PLAY_VIBRATION_ACTUATOR_EFFECT);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("complete");
    }

    [Test]
    public async Task ResetVibrationActuator() {
        await Page.EvaluateAsync($"navigator.getGamepads = () => [{JS_GAMEPAD_OBJECT}];");
        await Task.Delay(SMALL_WAIT_TIME);
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_RESET_VIBRATION_ACTUATOR);

        string? result = await Page.GetByTestId(GamepadAPIInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("complete");
    }
}
