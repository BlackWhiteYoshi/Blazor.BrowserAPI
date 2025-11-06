export class FileAPI {
    private _file: File;
    public get file() {
        return this._file;
    }

    public constructor(file: File) {
        this._file = file;
    }


    public getName(): string {
        return this.file.name;
    }

    public getSize(): number {
        return this.file.size;
    }

    public getType(): string {
        return this.file.type;
    }

    public getLastModified(): number {
        return this.file.lastModified;
    }

    public getWebkitRelativePath(): string {
        return this.file.webkitRelativePath;
    }


    public text(): Promise<string> {
        return this.file.text();
    }
}
