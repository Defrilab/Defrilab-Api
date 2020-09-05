using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models;

namespace ReaiotBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class MessageController : BaseController<Message>
    {
        public MessageController(IMessageRepository messageRepository) : base(messageRepository)
        {

        }
    }
}
