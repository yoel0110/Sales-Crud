
using Microsoft.EntityFrameworkCore;
using Sales.Application.Dtos;
using Sales.Application.Interfaces;
using Sales.Application.Types;
using Sales.Infrastructure.Interfaces.Repositories;
using Sales.Domain.Entities;

namespace Sales.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Update(ProductDto productDto)
        {
            var product = await _productRepository.Query()
                                                    .Include(p => p.Category)
                                                    .FirstOrDefaultAsync(
                                                        p => p.ProductId == productDto.ProductId
                                                    );
            if (product != null)
            {
                product.ProductName = productDto.ProductName;
                product.Price = productDto.Price;
                product.Stock = productDto.Stock;
                product.CategoryId = productDto.Category.Id;
               
               await _productRepository.Update(product);
            }
            return product;
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

        public async Task<Product> DeleteById(int id)
        {
            var product = await _productRepository.Query()
                                                    .Include(p => p.Category)
                                                    .FirstOrDefaultAsync(
                                                        p => p.ProductId == id
                                                    );
            if(product.ProductName.Length > 0 && product.ProductId != 0)
            {
                await _productRepository.Delete(product);
                return product;
            }
            return product;
        }

        public async Task<string> Create(ProductDto productDto)
        {
            var product = new Product
            {
                CategoryId = productDto.Category.Id,
                Price = productDto.Price,
                ProductName = productDto.ProductName,
                Stock = productDto.Stock,
                Category = null,
                OrderDetail = null
            };
           await _productRepository.Add(product);

            return $"{product.ProductId}";
        }
    }
}
