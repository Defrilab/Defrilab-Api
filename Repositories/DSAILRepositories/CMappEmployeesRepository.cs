using ReaiotBackend.Data;
using ReaiotBackend.IRepositories.IDSAILRepositories.IDSAILCMappRepositories;
using ReaiotBackend.Models.DSAIL;

namespace ReaiotBackend.Repositories.DSAILRepositories
{
    public class CMappEmployeesRepository : BaseRepository<CMappEmployee>,  ICMappEmployeesRepository
    {
        public CMappEmployeesRepository(ReaiotDbContext dbContext) : base(dbContext)
        {

        }
    }
}
