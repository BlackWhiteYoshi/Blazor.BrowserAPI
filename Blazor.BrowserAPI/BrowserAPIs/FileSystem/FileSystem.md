# FileSystem

The *File System API*
— with extensions provided via the [File System Access API](https://wicg.github.io/file-system-access) to access files on the device file system —
allows read, write and file management capabilities.

See [Relationship to other file-related APIs](https://developer.mozilla.org/en-US/docs/Web/API/File_API#relationship_to_other_file-related_apis) for a comparison between this API,
the [File and Directory Entries API](https://developer.mozilla.org/en-US/docs/Web/API/File_and_Directory_Entries_API),
and the [File API](https://developer.mozilla.org/en-US/docs/Web/API/File_API).


<br><br />
## Example

```csharp
public sealed partial class ExampleComponent : ComponentBase {
    [Inject]
    public required IFileSystem FileSystem { private get; init; }

    private async Task ReadFile() {
        await using IFileHandle fileHandle = await FileSystem.ShowOpenFilePicker();
        await using IFile file = await fileHandle.GetFile();
        string fileContent = await file.Text();
    }

    private async Task WriteFile() {
        await using IFileHandle fileHandle = await FileSystem.ShowSaveFilePicker(suggestedName: "example.json", startIn: PickerDialogStartIn.Documents, excludeAcceptAllOption: true, types: [("JSON", [("application/json", [".json"])])]);
        await using IWritableFileStream fileStream = await fileHandle.CreateWritable();
        await fileStream.Write("""{ "id": 0, "secret-key": "Yoshi", "password": "123456" }""");
        await fileStream.Close(); // disposing does not call Close(), always Close() before disposing
    }

    private async Task RemoveContentOfDirectory() {
        await using IDirectoryHandle directoryHandle = await FileSystem.ShowDirectoryPicker();
        (IFileHandle[] fileHandleList, IDirectoryHandle[] directoryHandleList) = await directoryHandle.Values();

        foreach (IFileHandle fileHandle in fileHandleList)
            await directoryHandle.RemoveEntry(await fileHandle.Name);
        foreach (IDirectoryHandle subdirectoryHandle in directoryHandleList)
            await directoryHandle.RemoveEntry(await subdirectoryHandle.Name, recursive: true);

        await (fileHandleList, directoryHandleList).DisposeAsync(); // always dispose all obtained handles
    }
}
```


<br><br />
## Members

### IFileSystem

The *File System API*
— with extensions provided via the [File System Access API](https://wicg.github.io/file-system-access) to access files on the device file system —
allows read, write and file management capabilities.

See [Relationship to other file-related APIs](https://developer.mozilla.org/en-US/docs/Web/API/File_API#relationship_to_other_file-related_apis) for a comparison between this API,
the [File and Directory Entries API](https://developer.mozilla.org/en-US/docs/Web/API/File_and_Directory_Entries_API),
and the [File API](https://developer.mozilla.org/en-US/docs/Web/API/File_API).

#### Methods

| **Name**                        | **Parameters**                                                                                                                                                                                                                                                                    | **ReturnType**                              | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
| ------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| ShowOpenFilePicker              | [string? id = null], [PickerDialogStartIn startIn = default], [bool excludeAcceptAllOption = false], [(string description, (string MIMEtype, string[] fileExtensions)[] accept)[]? types = null], [CancellationToken cancellationToken = default]                                 | ValueTask&lt;IFileHandle&gt;                | The *showOpenFilePicker()* method of the Window interface shows a file picker that allows a user to select a file and returns a handle for the file.<br/>When the user clicks on the cancel button or just closes the dialog picker, an Exception is thrown.<br/>This method sets the parameter [multiple](https://developer.mozilla.org/en-US/docs/Web/API/Window/showOpenFilePicker#multiple) to false, so a single fileHandle is returned. When multiple files should be selectable use the method *ShowOpenFilePickerMultipleFiles()*. |
| ShowOpenFilePickerMultipleFiles | [string? id = null], [PickerDialogStartIn startIn = default], [bool excludeAcceptAllOption = false], [(string description, (string MIMEtype, string[] fileExtensions)[] accept)[]? types = null], [CancellationToken cancellationToken = default]                                 | ValueTask&lt;IFileHandle[]&gt;              | The *showOpenFilePicker()* method of the Window interface shows a file picker that allows a user to select a file and returns a handle for the file.<br/>When the user clicks on the cancel button or just closes the dialog picker, an Exception is thrown.<br/>This method sets the parameter [multiple](https://developer.mozilla.org/en-US/docs/Web/API/Window/showOpenFilePicker#multiple) to true, so a multiple fileHandles can be returned. When only a single file should be selectable use the method *ShowOpenFilePicker()*.    |
| ShowSaveFilePicker              | [string? suggestedName = null], [string? id = null], [PickerDialogStartIn startIn = default], [bool excludeAcceptAllOption = false], [(string description, (string MIMEtype, string[] fileExtensions)[] accept)[]? types = null], [CancellationToken cancellationToken = default] | ValueTask&lt;IFileHandle&gt;                | The *showSaveFilePicker()* method of the Window interface shows a file picker that allows a user to save a file. Either by selecting an existing file, or entering a name for a new file.<br/>When the user clicks on the cancel button or just closes the dialog picker, an Exception is thrown.                                                                                                                                                                                                                                          |
| ShowDirectoryPicker             | [string mode = "read"], [string? id = null], [PickerDialogStartIn startIn = default], [CancellationToken cancellationToken = default]                                                                                                                                             | ValueTask&lt;IDirectoryHandle&gt;           | The *showDirectoryPicker()* method of the Window interface displays a directory picker which allows the user to select a directory.<br/>>When the user clicks on the cancel button or just closes the dialog picker, an Exception is thrown.                                                                                                                                                                                                                                                                                               |
| StorageManagerEstimate          | [CancellationToken cancellationToken = default]                                                                                                                                                                                                                                   | ValueTask&lt;(long? usage, long? quota)&gt; | The *estimate()* method of the StorageManager interface asks the Storage Manager for how much storage the current origin takes up (usage), and how much space is available (quota).<br/>This method operates asynchronously, so it returns a Promise which resolves once the information is available. The promise's fulfillment handler is called with an object containing the usage and quota data.                                                                                                                                     |
| StorageManagerPersist           | [CancellationToken cancellationToken = default]                                                                                                                                                                                                                                   | ValueTask&lt;bool&gt;                       | The *persist()* method of the StorageManager interface requests permission to use persistent storage, and returns a Promise that resolves to true if permission is granted and bucket mode is persistent, and false otherwise. The browser may or may not honor the request, depending on browser-specific rules. (For more details, see the guide to [Storage quotas and eviction criteria](https://developer.mozilla.org/en-US/docs/Web/API/Storage_API/Storage_quotas_and_eviction_criteria#does_browser-stored_data_persist).)         |
| StorageManagerPersisted         | [CancellationToken cancellationToken = default]                                                                                                                                                                                                                                   | ValueTask&lt;bool&gt;                       | The *persisted()* method of the StorageManager interface returns a Promise that resolves to true if your site's storage bucket is persistent.                                                                                                                                                                                                                                                                                                                                                                                              |
| StorageManagerGetDirectory      | [CancellationToken cancellationToken = default]                                                                                                                                                                                                                                   | ValueTask&lt;IDirectoryHandle&gt;           | The *getDirectory()* method of the StorageManager interface is used to obtain a reference to a FileSystemDirectoryHandle object allowing access to a directory and its contents, stored in the origin private file system (OPFS).                                                                                                                                                                                                                                                                                                          |


<br></br>
### IFileHandle

The *FileSystemFileHandle* interface of the File System API represents a handle to a file system entry. The interface is accessed through the window.showOpenFilePicker() method.

Note that read and write operations depend on file-access permissions that do not persist after a page refresh if no other tabs for that origin remain open. The queryPermission method of the FileSystemHandle interface can be used to verify permission state before accessing a file.

#### Properties

| **Name** | **Type**                | get/set | **Description**                                                                                                                                                                               |
| -------- | ----------------------- | ------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Name     | ValueTask&lt;string&gt; | get     | Returns the name of the associated entry.                                                                                                                                                     |
| Kind     | string                  | get     | Returns the type of entry. This is 'file' if the associated entry is a file or 'directory'. It is used to distinguish files from directories when iterating over the contents of a directory. |

#### Methods

| **Name**       | **Parameters**                                                                                             | **ReturnType**                       | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
| -------------- | ---------------------------------------------------------------------------------------------------------- | ------------------------------------ | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetName        | CancellationToken cancellationToken                                                                        | ValueTask&lt;string&gt;              | Returns the name of the associated entry.                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| IsSameEntry    | IFileHandle other, [CancellationToken cancellationToken = default]                                         | ValueTask&lt;bool&gt;                | Compares two file handles to see if the associated entries match.                                                                                                                                                                                                                                                                                                                                                                                                                   |
| GetFile        | [CancellationToken cancellationToken = default]                                                            | ValueTask&lt;IFile&gt;               | Returns a Promise which resolves to a File object representing the state on disk of the entry represented by the handle.<br/>If the file on disk changes or is removed after this method is called, the returned File object will likely be no longer readable.                                                                                                                                                                                                                     |
| CreateWritable | [bool keepExistingData = false], [string mode = "siloed"], [CancellationToken cancellationToken = default] | ValueTask&lt;IWritableFileStream&gt; | Creates a FileSystemWritableFileStream that can be used to write to a file. The method returns a Promise which resolves to this created stream.<br/> Any changes made through the stream won't be reflected in the file represented by the file handle until the stream has been closed. This is typically implemented by writing data to a temporary file, and only replacing the file represented by file handle with the temporary file when the writable file stream is closed. |


<br></br>
### IDirectoryHandle

The *FileSystemDirectoryHandle* interface of the File System API provides a handle to a file system directory.

The interface can be accessed via the following methods:
 - [window.showDirectoryPicker()](https://developer.mozilla.org/en-US/docs/Web/API/Window/showDirectoryPicker)
 - [StorageManager.getDirectory()](https://developer.mozilla.org/en-US/docs/Web/API/StorageManager/getDirectory)
 - [DataTransferItem.getAsFileSystemHandle()](https://developer.mozilla.org/en-US/docs/Web/API/DataTransferItem/getAsFileSystemHandle)
 - [FileSystemDirectoryHandle.getDirectoryHandle()](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemDirectoryHandle/getDirectoryHandle)

#### Properties

| **Name** | **Type**                | get/set | **Description**                                                                                                                                                                               |
| -------- | ----------------------- | ------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Name     | ValueTask&lt;string&gt; | get     | Returns the name of the associated entry.                                                                                                                                                     |
| Kind     | string                  | get     | Returns the type of entry. This is 'file' if the associated entry is a file or 'directory'. It is used to distinguish files from directories when iterating over the contents of a directory. |

#### Methods

| **Name**           | **Parameters**                                                                        | **ReturnType**                                                              | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| ------------------ | ------------------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetName            | CancellationToken cancellationToken                                                   | ValueTask&lt;string&gt;                                                     | Returns the name of the associated entry.                                                                                                                                                                                                                                                                                                                                                                                                                                         |
| IsSameEntry        | IFileHandle other, [CancellationToken cancellationToken = default]                    | ValueTask&lt;bool&gt;                                                       | Compares two file handles to see if the associated entries match.                                                                                                                                                                                                                                                                                                                                                                                                                 |
| GetDirectoryHandle | string name, [bool create = false], [CancellationToken cancellationToken = default]   | ValueTask&lt;IDirectoryHandle&gt;                                           | Returns a Promise fulfilled with a FileSystemDirectoryHandle for a subdirectory with the specified name within the directory handle on which the method is called.                                                                                                                                                                                                                                                                                                                |
| GetFileHandle      | string name, [bool create = false], [CancellationToken cancellationToken = default]   | ValueTask&lt;IFileHandle&gt;                                                | Returns a Promise fulfilled with a FileSystemFileHandle for a file with the specified name, within the directory the method is called.                                                                                                                                                                                                                                                                                                                                            |
| RemoveEntry        | string name, [bool recursive = false], [CancellationToken cancellationToken = default | ValueTask                                                                   | Attempts to asynchronously remove an entry if the directory handle contains a file or directory called the name specified.                                                                                                                                                                                                                                                                                                                                                        |
| Values             | [CancellationToken cancellationToken = default]                                       | ValueTask&lt;(IFileHandle[] fileList, IDirectoryHandle[] directoryList)&gt; | Returns all entries (files, directories) located in this directory.<br/>This method uses the [values()](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemDirectoryHandle/values) Asynchronous iterator method to create these lists. Since returning each entry one by one would be unnecessary slow, all entries are iterated and returned at once.<br/>Do not forget to call *DispseAsync()* on each single item in fileList and directoryList when you done with it. |


<br></br>
### IFile

The *File* interface provides information about files and allows JavaScript in a web page to access their content.

File objects are generally retrieved from a FileList object returned as a result of a user selecting files using the &lt;input&gt; element, or from a drag and drop operation's DataTransfer object.

A File object is a specific kind of Blob, and can be used in any context that a Blob can.In particular, the following APIs accept both Blobs and File objects:
- FileReader
- URL.createObjectURL()
- Window.createImageBitmap() and WorkerGlobalScope.createImageBitmap()
- the body option to fetch()
- XMLHttpRequest.send()

See [Using files from web applications](https://developer.mozilla.org/en-US/docs/Web/API/File_API/Using_files_from_web_applications) for more information and examples.

#### Properties

| **Name**           | **Type**                | get/set | **Description**                                                                                                    |
| ------------------ | ----------------------- | ------- | ------------------------------------------------------------------------------------------------------------------ |
| Name               | ValueTask&lt;string&gt; | get     | Returns the name of the file referenced by the File object.                                                        |
| Size               | ValueTask&lt;long&gt;   | get     | The size, in bytes, of the data contained in the Blob object.                                                      |
| Type               | ValueTask&lt;string&gt; | get     | A string indicating the MIME type of the data contained in the Blob. If the type is unknown, this string is empty. |
| LastModified       | ValueTask&lt;long&gt;   | get     | Returns the last modified time of the file, in millisecond since the UNIX epoch (January 1st, 1970 at Midnight).   |
| WebkitRelativePath | ValueTask&lt;string&gt; | get     | Returns the path the URL of the File is relative to.                                                               |

#### Methods

| **Name**              | **Parameters**                                  | **ReturnType**          | **Description**                                                                                                     |
| --------------------- | ----------------------------------------------- | ----------------------- | ------------------------------------------------------------------------------------------------------------------- |
| GetName               | CancellationToken cancellationToken             | ValueTask&lt;string&gt; | Returns the name of the file referenced by the File object.                                                         |
| GetSize               | CancellationToken cancellationToken             | ValueTask&lt;long&gt;   | The size, in bytes, of the data contained in the Blob object.                                                       |
| GetType               | CancellationToken cancellationToken             | ValueTask&lt;string&gt; | A string indicating the MIME type of the data contained in the Blob. If the type is unknown, this string is empty.  |
| GetLastModified       | CancellationToken cancellationToken             | ValueTask&lt;long&gt;   | Returns the last modified time of the file, in millisecond since the UNIX epoch (January 1st, 1970 at Midnight).    |
| GetWebkitRelativePath | CancellationToken cancellationToken             | ValueTask&lt;string&gt; | Returns the path the URL of the File is relative to.                                                                |
| Text                  | [CancellationToken cancellationToken = default] | ValueTask&lt;string&gt; | Returns a promise that resolves with a string containing the entire contents of the Blob interpreted as UTF-8 text. |


<br></br>
### IWritableFileStream

The *FileSystemWritableFileStream* interface of the File System API is a WritableStream object with additional convenience methods, which operates on a single file on disk.
The interface is accessed through the FileSystemFileHandle.createWritable() method.

#### Properties

| **Name** | **Type**              | get/set | **Description**                                                        |
| -------- | --------------------- | ------- | ---------------------------------------------------------------------- |
| Locked   | ValueTask&lt;bool&gt; | get     | A boolean indicating whether the WritableStream is locked to a writer. |

#### Methods

| **Name**  | **Parameters**                                                           | **ReturnType**        | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| --------- | ------------------------------------------------------------------------ | --------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetLocked | CancellationToken cancellationToken                                      | ValueTask&lt;bool&gt; | A boolean indicating whether the WritableStream is locked to a writer.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| Write     | string data, [CancellationToken cancellationToken = default]             | ValueTask             | Writes content into the file the method is called on, at the current file cursor offset.<br/>No changes are written to the actual file on disk until the stream has been closed. Changes are typically written to a temporary file instead. This method can also be used to seek to a byte point within the stream and truncate to modify the total bytes the file contains.                                                                                                                                                                                                           |
| Write     | byte[] data, [CancellationToken cancellationToken = default]             | ValueTask             | Writes content into the file the method is called on, at the current file cursor offset.<br/>No changes are written to the actual file on disk until the stream has been closed. Changes are typically written to a temporary file instead. This method can also be used to seek to a byte point within the stream and truncate to modify the total bytes the file contains.                                                                                                                                                                                                           |
| Seek      | int position, [CancellationToken cancellationToken = default]            | ValueTask             | Updates the current file cursor offset to the position (in bytes) specified.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| Truncate  | int size, [CancellationToken cancellationToken = default]                | ValueTask             | Resizes the file associated with the stream to be the specified size in bytes.<br/>If the size specified is larger than the current file size the file is padded with 0x00 bytes.<br/>The file cursor is also updated when truncate() is called. If the offset is smaller than the size, it remains unchanged. If the offset is larger than size, the offset is set to that size. This ensures that subsequent writes do not error.<br/>No changes are written to the actual file on disk until the stream has been closed. Changes are typically written to a temporary file instead. |
| Abort     | [object? reason = null], [CancellationToken cancellationToken = default] | ValueTask             | Aborts the stream, signaling that the producer can no longer successfully write to the stream and it is to be immediately moved to an error state, with any queued writes discarded.                                                                                                                                                                                                                                                                                                                                                                                                   |
| Close     | [CancellationToken cancellationToken = default]                          | ValueTask             | Closes the associated stream. All chunks written before this method is called are sent before the returned promise is fulfilled.<br/>This is equivalent to getting a WritableStreamDefaultWriter with getWriter(), calling close() on it.                                                                                                                                                                                                                                                                                                                                              |



<br></br>
### IFileSystemInProcess

The *File System API*
— with extensions provided via the [File System Access API](https://wicg.github.io/file-system-access) to access files on the device file system —
allows read, write and file management capabilities.

See [Relationship to other file-related APIs](https://developer.mozilla.org/en-US/docs/Web/API/File_API#relationship_to_other_file-related_apis) for a comparison between this API,
the [File and Directory Entries API](https://developer.mozilla.org/en-US/docs/Web/API/File_and_Directory_Entries_API),
and the [File API](https://developer.mozilla.org/en-US/docs/Web/API/File_API).

#### Methods

| **Name**                        | **Parameters**                                                                                                                                                                                                                                                                    | **ReturnType**                              | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
| ------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| ShowOpenFilePicker              | [string? id = null], [PickerDialogStartIn startIn = default], [bool excludeAcceptAllOption = false], [(string description, (string MIMEtype, string[] fileExtensions)[] accept)[]? types = null], [CancellationToken cancellationToken = default]                                 | ValueTask&lt;IFileHandleInProcess&gt;       | The *showOpenFilePicker()* method of the Window interface shows a file picker that allows a user to select a file and returns a handle for the file.<br/>When the user clicks on the cancel button or just closes the dialog picker, an Exception is thrown.<br/>This method sets the parameter [multiple](https://developer.mozilla.org/en-US/docs/Web/API/Window/showOpenFilePicker#multiple) to false, so a single fileHandle is returned. When multiple files should be selectable use the method *ShowOpenFilePickerMultipleFiles()*. |
| ShowOpenFilePickerMultipleFiles | [string? id = null], [PickerDialogStartIn startIn = default], [bool excludeAcceptAllOption = false], [(string description, (string MIMEtype, string[] fileExtensions)[] accept)[]? types = null], [CancellationToken cancellationToken = default]                                 | ValueTask&lt;IFileHandleInProcess[]&gt;     | The *showOpenFilePicker()* method of the Window interface shows a file picker that allows a user to select a file and returns a handle for the file.<br/>When the user clicks on the cancel button or just closes the dialog picker, an Exception is thrown.<br/>This method sets the parameter [multiple](https://developer.mozilla.org/en-US/docs/Web/API/Window/showOpenFilePicker#multiple) to true, so a multiple fileHandles can be returned. When only a single file should be selectable use the method *ShowOpenFilePicker()*.    |
| ShowSaveFilePicker              | [string? suggestedName = null], [string? id = null], [PickerDialogStartIn startIn = default], [bool excludeAcceptAllOption = false], [(string description, (string MIMEtype, string[] fileExtensions)[] accept)[]? types = null], [CancellationToken cancellationToken = default] | ValueTask&lt;IFileHandleInProcess&gt;       | The *showSaveFilePicker()* method of the Window interface shows a file picker that allows a user to save a file. Either by selecting an existing file, or entering a name for a new file.<br/>When the user clicks on the cancel button or just closes the dialog picker, an Exception is thrown.                                                                                                                                                                                                                                          |
| ShowDirectoryPicker             | [string mode = "read"], [string? id = null], [PickerDialogStartIn startIn = default], [CancellationToken cancellationToken = default]                                                                                                                                             | ValueTask&lt;IDirectoryHandleInProcess&gt;  | The *showDirectoryPicker()* method of the Window interface displays a directory picker which allows the user to select a directory.<br/>>When the user clicks on the cancel button or just closes the dialog picker, an Exception is thrown.                                                                                                                                                                                                                                                                                               |
| StorageManagerEstimate          | [CancellationToken cancellationToken = default]                                                                                                                                                                                                                                   | ValueTask&lt;(long? usage, long? quota)&gt; | The *estimate()* method of the StorageManager interface asks the Storage Manager for how much storage the current origin takes up (usage), and how much space is available (quota).<br/>This method operates asynchronously, so it returns a Promise which resolves once the information is available. The promise's fulfillment handler is called with an object containing the usage and quota data.                                                                                                                                     |
| StorageManagerPersist           | [CancellationToken cancellationToken = default]                                                                                                                                                                                                                                   | ValueTask&lt;bool&gt;                       | The *persist()* method of the StorageManager interface requests permission to use persistent storage, and returns a Promise that resolves to true if permission is granted and bucket mode is persistent, and false otherwise. The browser may or may not honor the request, depending on browser-specific rules. (For more details, see the guide to [Storage quotas and eviction criteria](https://developer.mozilla.org/en-US/docs/Web/API/Storage_API/Storage_quotas_and_eviction_criteria#does_browser-stored_data_persist).)         |
| StorageManagerPersisted         | [CancellationToken cancellationToken = default]                                                                                                                                                                                                                                   | ValueTask&lt;bool&gt;                       | The *persisted()* method of the StorageManager interface returns a Promise that resolves to true if your site's storage bucket is persistent.                                                                                                                                                                                                                                                                                                                                                                                              |
| StorageManagerGetDirectory      | [CancellationToken cancellationToken = default]                                                                                                                                                                                                                                   | ValueTask&lt;IDirectoryHandleInProcess&gt;  | The *getDirectory()* method of the StorageManager interface is used to obtain a reference to a FileSystemDirectoryHandle object allowing access to a directory and its contents, stored in the origin private file system (OPFS).                                                                                                                                                                                                                                                                                                          |


<br></br>
### IFileHandleInProcess

The *FileSystemFileHandle* interface of the File System API represents a handle to a file system entry. The interface is accessed through the window.showOpenFilePicker() method.

Note that read and write operations depend on file-access permissions that do not persist after a page refresh if no other tabs for that origin remain open. The queryPermission method of the FileSystemHandle interface can be used to verify permission state before accessing a file.

#### Properties

| **Name** | **Type** | get/set | **Description**                                                                                                                                                                               |
| -------- | ---------| ------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Name     | string   | get     | Returns the name of the associated entry.                                                                                                                                                     |
| Kind     | string   | get     | Returns the type of entry. This is 'file' if the associated entry is a file or 'directory'. It is used to distinguish files from directories when iterating over the contents of a directory. |

#### Methods

| **Name**       | **Parameters**                                                                                             | **ReturnType**                                | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
| -------------- | ---------------------------------------------------------------------------------------------------------- | --------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| IsSameEntry    | IFileHandleInProcess other, [CancellationToken cancellationToken = default]                                | ValueTask&lt;bool&gt;                         | Compares two file handles to see if the associated entries match.                                                                                                                                                                                                                                                                                                                                                                                                                   |
| GetFile        | [CancellationToken cancellationToken = default]                                                            | ValueTask&lt;IFileInProcess&gt;               | Returns a Promise which resolves to a File object representing the state on disk of the entry represented by the handle.<br/>If the file on disk changes or is removed after this method is called, the returned File object will likely be no longer readable.                                                                                                                                                                                                                     |
| CreateWritable | [bool keepExistingData = false], [string mode = "siloed"], [CancellationToken cancellationToken = default] | ValueTask&lt;IWritableFileStreamInProcess&gt; | Creates a FileSystemWritableFileStream that can be used to write to a file. The method returns a Promise which resolves to this created stream.<br/> Any changes made through the stream won't be reflected in the file represented by the file handle until the stream has been closed. This is typically implemented by writing data to a temporary file, and only replacing the file represented by file handle with the temporary file when the writable file stream is closed. |


<br></br>
### IDirectoryHandleInProcess

The *FileSystemDirectoryHandle* interface of the File System API provides a handle to a file system directory.

The interface can be accessed via the following methods:
 - [window.showDirectoryPicker()](https://developer.mozilla.org/en-US/docs/Web/API/Window/showDirectoryPicker)
 - [StorageManager.getDirectory()](https://developer.mozilla.org/en-US/docs/Web/API/StorageManager/getDirectory)
 - [DataTransferItem.getAsFileSystemHandle()](https://developer.mozilla.org/en-US/docs/Web/API/DataTransferItem/getAsFileSystemHandle)
 - [FileSystemDirectoryHandle.getDirectoryHandle()](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemDirectoryHandle/getDirectoryHandle)

#### Properties

| **Name** | **Type** | get/set | **Description**                                                                                                                                                                               |
| -------- | -------- | ------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Name     | string   | get     | Returns the name of the associated entry.                                                                                                                                                     |
| Kind     | string   | get     | Returns the type of entry. This is 'file' if the associated entry is a file or 'directory'. It is used to distinguish files from directories when iterating over the contents of a directory. |

#### Methods

| **Name**           | **Parameters**                                                                        | **ReturnType**                                                                                | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| ------------------ | ------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| IsSameEntry        | IFileHandleInProcess other, [CancellationToken cancellationToken = default]           | ValueTask&lt;bool&gt;                                                                         | Compares two file handles to see if the associated entries match.                                                                                                                                                                                                                                                                                                                                                                                                                 |
| GetDirectoryHandle | string name, [bool create = false], [CancellationToken cancellationToken = default]   | ValueTask&lt;IDirectoryHandleInProcess&gt;                                                    | Returns a Promise fulfilled with a FileSystemDirectoryHandle for a subdirectory with the specified name within the directory handle on which the method is called.                                                                                                                                                                                                                                                                                                                |
| GetFileHandle      | string name, [bool create = false], [CancellationToken cancellationToken = default]   | ValueTask&lt;IFileHandleInProcess&gt;                                                         | Returns a Promise fulfilled with a FileSystemFileHandle for a file with the specified name, within the directory the method is called.                                                                                                                                                                                                                                                                                                                                            |
| RemoveEntry        | string name, [bool recursive = false], [CancellationToken cancellationToken = default | ValueTask                                                                                     | Attempts to asynchronously remove an entry if the directory handle contains a file or directory called the name specified.                                                                                                                                                                                                                                                                                                                                                        |
| Values             | [CancellationToken cancellationToken = default]                                       | ValueTask&lt;(IFileHandleInProcess[] fileList, IDirectoryHandleInProcess[] directoryList)&gt; | Returns all entries (files, directories) located in this directory.<br/>This method uses the [values()](https://developer.mozilla.org/en-US/docs/Web/API/FileSystemDirectoryHandle/values) Asynchronous iterator method to create these lists. Since returning each entry one by one would be unnecessary slow, all entries are iterated and returned at once.<br/>Do not forget to call *DispseAsync()* on each single item in fileList and directoryList when you done with it. |


<br></br>
### IFileInProcess

The *File* interface provides information about files and allows JavaScript in a web page to access their content.

File objects are generally retrieved from a FileList object returned as a result of a user selecting files using the &lt;input&gt; element, or from a drag and drop operation's DataTransfer object.

A File object is a specific kind of Blob, and can be used in any context that a Blob can.In particular, the following APIs accept both Blobs and File objects:
- FileReader
- URL.createObjectURL()
- Window.createImageBitmap() and WorkerGlobalScope.createImageBitmap()
- the body option to fetch()
- XMLHttpRequest.send()

See [Using files from web applications](https://developer.mozilla.org/en-US/docs/Web/API/File_API/Using_files_from_web_applications) for more information and examples.

#### Properties

| **Name**           | **Type** | get/set | **Description**                                                                                                    |
| ------------------ | -------- | ------- | ------------------------------------------------------------------------------------------------------------------ |
| Name               | string   | get     | Returns the name of the file referenced by the File object.                                                        |
| Size               | long     | get     | The size, in bytes, of the data contained in the Blob object.                                                      |
| Type               | string   | get     | A string indicating the MIME type of the data contained in the Blob. If the type is unknown, this string is empty. |
| LastModified       | long     | get     | Returns the last modified time of the file, in millisecond since the UNIX epoch (January 1st, 1970 at Midnight).   |
| WebkitRelativePath | string   | get     | Returns the path the URL of the File is relative to.                                                               |

#### Methods

| **Name**              | **Parameters**                                  | **ReturnType**          | **Description**                                                                                                     |
| --------------------- | ----------------------------------------------- | ----------------------- | ------------------------------------------------------------------------------------------------------------------- |
| Text                  | [CancellationToken cancellationToken = default] | ValueTask&lt;string&gt; | Returns a promise that resolves with a string containing the entire contents of the Blob interpreted as UTF-8 text. |


<br></br>
### IWritableFileStreamInProcess

The *FileSystemWritableFileStream* interface of the File System API is a WritableStream object with additional convenience methods, which operates on a single file on disk.
The interface is accessed through the FileSystemFileHandle.createWritable() method.

#### Properties

| **Name** | **Type** | get/set | **Description**                                                        |
| -------- | -------- | ------- | ---------------------------------------------------------------------- |
| Locked   | bool     | get     | A boolean indicating whether the WritableStream is locked to a writer. |

#### Methods

| **Name**  | **Parameters**                                                           | **ReturnType**        | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| --------- | ------------------------------------------------------------------------ | --------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Write     | string data, [CancellationToken cancellationToken = default]             | ValueTask             | Writes content into the file the method is called on, at the current file cursor offset.<br/>No changes are written to the actual file on disk until the stream has been closed. Changes are typically written to a temporary file instead. This method can also be used to seek to a byte point within the stream and truncate to modify the total bytes the file contains.                                                                                                                                                                                                           |
| Write     | byte[] data, [CancellationToken cancellationToken = default]             | ValueTask             | Writes content into the file the method is called on, at the current file cursor offset.<br/>No changes are written to the actual file on disk until the stream has been closed. Changes are typically written to a temporary file instead. This method can also be used to seek to a byte point within the stream and truncate to modify the total bytes the file contains.                                                                                                                                                                                                           |
| Seek      | int position, [CancellationToken cancellationToken = default]            | ValueTask             | Updates the current file cursor offset to the position (in bytes) specified.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| Truncate  | int size, [CancellationToken cancellationToken = default]                | ValueTask             | Resizes the file associated with the stream to be the specified size in bytes.<br/>If the size specified is larger than the current file size the file is padded with 0x00 bytes.<br/>The file cursor is also updated when truncate() is called. If the offset is smaller than the size, it remains unchanged. If the offset is larger than size, the offset is set to that size. This ensures that subsequent writes do not error.<br/>No changes are written to the actual file on disk until the stream has been closed. Changes are typically written to a temporary file instead. |
| Abort     | [object? reason = null], [CancellationToken cancellationToken = default] | ValueTask             | Aborts the stream, signaling that the producer can no longer successfully write to the stream and it is to be immediately moved to an error state, with any queued writes discarded.                                                                                                                                                                                                                                                                                                                                                                                                   |
| Close     | [CancellationToken cancellationToken = default]                          | ValueTask             | Closes the associated stream. All chunks written before this method is called are sent before the returned promise is fulfilled.<br/>This is equivalent to getting a WritableStreamDefaultWriter with getWriter(), calling close() on it.                                                                                                                                                                                                                                                                                                                                              |
