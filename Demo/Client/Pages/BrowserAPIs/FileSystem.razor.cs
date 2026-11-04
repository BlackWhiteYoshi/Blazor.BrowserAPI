using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BrowserAPI.Demo.Client;

public sealed partial class FileSystem : ComponentBase {
    [Inject]
    public required IFileSystem PFileSystem { private get; init; }

    private string textAreaContent = "BlackWhiteYoshi";


    private async Task WriteTextAreaToFile() {
        try {
            await using IFileHandle fileHandle = await PFileSystem.ShowSaveFilePicker(suggestedName: "file.txt", startIn: PickerDialogStartIn.Documents, types: [("TXT", [("text/plain", [".txt"])])]);
            await using IWritableFileStream fileStream = await fileHandle.CreateWritable();
            await fileStream.Write(textAreaContent);
            await fileStream.Close();
        }
        catch(JSException jsException) {
            if (!jsException.Message.Contains("abort") && !jsException.Message.Contains("cancel"))
                throw;
        }
    }

    private async Task ReadFromFileToTextArea() {
        try {
            await using IFileHandle fileHandle = await PFileSystem.ShowOpenFilePicker(startIn: PickerDialogStartIn.Documents, types: [("TXT", [("text/plain", [".txt"])])]);
            await using IFile file = await fileHandle.GetFile();
            textAreaContent = await file.Text();
        }
        catch(JSException jsException) {
            if (!jsException.Message.Contains("abort") && !jsException.Message.Contains("cancel"))
                throw;
        }
    }

    private async Task RemoveContentOfDirectory() {
        try {
            await using IDirectoryHandle directoryHandle = await PFileSystem.ShowDirectoryPicker(startIn: PickerDialogStartIn.Downloads);
            (IFileHandle[] fileHandleList, IDirectoryHandle[] directoryHandleList) = await directoryHandle.Values();

            foreach (IFileHandle fileHandle in fileHandleList)
                await directoryHandle.RemoveEntry(await fileHandle.Name);
            foreach (IDirectoryHandle subdirectoryHandle in directoryHandleList)
                await directoryHandle.RemoveEntry(await subdirectoryHandle.Name, recursive: true);

            await (fileHandleList, directoryHandleList).DisposeAsync();
        }
        catch(JSException jsException) {
            if (!jsException.Message.Contains("abort") && !jsException.Message.Contains("cancel"))
                throw;
        }
    }
}
