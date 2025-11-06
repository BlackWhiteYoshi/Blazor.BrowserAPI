export class WritableFileStreamAPI {
    private writableFileStream: FileSystemWritableFileStream;

    public constructor(writableFileStream: FileSystemWritableFileStream) {
        this.writableFileStream = writableFileStream;
    }


    public getLocked(): boolean {
        return this.writableFileStream.locked;
    }


    public write(data: string | Uint8Array): Promise<void> {
        return this.writableFileStream.write(data);
    }

    public seek(position: number): Promise<void> {
        return this.writableFileStream.seek(position);
    }

    public truncate(size: number): Promise<void> {
        return this.writableFileStream.truncate(size);
    }

    public abort(reason?: any): Promise<void> {
        return this.writableFileStream.abort(reason);
    }

    public close(): Promise<void> {
        return this.writableFileStream.close();
    }
}
