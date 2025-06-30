using BrowserAPI.Test.Client;

namespace BrowserAPI.UnitTest;

[ClassDataSource<PlayWrightFixture>(Shared = SharedType.PerAssembly)]
public sealed class FileSystemTest(PlayWrightFixture playWrightFixture) : PlayWrightTest(playWrightFixture) {
    /* File Picker Dialog not working

    [Test]
    [Retry(3)]
    public async Task ShowOpenFilePicker() {
        Page.FileChooser += (object? _, IFileChooser fileChooser) => fileChooser.SetFilesAsync("test.txt");
        await Page.GetByTestId(FileSystemGroup.BUTTON_SHOW_OPEN_FILE_PICKER).ClickAsync();

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    [Retry(3)]
    public async Task ShowOpenFilePickerMultipleFiles() {
        Page.FileChooser += (object? _, IFileChooser fileChooser) => fileChooser.SetFilesAsync("test.txt");
        await Page.GetByTestId(FileSystemGroup.BUTTON_SHOW_OPEN_FILE_PICKER_MULTIPLE_FILES).ClickAsync();

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(int.Parse(result!)).IsGreaterThanOrEqualTo(0);
    }

    [Test]
    [Retry(3)]
    public async Task ShowSaveFilePicker() {
        Page.FileChooser += (object? _, IFileChooser fileChooser) => fileChooser.SetFilesAsync("test.txt");
        await Page.GetByTestId(FileSystemGroup.BUTTON_SHOW_SAVE_FILE_PICKER).ClickAsync();

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    [Retry(3)]
    public async Task ShowDirectoryPicker() {
        Page.FileChooser += (object? _, IFileChooser fileChooser) => fileChooser.SetFilesAsync(".");
        await Page.GetByTestId(FileSystemGroup.BUTTON_SHOW_DIRECTORY_PICKER).ClickAsync();

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    */


