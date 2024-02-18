using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Repositories.ProductRepository;

namespace RealEstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = _productRepository.GetAllProductsAsync();
            return Ok(products.Result);
        }
        [HttpGet("withcategory")]
        public async Task<IActionResult> GetAllProductsWithCategory()
        {
            var productsWithCategory = _productRepository.GetAllProductsWithCategoryAsync();
            return Ok(productsWithCategory.Result);
        }
    }
}
