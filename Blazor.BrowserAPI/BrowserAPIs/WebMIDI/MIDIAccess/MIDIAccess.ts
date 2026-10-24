import { MIDIInputAPI } from "./MIDIPort/MIDIInput/MIDIInput";
import { MIDIOutputAPI } from "./MIDIPort/MIDIOutput/MIDIOutput";
import { BlazorInvoke } from "../../../Extensions/blazorExtensions";

export class MIDIAccessAPI {
    private midiAccess: MIDIAccess;

    public constructor(midiAccess: MIDIAccess) {
        this.midiAccess = midiAccess;
    }


    public getInputs(): MIDIInputAPI[] {
        return [... this.midiAccess.inputs.values().map(midiInput => DotNet.createJSObjectReference(new MIDIInputAPI(midiInput)))];
    }

    public getOutputs(): MIDIOutputAPI[] {
        return [... this.midiAccess.outputs.values().map(midiOutput => DotNet.createJSObjectReference(new MIDIOutputAPI(midiOutput)))];
    }

    public getSysexEnabled(): boolean {
        return this.midiAccess.sysexEnabled;
    }



    // events


    private eventTrigger!: DotNet.DotNetObject;

    public initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.eventTrigger = eventTrigger;
    }


    // statechange event

    private onstatechange = (event: MIDIConnectionEvent) => {
        let isInputPort = event.port!.type === "input";
        let midiPortAPI = isInputPort
            ? new MIDIInputAPI(<MIDIInput>event.port)
            : new MIDIOutputAPI(<MIDIOutput>event.port);
        return BlazorInvoke.method(this.eventTrigger, "InvokeStateChange", isInputPort, DotNet.createJSObjectReference(midiPortAPI));
    }

    public activateOnstatechange(): void {
        this.midiAccess.addEventListener("statechange", this.onstatechange);
    }

    public deactivateOnstatechange(): void {
        this.midiAccess.removeEventListener("statechange", this.onstatechange);
    }
}
