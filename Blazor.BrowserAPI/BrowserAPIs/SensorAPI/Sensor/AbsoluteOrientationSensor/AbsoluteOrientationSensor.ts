import { SensorAPI } from "../Sensor";

export class AbsoluteOrientationSensorAPI extends SensorAPI {
    declare protected sensor: AbsoluteOrientationSensor;

    private constructor(absoluteOrientationSensor: AbsoluteOrientationSensor) {
        super(absoluteOrientationSensor);
    }

    public static create(frequency: number, referenceFrame: "device" | "screen"): [AbsoluteOrientationSensorAPI] | [null] {
        if (!("AbsoluteOrientationSensor" in window))
            return [null];

        let options: MotionSensorOptions;
        if (frequency > 0)
            options = { frequency, referenceFrame };
        else
            options = { referenceFrame };

        return [DotNet.createJSObjectReference(new AbsoluteOrientationSensorAPI(new AbsoluteOrientationSensor(options)))];
    }


    public getQuaternion(): number[] {
        return this.sensor.quaternion ?? [0, 0, 0, 0];
    }


    public populateMatrix(): number[] {
        if (this.sensor.quaternion === null)
            return [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

        let matrix4x4 = new DOMMatrix();
        this.sensor.populateMatrix(matrix4x4);
        return [
            matrix4x4.m11,
            matrix4x4.m12,
            matrix4x4.m13,
            matrix4x4.m14,
            matrix4x4.m21,
            matrix4x4.m22,
            matrix4x4.m23,
            matrix4x4.m24,
            matrix4x4.m31,
            matrix4x4.m32,
            matrix4x4.m33,
            matrix4x4.m34,
            matrix4x4.m41,
            matrix4x4.m42,
            matrix4x4.m43,
            matrix4x4.m44
        ];
    }
}