    [Test]
    [Retry(3)]
    public async Task StorageManagerEstimate() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_STORAGE_MANAGER_ESTIMATE).ClickAsync();

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();

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
    [Retry(3)]
    public async Task StorageManagerPersist() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_STORAGE_MANAGER_PERSIST).ClickAsync();

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    [Retry(3)]
    public async Task StorageManagerPersisted() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_STORAGE_MANAGER_PERSISTED).ClickAsync();

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    [Retry(3)]
    public async Task StorageManagerGetDirectory() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_STORAGE_MANAGER_GET_DIRECTORY).ClickAsync();

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }



    [Test]
    [Retry(3)]
    public async Task FileHandle_GetName_Property() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_FILEHANDLE_GET_NAME_PROPERTY).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(FileSystemGroup.TEMP_FILE_NAME);
    }

    [Test]
    [Retry(3)]
    public async Task FileHandle_GetName_Method() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_FILEHANDLE_GET_NAME_METHOD).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(FileSystemGroup.TEMP_FILE_NAME);
    }

    [Test]
    [Retry(3)]
    public async Task FileHandle_GetKind() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_FILEHANDLE_GET_KIND).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("file");
    }


    [Test]
    [Retry(3)]
    public async Task FileHandle_IsSameEntry() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_FILEHANDLE_IS_SAME_Entry).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    [Retry(3)]
    public async Task FileHandle_GetFile() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_FILEHANDLE_GET_FILE).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    [Retry(3)]
    public async Task FileHandle_CreateWritable() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_FILEHANDLE_CREATE_WRITABLE).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }



    [Test]
    [Retry(3)]
    public async Task DirectoryHandle_GetName_Property() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_DIRECTORYHANDLE_GET_NAME_PROPERTY).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    [Retry(3)]
    public async Task DirectoryHandle_GetName_Method() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_DIRECTORYHANDLE_GET_NAME_METHOD).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    [Retry(3)]
    public async Task DirectoryHandle_GetKind() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_DIRECTORYHANDLE_GET_KIND).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("directory");
    }


    [Test]
    [Retry(3)]
    public async Task DirectoryHandle_IsSameEntry() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_DIRECTORYHANDLE_IS_SAME_Entry).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    [Retry(3)]
    public async Task DirectoryHandle_GetDirectoryHandle() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_DIRECTORYHANDLE_GET_DIRECTORYHANDLE).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    [Retry(3)]
    public async Task DirectoryHandle_GetFileHandle() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_DIRECTORYHANDLE_GET_FILEHANDLE).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("True");
    }

    [Test]
    [Retry(3)]
    public async Task DirectoryHandle_RemoveEntry() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_DIRECTORYHANDLE_REMOVE_ENTRY).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("usage: 0");
    }

    [Test]
    [Retry(3)]
    public async Task DirectoryHandle_Values() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_DIRECTORYHANDLE_VALUES).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("(3): folder: sub2, folder: sub1, file: temp1.txt");
    }



    [Test]
    [Retry(3)]
    public async Task File_GetName_Property() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_FILE_GET_NAME_PROPERTY).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(FileSystemGroup.TEMP_FILE_NAME);
    }

    [Test]
    [Retry(3)]
    public async Task File_GetName_Method() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_FILE_GET_NAME_METHOD).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(FileSystemGroup.TEMP_FILE_NAME);
    }

    [Test]
    [Retry(3)]
    public async Task File_GetSize_Property() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_FILE_GET_SIZE_PROPERTY).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("0");
    }

    [Test]
    [Retry(3)]
    public async Task File_GetSize_Method() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_FILE_GET_SIZE_METHOD).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("0");
    }

    [Test]
    [Retry(3)]
    public async Task File_GetType_Property() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_FILE_GET_TYPE_PROPERTY).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("text/plain");
    }

    [Test]
    [Retry(3)]
    public async Task File_GetType_Method() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_FILE_GET_TYPE_METHOD).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("text/plain");
    }

    [Test]
    [Retry(3)]
    public async Task File_GetLastModified_Property() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_FILE_GET_LAST_MODIFIED_PROPERTY).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(long.Parse(result!)).IsGreaterThan(0L);
    }

    [Test]
    [Retry(3)]
    public async Task File_GetLastModified_Method() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_FILE_GET_LAST_MODIFIED_METHOD).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(long.Parse(result!)).IsGreaterThan(0L);
    }

    [Test]
    [Retry(3)]
    public async Task File_GetWebkitRelativePath_Property() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_FILE_GET_WEBKIT_RELATIVE_PATH_PROPERTY).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    [Retry(3)]
    public async Task File_GetWebkitRelativePath_Method() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_FILE_GET_WEBKIT_RELATIVE_PATH_METHOD).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(string.Empty);
    }


    [Test]
    [Retry(3)]
    public async Task File_Text() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_FILE_TEXT).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(FileSystemGroup.FILE_TEXT_RESULT);
    }



    [Test]
    [Retry(3)]
    public async Task WritableFileStream_GetLocked_Property() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_WRITABLE_FILE_STREAM_GET_LOCKED_PROPERTY).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }

    [Test]
    [Retry(3)]
    public async Task WritableFileStream_GetLocked_Method() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_WRITABLE_FILE_STREAM_GET_LOCKED_METHOD).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo("False");
    }


    [Test]
    [Retry(3)]
    public async Task WritableFileStream_WriteText() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_WRITABLE_FILE_STREAM_WRITE_TEXT).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(FileSystemGroup.WRITABLE_FILE_STREAM_WRITE_TEXT);
    }

    [Test]
    [Retry(3)]
    public async Task WritableFileStream_WriteBytes() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_WRITABLE_FILE_STREAM_WRITE_BYTES).ClickAsync();
        await Task.Delay(500);

        string? result = await Page.GetByTestId(FileSystemGroup.LABEL_OUTPUT).TextContentAsync();
        await Assert.That(result).IsEqualTo(FileSystemGroup.WRITABLE_FILE_STREAM_WRITE_TEXT);
    }

    [Test]
    [Retry(3)]
    public async Task WritableFileStream_Seek() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_WRITABLE_FILE_STREAM_SEEK).ClickAsync();
        await Task.Delay(500);

        // an assertion happens in DisposeAsync()
    }

    [Test]
    [Retry(3)]
    public async Task WritableFileStream_Truncate() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_WRITABLE_FILE_STREAM_TRUNCATE).ClickAsync();
        await Task.Delay(500);

        // an assertion happens in DisposeAsync()
    }

    [Test]
    [Retry(3)]
    public async Task WritableFileStream_Abort() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_WRITABLE_FILE_STREAM_ABORT).ClickAsync();
        await Task.Delay(500);

        // an assertion happens in DisposeAsync()
    }

    [Test]
    [Retry(3)]
    public async Task WritableFileStream_Close() {
        await Page.GetByTestId(FileSystemGroup.BUTTON_WRITABLE_FILE_STREAM_CLOSE).ClickAsync();
        await Task.Delay(500);

        // an assertion happens in DisposeAsync()
    }
}
