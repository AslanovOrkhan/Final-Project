using Microsoft.AspNetCore.Mvc;

namespace BackendProject.Controllers
{
    public class ShopCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
