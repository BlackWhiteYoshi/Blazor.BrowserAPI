export class LanguageAPI {
    public static getBrowserLanguage(): string {
        return navigator.language;
    }

    public static getBrowserLanguages(): readonly string[] {
        return navigator.languages;
    }

    public static getHtmlLanguage(): string {
        return document.documentElement.lang;
    }

    public static setHtmlLanguage(language: string): string {
        return document.documentElement.lang = language;
    }
}
