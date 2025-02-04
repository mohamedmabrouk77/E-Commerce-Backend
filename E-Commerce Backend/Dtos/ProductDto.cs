using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Backend.Dtos
{
    public class ProductDto
    {
        [Required]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
