using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models;

namespace ReaiotBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ChangePasswordController : BaseController<ChangePassword>
    {
        public ChangePasswordController(IChangePasswordRepository changePasswordRepository) : base(changePasswordRepository)
        {

        }
    }
}
