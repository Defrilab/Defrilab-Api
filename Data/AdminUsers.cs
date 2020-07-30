using ReaiotBackend.Constants;
using ReaiotBackend.Models;
using System.Collections.Generic;

namespace ReaiotBackend.Data
{
    public static class AdminUsers
    {
        public static List<AppUser> Admins = new List<AppUser>()
        {
            new  AppUser() 
            {
                PasswordHash = "Isaac254", 
                UserName = "Isaac", 
                Email="isaaccherutich@gmail.com", 
                Role= Roles.Admin
            },
            new AppUser()  
            {
                PasswordHash = "Clinton254",
                UserName = "Clinton", 
                Email = "clintonoduor3@gmail.com",
                Role = Roles.Admin
            },
            new AppUser() 
            {
                PasswordHash = "Lilian254", 
                UserName = "Lilian", 
                Email = "lilianpatience97@outlook.com", 
                Role = Roles.Admin
            },
            new AppUser() 
            {
                PasswordHash = "2288Shiks.", 
                UserName = "Humphryshikunzi",
                Email = "humphry97@outlook.com",
                Role = Roles.Admin
            }
        };
           
    }
}
