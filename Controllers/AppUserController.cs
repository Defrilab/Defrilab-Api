using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ReaiotBackend.Constants;
using ReaiotBackend.Data;
using ReaiotBackend.Dtos;
using ReaiotBackend.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace ReaiotBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UserController : Controller
    {
        #region fields
        private SignInManager<AppUser> _signInManager;
        private ReaiotDbContext  _ReaiotDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppSettings _appSettings;
        #endregion

        public UserController(SignInManager<AppUser> signInManager, ReaiotDbContext ReaiotDbContext, IOptions<AppSettings> appSettings, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _ReaiotDbContext = ReaiotDbContext;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]AppUser userEntity)
        {
            userEntity.TwoFactorEnabled = false;
            var result = await _signInManager.UserManager.CreateAsync(userEntity, userEntity.PasswordHash);
            if (result.Succeeded)
            {
                var user = await _signInManager.UserManager.FindByEmailAsync(userEntity.Email);
                await _signInManager.UserManager.AddToRoleAsync(user, user.Role);
                var token = GenerateJwtToken(user);
                return Ok(token);
            }
            return BadRequest($"Something went wrong, could not Register the User with email {userEntity.Email}");
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = Roles.Admin)]
        [HttpGet("getall")]
        public IActionResult GetUsers()
        {
            return Ok(_ReaiotDbContext.Users);
        }

        [HttpGet("get/{email}")]
        public IActionResult GetUser(string  email)
        {
            var user = _ReaiotDbContext.Users.FirstOrDefault(user => user.Email == email);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound($"User with email {email} not found in the database");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody]AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _userManager.Users.FirstOrDefault(u => u.Id == appUser.Id);
                if (existingUser != null)
                {
                    existingUser.Country = appUser.Country;
                    existingUser.County = appUser.County;
                    existingUser.DateOfBirth = appUser.DateOfBirth;
                    existingUser.Email = appUser.Email;
                    existingUser.FirstName = appUser.FirstName;
                    existingUser.Institution = appUser.Institution;
                    existingUser.IsSignedIn = appUser.IsSignedIn;
                    existingUser.LastName = appUser.LastName;
                    existingUser.NationalId = appUser.NationalId;
                    existingUser.PasswordHash = appUser.PasswordHash;
                    existingUser.ProfilePhotoPath = appUser.ProfilePhotoPath;
                    existingUser.Project = appUser.Project;
                    existingUser.PhoneNumber = appUser.PhoneNumber;
                    existingUser.Role = appUser.Role;
                    existingUser.TermsAndConditionsChecked = appUser.TermsAndConditionsChecked;
                    existingUser.StudyLevel = appUser.StudyLevel;
                    existingUser.UserName = appUser.UserName;
                   
                    var result = await _userManager.UpdateAsync(existingUser);
                    if (result.Succeeded)
                    {
                        return Ok(existingUser);
                    }
                    return Ok("User was changed, but unfortunately not saved");
                }
                return NotFound($"AppUser with email {appUser.Email} Not Found");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteUser(int id)
        {
            var user = _ReaiotDbContext.Users.FirstOrDefault(user => user.Id == id.ToString());
            if (user != null)
            {
                _ReaiotDbContext.Remove(user);
                _ReaiotDbContext.SaveChanges();
                return Ok(user);
            }
            return BadRequest($"Error, could not delete the user with id {id}. The user is not found in the system.");
        }

        [HttpPost("authenticateUser")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody]AuthAppUserDto authDto)
        {
            var user = await _signInManager.UserManager.FindByEmailAsync(authDto.Email);
            var result = await _signInManager.PasswordSignInAsync(user, authDto.Password, false, false);
            if (result.Succeeded)
            {
                 var token = GenerateJwtToken(user);
                return Ok(token);
            }
            return BadRequest("Username or passsword not correct");
        }
        private string GenerateJwtToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMonths(1);
            var token = new JwtSecurityToken("Reaiot.com", claims: claims, expires: expires, signingCredentials: creds);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
