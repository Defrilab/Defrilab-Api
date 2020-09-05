using ReaiotBackend.Data;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models.ReiotModels.TrackTileModels;

namespace ReaiotBackend.Repositories
{
    public class TrackTileDeviceRepository : BaseRepository<TrackTileDevice>, ITrackTileDeviceRepository
    {
        public TrackTileDeviceRepository(ReaiotDbContext dbContext) : base(dbContext)
        {

        }
    }
}
