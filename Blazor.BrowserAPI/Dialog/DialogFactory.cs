using AutoInterfaceAttributes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI;

/// <summary>
/// <para>This class can take a <see cref="ElementReference"/> of &lt;dialog&gt; and creates a <see cref="IDialog"/> or <see cref="IDialogInProcess"/> object with it.</para>
/// <para>
/// This factory <b>does not dispose</b> the created onjects, they must disposed manually.
/// So do not forget to call <see cref="IDisposable.Dispose"/>/<see cref="IAsyncDisposable.DisposeAsync"/> on a dialog-object when you are done with it.
/// </para>
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
        Task<IJSObjectReference> dialogTask = moduleManager.InvokeTrySync<IJSObjectReference>("createDialog", default, [dialog]).AsTask();
        return new Dialog(dialogTask);
    }

    /// <summary>
    /// Takes a <see cref="ElementReference"/> of &lt;dialog&gt; and returns a <see cref="IDialogInProcess"/> interface to interact with the given &lt;dialog&gt;.
    /// </summary>
    /// <param name="dialog">An <see cref="ElementReference"/> referencing a &lt;dialog&gt; html tag.</param>
    /// <returns>An object that can be used to interact with the given &lt;dialog&gt; element.</returns>
    public IDialogInProcess CreateInProcess(ElementReference dialog) {
        IJSInProcessObjectReference dialogJS = moduleManager.InvokeSync<IJSInProcessObjectReference>("createDialog", [dialog]);
        return new DialogInProcess(dialogJS);
    }
}
