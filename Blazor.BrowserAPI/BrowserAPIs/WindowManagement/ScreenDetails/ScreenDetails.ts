import { ScreenDetailedAPI } from "../ScreenDetailed/ScreenDetailed";
import { blazorInvokeMethod } from "../../../Extensions/blazorExtensions";

export class ScreenDetailsAPI {
    #screenDetails: ScreenDetails;

    constructor(screenDetails: ScreenDetails) {
        this.#screenDetails = screenDetails;
    }


    getCurrentScreen(): ScreenDetailedAPI {
        const currentScreen = this.#screenDetails.currentScreen;
        return new ScreenDetailedAPI(currentScreen);
    }

    getScreens(): ScreenDetailedAPI[] {
        const screens = this.#screenDetails.screens;
        return screens.map(screen => DotNet.createJSObjectReference(new ScreenDetailedAPI(screen)));
    }


    // events


    #eventTrigger: DotNet.DotNetObject;
    #isEventTriggerSync: boolean;

    initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean): void {
        this.#eventTrigger = eventTrigger;
        this.#isEventTriggerSync = isEventTriggerSync;
    }


    // currentscreenchange event

    #oncurrentscreenchange = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeCurrentScreenChange");

    activateOncurrentscreenchange(): void {
        this.#screenDetails.addEventListener("currentscreenchange", this.#oncurrentscreenchange);
    }

    deactivateOncurrentscreenchange(): void {
        this.#screenDetails.removeEventListener("currentscreenchange", this.#oncurrentscreenchange);
    }


    // screenschange event

    #onscreenschange = () => blazorInvokeMethod(this.#eventTrigger, this.#isEventTriggerSync, "InvokeScreensChange"); 

    activateOnscreenschange(): void {
        this.#screenDetails.addEventListener("screenschange", this.#onscreenschange);
    }

    deactivateOnscreenschange(): void {
        this.#screenDetails.removeEventListener("screenschange", this.#onscreenschange);
    }
}
