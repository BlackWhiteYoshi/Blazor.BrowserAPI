import { ServiceWorkerAPI } from "../ServiceWorker/ServiceWorker";
import { NotificationAPI } from "../../NotificationsAPI/Notification/Notification";
import { BlazorInvoke } from "../../../Extensions/blazorExtensions";

export class ServiceWorkerRegistrationAPI {
    private serviceWorkerRegistration: ServiceWorkerRegistration;

    public constructor(serviceWorkerRegistration: ServiceWorkerRegistration) {
        this.serviceWorkerRegistration = serviceWorkerRegistration;
    }


    public getActive(): [ServiceWorkerAPI] | [null] {
        const serviceWorker = this.serviceWorkerRegistration.active;
        if (serviceWorker)
            return [DotNet.createJSObjectReference(new ServiceWorkerAPI(serviceWorker))];
        else
            return [null];
    }

    public getInstalling(): [ServiceWorkerAPI] | [null] {
        const serviceWorker = this.serviceWorkerRegistration.installing;
        if (serviceWorker)
            return [DotNet.createJSObjectReference(new ServiceWorkerAPI(serviceWorker))];
        else
            return [null];
    }

    public getWaiting(): [ServiceWorkerAPI] | [null] {
        const serviceWorker = this.serviceWorkerRegistration.waiting;
        if (serviceWorker)
            return [DotNet.createJSObjectReference(new ServiceWorkerAPI(serviceWorker))];
        else
            return [null];
    }


    public getScope(): string {
        return this.serviceWorkerRegistration.scope;
    }

    public getUpdateViaCache(): string {
        return this.serviceWorkerRegistration.updateViaCache;
    }


    public async update(): Promise<ServiceWorkerRegistrationAPI> {
        // wrong return type definition for update(): expected ServiceWorkerRegistration, actually void
        const updatedServiceWorkerRegistration = <ServiceWorkerRegistration><unknown>await this.serviceWorkerRegistration.update();
        return new ServiceWorkerRegistrationAPI(updatedServiceWorkerRegistration);
    }

    public unregister(): Promise<boolean> {
        return this.serviceWorkerRegistration.unregister();
    }

    public showNotification(title: string, actions: NotificationAction[] | null, badge: string | null, body: string, data: object | null, dir: NotificationDirection, icon: string | null, image: string | null, lang: string, navigate: string | null, renotify: boolean, requireInteraction: boolean, silent: boolean | null, tag: string, timestamp: number | null, vibrate: number[] | null): Promise<void> {
        if (actions !== null)
            for (const action of actions) {
                if (action.icon === null)
                    action.icon = undefined;
                if (action.navigate === null)
                    action.navigate = undefined;
            }
        const options = {
            ...(actions !== null && { actions }),
            ...(badge !== null && { badge }),
            body,
            data,
            dir,
            ...(icon !== null && { icon }),
            ...(image !== null && { image }),
            lang,
            ...(navigate !== null && { navigate }),
            renotify,
            requireInteraction,
            silent,
            tag,
            ...(timestamp !== null && { timestamp }),
            ...(vibrate !== null && { vibrate })
        };
        return this.serviceWorkerRegistration.showNotification(title, options);
    }

    public async getNotifications(tag: string | null): Promise<NotificationAPI[]> {
        const notifications = tag === null
            ? await this.serviceWorkerRegistration.getNotifications()
            : await this.serviceWorkerRegistration.getNotifications({ tag });
        return notifications.map<NotificationAPI>(notification => DotNet.createJSObjectReference(new NotificationAPI(notification)));
    }


    // events


    private eventTrigger!: DotNet.DotNetObject;

    public initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.eventTrigger = eventTrigger;
    }


    // updatefound event

    private onupdatefound = () => BlazorInvoke.method(this.eventTrigger, "InvokeUpdateFound");

    public activateOnupdatefound(): void {
        this.serviceWorkerRegistration.addEventListener("updatefound", this.onupdatefound);
    }

    public deactivateOnupdatefound(): void {
        this.serviceWorkerRegistration.removeEventListener("updatefound", this.onupdatefound);
    }
}
