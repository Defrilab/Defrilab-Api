using Microsoft.AspNetCore.Mvc;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models.Services;
using System.Threading.Tasks;

namespace ReaiotBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class  MeetBookingController : ControllerBase
    {
        private readonly IMeetBookingRepository  _meetBookingRepository;
        public MeetBookingController(IMeetBookingRepository  meetBookingRepository)
        {
             _meetBookingRepository =  meetBookingRepository;
        }


        [HttpPost("add")]
        public async Task<ActionResult> Add(MeetBooking  meetBooking)
        {
            if (ModelState.IsValid)
            {
                await  _meetBookingRepository.Add(meetBooking);
                return Ok(meetBooking);
            }
            return BadRequest();
        }

        [HttpGet("all")]
        public ActionResult GetAll()
        {
            return Ok(_meetBookingRepository.GetAll());
        }

        [HttpGet("getbyid/{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_meetBookingRepository.GetById(id));
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update(MeetBooking  meetBooking)
        {
            if (ModelState.IsValid)
            {
                await _meetBookingRepository.Update(meetBooking);
                return Ok(meetBooking);
            }
            return BadRequest();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var help =  _meetBookingRepository.GetById(id);
            if (help != null)
            {
                _meetBookingRepository.Delete(id);
                return Ok(help);
            }
            return BadRequest();
        }
    }
}
