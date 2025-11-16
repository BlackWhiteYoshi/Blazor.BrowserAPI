using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class DownloadGroup : ComponentBase {
    public const string TEST_FILENAME = "Test.txt";
    public const string TEST_FILECONTENT = "some test content\n";


    [Inject]
    public required IDownload Download { private get; init; }


    public const string BUTTON_DOWNLOAD_AS_FILE = "download";
    private async Task DownloadAsFile() {
        await Download.DownloadAsFile(TEST_FILENAME, TEST_FILECONTENT);
    }
}
