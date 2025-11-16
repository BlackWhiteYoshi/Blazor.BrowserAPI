import { FileHandleAPI } from "../FileHandle/FileHandle";

export class DirectoryHandleAPI {
    private _handle: FileSystemDirectoryHandle;
    public get handle(): FileSystemDirectoryHandle {
        return this._handle;
    }

    public constructor(directoryHandle: FileSystemDirectoryHandle) {
        this._handle = directoryHandle;
    }


    //public getKind(): "directory"; // result is always "directory", no need to retrieve this property

    public getName(): string {
        return this.handle.name;
    }


    public isSameEntry(other: DirectoryHandleAPI): Promise<boolean> {
        return this.handle.isSameEntry(other.handle);
    }

    public async getDirectoryHandle(name: string, create: boolean): Promise<DirectoryHandleAPI> {
        const directoryHandle: FileSystemDirectoryHandle = await this.handle.getDirectoryHandle(name, { create });
        return new DirectoryHandleAPI(directoryHandle);
    }

    public async getFileHandle(name: string, create: boolean): Promise<FileHandleAPI> {
        const fileHandle: FileSystemFileHandle = await this.handle.getFileHandle(name, { create });
        return new FileHandleAPI(fileHandle);
    }

    public removeEntry(name: string, recursive: boolean): Promise<void> {
        return this.handle.removeEntry(name, { recursive });
    }

    public async values(): Promise<{ fileList: FileHandleAPI[], directoryList: DirectoryHandleAPI[] }> {
        const fileList: FileHandleAPI[] = [];
        const directoryList: DirectoryHandleAPI[] = [];

        for await (const entry of this.handle.values())
            if (entry instanceof FileSystemFileHandle)
                fileList.push(DotNet.createJSObjectReference(new FileHandleAPI(entry)));
            else
                directoryList.push(DotNet.createJSObjectReference(new DirectoryHandleAPI(entry)));

        return { fileList, directoryList };
    }
}
