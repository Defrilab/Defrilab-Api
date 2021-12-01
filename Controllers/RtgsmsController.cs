using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models.Rtgsms;
using System.Threading.Tasks;

namespace ReaiotBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RtgsmsController :  ControllerBase
    {
        private readonly IRtgsmsRepository _rtgsmsRepository;
        private readonly ILogger<IRtgsmsRepository> _logger;
        public RtgsmsController(IRtgsmsRepository rtgsmsRepository, ILogger<IRtgsmsRepository> logger)
        {
            _rtgsmsRepository = rtgsmsRepository;
            _logger = logger;
        }

        [HttpPost("addRtgsmsObject")]
        public  async Task<ActionResult> AddRtgsmsMessage(RtgsmsSgfx rtgsmsObject)
        {
            await  _rtgsmsRepository.AddRtgsmsDevice(rtgsmsObject); 
            return Ok();
        }

        [HttpGet("all")]
        public ActionResult GetAll()
        {
            return Ok(_rtgsmsRepository.GetRtgsmsDevice());
        }
        [HttpGet("recentMessages")]
        public ActionResult GetRecent()
        {
            return Ok(_rtgsmsRepository.GetRecentMessages());
        }

        [HttpGet("getbyid/{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_rtgsmsRepository.GetRtgsmsDeviceById(id));
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update(DeviceMessage  deviceMessage)
        {
            if (ModelState.IsValid)
            {
                await _rtgsmsRepository.UpdateRtgsmsDeviceById(deviceMessage);
                return Ok(deviceMessage);
            }
            return BadRequest();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var help = _rtgsmsRepository.GetRtgsmsDeviceById(id);
            if (help != null)
            {
                _rtgsmsRepository.DeleteRtgsmsDeviceById(id);
                return Ok(help);
            }
            return BadRequest();
        }
    }
}
