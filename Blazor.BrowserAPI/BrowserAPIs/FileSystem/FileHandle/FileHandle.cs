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
/// <remarks>Objects of this class must disposed manually, so do not forget to call <see cref="DisposeAsync"/> when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IFileHandleBase<IJSObjectReference, IFileHandle, IFile, IWritableFileStream>), typeof(IAsyncDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class FileHandle(IJSObjectReference fileHandleJS) : FileHandleBase<IJSObjectReference, IFileHandle, IFile, IWritableFileStream>(fileHandleJS), IFileHandle {
    /// <summary>
    /// Releases the JS instance for this file handle.
    /// </summary>
    /// <returns></returns>
    public ValueTask DisposeAsync() => fileHandleJS.DisposeTrySync();


    /// <summary>
    /// Returns the name of the associated entry.
    /// </summary>
    public ValueTask<string> Name => GetName(CancellationToken.None);

    /// <inheritdoc cref="Name" />
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<string> GetName(CancellationToken cancellationToken) => fileHandleJS.InvokeTrySync<string>("getName", cancellationToken);
}
