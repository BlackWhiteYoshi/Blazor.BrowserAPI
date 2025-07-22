using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IFileHandle")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IFileHandleInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class FileHandleBase(IJSObjectReference fileHandleJS) {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IJSObjectReference fileHandleJS = fileHandleJS;


    /// <summary>
    /// Returns the type of entry.
    /// This is 'file' if the associated entry is a file or 'directory'.
    /// It is used to distinguish files from directories when iterating over the contents of a directory.
    /// </summary>
    /// <remarks>
    /// Note: This API does not have a common <see href="https://developer.mozilla.org/en-US/docs/Web/API/FileSystemHandle">FileSystemHandle</see> type, so this property always returns "file".
    /// </remarks>
    public string Kind => "file";


    private protected ValueTask<bool> IsSameEntryBase(IJSObjectReference other, CancellationToken cancellationToken) => fileHandleJS.InvokeAsync<bool>("isSameEntry", cancellationToken, [other]);

    private protected ValueTask<IJSObjectReference> GetFileBase(CancellationToken cancellationToken)
        => fileHandleJS.InvokeAsync<IJSObjectReference>("getFile", cancellationToken);

    private protected ValueTask<IJSObjectReference> CreateWritableBase(bool keepExistingData, string mode, CancellationToken cancellationToken)
        => fileHandleJS.InvokeAsync<IJSObjectReference>("createWritable", cancellationToken, [keepExistingData, mode]);
}
