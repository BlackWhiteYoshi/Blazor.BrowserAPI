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
}
