using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// The <i>FileSystemWritableFileStream</i> interface of the File System API is a WritableStream object with additional convenience methods, which operates on a single file on disk.
/// The interface is accessed through the FileSystemFileHandle.createWritable() method.
/// </summary>
/// <remarks>
/// <para>Objects of this class must disposed manually, so do not forget to call <see cref="Dispose"/> when you are done with it.</para>
/// <para>Disposing does <b>not</b> call <see cref="IWritableFileStreamInProcess.Close"/>. Before disposing this stream should be closed.</para>
/// </remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class WritableFileStreamInProcess(IJSObjectReference writableFileStreamJS) : WritableFileStreamBase(writableFileStreamJS), IWritableFileStreamInProcess {
    private IJSInProcessObjectReference WritableFileStreamJS => (IJSInProcessObjectReference)base.writableFileStreamJS;

    /// <summary>
    /// Releases the JS instance for this writableFileStream.
    /// </summary>
    /// <returns></returns>
    public void Dispose() => WritableFileStreamJS.Dispose();


    /// <summary>
    /// A boolean indicating whether the WritableStream is locked to a writer.
    /// </summary>
    public bool Locked => WritableFileStreamJS.Invoke<bool>("getLocked");
}
