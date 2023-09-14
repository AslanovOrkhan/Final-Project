using Microsoft.AspNetCore.Mvc;

namespace BackendProject.Controllers
{
    public class BlogDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
