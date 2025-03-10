export class ClipboardAPI {
    static writeText(text: string): Promise<void> {
        return navigator.clipboard.writeText(text);
    }

    static readText(): Promise<string> {
        return navigator.clipboard.readText();
    }
}
