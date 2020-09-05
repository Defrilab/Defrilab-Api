using ReaiotBackend.Data;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models.DevTrackModels;

namespace ReaiotBackend.Repositories
{
    public class DevTrackLeaderRepository :BaseRepository<DevTrackLeader>, IDevTrackLeaderRepository
    {
        public DevTrackLeaderRepository(ReaiotDbContext dbContext) : base(dbContext)
        {

        }
    }
}
