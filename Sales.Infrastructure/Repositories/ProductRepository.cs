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

        public async void Add(Product product)
        {
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
        }

        public async void Delete(Product product)
        {
            product.Stock = 0;
            _context.Update(product);
            await _context.SaveChangesAsync();
        }

        public IQueryable Query()
        {
            return _context.Products;
        }

        public async void Update(Product product)
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
