using Microsoft.AspNetCore.Mvc;

namespace BackendProject.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
