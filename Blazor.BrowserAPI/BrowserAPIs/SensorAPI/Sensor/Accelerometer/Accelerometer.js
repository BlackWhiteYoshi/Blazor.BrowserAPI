import { SensorAPI } from "../Sensor";

export class AccelerometerAPI extends SensorAPI {
    /**
     * @param {Accelerometer} accelerometer
     */
    constructor(accelerometer) {
        super(accelerometer);
    }

    /**
     * @param {number} frequency
     * @param {"device" | "screen"} referenceFrame
     * @returns {AccelerometerAPI | null}
     */
    static create(frequency, referenceFrame) {
        if (!("Accelerometer" in window))
            return null;

        /** @type {MotionSensorOptions} */
        let options;
        if (frequency > 0)
            options = { frequency, referenceFrame };
        else
            options = { referenceFrame };

        return new AccelerometerAPI(new Accelerometer(options));
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
