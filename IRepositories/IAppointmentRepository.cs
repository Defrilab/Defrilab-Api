using ReaiotBackend.Models.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReaiotBackend.IRepositories
{
    public  interface IAppointmentRepository
    {
        Task Add(Appointment meetBooking);
        IEnumerable<Appointment> GetAll();
        Appointment GetById(int id);
        Task Delete(int id);
        Task Update(Appointment meetBooking);
    }
}
