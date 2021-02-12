using Microsoft.AspNetCore.Mvc;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models.Services;
using System.Threading.Tasks;

namespace ReaiotBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class  AppointmentsController : ControllerBase
    {
        private readonly IAppointmentRepository  _appointmentRepository;
        public AppointmentsController(IAppointmentRepository  meetBookingRepository)
        {
             _appointmentRepository =  meetBookingRepository;
        }


        [HttpPost("add")]
        public async Task<ActionResult> Add(Appointment  meetBooking)
        {
            if (ModelState.IsValid)
            {
                await  _appointmentRepository.Add(meetBooking);
                return Ok(meetBooking);
            }
            return BadRequest();
        }

        [HttpGet("all")]
        public ActionResult GetAll()
        {
            return Ok(_appointmentRepository.GetAll());
        }

        [HttpGet("getbyid/{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_appointmentRepository.GetById(id));
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update(Appointment  meetBooking)
        {
            if (ModelState.IsValid)
            {
                await _appointmentRepository.Update(meetBooking);
                return Ok(meetBooking);
            }
            return BadRequest();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var help =  _appointmentRepository.GetById(id);
            if (help != null)
            {
                _appointmentRepository.Delete(id);
                return Ok(help);
            }
            return BadRequest();
        }
    }
}
