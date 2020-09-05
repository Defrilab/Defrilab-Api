using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models.DevTrackModels;

namespace ReaiotBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class DevTrackLeaderController : BaseController<DevTrackLeader>
    {
        public DevTrackLeaderController(IDevTrackLeaderRepository devTrackLeaderRepository) : base(devTrackLeaderRepository)
        {

        }
    }
}
