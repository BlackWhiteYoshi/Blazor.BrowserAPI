/**
 * @returns {string}
 */
export function LanguageBrowser() {
    return navigator.language;
}

/**
 * @returns string
 */
export function LanguageHtmlRead() {
    return document.documentElement.lang;
}

/**
 * @param {string} language
 * @returns string
 */
export function LanguageHtmlWrite(language) {
    return document.documentElement.lang = language;
}
