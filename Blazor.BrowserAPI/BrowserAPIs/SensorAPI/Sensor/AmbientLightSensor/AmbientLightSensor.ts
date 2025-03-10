import { SensorAPI } from "../Sensor";

export class AmbientLightSensorAPI extends SensorAPI {
    declare sensor: AmbientLightSensor;

    constructor(ambientLightSensor: AmbientLightSensor) {
        super(ambientLightSensor);
    }

    static create(frequency: number): AmbientLightSensorAPI | null {
        if (!("AmbientLightSensor" in window))
            return null;

        let options: SensorOptions;
        if (frequency > 0)
            options = { frequency };
        else
            options = {};

        return new AmbientLightSensorAPI(new AmbientLightSensor(options));
    }


    getIlluminance(): number {
        return this.sensor.illuminance ?? 0;
    }
}
