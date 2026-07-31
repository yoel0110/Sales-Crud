using Sales.Application.Dtos;
using Sales.Application.Types;


namespace Sales.Application.Interfaces
{
    public interface IProductService
    {
        public Task<List<ProductDto>> GetProducts(decimal minPrice, decimal maxPrice, int length = 0, decimal price = 0m, string category  = "Toys", FILTER filter = FILTER.LESS_THAN);
        
    }
}


