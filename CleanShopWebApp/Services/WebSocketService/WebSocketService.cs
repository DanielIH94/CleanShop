
using Microsoft.JSInterop;

namespace CleanShopWebApp.Services.WebSocketService;

public class WebSocketService(IJSRuntime jsRuntime) : IWebSocketService
{
    public async Task ConnectAsync(string url)
    {
        await jsRuntime.InvokeVoidAsync("connect", url);
    }

    public async Task SendMessageAsync(string message)
    {
        await jsRuntime.InvokeVoidAsync("sendMessage", message);
    }
}
