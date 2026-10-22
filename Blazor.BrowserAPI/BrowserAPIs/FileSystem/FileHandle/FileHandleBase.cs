using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// Base interface of <see cref="IFileHandle"/> and <see cref="IFileHandleInProcess"/>.<br/>
/// It contains common functionality for both interfaces.<br/>
/// It is not intended to use this interface directly.
/// </summary>
/// <typeparam name="TJSObjectReference"></typeparam>
/// <typeparam name="TFileHandle"></typeparam>
/// <typeparam name="TFile"></typeparam>
/// <typeparam name="TWritableFileStream"></typeparam>
/// <param name="fileHandleJS"></param>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class FileHandleBase<TJSObjectReference, TFileHandle, TFile, TWritableFileStream>(TJSObjectReference fileHandleJS) : IFileHandleBase<TJSObjectReference, TFileHandle, TFile, TWritableFileStream>
    where TJSObjectReference : IJSObjectReference
    where TFileHandle : IFileHandleBase<TJSObjectReference, TFileHandle, TFile, TWritableFileStream>
    where TFile : IFileBase<TJSObjectReference>
    where TWritableFileStream : IWritableFileStreamBase<TJSObjectReference> {
    private protected TJSObjectReference fileHandleJS = fileHandleJS;

    [AutoInterfaceVisibilityInternal]
    TJSObjectReference IFileHandleBase<TJSObjectReference, TFileHandle, TFile, TWritableFileStream>.FileHandleJS => fileHandleJS;


    /// <summary>
    /// Returns the type of entry.
    /// This is 'file' if the associated entry is a file or 'directory'.
    /// It is used to distinguish files from directories when iterating over the contents of a directory.
    /// </summary>
    /// <remarks>
    /// Note: This API does not have a common <see href="https://developer.mozilla.org/en-US/docs/Web/API/FileSystemHandle">FileSystemHandle</see> type, so this property always returns "file".
    /// </remarks>
    public string Kind => "file";


    /// <summary>
    /// Compares two file handles to see if the associated entries match.
    /// </summary>
    /// <param name="other">The FileHandle to match against the handle on which the method is invoked.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> IsSameEntry(TFileHandle other, CancellationToken cancellationToken = default) => fileHandleJS.InvokeAsync<bool>("isSameEntry", cancellationToken, [other.FileHandleJS]);

    /// <summary>
    /// <para>Returns a Promise which resolves to a File object representing the state on disk of the entry represented by the handle.</para>
    /// <para>If the file on disk changes or is removed after this method is called, the returned File object will likely be no longer readable.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<TFile> GetFile(CancellationToken cancellationToken = default) {
        TJSObjectReference fileJS = await fileHandleJS.InvokeAsync<TJSObjectReference>("getFile", cancellationToken);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference))
            return (TFile)(IFile)new File(fileJS);
        else
            return (TFile)(IFileInProcess)new FileInProcess((IJSInProcessObjectReference)fileJS);
    }

    /// <summary>
    /// <para>Creates a FileSystemWritableFileStream that can be used to write to a file. The method returns a Promise which resolves to this created stream.</para>
    /// <para>
    /// Any changes made through the stream won't be reflected in the file represented by the file handle until the stream has been closed.
    /// This is typically implemented by writing data to a temporary file, and only replacing the file represented by file handle with the temporary file when the writable file stream is closed.
    /// </para>
    /// </summary>
    /// <param name="keepExistingData">A Boolean. Default false. When set to true if the file exists, the existing file is first copied to the temporary file. Otherwise the temporary file starts out empty.</param>
    /// <param name="mode">
    /// A string specifying the locking mode for the writable file stream.
    /// The default value is "siloed". Possible values are:<br />
    /// - "exclusive": Only one FileSystemWritableFileStream writer can be opened. Attempting to open subsequent writers before the first writer is closed results in a NoModificationAllowedError exception being thrown.<br />
    /// - "siloed": Multiple FileSystemWritableFileStream writers can be opened at the same time, each with its own swap file, for example when using the same app in multiple tabs. The last writer opened has its data written, as the data gets flushed when each writer is closed.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<TWritableFileStream> CreateWritable(bool keepExistingData = false, string mode = "siloed", CancellationToken cancellationToken = default) {
        TJSObjectReference fileJS = await fileHandleJS.InvokeAsync<TJSObjectReference>("createWritable", cancellationToken, [keepExistingData, mode]);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference))
            return (TWritableFileStream)(IWritableFileStream)new WritableFileStream(fileJS);
        else
            return (TWritableFileStream)(IWritableFileStreamInProcess)new WritableFileStreamInProcess((IJSInProcessObjectReference)fileJS);
    }
}
