using System.Threading.Tasks;
using DeepDive_Server.Models;

namespace DeepDive_Server.Hubs.Clients
{
    public interface IChatClient
    {
        Task ReceiveMessage(ChatMessage message);
    }
}
