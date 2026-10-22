using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// Base interface of <see cref="IDirectoryHandle"/> and <see cref="IDirectoryHandleInProcess"/>.<br/>
/// It contains common functionality for both interfaces.<br/>
/// It is not intended to use this interface directly.
/// </summary>
/// <typeparam name="TJSObjectReference"></typeparam>
/// <typeparam name="TDirectoryHandle"></typeparam>
/// <typeparam name="TFileHandle"></typeparam>
/// <typeparam name="TFile"></typeparam>
/// <typeparam name="TWritableFileStream"></typeparam>
/// <param name="directoryHandleJS"></param>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class DirectoryHandleBase<TJSObjectReference, TDirectoryHandle, TFileHandle, TFile, TWritableFileStream>(TJSObjectReference directoryHandleJS) : IDirectoryHandleBase<TJSObjectReference, TDirectoryHandle, TFileHandle, TFile, TWritableFileStream>
    where TJSObjectReference : IJSObjectReference
    where TDirectoryHandle : IDirectoryHandleBase<TJSObjectReference, TDirectoryHandle, TFileHandle, TFile, TWritableFileStream>
    where TFileHandle : IFileHandleBase<TJSObjectReference, TFileHandle, TFile, TWritableFileStream>
    where TFile : IFileBase<TJSObjectReference>
    where TWritableFileStream : IWritableFileStreamBase<TJSObjectReference> {
    private protected TJSObjectReference directoryHandleJS = directoryHandleJS;

    [AutoInterfaceVisibilityInternal]
    TJSObjectReference IDirectoryHandleBase<TJSObjectReference, TDirectoryHandle, TFileHandle, TFile, TWritableFileStream>.DirectoryHandleJS => directoryHandleJS;


    /// <summary>
    /// Returns the type of entry.
    /// This is 'file' if the associated entry is a file or 'directory'.
    /// It is used to distinguish files from directories when iterating over the contents of a directory.
    /// </summary>
    /// <remarks>
    /// Note: This API does not have a common <see href="https://developer.mozilla.org/en-US/docs/Web/API/FileSystemHandle">FileSystemHandle</see> type, so this property always returns "directory".
    /// </remarks>
    public string Kind => "directory";


    /// <summary>
    /// Compares two directory handles to see if the associated entries match.
    /// </summary>
    /// <param name="other">The DirectoryHandle to match against the handle on which the method is invoked.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> IsSameEntry(TDirectoryHandle other, CancellationToken cancellationToken = default) => directoryHandleJS.InvokeAsync<bool>("isSameEntry", cancellationToken, [other.DirectoryHandleJS]);

    /// <summary>
    /// Returns a Promise fulfilled with a FileSystemDirectoryHandle for a subdirectory with the specified name within the directory handle on which the method is called.
    /// </summary>
    /// <param name="name">A string representing the FileSystemHandle.name of the subdirectory you wish to retrieve.</param>
    /// <param name="create">A boolean value, which defaults to false. When set to true if the directory is not found, one with the specified name will be created and returned.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<TDirectoryHandle> GetDirectoryHandle(string name, bool create = false, CancellationToken cancellationToken = default) {
        TJSObjectReference subDirectoryHandleJS = await directoryHandleJS.InvokeAsync<TJSObjectReference>("getDirectoryHandle", cancellationToken, [name, create]);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference))
            return (TDirectoryHandle)(IDirectoryHandle)new DirectoryHandle(subDirectoryHandleJS);
        else
            return (TDirectoryHandle)(IDirectoryHandleInProcess)new DirectoryHandleInProcess((IJSInProcessObjectReference)subDirectoryHandleJS);
    }

    /// <summary>
    /// Returns a Promise fulfilled with a FileSystemFileHandle for a file with the specified name, within the directory the method is called.
    /// </summary>
    /// <param name="name">A string representing the FileSystemHandle.name of the file you wish to retrieve.</param>
    /// <param name="create">A Boolean. Default false. When set to true if the file is not found, one with the specified name will be created and returned.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<TFileHandle> GetFileHandle(string name, bool create = false, CancellationToken cancellationToken = default) {
        TJSObjectReference fileHandleJS = await directoryHandleJS.InvokeAsync<TJSObjectReference>("getFileHandle", cancellationToken, [name, create]);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference))
            return (TFileHandle)(IFileHandle)new FileHandle(fileHandleJS);
        else
            return (TFileHandle)(IFileHandleInProcess)new FileHandleInProcess((IJSInProcessObjectReference)fileHandleJS);
    }

    /// <summary>
    /// Attempts to asynchronously remove an entry if the directory handle contains a file or directory called the name specified.
    /// </summary>
    /// <param name="name">A string representing the FileSystemHandle.name of the entry you wish to remove.</param>
    /// <param name="recursive">A boolean value, which defaults to false. When set to true entries will be removed recursively.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask RemoveEntry(string name, bool recursive = false, CancellationToken cancellationToken = default) => directoryHandleJS.InvokeVoidAsync("removeEntry", cancellationToken, [name, recursive]);


    private readonly record struct EntryList(TJSObjectReference[] FileList, TJSObjectReference[] DirectoryList);

    /// <summary>
    /// Returns all entries (files, directories) located in this directory.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This method uses the <see href="https://developer.mozilla.org/en-US/docs/Web/API/FileSystemDirectoryHandle/values">values()</see> Asynchronous iterator method to create these lists.
    /// Since returning each entry one by one would be unnecessary slow, all entries are iterated and returned at once.
    /// </para>
    /// <para>Do not forget to call <i>DispseAsync()</i> on all items in fileList and directoryList when you done with it.</para>
    /// </remarks>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<(TFileHandle[] fileList, TDirectoryHandle[] directoryList)> Values(CancellationToken cancellationToken = default) {
        EntryList entryList = await directoryHandleJS.InvokeAsync<EntryList>("values", cancellationToken);

        TFileHandle[] fileList = new TFileHandle[entryList.FileList.Length];
        for (int i = 0; i < fileList.Length; i++)
            fileList[i] = typeof(TJSObjectReference) == typeof(IJSObjectReference)
                ? (TFileHandle)(IFileHandle)new FileHandle(entryList.FileList[i])
                : (TFileHandle)(IFileHandleInProcess)new FileHandleInProcess((IJSInProcessObjectReference)entryList.FileList[i]);

        TDirectoryHandle[] directoryList = new TDirectoryHandle[entryList.DirectoryList.Length];
        for (int i = 0; i < directoryList.Length; i++)
            directoryList[i] = typeof(TJSObjectReference) == typeof(IJSObjectReference)
                ? (TDirectoryHandle)(IDirectoryHandle)new DirectoryHandle(entryList.DirectoryList[i])
                : (TDirectoryHandle)(IDirectoryHandleInProcess)new DirectoryHandleInProcess((IJSInProcessObjectReference)entryList.DirectoryList[i]);

        return (fileList, directoryList);
    }
}
