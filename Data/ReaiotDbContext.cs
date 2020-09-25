using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReaiotBackend.Models;
using ReaiotBackend.Models.DevTrackModels;
using ReaiotBackend.Models.DSAIL;
using ReaiotBackend.Models.FreeLearnModels;
using ReaiotBackend.Models.ReiotModels.TrackTileModels;

namespace ReaiotBackend.Data
{
    public class ReaiotDbContext :  IdentityDbContext<AppUser>
    {
        public ReaiotDbContext(DbContextOptions<ReaiotDbContext> dbContext) : base(dbContext)
        {

        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ChangePassword> ChangePasswords { get; set; }
        public DbSet<DevTrackLeader> Leaders { get; set; }
        public DbSet<DevTrackProject> Projects { get; set; }
        public DbSet<Help> Help { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Office> Offices { get; set; }
        public  DbSet<Setting> Settings { get; set; }
        public  DbSet<TrackTileDevice>  Devices { get; set; }

        #region DSAIL DbSets
        public DbSet<CmappTask> CmappTasks { get; set; }
        public DbSet<CMappEmployee> CMappEmployees { get; set; }
        #endregion

        //will seed some users here as well, apart from the IdentityDbContext
    }

}
