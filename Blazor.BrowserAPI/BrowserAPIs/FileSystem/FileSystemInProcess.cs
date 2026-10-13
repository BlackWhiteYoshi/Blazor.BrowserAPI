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
[AutoInterface(Namespace = "BrowserAPI", Inheritance = [typeof(IFileSystemBase<IJSInProcessObjectReference, IDirectoryHandleInProcess, IFileHandleInProcess, IFileInProcess, IWritableFileStreamInProcess>)])]
[RequiresUnreferencedCode("Uses Microsoft.JSInterop functionalities")]
public sealed class FileSystemInProcess(IModuleManager moduleManager) : FileSystemBase<IJSInProcessObjectReference, IDirectoryHandleInProcess, IFileHandleInProcess, IFileInProcess, IWritableFileStreamInProcess>(moduleManager), IFileSystemInProcess;
