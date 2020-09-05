using ReaiotBackend.Data;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models;

namespace ReaiotBackend.Repositories
{
    public class ChangePasswordRepository : BaseRepository<ChangePassword>, IChangePasswordRepository
    {
        public ChangePasswordRepository(ReaiotDbContext dbContext) : base(dbContext)
        {

        }
    }
}
