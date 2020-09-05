using ReaiotBackend.Data;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models;

namespace ReaiotBackend.Repositories
{
    public class HelpRepository : BaseRepository<Help>, IHelpRepository
    {
        public HelpRepository(ReaiotDbContext dbContext) : base(dbContext)
        {

        }
    }
}
