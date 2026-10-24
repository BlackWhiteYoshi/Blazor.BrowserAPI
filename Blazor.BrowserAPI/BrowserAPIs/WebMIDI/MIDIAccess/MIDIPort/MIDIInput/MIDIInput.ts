import { MIDIPortAPI } from "../MIDIPort";
import { BlazorInvoke } from "../../../../../Extensions/blazorExtensions";

export class MIDIInputAPI extends MIDIPortAPI<MIDIInput> {
    public constructor(midiInput: MIDIInput) {
        super(midiInput);
    }


    // midimessage event

    private onmidimessage = (event: MIDIMessageEvent) => BlazorInvoke.method(this.eventTrigger, "InvokeMIDIMessage", event.data);

    public activateOnmidimessage(): void {
        this.midiPort.addEventListener("midimessage", this.onmidimessage);
    }

    public deactivateOnmidimessage(): void {
        this.midiPort.removeEventListener("midimessage", this.onmidimessage);
    }
}
