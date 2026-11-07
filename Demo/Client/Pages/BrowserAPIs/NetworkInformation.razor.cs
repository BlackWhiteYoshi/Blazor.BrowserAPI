using Microsoft.AspNetCore.Components;

namespace BrowserAPI.Demo.Client;

public sealed partial class NetworkInformation : ComponentBase {
    [Inject]
    public required INetworkInformation PNetworkInformation { private get; init; }


    private bool? isConnected = null;
    private async Task GetOnLine() => isConnected = await PNetworkInformation.OnLine;

    private string connectionType = string.Empty;
    private new async Task GetType() => connectionType = await PNetworkInformation.Type ?? throw new Microsoft.JSInterop.JSException("");

    private string connectionKind = string.Empty;
    private async Task GetEffectiveType() => connectionKind = await PNetworkInformation.EffectiveType;

    private double? downloadBandwidth = null;
    private async Task GetDownlink() => downloadBandwidth = await PNetworkInformation.Downlink;

    private double? maxDownloadBandwidth = null;
    private async Task GetDownlinkMax() => maxDownloadBandwidth = await PNetworkInformation.DownlinkMax;

    private int? connectionLatency = null;
    private async Task GetRTT() => connectionLatency = await PNetworkInformation.RTT;

    private bool? reducedDataUsage = null;
    private async Task GetSaveData() => reducedDataUsage = await PNetworkInformation.SaveData;
}
