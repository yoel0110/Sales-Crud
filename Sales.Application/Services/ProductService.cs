
using Microsoft.EntityFrameworkCore;
using Sales.Application.Dtos;
using Sales.Application.Interfaces;
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

        public async Task<List<ProductDto>> GetProducts(int length = 10, decimal price = 0, string category = "Default")
        {
            var products = await _productRepository.Query()
                                                        .Where
                                                            (p => p.Price == price
                                                                && p.Category.CategoryName == category
                                                            )
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
