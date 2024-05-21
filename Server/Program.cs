using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR().AddAzureSignalR();

builder.Services.AddSingleton<ServerHub>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapHub<ServerHub>("/test-server");

var serverHub = app.Services.GetRequiredService<IHubContext<ServerHub>>();

app.MapGet("send-signalr", async () =>
{
    if (serverHub.Clients == null)
    {
        throw new ApplicationException($"{nameof(ServerHub)}.{nameof(ServerHub.Clients)} is null");
    }

    await serverHub.Clients.All.SendAsync("test-client");
});

app.Run();
