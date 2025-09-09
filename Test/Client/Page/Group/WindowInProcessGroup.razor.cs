using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class WindowInProcessGroup : ComponentBase {
    public const string TEST_NAME = "somw window name";


    [Inject]
    public required IWindowInProcess Window { private get; init; }


    public const string LABEL_OUTPUT = "window-inprocess-output";
    private string labelOutput = string.Empty;


    // Properties

    public const string BUTTON_GET_INNER_WIDTH = "window-inprocess-get-inner-width";
    private void GetInnerWidth() {
        int innerWidth = Window.InnerWidth;
        labelOutput = innerWidth.ToString();
    }

    public const string BUTTON_GET_INNER_HEIGHT = "window-inprocess-get-inner-height";
    private void GetInnerHeight() {
        int innerHeight = Window.InnerHeight;
        labelOutput = innerHeight.ToString();
    }

    public const string BUTTON_GET_OUTER_WIDTH = "window-inprocess-get-outer-width";
    private void GetOuterWidth() {
        int outerWidth = Window.OuterWidth;
        labelOutput = outerWidth.ToString();
    }

    public const string BUTTON_GET_OUTER_HEIGHT = "window-inprocess-get-outer-height";
    private void GetOuterHeight() {
        int outerHeight = Window.OuterHeight;
        labelOutput = outerHeight.ToString();
    }

    public const string BUTTON_GET_DEVICE_PIXEL_RATIO = "window-inprocess-get-device-pixel-ratio";
    private void GetDevicePixelRatio() {
        double devicePixelRatio = Window.DevicePixelRatio;
        labelOutput = devicePixelRatio.ToString();
    }


    public const string BUTTON_GET_SCROLL_X = "window-inprocess-get-scroll-x";
    private void GetScrollX() {
        double scrollX = Window.ScrollX;
        labelOutput = scrollX.ToString();
    }

    public const string BUTTON_GET_SCROLL_Y = "window-inprocess-get-scroll-y";
    private void GetScrollY() {
        double scrollY = Window.ScrollY;
        labelOutput = scrollY.ToString();
    }

    public const string BUTTON_GET_SCREEN_X = "window-inprocess-get-screen-x";
    private void GetScreenX() {
        int screenX = Window.ScreenX;
        labelOutput = screenX.ToString();
    }

    public const string BUTTON_GET_SCREEN_Y = "window-inprocess-get-screen-y";
    private void GetScreenY() {
        int screenY = Window.ScreenY;
        labelOutput = screenY.ToString();
    }


    public const string BUTTON_GET_ORIGIN = "window-inprocess-get-origin";
    private void GetOrigin() {
        string origin = Window.Origin;
        labelOutput = origin;
    }

    public const string BUTTON_GET_NAME = "window-inprocess-get-name";
    private void GetName() {
        string name = Window.Name;
        labelOutput = name;
    }

    public const string BUTTON_SET_NAME = "window-inprocess-set-name";
    private void SetName() {
        Window.Name = TEST_NAME;
    }


    public const string BUTTON_GET_CLOSED = "window-inprocess-get-closed";
    private void GetClosed() {
        bool closed = Window.Closed;
        labelOutput = closed.ToString();
    }

    public const string BUTTON_GET_CREDENTIALLESS = "window-inprocess-get-credentialless";
    private void GetCredentialless() {
        bool credentialless = Window.Credentialless;
        labelOutput = credentialless.ToString();
    }

    public const string BUTTON_GET_CROSS_ORIGIN_ISOLATED = "window-inprocess-get-cross-origin-isolated";
    private void GetCrossOriginIsolated() {
        bool crossOriginIsolated = Window.CrossOriginIsolated;
        labelOutput = crossOriginIsolated.ToString();
    }

    public const string BUTTON_GET_IS_SECURE_CONTEXT = "window-inprocess-get-is-secure-context";
    private void GetIsSecureContext() {
        bool isSecureContext = Window.IsSecureContext;
        labelOutput = isSecureContext.ToString();
    }

    public const string BUTTON_GET_ORIGIN_AGENT_CLUSTER = "window-inprocess-get-origin-agent-cluster";
    private void GetOriginAgentCluster() {
        bool originAgentCluster = Window.OriginAgentCluster;
        labelOutput = originAgentCluster.ToString();
    }

    public const string BUTTON_GET_MENUBAR = "window-inprocess-get-menubar";
    private void GetMenubar() {
        bool menubar = Window.Menubar;
        labelOutput = menubar.ToString();
    }


    public const string BUTTON_GET_FRAME_ELEMENT = "window-inprocess-get-frame-element";
    private void GetFrameElement() {
        using IHTMLElementInProcess? frameElement = Window.FrameElement;
        labelOutput = (frameElement is not null).ToString();
    }
}
