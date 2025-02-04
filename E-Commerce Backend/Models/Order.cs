using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Backend.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }

        //Relation With Product
        public List<Product> Product { get; set; }

        //Relation With User
        public User User { get; set; }

        //Relation With OrderDetails
        public List<OrderDetails> OrderDetail { get; set; }

        //Relation With Payment
        public Payment Payment { get; set; }
    }
}
