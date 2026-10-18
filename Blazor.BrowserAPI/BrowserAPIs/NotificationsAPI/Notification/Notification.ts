import { BlazorInvoke } from "../../../Extensions/blazorExtensions";

export class NotificationAPI {
    private notification: Notification;

    public constructor(notification: Notification) {
        this.notification = notification;
    }


    public getActions(): NotificationAction[] {
        return this.notification.actions;
    }

    public getBadge(): string {
        return this.notification.badge;
    }

    public getBody(): string {
        return this.notification.body;
    }

    public getData(): any {
        return this.notification.data;
    }

    public getDir(): NotificationDirection {
        return this.notification.dir;
    }

    public getIcon(): string {
        return this.notification.icon;
    }

    public getImage(): string {
        return this.notification.image;
    }

    public getLang(): string {
        return this.notification.lang;
    }

    public getNavigate(): string {
        return <string>this.notification.navigate;
    }

    public getRenotify(): boolean {
        return this.notification.renotify;
    }

    public getRequireInteraction(): boolean {
        return this.notification.requireInteraction;
    }

    public getSilent(): 0 | 1 | 2 { // 0 = false, 1 = true, 2 = null
        switch (this.notification.silent) {
            case false: return 0;
            case true: return 1;
            case null: return 2;
        }
    }

    public getTag(): string {
        return this.notification.tag;
    }

    public getTimestamp(): number {
        return this.notification.timestamp;
    }

    public getTitle(): string {
        return this.notification.title;
    }

    public getVibrate(): number[] {
        return this.notification.vibrate;
    }


    public close(): void {
        this.notification.close();
    }



    // events


    private eventTrigger!: DotNet.DotNetObject;

    public initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.eventTrigger = eventTrigger;
    }


    // click event

    private onclick = () => BlazorInvoke.method(this.eventTrigger, "InvokeClick");

    public activateOnclick(): void {
        this.notification.addEventListener("click", this.onclick);
    }

    public deactivateOnclick(): void {
        this.notification.removeEventListener("click", this.onclick);
    }


    // close event

    private onclose = () => BlazorInvoke.method(this.eventTrigger, "InvokeClose");

    public activateOnclose(): void {
        this.notification.addEventListener("close", this.onclose);
    }

    public deactivateOnclose(): void {
        this.notification.removeEventListener("close", this.onclose);
    }


    // error event

    private onerror = (event: Event) => BlazorInvoke.method(this.eventTrigger, "InvokeError", event);

    public activateOnerror(): void {
        this.notification.addEventListener("error", this.onerror);
    }

    public deactivateOnerror(): void {
        this.notification.removeEventListener("error", this.onerror);
    }


    // show event

    private onshow = () => BlazorInvoke.method(this.eventTrigger, "InvokeShow");

    public activateOnshow(): void {
        this.notification.addEventListener("show", this.onshow);
    }

    public deactivateOnshow(): void {
        this.notification.removeEventListener("show", this.onshow);
    }
}
