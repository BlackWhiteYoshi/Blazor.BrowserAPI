export class LanguageAPI {
    static getBrowserLanguage(): string {
        return navigator.language;
    }

    static getHtmlLanguage(): string {
        return document.documentElement.lang;
    }

    static setHtmlLanguage(language: string): string {
        return document.documentElement.lang = language;
    }
}
