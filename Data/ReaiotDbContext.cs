using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReaiotBackend.Models;
using ReaiotBackend.Models.FreeLearnModels;

namespace ReaiotBackend.Data
{
    public class ReaiotDbContext :  IdentityDbContext<AppUser>
    {
        public ReaiotDbContext(DbContextOptions<ReaiotDbContext> dbContext) : base(dbContext)
        {

        }
        public  DbSet<TttnTestData>  TttnTestData { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ChangePassword> ChangePasswords { get; set; }
        public DbSet<Help> Help { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Office> Offices { get; set; }
        public  DbSet<Setting> Settings { get; set; }
    }

}
