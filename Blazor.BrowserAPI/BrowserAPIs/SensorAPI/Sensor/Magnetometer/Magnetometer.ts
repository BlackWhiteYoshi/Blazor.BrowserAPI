import { SensorAPI } from "../Sensor";

export class MagnetometerAPI extends SensorAPI {
    declare sensor: Magnetometer;

    constructor(magnetometer: Magnetometer) {
        super(magnetometer);
    }

    static create(frequency: number, referenceFrame: "device" | "screen"): [MagnetometerAPI] | [null] {
        if (!("Magnetometer" in window))
            return [null];

        let options: MotionSensorOptions;
        if (frequency > 0)
            options = { frequency, referenceFrame };
        else
            options = { referenceFrame };

        return [DotNet.createJSObjectReference(new MagnetometerAPI(new Magnetometer(options)))];
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
