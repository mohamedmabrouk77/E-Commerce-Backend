using E_Commerce_Backend.AppDbContext;
using E_Commerce_Backend.Dtos;
using E_Commerce_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Backend.Services.OrderRepositorys
{
    public class OrderRepo : IOrderRepo
    {
        private readonly dbcontext _context;

        public OrderRepo(dbcontext context)
        {
            _context = context;
        }

        public void AddAllOrder(OrderDto dto)
        {
            var result = new Order
            {
                OrderDate = DateTime.UtcNow,
                TotalAmount = dto.TotalAmount,
                Status = dto.Status,
                OrderDetail = dto.OrderDetailDto.Select(x=> new OrderDetails
                {
                    OrderDetailsPrice = x.OrderDetailsPrice,
                    Quantity = x.Quantity,
                }).ToList(),
            };
            _context.Orders.Add(result);
            _context.SaveChanges();
        }

        public List<OrderDto> GetAllOrders()
        {
            var result = _context.Orders
                .Include(x=>x.OrderDetail)
                .Select(i=> new OrderDto
                {
                    OrderDate= DateTime.UtcNow,
                    TotalAmount = i.TotalAmount,
                    Status= i.Status,
                    OrderDetailDto = i.OrderDetail.Select(t => new OrderDetailsDto
                    {
                        OrderDetailsPrice= t.OrderDetailsPrice,
                        Quantity = t.Quantity,  
                    }).ToList(),
                }).ToList();
            return result;
        }

        public OrderDto GetById(int id)
        {
            var result = _context.Orders
                .Include(x=>x.OrderDetail)
                .FirstOrDefault(x=>x.OrderId == id);

            return new OrderDto
            {
                OrderDate = DateTime.UtcNow,
                TotalAmount = result.TotalAmount,
                Status= result.Status,  
                OrderDetailDto = result.OrderDetail.Select(i => new OrderDetailsDto
                {
                    OrderDetailsPrice = i.OrderDetailsPrice,
                    Quantity = i.Quantity,
                }).ToList(),
            };
        }
    }
}
