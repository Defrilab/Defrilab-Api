using Microsoft.AspNetCore.SignalR;
using ReaiotBackend.Models.DSAIL;
using System.Threading.Tasks;

namespace ReaiotBackend.Hubs.DSAILHub
{
    public class CMappChatHub : Hub
    {
        public async Task SendCMappMessage(string name, CmappMessage message)
        {
            await Clients.All.SendAsync("ReceiveCMappMessage", name, message);
        }
    }
}
