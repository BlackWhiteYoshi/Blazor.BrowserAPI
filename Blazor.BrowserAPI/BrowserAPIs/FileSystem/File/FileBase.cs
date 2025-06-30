using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IFile")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IFileInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class FileBase(IJSObjectReference fileJS) {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IJSObjectReference fileJS = fileJS;


    /// <summary>
    /// Returns a promise that resolves with a string containing the entire contents of the Blob interpreted as UTF-8 text.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> Text(CancellationToken cancellationToken = default) => fileJS.InvokeAsync<string>("text", cancellationToken);
}
