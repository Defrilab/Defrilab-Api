using ReaiotBackend.Data;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models.DevTrackModels;

namespace ReaiotBackend.Repositories
{
    public class DevTrackProjectRepository : BaseRepository<DevTrackProject>, IDevTrackProjectRepository
    {
        public DevTrackProjectRepository(ReaiotDbContext dbContext) : base(dbContext)
        {

        }
    }
}
