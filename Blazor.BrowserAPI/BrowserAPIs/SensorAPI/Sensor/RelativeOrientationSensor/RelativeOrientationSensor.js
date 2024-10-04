import { SensorAPI } from "../Sensor";

export class RelativeOrientationSensorAPI extends SensorAPI {
    /**
     * @param {RelativeOrientationSensor} relativeOrientationSensor
     */
    constructor(relativeOrientationSensor) {
        super(relativeOrientationSensor);
    }

    /**
     * @param {number} frequency
     * @param {"device" | "screen"} referenceFrame
     * @returns {RelativeOrientationSensorAPI | null}
     */
    static create(frequency, referenceFrame) {
        if (!("RelativeOrientationSensor" in window))
            return null;

        /** @type {MotionSensorOptions} */
        let options;
        if (frequency > 0)
            options = { frequency, referenceFrame };
        else
            options = { referenceFrame };

        return new RelativeOrientationSensorAPI(new RelativeOrientationSensor(options));
    }


    /**
     * @returns {number[]}
     */
    getQuaternion() {
        return /** @type {RelativeOrientationSensor} */(this.sensor).quaternion ?? [0, 0, 0, 0];
    }


    /**
     * @returns {number[]}
     */
    populateMatrix() {
        if (/** @type {RelativeOrientationSensor} */(this.sensor).quaternion === null)
            return [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

        let matrix4x4 = new DOMMatrix();
        /** @type {RelativeOrientationSensor} */(this.sensor).populateMatrix(matrix4x4);
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
