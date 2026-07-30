
namespace Sales.Application.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public CategoryDto Category { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
