using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private static IConfiguration Configuration;
        public ServicesController(ReaiotDbContext context, IConfiguration configuration)
        {
           _context = context;
            Configuration = configuration;
        }
                
        [HttpPost("ResetPassword")]
        public  IActionResult ChangePasswordDto([FromBody]ChangePasswordDto changePasswordDto)
        {
            if (ModelState.IsValid)
            {
                var code = EmailServices.SendEmailForPasswordRecoveryCode(changePasswordDto.Email);
                return  Ok(code);
            }
            return BadRequest();
        }       
    }
}
