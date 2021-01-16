using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models;
using System.Threading.Tasks;

namespace ReaiotBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class MessagesController : ControllerBase
    {
        private readonly  IMessagesRepository  _messagesRepository;
        public MessagesController(IMessagesRepository  messagesRepository)
        {
           _messagesRepository = messagesRepository;
        }

        [HttpGet("get")]
        public IActionResult GetMessages()
        {
            return Ok(_messagesRepository.GetMessages());
        }

        [HttpGet("get/{id}")]
        public IActionResult GetMessageById(int id)
        {
            var message = _messagesRepository.GetMessageById(id);
            if (message != null)
            {
                return Ok(message);
            }
            return NotFound();
        }

        [HttpPost("add")]
        public async Task<IActionResult> PostEmployee(Message message)
        {
            if (ModelState.IsValid)
            {
                await _messagesRepository.AddMessage(message);
                return Ok(message);
            }
            return BadRequest();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateMessage(Message  message)
        {
            if (ModelState.IsValid)
            {
                await _messagesRepository.UpdateMessage(message);
                return Ok(message);
            }
            return BadRequest();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var message = _messagesRepository.GetMessageById(id);
            if (message != null)
            {
                _messagesRepository.DeleteMessage(id);
                return Ok(message);
            }
            return NotFound();
        }
    }
}
