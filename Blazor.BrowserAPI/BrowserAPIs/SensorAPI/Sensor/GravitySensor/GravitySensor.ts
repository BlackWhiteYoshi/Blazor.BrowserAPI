import { SensorAPI } from "../Sensor";

export class GravitySensorAPI extends SensorAPI {
    declare sensor: GravitySensor;

    constructor(gravitySensor: GravitySensor) {
        super(gravitySensor);
    }

    static create(frequency: number, referenceFrame: "device" | "screen"): GravitySensorAPI | null {
        if (!("GravitySensor" in window))
            return null;

        let options: MotionSensorOptions;
        if (frequency > 0)
            options = { frequency, referenceFrame };
        else
            options = { referenceFrame };

        return new GravitySensorAPI(new GravitySensor(options));
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
