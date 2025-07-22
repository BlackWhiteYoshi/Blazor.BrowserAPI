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
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IAsyncDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class DirectoryHandle(IJSObjectReference directoryHandleJS) : DirectoryHandleBase(directoryHandleJS), IDirectoryHandle {
    [AutoInterfaceVisibilityInternal]
    IJSObjectReference IDirectoryHandle.DirectoryHandleJS => directoryHandleJS;

    /// <summary>
    /// Releases the JS instance for this directory handle.
    /// </summary>
    /// <returns></returns>
    public ValueTask DisposeAsync() => directoryHandleJS.DisposeTrySync();


    /// <summary>
    /// Returns the name of the associated entry.
    /// </summary>
    public ValueTask<string> Name => GetName(default);

    /// <inheritdoc cref="Name" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetName(CancellationToken cancellationToken) => directoryHandleJS.InvokeTrySync<string>("getName", cancellationToken);


    /// <summary>
    /// Compares two directory handles to see if the associated entries match.
    /// </summary>
    /// <param name="other">The DirectoryHandle to match against the handle on which the method is invoked.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> IsSameEntry(IDirectoryHandle other, CancellationToken cancellationToken = default) => directoryHandleJS.InvokeAsync<bool>("isSameEntry", cancellationToken, [other.DirectoryHandleJS]);

    /// <summary>
    /// Returns a Promise fulfilled with a FileSystemDirectoryHandle for a subdirectory with the specified name within the directory handle on which the method is called.
    /// </summary>
    /// <param name="name">A string representing the FileSystemHandle.name of the subdirectory you wish to retrieve.</param>
    /// <param name="create">A boolean value, which defaults to false. When set to true if the directory is not found, one with the specified name will be created and returned.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IDirectoryHandle> GetDirectoryHandle(string name, bool create = false, CancellationToken cancellationToken = default) {
        IJSObjectReference subDirectoryHandleJS = await GetDirectoryHandleBase(name, create, cancellationToken);
        return new DirectoryHandle(subDirectoryHandleJS);
    }

    /// <summary>
    /// Returns a Promise fulfilled with a FileSystemFileHandle for a file with the specified name, within the directory the method is called.
    /// </summary>
    /// <param name="name">A string representing the FileSystemHandle.name of the file you wish to retrieve.</param>
    /// <param name="create">A Boolean. Default false. When set to true if the file is not found, one with the specified name will be created and returned.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IFileHandle> GetFileHandle(string name, bool create = false, CancellationToken cancellationToken = default) {
        IJSObjectReference fileHandleJS = await GetFileHandleBase(name, create, cancellationToken);
        return new FileHandle(fileHandleJS);
    }


    /// <summary>
    /// Returns all entries (files, directories) located in this directory.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This method uses the <see href="https://developer.mozilla.org/en-US/docs/Web/API/FileSystemDirectoryHandle/values">values()</see> Asynchronous iterator method to create these lists.
    /// Since returning each entry one by one would be unnecessary slow, all entries are iterated and returned at once.
    /// </para>
    /// <para>Do not forget to call <i>DispseAsync()</i> on each single item in fileList and directoryList when you done with it.</para>
    /// </remarks>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<(IFileHandle[] fileList, IDirectoryHandle[] directoryList)> Values(CancellationToken cancellationToken = default) {
        EntryList entryList = await ValuesBase(cancellationToken);

        IFileHandle[] fileList = new IFileHandle[entryList.FileList.Length];
        for (int i = 0; i < fileList.Length; i++)
            fileList[i] = new FileHandle(entryList.FileList[i]);

        IDirectoryHandle[] directoryList = new IDirectoryHandle[entryList.DirectoryList.Length];
        for (int i = 0; i < directoryList.Length; i++)
            directoryList[i] = new DirectoryHandle(entryList.DirectoryList[i]);

        return (fileList, directoryList);
    }
}
