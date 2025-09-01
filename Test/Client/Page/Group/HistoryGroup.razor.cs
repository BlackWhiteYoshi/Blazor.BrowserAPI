using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace BrowserAPI.Test.Client;

public sealed partial class HistoryGroup : ComponentBase {
    [Inject]
    public required IHistory History { private get; init; }


    public const string LABEL_OUTPUT = "history-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_GET_LENGTH_PROPERTY = "history-get-length-property";
    private async Task GetLength_Property() {
        int length = await History.Length;
        labelOutput = length.ToString();
    }

    public const string BUTTON_GET_LENGTH_METHOD = "history-get-length-method";
    private async Task GetLength_Method() {
        int length = await History.GetLength(default);
        labelOutput = length.ToString();
    }


    public const string BUTTON_GET_SCROLL_RESTORATION_PROPERTY = "history-get-scroll-restoration-property";
    private async Task GetScrollRestoration_Property() {
        labelOutput = await History.ScrollRestoration;
    }

    public const string BUTTON_GET_SCROLL_RESTORATION_METHOD = "history-get-scroll-restoration-method";
    private async Task GetScrollRestoration_Method() {
        labelOutput = await History.GetScrollRestoration(default);
    }

    public const string BUTTON_SET_SCROLL_RESTORATION = "history-set-scroll-restoration";
    private async Task SetScrollRestoration() {
        await History.SetScrollRestoration("manual");
        labelOutput = await History.ScrollRestoration;
        await History.SetScrollRestoration("auto");
    }


    public const string BUTTON_GET_STATE_PROPERTY = "history-get-state-property";
    private async Task GetState_Property() {
        object? state = await History.State;
        labelOutput = state?.ToString() ?? "(null)";
    }

    public const string BUTTON_GET_STATE_METHOD = "history-get-state-method";
    private async Task GetState_Method() {
        object? state = await History.GetState(default);
        labelOutput = state?.ToString() ?? "(null)";
    }



    public const string BUTTON_FORWARD = "history-forward";
    private async Task Forward() {
        await History.Forward();
    }

    public const string BUTTON_BACK = "history-back";
    private async Task Back() {
        await History.Back();
    }

    public const string BUTTON_GO = "history-go";
    private async Task Go() {
        await History.Go(0);
    }

    public const string BUTTON_PUSH_STATE = "history-push-state";
    private async Task PushState() {
        await History.PushState(null, "", "/test");

        int length = await History.Length;
        labelOutput = length.ToString();
    }

    public const string BUTTON_REPLACE_STATE = "history-replace-state";
    private async Task ReplaceState() {
        await History.ReplaceState(null, "", "/test");

        int length = await History.Length;
        labelOutput = length.ToString();
    }


    public const string BUTTON_REGISTER_ON_POP_STATE = "history-pop-state-event";
    private void RegisterOnPopState() {
        History.OnPopState += (JsonElement? data) => {
            labelOutput = data?.ToString() ?? "(null)";
            StateHasChanged();
        };
    }
}
