import { SensorWrapper } from "../Sensor";

/**
 * @param {number} frequency
 * @param {"device" | "screen"} referenceFrame
 * @returns {LinearAccelerationSensorWrapper | null}
 */
export function createLinearAccelerationSensor(frequency, referenceFrame) {
    if (!("LinearAccelerationSensor" in window))
        return null;

    /** @type {MotionSensorOptions} */
    let options;
    if (frequency > 0)
        options = { frequency, referenceFrame };
    else
        options = { referenceFrame };

    return new LinearAccelerationSensorWrapper(new LinearAccelerationSensor(options));
}


export class LinearAccelerationSensorWrapper extends SensorWrapper {
    /**
     * @param {LinearAccelerationSensor} linearAccelerationSensor
     */
    constructor(linearAccelerationSensor) {
        super(linearAccelerationSensor);
    }


    /**
     * @returns {number}
     */
    getX() {
        return /** @type {LinearAccelerationSensor} */(this.sensor).x ?? 0;
    }

    /**
     * @returns {number}
     */
    getY() {
        return /** @type {LinearAccelerationSensor} */(this.sensor).y ?? 0;
    }

    /**
     * @returns {number}
     */
    getZ() {
        return /** @type {LinearAccelerationSensor} */(this.sensor).z ?? 0;
    }
}
