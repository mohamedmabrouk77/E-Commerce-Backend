using E_Commerce_Backend.Dtos;
using E_Commerce_Backend.Services.PaymentRepositorys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepo _repo;

        public PaymentController(IPaymentRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult AddPayment(PaymentDto dto)
        {
            _repo.AddPayment(dto);
            if(dto ==  null)
            {
                return BadRequest("Enter Data Success");
            }
            return Accepted();
        }
    }
}
