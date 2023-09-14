using Microsoft.AspNetCore.Mvc;

namespace BackendProject.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
