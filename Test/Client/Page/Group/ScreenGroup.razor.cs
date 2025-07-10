using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class ScreenGroup : ComponentBase {
    public const string TEST_LOCK_ORIENTATION_RESULT = "locked orientation";
    public const string TEST_LOCK_ORIENTATION_NOT_SUPPOERTED = "Lock orientation not supported";
    public const string TEST_UNLOCK_ORIENTATION_RESULT = "unlocked orientation";
    public const string TEST_CHANGE_EVENT = "screen changed";
    public const string TEST_ORIENTATION_CHANGE_EVENT = "orientation changed";


    [Inject]
    public required IScreen Screen { private get; init; }


    public const string LABEL_OUTPUT = "screen-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_GET_WIDTH_PROPERTY = "screen-get-width-property";
    private async Task GetWidth_Property() {
        int width = await Screen.Width;
        labelOutput = width.ToString();
    }

    public const string BUTTON_GET_WIDTH_METHOD = "screen-get-width-method";
    private async Task GetWidth_Method() {
        int width = await Screen.GetWidth(default);
        labelOutput = width.ToString();
    }


    public const string BUTTON_GET_HEIGHT_PROPERTY = "screen-get-height-property";
    private async Task GetHeight_Property() {
        int height = await Screen.Height;
        labelOutput = height.ToString();
    }

    public const string BUTTON_GET_HEIGHT_METHOD = "screen-get-height-method";
    private async Task GetHeight_Method() {
        int height = await Screen.GetHeight(default);
        labelOutput = height.ToString();
    }


    public const string BUTTON_GET_AVAIL_WIDTH_PROPERTY = "screen-get-avail-width-property";
    private async Task GetAvailWidth_Property() {
        int availWidth = await Screen.AvailWidth;
        labelOutput = availWidth.ToString();
    }

    public const string BUTTON_GET_AVAIL_WIDTH_METHOD = "screen-get-avail-width-method";
    private async Task GetAvailWidth_Method() {
        int availWidth = await Screen.GetAvailWidth(default);
        labelOutput = availWidth.ToString();
    }


    public const string BUTTON_GET_AVAIL_HEIGHT_PROPERTY = "screen-get-avail-height-property";
    private async Task GetAvailHeight_Property() {
        int availHeight = await Screen.AvailHeight;
        labelOutput = availHeight.ToString();
    }

    public const string BUTTON_GET_AVAIL_HEIGHT_METHOD = "screen-get-avail-height-method";
    private async Task GetAvailHeight_Method() {
        int availHeight = await Screen.GetAvailHeight(default);
        labelOutput = availHeight.ToString();
    }


    public const string BUTTON_GET_COLOR_DEPTH_PROPERTY = "screen-get-color-depth-property";
    private async Task GetColorDepth_Property() {
        int colorDepth = await Screen.ColorDepth;
        labelOutput = colorDepth.ToString();
    }

    public const string BUTTON_GET_COLOR_DEPTH_METHOD = "screen-get-color-depth-method";
    private async Task GetColorDepth_Method() {
        int colorDepth = await Screen.GetColorDepth(default);
        labelOutput = colorDepth.ToString();
    }


    public const string BUTTON_GET_PIXEL_DEPTH_PROPERTY = "screen-get-pixel-depth-property";
    private async Task GetPixelDepth_Property() {
        int pixelDepth = await Screen.PixelDepth;
        labelOutput = pixelDepth.ToString();
    }

    public const string BUTTON_GET_PIXEL_DEPTH_METHOD = "screen-get-pixel-depth-method";
    private async Task GetPixelDepth_Method() {
        int pixelDepth = await Screen.GetPixelDepth(default);
        labelOutput = pixelDepth.ToString();
    }


    public const string BUTTON_GET_IS_EXTENDED_PROPERTY = "screen-get-is-extended-property";
    private async Task GetIsExtended_Property() {
        bool isExtended = await Screen.IsExtended;
        labelOutput = isExtended.ToString();
    }

    public const string BUTTON_GET_IS_EXTENDED_METHOD = "screen-get-is-extended-method";
    private async Task GetIsExtended_Method() {
        bool isExtended = await Screen.GetIsExtended(default);
        labelOutput = isExtended.ToString();
    }


    // orientation

    public const string BUTTON_GET_ORIENTATION_TYPE_PROPERTY = "screen-get-orientation-type-property";
    private async Task GetOrientationType_Property() {
        string orientationType = await Screen.OrientationType;
        labelOutput = orientationType;
    }

    public const string BUTTON_GET_ORIENTATION_TYPE_METHOD = "screen-get-orientation-type-method";
    private async Task GetOrientationType_Method() {
        string orientationType = await Screen.GetOrientationType(default);
        labelOutput = orientationType;
    }


    public const string BUTTON_GET_ORIENTATION_ANGLE_PROPERTY = "screen-get-orientation-angle-property";
    private async Task GetOrientationAngle_Property() {
        double orientationAngle = await Screen.OrientationAngle;
        labelOutput = orientationAngle.ToString();
    }

    public const string BUTTON_GET_ORIENTATION_ANGLE_METHOD = "screen-get-orientation-angle-method";
    private async Task GetOrientationAngle_Method() {
        double orientationAngle = await Screen.GetOrientationAngle(default);
        labelOutput = orientationAngle.ToString();
    }


    public const string BUTTON_LOCK_ORIENTATION = "screen-lock-orientation";
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

    public const string BUTTON_UNLOCK_ORIENTATION = "screen-unlock-orientation";
    private async Task UnlockOrientation() {
        await Screen.UnlockOrientation();
        labelOutput = TEST_UNLOCK_ORIENTATION_RESULT;
    }


    // events

    public const string BUTTON_REGISTER_ON_CHANGE = "screen-change-event";
    private void RegisterOnChange() {
        Screen.OnChange += () => {
            labelOutput = TEST_CHANGE_EVENT;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_ORIENTATION_CHANGE = "screen-orientation-change-event";
    private void RegisterOnOrientationChange() {
        Screen.OnOrientationChange += () => {
            labelOutput = TEST_ORIENTATION_CHANGE_EVENT;
            StateHasChanged();
        };
    }
}
