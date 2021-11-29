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

        public Task AddRtgsmsDevice(RtgsmsSgfx deviceMessage)
        {
            
            _logger.LogInformation($"RTGSMS Notification:\n Received payload from device ID :{deviceMessage.Device}\n\t DeviceTypeId : {deviceMessage.DeviceTypeId}, Time :{DateTime.Now.TimeOfDay}, data :{deviceMessage.Data}");
            //_reaiotDbContext.Add(deviceMessage);
            return _reaiotDbContext.SaveChangesAsync();
        }

        public Task AddRtgsmsDevice(DeviceMessage deviceMessage)
        {
            throw new NotImplementedException();
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
