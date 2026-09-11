import { BatteryManagerAPI } from "./BatteryManager/BatteryManager";

export class BatteryStatusAPI {
    public static async getBattery(): Promise<BatteryManagerAPI> {
        const batteryManager = await navigator.getBattery();
        return new BatteryManagerAPI(batteryManager);
    }
}
