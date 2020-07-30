using ReaiotBackend.Data;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models;

namespace ReaiotBackend.Repositories
{
    public class OfficeRepository : BaseRepository<Office>, IOfficeRepository
    {
        public OfficeRepository(ReaiotDbContext reaiotDbContext) : 
                                                     base(reaiotDbContext)
        {

        }
    }
}
