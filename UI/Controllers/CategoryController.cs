using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using UI.Dtos.CategoryDto;

namespace UI.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(CreateCategoryDto dto)
        {
            dto.categoryStatus = true;
            dto.categoryName = "Deneme";

            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44316/api/Categories", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return Ok(responseMessage);
            }
            return Ok(responseMessage);
        }
    }
}
