using Microsoft.AspNetCore.Components;
using System.Text;

namespace BrowserAPI.Test.Client;

public sealed partial class FileSystemGroup : ComponentBase {
    public const string TEMP_FILE_NAME = "TempFile.txt";
    public const string FILE_TEXT_RESULT = "(empty)";
    public const string WRITABLE_FILE_STREAM_WRITE_TEXT = "some example text";
    public const string WRITABLE_FILE_STREAM_SEEK_DONE = "stream seeked";
    public const string WRITABLE_FILE_STREAM_TRUNCATE_DONE = "stream truncated";
    public const string WRITABLE_FILE_STREAM_ABORT_DONE = "stream aborted";
    public const string WRITABLE_FILE_STREAM_CLOSE_DONE = "stream closed";


    private readonly struct TempFile : IAsyncDisposable {
        public IDirectoryHandle DirectoryHandle { get; private init; }
        public IFileHandle FileHandle { get; private init; }

        public static async ValueTask<TempFile> Create(IFileSystem FileSystem) {
            IDirectoryHandle directoryHandle = await FileSystem.StorageManagerGetDirectory();
            IFileHandle fileHandle = await directoryHandle.GetFileHandle(TEMP_FILE_NAME, create: true);
            return new TempFile() {
                DirectoryHandle = directoryHandle,
                FileHandle = fileHandle
            };
        }

        public async ValueTask DisposeAsync() {
            await DirectoryHandle.RemoveEntry(TEMP_FILE_NAME);
            await FileHandle.DisposeAsync();
            await DirectoryHandle.DisposeAsync();
        }
    }


    [Inject]
    public required IFileSystem FileSystem { private get; init; }


    public const string LABEL_OUTPUT = "filesystem-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_SHOW_OPEN_FILE_PICKER = "filesystem-show-open-file-picker";
    private async Task ShowOpenFilePicker() {
        await using IFileHandle fileHandle = await FileSystem.ShowOpenFilePicker(id: "example", PickerDialogStartIn.Desktop, excludeAcceptAllOption: true, [("text", [("text/plain", [".txt"])])]);
        labelOutput = (fileHandle is not null).ToString();
    }

    public const string BUTTON_SHOW_OPEN_FILE_PICKER_MULTIPLE_FILES = "filesystem-show-open-file-picker-multiple-files";
    private async Task ShowOpenFilePickerMultipleFiles() {
        IFileHandle[] fileHandleList = await FileSystem.ShowOpenFilePickerMultipleFiles(id: "Example", PickerDialogStartIn.Pictures, excludeAcceptAllOption: false, [("images", [("image/*", [".jpg", ".jpeg", ".png", ".gif"])])]);
        labelOutput = fileHandleList.Length.ToString();

        await fileHandleList.DisposeAsync();
    }

    public const string BUTTON_SHOW_SAVE_FILE_PICKER = "filesystem-show-save-file-picker";
    private async Task ShowSaveFilePicker() {
        await using IFileHandle fileHandle = await FileSystem.ShowSaveFilePicker(suggestedName: "test.txt", id: "y", PickerDialogStartIn.Documents, excludeAcceptAllOption: false, [("text", [("text/*", [".txt"])])]);
        labelOutput = (fileHandle is not null).ToString();
    }

    public const string BUTTON_SHOW_DIRECTORY_PICKER = "filesystem-show-directory-picker";
    private async Task ShowDirectoryPicker() {
        await using IDirectoryHandle directoryHandle = await FileSystem.ShowDirectoryPicker("readwrite", id: "Y", PickerDialogStartIn.Videos);
        labelOutput = (directoryHandle is not null).ToString();
    }


    public const string BUTTON_STORAGE_MANAGER_ESTIMATE = "filesystem-storage-manager-estimate";
    private async Task StorageManagerEstimate() {
        (long? usage, long? quota) = await FileSystem.StorageManagerEstimate();
        labelOutput = $"(usage: {usage}, quota: {quota})";
    }

    public const string BUTTON_STORAGE_MANAGER_PERSIST = "filesystem-storage-manager-persist";
    private async Task StorageManagerPersist() {
        bool persist = await FileSystem.StorageManagerPersist();
        labelOutput = persist.ToString();
    }

    public const string BUTTON_STORAGE_MANAGER_PERSISTED = "filesystem-storage-manager-persisted";
    private async Task StorageManagerPersisted() {
        bool persist = await FileSystem.StorageManagerPersisted();
        labelOutput = persist.ToString();
    }

