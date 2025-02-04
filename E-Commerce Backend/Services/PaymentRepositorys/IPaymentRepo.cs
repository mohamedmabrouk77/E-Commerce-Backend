using E_Commerce_Backend.Dtos;

namespace E_Commerce_Backend.Services.PaymentRepositorys
{
    public interface IPaymentRepo
    {
        public void AddPayment(PaymentDto dto);
    }
}
