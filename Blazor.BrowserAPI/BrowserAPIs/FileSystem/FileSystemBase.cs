using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// Base interface of <see cref="IFileSystem"/> and <see cref="IFileSystemInProcess"/>.<br/>
/// It contains common functionality for both interfaces.<br/>
/// It is not intended to use this interface directly.
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public abstract class FileSystemBase<TJSObjectReference, TDirectoryHandle, TFileHandle, TFile, TWritableFileStream>(IModuleManager moduleManager)
    where TJSObjectReference : IJSObjectReference
    where TDirectoryHandle : IDirectoryHandleBase<TJSObjectReference, TDirectoryHandle, TFileHandle, TFile, TWritableFileStream>
    where TFileHandle : IFileHandleBase<TJSObjectReference, TFileHandle, TFile, TWritableFileStream>
    where TFile : IFileBase<TJSObjectReference>
    where TWritableFileStream : IWritableFileStreamBase<TJSObjectReference> {
    private protected IModuleManager moduleManager = moduleManager;


    private static KeyValuePair<string, KeyValuePair<string, string[]>[]>[]? MapTypes((string description, (string MIMEtype, string[] fileExtensions)[] accept)[]? types) {
        if (types is null)
            return null;

        KeyValuePair<string, KeyValuePair<string, string[]>[]>[] result = new KeyValuePair<string, KeyValuePair<string, string[]>[]>[types.Length];
        for (int i = 0; i < result.Length; i++) {
            KeyValuePair<string, string[]>[] accept = new KeyValuePair<string, string[]>[types[i].accept.Length];
            for (int j = 0; j < accept.Length; j++) {
                string[] fileExtensions = new string[types[i].accept[j].fileExtensions.Length];
                for (int k = 0; k < fileExtensions.Length; k++)
                    fileExtensions[k] = types[i].accept[j].fileExtensions[k];

                accept[j] = new KeyValuePair<string, string[]>(types[i].accept[j].MIMEtype, fileExtensions);
            }

            result[i] = new KeyValuePair<string, KeyValuePair<string, string[]>[]>(types[i].description, accept);
        }

        return result;
    }

    /// <summary>
    /// Shows a file picker that allows a user to select a file and returns a handle for the file.
    /// </summary>
    /// <remarks>
    /// <para>When the user clicks on the cancel button or just closes the dialog picker, an Exception is thrown.</para>
    /// <para>
    /// This method sets the parameter <see href="https://developer.mozilla.org/en-US/docs/Web/API/Window/showOpenFilePicker#multiple">multiple</see> to false, so a single fileHandle is returned.
    /// When multiple files should be selectable use the method <see cref="IFileSystemBase{TJSObjectReference, TDirectoryHandle, TFileHandle, TFile, TWritableFileStream}.ShowOpenFilePickerMultipleFiles"/>.
    /// </para>
    /// </remarks>
    /// <exception cref="JSException"></exception>
    /// <param name="id">By specifying an ID, the browser can remember different directories for different IDs. If the same ID is used for another picker, the picker opens in the same directory.</param>
    /// <param name="startIn">A FileSystemHandle(<see cref="IFileHandle" />/<see cref="IFileHandleInProcess" />) or a well known directory ("desktop", "documents", "downloads", "music", "pictures", or "videos") to open the dialog in.</param>
    /// <param name="excludeAcceptAllOption">A boolean value that defaults to false. By default the picker should include an option to not apply any file type filters (instigated with the type option below). Setting this option to true means that option is not available.</param>
    /// <param name="types">
    /// An Array of allowed file types to pick. Each item is an object with the following options:<br />
    /// - description: An optional description of the category of files types allowed. Defaults to an empty string.<br />
    /// - accept: An Object with the keys set to the MIME type and the values an Array of file extensions.<br />
    /// e.g.
    /// <code>
    /// var types = [
    ///     ("Images", [
    ///         ("image/*", [".png", ".gif", ".jpeg", ".jpg"])
    ///     ])
    /// ];
    /// </code>
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<TFileHandle> ShowOpenFilePicker(string? id = null, PickerDialogStartIn startIn = default, bool excludeAcceptAllOption = false, (string description, (string MIMEtype, string[] fileExtensions)[] accept)[]? types = null, CancellationToken cancellationToken = default) {
        TJSObjectReference fileHandleJS = await moduleManager.InvokeAsync<TJSObjectReference>("FileSystemAPI.showOpenFilePicker", cancellationToken, [id, startIn.WellKnownDirectoryOrFileHandle, excludeAcceptAllOption, MapTypes(types)]);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference))
            return (TFileHandle)(IFileHandle)new FileHandle(fileHandleJS);
        else
            return (TFileHandle)(IFileHandleInProcess)new FileHandleInProcess((IJSInProcessObjectReference)fileHandleJS);
    }

    /// <summary>
    /// Shows a file picker that allows a user to select a file or multiple files and returns a handle for the file(s).
    /// </summary>
    /// <remarks>
    /// <para>When the user clicks on the cancel button or just closes the dialog picker, an Exception is thrown.</para>
    /// <para>
    /// This method sets the parameter <see href="https://developer.mozilla.org/en-US/docs/Web/API/Window/showOpenFilePicker#multiple">multiple</see> to true, so a multiple fileHandles can be returned.
    /// When only a single file should be selectable use the method <see cref="IFileSystemBase{TJSObjectReference, TDirectoryHandle, TFileHandle, TFile, TWritableFileStream}.ShowOpenFilePicker"/>.
    /// </para>
    /// </remarks>
    /// <exception cref="JSException"></exception>
    /// <param name="id">By specifying an ID, the browser can remember different directories for different IDs. If the same ID is used for another picker, the picker opens in the same directory.</param>
    /// <param name="startIn">A FileSystemHandle(<see cref="IFileHandle" />/<see cref="IFileHandleInProcess" />) or a well known directory ("desktop", "documents", "downloads", "music", "pictures", or "videos") to open the dialog in.</param>
    /// <param name="excludeAcceptAllOption">A boolean value that defaults to false. By default the picker should include an option to not apply any file type filters (instigated with the type option below). Setting this option to true means that option is not available.</param>
    /// <param name="types">
    /// An Array of allowed file types to pick. Each item is an object with the following options:<br />
    /// - description: An optional description of the category of files types allowed. Defaults to an empty string.<br />
    /// - accept: An Object with the keys set to the MIME type and the values an Array of file extensions.<br />
    /// e.g.
    /// <code>
    /// var types = [
    ///     ("Images", [
    ///         ("image/*", [".png", ".gif", ".jpeg", ".jpg"])
    ///     ])
    /// ];
    /// </code>
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<TFileHandle[]> ShowOpenFilePickerMultipleFiles(string? id = null, PickerDialogStartIn startIn = default, bool excludeAcceptAllOption = false, (string description, (string MIMEtype, string[] fileExtensions)[] accept)[]? types = null, CancellationToken cancellationToken = default) {
        TJSObjectReference[] fileHandleJSList = await moduleManager.InvokeAsync<TJSObjectReference[]>("FileSystemAPI.showOpenFilePickerMultipleFiles", cancellationToken, [id, startIn.WellKnownDirectoryOrFileHandle, excludeAcceptAllOption, MapTypes(types)]);

        TFileHandle[] result = new TFileHandle[fileHandleJSList.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = typeof(TJSObjectReference) == typeof(IJSObjectReference)
                ? (TFileHandle)(IFileHandle)new FileHandle(fileHandleJSList[i])
                : (TFileHandle)(IFileHandleInProcess)new FileHandleInProcess((IJSInProcessObjectReference)fileHandleJSList[i]);
        return result;
    }

    /// <summary>
    /// Shows a file picker that allows a user to save a file. Either by selecting an existing file, or entering a name for a new file.
    /// </summary>
    /// <remarks>When the user clicks on the cancel button or just closes the dialog picker, an Exception is thrown.</remarks>
    /// <exception cref="JSException"></exception>
    /// <param name="suggestedName">A String. The suggested file name.</param>
    /// <param name="id">By specifying an ID, the browser can remember different directories for different IDs. If the same ID is used for another picker, the picker opens in the same directory.</param>
    /// <param name="startIn">A FileSystemHandle(<see cref="IFileHandle" />/<see cref="IFileHandleInProcess" />) or a well known directory ("desktop", "documents", "downloads", "music", "pictures", or "videos") to open the dialog in.</param>
    /// <param name="excludeAcceptAllOption">A boolean value that defaults to false. By default the picker should include an option to not apply any file type filters (instigated with the type option below). Setting this option to true means that option is not available.</param>
    /// <param name="types">
    /// An Array of allowed file types to pick. Each item is an object with the following options:<br />
    /// - description: An optional description of the category of files types allowed. Defaults to an empty string.<br />
    /// - accept: An Object with the keys set to the MIME type and the values an Array of file extensions.<br />
    /// e.g.
    /// <code>
    /// var types = [
    ///     ("Images", [
    ///         ("image/*", [".png", ".gif", ".jpeg", ".jpg"])
    ///     ])
    /// ];
    /// </code>
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<TFileHandle> ShowSaveFilePicker(string? suggestedName = null, string? id = null, PickerDialogStartIn startIn = default, bool excludeAcceptAllOption = false, (string description, (string MIMEtype, string[] fileExtensions)[] accept)[]? types = null, CancellationToken cancellationToken = default) {
        TJSObjectReference fileHandleJS = await moduleManager.InvokeAsync<TJSObjectReference>("FileSystemAPI.showSaveFilePicker", cancellationToken, [suggestedName, id, startIn.WellKnownDirectoryOrFileHandle, excludeAcceptAllOption, MapTypes(types)]);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference))
            return (TFileHandle)(IFileHandle)new FileHandle(fileHandleJS);
        else
            return (TFileHandle)(IFileHandleInProcess)new FileHandleInProcess((IJSInProcessObjectReference)fileHandleJS);
    }

    /// <summary>
    /// Displays a directory picker which allows the user to select a directory.
    /// </summary>
    /// <remarks>When the user clicks on the cancel button or just closes the dialog picker, an Exception is thrown.</remarks>
    /// <exception cref="JSException"></exception>
    /// <param name="mode">A string that defaults to "read" for read-only access or "readwrite" for read and write access to the directory.</param>
    /// <param name="id">By specifying an ID, the browser can remember different directories for different IDs. If the same ID is used for another picker, the picker opens in the same directory.</param>
    /// <param name="startIn">A FileSystemHandle(<see cref="IFileHandle" />/<see cref="IFileHandleInProcess" />) or a well known directory ("desktop", "documents", "downloads", "music", "pictures", or "videos") to open the dialog in.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<TDirectoryHandle> ShowDirectoryPicker(string mode = "read", string? id = null, PickerDialogStartIn startIn = default, CancellationToken cancellationToken = default) {
        TJSObjectReference directoryHandleJS = await moduleManager.InvokeAsync<TJSObjectReference>("FileSystemAPI.showDirectoryPicker", cancellationToken, [mode, id, startIn.WellKnownDirectoryOrFileHandle]);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference))
            return (TDirectoryHandle)(IDirectoryHandle)new DirectoryHandle(directoryHandleJS);
        else
            return (TDirectoryHandle)(IDirectoryHandleInProcess)new DirectoryHandleInProcess((IJSInProcessObjectReference)directoryHandleJS);
    }


    private readonly record struct Estimate(long? Usage, long? Quota);

    /// <summary>
    /// <para>Asks the Storage Manager for how much storage the current origin takes up (usage), and how much space is available (quota).</para>
    /// <para>This method operates asynchronously, so it returns a Promise which resolves once the information is available. The promise's fulfillment handler is called with an object containing the usage and quota data.</para>
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<(long? usage, long? quota)> StorageManagerEstimate(CancellationToken cancellationToken = default) {
        Estimate estimate = await moduleManager.InvokeAsync<Estimate>("FileSystemAPI.storageManagerEstimate", cancellationToken);
        return (estimate.Usage, estimate.Quota);
    }

    /// <summary>
    /// Requests permission to use persistent storage, and returns a Promise that resolves to true if permission is granted and bucket mode is persistent, and false otherwise.
    /// The browser may or may not honor the request, depending on browser-specific rules.
    /// (For more details, see the guide to <see href="https://developer.mozilla.org/en-US/docs/Web/API/Storage_API/Storage_quotas_and_eviction_criteria#does_browser-stored_data_persist">Storage quotas and eviction criteria</see>.)
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> StorageManagerPersist(CancellationToken cancellationToken = default) => moduleManager.InvokeAsync<bool>("FileSystemAPI.storageManagerPersist", cancellationToken);

    /// <summary>
    /// Returns a Promise that resolves to true if your site's storage bucket is persistent.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<bool> StorageManagerPersisted(CancellationToken cancellationToken = default) => moduleManager.InvokeAsync<bool>("FileSystemAPI.storageManagerPersisted", cancellationToken);

    /// <summary>
    /// Is used to obtain a reference to a FileSystemDirectoryHandle object allowing access to a directory and its contents, stored in the origin private file system (OPFS).
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<TDirectoryHandle> StorageManagerGetDirectory(CancellationToken cancellationToken = default) {
        TJSObjectReference directoryHandleJS = await moduleManager.InvokeAsync<TJSObjectReference>("FileSystemAPI.storageManagerGetDirectory", cancellationToken);
        if (typeof(TJSObjectReference) == typeof(IJSObjectReference))
            return (TDirectoryHandle)(IDirectoryHandle)new DirectoryHandle(directoryHandleJS);
        else
            return (TDirectoryHandle)(IDirectoryHandleInProcess)new DirectoryHandleInProcess((IJSInProcessObjectReference)directoryHandleJS);
    }
}
