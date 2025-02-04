using E_Commerce_Backend.Dtos;
using E_Commerce_Backend.Services.ProductRepositorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Backend.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _repo;
        public ProductController(IProductRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("Get All Product")]
        public IActionResult GetAll()
        {
            var result = _repo.GetAllProduct();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("Get All Product ById")]
        public IActionResult GetById(int id)
        {
            var result = _repo.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductDto dto)
        {
            _repo.AddProduct(dto);
            if (dto == null)
            {
                return BadRequest("Enter All Data Success");
            }
            return Ok(new { Message = "Product Add Successfully" });
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] ProductDto dto, int id)
        {
            _repo.UpdateProduct(dto, id);
            if (dto == null)
            {
                return BadRequest("Enter Data & Id Success");
            }
            return Ok(new { Message = "Product Update Successfully" });
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            _repo.DeleteProduct(id);
            if (id == null)
            {
                return BadRequest("Enter Success Id");
            }
            return Ok(new { Message = "Product Delete Successfully" });
        }
    }
}
