import { SensorAPI } from "../Sensor";

export class LinearAccelerationSensorAPI extends SensorAPI {
    declare sensor: LinearAccelerationSensor;

    constructor(linearAccelerationSensor: LinearAccelerationSensor) {
        super(linearAccelerationSensor);
    }

    static create(frequency: number, referenceFrame: "device" | "screen"): [LinearAccelerationSensorAPI] | [null] {
        if (!("LinearAccelerationSensor" in window))
            return [null];

        let options: MotionSensorOptions;
        if (frequency > 0)
            options = { frequency, referenceFrame };
        else
            options = { referenceFrame };

        return [DotNet.createJSObjectReference(new LinearAccelerationSensorAPI(new LinearAccelerationSensor(options)))];
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
