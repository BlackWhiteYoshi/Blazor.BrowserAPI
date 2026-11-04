using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Demo.Client;

public sealed partial class GamepadAPI : ComponentBase, IDisposable {
    [Inject]
    public required IGamepadAPI PGamepadAPI { private get; init; }

    public void Dispose() => periodicTimer?.Dispose();


    private readonly record struct GamepadInfo(string Id, int Index, string Mapping, string[] VibrationActuatorEffects, double[] Axes, GamepadButton[] Buttons);
    private readonly List<GamepadInfo> gamepadInfoList = [];


    private async Task GetGamePads() {
        gamepadInfoList.Clear();
        IGamepad?[] gamepads = await PGamepadAPI.GetGamepads();
        foreach (IGamepad? gamepad in gamepads)
            if (gamepad is not null) {
                GamepadInfo gamepadInfo = new(await gamepad.Id, await gamepad.Index, await gamepad.Mapping, await gamepad.VibrationActuatorEffects, await gamepad.Axes, await gamepad.Buttons);
                gamepadInfoList.Add(gamepadInfo);
                await gamepad.DisposeAsync();
            }
    }


    // ReadGamepadLoop

    private PeriodicTimer? periodicTimer = null;
    private bool isLoopActive = false;

    private async Task StartReadGamepadLoop() {
        isLoopActive = true;
        periodicTimer = new(TimeSpan.FromMilliseconds(100));
        _ = ReadGamepadsLoop();
    }

    private async Task StopReadGamepadLoop() {
        isLoopActive = false;
        periodicTimer!.Dispose();
    }

    private async Task ReadGamepadsLoop() {
        while (await periodicTimer!.WaitForNextTickAsync()) {
            await GetGamePads();
            await InvokeAsync(StateHasChanged);
        }

        periodicTimer = null;
    }


    // Rumble

    private bool isRumbling = false;

    private async Task RumbleGamepads() {
        isRumbling = true;
        List<Task> rumbleTasks = [];

        IGamepad?[] gamepads = await PGamepadAPI.GetGamepads();
        foreach (IGamepad? gamepad in gamepads)
            if (gamepad is not null) {
                string[] effects = await gamepad.VibrationActuatorEffects;
                if (effects.Length >= 1)
                    rumbleTasks.Add(gamepad.PlayVibrationActuatorEffect(type: effects[0], duration: 1000).AsTask());

                await gamepad.DisposeAsync();
            }

        await Task.WhenAll(rumbleTasks);
        isRumbling = false;
    }
}
