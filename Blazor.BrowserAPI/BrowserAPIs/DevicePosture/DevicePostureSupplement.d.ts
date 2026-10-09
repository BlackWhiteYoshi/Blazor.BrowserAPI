interface Navigator {
    readonly devicePosture: DevicePosture;
}

interface DevicePosture {
    readonly type: string;

    onchange: (this: DevicePosture) => any;
    addEventListener(type: "change", listener: (this: DevicePosture) => any, useCapture?: boolean): void;
    removeEventListener(type: "change", listener: (this: DevicePosture) => any, useCapture?: boolean): void;
}
