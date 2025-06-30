using StringOrIJSObjectReference = object;

namespace BrowserAPI;

/// <summary>
/// <para>
/// This Struct represents a union of<br />
/// - IFileHandle<br />
/// - IFileHandleInProcess<br />
/// - DirectoryHandle<br />
/// - DirectoryHandleInProcess<br />
/// - string (of a well known directory: "desktop", "documents", "downloads", "music", "pictures", "videos")
/// </para>
/// <para>
/// The File System API has functions to open dialog pickers.
/// The startIn parameter of those functions decides the initial directory the dialog opens in.
/// The value of the startIn parameter can be a fileHandle/directoryHandle or a string of a well known directory.
/// </para>
/// </summary>
public readonly record struct PickerDialogStartIn {
    /// <summary>
    /// string | FileHandleAPI | DirectoryHandleAPI
    /// </summary>
    internal StringOrIJSObjectReference? WellKnownDirectoryOrFileHandle { get; }


    /// <summary>
    /// Creates a PickerDialogStartIn object where the value is not set (undefined).
    /// </summary>
    public PickerDialogStartIn() => WellKnownDirectoryOrFileHandle = null;


    /// <summary>
    /// Creates a PickerDialogStartIn object with the starting folder of the given fileHandle.
    /// </summary>
    public PickerDialogStartIn(IFileHandle fileHandle) => WellKnownDirectoryOrFileHandle = fileHandle.FileHandleJS;

    /// <summary>
    /// Creates a PickerDialogStartIn object with the starting folder of the given fileHandle.
    /// </summary>
    public static PickerDialogStartIn FromHandle(IFileHandle fileHandle) => new(fileHandle);

    /// <summary>
    /// Creates a PickerDialogStartIn object starting in the directory of the given directoyHandle.
    /// </summary>
    public PickerDialogStartIn(IDirectoryHandle directoryHandle) => WellKnownDirectoryOrFileHandle = directoryHandle.DirectoryHandleJS;

    /// <summary>
    /// Creates a PickerDialogStartIn object starting in the directory of the given directoyHandle.
    /// </summary>
    public static PickerDialogStartIn FromHandle(IDirectoryHandle directoryHandle) => new(directoryHandle);


    /// <summary>
    /// Creates a PickerDialogStartIn object with the starting folder of the given fileHandle.
    /// </summary>
    public PickerDialogStartIn(IFileHandleInProcess fileHandle) => WellKnownDirectoryOrFileHandle = fileHandle.FileHandleJS;

    /// <summary>
    /// Creates a PickerDialogStartIn object with the starting folder of the given fileHandle.
    /// </summary>
    public static PickerDialogStartIn FromHandle(IFileHandleInProcess fileHandle) => new(fileHandle);

    /// <summary>
    /// Creates a PickerDialogStartIn object starting in the directory of the given directoyHandle.
    /// </summary>
    public PickerDialogStartIn(IDirectoryHandleInProcess directoryHandle) => WellKnownDirectoryOrFileHandle = directoryHandle.DirectoryHandleJS;

    /// <summary>
    /// Creates a PickerDialogStartIn object starting in the directory of the given directoyHandle.
    /// </summary>
    public static PickerDialogStartIn FromHandle(IDirectoryHandleInProcess directoryHandle) => new(directoryHandle);




    private PickerDialogStartIn(string wellKnownDirectory) => WellKnownDirectoryOrFileHandle = wellKnownDirectory;

    /// <summary>
    /// Creates a PickerDialogStartIn object with "desktop" as starting folder.
    /// </summary>
    public static PickerDialogStartIn Desktop => new("desktop");

    /// <summary>
    /// Creates a PickerDialogStartIn object with "documents" as starting folder.
    /// </summary>
    public static PickerDialogStartIn Documents => new("documents");

    /// <summary>
    /// Creates a PickerDialogStartIn object with "downloads" as starting folder.
    /// </summary>
    public static PickerDialogStartIn Downloads => new("downloads");

    /// <summary>
    /// Creates a PickerDialogStartIn object with "music" as starting folder.
    /// </summary>
    public static PickerDialogStartIn Music => new("music");

    /// <summary>
    /// Creates a PickerDialogStartIn object with "pictures" as starting folder.
    /// </summary>
    public static PickerDialogStartIn Pictures => new("pictures");

    /// <summary>
    /// Creates a PickerDialogStartIn object with "videos" as starting folder.
    /// </summary>
    public static PickerDialogStartIn Videos => new("videos");
}
