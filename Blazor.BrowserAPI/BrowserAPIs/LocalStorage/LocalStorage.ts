export class LocalStorageAPI {
    public static count(): number {
        return localStorage.length;
    }

    public static key(index: number): string | null {
        return localStorage.key(index);
    }

    public static getItem(key: string): string | null {
        return localStorage.getItem(key);
    }

    public static setItem(key: string, value: string): void {
        localStorage.setItem(key, value);
    }

    public static removeItem(key: string): void {
        localStorage.removeItem(key);
    }

    public static clear(): void {
        localStorage.clear();
    }
}
