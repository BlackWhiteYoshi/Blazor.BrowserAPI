using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Demo.Client;

public sealed partial class Window : ComponentBase {
    [Inject]
    public required IWindow PWindow { private get; init; }


    private int? outerWidth = null;
    private async Task GetOuterWidth() => outerWidth = await PWindow.OuterWidth;

    private int? outerHeight = null;
    private async Task GetOuterHeight() => outerHeight = await PWindow.OuterHeight;

    private bool? isSecureContext = null;
    private async Task GetIsSecureContext() => isSecureContext = await PWindow.IsSecureContext;


    private string? promptAnswer = null;
    private async Task BrowserPrompt() => promptAnswer = (await PWindow.Prompt("BlackWhiteYoshi", "green")) ?? "prompt got canceled";

    private bool? conformAnswer = null;
    private async Task BrowserConfirm() => conformAnswer = await PWindow.Confirm("Press \"OK\" or \"Cancel\", the choice is yours.");

    private async Task BrowserAlert() => await PWindow.Alert("critical error:\nuser clicked THE button!");

    private async Task BrowserPrint() => await PWindow.Print();
}
