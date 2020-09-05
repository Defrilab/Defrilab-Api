using ReaiotBackend.Data;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models;

namespace ReaiotBackend.Repositories
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(ReaiotDbContext dbContext) : base(dbContext)
        {

        }
    }
}
