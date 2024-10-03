import { SensorWrapper } from "../Sensor";

/**
 * @param {number} frequency
 * @returns {AmbientLightSensorWrapper | null}
 */
export function createAmbientLightSensor(frequency) {
    if (!("AmbientLightSensor" in window))
        return null;

    /** @type {SensorOptions} */
    let options;
    if (frequency > 0)
        options = { frequency };
    else
        options = { };

    return new AmbientLightSensorWrapper(new AmbientLightSensor(options));
}


export class AmbientLightSensorWrapper extends SensorWrapper {
    /**
     * @param {AmbientLightSensor} ambientLightSensor
     */
    constructor(ambientLightSensor) {
        super(ambientLightSensor);
    }


    /**
     * @returns {number}
     */
    getIlluminance() {
        return /** @type {AmbientLightSensor} */(this.sensor).illuminance ?? 0;
    }
}
