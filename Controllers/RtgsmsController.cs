using Microsoft.AspNetCore.Mvc;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models.Rtgsms;
using System.Threading.Tasks;

namespace ReaiotBackend.Controllers
{
    public class RtgsmsController :  ControllerBase
    {
        private readonly IRtgsmsRepository _rtgsmsRepository;
        public RtgsmsController(IRtgsmsRepository rtgsmsRepository)
        {
            _rtgsmsRepository = rtgsmsRepository;
        }
        [HttpPost("add")]
        public async Task<ActionResult> Add(DeviceMessage deviceMessage)
        {
            if (ModelState.IsValid)
            {
                await _rtgsmsRepository.AddRtgsmsDevice(deviceMessage);
                return Ok(deviceMessage);
            }
            return BadRequest();
        }

        [HttpGet("all")]
        public ActionResult GetAll()
        {
            return Ok(_rtgsmsRepository.GetRtgsmsDevice());
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
