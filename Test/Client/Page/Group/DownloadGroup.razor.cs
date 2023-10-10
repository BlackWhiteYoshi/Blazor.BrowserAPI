using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class DownloadGroup : ComponentBase {
    public const string DATA_TESTID = "download";

    public const string FILENAME = "Test.txt";
    public const string FILECONTENT = "some test content\n";


    [Inject]
    public required IDownload Download { private get; init; }


    private async Task DoDownload() {
        await Download.DownloadAsFile(FILENAME, FILECONTENT);
    }
}
