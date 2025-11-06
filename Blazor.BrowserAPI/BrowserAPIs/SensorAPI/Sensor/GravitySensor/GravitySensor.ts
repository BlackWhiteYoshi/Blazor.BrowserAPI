import { SensorAPI } from "../Sensor";

export class GravitySensorAPI extends SensorAPI {
    declare protected sensor: GravitySensor;

    private constructor(gravitySensor: GravitySensor) {
        super(gravitySensor);
    }

    public static create(frequency: number, referenceFrame: "device" | "screen"): [GravitySensorAPI] | [null] {
        if (!("GravitySensor" in window))
            return [null];

        let options: MotionSensorOptions;
        if (frequency > 0)
            options = { frequency, referenceFrame };
        else
            options = { referenceFrame };

        return [DotNet.createJSObjectReference(new GravitySensorAPI(new GravitySensor(options)))];
    }


    public getX(): number {
        return this.sensor.x ?? 0;
    }

    public getY(): number {
        return this.sensor.y ?? 0;
    }

    public getZ(): number {
        return this.sensor.z ?? 0;
    }
}
