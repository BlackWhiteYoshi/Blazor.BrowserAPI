import { SensorAPI } from "../Sensor";

export class GyroscopeAPI extends SensorAPI {
    /**
     * @param {Gyroscope} gyroscope
     */
    constructor(gyroscope) {
        super(gyroscope);
    }

    /**
     * @param {number} frequency
     * @param {"device" | "screen"} referenceFrame
     * @returns {GyroscopeAPI | null}
     */
    static create(frequency, referenceFrame) {
        if (!("Gyroscope" in window))
            return null;

        /** @type {MotionSensorOptions} */
        let options;
        if (frequency > 0)
            options = { frequency, referenceFrame };
        else
            options = { referenceFrame };

        return new GyroscopeAPI(new Gyroscope(options));
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
