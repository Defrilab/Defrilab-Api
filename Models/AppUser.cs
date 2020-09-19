using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ReaiotBackend.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string ProfilePhotoPath { get; set; }
        public string NationalId { get; set; }
        public bool IsSignedIn { get; set; }
        public bool TermsAndConditionsChecked { get; set; }
        public string Institution { get; set; }
        public string StudyLevel { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string Role { get; set; }
        public string Project { get; set; }
    }
}
