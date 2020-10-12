using ReaiotBackend.Data;
using ReaiotBackend.IRepositories.IDSAILRepositories.IDSAILCMappRepositories;
using ReaiotBackend.Models.DSAIL;

namespace ReaiotBackend.Repositories.DSAILRepositories
{
    public class CMappHerbicideRepository : BaseRepository<CMappHerbicide>, ICMappHerbicideRepository
    {
        public CMappHerbicideRepository(ReaiotDbContext reaiotDb) : base(reaiotDb)
        {

        }
    }
}
