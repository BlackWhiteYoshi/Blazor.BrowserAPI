import { MIDIAccessAPI } from "./MIDIAccess/MIDIAccess";

export class WebMIDIAPI {
    public static async requestMIDIAccess(sysex: boolean, software: boolean): Promise<MIDIAccessAPI> {
        const midiAccess = await navigator.requestMIDIAccess({ sysex, software });
        return new MIDIAccessAPI(midiAccess);
    }
}
