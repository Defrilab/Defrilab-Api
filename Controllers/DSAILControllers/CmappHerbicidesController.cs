using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReaiotBackend.IRepositories.IDSAILRepositories.IDSAILCMappRepositories;
using ReaiotBackend.Models.DSAIL;

namespace ReaiotBackend.Controllers.DSAILControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CmappHerbicidesController : BaseController<CMappHerbicide>
    {
        public CmappHerbicidesController(ICMappHerbicideRepository herbicideRepository) : base(herbicideRepository)
        {

        }
    }
}
