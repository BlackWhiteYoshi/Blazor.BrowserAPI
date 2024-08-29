import { MediaStreamWrapper } from "./MediaStream/MediaStream";


/**
 * @returns {Promise<MediaDeviceInfo[]>}
 */
export function enumerateDevices() {
    return navigator.mediaDevices.enumerateDevices();
}

/**
 * @returns {MediaTrackSupportedConstraints}
 */
export function getSupportedConstraints() {
    return navigator.mediaDevices.getSupportedConstraints();
}

/**
 * @param {boolean | ConstrainMediaTrack} audio
 * @param {boolean | ConstrainMediaTrack} video
 * @returns {Promise<MediaStreamWrapper>}
 */
export async function getUserMedia(audio, video) {
    return new MediaStreamWrapper(await navigator.mediaDevices.getUserMedia({ audio: ConvertToMediaTrackConstraintSet(audio), video: ConvertToMediaTrackConstraintSet(video) }));
}

/**
 * @param {boolean | ConstrainMediaTrack} audio
 * @param {boolean | ConstrainMediaTrack} video
 * @returns {Promise<MediaStreamWrapper>}
 */
export async function getDisplayMedia(audio, video) {
    return new MediaStreamWrapper(await navigator.mediaDevices.getDisplayMedia({ audio: ConvertToMediaTrackConstraintSet(audio), video: ConvertToMediaTrackConstraintSet(video) }));
}


/**
 * @typedef {0 | 1 | 2} Type - 0 = none, 1 = exact, 2 = ideal
 * 
 * @typedef {{ type: Type; value: boolean; }} BooleanConstrain
 * @typedef {{ type: Type; value: number; min: number; max: number }} DoubleConstrain
 * @typedef {{ type: Type; value: number; min: number; max: number }} ULongConstrain
 * @typedef {{ type: Type; value: string; values: string[] | null; }} DOMStringConstrain
 * 
 * @typedef {{ aspectRatio: DoubleConstrain | null; autoGainControl: BooleanConstrain | null; channelCount: ULongConstrain | null; deviceId: DOMStringConstrain | null; displaySurface: DOMStringConstrain | null; echoCancellation: BooleanConstrain | null; facingMode: DOMStringConstrain | null; frameRate: DoubleConstrain | null; groupId: DOMStringConstrain | null; height: ULongConstrain | null; noiseSuppression: BooleanConstrain | null; sampleRate: ULongConstrain | null; sampleSize: ULongConstrain | null; width: ULongConstrain | null; }} ConstrainMediaTrack
 */

/**
 * @param {boolean | ConstrainMediaTrack} constrainMediaTrack
 * @returns {boolean | MediaTrackConstraintSet}
 */
function ConvertToMediaTrackConstraintSet(constrainMediaTrack) {
    if (typeof constrainMediaTrack === "boolean")
        return constrainMediaTrack;
    else
        return {
            aspectRatio: toConstrainNumber(constrainMediaTrack.aspectRatio),
            autoGainControl: toConstrainBoolean(constrainMediaTrack.autoGainControl),
            channelCount: toConstrainNumber(constrainMediaTrack.channelCount),
            deviceId: toConstrainDOMString(constrainMediaTrack.deviceId),
            displaySurface: toConstrainDOMString(constrainMediaTrack.displaySurface),
            echoCancellation: toConstrainBoolean(constrainMediaTrack.echoCancellation),
            facingMode: toConstrainDOMString(constrainMediaTrack.facingMode),
            frameRate: toConstrainNumber(constrainMediaTrack.frameRate),
            groupId: toConstrainDOMString(constrainMediaTrack.groupId),
            height: toConstrainNumber(constrainMediaTrack.height),
            noiseSuppression: toConstrainBoolean(constrainMediaTrack.noiseSuppression),
            sampleRate: toConstrainNumber(constrainMediaTrack.sampleRate),
            sampleSize: toConstrainNumber(constrainMediaTrack.sampleSize),
            width: toConstrainNumber(constrainMediaTrack.width)
        };


    /**
     * @param {BooleanConstrain | null} booleanConstrain
     * @return {ConstrainBoolean | undefined}
     */
    function toConstrainBoolean(booleanConstrain) {
        if (booleanConstrain === null)
            return undefined;

        switch (booleanConstrain.type) {
            case 0:
                return booleanConstrain.value;
            case 1:
                return { exact: booleanConstrain.value };
            case 2:
                return { ideal: booleanConstrain.value };
            default:
                throw new Error(`unreachable code: invalid enum -> type must be 0, 1 or 2, but it is ${booleanConstrain?.type}`);
        }
    }

    /**
     * @param {DoubleConstrain | ULongConstrain | null} numberConstrain
     * @return {ConstrainDouble | ConstrainULong | undefined}
     */
    function toConstrainNumber(numberConstrain) {
        if (numberConstrain === null)
            return undefined;

        switch (numberConstrain.type) {
            case 0:
                return numberConstrain.value;
            case 1:
                return { exact: numberConstrain.value };
            case 2:
                return {
                    ideal: numberConstrain.value ?? undefined,
                    min: numberConstrain.min ?? undefined,
                    max: numberConstrain.max ?? undefined,
                };
            default:
                throw new Error(`unreachable code: invalid enum -> type must be 0, 1 or 2, but it is ${numberConstrain?.type}`);
        }
    }

    /**
     * @param {DOMStringConstrain | null} stringConstrain
     * @return {ConstrainDOMString | undefined}
     */
    function toConstrainDOMString(stringConstrain) {
        if (stringConstrain === null)
            return undefined;

        switch (stringConstrain.type) {
            case 0:
                return stringConstrain.values ?? stringConstrain.value;
            case 1:
                return { exact: stringConstrain.values ?? stringConstrain.value };
            case 2:
                return { ideal: stringConstrain.values ?? stringConstrain.value };
            default:
                throw new Error(`unreachable code: invalid enum -> type must be 0, 1 or 2, but it is ${stringConstrain?.type}`);
        }
    }
}
