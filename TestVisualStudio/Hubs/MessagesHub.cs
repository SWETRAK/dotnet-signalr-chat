using Microsoft.AspNetCore.SignalR;
using TestVisualStudio.Models.Dtos;

namespace TestVisualStudio.Hubs;

public class MessagesHub : Hub<IMessagesHub>
{
    public MessagesHub()
    {
    }

    public async Task SendMessages(OutgoingMessageDto message)
    {
        await Clients.All.ReceiveMessages(message);
    }
}

public interface IMessagesHub
{
    Task ReceiveMessages(OutgoingMessageDto message);
}

