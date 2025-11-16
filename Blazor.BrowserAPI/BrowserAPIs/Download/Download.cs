using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Text;

namespace BrowserAPI.Implementation;

/// <summary>
/// Save data as a file download on the filesystem.
/// <para>For file upload use the <see cref="Microsoft.AspNetCore.Components.Forms.InputFile">InputFile</see> component.</para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
public sealed class Download(IModuleManager moduleManager) : IDownload {
    /// <summary>
    /// Triggers a download by adding an &lt;a&gt;-element to the document and simulate a click on it.
    /// </summary>
    /// <param name="fileName">The name of the downloaded file.</param>
    /// <param name="fileContent">UTF8 encoded content of the file.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask DownloadAsFile(string fileName, string fileContent, CancellationToken cancellationToken = default)
        => DownloadAsFile(fileName, Encoding.UTF8.GetBytes(fileContent), cancellationToken);

    /// <inheritdoc cref="DownloadAsFile(string, string, CancellationToken)" />
    /// <param name="fileName">The name of the downloaded file.</param>
    /// <param name="fileContent">Raw data that gets downloaded and saved in a file.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask DownloadAsFile(string fileName, byte[] fileContent, CancellationToken cancellationToken = default) {
        using MemoryStream memoryStream = new(fileContent);
        using DotNetStreamReference streamReference = new(memoryStream);
        await DownloadAsFile(fileName, streamReference, cancellationToken);
    }

    /// <inheritdoc cref="DownloadAsFile(string, string, CancellationToken)" />
    /// <param name="fileName">The name of the downloaded file.</param>
    /// <param name="fileContent">Data stream that gets downloaded and saved in a file.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask DownloadAsFile(string fileName, DotNetStreamReference fileContent, CancellationToken cancellationToken = default)
        => moduleManager.InvokeAsync("DownloadAPI.downloadAsFile", cancellationToken, [fileName, fileContent]);
}
