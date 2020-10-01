using ReaiotBackend.Data;
using ReaiotBackend.IRepositories.IDSAILRepositories.IDSAILCMappRepositories;
using ReaiotBackend.Models.DSAIL;

namespace ReaiotBackend.Repositories.DSAILRepositories
{
    public class CMappTaskAssignsRepository : BaseRepository<CmappTaskAssign>, ICMappTaskAssignsRepository
    {
        public CMappTaskAssignsRepository(ReaiotDbContext reaiotDbContext) : base(reaiotDbContext)
        {

        }
    }
}
