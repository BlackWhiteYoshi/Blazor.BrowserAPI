export class WritableFileStreamAPI {
    #writableFileStream: FileSystemWritableFileStream;

    constructor(writableFileStream: FileSystemWritableFileStream) {
        this.#writableFileStream = writableFileStream;
    }


    getLocked(): boolean {
        return this.#writableFileStream.locked;
    }


    write(data: string | Uint8Array): Promise<void> {
        return this.#writableFileStream.write(data);
    }

    seek(position: number): Promise<void> {
        return this.#writableFileStream.seek(position);
    }

    truncate(size: number): Promise<void> {
        return this.#writableFileStream.truncate(size);
    }

    abort(reason?: any): Promise<void> {
        return this.#writableFileStream.abort(reason);
    }

    close(): Promise<void> {
        return this.#writableFileStream.close();
    }
}
