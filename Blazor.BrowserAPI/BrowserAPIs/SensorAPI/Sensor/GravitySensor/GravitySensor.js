import { SensorAPI } from "../Sensor";

export class GravitySensorAPI extends SensorAPI {
    /**
     * @param {GravitySensor} gravitySensor
     */
    constructor(gravitySensor) {
        super(gravitySensor);
    }

    /**
     * @param {number} frequency
     * @param {"device" | "screen"} referenceFrame
     * @returns {GravitySensorAPI | null}
     */
    static create(frequency, referenceFrame) {
        if (!("GravitySensor" in window))
            return null;

        /** @type {MotionSensorOptions} */
        let options;
        if (frequency > 0)
            options = { frequency, referenceFrame };
        else
            options = { referenceFrame };

        return new GravitySensorAPI(new GravitySensor(options));
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
