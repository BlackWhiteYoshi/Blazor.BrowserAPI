// @ts-check


/**
 * @returns {number}
 */
export function localStorageLength() {
    return localStorage.length;
}

/**
 * @param {number} index
 * @returns {string | null}
 */
export function localStorageKey(index) {
    return localStorage.key(index);
}

/**
 * @param {string} key
 * @returns {string | null}
 */
export function localStorageGetItem(key) {
    return localStorage.getItem(key);
}

/**
 * @param {string} key
 * @param {string} value
 */
export function localStorageSetItem(key, value) {
    localStorage.setItem(key, value);
}

/**
 * @param {string} key
 */
export function localStorageRemoveItem(key) {
    localStorage.removeItem(key);
}

/**
 */
export function localStorageClear() {
    localStorage.clear();
}
