
namespace BackendProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.ToList();
            List<Service> services = _context.Services.ToList();
            List<Product> products = _context.Products.OrderByDescending(p => p.Rating).Take(4).ToList();
            List<Menu> menus = _context.Menus.OrderByDescending(p => p.CreatedAt).Take(2).ToList();


            HomeViewModel homeViewModel = new()
            {
                Sliders = sliders,
                Services = services,
                Products = products,
                Menus = menus
            };

            HttpContext.Session.SetString("name", "Orkhan");
            Response.Cookies.Append("surname", "Aslanov", new CookieOptions
            {
                MaxAge = TimeSpan.FromSeconds(30)
            });
            return View(homeViewModel);
        }
        public IActionResult Test()
        {
            var name = HttpContext.Session.GetString("name");
            var surname = Request.Cookies["surname"];
            return Content(name + " " + surname);
        }
    }
}
