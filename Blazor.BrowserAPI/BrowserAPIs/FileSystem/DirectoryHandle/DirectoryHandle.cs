using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The <i>FileSystemDirectoryHandle</i> interface of the File System API provides a handle to a file system directory.</para>
/// <para>
/// The interface can be accessed via the following methods:<br />
/// - <see href="https://developer.mozilla.org/en-US/docs/Web/API/Window/showDirectoryPicker">window.showDirectoryPicker()</see><br />
/// - <see href="https://developer.mozilla.org/en-US/docs/Web/API/StorageManager/getDirectory">StorageManager.getDirectory()</see><br />
/// - <see href="https://developer.mozilla.org/en-US/docs/Web/API/DataTransferItem/getAsFileSystemHandle">DataTransferItem.getAsFileSystemHandle()</see><br />
/// - <see href="https://developer.mozilla.org/en-US/docs/Web/API/FileSystemDirectoryHandle/getDirectoryHandle">FileSystemDirectoryHandle.getDirectoryHandle()</see>
/// </para>
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call <see cref="DisposeAsync"/> when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IDirectoryHandleBase<IJSObjectReference, IDirectoryHandle, IFileHandle, IFile, IWritableFileStream>), typeof(IAsyncDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class DirectoryHandle(IJSObjectReference directoryHandleJS) : DirectoryHandleBase<IJSObjectReference, IDirectoryHandle, IFileHandle, IFile, IWritableFileStream>(directoryHandleJS), IDirectoryHandle {
    /// <summary>
    /// Releases the JS instance for this directory handle.
    /// </summary>
    /// <returns></returns>
    public ValueTask DisposeAsync() => directoryHandleJS.DisposeTrySync();


    /// <summary>
    /// Returns the name of the associated entry.
    /// </summary>
    public ValueTask<string> Name => GetName(CancellationToken.None);

    /// <inheritdoc cref="Name" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetName(CancellationToken cancellationToken) => directoryHandleJS.InvokeTrySync<string>("getName", cancellationToken);
}
