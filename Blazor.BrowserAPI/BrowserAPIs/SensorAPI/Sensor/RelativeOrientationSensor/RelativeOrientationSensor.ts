import { SensorAPI } from "../Sensor";

export class RelativeOrientationSensorAPI extends SensorAPI {
    declare sensor: RelativeOrientationSensor;

    constructor(relativeOrientationSensor: RelativeOrientationSensor) {
        super(relativeOrientationSensor);
    }

    static create(frequency: number, referenceFrame: "device" | "screen"): RelativeOrientationSensorAPI | null {
        if (!("RelativeOrientationSensor" in window))
            return null;

        let options: MotionSensorOptions;
        if (frequency > 0)
            options = { frequency, referenceFrame };
        else
            options = { referenceFrame };

        return new RelativeOrientationSensorAPI(new RelativeOrientationSensor(options));
    }


    getQuaternion(): number[] {
        return this.sensor.quaternion ?? [0, 0, 0, 0];
    }


    populateMatrix(): number[] {
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
