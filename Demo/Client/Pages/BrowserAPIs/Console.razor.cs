using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Demo.Client;

public sealed partial class Console : ComponentBase {
    [Inject]
    public required IConsole PConsole { private get; init; }

    private async Task ConsoleLog() => await PConsole.Log("Standard output massage to the console.");
    private async Task ConsoleInfo() => await PConsole.Info("Shows only when info is enabled.");
    private async Task ConsoleDebug() => await PConsole.Debug("Shows only on verbose log level.");
    private async Task ConsoleWarning() => await PConsole.Warn("You have been warned.");
    private async Task ConsoleError() => await PConsole.Error("serious error: Button pressed");
    private async Task ConsoleAssert() => await PConsole.Assert(1 == 2, "1 is not equal 2 (obviously)");
    private async Task ConsoleClear() => await PConsole.Clear();
}
