using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The <i>FileSystemFileHandle</i> interface of the File System API represents a handle to a file system entry. The interface is accessed through the window.showOpenFilePicker() method.</para>
/// <para>
/// Note that read and write operations depend on file-access permissions that do not persist after a page refresh if no other tabs for that origin remain open.
/// The queryPermission method of the FileSystemHandle interface can be used to verify permission state before accessing a file.
/// </para>
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call <see cref="Dispose"/> when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class FileHandleInProcess(IJSObjectReference fileHandleJS) : FileHandleBase(fileHandleJS), IFileHandleInProcess {
    private IJSInProcessObjectReference FileHandleJS => (IJSInProcessObjectReference)base.fileHandleJS;

    [AutoInterfaceVisibilityInternal]
    IJSObjectReference IFileHandleInProcess.FileHandleJS => fileHandleJS;

    /// <summary>
    /// Releases the JS instance for this file handle.
    /// </summary>
    /// <returns></returns>
    public void Dispose() => FileHandleJS.Dispose();


    /// <summary>
    /// Returns the name of the associated entry.
    /// </summary>
    public string Name => FileHandleJS.Invoke<string>("getName");


    /// <summary>
    /// Compares two file handles to see if the associated entries match.
    /// </summary>
    /// <param name="other">The FileHandle to match against the handle on which the method is invoked.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> IsSameEntry(IFileHandleInProcess other, CancellationToken cancellationToken = default) => IsSameEntryBase(other.FileHandleJS, cancellationToken);

    /// <summary>
    /// <para>Returns a Promise which resolves to a File object representing the state on disk of the entry represented by the handle.</para>
    /// <para>If the file on disk changes or is removed after this method is called, the returned File object will likely be no longer readable.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IFileInProcess> GetFile(CancellationToken cancellationToken = default) {
        IJSObjectReference fileJS = await GetFileBase(cancellationToken);
        return new FileInProcess(fileJS);
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
    public async ValueTask<IWritableFileStreamInProcess> CreateWritable(bool keepExistingData = false, string mode = "siloed", CancellationToken cancellationToken = default) {
        IJSObjectReference fileJS = await CreateWritableBase(keepExistingData, mode, cancellationToken);
        return new WritableFileStreamInProcess(fileJS);
    }
}
