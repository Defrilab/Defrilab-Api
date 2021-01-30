using ReaiotBackend.Models.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReaiotBackend.IRepositories
{
    public  interface IMeetBookingRepository
    {
        Task Add(MeetBooking meetBooking);
        IEnumerable<MeetBooking> GetAll();
        MeetBooking GetById(int id);
        Task Delete(int id);
        Task Update(MeetBooking meetBooking);
    }
}
