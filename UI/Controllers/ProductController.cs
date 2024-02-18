using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.Dtos.ProductDto;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44316/api/Products");
            if (responseMessage != null)
            {
                var jsondata =await responseMessage.Content.ReadAsStringAsync();
                return Ok(jsondata);
            }
            return Ok();
        }
    }
}
