using E_Commerce_Backend.Dtos;

namespace E_Commerce_Backend.Services.OrderRepositorys
{
    public interface IOrderRepo
    {
        public void AddAllOrder(OrderDto dto);
        public List<OrderDto> GetAllOrders();
        public OrderDto GetById(int id);
    }
}
