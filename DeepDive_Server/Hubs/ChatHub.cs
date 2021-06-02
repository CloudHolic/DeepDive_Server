using System.Threading.Tasks;
using DeepDive_Server.Hubs.Clients;
using Microsoft.AspNetCore.SignalR;
using DeepDive_Server.Models;

namespace DeepDive_Server.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(ChatMessage message)
        {
            await Clients.All.ReceiveMessage(message);
        }
    }
}
