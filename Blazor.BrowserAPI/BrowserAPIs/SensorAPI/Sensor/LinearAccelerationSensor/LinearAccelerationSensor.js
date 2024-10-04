import { SensorAPI } from "../Sensor";

export class LinearAccelerationSensorAPI extends SensorAPI {
    /**
     * @param {LinearAccelerationSensor} linearAccelerationSensor
     */
    constructor(linearAccelerationSensor) {
        super(linearAccelerationSensor);
    }

    /**
     * @param {number} frequency
     * @param {"device" | "screen"} referenceFrame
     * @returns {LinearAccelerationSensorAPI | null}
     */
    static create(frequency, referenceFrame) {
        if (!("LinearAccelerationSensor" in window))
            return null;

        /** @type {MotionSensorOptions} */
        let options;
        if (frequency > 0)
            options = { frequency, referenceFrame };
        else
            options = { referenceFrame };

        return new LinearAccelerationSensorAPI(new LinearAccelerationSensor(options));
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
