import { SensorAPI } from "../Sensor";

export class AmbientLightSensorAPI extends SensorAPI {
    /**
     * @param {AmbientLightSensor} ambientLightSensor
     */
    constructor(ambientLightSensor) {
        super(ambientLightSensor);
    }

    /**
     * @param {number} frequency
     * @returns {AmbientLightSensorAPI | null}
     */
    static create(frequency) {
        if (!("AmbientLightSensor" in window))
            return null;

        /** @type {SensorOptions} */
        let options;
        if (frequency > 0)
            options = { frequency };
        else
            options = {};

        return new AmbientLightSensorAPI(new AmbientLightSensor(options));
    }


    /**
     * @returns {number}
     */
    getIlluminance() {
        return /** @type {AmbientLightSensor} */(this.sensor).illuminance ?? 0;
    }
}
