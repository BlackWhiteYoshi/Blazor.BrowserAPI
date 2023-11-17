﻿using AutoInterfaceAttributes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI;

/// <summary>
/// This class can take a <see cref="ElementReference"/> of &lt;dialog&gt; and creates a <see cref="IDialog"/> or <see cref="IDialogInProcess"/> object with it.
/// </summary>
[AutoInterface]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
internal sealed class DialogFactory(IModuleManager moduleManager) : IDialogFactory {
    /// <summary>
    /// Takes a <see cref="ElementReference"/> of &lt;dialog&gt; and returns a <see cref="IDialog"/> interface to interact with the given &lt;dialog&gt;.
    /// </summary>
    /// <param name="dialog">An <see cref="ElementReference"/> referencing a &lt;dialog&gt; html tag.</param>
    /// <returns>An object that can be used to interact with the given &lt;dialog&gt; element.</returns>
    public IDialog Create(ElementReference dialog) {
        Task<IJSObjectReference> dialogJS = moduleManager.InvokeTrySync<IJSObjectReference>("createDialog", default, dialog).AsTask();
        return new Dialog(dialogJS);
    }

    /// <summary>
    /// Takes a <see cref="ElementReference"/> of &lt;dialog&gt; and returns a <see cref="IDialogInProcess"/> interface to interact with the given &lt;dialog&gt;.
    /// </summary>
    /// <param name="dialog">An <see cref="ElementReference"/> referencing a &lt;dialog&gt; html tag.</param>
    /// <returns>An object that can be used to interact with the given &lt;dialog&gt; element.</returns>
    public IDialogInProcess CreateInProcess(ElementReference dialog) {
        IJSInProcessObjectReference dialogJS = moduleManager.InvokeSync<IJSInProcessObjectReference>("createDialog", dialog);
        return new DialogInProcess(dialogJS);
    }
}
