using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class ClipboardGroup : ComponentBase {
    public const string TEST_WRITE = "clipboard write test";


    [Inject]
    public required IClipboard Clipboard { private get; init; }


    public const string OUTPUT = "clipboard-output";
    private string output = string.Empty;


    public const string BUTTON_READ = "clipboard-read";
    private async Task Read() {
        output = await Clipboard.Read();
    }

    public const string BUTTON_WRITE = "clipboard-write";
    private async Task Write() {
        await Clipboard.Write(TEST_WRITE);
    }
}
