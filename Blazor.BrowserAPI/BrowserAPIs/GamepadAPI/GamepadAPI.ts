import { GamepadAPI } from "./Gamepad/Gamepad";
import { blazorInvokeMethod } from "../../Extensions/blazorExtensions";

export class GamepadInterfaceAPI {
    static getGamepads(): (GamepadAPI | null)[] {
        const gamepads = <(Gamepad | null)[]>navigator.getGamepads();

        const result: (GamepadAPI | null)[] = new Array(gamepads.length);
        for (let i = 0; i < result.length; i++)
            if (gamepads[i])
                result[i] = DotNet.createJSObjectReference(new GamepadAPI(<Gamepad>gamepads[i]));
            else
                result[i] = null;

        return result;
    }


    // events


    static #eventTrigger: DotNet.DotNetObject;
    static #isEventTriggerSync: boolean;

    static initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean): void {
        GamepadInterfaceAPI.#eventTrigger = eventTrigger;
        GamepadInterfaceAPI.#isEventTriggerSync = isEventTriggerSync;
    }


    // gamepadconnected event

    static #ongamepadconnected(gamepadEvent: GamepadEvent) {
        return blazorInvokeMethod(GamepadInterfaceAPI.#eventTrigger, GamepadInterfaceAPI.#isEventTriggerSync, "InvokeGamepadConnected", DotNet.createJSObjectReference(new GamepadAPI(gamepadEvent.gamepad)));
    }

    static activateOngamepadconnected(): void {
        window.addEventListener("gamepadconnected", GamepadInterfaceAPI.#ongamepadconnected);
    }

    static deactivateOngamepadconnected(): void {
        window.removeEventListener("gamepadconnected", GamepadInterfaceAPI.#ongamepadconnected);
    }


    // ongamepaddisconnected event

    static #ongamepaddisconnected(gamepadEvent: GamepadEvent) {
        return blazorInvokeMethod(GamepadInterfaceAPI.#eventTrigger, GamepadInterfaceAPI.#isEventTriggerSync, "InvokeGamepadDisconnected", DotNet.createJSObjectReference(new GamepadAPI(gamepadEvent.gamepad)));
    }

    static activateOngamepaddisconnected(): void {
        window.addEventListener("gamepaddisconnected", GamepadInterfaceAPI.#ongamepaddisconnected);
    }

    static deactivateOngamepaddisconnected(): void {
        window.removeEventListener("gamepaddisconnected", GamepadInterfaceAPI.#ongamepaddisconnected);
    }
}
