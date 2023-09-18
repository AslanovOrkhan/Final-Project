using Microsoft.AspNetCore.Mvc;

namespace BackendProject.Controllers
{
	public class MenuController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
