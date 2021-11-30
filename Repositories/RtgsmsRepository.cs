using Microsoft.Extensions.Logging;
using ReaiotBackend.Data;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models.Rtgsms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReaiotBackend.Repositories
{
    public class RtgsmsRepository : IRtgsmsRepository
    {
        private readonly ReaiotDbContext _reaiotDbContext;
        private readonly ILogger<IRtgsmsRepository> _logger;
        public RtgsmsRepository(ReaiotDbContext reaiotDbContext, ILogger<IRtgsmsRepository> logger)
        {
            _reaiotDbContext = reaiotDbContext;
            _logger = logger;
        }       

        public Task AddRtgsmsDevice(RtgsmsSgfx rtgsmsObject)
        {
            var device = new DeviceMessage()
            {
                Id = 0,
                Geophone_analog_value = rtgsmsObject.Geophone_analog_value,
                x_acc = rtgsmsObject.x_acc,
                Y_acc = rtgsmsObject.Y_acc,
                Z_acc = rtgsmsObject.Z_acc,
                Data = rtgsmsObject.Data,
                deviceTypeId = rtgsmsObject.DeviceTypeId,
                Hum = rtgsmsObject.Hum,
                Temp = rtgsmsObject.Temp,
                Lat = rtgsmsObject.Lat,
                Device = rtgsmsObject.Device,
                Flags = rtgsmsObject.Flags,
                Ldr = rtgsmsObject.Ldr,
                Long = rtgsmsObject.Long,
                Time = rtgsmsObject.Time
            };
            _logger.LogInformation($"RTGSMS Notification:\r\n Received payload from device ID :{rtgsmsObject.DeviceTypeId}\n\t DeviceTypeId : {rtgsmsObject.Geophone_analog_value}, Time :{DateTime.Now.TimeOfDay}, data :{rtgsmsObject.Data}");
            _reaiotDbContext.Add(device);
            return _reaiotDbContext.SaveChangesAsync();
        }

        public Task DeleteRtgsmsDeviceById(int id)
        {
            _reaiotDbContext.Remove(_reaiotDbContext.DeviceMessage.Find(id));
            return _reaiotDbContext.SaveChangesAsync();
        }

        public IEnumerable<DeviceMessage> GetRtgsmsDevice()
        {
            return _reaiotDbContext.DeviceMessage;
        }

        public DeviceMessage GetRtgsmsDeviceById(int id)
        {
            return _reaiotDbContext.DeviceMessage.Find(id);
        }

        public Task UpdateRtgsmsDeviceById(DeviceMessage deviceMessage)
        {
            _reaiotDbContext.Update(deviceMessage);
            return _reaiotDbContext.SaveChangesAsync();
        }
    }
}
