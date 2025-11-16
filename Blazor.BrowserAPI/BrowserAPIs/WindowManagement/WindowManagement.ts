import { ScreenDetailsAPI } from "./ScreenDetails/ScreenDetails";

export class WindowManagementAPI {
    public static async getScreenDetails(): Promise<ScreenDetailsAPI> {
        const screenDetails = await window.getScreenDetails();
        return new ScreenDetailsAPI(screenDetails);
    }

    public static open(url?: string | URL, target?: string, features?: string): void {
        window.open(url, target, features);
    }
}
