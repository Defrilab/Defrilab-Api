using Microsoft.AspNetCore.Mvc;
using ReaiotBackend.Data;
using ReaiotBackend.Dtos;
using ReaiotBackend.Services;

namespace ReaiotBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ReaiotDbContext _context;
       public ServicesController(ReaiotDbContext context)
        {
            _context = context;
        }
                
        [HttpPost("ResetPassword")]
        public  IActionResult PostChangePasswordDto([FromBody]ChangePasswordDto changePasswordDto)
        {
            if (ModelState.IsValid)
            {
                var code = EmailServices.SendEmailForPasswordRecoveryCode(changePasswordDto.Email);
                return  Ok(code);
            }
            return BadRequest($"Could not send password recovery code to user with email {changePasswordDto.Email}");
        }
    }
}
