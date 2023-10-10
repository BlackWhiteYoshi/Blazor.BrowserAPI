using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class ClipboardGroup : ComponentBase {
    public const string DATA_TESTID_READ = "clipboard-read";
    public const string DATA_TESTID_WRITE = "clipboard-write";

    public const string DATA_TESTID_OUTPUT = "clipboard-output";

    public const string WRITE_TEST = "clipboard write test";
    
    
    [Inject]
    public required IClipboard Clipboard { private get; init; }

    private string labelOutput = string.Empty;


    private async Task ClipboardRead() {
        labelOutput = await Clipboard.Read();
    }

    private async Task ClipboardWrite() {
        await Clipboard.Write(WRITE_TEST);
    }
}
