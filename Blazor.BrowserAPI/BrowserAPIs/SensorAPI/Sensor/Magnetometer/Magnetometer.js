import { SensorAPI } from "../Sensor";

export class MagnetometerAPI extends SensorAPI {
    /**
     * @param {Magnetometer} magnetometer
     */
    constructor(magnetometer) {
        super(magnetometer);
    }

    /**
     * @param {number} frequency
     * @param {"device" | "screen"} referenceFrame
     * @returns {MagnetometerAPI | null}
     */
    static create(frequency, referenceFrame) {
        if (!("Magnetometer" in window))
            return null;

        /** @type {MotionSensorOptions} */
        let options;
        if (frequency > 0)
            options = { frequency, referenceFrame };
        else
            options = { referenceFrame };

        return new MagnetometerAPI(new Magnetometer(options));
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
