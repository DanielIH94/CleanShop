﻿
using Microsoft.JSInterop;

namespace CleanShopWebAppPanel.Services.WebSocketService;

public class WebSocketService(IJSRuntime jsRuntime) : IWebSocketService
{
    private Func<string, Task> _messageHandler;

    public async Task ConnectAsync(string url)
    {
        await jsRuntime.InvokeVoidAsync("connect", url);
    }

    public async Task SendMessageAsync(string message)
    {
        await jsRuntime.InvokeVoidAsync("sendMessage", message);
    }
}
