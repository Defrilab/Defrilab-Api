using Microsoft.AspNetCore.SignalR;
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
