using Microsoft.AspNetCore.Mvc;

namespace BackendProject.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }
		public IActionResult Cart()
		{
			return View();
		}
        public IActionResult Checkout()
        {
            return View();
        }
	}
}
