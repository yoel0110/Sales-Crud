using Sales.Domain.Entities;

namespace Sales.Infrastructure.Interfaces.Repositories
{
    public interface IProductRepository
    {
        public  void Add(Product product);
        public IQueryable Query();
        public void Update(Product product);
        public void Delete(Product product);
    }
}
