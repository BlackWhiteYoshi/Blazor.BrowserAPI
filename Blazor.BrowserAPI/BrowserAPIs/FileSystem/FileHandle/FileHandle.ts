import { FileAPI } from "../File/File";
import { WritableFileStreamAPI } from "../WritableFileStream/WritableFileStream";

export class FileHandleAPI {
    #fileHandle: FileSystemFileHandle;

    public get handle() {
        return this.#fileHandle;
    }

    constructor(fileHandle: FileSystemFileHandle) {
        this.#fileHandle = fileHandle;
    }


    //getKind(): "file"; // result is always "file", no need to retrieve this property

    getName(): string {
        return this.#fileHandle.name;
    }


    isSameEntry(other: FileHandleAPI): Promise<boolean> {
        return this.#fileHandle.isSameEntry(other.#fileHandle);
    }

    async getFile(): Promise<FileAPI> {
        const file = await this.#fileHandle.getFile();
        return new FileAPI(file);
    }

    async createWritable(keepExistingData: boolean, mode: string): Promise<WritableFileStreamAPI> {
        const writableFileStream = await this.#fileHandle.createWritable(<FileSystemCreateWritableOptions>{ keepExistingData, mode });
        return new WritableFileStreamAPI(writableFileStream);
    }
}
