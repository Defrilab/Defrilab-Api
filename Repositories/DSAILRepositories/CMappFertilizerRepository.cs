using ReaiotBackend.Data;
using ReaiotBackend.IRepositories.IDSAILRepositories.IDSAILCMappRepositories;
using ReaiotBackend.Models.DSAIL;

namespace ReaiotBackend.Repositories.DSAILRepositories
{
    public class CMappFertilizerRepository : BaseRepository<CMappFertilizer>, ICmappFertilizerRepository
    {
        public CMappFertilizerRepository(ReaiotDbContext reaiotDb): base(reaiotDb)
        {

        }
    }
}
