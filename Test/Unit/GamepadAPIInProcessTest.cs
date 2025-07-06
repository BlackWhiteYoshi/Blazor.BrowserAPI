using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class GamepadAPIInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
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
        // an assertion happens in DisposeAsync()
    }

    [Test]
    public async Task RegisterOnGamepadDisconnected() {
        await ExecuteTest(GamepadAPIInProcessGroup.BUTTON_REGISTER_ON_GAMEPAD_DISCONNECTED);
        // an assertion happens in DisposeAsync()
    }


    // gamepad tests omitted: gamepad not working: Even when a gamepad is plugged in, it is not recognized (probably it need a button press to be recognized)
}
