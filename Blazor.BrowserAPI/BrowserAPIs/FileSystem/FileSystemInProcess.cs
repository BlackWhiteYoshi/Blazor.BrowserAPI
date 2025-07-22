using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

/// <summary>
/// <para>
/// The <i>File System API</i>
/// — with extensions provided via the <see href="https://wicg.github.io/file-system-access/">File System Access API</see> to access files on the device file system —
/// allows read, write and file management capabilities.
/// </para>
/// <para>
/// See <see href="https://developer.mozilla.org/en-US/docs/Web/API/File_API#relationship_to_other_file-related_apis">Relationship to other file-related APIs</see> for a comparison between this API,
/// the <see href="https://developer.mozilla.org/en-US/docs/Web/API/File_and_Directory_Entries_API">File and Directory Entries API</see>,
/// and the <see href="https://developer.mozilla.org/en-US/docs/Web/API/File_API">File API</see>.
/// </para>
/// </summary>
[AutoInterface(Namespace = "BrowserAPI")]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class FileSystemInProcess(IModuleManager moduleManager) : FileSystemBase(moduleManager), IFileSystemInProcess {
    /// <summary>
    /// Shows a file picker that allows a user to select a file and returns a handle for the file.
    /// </summary>
    /// <remarks>
    /// <para>When the user clicks on the cancel button or just closes the dialog picker, an Exception is thrown.</para>
    /// <para>
    /// This method sets the parameter <see href="https://developer.mozilla.org/en-US/docs/Web/API/Window/showOpenFilePicker#multiple">multiple</see> to false, so a single fileHandle is returned.
    /// When multiple files should be selectable use the method <see cref="IFileSystem.ShowOpenFilePickerMultipleFiles"/>.
    /// </para>
    /// </remarks>
    /// <exception cref="JSException"></exception>
    /// <param name="id">By specifying an ID, the browser can remember different directories for different IDs. If the same ID is used for another picker, the picker opens in the same directory.</param>
    /// <param name="startIn">A <see cref="IFileHandle">FileSystemHandle</see> or a well known directory ("desktop", "documents", "downloads", "music", "pictures", or "videos") to open the dialog in.</param>
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
    public async ValueTask<IFileHandleInProcess> ShowOpenFilePicker(string? id = null, PickerDialogStartIn startIn = default, bool excludeAcceptAllOption = false, (string description, (string MIMEtype, string[] fileExtensions)[] accept)[]? types = null, CancellationToken cancellationToken = default) {
        IJSObjectReference fileHandleJS = await ShowOpenFilePickerBase(id, startIn, excludeAcceptAllOption, types, cancellationToken);
        return new FileHandleInProcess(fileHandleJS);
    }

    /// <summary>
    /// Shows a file picker that allows a user to select a file or multiple files and returns a handle for the file(s).
    /// </summary>
    /// <remarks>
    /// <para>When the user clicks on the cancel button or just closes the dialog picker, an Exception is thrown.</para>
    /// <para>
    /// This method sets the parameter <see href="https://developer.mozilla.org/en-US/docs/Web/API/Window/showOpenFilePicker#multiple">multiple</see> to true, so a multiple fileHandles can be returned.
    /// When only a single file should be selectable use the method <see cref="IFileSystem.ShowOpenFilePicker"/>.
    /// </para>
    /// </remarks>
    /// <exception cref="JSException"></exception>
    /// <param name="id">By specifying an ID, the browser can remember different directories for different IDs. If the same ID is used for another picker, the picker opens in the same directory.</param>
    /// <param name="startIn">A <see cref="IFileHandle">FileSystemHandle</see> or a well known directory ("desktop", "documents", "downloads", "music", "pictures", or "videos") to open the dialog in.</param>
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
    public async ValueTask<IFileHandleInProcess[]> ShowOpenFilePickerMultipleFiles(string? id = null, PickerDialogStartIn startIn = default, bool excludeAcceptAllOption = false, (string description, (string MIMEtype, string[] fileExtensions)[] accept)[]? types = null, CancellationToken cancellationToken = default) {
        IJSObjectReference[] fileHandleJSList = await ShowOpenFilePickerMultipleFilesBase(id, startIn, excludeAcceptAllOption, types, cancellationToken);

        FileHandleInProcess[] result = new FileHandleInProcess[fileHandleJSList.Length];
        for (int i = 0; i < result.Length; i++)
            result[i] = new FileHandleInProcess(fileHandleJSList[i]);
        return result;
    }

    /// <summary>
    /// Shows a file picker that allows a user to save a file. Either by selecting an existing file, or entering a name for a new file.
    /// </summary>
    /// <remarks>When the user clicks on the cancel button or just closes the dialog picker, an Exception is thrown.</remarks>
    /// <exception cref="JSException"></exception>
    /// <param name="suggestedName">A String. The suggested file name.</param>
    /// <param name="id">By specifying an ID, the browser can remember different directories for different IDs. If the same ID is used for another picker, the picker opens in the same directory.</param>
    /// <param name="startIn">A <see cref="IFileHandle">FileSystemHandle</see> or a well known directory ("desktop", "documents", "downloads", "music", "pictures", or "videos") to open the dialog in.</param>
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
    public async ValueTask<IFileHandleInProcess> ShowSaveFilePicker(string? suggestedName = null, string? id = null, PickerDialogStartIn startIn = default, bool excludeAcceptAllOption = false, (string description, (string MIMEtype, string[] fileExtensions)[] accept)[]? types = null, CancellationToken cancellationToken = default) {
        IJSObjectReference fileHandleJS = await ShowSaveFilePickerBase(suggestedName, id, startIn, excludeAcceptAllOption, types, cancellationToken);
        return new FileHandleInProcess(fileHandleJS);
    }

    /// <summary>
    /// Displays a directory picker which allows the user to select a directory.
    /// </summary>
    /// <remarks>When the user clicks on the cancel button or just closes the dialog picker, an Exception is thrown.</remarks>
    /// <exception cref="JSException"></exception>
    /// <param name="mode">A string that defaults to "read" for read-only access or "readwrite" for read and write access to the directory.</param>
    /// <param name="id">By specifying an ID, the browser can remember different directories for different IDs. If the same ID is used for another picker, the picker opens in the same directory.</param>
    /// <param name="startIn">A <see cref="IFileHandle">FileSystemHandle</see> or a well known directory ("desktop", "documents", "downloads", "music", "pictures", or "videos") to open the dialog in.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IDirectoryHandleInProcess> ShowDirectoryPicker(string mode = "read", string? id = null, PickerDialogStartIn startIn = default, CancellationToken cancellationToken = default) {
        IJSObjectReference directoryHandleJS = await ShowDirectoryPickerBase(mode, id, startIn, cancellationToken);
        return new DirectoryHandleInProcess(directoryHandleJS);
    }


    /// <summary>
    /// Is used to obtain a reference to a FileSystemDirectoryHandle object allowing access to a directory and its contents, stored in the origin private file system (OPFS).
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<IDirectoryHandleInProcess> StorageManagerGetDirectory(CancellationToken cancellationToken = default) {
        IJSObjectReference directoryHandleJS = await StorageManagerGetDirectoryBase(cancellationToken);
        return new DirectoryHandleInProcess(directoryHandleJS);
    }
}
