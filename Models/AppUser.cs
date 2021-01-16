using Microsoft.AspNetCore.Identity;

namespace ReaiotBackend.Models
{
    public class AppUser : IdentityUser
    {
        public string ProfilePhotoPath { get; set; }
        public bool IsSignedIn { get; set; }
        public bool TermsAndConditionsChecked { get; set; }
        public string Country { get; set; }
        public string Role { get; set; }
        public string Project { get; set; }
        public  string AuthKey { get; set; }
        public  Setting  Setting { get; set; }
    }
}
