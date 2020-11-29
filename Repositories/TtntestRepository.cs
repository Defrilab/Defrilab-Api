using ReaiotBackend.Data;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models;
using System.Threading.Tasks;

namespace ReaiotBackend.Repositories
{
    public class TtntestRepository : ITtntestRepository
    {
        private readonly ReaiotDbContext _reaiotDbContext;
        public TtntestRepository(ReaiotDbContext reaiotDbContext)
        {
            _reaiotDbContext = reaiotDbContext;
        }
        public async  Task<TttnTestData> AddData(TttnTestData tttnTestData)
        {
            _reaiotDbContext.TttnTestData.Add(tttnTestData);
            await _reaiotDbContext.SaveChangesAsync();
            return tttnTestData;
        }
    }
}
