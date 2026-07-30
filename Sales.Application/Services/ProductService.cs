
using Sales.Application.Dtos;
using Sales.Application.Interfaces;

namespace Sales.Application.Services
{
    public class ProductService : IProductService
    {
        public Task<List<ProductDto>> GetProducts(int id = 0, decimal price = 0, string category = "Default")
        {
            throw new NotImplementedException();
        }
    }
}
