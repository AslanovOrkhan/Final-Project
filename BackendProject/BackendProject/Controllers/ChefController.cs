using Microsoft.AspNetCore.Mvc;

namespace BackendProject.Controllers
{
	public class ChefController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
