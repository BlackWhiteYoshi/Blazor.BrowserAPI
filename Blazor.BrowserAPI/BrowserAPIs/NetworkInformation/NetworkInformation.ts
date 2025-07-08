import { blazorInvokeMethod } from "../../Extensions/blazorExtensions";

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
    static #isEventTriggerSync: boolean;

    static initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        NetworkInformationAPI.#eventTrigger = eventTrigger;
        NetworkInformationAPI.#isEventTriggerSync = isEventTriggerSync;
    }


    // online event

    static #ononline() {
        blazorInvokeMethod(NetworkInformationAPI.#eventTrigger, NetworkInformationAPI.#isEventTriggerSync, "InvokeOnline");
    }

    static activateOnonline() {
        window.addEventListener("online", NetworkInformationAPI.#ononline);
    }

    static deactivateOnonline() {
        window.removeEventListener("online", NetworkInformationAPI.#ononline);
    }


    // offline event

    static #onoffline() {
        blazorInvokeMethod(NetworkInformationAPI.#eventTrigger, NetworkInformationAPI.#isEventTriggerSync, "InvokeOffline");
    }

    static activateOnoffline() {
        window.addEventListener("offline", NetworkInformationAPI.#onoffline);
    }

    static deactivateOnoffline() {
        window.removeEventListener("offline", NetworkInformationAPI.#onoffline);
    }


    // change event

    static #onchange() {
        blazorInvokeMethod(NetworkInformationAPI.#eventTrigger, NetworkInformationAPI.#isEventTriggerSync, "InvokeChange");
    }

    static activateOnchange() {
        navigator.connection.addEventListener("change", NetworkInformationAPI.#onchange);
    }

    static deactivateOnchange() {
        navigator.connection.removeEventListener("change", NetworkInformationAPI.#onchange);
    }
}
