using Microsoft.AspNetCore.Identity;

namespace ReaiotBackend.Models
{
    public class AppUser : IdentityUser
    {
        public  string  FirstName { get; set; }
        public  string  LastName { get; set; }
        public  string  NationalId { get; set; }
        public  string  Role { get; set; }
    }
}
