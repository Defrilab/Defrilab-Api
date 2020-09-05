using ReaiotBackend.Data;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models.FreeLearnModels;

namespace ReaiotBackend.Repositories
{
    public class SettingRepository : BaseRepository<Setting>, ISettingRepository
    {
        public SettingRepository(ReaiotDbContext dbContext) : base(dbContext)
        {

        }
    }
}
