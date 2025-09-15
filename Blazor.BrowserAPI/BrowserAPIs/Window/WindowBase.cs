using AutoInterfaceAttributes;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace BrowserAPI.Implementation;

[AutoInterface(Namespace = "BrowserAPI", Name = "IWindow")]
[AutoInterface(Namespace = "BrowserAPI", Name = "IWindowInProcess")]
#pragma warning disable CS1591 // Missing XML comment because AutoInterface must not generate XML comment
public abstract class WindowBase(IModuleManager moduleManager) {
#pragma warning restore CS1591 // Missing XML comment because AutoInterface must not generate XML comment
    private protected IModuleManager moduleManager = moduleManager;
    private protected IJSObjectReference? windowJS;


    /// <summary>
    /// <para>Contains a callback with no parameter and no return value.</para>
    /// <para>Used for <see cref="Window.SetTimeout"/>, <see cref="Window.SetInterval"/>, <see cref="Window.RequestIdleCallback"/> and <see cref="Window.QueueMicrotask"/>.</para>
    /// </summary>
    /// <param name="handler">callback function given as argument.</param>
    [method: DynamicDependency(nameof(Handler))]
    internal sealed class VoidCallback(Action handler) {
        public Action HandlerValue { get; set; } = handler;

        [JSInvokable]
        public void Handler() => HandlerValue();
    }

    /// <summary>
    /// <para>Contains a callback with a timestamp parameter and no return value.</para>
    /// <para>Used for <see cref="Window.RequestAnimationFrame"/>.</para>
    /// </summary>
    /// <param name="handler">callback function given as argument. The parameter is the timeStamp.</param>
    [method: DynamicDependency(nameof(Handler))]
    internal sealed class AnimationFrameCallback(Action<double> handler) {
        public Action<double> HandlerValue { get; set; } = handler;

        [JSInvokable]
        public void Handler(double timeStamp) => HandlerValue(timeStamp);
    }
}
