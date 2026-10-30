using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Demo.Client;

public sealed partial class Clipboard : ComponentBase {
    [Inject]
    public required IClipboard PClipboard { private get; init; }

    private string textAreaContent = "BlackWhiteYoshi";
    private string? savedValue = null;

    private async Task CopyTextToClipboard() => await PClipboard.Write(textAreaContent);
    private async Task GetTextFromClipboard() => savedValue = await PClipboard.Read();
}
