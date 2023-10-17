using AutoInterfaceAttributes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BrowserAPI;

/// <summary>
/// This class can take a <see cref="ElementReference"/> of &lt;dialog&gt; and creates a <see cref="IDialogInProcess"/> object with it.
/// </summary>
[AutoInterface]
internal sealed class DialogInProcessFactory : IDialogInProcessFactory {
    private readonly IModuleManager _moduleManager;

    public DialogInProcessFactory(IModuleManager moduleManager) {
        _moduleManager = moduleManager;
    }

    /// <summary>
    /// Takes a <see cref="ElementReference"/> of &lt;dialog&gt; and returns a <see cref="IDialogInProcess"/> interface to interact with the given &lt;dialog&gt;.
    /// </summary>
    /// <param name="dialog">An <see cref="ElementReference"/> referencing a &lt;dialog&gt; html tag.</param>
    /// <returns>An object that can be used to interact with the given &lt;dialog&gt; element.</returns>
    public IDialogInProcess Create(ElementReference dialog) {
        IJSInProcessObjectReference dialogJS = _moduleManager.InvokeSync<IJSInProcessObjectReference>("createDialog", dialog);
        return new DialogInProcess(dialogJS);
    }
}
