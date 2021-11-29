using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models.Rtgsms;
using System;
using System.Threading.Tasks;

namespace ReaiotBackend.Controllers
{
    public class RtgsmsController :  ControllerBase
    {
        private readonly IRtgsmsRepository _rtgsmsRepository;
        private readonly ILogger<IRtgsmsRepository> _logger;
        public RtgsmsController(IRtgsmsRepository rtgsmsRepository, ILogger<IRtgsmsRepository> logger)
        {
            _rtgsmsRepository = rtgsmsRepository;
            _logger = logger;
        }
        [HttpPost("add")]
        public async Task<ActionResult> Add(DeviceMessage deviceMessage)
        {
            await _rtgsmsRepository.AddRtgsmsDevice(deviceMessage);
            return Ok(deviceMessage);
            //return BadRequest();
        }

        [HttpPost("addRtgsmsObject")]
        public ActionResult AddRtgsmsMessage(RtgsmsSgfx rtgsmsObject)
        {
            var jsonObject = JsonConvert.SerializeObject(rtgsmsObject);
            _logger.LogInformation($"RTGSMS Notification: \r\n Received payload from \r\n device ID :{rtgsmsObject.Device}\n\t DeviceTypeId : {rtgsmsObject.DeviceTypeId}, Time :{DateTime.Now.TimeOfDay}, data :{rtgsmsObject.Data}");
            //_reaiotDbContext.Add(deviceMessage);
            _logger.LogInformation(jsonObject);
            return Ok();
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
