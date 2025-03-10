export class CookieStorageAPI {
    static getAllCookies(): string {
        return document.cookie;
    }

    static count(): number {
        if (document.cookie === "")
            return 0;

        let cookies = document.cookie.split(';');
        return cookies.length;
    }

    static key(index: number): string | null {
        if (index < 0)
            return null;

        let cookies = document.cookie.split(';');
        if (index >= cookies.length)
            return null;

        let cookie = cookies[index];
        let key = cookie.split('=')[0];
        return key.trim();
    }

    static getCookie(key: string): string | null {
        let cookies = document.cookie.split(';');
        for (let i = 0; i < cookies.length; i++) {
            let keyValuePair = cookies[i].split('=');
            let cookieKey = keyValuePair[0];
            let cookieValue = keyValuePair[1];
            if (cookieKey.trim() === key)
                return cookieValue.trim();
        }

        return null;
    }

    static setCookie(key: string, value: string, expires: number | null, path: string, sameSite: string, secure: boolean) {
        let cookie = `${key}=${value}`;

        if (expires !== null)
            cookie += `;expires=${new Date(Date.now() + expires * 1000).toUTCString()}`;
        cookie += `;path=${path}`;
        cookie += `;SameSite=${sameSite}`;
        if (secure)
            cookie += ";Secure";

        document.cookie = cookie;
    }

    static removeCookie(key: string) {
        document.cookie = `${key}=;expires=Thu, 01 Jan 1970 00:00:00 GMT`;
    }

    static clear() {
        let cookies = document.cookie.split(';');
        for (let i = 0; i < cookies.length; i++) {
            let key = cookies[i].split('=')[0];
            document.cookie = `${key}=;expires=Thu, 01 Jan 1970 00:00:00 GMT`;
        }
    }
}
