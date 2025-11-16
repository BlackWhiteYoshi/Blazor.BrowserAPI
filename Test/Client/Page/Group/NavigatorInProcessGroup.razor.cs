using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class NavigatorInProcessGroup : ComponentBase {
    public const string TEST_SHARE = "data shared";
    public const string TEST_SET_APP_BADGE = "app badge set";
    public const string TEST_CLEAR_APP_BADGE = "app badge cleared";
    public const string TEST_REGISTER_PROTOCOL_HANDLER = "protocol handler registered";
    public const string TEST_UNREGISTER_PROTOCOL_HANDLER = "unregistered protocol handler";
    public const string TEST_NO_INSTALLED_RELATED_APPS = "no installed related apps";


    [Inject]
    public required INavigatorInProcess Navigator { private get; init; }

    [Inject] public required IElementFactoryInProcess ElementFactory { private get; init; }
    private ElementReference audioElement;


    public const string LABEL_OUTPUT = "navigator-inprocess-output";
    private string labelOutput = string.Empty;


    // Properties

    public const string BUTTON_GET_LANGUAGE = "navigator-inprocess-get-language";
    private void GetLanguage() {
        string langauge = Navigator.Language;
        labelOutput = langauge;
    }

    public const string BUTTON_GET_LANGUAGES = "navigator-inprocess-get-languages";
    private void GetLanguages() {
        string[] langauges = Navigator.Languages;
        labelOutput = string.Join(',', langauges);
    }


    public const string BUTTON_GET_USER_AGENT = "navigator-inprocess-get-user-agent";
    private void GetUserAgent() {
        string langauge = Navigator.UserAgent;
        labelOutput = langauge;
    }

    public const string BUTTON_GET_WEBDRIVER = "navigator-inprocess-get-webdriver";
    private void GetWebdriver() {
        bool webdriver = Navigator.Webdriver;
        labelOutput = webdriver.ToString();
    }


    public const string BUTTON_GET_USER_ACTIVATION_IS_ACTIVE = "navigator-inprocess-get-user-activation-is-active";
    private void GetUserActivationIsActive() {
        bool userActivationIsActive = Navigator.UserActivationIsActive;
        labelOutput = userActivationIsActive.ToString();
    }

    public const string BUTTON_GET_USER_ACTIVATION_HAS_BEEN_ACTIVE = "navigator-inprocess-get-user-activation-has-been-active";
    private void GetUserActivationHasBeenActive() {
        bool userActivationHasBeenActive = Navigator.UserActivationHasBeenActive;
        labelOutput = userActivationHasBeenActive.ToString();
    }


    public const string BUTTON_GET_COOKIE_ENABLED = "navigator-inprocess-get-cookie-enabled";
    private void GetCookieEnabled() {
        bool cookieEnabled = Navigator.CookieEnabled;
        labelOutput = cookieEnabled.ToString();
    }

    public const string BUTTON_GET_PDF_VIEWER_ENABLED = "navigator-inprocess-get-pdf-viewer-enabled";
    private void GetPdfViewerEnabled() {
        bool pdfViewerEnabled = Navigator.PdfViewerEnabled;
        labelOutput = pdfViewerEnabled.ToString();
    }


    public const string BUTTON_GET_MAX_TOUCH_POINTS = "navigator-inprocess-get-max-touch-points";
    private void GetMaxTouchPoints() {
        int maxTouchPoints = Navigator.MaxTouchPoints;
        labelOutput = maxTouchPoints.ToString();
    }

    public const string BUTTON_GET_HARDWARE_CONCURRENCY = "navigator-inprocess-get-hardware-concurrency";
    private void GetHardwareConcurrency() {
        int hardwareConcurrency = Navigator.HardwareConcurrency;
        labelOutput = hardwareConcurrency.ToString();
    }

    public const string BUTTON_GET_DEVICE_MEMORY = "navigator-inprocess-get-device-memory";
    private void GetDeviceMemory() {
        double deviceMemory = Navigator.DeviceMemory;
        labelOutput = deviceMemory.ToString();
    }



    public const string BUTTON_CAN_SHARE = "navigator-inprocess-can-share";
    private void CanShare() {
        bool canShare = Navigator.CanShare("https://localhost:5000/", "something", "News");
        labelOutput = canShare.ToString();
    }

    public const string BUTTON_SHARE = "navigator-inprocess-share";
    private async Task Share() {
        await Navigator.Share("https://localhost:5000/", "something", "News");
        labelOutput = TEST_SHARE;
    }


    public const string BUTTON_SET_APP_BADGE = "navigator-inprocess-set-app-badge";
    private async Task SetAppBadge() {
        await Navigator.SetAppBadge();
        labelOutput = TEST_SET_APP_BADGE;
    }

    public const string BUTTON_CLEAR_APP_BADGE = "navigator-inprocess-clear-app-badge";
    private async Task ClearAppBadge() {
        await Navigator.ClearAppBadge();
        labelOutput = TEST_CLEAR_APP_BADGE;
    }


    public const string BUTTON_REGISTER_PROTOCOL_HANDLER = "navigator-inprocess-register-protocol-handler";
    private void RegisterProtocolHandler() {
        Navigator.RegisterProtocolHandler("web+test", "https://localhost:5000/%s");
        labelOutput = TEST_REGISTER_PROTOCOL_HANDLER;
    }

    public const string BUTTON_UNREGISTER_PROTOCOL_HANDLER = "navigator-inprocess-unregister-protocol-handler";
    private void UnregisterProtocolHandler() {
        Navigator.UnregisterProtocolHandler("web+test", "https://localhost:5000/%s");
        labelOutput = TEST_UNREGISTER_PROTOCOL_HANDLER;
    }


    public const string BUTTON_SEND_BEACON_STRING = "navigator-inprocess-send-beacon-string";
    private void SendBeacon_String() {
        bool send = Navigator.SendBeacon("https://localhost:5000/send-beacon-test", "null");
        labelOutput = send.ToString();
    }

    public const string BUTTON_SEND_BEACON_BYTES = "navigator-inprocess-send-beacon-bytes";
    private void SendBeacon_Bytes() {
        bool send = Navigator.SendBeacon("https://localhost:5000/send-beacon-test", [0, 1, 2]);
        labelOutput = send.ToString();
    }

    public const string BUTTON_VIBRATE = "navigator-inprocess-vibrate";
    private void Vibrate() {
        bool vibrate = Navigator.Vibrate([500, 250, 500]);
        labelOutput = vibrate.ToString();
    }


    public const string BUTTON_GET_AUTOPLAY_POLICY_STRING = "navigator-inprocess-get-autoplay-policy-string";
    private void GetAutoplayPolicy_String() {
        string autoplayPolicy = Navigator.GetAutoplayPolicy("mediaelement");
        labelOutput = autoplayPolicy;
    }

    public const string BUTTON_GET_AUTOPLAY_POLICY_ELEMENT = "navigator-inprocess-get-autoplay-policy-element";
    private void GetAutoplayPolicy_Element() {
        using IHTMLMediaElementInProcess audio = ElementFactory.CreateHTMLMediaElement(audioElement);
        string autoplayPolicy = Navigator.GetAutoplayPolicy(audio);
        labelOutput = autoplayPolicy;
    }

    public const string BUTTON_GET_INSTALLED_RELATED_APPS = "navigator-inprocess-get-installed-related-apps";
    private async Task GetInstalledRelatedApps() {
        InstalledRelatedApps[] installedRelatedApps = await Navigator.GetInstalledRelatedApps();
        labelOutput = installedRelatedApps.Length > 0 ? string.Join(',', installedRelatedApps) : TEST_NO_INSTALLED_RELATED_APPS;
    }
}
