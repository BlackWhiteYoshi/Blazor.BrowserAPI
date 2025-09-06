using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>The <i>File</i> interface provides information about files and allows JavaScript in a web page to access their content.</para>
/// <para>File objects are generally retrieved from a FileList object returned as a result of a user selecting files using the &lt;input&gt; element, or from a drag and drop operation's DataTransfer object.</para>
/// <para>
/// A File object is a specific kind of Blob, and can be used in any context that a Blob can.In particular, the following APIs accept both Blobs and File objects:<br />
/// - FileReader<br />
/// - URL.createObjectURL()<br />
/// - Window.createImageBitmap() and WorkerGlobalScope.createImageBitmap()<br />
/// - the body option to fetch()<br />
/// - XMLHttpRequest.send()
/// </para>
/// <para>See <see href="https://developer.mozilla.org/en-US/docs/Web/API/File_API/Using_files_from_web_applications">Using files from web applications</see> for more information and examples.</para>
/// </summary>
/// <remarks>Objects of this class must disposed manually, so do not forget to call <see cref="Dispose"/> when you are done with it.</remarks>
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IDisposable)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class FileInProcess(IJSObjectReference fileJS) : FileBase(fileJS), IFileInProcess {
    private IJSInProcessObjectReference FileJS => (IJSInProcessObjectReference)base.fileJS;

    [AutoInterfaceVisibilityInternal]
    IJSInProcessObjectReference IFileInProcess.FileJS => FileJS;

    /// <summary>
    /// Releases the JS instance for this file.
    /// </summary>
    /// <returns></returns>
    public void Dispose() => FileJS.Dispose();


    /// <summary>
    /// Returns the name of the file referenced by the File object.
    /// </summary>
    public string Name => FileJS.Invoke<string>("getName");

    /// <summary>
    /// The size, in bytes, of the data contained in the Blob object.
    /// </summary>
    public long Size => FileJS.Invoke<long>("getSize");

    /// <summary>
    /// A string indicating the MIME type of the data contained in the Blob. If the type is unknown, this string is empty.
    /// </summary>
    public string Type => FileJS.Invoke<string>("getType");

    /// <summary>
    /// Returns the last modified time of the file, in millisecond since the UNIX epoch (January 1st, 1970 at Midnight).
    /// </summary>
    public long LastModified => FileJS.Invoke<long>("getLastModified");

    /// <summary>
    /// Returns the path the URL of the File is relative to.
    /// </summary>
    public string WebkitRelativePath => FileJS.Invoke<string>("getWebkitRelativePath");
}
