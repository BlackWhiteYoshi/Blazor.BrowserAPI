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
/// <remarks>Objects of this class must disposed manually, so do not forget to call <see cref="Dispose"/> when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IDirectoryHandleBase<IJSInProcessObjectReference, IDirectoryHandleInProcess, IFileHandleInProcess, IFileInProcess, IWritableFileStreamInProcess>), typeof(IDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class DirectoryHandleInProcess(IJSInProcessObjectReference directoryHandleJS) : DirectoryHandleBase<IJSInProcessObjectReference, IDirectoryHandleInProcess, IFileHandleInProcess, IFileInProcess, IWritableFileStreamInProcess>(directoryHandleJS), IDirectoryHandleInProcess {
    /// <summary>
    /// Releases the JS instance for this directory handle.
    /// </summary>
    /// <returns></returns>
    public void Dispose() => directoryHandleJS.Dispose();


    /// <summary>
    /// Returns the name of the associated entry.
    /// </summary>
    public string Name => directoryHandleJS.Invoke<string>("getName");
}
