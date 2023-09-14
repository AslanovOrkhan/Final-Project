using Microsoft.AspNetCore.Mvc;

namespace BackendProject.Controllers
{
    public class ShopChecoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
