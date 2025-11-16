export class GamepadAPI {
    private gamepad: Gamepad;

    public constructor(gamepad: Gamepad) {
        this.gamepad = gamepad;
    }


    public getAxes(): readonly number[] {
        return this.gamepad.axes;
    }


    public getButtons(): GamepadButton[] {
        return this.gamepad.buttons.map(gamepadButton => ({ pressed: gamepadButton.pressed, touched: gamepadButton.touched, value: gamepadButton.value }));
    }


    public getConnected(): boolean {
        return this.gamepad.connected;
    }

    public getId(): string {
        return this.gamepad.id;
    }

    public getIndex(): number {
        return this.gamepad.index;
    }

    public getMapping(): string {
        return this.gamepad.mapping;
    }

    public getTimestamp(): number {
        return this.gamepad.timestamp;
    }


    // vibrationActuator

    public getVibrationActuatorEffects(): ("vibration" | "dual-rumble" | "trigger-rumble")[] {
        const vibration = <GamepadHapticActuator & { effects: ("dual-rumble" | "trigger-rumble")[]; }>this.gamepad.vibrationActuator;
        if (!vibration)
            return [];

        return vibration.effects || [vibration.type];
    }

    public playVibrationActuatorEffect(type: string, duration: number, startDelay: number, strongMagnitude: number, weakMagnitude: number, leftTrigger: number, rightTrigger: number): Promise<"complete" | "preempted" | "none"> {
        const vibration = this.gamepad.vibrationActuator;
        if (!vibration)
            return Promise.resolve("none");

        return vibration.playEffect(<"dual-rumble">type, <GamepadEffectParameters>{ duration, startDelay, strongMagnitude, weakMagnitude, leftTrigger, rightTrigger });
    }

    public resetVibrationActuator(): Promise<"complete" | "preempted" | "none"> {
        const vibration = this.gamepad.vibrationActuator;
        if (!vibration)
            return Promise.resolve("none");

        return vibration.reset();
    }
}
