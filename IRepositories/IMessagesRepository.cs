using ReaiotBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReaiotBackend.IRepositories
{
    public interface IMessagesRepository
    {
        IEnumerable<Message> GetMessages();
        Message GetMessageById(int id);
        Task<Message> AddMessage(Message message);
        Task UpdateMessage(Message message);
        Task DeleteMessage(int id);
    }
}
