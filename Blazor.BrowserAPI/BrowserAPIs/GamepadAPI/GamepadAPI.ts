import { GamepadAPI } from "./Gamepad/Gamepad";
import { BlazorInvoke } from "../../Extensions/blazorExtensions";

export class GamepadInterfaceAPI {
    public static getGamepads(): (GamepadAPI | null)[] {
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


    private static eventTrigger: DotNet.DotNetObject;

    public static initEvents(eventTrigger: DotNet.DotNetObject): void {
        GamepadInterfaceAPI.eventTrigger = eventTrigger;
    }


    // gamepadconnected event

    private static ongamepadconnected(gamepadEvent: GamepadEvent) {
        return BlazorInvoke.method(GamepadInterfaceAPI.eventTrigger, "InvokeGamepadConnected", DotNet.createJSObjectReference(new GamepadAPI(gamepadEvent.gamepad)));
    }

    public static activateOngamepadconnected(): void {
        window.addEventListener("gamepadconnected", GamepadInterfaceAPI.ongamepadconnected);
    }

    public static deactivateOngamepadconnected(): void {
        window.removeEventListener("gamepadconnected", GamepadInterfaceAPI.ongamepadconnected);
    }


    // ongamepaddisconnected event

    private static ongamepaddisconnected(gamepadEvent: GamepadEvent) {
        return BlazorInvoke.method(GamepadInterfaceAPI.eventTrigger, "InvokeGamepadDisconnected", DotNet.createJSObjectReference(new GamepadAPI(gamepadEvent.gamepad)));
    }

    public static activateOngamepaddisconnected(): void {
        window.addEventListener("gamepaddisconnected", GamepadInterfaceAPI.ongamepaddisconnected);
    }

    public static deactivateOngamepaddisconnected(): void {
        window.removeEventListener("gamepaddisconnected", GamepadInterfaceAPI.ongamepaddisconnected);
    }
}
