export class GamepadAPI {
    #gamepad: Gamepad;

    constructor(gamepad: Gamepad) {
        this.#gamepad = gamepad;
    }


    getAxes(): readonly number[] {
        return this.#gamepad.axes;
    }


    getButtons(): GamepadButton[] {
        return this.#gamepad.buttons.map(gamepadButton => ({ pressed: gamepadButton.pressed, touched: gamepadButton.touched, value: gamepadButton.value }));
    }


    getConnected(): boolean {
        return this.#gamepad.connected;
    }

    getId(): string {
        return this.#gamepad.id;
    }

    getIndex(): number {
        return this.#gamepad.index;
    }

    getMapping(): string {
        return this.#gamepad.mapping;
    }

    getTimestamp(): number {
        return this.#gamepad.timestamp;
    }


    // vibrationActuator

    getVibrationActuatorEffects(): ("vibration" | "dual-rumble" | "trigger-rumble")[] {
        const vibration = <GamepadHapticActuator & { effects: ("dual-rumble" | "trigger-rumble")[]; }>this.#gamepad.vibrationActuator;
        if (!vibration)
            return [];

        return vibration.effects || [vibration.type];
    }

    playVibrationActuatorEffect(type: string, duration: number, startDelay: number, strongMagnitude: number, weakMagnitude: number, leftTrigger: number, rightTrigger: number): Promise<"complete" | "preempted" | "none"> {
        const vibration = this.#gamepad.vibrationActuator;
        if (!vibration)
            return new Promise(() => "none");

        return vibration.playEffect(<"dual-rumble">type, <GamepadEffectParameters>{ duration, startDelay, strongMagnitude, weakMagnitude, leftTrigger, rightTrigger });
    }

    resetVibrationActuator(): Promise<"complete" | "preempted" | "none"> {
        const vibration = this.#gamepad.vibrationActuator;
        if (!vibration)
            return new Promise(() => "none");

        return vibration.reset();
    }
}
