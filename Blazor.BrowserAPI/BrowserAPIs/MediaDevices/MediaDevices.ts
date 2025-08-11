import { MediaStreamAPI } from "./MediaStream/MediaStream";

namespace MediaDevicesTypes {
    export type ConstrainPreference = 0 | 1 | 2; // 0 = none, 1 = exact, 2 = ideal

    export type BooleanConstrain = {
        preference: ConstrainPreference;
        value: boolean;
    };

    export type DoubleConstrain = {
        preference: ConstrainPreference;
        value: number;
        min: number;
        max: number;
    };

    export type ULongConstrain = {
        preference: ConstrainPreference;
        value: number;
        min: number;
        max: number;
    };

    export type DOMStringConstrain = {
        preference: ConstrainPreference;
        value: string;
        values: string[] | null;
    };

    export type ConstrainMediaTrack = {
        aspectRatio: DoubleConstrain | null;
        autoGainControl: BooleanConstrain | null;
        channelCount: ULongConstrain | null;
        deviceId: DOMStringConstrain | null;
        displaySurface: DOMStringConstrain | null;
        echoCancellation: BooleanConstrain | null;
        facingMode: DOMStringConstrain | null;
        frameRate: DoubleConstrain | null;
        groupId: DOMStringConstrain | null;
        height: ULongConstrain | null;
        noiseSuppression: BooleanConstrain | null;
        sampleRate: ULongConstrain | null;
        sampleSize: ULongConstrain | null;
        width: ULongConstrain | null;
    };
}

export class MediaDevicesAPI {
    static enumerateDevices(): Promise<MediaDeviceInfo[]> {
        return navigator.mediaDevices.enumerateDevices();
    }

    static getSupportedConstraints(): MediaTrackSupportedConstraints {
        return navigator.mediaDevices.getSupportedConstraints();
    }

    static async getUserMedia(audio: boolean | MediaDevicesTypes.ConstrainMediaTrack, video: boolean | MediaDevicesTypes.ConstrainMediaTrack): Promise<MediaStreamAPI> {
        const mediaStream = await navigator.mediaDevices.getUserMedia({ audio: this.#convertToMediaTrackConstraintSet(audio), video: this.#convertToMediaTrackConstraintSet(video) });
        return new MediaStreamAPI(mediaStream);
    }

    static async getDisplayMedia(audio: boolean | MediaDevicesTypes.ConstrainMediaTrack, video: boolean | MediaDevicesTypes.ConstrainMediaTrack): Promise<MediaStreamAPI> {
        const mediaStream = await navigator.mediaDevices.getDisplayMedia({ audio: this.#convertToMediaTrackConstraintSet(audio), video: this.#convertToMediaTrackConstraintSet(video) });
        return new MediaStreamAPI(mediaStream);
    }



    static #convertToMediaTrackConstraintSet(constrainMediaTrack: boolean | MediaDevicesTypes.ConstrainMediaTrack): boolean | MediaTrackConstraintSet {
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


        function toConstrainBoolean(booleanConstrain: MediaDevicesTypes.BooleanConstrain | null): ConstrainBoolean | undefined {
            if (booleanConstrain === null)
                return undefined;

            switch (booleanConstrain.preference) {
                case 0: // none
                    return booleanConstrain.value;
                case 1: // exact
                    return { exact: booleanConstrain.value };
                case 2: // ideal
                    return { ideal: booleanConstrain.value };
                default:
                    throw new Error(`unreachable code: invalid enum -> type must be 0, 1 or 2, but it is ${booleanConstrain?.preference}`);
            }
        }

        function toConstrainNumber(numberConstrain: MediaDevicesTypes.DoubleConstrain | MediaDevicesTypes.ULongConstrain | null): ConstrainDouble | ConstrainULong | undefined {
            if (numberConstrain === null)
                return undefined;

            switch (numberConstrain.preference) {
                case 0: // none
                    return numberConstrain.value;
                case 1: // exact
                    return { exact: numberConstrain.value };
                case 2: // ideal
                    return {
                        ideal: numberConstrain.value ?? undefined,
                        min: numberConstrain.min ?? undefined,
                        max: numberConstrain.max ?? undefined,
                    };
                default:
                    throw new Error(`unreachable code: invalid enum -> type must be 0, 1 or 2, but it is ${numberConstrain?.preference}`);
            }
        }

        function toConstrainDOMString(stringConstrain: MediaDevicesTypes.DOMStringConstrain | null): ConstrainDOMString | undefined {
            if (stringConstrain === null)
                return undefined;

            switch (stringConstrain.preference) {
                case 0: // none
                    return stringConstrain.values ?? stringConstrain.value;
                case 1: // exact
                    return { exact: stringConstrain.values ?? stringConstrain.value };
                case 2: // ideal
                    return { ideal: stringConstrain.values ?? stringConstrain.value };
                default:
                    throw new Error(`unreachable code: invalid enum -> type must be 0, 1 or 2, but it is ${stringConstrain?.preference}`);
            }
        }
    }
}
