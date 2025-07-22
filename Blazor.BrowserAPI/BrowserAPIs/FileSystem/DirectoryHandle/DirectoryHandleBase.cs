using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IDirectoryHandle")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IDirectoryHandleInProcess")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class DirectoryHandleBase(IJSObjectReference directoryHandleJS) {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IJSObjectReference directoryHandleJS = directoryHandleJS;


    /// <summary>
    /// Returns the type of entry.
    /// This is 'file' if the associated entry is a file or 'directory'.
    /// It is used to distinguish files from directories when iterating over the contents of a directory.
    /// </summary>
    /// <remarks>
    /// Note: This API does not have a common <see href="https://developer.mozilla.org/en-US/docs/Web/API/FileSystemHandle">FileSystemHandle</see> type, so this property always returns "directory".
    /// </remarks>
    public string Kind => "directory";


    private protected ValueTask<IJSObjectReference> GetDirectoryHandleBase(string name, bool create, CancellationToken cancellationToken)
        => directoryHandleJS.InvokeAsync<IJSObjectReference>("getDirectoryHandle", cancellationToken, [name, create]);

    private protected ValueTask<IJSObjectReference> GetFileHandleBase(string name, bool create, CancellationToken cancellationToken)
        => directoryHandleJS.InvokeAsync<IJSObjectReference>("getFileHandle", cancellationToken, [name, create]);

    /// <summary>
    /// Attempts to asynchronously remove an entry if the directory handle contains a file or directory called the name specified.
    /// </summary>
    /// <param name="name">A string representing the FileSystemHandle.name of the entry you wish to remove.</param>
    /// <param name="recursive">A boolean value, which defaults to false. When set to true entries will be removed recursively.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask RemoveEntry(string name, bool recursive = false, CancellationToken cancellationToken = default) => directoryHandleJS.InvokeVoidAsync("removeEntry", cancellationToken, [name, recursive]);


    private protected readonly record struct EntryList(IJSObjectReference[] FileList, IJSObjectReference[] DirectoryList);

    private protected ValueTask<EntryList> ValuesBase(CancellationToken cancellationToken)
        => directoryHandleJS.InvokeAsync<EntryList>("values", cancellationToken);
}
