namespace CleanShopWebApp.Services.WebSocketService;

public interface IWebSocketService
{
    Task ConnectAsync(string url);
    Task SendMessageAsync(string message);
}
