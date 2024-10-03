import { SensorWrapper } from "../Sensor";

/**
 * @param {number} frequency
 * @param {"device" | "screen"} referenceFrame
 * @returns {GravitySensorWrapper | null}
 */
export function createGravitySensor(frequency, referenceFrame) {
    if (!("GravitySensor" in window))
        return null;

    /** @type {MotionSensorOptions} */
    let options;
    if (frequency > 0)
        options = { frequency, referenceFrame };
    else
        options = { referenceFrame };

    return new GravitySensorWrapper(new GravitySensor(options));
}


export class GravitySensorWrapper extends SensorWrapper {
    /**
     * @param {GravitySensor} gravitySensor
     */
    constructor(gravitySensor) {
        super(gravitySensor);
    }


    /**
     * @returns {number}
     */
    getX() {
        return /** @type {GravitySensor} */(this.sensor).x ?? 0;
    }

    /**
     * @returns {number}
     */
    getY() {
        return /** @type {GravitySensor} */(this.sensor).y ?? 0;
    }

    /**
     * @returns {number}
     */
    getZ() {
        return /** @type {GravitySensor} */(this.sensor).z ?? 0;
    }
}
