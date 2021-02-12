using ReaiotBackend.Data;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReaiotBackend.Repositories
{
    public class  AppointmentRepository : IAppointmentRepository
    {
        private readonly ReaiotDbContext _reaiotDbContext;
        public AppointmentRepository(ReaiotDbContext reaiotDbContext)
        {
            _reaiotDbContext = reaiotDbContext;
        }

        public Task Add(Appointment meetBooking)
        {
            _reaiotDbContext.Add(meetBooking);
            return _reaiotDbContext.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            _reaiotDbContext.Remove(_reaiotDbContext.Appointments.Find(id));
            return _reaiotDbContext.SaveChangesAsync();
        }
        public Appointment GetById(int id)
        {
            return _reaiotDbContext.Appointments.Find(id);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _reaiotDbContext.Appointments;
        }

        public Task Update(Appointment meetBooking)
        {
            _reaiotDbContext.Update(meetBooking);
            return _reaiotDbContext.SaveChangesAsync();
        }
    }
}
