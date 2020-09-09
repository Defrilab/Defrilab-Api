using Microsoft.AspNetCore.SignalR;
using ReaiotBackend.Models;
using System.Threading.Tasks;

namespace ReaiotBackend.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string  name, string message)
        {
            // this method broadcasts the message to all Clients
            await Clients.All.SendAsync("ReceiveMessage",  name, message);
        }

        public async Task SendFreeLearnMessage(AppUser appUser)
        {
            await Clients.All.SendAsync("ReceiveFreeLearnMessage", appUser);
        }
        public async Task SendReiotMobileMessage(AppUser appUser)
        {
            await Clients.All.SendAsync("SendReiotMobileMessage", appUser);
        }
        public async Task SendDevTrackMessage(AppUser appUser)
        {
            await Clients.All.SendAsync("ReceiveDevTrackMessage", appUser);
        }
        public async Task GroupMessage(string name, string message, string room)
        {
            await Clients.Group(room).SendAsync(name, message);
        }
        public Task JoinRoom(string roomName)
        {
            return  Groups.AddToGroupAsync(Context.ConnectionId ,roomName);
        }
        public Task LeaveRoom(string roomName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }
    }
}
