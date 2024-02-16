using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
	public class ProfileController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
