import { FileAPI } from "../File/File";
import { WritableFileStreamAPI } from "../WritableFileStream/WritableFileStream";

export class FileHandleAPI {
    private _handle: FileSystemFileHandle;
    public get handle(): FileSystemFileHandle {
        return this._handle;
    }

    public constructor(fileHandle: FileSystemFileHandle) {
        this._handle = fileHandle;
    }


    //public getKind(): "file"; // result is always "file", no need to retrieve this property

    public getName(): string {
        return this.handle.name;
    }


    public isSameEntry(other: FileHandleAPI): Promise<boolean> {
        return this.handle.isSameEntry(other.handle);
    }

    public async getFile(): Promise<FileAPI> {
        const file = await this.handle.getFile();
        return new FileAPI(file);
    }

    public async createWritable(keepExistingData: boolean, mode: string): Promise<WritableFileStreamAPI> {
        const writableFileStream = await this.handle.createWritable(<FileSystemCreateWritableOptions>{ keepExistingData, mode });
        return new WritableFileStreamAPI(writableFileStream);
    }
}
