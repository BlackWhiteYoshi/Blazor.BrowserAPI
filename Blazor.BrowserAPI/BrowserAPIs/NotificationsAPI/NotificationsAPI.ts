import { NotificationAPI } from "./Notification/Notification";

export class NotificationsAPI {
    public static create(title: string, badge: string | null, body: string, data: object | null, dir: NotificationDirection, icon: string | null, image: string | null, lang: string, navigate: string | null, renotify: boolean, requireInteraction: boolean, silent: boolean | null, tag: string, timestamp: number | null, vibrate: number[] | null): NotificationAPI {
        const options = {
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
        const notification = new Notification(title, options);
        return new NotificationAPI(notification);
    }

    public static getPermission(): string {
        return Notification.permission;
    }

    public static getMaxActions(): number {
        return (<Notification & { maxActions: number }><unknown>Notification).maxActions;
    }

    public static requestPermission(): Promise<string> {
        return Notification.requestPermission();
    }
}
