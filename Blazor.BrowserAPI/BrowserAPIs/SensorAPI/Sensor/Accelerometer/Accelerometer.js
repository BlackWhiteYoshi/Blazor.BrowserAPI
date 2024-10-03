import { SensorWrapper } from "../Sensor";

/**
 * @param {number} frequency
 * @param {"device" | "screen"} referenceFrame
 * @returns {AccelerometerWrapper | null}
 */
export function createAccelerometer(frequency, referenceFrame) {
    if (!("Accelerometer" in window))
        return null;

    /** @type {MotionSensorOptions} */
    let options;
    if (frequency > 0)
        options = { frequency, referenceFrame };
    else
        options = { referenceFrame };

    return new AccelerometerWrapper(new Accelerometer(options));
}


export class AccelerometerWrapper extends SensorWrapper {
    /**
     * @param {Accelerometer} accelerometer
     */
    constructor(accelerometer) {
        super(accelerometer);
    }


    /**
     * @returns {number}
     */
    getX() {
        return /** @type {Accelerometer} */(this.sensor).x ?? 0;
    }

    /**
     * @returns {number}
     */
    getY() {
        return /** @type {Accelerometer} */(this.sensor).y ?? 0;
    }

    /**
     * @returns {number}
     */
    getZ() {
        return /** @type {Accelerometer} */(this.sensor).z ?? 0;
    }
}
