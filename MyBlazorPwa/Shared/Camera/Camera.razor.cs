using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Reflection;

namespace MyBlazorPwa.Shared.Camera;

public partial class Camera
{
    private IJSObjectReference? _module;

    [Inject] public required IJSRuntime JsRuntime { get; set; }

    protected override Task OnInitializedAsync()
    {
        return base.OnInitializedAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            _module ??= await JsRuntime!.InvokeAsync<IJSObjectReference>("import", "/Shared/Camera/Camera.razor.js");
    }

    private async Task StartCamera()
    {
        await _module!.InvokeVoidAsync("startCamera", "videoElement");
    }
}