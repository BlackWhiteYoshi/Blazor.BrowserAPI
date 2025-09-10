import { GamepadAPI } from "./Gamepad/Gamepad";
import { BlazorInvoke } from "../../Extensions/blazorExtensions";

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

    static initEvents(eventTrigger: DotNet.DotNetObject): void {
        GamepadInterfaceAPI.#eventTrigger = eventTrigger;
    }


    // gamepadconnected event

    static #ongamepadconnected(gamepadEvent: GamepadEvent) {
        return BlazorInvoke.method(GamepadInterfaceAPI.#eventTrigger, "InvokeGamepadConnected", DotNet.createJSObjectReference(new GamepadAPI(gamepadEvent.gamepad)));
    }

    static activateOngamepadconnected(): void {
        window.addEventListener("gamepadconnected", GamepadInterfaceAPI.#ongamepadconnected);
    }

    static deactivateOngamepadconnected(): void {
        window.removeEventListener("gamepadconnected", GamepadInterfaceAPI.#ongamepadconnected);
    }


    // ongamepaddisconnected event

    static #ongamepaddisconnected(gamepadEvent: GamepadEvent) {
        return BlazorInvoke.method(GamepadInterfaceAPI.#eventTrigger, "InvokeGamepadDisconnected", DotNet.createJSObjectReference(new GamepadAPI(gamepadEvent.gamepad)));
    }

    static activateOngamepaddisconnected(): void {
        window.addEventListener("gamepaddisconnected", GamepadInterfaceAPI.#ongamepaddisconnected);
    }

    static deactivateOngamepaddisconnected(): void {
        window.removeEventListener("gamepaddisconnected", GamepadInterfaceAPI.#ongamepaddisconnected);
    }
}
