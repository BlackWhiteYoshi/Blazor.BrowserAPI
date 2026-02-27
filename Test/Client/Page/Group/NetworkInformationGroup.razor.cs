using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class NetworkInformationGroup : ComponentBase {
    public const string MISSING_BROWSER_SUPPOERT = "(missing browser support)";
    public const string TEST_ONLINE_EVENT = "changed to online";
    public const string TEST_OFFLINE_EVENT = "changed to offline";
    public const string TEST_CHANGE_EVENT = "changed some network information";


    [Inject]
    public required INetworkInformation NetworkInformation { private get; init; }


    public const string OUTPUT = "network-information-output";
    private string output = string.Empty;


    public const string BUTTON_GET_ON_LINE_PROPERTY = "network-information-get-on-line-property";
    private async Task GetOnLine_Property() {
        bool online = await NetworkInformation.OnLine;
        output = online.ToString();
    }

    public const string BUTTON_GET_ON_LINE_METHOD = "network-information-get-on-line-method";
    private async Task GetOnLine_Method() {
        bool online = await NetworkInformation.GetOnLine(CancellationToken.None);
        output = online.ToString();
    }


    public const string BUTTON_GET_DOWNLINK_PROPERTY = "network-information-get-downlink-property";
    private async Task GetDownlink_Property() {
        double downlink = await NetworkInformation.Downlink;
        output = downlink.ToString();
    }

    public const string BUTTON_GET_DOWNLINK_METHOD = "network-information-get-downlink-method";
    private async Task GetDownlink_Method() {
        double downlink = await NetworkInformation.GetDownlink(CancellationToken.None);
        output = downlink.ToString();
    }

    public const string BUTTON_GET_DOWNLINK_MAX_PROPERTY = "network-information-get-downlink-max-property";
    private async Task GetDownlinkMax_Property() {
        double downlinkMax = await NetworkInformation.DownlinkMax;
        output = downlinkMax.ToString();
    }

    public const string BUTTON_GET_DOWNLINK_MAX_METHOD = "network-information-get-downlink-max-method";
    private async Task GetDownlinkMax_Method() {
        double downlinkMax = await NetworkInformation.GetDownlinkMax(CancellationToken.None);
        output = downlinkMax.ToString();
    }

    public const string BUTTON_GET_EFFECTIVE_TYPE_PROPERTY = "network-information-get-effective-type-property";
    private async Task GetEffectiveType_Property() {
        string effectiveType = await NetworkInformation.EffectiveType;
        output = effectiveType;
    }

    public const string BUTTON_GET_EFFECTIVE_TYPE_METHOD = "network-information-get-effective-type-method";
    private async Task GetEffectiveType_Method() {
        string effectiveType = await NetworkInformation.GetEffectiveType(CancellationToken.None);
        output = effectiveType;
    }

    public const string BUTTON_GET_TYPE_PROPERTY = "network-information-get-type-property";
    private async Task GetType_Property() {
        string type = await NetworkInformation.Type;
        output = type ?? MISSING_BROWSER_SUPPOERT;
    }

    public const string BUTTON_GET_TYPE_METHOD = "network-information-get-type-method";
    private async Task GetType_Method() {
        string type = await NetworkInformation.GetType(CancellationToken.None);
        output = type ?? MISSING_BROWSER_SUPPOERT;
    }

    public const string BUTTON_GET_RTT_PROPERTY = "network-information-get-rtt-property";
    private async Task GetRTT_Property() {
        int rtt = await NetworkInformation.RTT;
        output = rtt.ToString();
    }

    public const string BUTTON_GET_RTT_METHOD = "network-information-get-rtt-method";
    private async Task GetRTT_Method() {
        int rtt = await NetworkInformation.GetRTT(CancellationToken.None);
        output = rtt.ToString();
    }

    public const string BUTTON_GET_SAVE_DATA_PROPERTY = "network-information-get-save-data-property";
    private async Task GetSaveData_Property() {
        bool saveData = await NetworkInformation.SaveData;
        output = saveData.ToString();
    }

    public const string BUTTON_GET_SAVE_DATA_METHOD = "network-information-get-save-data-method";
    private async Task GetSaveData_Method() {
        bool saveData = await NetworkInformation.GetSaveData(CancellationToken.None);
        output = saveData.ToString();
    }


    public const string BUTTON_REGISTER_ON_ONLINE = "network-information-online-event";
    private void RegisterOnOnline() {
        NetworkInformation.OnOnline += () => {
            output = TEST_ONLINE_EVENT;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_OFFLINE = "network-information-offline-event";
    private void RegisterOnOffline() {
        NetworkInformation.OnOffline += () => {
            output = TEST_OFFLINE_EVENT;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CHANGE = "network-information-change-event";
    private void RegisterOnChange() {
        NetworkInformation.OnChange += () => {
            output = TEST_CHANGE_EVENT;
            StateHasChanged();
        };
    }
}
