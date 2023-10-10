using AutoInterfaceAttributes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BrowserAPI;

/// <summary>
/// <para>This class can take a <see cref="ElementReference"/> of &lt;dialog&gt; and creates a <see cref="IDialogInProcess"/> object with it.</para>
/// <para>The <i>HTMLDialogElement</i> interface provides methods to manipulate &lt;dialog&gt; elements. It inherits properties and methods from the HTMLElement interface.</para>
/// </summary>
[AutoInterface]
internal sealed class DialogFactory : IDialogFactory {
    private readonly IModuleManager _moduleManager;

    public DialogFactory(IModuleManager moduleManager) {
        _moduleManager = moduleManager;
    }

    /// <summary>
    /// Takes a <see cref="ElementReference"/> of &lt;dialog&gt; and returns a <see cref="IDialog"/> interface to interact with the given &lt;dialog&gt;.
    /// </summary>
    /// <param name="dialog"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IDialog> Create(ElementReference dialog, CancellationToken cancellationToken = default) {
        IJSObjectReference dialogJS = await _moduleManager.InvokeTrySync<IJSObjectReference>("createDialog", cancellationToken, dialog);
        return new Dialog(dialogJS);
    }
}
