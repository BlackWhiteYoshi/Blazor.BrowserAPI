export class LanguageAPI {
    /**
     * @returns {string}
     */
    static getBrowserLanguage() {
        return navigator.language;
    }

    /**
     * @returns {string}
     */
    static getHtmlLanguage() {
        return document.documentElement.lang;
    }

    /**
     * @param {string} language
     * @returns {string}
     */
    static setHtmlLanguage(language) {
        return document.documentElement.lang = language;
    }
}
