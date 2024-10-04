export class LocalStorageAPI {
    /**
     * @returns {number}
     */
    static count() {
        return localStorage.length;
    }

    /**
     * @param {number} index
     * @returns {string | null}
     */
    static key(index) {
        return localStorage.key(index);
    }

    /**
     * @param {string} key
     * @returns {string | null}
     */
    static getItem(key) {
        return localStorage.getItem(key);
    }

    /**
     * @param {string} key
     * @param {string} value
     */
    static setItem(key, value) {
        localStorage.setItem(key, value);
    }

    /**
     * @param {string} key
     */
    static removeItem(key) {
        localStorage.removeItem(key);
    }

    /**
     */
    static clear() {
        localStorage.clear();
    }
}
