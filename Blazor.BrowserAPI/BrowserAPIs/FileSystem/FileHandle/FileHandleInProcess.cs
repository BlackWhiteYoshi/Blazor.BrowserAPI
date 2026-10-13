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
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IFileHandleBase<IJSInProcessObjectReference, IFileHandleInProcess, IFileInProcess, IWritableFileStreamInProcess>), typeof(IDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class FileHandleInProcess(IJSInProcessObjectReference fileHandleJS) : FileHandleBase<IJSInProcessObjectReference, IFileHandleInProcess, IFileInProcess, IWritableFileStreamInProcess>(fileHandleJS), IFileHandleInProcess {
    /// <summary>
    /// Releases the JS instance for this file handle.
    /// </summary>
    /// <returns></returns>
    public void Dispose() => fileHandleJS.Dispose();


    /// <summary>
    /// Returns the name of the associated entry.
    /// </summary>
    public string Name => fileHandleJS.Invoke<string>("getName");
}
