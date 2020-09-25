using ReaiotBackend.Data;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models.DSAIL;

namespace ReaiotBackend.Repositories
{
    public class CmappTasksRepository : BaseRepository<CmappTask>, ICmappTasksRepository
    {
        public CmappTasksRepository(ReaiotDbContext dbContext) : base(dbContext)
        {

        }
    }
}
