using Microsoft.AspNetCore.Mvc;

namespace BackendProject.Controllers
{
    public class ChefsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
