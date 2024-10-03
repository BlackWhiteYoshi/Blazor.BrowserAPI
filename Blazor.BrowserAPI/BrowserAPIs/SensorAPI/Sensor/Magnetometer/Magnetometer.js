import { SensorWrapper } from "../Sensor";

/**
 * @param {number} frequency
 * @param {"device" | "screen"} referenceFrame
 * @returns {MagnetometerWrapper | null}
 */
export function createMagnetometer(frequency, referenceFrame) {
    if (!("Magnetometer" in window))
        return null;

    /** @type {MotionSensorOptions} */
    let options;
    if (frequency > 0)
        options = { frequency, referenceFrame };
    else
        options = { referenceFrame };

    return new MagnetometerWrapper(new Magnetometer(options));
}


export class MagnetometerWrapper extends SensorWrapper {
    /**
     * @param {Magnetometer} magnetometer
     */
    constructor(magnetometer) {
        super(magnetometer);
    }


    /**
     * @returns {number}
     */
    getX() {
        return /** @type {Magnetometer} */(this.sensor).x ?? 0;
    }

    /**
     * @returns {number}
     */
    getY() {
        return /** @type {Magnetometer} */(this.sensor).y ?? 0;
    }

    /**
     * @returns {number}
     */
    getZ() {
        return /** @type {Magnetometer} */(this.sensor).z ?? 0;
    }
}
