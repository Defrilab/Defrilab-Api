using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models.DevTrackModels;

namespace ReaiotBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class DevTrackProjectController : BaseController<DevTrackProject>
    {
        public DevTrackProjectController(IDevTrackProjectRepository devTrackProjectRepository) : base(devTrackProjectRepository)
        {

        }
    }
}
