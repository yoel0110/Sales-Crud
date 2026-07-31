using Sales.Domain.Entities;

namespace Sales.Infrastructure.Interfaces.Repositories
{
    public interface IProductRepository
    {
        public  Task Add(Product product);
        public IQueryable<Product> Query();
        public Task Update(Product product);
        public Task Delete(Product product);
    }
}
