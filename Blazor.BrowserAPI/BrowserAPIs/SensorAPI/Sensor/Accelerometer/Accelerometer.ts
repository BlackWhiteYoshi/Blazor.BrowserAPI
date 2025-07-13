import { SensorAPI } from "../Sensor";

export class AccelerometerAPI extends SensorAPI {
    declare sensor: Accelerometer;

    constructor(accelerometer: Accelerometer) {
        super(accelerometer);
    }

    static create(frequency: number, referenceFrame: "device" | "screen"): [AccelerometerAPI] | [null] {
        if (!("Accelerometer" in window))
            return [null];

        let options: MotionSensorOptions;
        if (frequency > 0)
            options = { frequency, referenceFrame };
        else
            options = { referenceFrame };

        return [DotNet.createJSObjectReference(new AccelerometerAPI(new Accelerometer(options)))];
    }


    getX(): number {
        return this.sensor.x ?? 0;
    }

    getY(): number {
        return this.sensor.y ?? 0;
    }

    getZ(): number {
        return this.sensor.z ?? 0;
    }
}
