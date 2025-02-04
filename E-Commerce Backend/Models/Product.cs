using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Backend.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock {  get; set; }

        //Relation With Order
        public List<Order> Order { get; set; }

        //Relation With Category
        public Category Category { get; set; }
    }
}
