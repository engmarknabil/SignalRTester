using Microsoft.AspNetCore.SignalR;

public class ServerHub : Hub
{
    public override Task OnConnectedAsync()
    {
        Console.WriteLine($"Received connection {Context.ConnectionId}");
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine($"Connection {Context.ConnectionId} disconnected");
        return base.OnDisconnectedAsync(exception);
    }
}