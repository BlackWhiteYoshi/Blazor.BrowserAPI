using AutoInterfaceAttributes;

namespace BrowserAPI;

/// <summary>
/// The Clipboard interface implements the Clipboard API, providing—if the user grants permission—both read and write access to the contents of the system clipboard.
/// </summary>
[AutoInterface]
internal sealed class Clipboard : IClipboard {
    private readonly IModuleManager _moduleManager;

    public Clipboard(IModuleManager moduleManager) {
        _moduleManager = moduleManager;
    }


    /// <summary>
    /// <para>navigator.clipboard.writeText(text);</para>
    /// <para>The Clipboard interface's writeText() property writes the specified text string to the system clipboard. Text may be read back using either read() or readText().</para>
    /// </summary>
    /// <param name="text">The string to be written to the clipboard.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask Write(string text, CancellationToken cancellationToken = default) => _moduleManager.InvokeAsync("clipboardWriteText", cancellationToken, text);

    /// <summary>
    /// <para>navigator.clipboard.readText();</para>
    /// <para>The Clipboard interface's readText() method returns a Promise which resolves with a copy of the textual contents of the system clipboard.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> Read(CancellationToken cancellationToken = default) => _moduleManager.InvokeAsync<string>("clipboardReadText", cancellationToken);
}
