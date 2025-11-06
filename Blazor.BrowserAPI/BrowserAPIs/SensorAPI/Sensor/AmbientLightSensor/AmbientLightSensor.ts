import { SensorAPI } from "../Sensor";

export class AmbientLightSensorAPI extends SensorAPI {
    declare protected sensor: AmbientLightSensor;

    private constructor(ambientLightSensor: AmbientLightSensor) {
        super(ambientLightSensor);
    }

    public static create(frequency: number): [AmbientLightSensorAPI] | [null] {
        if (!("AmbientLightSensor" in window))
            return [null];

        let options: SensorOptions;
        if (frequency > 0)
            options = { frequency };
        else
            options = {};

        return [DotNet.createJSObjectReference(new AmbientLightSensorAPI(new AmbientLightSensor(options)))];
    }


    public getIlluminance(): number {
        return this.sensor.illuminance ?? 0;
    }
}
