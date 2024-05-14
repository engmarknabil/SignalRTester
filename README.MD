# SignalRTester
This repo is used to reproduce an Azure SignalR issue.

## Description
The solution has a **Server** project and a **Client** project. The **Server** project has 2 launch settings that can be used to spin it up on ports **5046** and **5047**. The **Client** project establishes a connection to the **Server**, which Azure SignalR assigns to only one of the **Server** instances. At that point, only the **Server** instance that received that client connection is able to send messages to the client, and the other instance can not. You can try running more **Client** instances until one of them is connected to the other **Server** instance, and only then, that **Server** instance would be able to send messages to all clients.

## How to Run
1. Add **Azure:SignalR:ConnectionString** to user secrets in **Server** project
1. Open **Server** folder in a terminal and run: 
```dotnet run --launch-profile http1```
1. Open **Server** folder in another terminal and run: ```dotnet run --launch-profile http2```
1. Open **Client** folder in another terminal and run: ```dotnet run```
1. Open http://localhost:5046/swagger in the browser
1. Open http://localhost:5047/swagger in the browser
1. Use the **/send-signalr** endpoint in the swagger of both instances to reproduce the issue
