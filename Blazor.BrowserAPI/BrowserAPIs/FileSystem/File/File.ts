export class FileAPI {
    #file: File;

    constructor(file: File) {
        this.#file = file;
    }


    getName(): string {
        return this.#file.name;
    }

    getSize(): number {
        return this.#file.size;
    }

    getType(): string {
        return this.#file.type;
    }

    getLastModified(): number {
        return this.#file.lastModified;
    }

    getWebkitRelativePath(): string {
        return this.#file.webkitRelativePath;
    }


    text(): Promise<string> {
        return this.#file.text();
    }
}
