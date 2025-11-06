export class SessionStorageAPI {
    public static count(): number {
        return sessionStorage.length;
    }

    public static key(index: number): string | null {
        return sessionStorage.key(index);
    }

    public static getItem(key: string): string | null {
        return sessionStorage.getItem(key);
    }

    public static setItem(key: string, value: string): void {
        sessionStorage.setItem(key, value);
    }

    public static removeItem(key: string): void {
        sessionStorage.removeItem(key);
    }

    public static clear(): void {
        sessionStorage.clear();
    }
}
