using Microsoft.AspNetCore.SignalR;
using ReaiotBackend.Models.DSAIL;
using System.Threading.Tasks;

namespace ReaiotBackend.Hubs.DSAILHub
{
    public class CMappChatHub : Hub
    {
        public async Task CMappMessage(string name, CmappMessage message)
        {
            await Clients.All.SendAsync("CMappMessage", name, message);
        }
    }
}
