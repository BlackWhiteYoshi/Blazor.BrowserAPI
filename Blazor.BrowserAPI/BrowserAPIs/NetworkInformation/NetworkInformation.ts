import { BlazorInvoke } from "../../Extensions/blazorExtensions";

export class NetworkInformationAPI {
    static getOnLine(): boolean {
        return navigator.onLine;
    }


    static getDownlink(): number {
        return navigator.connection.downlink;
    }

    static getDownlinkMax(): number {
        return navigator.connection.downlinkMax;
    }

    static getEffectiveType(): string {
        return navigator.connection.effectiveType;
    }

    static getType(): string {
        return navigator.connection.type;
    }

    static getRTT(): number {
        return navigator.connection.rtt;
    }

    static getSaveData(): boolean {
        return navigator.connection.saveData;
    }


    // events


    static #eventTrigger: DotNet.DotNetObject;

    static initEvents(eventTrigger: DotNet.DotNetObject): void {
        NetworkInformationAPI.#eventTrigger = eventTrigger;
    }


    // online event

    static #ononline() {
        return BlazorInvoke.method(NetworkInformationAPI.#eventTrigger, "InvokeOnline");
    }

    static activateOnonline(): void {
        window.addEventListener("online", NetworkInformationAPI.#ononline);
    }

    static deactivateOnonline(): void {
        window.removeEventListener("online", NetworkInformationAPI.#ononline);
    }


    // offline event

    static #onoffline() {
        return BlazorInvoke.method(NetworkInformationAPI.#eventTrigger, "InvokeOffline");
    }

    static activateOnoffline(): void {
        window.addEventListener("offline", NetworkInformationAPI.#onoffline);
    }

    static deactivateOnoffline(): void {
        window.removeEventListener("offline", NetworkInformationAPI.#onoffline);
    }


    // change event

    static #onchange() {
        return BlazorInvoke.method(NetworkInformationAPI.#eventTrigger, "InvokeChange");
    }

    static activateOnchange(): void {
        navigator.connection.addEventListener("change", NetworkInformationAPI.#onchange);
    }

    static deactivateOnchange(): void {
        navigator.connection.removeEventListener("change", NetworkInformationAPI.#onchange);
    }
}
