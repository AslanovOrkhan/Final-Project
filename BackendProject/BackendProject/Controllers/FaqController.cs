using Microsoft.AspNetCore.Mvc;

namespace BackendProject.Controllers
{
    public class FaqController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
