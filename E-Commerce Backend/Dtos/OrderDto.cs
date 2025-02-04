using E_Commerce_Backend.Models;

namespace E_Commerce_Backend.Dtos
{
    public class OrderDto
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }

        //Relation With OrderDetailsDto
        public List<OrderDetailsDto> OrderDetailDto { get; set; }
    }
}
