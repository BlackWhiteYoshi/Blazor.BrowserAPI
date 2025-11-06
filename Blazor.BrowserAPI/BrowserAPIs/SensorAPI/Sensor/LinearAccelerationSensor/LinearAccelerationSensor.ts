import { SensorAPI } from "../Sensor";

export class LinearAccelerationSensorAPI extends SensorAPI {
    declare protected sensor: LinearAccelerationSensor;

    private constructor(linearAccelerationSensor: LinearAccelerationSensor) {
        super(linearAccelerationSensor);
    }

    public static create(frequency: number, referenceFrame: "device" | "screen"): [LinearAccelerationSensorAPI] | [null] {
        if (!("LinearAccelerationSensor" in window))
            return [null];

        let options: MotionSensorOptions;
        if (frequency > 0)
            options = { frequency, referenceFrame };
        else
            options = { referenceFrame };

        return [DotNet.createJSObjectReference(new LinearAccelerationSensorAPI(new LinearAccelerationSensor(options)))];
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
