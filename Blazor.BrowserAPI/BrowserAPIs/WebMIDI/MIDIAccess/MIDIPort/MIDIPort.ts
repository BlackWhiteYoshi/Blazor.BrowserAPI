import { BlazorInvoke } from "../../../../Extensions/blazorExtensions";

export abstract class MIDIPortAPI<TMIDIPort extends MIDIPort> {
    protected midiPort: TMIDIPort;

    public constructor(midiPort: TMIDIPort) {
        this.midiPort = midiPort;
    }


    public getId(): string {
        return this.midiPort.id;
    }

    public getManufacturer(): string | null {
        return this.midiPort.manufacturer;
    }

    public getName(): string | null {
        return this.midiPort.name;
    }

    public getType(): "input" | "output" {
        return this.midiPort.type;
    }

    public getVersion(): string | null {
        return this.midiPort.version;
    }

    public getState(): "connected" | "disconnected" {
        return this.midiPort.state;
    }

    public getConnection(): "open" | "closed" | "pending" {
        return this.midiPort.connection;
    }


    public async open(): Promise<void> {
        await this.midiPort.open();
    }

    public async close(): Promise<void> {
        await this.midiPort.close();
    }



    // events


    protected eventTrigger!: DotNet.DotNetObject;

    public initEvents(eventTrigger: DotNet.DotNetObject): void {
        this.eventTrigger = eventTrigger;
    }


    // statechange event

    private onstatechange = () => BlazorInvoke.method(this.eventTrigger, "InvokeStateChange");

    public activateOnstatechange(): void {
        this.midiPort.addEventListener("statechange", this.onstatechange);
    }

    public deactivateOnstatechange(): void {
        this.midiPort.removeEventListener("statechange", this.onstatechange);
    }
}
