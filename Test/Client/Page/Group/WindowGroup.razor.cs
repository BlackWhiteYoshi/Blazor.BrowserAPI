using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class WindowGroup : ComponentBase {
    public const string TEST_NAME = "somw window name";


    [Inject]
    public required IWindow Window { private get; init; }


    public const string LABEL_OUTPUT = "window-output";
    private string labelOutput = string.Empty;


    // Properties

    public const string BUTTON_GET_INNER_WIDTH_PROPERTY = "window-get-inner-width-property";
    private async Task GetInnerWidth_Property() {
        int innerWidth = await Window.InnerWidth;
        labelOutput = innerWidth.ToString();
    }

    public const string BUTTON_GET_INNER_WIDTH_METHOD = "window-get-inner-width-method";
    private async Task GetInnerWidth_Method() {
        int innerWidth = await Window.GetInnerWidth(default);
        labelOutput = innerWidth.ToString();
    }

    public const string BUTTON_GET_INNER_HEIGHT_PROPERTY = "window-get-inner-height-property";
    private async Task GetInnerHeight_Property() {
        int innerHeight = await Window.InnerHeight;
        labelOutput = innerHeight.ToString();
    }

    public const string BUTTON_GET_INNER_HEIGHT_METHOD = "window-get-inner-height-method";
    private async Task GetInnerHeight_Method() {
        int innerHeight = await Window.GetInnerHeight(default);
        labelOutput = innerHeight.ToString();
    }

    public const string BUTTON_GET_OUTER_WIDTH_PROPERTY = "window-get-outer-width-property";
    private async Task GetOuterWidth_Property() {
        int outerWidth = await Window.OuterWidth;
        labelOutput = outerWidth.ToString();
    }

    public const string BUTTON_GET_OUTER_WIDTH_METHOD = "window-get-outer-width-method";
    private async Task GetOuterWidth_Method() {
        int outerWidth = await Window.GetOuterWidth(default);
        labelOutput = outerWidth.ToString();
    }

    public const string BUTTON_GET_OUTER_HEIGHT_PROPERTY = "window-get-outer-height-property";
    private async Task GetOuterHeight_Property() {
        int outerHeight = await Window.OuterHeight;
        labelOutput = outerHeight.ToString();
    }

    public const string BUTTON_GET_OUTER_HEIGHT_METHOD = "window-get-outer-height-method";
    private async Task GetOuterHeight_Method() {
        int outerHeight = await Window.GetOuterHeight(default);
        labelOutput = outerHeight.ToString();
    }

    public const string BUTTON_GET_DEVICE_PIXEL_RATIO_PROPERTY = "window-get-device-pixel-ratio-property";
    private async Task GetDevicePixelRatio_Property() {
        double devicePixelRatio = await Window.DevicePixelRatio;
        labelOutput = devicePixelRatio.ToString();
    }

    public const string BUTTON_GET_DEVICE_PIXEL_RATIO_METHOD = "window-get-device-pixel-ratio-method";
    private async Task GetDevicePixelRatio_Method() {
        double devicePixelRatio = await Window.GetDevicePixelRatio(default);
        labelOutput = devicePixelRatio.ToString();
    }


    public const string BUTTON_GET_SCROLL_X_PROPERTY = "window-get-scroll-x-property";
    private async Task GetScrollX_Property() {
        double scrollX = await Window.ScrollX;
        labelOutput = scrollX.ToString();
    }

    public const string BUTTON_GET_SCROLL_X_METHOD = "window-get-scroll-x-method";
    private async Task GetScrollX_Method() {
        double scrollX = await Window.GetScrollX(default);
        labelOutput = scrollX.ToString();
    }

    public const string BUTTON_GET_SCROLL_Y_PROPERTY = "window-get-scroll-y-property";
    private async Task GetScrollY_Property() {
        double scrollY = await Window.ScrollY;
        labelOutput = scrollY.ToString();
    }

    public const string BUTTON_GET_SCROLL_Y_METHOD = "window-get-scroll-y-method";
    private async Task GetScrollY_Method() {
        double scrollY = await Window.GetScrollY(default);
        labelOutput = scrollY.ToString();
    }

    public const string BUTTON_GET_SCREEN_X_PROPERTY = "window-get-screen-x-property";
    private async Task GetScreenX_Property() {
        int screenX = await Window.ScreenX;
        labelOutput = screenX.ToString();
    }

    public const string BUTTON_GET_SCREEN_X_METHOD = "window-get-screen-x-method";
    private async Task GetScreenX_Method() {
        int screenX = await Window.GetScreenX(default);
        labelOutput = screenX.ToString();
    }

    public const string BUTTON_GET_SCREEN_Y_PROPERTY = "window-get-screen-y-property";
    private async Task GetScreenY_Property() {
        int screenY = await Window.ScreenY;
        labelOutput = screenY.ToString();
    }

    public const string BUTTON_GET_SCREEN_Y_METHOD = "window-get-screen-y-method";
    private async Task GetScreenY_Method() {
        int screenY = await Window.GetScreenY(default);
        labelOutput = screenY.ToString();
    }


    public const string BUTTON_GET_ORIGIN_PROPERTY = "window-get-origin-property";
    private async Task GetOrigin_Property() {
        string origin = await Window.Origin;
        labelOutput = origin;
    }

    public const string BUTTON_GET_ORIGIN_METHOD = "window-get-origin-method";
    private async Task GetOrigin_Method() {
        string origin = await Window.GetOrigin(default);
        labelOutput = origin;
    }

    public const string BUTTON_GET_NAME_PROPERTY = "window-get-name-property";
    private async Task GetName_Property() {
        string name = await Window.Name;
        labelOutput = name;
    }

    public const string BUTTON_GET_NAME_METHOD = "window-get-name-method";
    private async Task GetName_Method() {
        string name = await Window.GetName(default);
        labelOutput = name;
    }

    public const string BUTTON_SET_NAME = "window-set-name";
    private async Task SetName() {
        await Window.SetName(TEST_NAME);
    }


    public const string BUTTON_GET_CLOSED_PROPERTY = "window-get-closed-property";
    private async Task GetClosed_Property() {
        bool closed = await Window.Closed;
        labelOutput = closed.ToString();
    }

    public const string BUTTON_GET_CLOSED_METHOD = "window-get-closed-method";
    private async Task GetClosed_Method() {
        bool closed = await Window.GetClosed(default);
        labelOutput = closed.ToString();
    }

    public const string BUTTON_GET_CREDENTIALLESS_PROPERTY = "window-get-credentialless-property";
    private async Task GetCredentialless_Property() {
        bool credentialless = await Window.Credentialless;
        labelOutput = credentialless.ToString();
    }

    public const string BUTTON_GET_CREDENTIALLESS_METHOD = "window-get-credentialless-method";
    private async Task GetCredentialless_Method() {
        bool credentialless = await Window.GetCredentialless(default);
        labelOutput = credentialless.ToString();
    }

    public const string BUTTON_GET_CROSS_ORIGIN_ISOLATED_PROPERTY = "window-get-cross-origin-isolated-property";
    private async Task GetCrossOriginIsolated_Property() {
        bool crossOriginIsolated = await Window.CrossOriginIsolated;
        labelOutput = crossOriginIsolated.ToString();
    }

    public const string BUTTON_GET_CROSS_ORIGIN_ISOLATED_METHOD = "window-get-cross-origin-isolated-method";
    private async Task GetCrossOriginIsolated_Method() {
        bool crossOriginIsolated = await Window.GetCrossOriginIsolated(default);
        labelOutput = crossOriginIsolated.ToString();
    }

    public const string BUTTON_GET_IS_SECURE_CONTEXT_PROPERTY = "window-get-is-secure-context-property";
    private async Task GetIsSecureContext_Property() {
        bool isSecureContext = await Window.IsSecureContext;
        labelOutput = isSecureContext.ToString();
    }

    public const string BUTTON_GET_IS_SECURE_CONTEXT_METHOD = "window-get-is-secure-context-method";
    private async Task GetIsSecureContext_Method() {
        bool isSecureContext = await Window.GetIsSecureContext(default);
        labelOutput = isSecureContext.ToString();
    }

    public const string BUTTON_GET_ORIGIN_AGENT_CLUSTER_PROPERTY = "window-get-origin-agent-cluster-property";
    private async Task GetOriginAgentCluster_Property() {
        bool originAgentCluster = await Window.OriginAgentCluster;
        labelOutput = originAgentCluster.ToString();
    }

    public const string BUTTON_GET_ORIGIN_AGENT_CLUSTER_METHOD = "window-get-origin-agent-cluster-method";
    private async Task GetOriginAgentCluster_Method() {
        bool originAgentCluster = await Window.GetOriginAgentCluster(default);
        labelOutput = originAgentCluster.ToString();
    }

    public const string BUTTON_GET_MENUBAR_PROPERTY = "window-get-menubar-property";
    private async Task GetMenubar_Property() {
        bool menubar = await Window.Menubar;
        labelOutput = menubar.ToString();
    }

    public const string BUTTON_GET_MENUBAR_METHOD = "window-get-menubar-method";
    private async Task GetMenubar_Method() {
        bool menubar = await Window.GetMenubar(default);
        labelOutput = menubar.ToString();
    }


    public const string BUTTON_GET_FRAME_ELEMENT_PROPERTY = "window-get-frame-element-property";
    private async Task GetFrameElement_Property() {
        await using IHTMLElement? frameElement = await Window.FrameElement;
        labelOutput = (frameElement is not null).ToString();
    }

    public const string BUTTON_GET_FRAME_ELEMENT_METHOD = "window-get-frame-element-method";
    private async Task GetFrameElement_Method() {
        await using IHTMLElement? frameElement = await Window.GetFrameElement(default);
        labelOutput = (frameElement is not null).ToString();
    }
}
