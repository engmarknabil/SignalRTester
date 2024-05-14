using Microsoft.AspNetCore.SignalR.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        var connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5046/test-server")
            .Build();


        connection.On("test-client", () =>
        {
            Console.WriteLine("Received message");
        });

        await connection.StartAsync();
        Console.WriteLine("Connected");

        Console.Read();
    }
}