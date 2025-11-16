using Microsoft.AspNetCore.Components;
using System.Text;

namespace BrowserAPI.Test.Client;

public sealed partial class FileSystemInProcessGroup : ComponentBase {
    public const string TEMP_FILE_NAME = "TempFile.txt";
    public const string FILE_TEXT_RESULT = "(empty)";
    public const string WRITABLE_FILE_STREAM_WRITE_TEXT = "some example text";
    public const string WRITABLE_FILE_STREAM_SEEK_DONE = "stream seeked";
    public const string WRITABLE_FILE_STREAM_TRUNCATE_DONE = "stream truncated";
    public const string WRITABLE_FILE_STREAM_ABORT_DONE = "stream aborted";
    public const string WRITABLE_FILE_STREAM_CLOSE_DONE = "stream closed";


    private readonly struct TempFile : IAsyncDisposable {
        public IDirectoryHandleInProcess DirectoryHandle { get; private init; }
        public IFileHandleInProcess FileHandle { get; private init; }

        public static async ValueTask<TempFile> Create(IFileSystemInProcess FileSystem) {
            IDirectoryHandleInProcess directoryHandle = await FileSystem.StorageManagerGetDirectory();
            IFileHandleInProcess fileHandle = await directoryHandle.GetFileHandle(TEMP_FILE_NAME, create: true);
            return new TempFile() {
                DirectoryHandle = directoryHandle,
                FileHandle = fileHandle
            };
        }

        public async ValueTask DisposeAsync() {
            await DirectoryHandle.RemoveEntry(TEMP_FILE_NAME);
            FileHandle.Dispose();
            DirectoryHandle.Dispose();
        }
    }


    [Inject]
    public required IFileSystemInProcess FileSystem { private get; init; }


    public const string LABEL_OUTPUT = "filesystem-inprocess-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_SHOW_OPEN_FILE_PICKER = "filesystem-inprocess-show-open-file-picker";
    private async Task ShowOpenFilePicker() {
        using IFileHandleInProcess fileHandle = await FileSystem.ShowOpenFilePicker(id: "example", PickerDialogStartIn.Desktop, excludeAcceptAllOption: true, [("text", [("text/plain", [".txt"])])]);
        labelOutput = (fileHandle is not null).ToString();
    }

    public const string BUTTON_SHOW_OPEN_FILE_PICKER_MULTIPLE_FILES = "filesystem-inprocess-show-open-file-picker-multiple-files";
    private async Task ShowOpenFilePickerMultipleFiles() {
        IFileHandleInProcess[] fileHandleList = await FileSystem.ShowOpenFilePickerMultipleFiles(id: "Example", PickerDialogStartIn.Pictures, excludeAcceptAllOption: false, [("images", [("image/*", [".jpg", ".jpeg", ".png", ".gif"])])]);
        labelOutput = fileHandleList.Length.ToString();

        fileHandleList.Dispose();
    }

    public const string BUTTON_SHOW_SAVE_FILE_PICKER = "filesystem-inprocess-show-save-file-picker";
    private async Task ShowSaveFilePicker() {
        using IFileHandleInProcess fileHandle = await FileSystem.ShowSaveFilePicker(suggestedName: "asdf.txt", id: "y", PickerDialogStartIn.Documents, excludeAcceptAllOption: false, [("text", [("text/*", [".txt"])])]);
        labelOutput = (fileHandle is not null).ToString();
    }

    public const string BUTTON_SHOW_DIRECTORY_PICKER = "filesystem-inprocess-show-directory-picker";
    private async Task ShowDirectoryPicker() {
        using IDirectoryHandleInProcess directoryHandle = await FileSystem.ShowDirectoryPicker("readwrite", id: "Y", PickerDialogStartIn.Videos);
        labelOutput = (directoryHandle is not null).ToString();
    }


    public const string BUTTON_STORAGE_MANAGER_ESTIMATE = "filesystem-inprocess-storage-manager-estimate";
    private async Task StorageManagerEstimate() {
        (long? usage, long? quota) = await FileSystem.StorageManagerEstimate();
        labelOutput = $"(usage: {usage}, quota: {quota})";
    }

