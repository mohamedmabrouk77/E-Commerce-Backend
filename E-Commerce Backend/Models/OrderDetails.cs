using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Backend.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsId { get; set; }
        public int Quantity { get; set; }
        public decimal OrderDetailsPrice { get; set; }

        //Relation With Order
        public Order Order {  get; set; }
    }
}
