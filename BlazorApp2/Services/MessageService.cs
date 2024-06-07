using BlazorDemo.Data;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorApp2.Services
{
    public class MessageService : IMessageService
    {
        HubConnection hubConnection;
        HttpClient client;

        public delegate void MessageEventHandler(string senderId,string receiverId,string message);

        public event MessageEventHandler OnReceiveMessage;
        public MessageService(HttpClient httpClient)
        {
            client = httpClient;
        }

        public async Task Initialize()
        {
            hubConnection = new HubConnectionBuilder()
            .WithUrl(client.BaseAddress + "chathub")
            .Build();

            hubConnection.On<string, string, string>("ReceiveMessage", (senderId, receiverId, message) =>
            {
                OnReceiveMessage?.Invoke(senderId, receiverId, message);
            });

            await hubConnection.StartAsync();

            if(hubConnection.State == HubConnectionState.Connected)
            {
                await hubConnection.SendAsync("SetConnection", Settings.UserId, hubConnection.ConnectionId);
            }

            hubConnection.Closed += HubConnection_Closed;
            hubConnection.Reconnected += HubConnection_Reconnected;
            hubConnection.Reconnecting += HubConnection_Reconnecting;
        }

        private Task HubConnection_Closed(Exception? arg)
        {
            throw new NotImplementedException();
        }

        private Task HubConnection_Reconnecting(Exception? arg)
        {
            throw new NotImplementedException();
        }

        private async Task HubConnection_Reconnected(string? ConnectionId)
        {
            await hubConnection.SendAsync("SetConnection", Settings.UserId, ConnectionId);
        }

        public async Task SendMessageToUser(string senderId, string receiverId, string message)
        {
            await hubConnection.SendAsync("SendMessageToUser", Settings.UserId, receiverId, message);
        }
    }

    public class MessageEventArgs
    {
    }
}
