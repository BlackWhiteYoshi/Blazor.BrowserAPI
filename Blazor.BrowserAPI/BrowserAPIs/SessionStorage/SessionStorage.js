/**
 * @returns {number}
 */
export function sessionStorageLength() {
    return sessionStorage.length;
}

/**
 * @param {number} index
 * @returns {string | null}
 */
export function sessionStorageKey(index) {
    return sessionStorage.key(index);
}

/**
 * @param {string} key
 * @returns {string | null}
 */
export function sessionStorageGetItem(key) {
    return sessionStorage.getItem(key);
}

/**
 * @param {string} key
 * @param {string} value
 */
export function sessionStorageSetItem(key, value) {
    sessionStorage.setItem(key, value);
}

/**
 * @param {string} key
 */
export function sessionStorageRemoveItem(key) {
    sessionStorage.removeItem(key);
}

/**
 */
export function sessionStorageClear() {
    sessionStorage.clear();
}
