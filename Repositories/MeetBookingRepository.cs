using ReaiotBackend.Data;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReaiotBackend.Repositories
{
    public class  MeetBookingRepository : IMeetBookingRepository
    {
        private readonly ReaiotDbContext _reaiotDbContext;
        public MeetBookingRepository(ReaiotDbContext reaiotDbContext)
        {
            _reaiotDbContext = reaiotDbContext;
        }

        public Task Add(MeetBooking meetBooking)
        {
            _reaiotDbContext.Add(meetBooking);
            return _reaiotDbContext.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            _reaiotDbContext.Remove(_reaiotDbContext.MeetBookings.Find(id));
            return _reaiotDbContext.SaveChangesAsync();
        }
        public MeetBooking GetById(int id)
        {
            return _reaiotDbContext.MeetBookings.Find(id);
        }

        public IEnumerable<MeetBooking> GetAll()
        {
            return _reaiotDbContext.MeetBookings;
        }

        public Task Update(MeetBooking meetBooking)
        {
            _reaiotDbContext.Update(meetBooking);
            return _reaiotDbContext.SaveChangesAsync();
        }
    }
}