    public const string BUTTON_STORAGE_MANAGER_PERSIST = "filesystem-inprocess-storage-manager-persist";
    private async Task StorageManagerPersist() {
        bool persist = await FileSystem.StorageManagerPersist();
        labelOutput = persist.ToString();
    }

    public const string BUTTON_STORAGE_MANAGER_PERSISTED = "filesystem-inprocess-storage-manager-persisted";
    private async Task StorageManagerPersisted() {
        bool persist = await FileSystem.StorageManagerPersisted();
        labelOutput = persist.ToString();
    }

    public const string BUTTON_STORAGE_MANAGER_GET_DIRECTORY = "filesystem-inprocess-storage-manager-get-directory";
    private async Task StorageManagerGetDirectory() {
        using IDirectoryHandleInProcess directoryHandle = await FileSystem.StorageManagerGetDirectory();
        labelOutput = (directoryHandle is not null).ToString();
    }



    public const string BUTTON_FILEHANDLE_GET_NAME = "filesystem-inprocess-filehandle-get-name";
    private async Task FileHandle_GetName() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        string name = tempFile.FileHandle.Name;
        labelOutput = name;
    }

    public const string BUTTON_FILEHANDLE_GET_KIND = "filesystem-inprocess-filehandle-get-kind";
    private async Task FileHandle_GetKind() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        string kind = tempFile.FileHandle.Kind;
        labelOutput = kind;
    }


    public const string BUTTON_FILEHANDLE_IS_SAME_Entry = "filesystem-inprocess-filehandle-is-same-entry";
    private async Task FileHandle_IsSameEntry() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        bool isSame = await tempFile.FileHandle.IsSameEntry(tempFile.FileHandle);
        labelOutput = isSame.ToString();
    }

    public const string BUTTON_FILEHANDLE_GET_FILE = "filesystem-inprocess-filehandle-get-file";
    private async Task FileHandle_GetFile() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        using IFileInProcess file = await tempFile.FileHandle.GetFile();
        labelOutput = (file is not null).ToString();
    }

    public const string BUTTON_FILEHANDLE_CREATE_WRITABLE = "filesystem-inprocess-filehandle-create-writable";
    private async Task FileHandle_CreateWritable() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        using IWritableFileStreamInProcess writableFileStream = await tempFile.FileHandle.CreateWritable();
        await writableFileStream.Close();
        labelOutput = (writableFileStream is not null).ToString();
    }



    public const string BUTTON_DIRECTORYHANDLE_GET_NAME = "filesystem-inprocess-directoryhandle-get-name";
    private async Task DirectoryHandle_GetName() {
        using IDirectoryHandleInProcess directoryHandle = await FileSystem.StorageManagerGetDirectory();
        string name = directoryHandle.Name;
        labelOutput = name;
    }

    public const string BUTTON_DIRECTORYHANDLE_GET_KIND = "filesystem-inprocess-directoryhandle-get-kind";
    private async Task DirectoryHandle_GetKind() {
        using IDirectoryHandleInProcess directoryHandle = await FileSystem.StorageManagerGetDirectory();
        string kind = directoryHandle.Kind;
        labelOutput = kind;
    }


    public const string BUTTON_DIRECTORYHANDLE_IS_SAME_Entry = "filesystem-inprocess-directoryhandle-is-same-entry";
    private async Task DirectoryHandle_IsSameEntry() {
        using IDirectoryHandleInProcess directoryHandle = await FileSystem.StorageManagerGetDirectory();
        bool isSame = await directoryHandle.IsSameEntry(directoryHandle);
        labelOutput = isSame.ToString();
    }

    public const string BUTTON_DIRECTORYHANDLE_GET_DIRECTORYHANDLE = "filesystem-inprocess-directoryhandle-get-directoryhandle";
    private async Task DirectoryHandle_GetDirectoryHandle() {
        using IDirectoryHandleInProcess directoryHandle = await FileSystem.StorageManagerGetDirectory();
        using IDirectoryHandleInProcess subDirectoryHandle = await directoryHandle.GetDirectoryHandle("temp", create: true);
        labelOutput = (subDirectoryHandle is not null).ToString();

        await directoryHandle.RemoveEntry("temp", recursive: true);
    }

    public const string BUTTON_DIRECTORYHANDLE_GET_FILEHANDLE = "filesystem-inprocess-directoryhandle-get-filehandle";
    private async Task DirectoryHandle_GetFileHandle() {
        using IDirectoryHandleInProcess directoryHandle = await FileSystem.StorageManagerGetDirectory();
        using IFileHandleInProcess fileHandle = await directoryHandle.GetFileHandle("temp.txt", create: true);
        labelOutput = (fileHandle is not null).ToString();

        await directoryHandle.RemoveEntry("temp.txt");
    }

    public const string BUTTON_DIRECTORYHANDLE_REMOVE_ENTRY = "filesystem-inprocess-directoryhandle-remove-entry";
    private async Task DirectoryHandle_RemoveEntry() {
        using IDirectoryHandleInProcess directoryHandle = await FileSystem.StorageManagerGetDirectory();
        using IDirectoryHandleInProcess subFolder = await directoryHandle.GetDirectoryHandle("subFolder", create: true);
        using IFileHandleInProcess fileHandle = await subFolder.GetFileHandle("someFile", create: true);
        await directoryHandle.RemoveEntry("subFolder", recursive: true);

        (long? usage, _) = await FileSystem.StorageManagerEstimate();
        labelOutput = $"usage: {usage?.ToString() ?? "unkown"}";
    }

    public const string BUTTON_DIRECTORYHANDLE_VALUES = "filesystem-inprocess-directoryhandle-values";
    private async Task DirectoryHandle_Values() {
        using IDirectoryHandleInProcess directoryHandle = await FileSystem.StorageManagerGetDirectory();
        using IDirectoryHandleInProcess subDirectory1 = await directoryHandle.GetDirectoryHandle("sub1", create: true);
        using IDirectoryHandleInProcess subDirectory2 = await directoryHandle.GetDirectoryHandle("sub2", create: true);
        using IFileHandleInProcess fileHandle1 = await directoryHandle.GetFileHandle("temp1.txt", create: true);
        using IFileHandleInProcess fileHandle2 = await subDirectory1.GetFileHandle("temp2.txt", create: true);
        (IFileHandleInProcess[] fileList, IDirectoryHandleInProcess[] directoryList) = await directoryHandle.Values();

        StringBuilder builder = new(1024);
        builder.Append($"({fileList.Length + directoryList.Length}): ");
        foreach (IDirectoryHandleInProcess directory in directoryList)
            builder.Append($"folder: {directory.Name}, ");
        foreach (IFileHandleInProcess file in fileList)
            builder.Append($"file: {file.Name}, ");
        builder.Length -= 2;
        labelOutput = builder.ToString();

        await directoryHandle.RemoveEntry("sub1", recursive: true);
        await directoryHandle.RemoveEntry("sub2");
        await directoryHandle.RemoveEntry("temp1.txt");
        (fileList, directoryList).Dispose();
    }



    public const string BUTTON_FILE_GET_NAME = "filesystem-inprocess-file-get-name";
    private async Task File_GetName() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        using IFileInProcess file = await tempFile.FileHandle.GetFile();
        string name = file.Name;
        labelOutput = name;
    }

    public const string BUTTON_FILE_GET_SIZE = "filesystem-inprocess-file-get-size";
    private async Task File_GetSize() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        using IFileInProcess file = await tempFile.FileHandle.GetFile();
        long size = file.Size;
        labelOutput = size.ToString();
    }

    public const string BUTTON_FILE_GET_TYPE = "filesystem-inprocess-file-get-type";
    private async Task File_GetType() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        using IFileInProcess file = await tempFile.FileHandle.GetFile();
        string type = file.Type;
        labelOutput = type;
    }

    public const string BUTTON_FILE_GET_LAST_MODIFIED = "filesystem-inprocess-file-get-last-modified";
    private async Task File_GetLastModified() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        using IFileInProcess file = await tempFile.FileHandle.GetFile();
        long lastModified = file.LastModified;
        labelOutput = lastModified.ToString();
    }

    public const string BUTTON_FILE_GET_WEBKIT_RELATIVE_PATH = "filesystem-inprocess-file-get-webkit-relative-path";
    private async Task File_GetWebkitRelativePath() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        using IFileInProcess file = await tempFile.FileHandle.GetFile();
        string webkitRelativePath = file.WebkitRelativePath;
        labelOutput = webkitRelativePath;
    }


    public const string BUTTON_FILE_TEXT = "filesystem-inprocess-file-text";
    private async Task File_Text() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        using IFileInProcess file = await tempFile.FileHandle.GetFile();
        string fileContent = await file.Text();
        labelOutput = fileContent != string.Empty ? fileContent : FILE_TEXT_RESULT;
    }



    public const string BUTTON_WRITABLE_FILE_STREAM_GET_LOCKED = "filesystem-inprocess-writable-file-stream-get-locked";
    private async Task WritableFileStream_GetLocked() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        using IWritableFileStreamInProcess stream = await tempFile.FileHandle.CreateWritable();
        bool locked = stream.Locked;
        await stream.Close();
        labelOutput = locked.ToString();
    }


    public const string BUTTON_WRITABLE_FILE_STREAM_WRITE_TEXT = "filesystem-inprocess-writable-file-stream-write-text";
    private async Task WritableFileStream_WriteText() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        using IWritableFileStreamInProcess stream = await tempFile.FileHandle.CreateWritable();
        await stream.Write(WRITABLE_FILE_STREAM_WRITE_TEXT);
        await stream.Close();

        using IFileInProcess file = await tempFile.FileHandle.GetFile();
        string fileContent = await file.Text();
        labelOutput = fileContent;
    }

    public const string BUTTON_WRITABLE_FILE_STREAM_WRITE_BYTES = "filesystem-inprocess-writable-file-stream-write-bytes";
    private async Task WritableFileStream_WriteBytes() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        using IWritableFileStreamInProcess stream = await tempFile.FileHandle.CreateWritable();
        await stream.Write(Encoding.UTF8.GetBytes(WRITABLE_FILE_STREAM_WRITE_TEXT));
        await stream.Close();

        using IFileInProcess file = await tempFile.FileHandle.GetFile();
        string fileContent = await file.Text();
        labelOutput = fileContent;
    }

    public const string BUTTON_WRITABLE_FILE_STREAM_SEEK = "filesystem-inprocess-writable-file-stream-seek";
    private async Task WritableFileStream_Seek() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        using IWritableFileStreamInProcess stream = await tempFile.FileHandle.CreateWritable();
        await stream.Seek(1);

        labelOutput = WRITABLE_FILE_STREAM_SEEK_DONE;
        await stream.Close();
    }

    public const string BUTTON_WRITABLE_FILE_STREAM_TRUNCATE = "filesystem-inprocess-writable-file-stream-truncate";
    private async Task WritableFileStream_Truncate() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        using IWritableFileStreamInProcess stream = await tempFile.FileHandle.CreateWritable();
        await stream.Truncate(1);

        labelOutput = WRITABLE_FILE_STREAM_TRUNCATE_DONE;
        await stream.Close();
    }

    public const string BUTTON_WRITABLE_FILE_STREAM_ABORT = "filesystem-inprocess-writable-file-stream-abort";
    private async Task WritableFileStream_Abort() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        using IWritableFileStreamInProcess stream = await tempFile.FileHandle.CreateWritable();
        await stream.Abort("test reason");

        labelOutput = WRITABLE_FILE_STREAM_ABORT_DONE;
    }

    public const string BUTTON_WRITABLE_FILE_STREAM_CLOSE = "filesystem-inprocess-writable-file-stream-close";
    private async Task WritableFileStream_Close() {
        await using TempFile tempFile = await TempFile.Create(FileSystem);
        using IWritableFileStreamInProcess stream = await tempFile.FileHandle.CreateWritable();
        await stream.Close();

        labelOutput = WRITABLE_FILE_STREAM_CLOSE_DONE;
    }
}
