import { DirectoryHandleAPI } from "./DirectoryHandle/DirectoryHandle";
import { FileHandleAPI } from "./FileHandle/FileHandle";

export class FileSystemAPI {
    static async showOpenFilePicker(id: string | null, startIn: FileHandleAPI | DirectoryHandleAPI | WellKnownDirectory | null, excludeAcceptAllOption: boolean, types: { key: string, value: { key: string, value: string[] }[] }[] | null): Promise<FileHandleAPI> {
        const options: OpenFilePickerOptions = {
            id: id ?? undefined,
            startIn: this.#mapStartIn(startIn),
            excludeAcceptAllOption: excludeAcceptAllOption,
            types: FileSystemAPI.#mapTypes(types),
            multiple: false
        }
        const [fileHandle] = await showOpenFilePicker(options);
        return new FileHandleAPI(fileHandle);
    }

    static async showOpenFilePickerMultipleFiles(id: string | null, startIn: FileHandleAPI | DirectoryHandleAPI | WellKnownDirectory | null, excludeAcceptAllOption: boolean, types: { key: string, value: { key: string, value: string[]; }[]; }[] | null): Promise<FileHandleAPI[]> {
        const options: OpenFilePickerOptions = {
            id: id ?? undefined,
            startIn: this.#mapStartIn(startIn),
            excludeAcceptAllOption: excludeAcceptAllOption,
            types: FileSystemAPI.#mapTypes(types),
            multiple: true
        }
        const fileHandleList = await showOpenFilePicker(options);
        return fileHandleList.map((fileHandle: FileSystemFileHandle) => DotNet.createJSObjectReference(new FileHandleAPI(fileHandle)));
    }

    static async showSaveFilePicker(suggestedName: string | null, id: string | null, startIn: FileHandleAPI | DirectoryHandleAPI | WellKnownDirectory | null, excludeAcceptAllOption: boolean, types: { key: string, value: { key: string, value: string[]; }[]; }[] | null): Promise<FileHandleAPI> {
        const options: SaveFilePickerOptions = {
            suggestedName: suggestedName ?? undefined,
            id: id ?? undefined,
            startIn: this.#mapStartIn(startIn),
            excludeAcceptAllOption: excludeAcceptAllOption,
            types: FileSystemAPI.#mapTypes(types)
        }
        const fileHandle = await showSaveFilePicker(options);
        return new FileHandleAPI(fileHandle);
    }

    static async showDirectoryPicker(mode: FileSystemPermissionMode, id: string | null, startIn: FileHandleAPI | DirectoryHandleAPI | WellKnownDirectory | null): Promise<DirectoryHandleAPI> {
        const options: DirectoryPickerOptions = {
            mode: mode,
            id: id ?? undefined,
            startIn: this.#mapStartIn(startIn)
        };
        const directoryHandle = await showDirectoryPicker(options);
        return new DirectoryHandleAPI(directoryHandle);
    }


    static storageManagerEstimate(): Promise<StorageEstimate> {
        return navigator.storage.estimate();
    }

    static storageManagerPersist(): Promise<boolean> {
        return navigator.storage.persist();
    }

    static storageManagerPersisted(): Promise<boolean> {
        return navigator.storage.persisted();
    }

    static async storageManagerGetDirectory(): Promise<DirectoryHandleAPI> {
        const directoryHandle = await navigator.storage.getDirectory()
        return new DirectoryHandleAPI(directoryHandle);
    }



    static #mapTypes(types: { key: string, value: { key: string, value: string[]; }[]; }[] | null): FilePickerAcceptType[] | undefined {
        return types?.map(entry => ({
            description: entry.key,
            accept: Object.fromEntries(entry.value.map(mimeType => [<MIMEType>mimeType.key, <FileExtension[]>mimeType.value]))
        }));
    }

    static #mapStartIn(startIn: FileHandleAPI | DirectoryHandleAPI | WellKnownDirectory | null): FileSystemHandle | WellKnownDirectory | undefined {
        switch (startIn) {
            case null:
                return undefined;
            case "desktop":
            case "documents":
            case "downloads":
            case "music":
            case "pictures":
            case "videos":
                return startIn;
            default:
                return startIn.handle;
        }
    }
}
