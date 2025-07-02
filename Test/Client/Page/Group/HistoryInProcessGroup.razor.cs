using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace BrowserAPI.Test.Client;

public sealed partial class HistoryInProcessGroup : ComponentBase {
    [Inject]
    public required IHistoryInProcess History { private get; init; }


    public const string LABEL_OUTPUT = "history-inprocess-output";
    private string labelOutput = string.Empty;


    public const string BUTTON_GET_LENGTH = "history-inprocess-get-length";
    public void GetLength() {
        int length = History.Length;
        labelOutput = length.ToString();
    }

    public const string BUTTON_GET_SCROLL_RESTORATION = "history-inprocess-get-scroll-restoration";
    public void GetScrollRestoration() {
        labelOutput = History.ScrollRestoration;
    }

    public const string BUTTON_SET_SCROLL_RESTORATION = "history-inprocess-set-scroll-restoration";
    public void SetScrollRestoration() {
        History.ScrollRestoration = "manual";
        labelOutput = History.ScrollRestoration;
        History.ScrollRestoration = "auto";
    }

    public const string BUTTON_GET_STATE = "history-inprocess-get-state";
    public void GetState() {
        object? state = History.State;
        labelOutput = state?.ToString() ?? "(null)";
    }


    public const string BUTTON_FORWARD = "history-inprocess-forward";
    public void Forward() {
        History.Forward();
    }

    public const string BUTTON_BACK = "history-inprocess-back";
    public void Back() {
        History.Back();
    }

    public const string BUTTON_GO = "history-inprocess-go";
    public void Go() {
        History.Go(0);
    }

    public const string BUTTON_PUSH_STATE = "history-inprocess-push-state";
    public void PushState() {
        History.PushState(null, "", "test");

        int length = History.Length;
        labelOutput = length.ToString();
    }

    public const string BUTTON_REPLACE_STATE = "history-inprocess-replace-state";
    public void ReplaceState() {
        History.ReplaceState(null, "", "test");

        int length = History.Length;
        labelOutput = length.ToString();
    }


    public const string BUTTON_REGISTER_ON_POP_STATE = "history-inprocess-register-on-pop-state";
    public void RegisterOnPopState() {
        History.OnPopState += (JsonElement? data) => {
            labelOutput = data?.ToString() ?? "(null)";
            StateHasChanged();
        };
    }
}
