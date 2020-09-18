using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models.DSAIL;

namespace ReaiotBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CMappTasksController : BaseController<CmappTask>
    {
        public CMappTasksController(ICmappTasksRepository tasksRepository) : base(tasksRepository)
        {
            // will learn to do Eager Loading
        }
    }
}
