import { FileHandleAPI } from "../FileHandle/FileHandle";

export class DirectoryHandleAPI {
    #directoryHandle: FileSystemDirectoryHandle;

    public get handle(): FileSystemDirectoryHandle {
        return this.#directoryHandle;
    }

    constructor(directoryHandle: FileSystemDirectoryHandle) {
        this.#directoryHandle = directoryHandle;
    }


    //getKind(): "directory"; // result is always "directory", no need to retrieve this property

    getName(): string {
        return this.#directoryHandle.name;
    }


    isSameEntry(other: DirectoryHandleAPI): Promise<boolean> {
        return this.#directoryHandle.isSameEntry(other.#directoryHandle);
    }

    async getDirectoryHandle(name: string, create: boolean): Promise<DirectoryHandleAPI> {
        const directoryHandle: FileSystemDirectoryHandle = await this.#directoryHandle.getDirectoryHandle(name, { create });
        return new DirectoryHandleAPI(directoryHandle);
    }

    async getFileHandle(name: string, create: boolean): Promise<FileHandleAPI> {
        const fileHandle: FileSystemFileHandle = await this.#directoryHandle.getFileHandle(name, { create });
        return new FileHandleAPI(fileHandle);
    }

    removeEntry(name: string, recursive: boolean): Promise<void> {
        return this.#directoryHandle.removeEntry(name, { recursive });
    }

    async values(): Promise<{ fileList: FileHandleAPI[], directoryList: DirectoryHandleAPI[] }> {
        const fileList: FileHandleAPI[] = [];
        const directoryList: DirectoryHandleAPI[] = [];

        for await (const entry of this.#directoryHandle.values())
            if (entry instanceof FileSystemFileHandle)
                fileList.push(DotNet.createJSObjectReference(new FileHandleAPI(entry)));
            else
                directoryList.push(DotNet.createJSObjectReference(new DirectoryHandleAPI(entry)));

        return { fileList, directoryList };
    }
}