    public const string BUTTON_STORAGE_MANAGER_GET_DIRECTORY = "filesystem-storage-manager-get-directory";
    private async Task StorageManagerGetDirectory() {
        await using IDirectoryHandle directoryHandle = await FileSystem.StorageManagerGetDirectory();
        labelOutput = (directoryHandle is not null).ToString();
    }



    public const string BUTTON_FILEHANDLE_GET_NAME_PROPERTY = "filesystem-filehandle-get-name-property";
    private async Task FileHandle_GetName_Property() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        string name = await tempFile.FileHandle.Name;
        labelOutput = name;
    }

    public const string BUTTON_FILEHANDLE_GET_NAME_METHOD = "filesystem-filehandle-get-name-method";
    private async Task FileHandle_GetName_Method() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        string name = await tempFile.FileHandle.GetName(default);
        labelOutput = name;
    }

    public const string BUTTON_FILEHANDLE_GET_KIND = "filesystem-filehandle-get-kind";
    private async Task FileHandle_GetKind() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        string kind = tempFile.FileHandle.Kind;
        labelOutput = kind;
    }


    public const string BUTTON_FILEHANDLE_IS_SAME_Entry = "filesystem-filehandle-is-same-entry";
    private async Task FileHandle_IsSameEntry() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        bool isSame = await tempFile.FileHandle.IsSameEntry(tempFile.FileHandle);
        labelOutput = isSame.ToString();
    }

    public const string BUTTON_FILEHANDLE_GET_FILE = "filesystem-filehandle-get-file";
    private async Task FileHandle_GetFile() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        await using IFile file = await tempFile.FileHandle.GetFile();
        labelOutput = (file is not null).ToString();
    }

    public const string BUTTON_FILEHANDLE_CREATE_WRITABLE = "filesystem-filehandle-create-writable";
    private async Task FileHandle_CreateWritable() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        await using IWritableFileStream writableFileStream = await tempFile.FileHandle.CreateWritable();
        await writableFileStream.Close();
        labelOutput = (writableFileStream is not null).ToString();
    }



    public const string BUTTON_DIRECTORYHANDLE_GET_NAME_PROPERTY = "filesystem-directoryhandle-get-name-property";
    private async Task DirectoryHandle_GetName_Property() {
        await using IDirectoryHandle directoryHandle = await FileSystem.StorageManagerGetDirectory();
        string name = await directoryHandle.Name;
        labelOutput = name;
    }

    public const string BUTTON_DIRECTORYHANDLE_GET_NAME_METHOD = "filesystem-directoryhandle-get-name-method";
    private async Task DirectoryHandle_GetName_Method() {
        await using IDirectoryHandle directoryHandle = await FileSystem.StorageManagerGetDirectory();
        string name = await directoryHandle.GetName(default);
        labelOutput = name;
    }

    public const string BUTTON_DIRECTORYHANDLE_GET_KIND = "filesystem-directoryhandle-get-kind";
    private async Task DirectoryHandle_GetKind() {
        await using IDirectoryHandle directoryHandle = await FileSystem.StorageManagerGetDirectory();
        string kind = directoryHandle.Kind;
        labelOutput = kind;
    }


    public const string BUTTON_DIRECTORYHANDLE_IS_SAME_Entry = "filesystem-directoryhandle-is-same-entry";
    private async Task DirectoryHandle_IsSameEntry() {
        await using IDirectoryHandle directoryHandle = await FileSystem.StorageManagerGetDirectory();
        bool isSame = await directoryHandle.IsSameEntry(directoryHandle);
        labelOutput = isSame.ToString();
    }

    public const string BUTTON_DIRECTORYHANDLE_GET_DIRECTORYHANDLE = "filesystem-directoryhandle-get-directoryhandle";
    private async Task DirectoryHandle_GetDirectoryHandle() {
        const string SUB_DIRECTORY_NAME = "temp";

        await using IDirectoryHandle directoryHandle = await FileSystem.StorageManagerGetDirectory();
        await using IDirectoryHandle subDirectoryHandle = await directoryHandle.GetDirectoryHandle(SUB_DIRECTORY_NAME, create: true);
        labelOutput = (subDirectoryHandle is not null).ToString();

        await directoryHandle.RemoveEntry(SUB_DIRECTORY_NAME, recursive: true);
    }

    public const string BUTTON_DIRECTORYHANDLE_GET_FILEHANDLE = "filesystem-directoryhandle-get-filehandle";
    private async Task DirectoryHandle_GetFileHandle() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        labelOutput = (tempFile.FileHandle is not null).ToString();
    }

    public const string BUTTON_DIRECTORYHANDLE_REMOVE_ENTRY = "filesystem-directoryhandle-remove-entry";
    private async Task DirectoryHandle_RemoveEntry() {
        await using IDirectoryHandle directoryHandle = await FileSystem.StorageManagerGetDirectory();
        await using IDirectoryHandle subFolder = await directoryHandle.GetDirectoryHandle("subFolder", create: true);
        await using IFileHandle fileHandle = await subFolder.GetFileHandle("someFile", create: true);
        await directoryHandle.RemoveEntry("subFolder", recursive: true);

        (long? usage, _) = await FileSystem.StorageManagerEstimate();
        labelOutput = $"usage: {usage?.ToString() ?? "unkown"}";
    }

    public const string BUTTON_DIRECTORYHANDLE_VALUES = "filesystem-directoryhandle-values";
    private async Task DirectoryHandle_Values() {
        await using IDirectoryHandle directoryHandle = await FileSystem.StorageManagerGetDirectory();
        await using IDirectoryHandle subDirectory1 = await directoryHandle.GetDirectoryHandle("sub1", create: true);
        await using IDirectoryHandle subDirectory2 = await directoryHandle.GetDirectoryHandle("sub2", create: true);
        await using IFileHandle fileHandle1 = await directoryHandle.GetFileHandle("temp1.txt", create: true);
        await using IFileHandle fileHandle2 = await subDirectory1.GetFileHandle("temp2.txt", create: true);
        (IFileHandle[] fileList, IDirectoryHandle[] directoryList) = await directoryHandle.Values();

        StringBuilder builder = new(1024);
        builder.Append($"({fileList.Length + directoryList.Length}): ");
        foreach (IDirectoryHandle directory in directoryList)
            builder.Append($"folder: {await directory.Name}, ");
        foreach (IFileHandle file in fileList)
            builder.Append($"file: {await file.Name}, ");
        builder.Length -= 2;
        labelOutput = builder.ToString();

        await directoryHandle.RemoveEntry("sub1", recursive: true);
        await directoryHandle.RemoveEntry("sub2");
        await directoryHandle.RemoveEntry("temp1.txt");
        await (fileList, directoryList).DisposeAsync();
    }



    public const string BUTTON_FILE_GET_NAME_PROPERTY = "filesystem-file-get-name-property";
    private async Task File_GetName_Property() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        await using IFile file = await tempFile.FileHandle.GetFile();
        string name = await file.Name;
        labelOutput = name;
    }

    public const string BUTTON_FILE_GET_NAME_METHOD = "filesystem-file-get-name-method";
    private async Task File_GetName_Method() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        await using IFile file = await tempFile.FileHandle.GetFile();
        string name = await file.GetName(default);
        labelOutput = name;
    }

    public const string BUTTON_FILE_GET_SIZE_PROPERTY = "filesystem-file-get-size-property";
    private async Task File_GetSize_Property() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        await using IFile file = await tempFile.FileHandle.GetFile();
        long size = await file.Size;
        labelOutput = size.ToString();
    }

    public const string BUTTON_FILE_GET_SIZE_METHOD = "filesystem-file-get-size-method";
    private async Task File_GetSize_Method() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        await using IFile file = await tempFile.FileHandle.GetFile();
        long size = await file.GetSize(default);
        labelOutput = size.ToString();
    }

    public const string BUTTON_FILE_GET_TYPE_PROPERTY = "filesystem-file-get-type-property";
    private async Task File_GetType_Property() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        await using IFile file = await tempFile.FileHandle.GetFile();
        string type = await file.Type;
        labelOutput = type;
    }

    public const string BUTTON_FILE_GET_TYPE_METHOD = "filesystem-file-get-type-method";
    private async Task File_GetType_Method() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        await using IFile file = await tempFile.FileHandle.GetFile();
        string type = await file.GetType(default);
        labelOutput = type;
    }

    public const string BUTTON_FILE_GET_LAST_MODIFIED_PROPERTY = "filesystem-file-get-last-modified-property";
    private async Task File_GetLastModified_Property() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        await using IFile file = await tempFile.FileHandle.GetFile();
        long lastModified = await file.LastModified;
        labelOutput = lastModified.ToString();
    }

    public const string BUTTON_FILE_GET_LAST_MODIFIED_METHOD = "filesystem-file-get-last-modified-method";
    private async Task File_GetLastModified_Method() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        await using IFile file = await tempFile.FileHandle.GetFile();
        long lastModified = await file.GetLastModified(default);
        labelOutput = lastModified.ToString();
    }

    public const string BUTTON_FILE_GET_WEBKIT_RELATIVE_PATH_PROPERTY = "filesystem-file-get-webkit-relative-path-property";
    private async Task File_GetWebkitRelativePath_Property() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        await using IFile file = await tempFile.FileHandle.GetFile();
        string webkitRelativePath = await file.WebkitRelativePath;
        labelOutput = webkitRelativePath;
    }

    public const string BUTTON_FILE_GET_WEBKIT_RELATIVE_PATH_METHOD = "filesystem-file-get-webkit-relative-path-method";
    private async Task File_GetWebkitRelativePath_Method() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        await using IFile file = await tempFile.FileHandle.GetFile();
        string webkitRelativePath = await file.GetWebkitRelativePath(default);
        labelOutput = webkitRelativePath;
    }


    public const string BUTTON_FILE_TEXT = "filesystem-file-text";
    private async Task File_Text() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        await using IFile file = await tempFile.FileHandle.GetFile();
        string fileContent = await file.Text();
        labelOutput = fileContent != string.Empty ? fileContent : FILE_TEXT_RESULT;
    }



    public const string BUTTON_WRITABLE_FILE_STREAM_GET_LOCKED_PROPERTY = "filesystem-writable-file-stream-get-locked-property";
    private async Task WritableFileStream_GetLocked_Property() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        await using IWritableFileStream stream = await tempFile.FileHandle.CreateWritable();
        bool locked = await stream.Locked;
        await stream.Close();
        labelOutput = locked.ToString();
    }

    public const string BUTTON_WRITABLE_FILE_STREAM_GET_LOCKED_METHOD = "filesystem-writable-file-stream-get-locked-method";
    private async Task WritableFileStream_GetLocked_Method() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        await using IWritableFileStream stream = await tempFile.FileHandle.CreateWritable();
        bool locked = await stream.GetLocked(default);
        await stream.Close();
        labelOutput = locked.ToString();
    }


    public const string BUTTON_WRITABLE_FILE_STREAM_WRITE_TEXT = "filesystem-writable-file-stream-write-text";
    private async Task WritableFileStream_WriteText() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        await using IWritableFileStream stream = await tempFile.FileHandle.CreateWritable();
        await stream.Write(WRITABLE_FILE_STREAM_WRITE_TEXT);
        await stream.Close();

        await using IFile file = await tempFile.FileHandle.GetFile();
        string fileContent = await file.Text();
        labelOutput = fileContent;
    }

    public const string BUTTON_WRITABLE_FILE_STREAM_WRITE_BYTES = "filesystem-writable-file-stream-write-bytes";
    private async Task WritableFileStream_WriteBytes() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        await using IWritableFileStream stream = await tempFile.FileHandle.CreateWritable();
        await stream.Write(Encoding.UTF8.GetBytes(WRITABLE_FILE_STREAM_WRITE_TEXT));
        await stream.Close();

        await using IFile file = await tempFile.FileHandle.GetFile();
        string fileContent = await file.Text();
        labelOutput = fileContent;
    }

    public const string BUTTON_WRITABLE_FILE_STREAM_SEEK = "filesystem-writable-file-stream-seek";
    private async Task WritableFileStream_Seek() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        await using IWritableFileStream stream = await tempFile.FileHandle.CreateWritable();
        await stream.Seek(1);

        labelOutput = WRITABLE_FILE_STREAM_SEEK_DONE;
        await stream.Close();
    }

    public const string BUTTON_WRITABLE_FILE_STREAM_TRUNCATE = "filesystem-writable-file-stream-truncate";
    private async Task WritableFileStream_Truncate() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        await using IWritableFileStream stream = await tempFile.FileHandle.CreateWritable();
        await stream.Truncate(1);

        labelOutput = WRITABLE_FILE_STREAM_TRUNCATE_DONE;
        await stream.Close();
    }

    public const string BUTTON_WRITABLE_FILE_STREAM_ABORT = "filesystem-writable-file-stream-abort";
    private async Task WritableFileStream_Abort() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        await using IWritableFileStream stream = await tempFile.FileHandle.CreateWritable();
        await stream.Abort("test reason");

        labelOutput = WRITABLE_FILE_STREAM_ABORT_DONE;
    }

    public const string BUTTON_WRITABLE_FILE_STREAM_CLOSE = "filesystem-writable-file-stream-close";
    private async Task WritableFileStream_Close() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        await using IWritableFileStream stream = await tempFile.FileHandle.CreateWritable();
        await stream.Close();

        labelOutput = WRITABLE_FILE_STREAM_CLOSE_DONE;
    }
}
