// enhance window.Window with getScreenDetails method.
interface Navigator {
    getBattery(): Promise<BatteryManager>;
}

declare class BatteryManager {
    readonly charging: boolean;
    readonly chargingTime: number;
    readonly dischargingTime: number;
    readonly level: number;

    onchargingchange: (this: BatteryManager) => any;
    addEventListener(type: "chargingchange", listener: (this: BatteryManager) => any, useCapture?: boolean): void;
    removeEventListener(type: "chargingchange", listener: (this: BatteryManager) => any, useCapture?: boolean): void;

    onchargingtimechange: (this: BatteryManager) => any;
    addEventListener(type: "chargingtimechange", listener: (this: BatteryManager) => any, useCapture?: boolean): void;
    removeEventListener(type: "chargingtimechange", listener: (this: BatteryManager) => any, useCapture?: boolean): void;

    ondischargingtimechange: (this: BatteryManager) => any;
    addEventListener(type: "dischargingtimechange", listener: (this: BatteryManager) => any, useCapture?: boolean): void;
    removeEventListener(type: "dischargingtimechange", listener: (this: BatteryManager) => any, useCapture?: boolean): void;

    onlevelchange: (this: BatteryManager) => any;
    addEventListener(type: "levelchange", listener: (this: BatteryManager) => any, useCapture?: boolean): void;
    removeEventListener(type: "levelchange", listener: (this: BatteryManager) => any, useCapture?: boolean): void;
}


