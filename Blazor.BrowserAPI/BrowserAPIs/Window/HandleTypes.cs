using BrowserAPI.Implementation;
using Microsoft.JSInterop;

namespace BrowserAPI;

/// <summary>
/// <para>
/// The return value of <see cref="IWindow.SetTimeout"/> or <see cref="IWindowInProcess.SetTimeout"/>.<br />
/// It can be used to call <see cref="IWindow.ClearTimeout"/> / <see cref="IWindowInProcess.ClearTimeout"/>.
/// </para>
/// <para>It contains the timeout id as well as the function handler.</para>
/// </summary>
public readonly struct TimeoutHandle {
    internal readonly int id;
    internal readonly DotNetObjectReference<WindowBase.VoidCallback> callback;
    internal TimeoutHandle(int id, DotNetObjectReference<WindowBase.VoidCallback> callback) => (this.id, this.callback) = (id, callback);

    /// <summary>
    /// <para>
    /// The setTimeout() method returns a positive integer (typically within the range of 1 to 2,147,483,647) that uniquely identifies the timer created by the call.
    /// This identifier, often referred to as a "timeout ID", can be passed to clearTimeout() to cancel the timer.
    /// </para>
    /// <para>
    /// Within the same global environment (e.g., a specific window or worker) the timeout ID is guaranteed not to be reused for any new timer as long as the original timer remains active.
    /// However, separate global environments maintain their own independent pools of timer IDs.
    /// </para>
    /// </summary>
    public int Id => id;

    /// <summary>
    /// The callback handler that was used as parameter on the <see cref="IWindow.SetTimeout"/> / <see cref="IWindowInProcess.SetTimeout"/> call.
    /// </summary>
    public Action Callback => callback.Value.HandlerValue;
}

/// <summary>
/// <para>
/// The return value of <see cref="IWindow.SetInterval"/> or <see cref="IWindowInProcess.SetInterval"/>.<br />
/// It can be used to call <see cref="IWindow.ClearInterval"/> / <see cref="IWindowInProcess.ClearInterval"/>.
/// </para>
/// <para>It contains the interval id as well as the function handler.</para>
/// </summary>
public readonly struct IntervalHandle {
    internal readonly int id;
    internal readonly DotNetObjectReference<WindowBase.VoidCallback> callback;
    internal IntervalHandle(int id, DotNetObjectReference<WindowBase.VoidCallback> callback) => (this.id, this.callback) = (id, callback);

    /// <summary>
    /// <para>
    /// The setInterval() method returns a positive integer (typically within the range of 1 to 2,147,483,647) that uniquely identifies the interval timer created by the call.
    /// This identifier, often referred to as an "interval ID", can be passed to clearInterval() to stop the repeated execution of the specified function.
    /// </para>
    /// <para>
    /// Within the same global environment (e.g., a particular window or worker), the interval ID is ensured to remain unique and is not reused for any new interval timer as long as the original timer is still active.
    /// However, different global environments maintain their own independent pools of interval IDs.
    /// </para>
    /// </summary>
    public int Id => id;

    /// <summary>
    /// The callback handler that was used as parameter on the <see cref="IWindow.SetInterval"/> / <see cref="IWindowInProcess.SetInterval"/> call.
    /// </summary>
    public Action Callback => callback.Value.HandlerValue;
}

/// <summary>
/// <para>
/// The return value of <see cref="IWindow.RequestAnimationFrame"/> or <see cref="IWindowInProcess.RequestAnimationFrame"/>.<br />
/// It can be used to call <see cref="IWindow.CancelAnimationFrame"/> / <see cref="IWindowInProcess.CancelAnimationFrame"/>.
/// </para>
/// <para>It contains the request id as well as the function handler.</para>
/// </summary>
public readonly struct AnimationFrameHandle {
    internal readonly ulong id;
    internal readonly DotNetObjectReference<WindowBase.AnimationFrameCallback> callback;
    internal AnimationFrameHandle(ulong id, DotNetObjectReference<WindowBase.AnimationFrameCallback> callback) => (this.id, this.callback) = (id, callback);

    /// <summary>
    /// The request ID that uniquely identifies the entry in the callback list.
    /// You should not make any assumptions about its value.
    /// You can pass this value to cancelAnimationFrame() to cancel the refresh callback request.
    /// </summary>
    public ulong Id => id;

    /// <summary>
    /// The callback handler that was used as parameter on the <see cref="IWindow.RequestAnimationFrame"/> / <see cref="IWindowInProcess.RequestAnimationFrame"/> call.
    /// </summary>
    public Action<double> Callback => callback.Value.HandlerValue;
}

/// <summary>
/// <para>
/// The return value of <see cref="IWindow.RequestIdleCallback"/> or <see cref="IWindowInProcess.RequestIdleCallback"/>.<br />
/// It can be used to call <see cref="IWindow.CancelIdleCallback"/> / <see cref="IWindowInProcess.CancelIdleCallback"/>.
/// </para>
/// <para>It contains the request id as well as the function handler.</para>
/// </summary>
public readonly struct IdleCallbackHandle {
    internal readonly ulong id;
    internal readonly DotNetObjectReference<WindowBase.VoidCallback> callback;
    internal IdleCallbackHandle(ulong id, DotNetObjectReference<WindowBase.VoidCallback> callback) => (this.id, this.callback) = (id, callback);

    /// <summary>
    /// An ID which can be used to cancel the callback by passing it into the cancelIdleCallback() method.
    /// </summary>
    public ulong Id => id;

    /// <summary>
    /// The callback handler that was used as parameter on the <see cref="IWindow.RequestIdleCallback"/> / <see cref="IWindowInProcess.RequestIdleCallback"/> call.
    /// </summary>
    public Action Callback => callback.Value.HandlerValue;
}
