using ReaiotBackend.Data;
using ReaiotBackend.IRepositories.IDSAILRepositories.IDSAILCMappRepositories;
using ReaiotBackend.Models.DSAIL;

namespace ReaiotBackend.Repositories.DSAILRepositories
{
    public class CMappMessageRepository : BaseRepository<CmappMessage>,  ICmappMessageRepository
    {
        public CMappMessageRepository(ReaiotDbContext reaiotDbContext) : base(reaiotDbContext)
        {

        }
    }
}
