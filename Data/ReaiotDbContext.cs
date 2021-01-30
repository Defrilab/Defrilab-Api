using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReaiotBackend.Models;

namespace ReaiotBackend.Data
{
    public class ReaiotDbContext :  IdentityDbContext<AppUser>
    {
        public ReaiotDbContext(DbContextOptions<ReaiotDbContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Help> Help { get; set; }
        public DbSet<Message> Messages { get; set; }
        public  DbSet<Setting> Settings { get; set; }
    }

}
