using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReaiotBackend.IRepositories.IDSAILRepositories.IDSAILCMappRepositories;
using ReaiotBackend.Models.DSAIL;

namespace ReaiotBackend.Controllers.DSAILControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CMappMessageController : BaseController<CmappMessage>
    {
        public CMappMessageController(ICmappMessageRepository messageRepository) : base(messageRepository)
        {

        }
    }
}
