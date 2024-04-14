/**
 * @returns {string}
 */
export function languageBrowser() {
    return navigator.language;
}

/**
 * @returns {string}
 */
export function languageHtmlRead() {
    return document.documentElement.lang;
}

/**
 * @param {string} language
 * @returns {string}
 */
export function languageHtmlWrite(language) {
    return document.documentElement.lang = language;
}
