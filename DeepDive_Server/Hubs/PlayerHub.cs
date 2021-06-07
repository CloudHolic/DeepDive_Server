using System.Threading.Tasks;
using DeepDive_Server.Hubs.Clients;
using Microsoft.AspNetCore.SignalR;

namespace DeepDive_Server.Hubs
{
    public class PlayerHub : Hub<IPlayerClient>
    {
    }
}
