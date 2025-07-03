export class LanguageAPI {
    static getBrowserLanguage(): string {
        return navigator.language;
    }

    static getBrowserLanguages(): readonly string[] {
        return navigator.languages;
    }

    static getHtmlLanguage(): string {
        return document.documentElement.lang;
    }

    static setHtmlLanguage(language: string): string {
        return document.documentElement.lang = language;
    }
}
