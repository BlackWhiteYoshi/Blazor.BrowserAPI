using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class WindowManagementGroup : ComponentBase {
    public const string TEST_SCREEN_LOCK_ORIENTATION_RESULT = "screen locked orientation";
    public const string TEST_SCREEN_LOCK_ORIENTATION_NOT_SUPPOERTED = "screen Lock orientation not supported";
    public const string TEST_SCREEN_UNLOCK_ORIENTATION_RESULT = "screen unlocked orientation";
    public const string TEST_SCREEN_CHANGE_EVENT = "screen changed";
    public const string TEST_SCREEN_ORIENTATION_CHANGE_EVENT = "screen orientation changed";

    public const string TEST_EVENT_ON_CURRENT_SCREEN_CHANGE = "window-management current screen has changed";
    public const string TEST_EVENT_ON_SCREENS_CHANGE = "window-management some screen property has changed";
    public const string TEST_LOCK_ORIENTATION_RESULT = "window-management locked orientation";
    public const string TEST_LOCK_ORIENTATION_NOT_SUPPOERTED = "window-management Lock orientation not supported";
    public const string TEST_UNLOCK_ORIENTATION_RESULT = "window-management unlocked orientation";
    public const string TEST_CHANGE_EVENT = "window-management changed";
    public const string TEST_ORIENTATION_CHANGE_EVENT = "window-management orientation changed";


    [Inject]
    public required IWindowManagement WindowManagement { private get; init; }


    public const string LABEL_OUTPUT = "window-management-output";
    private string labelOutput = string.Empty;


    #region Screen

    public const string BUTTON_SCREEN_GET_WIDTH_PROPERTY = "window-management-screen-get-width-property";
    private async Task Screen_GetWidth_Property() {
        int width = await WindowManagement.Screen.Width;
        labelOutput = width.ToString();
    }

    public const string BUTTON_SCREEN_GET_WIDTH_METHOD = "window-management-screen-get-width-method";
    private async Task Screen_GetWidth_Method() {
        int width = await WindowManagement.Screen.GetWidth(CancellationToken.None);
        labelOutput = width.ToString();
    }


    public const string BUTTON_SCREEN_GET_HEIGHT_PROPERTY = "window-management-screen-get-height-property";
    private async Task Screen_GetHeight_Property() {
        int height = await WindowManagement.Screen.Height;
        labelOutput = height.ToString();
    }

    public const string BUTTON_SCREEN_GET_HEIGHT_METHOD = "window-management-screen-get-height-method";
    private async Task Screen_GetHeight_Method() {
        int height = await WindowManagement.Screen.GetHeight(CancellationToken.None);
        labelOutput = height.ToString();
    }


    public const string BUTTON_SCREEN_GET_AVAIL_WIDTH_PROPERTY = "window-management-screen-get-avail-width-property";
    private async Task Screen_GetAvailWidth_Property() {
        int availWidth = await WindowManagement.Screen.AvailWidth;
        labelOutput = availWidth.ToString();
    }

    public const string BUTTON_SCREEN_GET_AVAIL_WIDTH_METHOD = "window-management-screen-get-avail-width-method";
    private async Task Screen_GetAvailWidth_Method() {
        int availWidth = await WindowManagement.Screen.GetAvailWidth(CancellationToken.None);
        labelOutput = availWidth.ToString();
    }


    public const string BUTTON_SCREEN_GET_AVAIL_HEIGHT_PROPERTY = "window-management-screen-get-avail-height-property";
    private async Task Screen_GetAvailHeight_Property() {
        int availHeight = await WindowManagement.Screen.AvailHeight;
        labelOutput = availHeight.ToString();
    }

    public const string BUTTON_SCREEN_GET_AVAIL_HEIGHT_METHOD = "window-management-screen-get-avail-height-method";
    private async Task Screen_GetAvailHeight_Method() {
        int availHeight = await WindowManagement.Screen.GetAvailHeight(CancellationToken.None);
        labelOutput = availHeight.ToString();
    }


    public const string BUTTON_SCREEN_GET_COLOR_DEPTH_PROPERTY = "window-management-screen-get-color-depth-property";
    private async Task Screen_GetColorDepth_Property() {
        int colorDepth = await WindowManagement.Screen.ColorDepth;
        labelOutput = colorDepth.ToString();
    }

    public const string BUTTON_SCREEN_GET_COLOR_DEPTH_METHOD = "window-management-screen-get-color-depth-method";
    private async Task Screen_GetColorDepth_Method() {
        int colorDepth = await WindowManagement.Screen.GetColorDepth(CancellationToken.None);
        labelOutput = colorDepth.ToString();
    }


    public const string BUTTON_SCREEN_GET_PIXEL_DEPTH_PROPERTY = "window-management-screen-get-pixel-depth-property";
    private async Task Screen_GetPixelDepth_Property() {
        int pixelDepth = await WindowManagement.Screen.PixelDepth;
        labelOutput = pixelDepth.ToString();
    }

    public const string BUTTON_SCREEN_GET_PIXEL_DEPTH_METHOD = "window-management-screen-get-pixel-depth-method";
    private async Task Screen_GetPixelDepth_Method() {
        int pixelDepth = await WindowManagement.Screen.GetPixelDepth(CancellationToken.None);
        labelOutput = pixelDepth.ToString();
    }


    public const string BUTTON_SCREEN_GET_IS_EXTENDED_PROPERTY = "window-management-screen-get-is-extended-property";
    private async Task Screen_GetIsExtended_Property() {
        bool isExtended = await WindowManagement.Screen.IsExtended;
        labelOutput = isExtended.ToString();
    }

    public const string BUTTON_SCREEN_GET_IS_EXTENDED_METHOD = "window-management-screen-get-is-extended-method";
    private async Task Screen_GetIsExtended_Method() {
        bool isExtended = await WindowManagement.Screen.GetIsExtended(CancellationToken.None);
        labelOutput = isExtended.ToString();
    }


    // orientation

    public const string BUTTON_SCREEN_GET_ORIENTATION_TYPE_PROPERTY = "window-management-screen-get-orientation-type-property";
    private async Task Screen_GetOrientationType_Property() {
        string orientationType = await WindowManagement.Screen.OrientationType;
        labelOutput = orientationType;
    }

    public const string BUTTON_SCREEN_GET_ORIENTATION_TYPE_METHOD = "window-management-screen-get-orientation-type-method";
    private async Task Screen_GetOrientationType_Method() {
        string orientationType = await WindowManagement.Screen.GetOrientationType(CancellationToken.None);
        labelOutput = orientationType;
    }


    public const string BUTTON_SCREEN_GET_ORIENTATION_ANGLE_PROPERTY = "window-management-screen-get-orientation-angle-property";
    private async Task Screen_GetOrientationAngle_Property() {
        double orientationAngle = await WindowManagement.Screen.OrientationAngle;
        labelOutput = orientationAngle.ToString();
    }

    public const string BUTTON_SCREEN_GET_ORIENTATION_ANGLE_METHOD = "window-management-screen-get-orientation-angle-method";
    private async Task Screen_GetOrientationAngle_Method() {
        double orientationAngle = await WindowManagement.Screen.GetOrientationAngle(CancellationToken.None);
        labelOutput = orientationAngle.ToString();
    }


    public const string BUTTON_SCREEN_LOCK_ORIENTATION = "window-management-screen-lock-orientation";
    private async Task Screen_LockOrientation() {
        try {
            await WindowManagement.Screen.LockOrientation("any");
            labelOutput = TEST_SCREEN_LOCK_ORIENTATION_RESULT;
        }
        catch (Microsoft.JSInterop.JSException exception) {
            if (exception.Message.Contains("lock() is not available on this device"))
                labelOutput = TEST_SCREEN_LOCK_ORIENTATION_NOT_SUPPOERTED;
            else
                throw;
        }
    }

    public const string BUTTON_SCREEN_UNLOCK_ORIENTATION = "window-management-screen-unlock-orientation";
    private async Task Screen_UnlockOrientation() {
        await WindowManagement.Screen.UnlockOrientation();
        labelOutput = TEST_SCREEN_UNLOCK_ORIENTATION_RESULT;
    }


    // events

    public const string BUTTON_SCREEN_REGISTER_ON_CHANGE = "window-management-screen-change-event";
    private void Screen_RegisterOnChange() {
        WindowManagement.Screen.OnChange += () => {
            labelOutput = TEST_SCREEN_CHANGE_EVENT;
            StateHasChanged();
        };
    }

    public const string BUTTON_SCREEN_REGISTER_ON_ORIENTATION_CHANGE = "window-management-screen-orientation-change-event";
    private void Screen_RegisterOnOrientationChange() {
        WindowManagement.Screen.OnOrientationChange += () => {
            labelOutput = TEST_SCREEN_ORIENTATION_CHANGE_EVENT;
            StateHasChanged();
        };
    }

    #endregion


    #region Window Management

    public const string BUTTON_GET_SCREEN_DETAILS = "window-management-get-screen-details";
    private async Task GetScreenDetails() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        labelOutput = (screenDetails is not null).ToString();
    }


    public const string BUTTON_GET_CURRENT_SCREEN_PROPERTY = "window-management-get-current-screen-property";
    private async Task GetCurrentScreen_Property() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        labelOutput = (screenDetailed is not null).ToString();
    }

    public const string BUTTON_GET_CURRENT_SCREEN_METHOD = "window-management-get-current-screen-method";
    private async Task GetCurrentScreen_Method() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.GetCurrentScreen(CancellationToken.None);

        labelOutput = (screenDetailed is not null).ToString();
    }

    public const string BUTTON_GET_SCREENS_PROPERTY = "window-management-get-screens-property";
    private async Task GetScreens_Property() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        IScreenDetailed[] screens = await screenDetails.Screens;

        labelOutput = screens.Length.ToString();
        await screens.DisposeAsync();
    }

    public const string BUTTON_GET_SCREENS_METHOD = "window-management-get-screens-method";
    private async Task GetScreens_Method() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        IScreenDetailed[] screens = await screenDetails.GetScreens(CancellationToken.None);

        labelOutput = screens.Length.ToString();
        await screens.DisposeAsync();
    }


    public const string BUTTON_REGISTER_ON_CURRENT_SCREEN_CHANGE = "window-management-current-screen-change-event";
    private async Task RegisterOnCurrentScreenChange() {
        IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        screenDetails.OnCurrentScreenChange += OnCurrentScreenChange;

        void OnCurrentScreenChange() {
            labelOutput = TEST_EVENT_ON_CURRENT_SCREEN_CHANGE;
            StateHasChanged();
            screenDetails.OnCurrentScreenChange -= OnCurrentScreenChange;
            _ = screenDetails.DisposeAsync().Preserve();
        }
    }

    public const string BUTTON_REGISTER_ON_SCREENS_CHANGE = "window-management-screens-change-event";
    private async Task RegisterOnScreensChange() {
        IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        screenDetails.OnScreensChange += OnScreensChange;

        void OnScreensChange() {
            labelOutput = TEST_EVENT_ON_SCREENS_CHANGE;
            StateHasChanged();
            screenDetails.OnCurrentScreenChange -= OnScreensChange;
            _ = screenDetails.DisposeAsync().Preserve();
        }
    }


    // ScreenDetailed

    public const string BUTTON_REGISTER_GET_LEFT_PROPERTY = "window-management-get-left-property";
    private async Task GetLeft_Property() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        int left = await screenDetailed.Left;
        labelOutput = left.ToString();
    }

    public const string BUTTON_REGISTER_GET_LEFT_METHOD = "window-management-get-left-method";
    private async Task GetLeft_Method() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        int left = await screenDetailed.GetLeft(CancellationToken.None);
        labelOutput = left.ToString();
    }


    public const string BUTTON_REGISTER_GET_TOP_PROPERTY = "window-management-get-top-property";
    private async Task GetTop_Property() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        int top = await screenDetailed.Top;
        labelOutput = top.ToString();
    }

    public const string BUTTON_REGISTER_GET_TOP_METHOD = "window-management-get-top-method";
    private async Task GetTop_Method() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        int top = await screenDetailed.GetTop(CancellationToken.None);
        labelOutput = top.ToString();
    }


    public const string BUTTON_REGISTER_GET_AVAIL_LEFT_PROPERTY = "window-management-get-avail-left-property";
    private async Task GetAvailLeft_Property() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        int availLeft = await screenDetailed.AvailLeft;
        labelOutput = availLeft.ToString();
    }

    public const string BUTTON_REGISTER_GET_AVAIL_LEFT_METHOD = "window-management-get-avail-left-method";
    private async Task GetAvailLeft_Method() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        int availLeft = await screenDetailed.GetAvailLeft(CancellationToken.None);
        labelOutput = availLeft.ToString();
    }


    public const string BUTTON_REGISTER_GET_AVAIL_TOP_PROPERTY = "window-management-get-avail-top-property";
    private async Task GetAvailTop_Property() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        int availTop = await screenDetailed.AvailTop;
        labelOutput = availTop.ToString();
    }

    public const string BUTTON_REGISTER_GET_AVAIL_TOP_METHOD = "window-management-get-avail-top-method";
    private async Task GetAvailTop_Method() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        int availTop = await screenDetailed.GetAvailTop(CancellationToken.None);
        labelOutput = availTop.ToString();
    }


    public const string BUTTON_REGISTER_GET_LABEL_PROPERTY = "window-management-get-label-property";
    private async Task GetLabel_Property() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        string label = await screenDetailed.Label;
        labelOutput = label != string.Empty ? label : "(empty)";
    }

    public const string BUTTON_REGISTER_GET_LABEL_METHOD = "window-management-get-label-method";
    private async Task GetLabel_Method() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        string label = await screenDetailed.GetLabel(CancellationToken.None);
        labelOutput = label != string.Empty ? label : "(empty)";
    }


    public const string BUTTON_REGISTER_GET_DEVICE_PIXEL_RATIO_PROPERTY = "window-management-get-device-pixel-ratio-property";
    private async Task GetDevicePixelRatio_Property() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        double devicePixelRatio = await screenDetailed.DevicePixelRatio;
        labelOutput = devicePixelRatio.ToString();
    }

    public const string BUTTON_REGISTER_GET_DEVICE_PIXEL_RATIO_METHOD = "window-management-get-device-pixel-ratio-method";
    private async Task GetDevicePixelRatio_Method() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        double devicePixelRatio = await screenDetailed.GetDevicePixelRatio(CancellationToken.None);
        labelOutput = devicePixelRatio.ToString();
    }


    public const string BUTTON_REGISTER_GET_IS_PRIMARY_PROPERTY = "window-management-get-is-primary-property";
    private async Task GetIsPrimary_Property() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        bool isPrimary = await screenDetailed.IsPrimary;
        labelOutput = isPrimary.ToString();
    }

    public const string BUTTON_REGISTER_GET_IS_PRIMARY_METHOD = "window-management-get-is-primary-method";
    private async Task GetIsPrimary_Method() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        bool isPrimary = await screenDetailed.GetIsPrimary(CancellationToken.None);
        labelOutput = isPrimary.ToString();
    }


    public const string BUTTON_REGISTER_GET_IS_INTERNAL_PROPERTY = "window-management-get-is-internal-property";
    private async Task GetIsInternal_Property() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        bool isInternal = await screenDetailed.IsInternal;
        labelOutput = isInternal.ToString();
    }

    public const string BUTTON_REGISTER_GET_IS_INTERNAL_METHOD = "window-management-get-is-internal-method";
    private async Task GetIsInternal_Method() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        bool isInternal = await screenDetailed.GetIsInternal(CancellationToken.None);
        labelOutput = isInternal.ToString();
    }



    public const string BUTTON_GET_WIDTH_PROPERTY = "window-management-get-width-property";
    private async Task GetWidth_Property() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        int width = await screenDetailed.Width;
        labelOutput = width.ToString();
    }

    public const string BUTTON_GET_WIDTH_METHOD = "window-management-get-width-method";
    private async Task GetWidth_Method() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        int width = await screenDetailed.GetWidth(CancellationToken.None);
        labelOutput = width.ToString();
    }


    public const string BUTTON_GET_HEIGHT_PROPERTY = "window-management-get-height-property";
    private async Task GetHeight_Property() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        int height = await screenDetailed.Height;
        labelOutput = height.ToString();
    }

    public const string BUTTON_GET_HEIGHT_METHOD = "window-management-get-height-method";
    private async Task GetHeight_Method() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        int height = await screenDetailed.GetHeight(CancellationToken.None);
        labelOutput = height.ToString();
    }


    public const string BUTTON_GET_AVAIL_WIDTH_PROPERTY = "window-management-get-avail-width-property";
    private async Task GetAvailWidth_Property() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        int availWidth = await screenDetailed.AvailWidth;
        labelOutput = availWidth.ToString();
    }

    public const string BUTTON_GET_AVAIL_WIDTH_METHOD = "window-management-get-avail-width-method";
    private async Task GetAvailWidth_Method() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        int availWidth = await screenDetailed.GetAvailWidth(CancellationToken.None);
        labelOutput = availWidth.ToString();
    }


    public const string BUTTON_GET_AVAIL_HEIGHT_PROPERTY = "window-management-get-avail-height-property";
    private async Task GetAvailHeight_Property() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        int availHeight = await screenDetailed.AvailHeight;
        labelOutput = availHeight.ToString();
    }

    public const string BUTTON_GET_AVAIL_HEIGHT_METHOD = "window-management-get-avail-height-method";
    private async Task GetAvailHeight_Method() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        int availHeight = await screenDetailed.GetAvailHeight(CancellationToken.None);
        labelOutput = availHeight.ToString();
    }


    public const string BUTTON_GET_COLOR_DEPTH_PROPERTY = "window-management-get-color-depth-property";
    private async Task GetColorDepth_Property() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        int colorDepth = await screenDetailed.ColorDepth;
        labelOutput = colorDepth.ToString();
    }

    public const string BUTTON_GET_COLOR_DEPTH_METHOD = "window-management-get-color-depth-method";
    private async Task GetColorDepth_Method() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        int colorDepth = await screenDetailed.GetColorDepth(CancellationToken.None);
        labelOutput = colorDepth.ToString();
    }


    public const string BUTTON_GET_PIXEL_DEPTH_PROPERTY = "window-management-get-pixel-depth-property";
    private async Task GetPixelDepth_Property() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        int pixelDepth = await screenDetailed.PixelDepth;
        labelOutput = pixelDepth.ToString();
    }

    public const string BUTTON_GET_PIXEL_DEPTH_METHOD = "window-management-get-pixel-depth-method";
    private async Task GetPixelDepth_Method() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        int pixelDepth = await screenDetailed.GetPixelDepth(CancellationToken.None);
        labelOutput = pixelDepth.ToString();
    }


    public const string BUTTON_GET_IS_EXTENDED_PROPERTY = "window-management-get-is-extended-property";
    private async Task GetIsExtended_Property() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        bool isExtended = await screenDetailed.IsExtended;
        labelOutput = isExtended.ToString();
    }

    public const string BUTTON_GET_IS_EXTENDED_METHOD = "window-management-get-is-extended-method";
    private async Task GetIsExtended_Method() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        bool isExtended = await screenDetailed.GetIsExtended(CancellationToken.None);
        labelOutput = isExtended.ToString();
    }



    public const string BUTTON_GET_ORIENTATION_TYPE_PROPERTY = "window-management-get-orientation-type-property";
    private async Task GetOrientationType_Property() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        string orientationType = await screenDetailed.OrientationType;
        labelOutput = orientationType;
    }

    public const string BUTTON_GET_ORIENTATION_TYPE_METHOD = "window-management-get-orientation-type-method";
    private async Task GetOrientationType_Method() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        string orientationType = await screenDetailed.GetOrientationType(CancellationToken.None);
        labelOutput = orientationType;
    }


    public const string BUTTON_GET_ORIENTATION_ANGLE_PROPERTY = "window-management-get-orientation-angle-property";
    private async Task GetOrientationAngle_Property() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        double angle = await screenDetailed.OrientationAngle;
        labelOutput = angle.ToString();
    }

    public const string BUTTON_GET_ORIENTATION_ANGLE_METHOD = "window-management-get-orientation-angle-method";
    private async Task GetOrientationAngle_Method() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        double angle = await screenDetailed.GetOrientationAngle(CancellationToken.None);
        labelOutput = angle.ToString();
    }


    public const string BUTTON_LOCK_ORIENTATION = "window-management-lock-orientation";
    private async Task LockOrientation() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        try {
            await screenDetailed.LockOrientation("any");
            labelOutput = TEST_LOCK_ORIENTATION_RESULT;
        }
        catch (Microsoft.JSInterop.JSException exception) {
            if (exception.Message.Contains("lock() is not available on this device"))
                labelOutput = TEST_LOCK_ORIENTATION_NOT_SUPPOERTED;
            else
                throw;
        }
    }

    public const string BUTTON_UNLOCK_ORIENTATION = "window-management-unlock-orientation";
    private async Task UnlockOrientation() {
        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        await screenDetailed.UnlockOrientation();
        labelOutput = TEST_UNLOCK_ORIENTATION_RESULT;
    }



    public const string BUTTON_REGISTER_ON_CHANGE = "window-management-change-event";
    private async Task RegisterOnChange() {
        IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;
        screenDetailed.OnChange += OnChange;

        void OnChange() {
            labelOutput = TEST_CHANGE_EVENT;
            StateHasChanged();
            screenDetailed.OnChange -= OnChange;
            _ = screenDetails.DisposeAsync().Preserve();
            _ = screenDetailed.DisposeAsync().Preserve();
        }
    }

    public const string BUTTON_REGISTER_ON_ORIENTATION_CHANGE = "window-management-orientation-change-event";
    private async Task RegisterOnOrientationChange() {
        IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;
        screenDetailed.OnOrientationChange += OnOrientationChange;

        void OnOrientationChange() {
            labelOutput = TEST_ORIENTATION_CHANGE_EVENT;
            StateHasChanged();
            screenDetailed.OnOrientationChange -= OnOrientationChange;
            _ = screenDetails.DisposeAsync().Preserve();
            _ = screenDetailed.DisposeAsync().Preserve();
        }
    }

    #endregion
}
