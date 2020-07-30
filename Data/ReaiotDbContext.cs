using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReaiotBackend.Models;

namespace ReaiotBackend.Data
{
    public class ReaiotDbContext :  IdentityDbContext<AppUser>
    {
        public ReaiotDbContext(DbContextOptions<ReaiotDbContext> dbContext) : 
                                                                  base(dbContext)
        {

        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Office> Offices { get; set; }

        //will seed some users here as well, apart from the IdentityDbContext
    }
   
}
