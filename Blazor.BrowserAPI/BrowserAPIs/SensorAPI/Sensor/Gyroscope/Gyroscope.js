import { SensorWrapper } from "../Sensor";

/**
 * @param {number} frequency
 * @param {"device" | "screen"} referenceFrame
 * @returns {GyroscopeWrapper | null}
 */
export function createGyroscope(frequency, referenceFrame) {
    if (!("Gyroscope" in window))
        return null;

    /** @type {MotionSensorOptions} */
    let options;
    if (frequency > 0)
        options = { frequency, referenceFrame };
    else
        options = { referenceFrame };

    return new GyroscopeWrapper(new Gyroscope(options));
}


export class GyroscopeWrapper extends SensorWrapper {
    /**
     * @param {Gyroscope} gyroscope
     */
    constructor(gyroscope) {
        super(gyroscope);
    }


    /**
     * @returns {number}
     */
    getX() {
        return /** @type {Gyroscope} */(this.sensor).x ?? 0;
    }

    /**
     * @returns {number}
     */
    getY() {
        return /** @type {Gyroscope} */(this.sensor).y ?? 0;
    }

    /**
     * @returns {number}
     */
    getZ() {
        return /** @type {Gyroscope} */(this.sensor).z ?? 0;
    }
}
