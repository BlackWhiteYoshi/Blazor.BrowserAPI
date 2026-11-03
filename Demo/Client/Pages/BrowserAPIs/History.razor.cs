using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Demo.Client;

public sealed partial class History : ComponentBase {
    [Inject]
    public required IHistory PHistory { private get; init; }

    private int? length = null;
    private string? scrollRestoration = null;


    private async Task GetLength() => length = await PHistory.Length;

    private async Task GetScrollRestoration() => scrollRestoration = await PHistory.ScrollRestoration;


    private async Task Forward() => await PHistory.Forward();

    private async Task Back() => await PHistory.Back();
}
