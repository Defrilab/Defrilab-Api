using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReaiotBackend.IRepositories.IDSAILRepositories.IDSAILCMappRepositories;
using ReaiotBackend.Models.DSAIL;

namespace ReaiotBackend.Controllers.DSAILControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CMappTaskAssignController : BaseController<CmappTaskAssign>
    {
         public CMappTaskAssignController(ICMappTaskAssignsRepository cMappTaskAssignsRepository) : base(cMappTaskAssignsRepository)
        {

        }
    }
}
