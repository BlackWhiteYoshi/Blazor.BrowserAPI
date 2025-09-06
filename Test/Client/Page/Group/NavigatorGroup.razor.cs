using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class NavigatorGroup : ComponentBase {
    public const string TEST_SHARE = "data shared";
    public const string TEST_SET_APP_BADGE = "app badge set";
    public const string TEST_CLEAR_APP_BADGE = "app badge cleared";
    public const string TEST_REGISTER_PROTOCOL_HANDLER = "protocol handler registered";
    public const string TEST_UNREGISTER_PROTOCOL_HANDLER = "unregistered protocol handler";
    public const string TEST_NO_INSTALLED_RELATED_APPS = "no installed related apps";


    [Inject]
    public required INavigator Navigator { private get; init; }

    [Inject] public required IElementFactory ElementFactory { private get; init; }
    private ElementReference audioElement;


    public const string LABEL_OUTPUT = "navigator-output";
    private string labelOutput = string.Empty;


    // Properties

    public const string BUTTON_GET_LANGUAGE_PROPERTY = "navigator-get-language-property";
    private async Task GetLanguage_Property() {
        string langauge = await Navigator.Language;
        labelOutput = langauge;
    }

    public const string BUTTON_GET_LANGUAGE_METHOD = "navigator-get-language-method";
    private async Task GetLanguage_Method() {
        string langauge = await Navigator.GetLanguage(default);
        labelOutput = langauge;
    }

    public const string BUTTON_GET_LANGUAGES_PROPERTY = "navigator-get-languages-property";
    private async Task GetLanguages_Property() {
        string[] langauges = await Navigator.Languages;
        labelOutput = string.Join(',', langauges);
    }

    public const string BUTTON_GET_LANGUAGES_METHOD = "navigator-get-languages-method";
    private async Task GetLanguages_Method() {
        string[] langauges = await Navigator.GetLanguages(default);
        labelOutput = string.Join(',', langauges);
    }


    public const string BUTTON_GET_USER_AGENT_PROPERTY = "navigator-get-user-agent-property";
    private async Task GetUserAgent_Property() {
        string langauge = await Navigator.UserAgent;
        labelOutput = langauge;
    }

    public const string BUTTON_GET_USER_AGENT_METHOD = "navigator-get-user-agent-method";
    private async Task GetUserAgent_Method() {
        string langauge = await Navigator.GetUserAgent(default);
        labelOutput = langauge;
    }

    public const string BUTTON_GET_WEBDRIVER_PROPERTY = "navigator-get-webdriver-property";
    private async Task GetWebdriver_Property() {
        bool webdriver = await Navigator.Webdriver;
        labelOutput = webdriver.ToString();
    }

    public const string BUTTON_GET_WEBDRIVER_METHOD = "navigator-get-webdriver-method";
    private async Task GetWebdriver_Method() {
        bool webdriver = await Navigator.GetWebdriver(default);
        labelOutput = webdriver.ToString();
    }


    public const string BUTTON_GET_USER_ACTIVATION_IS_ACTIVE_PROPERTY = "navigator-get-user-activation-is-active-property";
    private async Task GetUserActivationIsActive_Property() {
        bool userActivationIsActive = await Navigator.UserActivationIsActive;
        labelOutput = userActivationIsActive.ToString();
    }

    public const string BUTTON_GET_USER_ACTIVATION_IS_ACTIVE_METHOD = "navigator-get-user-activation-is-active-method";
    private async Task GetUserActivationIsActive_Method() {
        bool userActivationIsActive = await Navigator.GetUserActivationIsActive(default);
        labelOutput = userActivationIsActive.ToString();
    }

    public const string BUTTON_GET_USER_ACTIVATION_HAS_BEEN_ACTIVE_PROPERTY = "navigator-get-user-activation-has-been-active-property";
    private async Task GetUserActivationHasBeenActive_Property() {
        bool userActivationHasBeenActive = await Navigator.UserActivationHasBeenActive;
        labelOutput = userActivationHasBeenActive.ToString();
    }

    public const string BUTTON_GET_USER_ACTIVATION_HAS_BEEN_ACTIVE_METHOD = "navigator-get-user-activation-has-been-active-method";
    private async Task GetUserActivationHasBeenActive_Method() {
        bool userActivationHasBeenActive = await Navigator.GetUserActivationHasBeenActive(default);
        labelOutput = userActivationHasBeenActive.ToString();
    }


    public const string BUTTON_GET_COOKIE_ENABLED_PROPERTY = "navigator-get-cookie-enabled-property";
    private async Task GetCookieEnabled_Property() {
        bool cookieEnabled = await Navigator.CookieEnabled;
        labelOutput = cookieEnabled.ToString();
    }

    public const string BUTTON_GET_COOKIE_ENABLED_METHOD = "navigator-get-cookie-enabled-method";
    private async Task GetCookieEnabled_Method() {
        bool cookieEnabled = await Navigator.GetCookieEnabled(default);
        labelOutput = cookieEnabled.ToString();
    }

    public const string BUTTON_GET_PDF_VIEWER_ENABLED_PROPERTY = "navigator-get-pdf-viewer-enabled-property";
    private async Task GetPdfViewerEnabled_Property() {
        bool pdfViewerEnabled = await Navigator.PdfViewerEnabled;
        labelOutput = pdfViewerEnabled.ToString();
    }

    public const string BUTTON_GET_PDF_VIEWER_ENABLED_METHOD = "navigator-get-pdf-viewer-enabled-method";
    private async Task GetPdfViewerEnabled_Method() {
        bool pdfViewerEnabled = await Navigator.GetPdfViewerEnabled(default);
        labelOutput = pdfViewerEnabled.ToString();
    }


    public const string BUTTON_GET_MAX_TOUCH_POINTS_PROPERTY = "navigator-get-max-touch-points-property";
    private async Task GetMaxTouchPoints_Property() {
        int maxTouchPoints = await Navigator.MaxTouchPoints;
        labelOutput = maxTouchPoints.ToString();
    }

    public const string BUTTON_GET_MAX_TOUCH_POINTS_METHOD = "navigator-get-max-touch-points-method";
    private async Task GetMaxTouchPoints_Method() {
        int maxTouchPoints = await Navigator.GetMaxTouchPoints(default);
        labelOutput = maxTouchPoints.ToString();
    }

    public const string BUTTON_GET_HARDWARE_CONCURRENCY_PROPERTY = "navigator-get-hardware-concurrency-property";
    private async Task GetHardwareConcurrency_Property() {
        int hardwareConcurrency = await Navigator.HardwareConcurrency;
        labelOutput = hardwareConcurrency.ToString();
    }

    public const string BUTTON_GET_HARDWARE_CONCURRENCY_METHOD = "navigator-get-hardware-concurrency-method";
    private async Task GetHardwareConcurrency_Method() {
        int hardwareConcurrency = await Navigator.GetHardwareConcurrency(default);
        labelOutput = hardwareConcurrency.ToString();
    }

    public const string BUTTON_GET_DEVICE_MEMORY_PROPERTY = "navigator-get-device-memory-property";
    private async Task GetDeviceMemory_Property() {
        double deviceMemory = await Navigator.DeviceMemory;
        labelOutput = deviceMemory.ToString();
    }

    public const string BUTTON_GET_DEVICE_MEMORY_METHOD = "navigator-get-device-memory-method";
    private async Task GetDeviceMemory_Method() {
        double deviceMemory = await Navigator.GetDeviceMemory(default);
        labelOutput = deviceMemory.ToString();
    }



    public const string BUTTON_CAN_SHARE = "navigator-can-share";
    private async Task CanShare() {
        bool canShare = await Navigator.CanShare("https://localhost:5000/", "something", "News");
        labelOutput = canShare.ToString();
    }

    public const string BUTTON_SHARE = "navigator-share";
    private async Task Share() {
        await Navigator.Share("https://localhost:5000/", "something", "News");
        labelOutput = TEST_SHARE;
    }


    public const string BUTTON_SET_APP_BADGE = "navigator-set-app-badge";
    private async Task SetAppBadge() {
        await Navigator.SetAppBadge();
        labelOutput = TEST_SET_APP_BADGE;
    }

    public const string BUTTON_CLEAR_APP_BADGE = "navigator-clear-app-badge";
    private async Task ClearAppBadge() {
        await Navigator.ClearAppBadge();
        labelOutput = TEST_CLEAR_APP_BADGE;
    }


    public const string BUTTON_REGISTER_PROTOCOL_HANDLER = "navigator-register-protocol-handler";
    private async Task RegisterProtocolHandler() {
        await Navigator.RegisterProtocolHandler("web+test", "https://localhost:5000/%s");
        labelOutput = TEST_REGISTER_PROTOCOL_HANDLER;
    }

    public const string BUTTON_UNREGISTER_PROTOCOL_HANDLER = "navigator-unregister-protocol-handler";
    private async Task UnregisterProtocolHandler() {
        await Navigator.UnregisterProtocolHandler("web+test", "https://localhost:5000/%s");
        labelOutput = TEST_UNREGISTER_PROTOCOL_HANDLER;
    }


    public const string BUTTON_SEND_BEACON_STRING = "navigator-send-beacon-string";
    private async Task SendBeacon_String() {
        bool send = await Navigator.SendBeacon("https://localhost:5000/send-beacon-test", "null");
        labelOutput = send.ToString();
    }

    public const string BUTTON_SEND_BEACON_BYTES = "navigator-send-beacon-bytes";
    private async Task SendBeacon_Bytes() {
        bool send = await Navigator.SendBeacon("https://localhost:5000/send-beacon-test", [0, 1, 2]);
        labelOutput = send.ToString();
    }

    public const string BUTTON_VIBRATE = "navigator-vibrate";
    private async Task Vibrate() {
        bool vibrate = await Navigator.Vibrate([500, 250, 500]);
        labelOutput = vibrate.ToString();
    }


    public const string BUTTON_GET_AUTOPLAY_POLICY_STRING = "navigator-get-autoplay-policy-string";
    private async Task GetAutoplayPolicy_String() {
        string autoplayPolicy = await Navigator.GetAutoplayPolicy("mediaelement");
        labelOutput = autoplayPolicy;
    }

    public const string BUTTON_GET_AUTOPLAY_POLICY_ELEMENT = "navigator-get-autoplay-policy-element";
    private async Task GetAutoplayPolicy_Element() {
        await using IHTMLMediaElement audio = ElementFactory.CreateHTMLMediaElement(audioElement);
        string autoplayPolicy = await Navigator.GetAutoplayPolicy(audio);
        labelOutput = autoplayPolicy;
    }

    public const string BUTTON_GET_INSTALLED_RELATED_APPS = "navigator-get-installed-related-apps";
    private async Task GetInstalledRelatedApps() {
        InstalledRelatedApps[] installedRelatedApps = await Navigator.GetInstalledRelatedApps();
        labelOutput = installedRelatedApps.Length > 0 ? string.Join(',', installedRelatedApps) : TEST_NO_INSTALLED_RELATED_APPS;
    }
}
