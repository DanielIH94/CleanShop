namespace CleanShopWebAppPanel.Services.WebSocketService;

public interface IWebSocketService
{
    Task ConnectAsync(string url);
    Task SendMessageAsync(string message);
    Task ReceiveMessage(string message);
    void RegisterMessageHandler(Func<string, Task> messageHandler);
}
