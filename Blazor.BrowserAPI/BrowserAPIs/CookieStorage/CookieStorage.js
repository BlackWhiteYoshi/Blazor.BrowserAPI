export class CookieStorageAPI {
    /**
     * @returns {string}
     */
    static getAllCookies() {
        return document.cookie;
    }

    /**
     * @returns {number}
     */
    static count() {
        if (document.cookie === "")
            return 0;

        let cookies = document.cookie.split(';');
        return cookies.length;
    }

    /**
     * @param {number} index
     * @returns {string | null}
     */
    static key(index) {
        if (index < 0)
            return null;

        let cookies = document.cookie.split(';');
        if (index >= cookies.length)
            return null;

        let cookie = cookies[index];
        let key = cookie.split('=')[0];
        return key.trim();
    }

    /**
     * @param {string} key
     * @returns {string | null}
     */
    static getCookie(key) {
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

    /**
     * @param {string} key
     * @param {string} value
     * @param {number | null} expires
     * @param {string} path
     * @param {string} sameSite
     * @param {boolean} secure
     */
    static setCookie(key, value, expires, path, sameSite, secure) {
        let cookie = `${key}=${value}`;

        if (expires !== null)
            cookie += `;expires=${new Date(Date.now() + expires * 1000).toUTCString()}`;
        cookie += `;path=${path}`;
        cookie += `;SameSite=${sameSite}`;
        if (secure)
            cookie += ";Secure";

        document.cookie = cookie;
    }

    /**
     * @param {string} key
     */
    static removeCookie(key) {
        document.cookie = `${key}=;expires=Thu, 01 Jan 1970 00:00:00 GMT`;
    }

    /**
     */
    static clear() {
        let cookies = document.cookie.split(';');
        for (let i = 0; i < cookies.length; i++) {
            let key = cookies[i].split('=')[0];
            document.cookie = `${key}=;expires=Thu, 01 Jan 1970 00:00:00 GMT`;
        }
    }
}
