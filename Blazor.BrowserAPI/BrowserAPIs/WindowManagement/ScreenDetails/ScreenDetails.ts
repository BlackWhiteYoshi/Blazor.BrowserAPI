import { ScreenDetailedAPI } from "../ScreenDetailed/ScreenDetailed";
import { BlazorInvoke } from "../../../Extensions/blazorExtensions";

export class ScreenDetailsAPI {
    private screenDetails: ScreenDetails;

    public constructor(screenDetails: ScreenDetails) {
        this.screenDetails = screenDetails;
    }


    public getCurrentScreen(): ScreenDetailedAPI {
        const currentScreen = this.screenDetails.currentScreen;
        return new ScreenDetailedAPI(currentScreen);
    }

    public getScreens(): ScreenDetailedAPI[] {
        const screens = this.screenDetails.screens;
        return screens.map(screen => DotNet.createJSObjectReference(new ScreenDetailedAPI(screen)));
    }


    // events


    private eventTrigger: DotNet.DotNetObject;

    public initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.eventTrigger = eventTrigger;
    }


    // currentscreenchange event

    private oncurrentscreenchange = () => BlazorInvoke.method(this.eventTrigger, "InvokeCurrentScreenChange");

    public activateOncurrentscreenchange(): void {
        this.screenDetails.addEventListener("currentscreenchange", this.oncurrentscreenchange);
    }

    public deactivateOncurrentscreenchange(): void {
        this.screenDetails.removeEventListener("currentscreenchange", this.oncurrentscreenchange);
    }


    // screenschange event

    private onscreenschange = () => BlazorInvoke.method(this.eventTrigger, "InvokeScreensChange");

    public activateOnscreenschange(): void {
        this.screenDetails.addEventListener("screenschange", this.onscreenschange);
    }

    public deactivateOnscreenschange(): void {
        this.screenDetails.removeEventListener("screenschange", this.onscreenschange);
    }
}
