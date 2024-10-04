import { SensorAPI } from "../Sensor";

export class AbsoluteOrientationSensorAPI extends SensorAPI {
    /**
     * @param {AbsoluteOrientationSensor} absoluteOrientationSensor
     */
    constructor(absoluteOrientationSensor) {
        super(absoluteOrientationSensor);
    }

    /**
     * @param {number} frequency
     * @param {"device" | "screen"} referenceFrame
     * @returns {AbsoluteOrientationSensorAPI | null}
     */
    static create(frequency, referenceFrame) {
        if (!("AbsoluteOrientationSensor" in window))
            return null;

        /** @type {MotionSensorOptions} */
        let options;
        if (frequency > 0)
            options = { frequency, referenceFrame };
        else
            options = { referenceFrame };

        return new AbsoluteOrientationSensorAPI(new AbsoluteOrientationSensor(options));
    }


    /**
     * @returns {number[]}
     */
    getQuaternion() {
        return /** @type {AbsoluteOrientationSensor} */(this.sensor).quaternion ?? [0, 0, 0, 0];
    }


    /**
     * @returns {number[]}
     */
    populateMatrix() {
        if (/** @type {AbsoluteOrientationSensor} */(this.sensor).quaternion === null)
            return [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

        let matrix4x4 = new DOMMatrix();
        /** @type {AbsoluteOrientationSensor} */(this.sensor).populateMatrix(matrix4x4);
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
