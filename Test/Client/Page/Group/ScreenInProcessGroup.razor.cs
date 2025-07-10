using Microsoft.AspNetCore.Components;
using System;

namespace BrowserAPI.Test.Client;

public sealed partial class ScreenInProcessGroup : ComponentBase {
    public const string TEST_LOCK_ORIENTATION_RESULT = "locked orientation";
    public const string TEST_LOCK_ORIENTATION_NOT_SUPPOERTED = "Lock orientation not supported";
    public const string TEST_UNLOCK_ORIENTATION_RESULT = "unlocked orientation";
    public const string TEST_CHANGE_EVENT = "screen changed";
    public const string TEST_ORIENTATION_CHANGE_EVENT = "orientation changed";


    [Inject]
    public required IScreenInProcess Screen { private get; init; }


    public const string LABEL_OUTPUT = "screen-inprocess-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_GET_WIDTH = "screen-inprocess-get-width";
    private void GetWidth() {
        int width = Screen.Width;
        labelOutput = width.ToString();
    }


    public const string BUTTON_GET_HEIGHT = "screen-inprocess-get-height";
    private void GetHeight() {
        int height = Screen.Height;
        labelOutput = height.ToString();
    }


    public const string BUTTON_GET_AVAIL_WIDTH = "screen-inprocess-get-avail-width";
    private void GetAvailWidth() {
        int availWidth = Screen.AvailWidth;
        labelOutput = availWidth.ToString();
    }


    public const string BUTTON_GET_AVAIL_HEIGHT = "screen-inprocess-get-avail-height";
    private void GetAvailHeight() {
        int availHeight = Screen.AvailHeight;
        labelOutput = availHeight.ToString();
    }


    public const string BUTTON_GET_COLOR_DEPTH = "screen-inprocess-get-color-depth";
    private void GetColorDepth() {
        int colorDepth = Screen.ColorDepth;
        labelOutput = colorDepth.ToString();
    }


    public const string BUTTON_GET_PIXEL_DEPTH = "screen-inprocess-get-pixel-depth";
    private void GetPixelDepth() {
        int pixelDepth = Screen.PixelDepth;
        labelOutput = pixelDepth.ToString();
    }


    public const string BUTTON_GET_IS_EXTENDED = "screen-inprocess-get-is-extended";
    private void GetIsExtended() {
        bool isExtended = Screen.IsExtended;
        labelOutput = isExtended.ToString();
    }


    // orientation

    public const string BUTTON_GET_ORIENTATION_TYPE = "screen-inprocess-get-orientation-type";
    private void GetOrientationType() {
        string orientationType = Screen.OrientationType;
        labelOutput = orientationType;
    }


    public const string BUTTON_GET_ORIENTATION_ANGLE = "screen-inprocess-get-orientation-angle";
    private void GetOrientationAngle() {
        double orientationAngle = Screen.OrientationAngle;
        labelOutput = orientationAngle.ToString();
    }


    public const string BUTTON_LOCK_ORIENTATION = "screen-inprocess-lock-orientation";
    private async Task LockOrientation() {
        try {
            await Screen.LockOrientation("any");
            labelOutput = TEST_LOCK_ORIENTATION_RESULT;
        }
        catch (Microsoft.JSInterop.JSException exception) {
            if (exception.Message.StartsWith("screen.orientation.lock() is not available on this device"))
                labelOutput = TEST_LOCK_ORIENTATION_NOT_SUPPOERTED;
            else
                throw;
        }
    }

    public const string BUTTON_UNLOCK_ORIENTATION = "screen-inprocess-unlock-orientation";
    private void UnlockOrientation() {
        Screen.UnlockOrientation();
        labelOutput = TEST_UNLOCK_ORIENTATION_RESULT;
    }


    // events

    public const string BUTTON_REGISTER_ON_CHANGE = "screen-inprocess-change-event";
    private void RegisterOnChange() {
        Screen.OnChange += () => {
            labelOutput = TEST_CHANGE_EVENT;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ORIENTATION_CHANGE = "screen-inprocess-orientation-change-event";
    private void RegisterOnOrientationChange() {
        Screen.OnOrientationChange += () => {
            labelOutput = TEST_ORIENTATION_CHANGE_EVENT;
            StateHasChanged();
        };
    }
}
