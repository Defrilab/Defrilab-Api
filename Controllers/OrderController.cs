using Microsoft.AspNetCore.Mvc;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models.services;
using System.Threading.Tasks;

namespace ReaiotBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _ordersRepository;
        public OrdersController(IOrderRepository orderRepository)
        {
            _ordersRepository = orderRepository;
        }


        [HttpPost("add")]
        public async Task<ActionResult> Add(Order order)
        {
            if (ModelState.IsValid)
            {
                await _ordersRepository.Add(order);
                return Ok(order);
            }
            return BadRequest();
        }

        [HttpGet("all")]
        public ActionResult GetAll()
        {
            return Ok(_ordersRepository.GetAll());
        }

        [HttpGet("getbyid/{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_ordersRepository.GetById(id));
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update(Order order)
        {
            if (ModelState.IsValid)
            {
                await _ordersRepository.Update(order);
                return Ok(order);
            }
            return BadRequest();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var help = _ordersRepository.GetById(id);
            if (help != null)
            {
                _ordersRepository.Delete(id);
                return Ok(help);
            }
            return BadRequest();
        }
    }
}
