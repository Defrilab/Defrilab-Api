using ReaiotBackend.Data;
using ReaiotBackend.IRepositories.IDSAILRepositories.IDSAILCMappRepositories;
using ReaiotBackend.Models.DSAIL;

namespace ReaiotBackend.Repositories.DSAILRepositories
{
    public class CMappSeedlingRepository : BaseRepository<CMappSeedling>, ICmappSeedlingRepository
    {
        public CMappSeedlingRepository( ReaiotDbContext reaiotDb) : base(reaiotDb)
        {

        }
    }
}
