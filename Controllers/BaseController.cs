using Microsoft.AspNetCore.Mvc;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models;
using System.Threading.Tasks;

namespace  ReaiotBackend.Controllers
{
    public class BaseController<T> : Controller where T : BaseModel

    {
        protected IBaseRepository<T> _repository;
        public BaseController(IBaseRepository<T> repository)
        {
            _repository = repository;
        }
        [HttpGet("all")]
        public virtual IActionResult GetAll()
        {
            var entities = _repository.GetAll();
            return Ok(entities);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return Ok(entity);
        }

        [HttpPost("add")]
        public async virtual Task<IActionResult> Add([FromBody]T entity)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(entity);

                return Ok(entity);

            }
            return BadRequest(ModelState);
        }

        [HttpPut("update")]
        public virtual async Task<IActionResult> Update([FromBody]T entity)
        {
            if (ModelState.IsValid)
            {
                var entityExist = _repository.GetById(entity.Id, null);
                if (entityExist != null)
                {
                    entityExist = entity;
                    await _repository.UpdateAsync(entityExist);
                    return Ok(entityExist);
                }
                return NotFound($"Entity wih id {entity.Id}  not found");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("delete")]
        public virtual async Task<IActionResult> Delete([FromBody]T entity)
        {
            if (ModelState.IsValid)
            {
                var entityExist = await _repository.GetByIdAsync(entity.Id);
                if (entityExist != null)
                {
                    await _repository.DeleteAsync(entityExist);
                    return Ok(entityExist);
                }
                return NotFound("Entity not found");
            }
            return BadRequest(ModelState);
        }
    }
}
    