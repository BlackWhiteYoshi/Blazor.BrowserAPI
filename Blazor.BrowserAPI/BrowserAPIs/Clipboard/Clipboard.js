export class ClipboardAPI {
    /**
     * @param {string} text
     * @returns {Promise<void>}
     */
    static writeText(text) {
        return navigator.clipboard.writeText(text);
    }

    /**
     * @returns {Promise<string>}
     */
    static readText() {
        return navigator.clipboard.readText();
    }
}
