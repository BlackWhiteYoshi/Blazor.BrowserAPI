import { MIDIPortAPI } from "../MIDIPort";

export class MIDIOutputAPI extends MIDIPortAPI<MIDIOutput> {
    public constructor(midiOutput: MIDIOutput) {
        super(midiOutput);
    }


    public send(data: number[], timestamp?: number): void {
        this.midiPort.send(data, timestamp);
    }

    public clear(): void {
        (<MIDIOutput & { clear: () => void }>this.midiPort).clear();
    }
}
