using E_Commerce_Backend.Dtos;
using E_Commerce_Backend.Services.OrderRepositorys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo _repo;
        public OrderController(IOrderRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult AddAllOrder([FromBody] OrderDto dto)
        {
            _repo.AddAllOrder(dto);
            if(dto ==  null)
            {
                return BadRequest("Enter Data Success");
            }
            return Accepted();  
        }

        [HttpGet("Get All Order")]
        public IActionResult GetAll()
        {
            var result = _repo.GetAllOrders();
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("Get All Order ById")]
        public IActionResult GetAllById(int id)
        {
            var result = _repo.GetById(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
