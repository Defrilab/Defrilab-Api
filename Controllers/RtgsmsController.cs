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
            var device = new DeviceMessage()
            {
                Id = 0,
                Geophone_analog_value = rtgsmsObject.Geophone_analog_value,
                x_acc = rtgsmsObject.x_acc,
                Y_acc = rtgsmsObject.Y_acc,
                Z_acc = rtgsmsObject.Z_acc,
                Data = rtgsmsObject.Data,
                deviceTypeId = rtgsmsObject.deviceTypeId,
                Hum = rtgsmsObject.Hum,
                Temp = rtgsmsObject.Temp,
                Lat = rtgsmsObject.Lat,
                Device = rtgsmsObject.Device,
                Flags = rtgsmsObject.Flags,
                Ldr = rtgsmsObject.Ldr,
                Long = rtgsmsObject.Long,
                Time = rtgsmsObject.Time
            };
             
            _logger.LogInformation($"RTGSMS Notification: \r\n Received payload from \r\n device ID :{rtgsmsObject.Device}\n\t DeviceTypeId : {rtgsmsObject.deviceTypeId}, Time :{DateTime.Now.TimeOfDay}, data :{rtgsmsObject.Data}, Geophone Analog Value : {rtgsmsObject.Geophone_analog_value}");
            _rtgsmsRepository.AddRtgsmsDevice(device); 
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
