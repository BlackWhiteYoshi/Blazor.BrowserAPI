import { GamepadAPI } from "./Gamepad/Gamepad";

export class GamepadInterfaceAPI {
    static getGamepads(): (Gamepad | null)[] {
        const gamepads = <(Gamepad | null)[]>navigator.getGamepads();

        const result: (Gamepad | null)[] = new Array(gamepads.length);
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

    static initEvents(eventTrigger: DotNet.DotNetObject, isEventTriggerSync: boolean) {
        GamepadInterfaceAPI.#eventTrigger = eventTrigger;
        GamepadInterfaceAPI.#isEventTriggerSync = isEventTriggerSync;
    }


    // gamepadconnected event

    static #ongamepadconnected(gamepadEvent: GamepadEvent) {
        if (GamepadInterfaceAPI.#isEventTriggerSync)
            GamepadInterfaceAPI.#eventTrigger.invokeMethod("InvokeGamepadConnected", DotNet.createJSObjectReference(new GamepadAPI(gamepadEvent.gamepad)));
        else
            GamepadInterfaceAPI.#eventTrigger.invokeMethodAsync("InvokeGamepadConnected", DotNet.createJSObjectReference(new GamepadAPI(gamepadEvent.gamepad)));
    }

    static activateOngamepadconnected() {        
        window.addEventListener("gamepadconnected", GamepadInterfaceAPI.#ongamepadconnected);
    }

    static deactivateOngamepadconnected() {
        window.removeEventListener("gamepadconnected", GamepadInterfaceAPI.#ongamepadconnected);
    }


    // ongamepaddisconnected event

    static #ongamepaddisconnected(gamepadEvent: GamepadEvent) {
        if (GamepadInterfaceAPI.#isEventTriggerSync)
            GamepadInterfaceAPI.#eventTrigger.invokeMethod("InvokeGamepadDisconnected", DotNet.createJSObjectReference(new GamepadAPI(gamepadEvent.gamepad)));
        else
            GamepadInterfaceAPI.#eventTrigger.invokeMethodAsync("InvokeGamepadDisconnected", DotNet.createJSObjectReference(new GamepadAPI(gamepadEvent.gamepad)));
    }

    static activateOngamepaddisconnected() {
        window.addEventListener("gamepaddisconnected", GamepadInterfaceAPI.#ongamepaddisconnected);
    }

    static deactivateOngamepaddisconnected() {
        window.removeEventListener("gamepaddisconnected", GamepadInterfaceAPI.#ongamepaddisconnected);
    }
}
