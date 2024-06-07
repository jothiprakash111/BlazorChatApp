using static BlazorApp2.Services.MessageService;

namespace BlazorApp2.Services
{
    public interface IMessageService
    {
        event MessageEventHandler OnReceiveMessage;
        Task Initialize();
        Task SendMessageToUser(string senderId, string receiverId, string message);
    }
}
