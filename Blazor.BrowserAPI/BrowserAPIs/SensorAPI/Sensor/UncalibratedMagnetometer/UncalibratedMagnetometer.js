import { SensorWrapper } from "../Sensor";

/**
 * @param {number} frequency
 * @param {"device" | "screen"} referenceFrame
 * @returns {UncalibratedMagnetometerWrapper | null}
 */
export function createUncalibratedMagnetometer(frequency, referenceFrame) {
    if (!("UncalibratedMagnetometer" in window))
        return null;

    /** @type {MotionSensorOptions} */
    let options;
    if (frequency > 0)
        options = { frequency, referenceFrame };
    else
        options = { referenceFrame };

    return new UncalibratedMagnetometerWrapper(new UncalibratedMagnetometer(options));
}


export class UncalibratedMagnetometerWrapper extends SensorWrapper {
    /**
     * @param {UncalibratedMagnetometer} uncalibratedMagnetometer
     */
    constructor(uncalibratedMagnetometer) {
        super(uncalibratedMagnetometer);
    }


    /**
     * @returns {number}
     */
    getX() {
        return /** @type {UncalibratedMagnetometer} */(this.sensor).x ?? 0;
    }

    /**
     * @returns {number}
     */
    getY() {
        return /** @type {UncalibratedMagnetometer} */(this.sensor).y ?? 0;
    }

    /**
     * @returns {number}
     */
    getZ() {
        return /** @type {UncalibratedMagnetometer} */(this.sensor).z ?? 0;
    }


    /**
     * @returns {number}
     */
    getXBias() {
        return /** @type {UncalibratedMagnetometer} */(this.sensor).xBias ?? 0;
    }

    /**
     * @returns {number}
     */
    getYBias() {
        return /** @type {UncalibratedMagnetometer} */(this.sensor).yBias ?? 0;
    }

    /**
     * @returns {number}
     */
    getZBias() {
        return /** @type {UncalibratedMagnetometer} */(this.sensor).zBias ?? 0;
    }
}
