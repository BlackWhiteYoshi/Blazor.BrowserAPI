export class ClipboardAPI {
    public static writeText(text: string): Promise<void> {
        return navigator.clipboard.writeText(text);
    }

    public static readText(): Promise<string> {
        return navigator.clipboard.readText();
    }
}
