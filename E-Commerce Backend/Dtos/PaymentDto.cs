namespace E_Commerce_Backend.Dtos
{
    public class PaymentDto
    {
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public string PaymentMethod { get; set; }

        public int OrderId { get; set; }
    }
}
