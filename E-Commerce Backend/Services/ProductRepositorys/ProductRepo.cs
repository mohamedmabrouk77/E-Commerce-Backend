using E_Commerce_Backend.AppDbContext;
using E_Commerce_Backend.Dtos;
using E_Commerce_Backend.Models;

namespace E_Commerce_Backend.Services.ProductRepositorys
{
    public class ProductRepo : IProductRepo
    {
        private readonly dbcontext _context;

        public ProductRepo(dbcontext context)
        {
            _context = context;
        }

        public void AddProduct(ProductDto dto)
        {
            var result = new Product
            {
                ProductName = dto.ProductName,
                Price = dto.Price,
                Stock = dto.Stock,
            };
            _context.Products.Add(result);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var result = _context.Products.FirstOrDefault(x=>x.ProductId == id);
            if(result != null)
            {
                _context.Products.Remove(result);
            }
            else
            {
                throw new Exception("Id Not Found");
            }
            _context.SaveChanges();
        }

        public List<ProductDto> GetAllProduct()
        {
            var result = _context.Products.Select(x => new ProductDto
            {
                ProductName = x.ProductName,
                Price = x.Price,
                Stock = x.Stock,
            }).ToList();
            return result;
        }

        public ProductDto GetById(int id)
        {
            var result = _context.Products.FirstOrDefault(x=>x.ProductId == id);

            return new ProductDto
            {
                ProductName = result.ProductName,
                Price = result.Price,
                Stock = result.Stock,
            };
        }

        public void UpdateProduct(ProductDto dto, int id)
        {
            var result = _context.Products.FirstOrDefault(x=>x.ProductId==id);

            if( result != null )
            {
                result.ProductName = dto.ProductName;
                result.Price = dto.Price;
                result.Stock = dto.Stock;
            }
            else
            {
                throw new Exception("Id Not Found");
            }
            _context.Products.Update(result);
            _context.SaveChanges();
        }
    }
}
