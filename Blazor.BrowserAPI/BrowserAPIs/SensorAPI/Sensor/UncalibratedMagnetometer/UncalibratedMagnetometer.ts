import { SensorAPI } from "../Sensor";

export class UncalibratedMagnetometerAPI extends SensorAPI {
    declare protected sensor: UncalibratedMagnetometer;

    private constructor(uncalibratedMagnetometer: UncalibratedMagnetometer) {
        super(uncalibratedMagnetometer);
    }

    public static create(frequency: number, referenceFrame: "device" | "screen"): [UncalibratedMagnetometerAPI] | [null] {
        if (!("UncalibratedMagnetometer" in window))
            return [null];

        let options: MotionSensorOptions;
        if (frequency > 0)
            options = { frequency, referenceFrame };
        else
            options = { referenceFrame };

        return [DotNet.createJSObjectReference(new UncalibratedMagnetometerAPI(new UncalibratedMagnetometer(options)))];
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


    public getXBias(): number {
        return this.sensor.xBias ?? 0;
    }

    public getYBias(): number {
        return this.sensor.yBias ?? 0;
    }

    public getZBias(): number {
        return this.sensor.zBias ?? 0;
    }
}
