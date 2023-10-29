// @ts-check


/**
 * @param {string} text
 * @returns {Promise<void>}
 */
export function clipboardWriteText(text) {
    return navigator.clipboard.writeText(text);
}

/**
 * @returns {Promise<string>}
 */
export function clipboardReadText() {
    return navigator.clipboard.readText();
}
