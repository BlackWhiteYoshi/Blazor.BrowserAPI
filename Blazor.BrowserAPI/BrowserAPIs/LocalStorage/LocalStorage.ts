export class LocalStorageAPI {
    static count(): number {
        return localStorage.length;
    }

    static key(index: number): string | null {
        return localStorage.key(index);
    }

    static getItem(key: string): string | null {
        return localStorage.getItem(key);
    }

    static setItem(key: string, value: string) {
        localStorage.setItem(key, value);
    }

    static removeItem(key: string) {
        localStorage.removeItem(key);
    }

    static clear() {
        localStorage.clear();
    }
}
