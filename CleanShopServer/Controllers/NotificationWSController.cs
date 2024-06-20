using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;

namespace CleanShopServer.Controllers;

public class NotificationWSController : ControllerBase
{
    private static ConcurrentDictionary<string, WebSocket> _connectedClients = new();

    [Route("/ws/notifications")]
    public async Task Get()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            var clientId = Guid.NewGuid().ToString();
            _connectedClients.TryAdd(clientId, webSocket);
            await HandleWebSocketAsync(clientId, webSocket);
        }
        else
        {
            HttpContext.Response.StatusCode = 400;
        }
    }

    private async Task HandleWebSocketAsync(string clientId, WebSocket webSocket)
    {
        var buffer = new byte[1024 * 4];
        var receiveResult = await webSocket.ReceiveAsync(
            new ArraySegment<byte>(buffer), CancellationToken.None);

        while (!receiveResult.CloseStatus.HasValue)
        {
            var receivedMessage = Encoding.UTF8.GetString(buffer, 0, receiveResult.Count);
            await SendMessageToAllClients(receivedMessage);

            receiveResult = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);
        }

        await webSocket.CloseAsync(
            receiveResult.CloseStatus.Value,
            receiveResult.CloseStatusDescription,
            CancellationToken.None);
    }

    private async Task SendMessageToAllClients(string message)
    {
        var buffer = Encoding.UTF8.GetBytes(message);

        foreach (var client in _connectedClients)
        {
            if (client.Value.State == WebSocketState.Open)
            {
                await client.Value.SendAsync(
                    new ArraySegment<byte>(buffer, 0, buffer.Length), 
                    WebSocketMessageType.Text, 
                    true, 
                    CancellationToken.None
                );
            }
        }
    }
}
