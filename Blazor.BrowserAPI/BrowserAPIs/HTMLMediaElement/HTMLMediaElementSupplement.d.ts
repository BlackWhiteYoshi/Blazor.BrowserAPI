interface HTMLMediaElement {
    onenterpictureinpicture: (this: HTMLMediaElement, event: PictureInPictureEvent) => any;
    addEventListener(type: "enterpictureinpicture", listener: (this: HTMLMediaElement, event: PictureInPictureEvent) => any, useCapture?: boolean): void;
    removeEventListener(type: "enterpictureinpicture", listener: (this: HTMLMediaElement, event: PictureInPictureEvent) => any, useCapture?: boolean): void;

    onleavepictureinpicture: (this: HTMLMediaElement, event: PictureInPictureEvent) => any;
    addEventListener(type: "leavepictureinpicture", listener: (this: HTMLMediaElement, event: PictureInPictureEvent) => any, useCapture?: boolean): void;
    removeEventListener(type: "leavepictureinpicture", listener: (this: HTMLMediaElement, event: PictureInPictureEvent) => any, useCapture?: boolean): void;
}
