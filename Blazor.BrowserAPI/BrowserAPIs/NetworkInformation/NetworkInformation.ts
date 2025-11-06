import { BlazorInvoke } from "../../Extensions/blazorExtensions";

export class NetworkInformationAPI {
    public static getOnLine(): boolean {
        return navigator.onLine;
    }


    public static getDownlink(): number {
        return navigator.connection.downlink;
    }

    public static getDownlinkMax(): number {
        return navigator.connection.downlinkMax;
    }

    public static getEffectiveType(): string {
        return navigator.connection.effectiveType;
    }

    public static getType(): string {
        return navigator.connection.type;
    }

    public static getRTT(): number {
        return navigator.connection.rtt;
    }

    public static getSaveData(): boolean {
        return navigator.connection.saveData;
    }


    // events


    private static eventTrigger: DotNet.DotNetObject;

    public static initEvents(eventTrigger: DotNet.DotNetObject): void {
        NetworkInformationAPI.eventTrigger = eventTrigger;
    }


    // online event

    private static ononline() {
        return BlazorInvoke.method(NetworkInformationAPI.eventTrigger, "InvokeOnline");
    }

    public static activateOnonline(): void {
        window.addEventListener("online", NetworkInformationAPI.ononline);
    }

    public static deactivateOnonline(): void {
        window.removeEventListener("online", NetworkInformationAPI.ononline);
    }


    // offline event

    private static onoffline() {
        return BlazorInvoke.method(NetworkInformationAPI.eventTrigger, "InvokeOffline");
    }

    public static activateOnoffline(): void {
        window.addEventListener("offline", NetworkInformationAPI.onoffline);
    }

    public static deactivateOnoffline(): void {
        window.removeEventListener("offline", NetworkInformationAPI.onoffline);
    }


    // change event

    private static onchange() {
        return BlazorInvoke.method(NetworkInformationAPI.eventTrigger, "InvokeChange");
    }

    public static activateOnchange(): void {
        navigator.connection.addEventListener("change", NetworkInformationAPI.onchange);
    }

    public static deactivateOnchange(): void {
        navigator.connection.removeEventListener("change", NetworkInformationAPI.onchange);
    }
}
