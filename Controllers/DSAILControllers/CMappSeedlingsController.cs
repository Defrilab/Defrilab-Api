using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReaiotBackend.IRepositories.IDSAILRepositories.IDSAILCMappRepositories;
using ReaiotBackend.Models.DSAIL;

namespace ReaiotBackend.Controllers.DSAILControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CMappSeedlingsController : BaseController<CMappSeedling>
    {
        public CMappSeedlingsController(ICmappSeedlingRepository seedlingRepository) : base(seedlingRepository)
        {

        }
    }
}
