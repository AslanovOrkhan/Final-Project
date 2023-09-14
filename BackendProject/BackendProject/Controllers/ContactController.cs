using Microsoft.AspNetCore.Mvc;

namespace BackendProject.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
