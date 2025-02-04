using E_Commerce_Backend.Dtos;

namespace E_Commerce_Backend.Services.ProductRepositorys
{
    public interface IProductRepo
    {
        public List<ProductDto> GetAllProduct();
        public ProductDto GetById(int id);
        public void AddProduct(ProductDto dto);
        public void UpdateProduct(ProductDto dto, int id);
        public void DeleteProduct(int id);
    }
}
