using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace BrowserAPI.Test.Client;

public sealed partial class HistoryInProcessGroup : ComponentBase {
    [Inject]
    public required IHistoryInProcess History { private get; init; }


    public const string LABEL_OUTPUT = "history-inprocess-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_GET_LENGTH = "history-inprocess-get-length";
    private void GetLength() {
        int length = History.Length;
        labelOutput = length.ToString();
    }

    public const string BUTTON_GET_SCROLL_RESTORATION = "history-inprocess-get-scroll-restoration";
    private void GetScrollRestoration() {
        labelOutput = History.ScrollRestoration;
    }

    public const string BUTTON_SET_SCROLL_RESTORATION = "history-inprocess-set-scroll-restoration";
    private void SetScrollRestoration() {
        History.ScrollRestoration = "manual";
        labelOutput = History.ScrollRestoration;
        History.ScrollRestoration = "auto";
    }

    public const string BUTTON_GET_STATE = "history-inprocess-get-state";
    private void GetState() {
        object? state = History.State;
        labelOutput = state?.ToString() ?? "(null)";
    }


    public const string BUTTON_FORWARD = "history-inprocess-forward";
    private void Forward() {
        History.Forward();
    }

    public const string BUTTON_BACK = "history-inprocess-back";
    private void Back() {
        History.Back();
    }

    public const string BUTTON_GO = "history-inprocess-go";
    private void Go() {
        History.Go(0);
    }

    public const string BUTTON_PUSH_STATE = "history-inprocess-push-state";
    private void PushState() {
        History.PushState(null, "", "test");

        int length = History.Length;
        labelOutput = length.ToString();
    }

    public const string BUTTON_REPLACE_STATE = "history-inprocess-replace-state";
    private void ReplaceState() {
        History.ReplaceState(null, "", "test");

        int length = History.Length;
        labelOutput = length.ToString();
    }


    public const string BUTTON_REGISTER_ON_POP_STATE = "history-inprocess-pop-state-event";
    private void RegisterOnPopState() {
        History.OnPopState += (JsonElement? data) => {
            labelOutput = data?.ToString() ?? "(null)";
            StateHasChanged();
        };
    }
}
