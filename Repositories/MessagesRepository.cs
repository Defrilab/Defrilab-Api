using ReaiotBackend.Data;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  ReaiotBackend.Repositories
{
    public class MessagesRepository : IMessagesRepository
    {
        private readonly ReaiotDbContext _reaiotDbContext;
        public MessagesRepository(ReaiotDbContext dbContext)
        {
            _reaiotDbContext = dbContext;
        }
        public async Task<Message> AddMessage(Message message)
        {
            _reaiotDbContext.Messages.Add(message);
            await _reaiotDbContext.SaveChangesAsync();
            return message;
        }

        public async Task DeleteMessage(int id)
        {
            _reaiotDbContext.Messages.Remove(_reaiotDbContext.Messages.Find(id));
            await _reaiotDbContext.SaveChangesAsync();            
        }

        public Message GetMessageById(int id)
        {
            return _reaiotDbContext.Messages.Where(m => m.Id == id).FirstOrDefault();
        }

        public IEnumerable<Message> GetMessages()
        {
            return _reaiotDbContext.Messages;
        }

        public async Task UpdateMessage(Message message)
        {
            _reaiotDbContext.Update(message);
            await _reaiotDbContext.SaveChangesAsync();
        }
    }
}
