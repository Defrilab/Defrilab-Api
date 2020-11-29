using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReaiotBackend.Models;
using ReaiotBackend.Models.DSAIL;
using ReaiotBackend.Models.FreeLearnModels;
using ReaiotBackend.Models.ReiotModels.TrackTileModels;
using ReaiotBackend.Models.TtnTest;

namespace ReaiotBackend.Data
{
    public class ReaiotDbContext :  IdentityDbContext<AppUser>
    {
        public ReaiotDbContext(DbContextOptions<ReaiotDbContext> dbContext) : base(dbContext)
        {

        }
        public  DbSet<TttnTestData>  TttnTestData { get; set; }
        #region Reaiot Fields
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ChangePassword> ChangePasswords { get; set; }
        public DbSet<Help> Help { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Office> Offices { get; set; }
        public  DbSet<Setting> Settings { get; set; }
        public  DbSet<TrackTileDevice>  Devices { get; set; }
        #endregion

        #region DSAIL DbSets
        public DbSet<CmappTask> CmappTasks { get; set; }
        public DbSet<CMappEmployee> CMappEmployees { get; set; }
        public DbSet<CMappHerbicide>  CMappHerbicides { get; set; }
        public  DbSet<CMappFertilizer>  CMappFertilizers { get; set; }
        public  DbSet<CMappSeedling>  CMappSeedlings { get; set; }
        public  DbSet<CmappMessage>  CmappMessages { get; set; }
        public DbSet<CmappTaskAssign> CmappTaskAssigns { get; set; }
        #endregion

        
        //will seed some users here as well, apart from the IdentityDbContext
    }

}
