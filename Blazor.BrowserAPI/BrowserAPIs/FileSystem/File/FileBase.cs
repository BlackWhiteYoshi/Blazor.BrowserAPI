using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// Base interface of <see cref="IFile"/> and <see cref="IFileInProcess"/>.<br/>
/// It contains common functionality for both interfaces.<br/>
/// It is not intended to use this interface directly.
/// </summary>
/// <typeparam name="TJSObjectReference"></typeparam>
/// <param name="fileJS"></param>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class FileBase<TJSObjectReference>(TJSObjectReference fileJS) : IFileBase<TJSObjectReference>
    where TJSObjectReference : IJSObjectReference {
    private protected TJSObjectReference fileJS = fileJS;

    [AutoInterfaceVisibilityInternal]
    TJSObjectReference IFileBase<TJSObjectReference>.FileJS => fileJS;


    /// <summary>
    /// Returns a promise that resolves with a string containing the entire contents of the Blob interpreted as UTF-8 text.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> Text(CancellationToken cancellationToken = default) => fileJS.InvokeAsync<string>("text", cancellationToken);
}
