using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BrowserAPI.Test.ClientHost;

public sealed partial class Root {
    [Inject]
    public required IConfiguration Configuration { private get; init; }


    private IComponentRenderMode? renderMode;

    protected override void OnInitialized() {
        base.OnInitialized();

        bool preRender = bool.TryParse(Configuration["Prerender"], out bool value) switch {
            true /* value present */ => value,
            false /* default value */ => true
        };
        renderMode = (Configuration["RenderMode"], preRender) switch {
            ("auto", true) => RenderMode.InteractiveAuto,
            ("auto", false) => new InteractiveAutoRenderMode(prerender: false),
            ("webassembly", true) => RenderMode.InteractiveWebAssembly,
            ("webassembly", false) => new InteractiveWebAssemblyRenderMode(prerender: false),
            ("server", true) => RenderMode.InteractiveServer,
            ("server", false) => new InteractiveServerRenderMode(prerender: false),
            ("static", true) => null,
            _ => throw new Exception("Unreachable: all invalid states should be already handled at startup")
        };
    }
}
