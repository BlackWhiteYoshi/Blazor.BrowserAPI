import { SensorAPI } from "../Sensor";

export class UncalibratedMagnetometerAPI extends SensorAPI {
    declare sensor: UncalibratedMagnetometer;

    constructor(uncalibratedMagnetometer: UncalibratedMagnetometer) {
        super(uncalibratedMagnetometer);
    }

    static create(frequency: number, referenceFrame: "device" | "screen"): UncalibratedMagnetometerAPI | null {
        if (!("UncalibratedMagnetometer" in window))
            return null;

        let options: MotionSensorOptions;
        if (frequency > 0)
            options = { frequency, referenceFrame };
        else
            options = { referenceFrame };

        return new UncalibratedMagnetometerAPI(new UncalibratedMagnetometer(options));
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


    getXBias(): number {
        return this.sensor.xBias ?? 0;
    }

    getYBias(): number {
        return this.sensor.yBias ?? 0;
    }

    getZBias(): number {
        return this.sensor.zBias ?? 0;
    }
}
