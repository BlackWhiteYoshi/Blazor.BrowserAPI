using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Test.Client;

public sealed partial class NetworkInformationInProcessGroup : ComponentBase {
    public const string MISSING_BROWSER_SUPPOERT = "(missing browser support)";
    public const string TEST_ONLINE_EVENT = "changed to online";
    public const string TEST_OFFLINE_EVENT = "changed to offline";
    public const string TEST_CHANGE_EVENT = "changed some network information";


    [Inject]
    public required INetworkInformation NetworkInformation { private get; init; }


    public const string OUTPUT = "network-information-inprocess-output";
    private string output = string.Empty;


    public const string BUTTON_GET_ON_LINE = "network-information-inprocess-get-on-line";
    private async Task GetOnLine() {
        bool online = await NetworkInformation.OnLine;
        output = online.ToString();
    }


    public const string BUTTON_GET_DOWNLINK = "network-information-inprocess-get-downlink";
    private async Task GetDownlink() {
        double downlink = await NetworkInformation.Downlink;
        output = downlink.ToString();
    }

    public const string BUTTON_GET_DOWNLINK_MAX = "network-information-inprocess-get-downlink-max";
    private async Task GetDownlinkMax() {
        double downlinkMax = await NetworkInformation.DownlinkMax;
        output = downlinkMax.ToString();
    }

    public const string BUTTON_GET_EFFECTIVE_TYPE = "network-information-inprocess-get-effective-type";
    private async Task GetEffectiveType() {
        string effectiveType = await NetworkInformation.EffectiveType;
        output = effectiveType;
    }

    public const string BUTTON_GET_TYPE = "network-information-inprocess-get-type";
    private new async Task GetType() {
        string type = await NetworkInformation.Type;
        output = type ?? MISSING_BROWSER_SUPPOERT;
    }

    public const string BUTTON_GET_RTT = "network-information-inprocess-get-rtt";
    private async Task GetRTT() {
        int rtt = await NetworkInformation.RTT;
        output = rtt.ToString();
    }

    public const string BUTTON_GET_SAVE_DATA = "network-information-inprocess-get-save-data";
    private async Task GetSaveData() {
        bool saveData = await NetworkInformation.SaveData;
        output = saveData.ToString();
    }


    public const string BUTTON_REGISTER_ON_ONLINE = "network-information-inprocess-online-event";
    private void RegisterOnOnline() {
        NetworkInformation.OnOnline += () => {
            output = TEST_ONLINE_EVENT;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_OFFLINE = "network-information-inprocess-offline-event";
    private void RegisterOnOffline() {
        NetworkInformation.OnOffline += () => {
            output = TEST_OFFLINE_EVENT;
            StateHasChanged();
        };
    }

    public const string BUTTON_REGISTER_ON_CHANGE = "network-information-inprocess-change-event";
    private void RegisterOnChange() {
        NetworkInformation.OnChange += () => {
            output = TEST_CHANGE_EVENT;
            StateHasChanged();
        };
    }
}
