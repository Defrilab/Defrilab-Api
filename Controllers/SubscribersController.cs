using Microsoft.AspNetCore.Mvc;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models;
using System.Threading.Tasks;

namespace ReaiotBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SubscribersController : ControllerBase
    {
        private readonly  ISubscriberRepository _subscriberRepository;
        public SubscribersController(ISubscriberRepository subscriberRepository)
        {
            _subscriberRepository = subscriberRepository;
        }


        [HttpPost("add")]
        public async Task<ActionResult> Add(Subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
              await _subscriberRepository.Add(subscriber);
              return Ok(subscriber);
            }
            return BadRequest();
        }

        [HttpGet("all")]
        public ActionResult GetAll()
        {
            return Ok(_subscriberRepository.GetAll());
        }

        [HttpGet("getbyid/{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_subscriberRepository.GetById(id));
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update(Subscriber  subscriber)
        {
            if (ModelState.IsValid)
            {
                await _subscriberRepository.Update(subscriber);
                return Ok(subscriber);
            }
            return BadRequest();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var help = _subscriberRepository.GetById(id);
            if (help != null)
            {
                _subscriberRepository.Delete(id);
                return Ok(help);
            }
            return BadRequest();
        }
    }
}
