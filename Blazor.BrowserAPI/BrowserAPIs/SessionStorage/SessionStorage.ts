export class SessionStorageAPI {
    static count(): number {
        return sessionStorage.length;
    }

    static key(index: number): string | null {
        return sessionStorage.key(index);
    }

    static getItem(key: string): string | null {
        return sessionStorage.getItem(key);
    }

    static setItem(key: string, value: string): void {
        sessionStorage.setItem(key, value);
    }

    static removeItem(key: string): void {
        sessionStorage.removeItem(key);
    }

    static clear(): void {
        sessionStorage.clear();
    }
}
