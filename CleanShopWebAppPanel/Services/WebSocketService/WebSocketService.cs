
using Microsoft.JSInterop;

namespace CleanShopWebAppPanel.Services.WebSocketService;

public class WebSocketService(IJSRuntime jsRuntime) : IWebSocketService
{
    private readonly IJSRuntime _jsRuntime;
    private Func<string, Task> _messageHandler;

    public async Task ConnectAsync(string url)
    {
        await jsRuntime.InvokeVoidAsync("connect", url);
    }

    public async Task SendMessageAsync(string message)
    {
        await jsRuntime.InvokeVoidAsync("sendMessage", message);
    }

    public void RegisterMessageHandler(Func<string, Task> messageHandler)
    {
        _messageHandler = messageHandler;
    }

    [JSInvokable]
    public async Task ReceiveMessage(string message)
    {
        if (_messageHandler != null)
        {
            await _messageHandler.Invoke(message);
        }
    }
}
