import { SensorAPI } from "../Sensor";

export class GyroscopeAPI extends SensorAPI {
    declare sensor: Gyroscope;

    constructor(gyroscope: Gyroscope) {
        super(gyroscope);
    }

    static create(frequency: number, referenceFrame: "device" | "screen"): GyroscopeAPI | null {
        if (!("Gyroscope" in window))
            return null;

        let options: MotionSensorOptions;
        if (frequency > 0)
            options = { frequency, referenceFrame };
        else
            options = { referenceFrame };

        return new GyroscopeAPI(new Gyroscope(options));
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
