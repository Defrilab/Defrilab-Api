using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models.ReiotModels.TrackTileModels;

namespace ReaiotBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TrackTileDeviceController : BaseController<TrackTileDevice>
    {
        public TrackTileDeviceController(ITrackTileDeviceRepository trackTileDeviceRepository) : base(trackTileDeviceRepository)
        {

        }
    }
}
