using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Backend.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public string PaymentMethod { get; set; }

        //Relation With Order
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
