using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ReaiotBackend.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
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
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }
    }
}
