using AutoInterfaceAttributes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BrowserAPI;

/// <summary>
/// <para>This class can take a <see cref="ElementReference"/> of &lt;dialog&gt; and creates a <see cref="IDialogInProcess"/> object with it.</para>
/// <para>The <i>HTMLDialogElement</i> interface provides methods to manipulate &lt;dialog&gt; elements. It inherits properties and methods from the HTMLElement interface.</para>
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
    /// <param name="dialog"></param>
    /// <returns></returns>
    public IDialogInProcess Create(ElementReference dialog) {
        IJSInProcessObjectReference dialogJS = _moduleManager.InvokeSync<IJSInProcessObjectReference>("createDialog", dialog);
        return new DialogInProcess(dialogJS);
    }
}
