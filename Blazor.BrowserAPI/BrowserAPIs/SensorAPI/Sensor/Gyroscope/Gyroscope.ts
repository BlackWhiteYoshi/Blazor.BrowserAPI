import { SensorAPI } from "../Sensor";

export class GyroscopeAPI extends SensorAPI {
    declare protected sensor: Gyroscope;

    private constructor(gyroscope: Gyroscope) {
        super(gyroscope);
    }

    public static create(frequency: number, referenceFrame: "device" | "screen"): [GyroscopeAPI] | [null] {
        if (!("Gyroscope" in window))
            return [null];

        let options: MotionSensorOptions;
        if (frequency > 0)
            options = { frequency, referenceFrame };
        else
            options = { referenceFrame };

        return [DotNet.createJSObjectReference(new GyroscopeAPI(new Gyroscope(options)))];
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
