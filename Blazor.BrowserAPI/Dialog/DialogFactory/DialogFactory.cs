﻿using AutoInterfaceAttributes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BrowserAPI;

/// <summary>
/// This class can take a <see cref="ElementReference"/> of &lt;dialog&gt; and creates a <see cref="IDialog"/> object with it.
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
    /// <param name="dialog">An <see cref="ElementReference"/> referencing a &lt;dialog&gt; html tag.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>An object that can be used to interact with the given &lt;dialog&gt; element.</returns>
    public async ValueTask<IDialog> Create(ElementReference dialog, CancellationToken cancellationToken = default) {
        IJSObjectReference dialogJS = await _moduleManager.InvokeTrySync<IJSObjectReference>("createDialog", cancellationToken, dialog);
        return new Dialog(dialogJS);
    }
}
