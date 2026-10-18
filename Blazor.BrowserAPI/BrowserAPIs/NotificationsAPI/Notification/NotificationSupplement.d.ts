interface Notification {
    readonly actions: NotificationAction[];
    readonly badge: string;
    readonly image: string;
    readonly navigate: string | undefined;
    readonly renotify: boolean;
    readonly timestamp: number;
    readonly vibrate: number[];
}

declare class NotificationAction {
    action: string;
    title: string;
    icon?: string;
    navigate?: string;
}
