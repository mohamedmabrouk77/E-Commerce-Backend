using E_Commerce_Backend.AppDbContext;
using E_Commerce_Backend.Dtos;
using E_Commerce_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Backend.Services.PaymentRepositorys
{
    public class PaymentRepo : IPaymentRepo
    {
        private readonly dbcontext _context;

        public PaymentRepo(dbcontext context)
        {
            _context = context;
        }

        public void AddPayment(PaymentDto dto)
        {
            var order = _context.Orders.Include(o => o.Payment).FirstOrDefault(o => o.OrderId == dto.OrderId);

            if (order == null || order.Status == "Paid")
            {
               throw new Exception("Order not found or already paid");
            }
            var result = new Payment
            {
                PaymentDate = dto.PaymentDate,
                PaymentAmount = dto.PaymentAmount,
                PaymentMethod = dto.PaymentMethod,
                OrderId = order.OrderId,
            };
            _context.Payments.Add(result);
            _context.SaveChanges();
        }
    }
}
