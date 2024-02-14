using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MyBlazorPwa.Shared.OfflinceIndication;

public partial class OfflineIndicator
{
    private IJSObjectReference? _module;

    private DotNetObjectReference<OfflineIndicator>? Instance { get; set; }

    private bool IsOnline { get; set; }

    [Inject] public required IJSRuntime JsRuntime { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _module ??= await JsRuntime!.InvokeAsync<IJSObjectReference>("import", "/Shared/OfflinceIndication/OfflineIndicator.razor.js");

            Instance ??= DotNetObjectReference.Create(this);
            if (_module != null) await _module.InvokeVoidAsync("listenOnline", Instance);
        }
    }

    [JSInvokable]
    public Task UpdateOnlineStatus(bool isOnline)
    {
        IsOnline = isOnline;
        StateHasChanged();
        return Task.CompletedTask;
    }
}