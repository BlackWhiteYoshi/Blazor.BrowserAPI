using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Demo.Client;

public sealed partial class Download : ComponentBase {
    [Inject]
    public required IDownload PDownload { private get; init; }

    private string textAreaContent = "BlackWhiteYoshi";

    private async Task DownloadTextAreaContent() => await PDownload.DownloadAsFile("file.txt", textAreaContent);
}
