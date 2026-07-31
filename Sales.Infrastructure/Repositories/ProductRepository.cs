using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Interfaces.Repositories;

namespace Sales.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SalesCrudAppDbContext _context;
        public ProductRepository(SalesCrudAppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Product product)
        {
            try
            {
                var lastId = await  _context.Products.MaxAsync(p => (int?)p.ProductId) ?? 0;
                Console.WriteLine(lastId);
                product.ProductId = (int)lastId + 1;
                _context.Products.Add(product);
                _ = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
        }

        public async Task Delete(Product product)
        {
            product.Stock = 0;
            _context.Update(product);
             await _context.SaveChangesAsync();
        }

        public IQueryable<Product> Query()
        {
            return _context.Products;
        }

        public async Task Update(Product product)
        {
            try
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
        }
    }
}
