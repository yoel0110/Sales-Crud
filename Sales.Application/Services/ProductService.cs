
using Microsoft.EntityFrameworkCore;
using Sales.Application.Dtos;
using Sales.Application.Interfaces;
using Sales.Application.Types;
using Sales.Infrastructure.Interfaces;
using Sales.Infrastructure.Interfaces.Repositories;

namespace Sales.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> GetProducts(decimal minPrice, decimal maxPrice, int length, decimal price,  string category = "Toys", FILTER filter = FILTER.LESS_THAN)
        {

            var query = _productRepository.Query();
            query = filter switch
            {
                FILTER.LESS_THAN => query.Where(p => p.Price < price),
                FILTER.MORE_THAN => query.Where(p => p.Price > price),
                FILTER.BETWEN => query.Where(p => p.Price >= minPrice && p.Price <= maxPrice),
                _ => query
            };
            var products = await query
                                .Take(length)
                                .Select
                                    (
                                        p =>
                                           new ProductDto
                                           {
                                            Category = new CategoryDto
                                                {
                                                    Id = p.CategoryId,
                                                    Name = p.Category.CategoryName
                                                },
                                           Price = p.Price,
                                           ProductId = p.ProductId,
                                           ProductName = p.ProductName,
                                           Stock = p.Stock
                                        }
                                    )
                                    .ToListAsync();
            return products;

        }


    }
}
