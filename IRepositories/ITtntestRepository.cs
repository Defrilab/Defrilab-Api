using ReaiotBackend.Models;
using System.Threading.Tasks;

namespace ReaiotBackend.IRepositories
{
    public interface ITtntestRepository
    {
        Task<TttnTestData> AddData(TttnTestData tttnTestData);
    }
}
