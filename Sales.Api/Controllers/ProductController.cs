using Microsoft.AspNetCore.Mvc;
using Sales.Api.utils;
using Sales.Application.Dtos;
using Sales.Application.Interfaces;
using Sales.Application.Types;

namespace Sales.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/product")]
    public class ProductController: ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<ApiResponse<List<ProductDto>>>> GetsAll([FromQuery] int filter, [FromQuery] decimal minPrice, [FromQuery] decimal maxPrice, [FromQuery] int price, [FromQuery] int lenght = 10, [FromQuery] string category = "Toys")
        {
            var products = await _productService.GetProducts(minPrice, maxPrice, lenght, (decimal) price, category,  filter: (FILTER) filter);
            return Ok(ApiResponse<List<ProductDto>>.SuccessFul(data: products));
        }

    }
}
