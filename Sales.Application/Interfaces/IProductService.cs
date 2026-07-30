using Sales.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Application.Interfaces
{
    public interface IProductService
    {
        public Task<List<ProductDto>> GetProducts(int id = 0, decimal price = 0m, string category  = "Default");
        
    }
}
