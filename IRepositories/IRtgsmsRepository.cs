using System.Collections.Generic;
using System.Threading.Tasks;
using ReaiotBackend.Models.Rtgsms;

namespace ReaiotBackend.IRepositories
{
    public interface IRtgsmsRepository
    {
        Task AddRtgsmsDevice(RtgsmsSgfx deviceMessage);
        IEnumerable<DeviceMessage> GetRtgsmsDevice();
        DeviceMessage GetRtgsmsDeviceById(int id);
        Task DeleteRtgsmsDeviceById(int id);
        Task UpdateRtgsmsDeviceById(DeviceMessage deviceMessage);
    }
}
