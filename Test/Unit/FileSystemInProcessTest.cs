using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class FileSystemInProcessTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    [Test]
    public async Task ShowOpenFilePicker() {
        await Page.EvaluateAsync("showOpenFilePicker = (options) => Promise.resolve([{}]);");
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_SHOW_OPEN_FILE_PICKER);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task ShowOpenFilePickerMultipleFiles() {
        await Page.EvaluateAsync("showOpenFilePicker = (options) => Promise.resolve([{}]);");
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_SHOW_OPEN_FILE_PICKER_MULTIPLE_FILES);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(int.Parse(result!)).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    public async Task ShowSaveFilePicker() {
        await Page.EvaluateAsync("showSaveFilePicker = (options) => Promise.resolve({});");
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_SHOW_SAVE_FILE_PICKER);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task ShowDirectoryPicker() {
        await Page.EvaluateAsync("showDirectoryPicker = (options) => Promise.resolve({});");
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_SHOW_DIRECTORY_PICKER);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }


    [Test]
    public async Task StorageManagerEstimate() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_STORAGE_MANAGER_ESTIMATE);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        // e.g. result = "(usage: 0, quota: 613807656960)"

        const string usagePart = "(usage: ";
        await Assert.That(result).StartsWith(usagePart);

        int index = usagePart.Length;
        while ('0' <= result![index] && result[index] <= '9')
            index++;

        const string quotaPart = ", quota: ";
        await Assert.That(result[index..(index + quotaPart.Length)]).IsEqualTo(quotaPart);

        index += quotaPart.Length;
        while ('0' <= result[index] && result[index] <= '9')
            index++;

        await Assert.That(result[index]).IsEqualTo(')');
        await Assert.That(index).IsEqualTo(result.Length - 1);
    }

    [Test]
    public async Task StorageManagerPersist() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_STORAGE_MANAGER_PERSIST);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task StorageManagerPersisted() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_STORAGE_MANAGER_PERSISTED);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    public async Task StorageManagerGetDirectory() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_STORAGE_MANAGER_GET_DIRECTORY);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }



    [Test]
    public async Task FileHandle_GetName() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_FILEHANDLE_GET_NAME);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(FileSystemInProcessGroup.TEMP_FILE_NAME);
    }

    [Test]
    public async Task FileHandle_GetKind() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_FILEHANDLE_GET_KIND);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("file");
    }


    [Test]
    public async Task FileHandle_IsSameEntry() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_FILEHANDLE_IS_SAME_Entry);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task FileHandle_GetFile() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_FILEHANDLE_GET_FILE);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task FileHandle_CreateWritable() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_FILEHANDLE_CREATE_WRITABLE);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }



    [Test]
    public async Task DirectoryHandle_GetName() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_DIRECTORYHANDLE_GET_NAME);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task DirectoryHandle_GetKind() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_DIRECTORYHANDLE_GET_KIND);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("directory");
    }


    [Test]
    public async Task DirectoryHandle_IsSameEntry() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_DIRECTORYHANDLE_IS_SAME_Entry);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task DirectoryHandle_GetDirectoryHandle() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_DIRECTORYHANDLE_GET_DIRECTORYHANDLE);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task DirectoryHandle_GetFileHandle() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_DIRECTORYHANDLE_GET_FILEHANDLE);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    public async Task DirectoryHandle_RemoveEntry() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_DIRECTORYHANDLE_REMOVE_ENTRY);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("usage: 0");
    }

    [Test]
    public async Task DirectoryHandle_Values() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_DIRECTORYHANDLE_VALUES);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("(3): folder: sub2, folder: sub1, file: temp1.txt");
    }



    [Test]
    public async Task File_GetName() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_FILE_GET_NAME);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(FileSystemInProcessGroup.TEMP_FILE_NAME);
    }

    [Test]
    public async Task File_GetSize() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_FILE_GET_SIZE);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("0");
    }

    [Test]
    public async Task File_GetType() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_FILE_GET_TYPE);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("text/plain");
    }

    [Test]
    public async Task File_GetLastModified() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_FILE_GET_LAST_MODIFIED);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(long.Parse(result!)).IsGreaterThan(0L);
    }

    [Test]
    public async Task File_GetWebkitRelativePath() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_FILE_GET_WEBKIT_RELATIVE_PATH);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(string.Empty);
    }


    [Test]
    public async Task File_Text() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_FILE_TEXT);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(FileSystemInProcessGroup.FILE_TEXT_RESULT);
    }



    [Test]
    public async Task WritableFileStream_GetLocked() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_WRITABLE_FILE_STREAM_GET_LOCKED);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }


    [Test]
    public async Task WritableFileStream_WriteText() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_WRITABLE_FILE_STREAM_WRITE_TEXT);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(FileSystemInProcessGroup.WRITABLE_FILE_STREAM_WRITE_TEXT);
    }

    [Test]
    public async Task WritableFileStream_WriteBytes() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_WRITABLE_FILE_STREAM_WRITE_BYTES);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(FileSystemInProcessGroup.WRITABLE_FILE_STREAM_WRITE_TEXT);
    }

    [Test]
    public async Task WritableFileStream_Seek() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_WRITABLE_FILE_STREAM_SEEK);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(FileSystemInProcessGroup.WRITABLE_FILE_STREAM_SEEK_DONE);
    }

    [Test]
    public async Task WritableFileStream_Truncate() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_WRITABLE_FILE_STREAM_TRUNCATE);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(FileSystemInProcessGroup.WRITABLE_FILE_STREAM_TRUNCATE_DONE);
    }

    [Test]
    public async Task WritableFileStream_Abort() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_WRITABLE_FILE_STREAM_ABORT);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(FileSystemInProcessGroup.WRITABLE_FILE_STREAM_ABORT_DONE);
    }

    [Test]
    public async Task WritableFileStream_Close() {
        await ExecuteTest(FileSystemInProcessGroup.BUTTON_WRITABLE_FILE_STREAM_CLOSE);

        string? result = await Page.GetByTestId(FileSystemInProcessGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(FileSystemInProcessGroup.WRITABLE_FILE_STREAM_CLOSE_DONE);
    }
}
