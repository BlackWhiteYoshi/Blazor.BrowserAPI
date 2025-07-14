using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class WindowManagementInProcessGroup : ComponentBase {
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
    public required IWindowManagementInProcess WindowManagement { private get; init; }


    public const string LABEL_OUTPUT = "window-management-inprocess-output";
    private string labelOutput = string.Empty;


    #region Screen

    public const string BUTTON_SCREEN_GET_WIDTH = "window-management-screen-inprocess-get-width";
    private void Screen_GetWidth() {
        int width = WindowManagement.Screen.Width;
        labelOutput = width.ToString();
    }


    public const string BUTTON_SCREEN_GET_HEIGHT = "window-management-screen-inprocess-get-height";
    private void Screen_GetHeight() {
        int height = WindowManagement.Screen.Height;
        labelOutput = height.ToString();
    }


    public const string BUTTON_SCREEN_GET_AVAIL_WIDTH = "window-management-screen-inprocess-get-avail-width";
    private void Screen_GetAvailWidth() {
        int availWidth = WindowManagement.Screen.AvailWidth;
        labelOutput = availWidth.ToString();
    }


    public const string BUTTON_SCREEN_GET_AVAIL_HEIGHT = "window-management-screen-inprocess-get-avail-height";
    private void Screen_GetAvailHeight() {
        int availHeight = WindowManagement.Screen.AvailHeight;
        labelOutput = availHeight.ToString();
    }


    public const string BUTTON_SCREEN_GET_COLOR_DEPTH = "window-management-screen-inprocess-get-color-depth";
    private void Screen_GetColorDepth() {
        int colorDepth = WindowManagement.Screen.ColorDepth;
        labelOutput = colorDepth.ToString();
    }


    public const string BUTTON_SCREEN_GET_PIXEL_DEPTH = "window-management-screen-inprocess-get-pixel-depth";
    private void Screen_GetPixelDepth() {
        int pixelDepth = WindowManagement.Screen.PixelDepth;
        labelOutput = pixelDepth.ToString();
    }


    public const string BUTTON_SCREEN_GET_IS_EXTENDED = "window-management-screen-inprocess-get-is-extended";
    private void Screen_GetIsExtended() {
        bool isExtended = WindowManagement.Screen.IsExtended;
        labelOutput = isExtended.ToString();
    }


    // orientation

    public const string BUTTON_SCREEN_GET_ORIENTATION_TYPE = "window-management-screen-inprocess-get-orientation-type";
    private void Screen_GetOrientationType() {
        string orientationType = WindowManagement.Screen.OrientationType;
        labelOutput = orientationType;
    }


    public const string BUTTON_SCREEN_GET_ORIENTATION_ANGLE = "window-management-screen-inprocess-get-orientation-angle";
    private void Screen_GetOrientationAngle() {
        double orientationAngle = WindowManagement.Screen.OrientationAngle;
        labelOutput = orientationAngle.ToString();
    }


    public const string BUTTON_SCREEN_LOCK_ORIENTATION = "window-management-screen-inprocess-lock-orientation";
    private async Task Screen_LockOrientation() {
        try {
            await WindowManagement.Screen.LockOrientation("any");
            labelOutput = TEST_SCREEN_LOCK_ORIENTATION_RESULT;
        }
        catch (Microsoft.JSInterop.JSException exception) {
            if (exception.Message.StartsWith("screen.orientation.lock() is not available on this device"))
                labelOutput = TEST_SCREEN_LOCK_ORIENTATION_NOT_SUPPOERTED;
            else
                throw;
        }
    }

    public const string BUTTON_SCREEN_UNLOCK_ORIENTATION = "window-management-screen-inprocess-unlock-orientation";
    private void Screen_UnlockOrientation() {
        WindowManagement.Screen.UnlockOrientation();
        labelOutput = TEST_SCREEN_UNLOCK_ORIENTATION_RESULT;
    }


    // events

    public const string BUTTON_SCREEN_REGISTER_ON_CHANGE = "window-management-screen-inprocess-change-event";
    private void Screen_RegisterOnChange() {
        WindowManagement.Screen.OnChange += () => {
            labelOutput = TEST_SCREEN_CHANGE_EVENT;
            StateHasChanged();
        };
    }

    public const string BUTTON_SCREEN_REGISTER_ON_ORIENTATION_CHANGE = "window-management-screen-inprocess-orientation-change-event";
    private void Screen_RegisterOnOrientationChange() {
        WindowManagement.Screen.OnOrientationChange += () => {
            labelOutput = TEST_SCREEN_ORIENTATION_CHANGE_EVENT;
            StateHasChanged();
        };
    }

    #endregion


    #region Window Management

    public const string BUTTON_GET_SCREEN_DETAILS = "window-management-inprocess-get-screen-details";
    private async Task GetScreenDetails() {
        using IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        labelOutput = (screenDetails is not null).ToString();
    }

    public const string BUTTON_OPEN = "window-management-inprocess-open";
    private void Open() {
        WindowManagement.Open();
    }


    public const string BUTTON_GET_CURRENT_SCREEN = "window-management-inprocess-get-current-screen";
    private async Task GetCurrentScreen() {
        using IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        using IScreenDetailedInProcess screenDetailed = screenDetails.CurrentScreen;

        labelOutput = (screenDetailed is not null).ToString();
    }

    public const string BUTTON_GET_SCREENS = "window-management-inprocess-get-screens";
    private async Task GetScreens() {
        using IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        IScreenDetailedInProcess[] screens = screenDetails.Screens;

        labelOutput = screens.Length.ToString();
        screens.Dispose();
    }


    public const string BUTTON_REGISTER_ON_CURRENT_SCREEN_CHANGE = "window-management-inprocess-current-screen-change-event";
    private async Task RegisterOnCurrentScreenChange() {
        IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        screenDetails.OnCurrentScreenChange += OnCurrentScreenChange;

        void OnCurrentScreenChange() {
            labelOutput = TEST_EVENT_ON_CURRENT_SCREEN_CHANGE;
            StateHasChanged();
            screenDetails.OnCurrentScreenChange -= OnCurrentScreenChange;
            screenDetails.Dispose();
        }
    }

    public const string BUTTON_REGISTER_ON_SCREENS_CHANGE = "window-management-inprocess-screens-change-event";
    private async Task RegisterOnScreensChange() {
        IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        screenDetails.OnScreensChange += OnScreensChange;

        void OnScreensChange() {
            labelOutput = TEST_EVENT_ON_SCREENS_CHANGE;
            StateHasChanged();
            screenDetails.OnCurrentScreenChange -= OnScreensChange;
            screenDetails.Dispose();
        }
    }


    // ScreenDetailed

    public const string BUTTON_REGISTER_GET_LEFT = "window-management-inprocess-get-left";
    private async Task GetLeft() {
        using IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        using IScreenDetailedInProcess screenDetailed = screenDetails.CurrentScreen;

        int left = screenDetailed.Left;
        labelOutput = left.ToString();
    }

    public const string BUTTON_REGISTER_GET_TOP = "window-management-inprocess-get-top";
    private async Task GetTop() {
        using IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        using IScreenDetailedInProcess screenDetailed = screenDetails.CurrentScreen;

        int top = screenDetailed.Top;
        labelOutput = top.ToString();
    }

    public const string BUTTON_REGISTER_GET_AVAIL_LEFT = "window-management-inprocess-get-avail-left";
    private async Task GetAvailLeft() {
        using IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        using IScreenDetailedInProcess screenDetailed = screenDetails.CurrentScreen;

        int availLeft = screenDetailed.AvailLeft;
        labelOutput = availLeft.ToString();
    }

    public const string BUTTON_REGISTER_GET_AVAIL_TOP = "window-management-inprocess-get-avail-top";
    private async Task GetAvailTop() {
        using IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        using IScreenDetailedInProcess screenDetailed = screenDetails.CurrentScreen;

        int availTop = screenDetailed.AvailTop;
        labelOutput = availTop.ToString();
    }

    public const string BUTTON_REGISTER_GET_LABEL = "window-management-inprocess-get-label";
    private async Task GetLabel() {
        using IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        using IScreenDetailedInProcess screenDetailed = screenDetails.CurrentScreen;

        string label = screenDetailed.Label;
        labelOutput = label != string.Empty ? label : "(empty)";
    }

    public const string BUTTON_REGISTER_GET_DEVICE_PIXEL_RATIO = "window-management-inprocess-get-device-pixel-ratio";
    private async Task GetDevicePixelRatio() {
        using IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        using IScreenDetailedInProcess screenDetailed = screenDetails.CurrentScreen;

        double devicePixelRatio = screenDetailed.DevicePixelRatio;
        labelOutput = devicePixelRatio.ToString();
    }

    public const string BUTTON_REGISTER_GET_IS_PRIMARY = "window-management-inprocess-get-is-primary";
    private async Task GetIsPrimary() {
        using IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        using IScreenDetailedInProcess screenDetailed = screenDetails.CurrentScreen;

        bool isPrimary = screenDetailed.IsPrimary;
        labelOutput = isPrimary.ToString();
    }

    public const string BUTTON_REGISTER_GET_IS_INTERNAL = "window-management-inprocess-get-is-internal";
    private async Task GetIsInternal() {
        using IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        using IScreenDetailedInProcess screenDetailed = screenDetails.CurrentScreen;

        bool isInternal = screenDetailed.IsInternal;
        labelOutput = isInternal.ToString();
    }


    public const string BUTTON_GET_WIDTH = "window-management-inprocess-get-width";
    private async Task GetWidth() {
        using IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        using IScreenDetailedInProcess screenDetailed = screenDetails.CurrentScreen;

        int width = screenDetailed.Width;
        labelOutput = width.ToString();
    }

    public const string BUTTON_GET_HEIGHT = "window-management-inprocess-get-height";
    private async Task GetHeight() {
        using IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        using IScreenDetailedInProcess screenDetailed = screenDetails.CurrentScreen;

        int height = screenDetailed.Height;
        labelOutput = height.ToString();
    }

    public const string BUTTON_GET_AVAIL_WIDTH = "window-management-inprocess-get-avail-width";
    private async Task GetAvailWidth() {
        using IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        using IScreenDetailedInProcess screenDetailed = screenDetails.CurrentScreen;

        int availWidth = screenDetailed.AvailWidth;
        labelOutput = availWidth.ToString();
    }

    public const string BUTTON_GET_AVAIL_HEIGHT = "window-management-inprocess-get-avail-height";
    private async Task GetAvailHeight() {
        using IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        using IScreenDetailedInProcess screenDetailed = screenDetails.CurrentScreen;

        int availHeight = screenDetailed.AvailHeight;
        labelOutput = availHeight.ToString();
    }

    public const string BUTTON_GET_COLOR_DEPTH = "window-management-inprocess-get-color-depth";
    private async Task GetColorDepth() {
        using IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        using IScreenDetailedInProcess screenDetailed = screenDetails.CurrentScreen;

        int colorDepth = screenDetailed.ColorDepth;
        labelOutput = colorDepth.ToString();
    }

    public const string BUTTON_GET_PIXEL_DEPTH = "window-management-inprocess-get-pixel-depth";
    private async Task GetPixelDepth() {
        using IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        using IScreenDetailedInProcess screenDetailed = screenDetails.CurrentScreen;

        int pixelDepth = screenDetailed.PixelDepth;
        labelOutput = pixelDepth.ToString();
    }

    public const string BUTTON_GET_IS_EXTENDED = "window-management-inprocess-get-is-extended";
    private async Task GetIsExtended() {
        using IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        using IScreenDetailedInProcess screenDetailed = screenDetails.CurrentScreen;

        bool isExtended = screenDetailed.IsExtended;
        labelOutput = isExtended.ToString();
    }


    public const string BUTTON_GET_ORIENTATION_TYPE = "window-management-inprocess-get-orientation-type";
    private async Task GetOrientationType() {
        using IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        using IScreenDetailedInProcess screenDetailed = screenDetails.CurrentScreen;

        string orientationType = screenDetailed.OrientationType;
        labelOutput = orientationType;
    }

    public const string BUTTON_GET_ORIENTATION_ANGLE = "window-management-inprocess-get-orientation-angle";
    private async Task GetOrientationAngle() {
        using IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        using IScreenDetailedInProcess screenDetailed = screenDetails.CurrentScreen;

        double angle = screenDetailed.OrientationAngle;
        labelOutput = angle.ToString();
    }


    public const string BUTTON_LOCK_ORIENTATION = "window-management-inprocess-lock-orientation";
    private async Task LockOrientation() {
        using IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        using IScreenDetailedInProcess screenDetailed = screenDetails.CurrentScreen;

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

    public const string BUTTON_UNLOCK_ORIENTATION = "window-management-inprocess-unlock-orientation";
    private async Task UnlockOrientation() {
        using IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        using IScreenDetailedInProcess screenDetailed = screenDetails.CurrentScreen;

        screenDetailed.UnlockOrientation();
        labelOutput = TEST_UNLOCK_ORIENTATION_RESULT;
    }


    public const string BUTTON_REGISTER_ON_CHANGE = "window-management-inprocess-change-event";
    private async Task RegisterOnChange() {
        IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        IScreenDetailedInProcess screenDetailed = screenDetails.CurrentScreen;
        screenDetailed.OnChange += OnChange;

        void OnChange() {
            labelOutput = TEST_CHANGE_EVENT;
            StateHasChanged();
            screenDetailed.OnChange -= OnChange;
            screenDetails.Dispose();
            screenDetailed.Dispose();
        }
    }

    public const string BUTTON_REGISTER_ON_ORIENTATION_CHANGE = "window-management-inprocess-orientation-change-event";
    private async Task RegisterOnOrientationChange() {
        IScreenDetailsInProcess screenDetails = await WindowManagement.GetScreenDetails();
        IScreenDetailedInProcess screenDetailed = screenDetails.CurrentScreen;
        screenDetailed.OnOrientationChange += OnOrientationChange;

        void OnOrientationChange() {
            labelOutput = TEST_ORIENTATION_CHANGE_EVENT;
            StateHasChanged();
            screenDetailed.OnOrientationChange -= OnOrientationChange;
            screenDetails.Dispose();
            screenDetailed.Dispose();
        }
    }

    #endregion
}
