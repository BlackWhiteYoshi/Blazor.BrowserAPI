export class SessionStorageAPI {
    /**
     * @returns {number}
     */
    static count() {
        return sessionStorage.length;
    }

    /**
     * @param {number} index
     * @returns {string | null}
     */
    static key(index) {
        return sessionStorage.key(index);
    }

    /**
     * @param {string} key
     * @returns {string | null}
     */
    static getItem(key) {
        return sessionStorage.getItem(key);
    }

    /**
     * @param {string} key
     * @param {string} value
     */
    static setItem(key, value) {
        sessionStorage.setItem(key, value);
    }

    /**
     * @param {string} key
     */
    static removeItem(key) {
        sessionStorage.removeItem(key);
    }

    /**
     */
    static clear() {
        sessionStorage.clear();
    }
}
