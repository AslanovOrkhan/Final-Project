namespace BackendProject.Areas.Admin.Controllers
{
	public class ChefController : Controller
	{
		private readonly AppDbContext _appDbContext;

		public ChefController(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public IActionResult Index()
		{
			IEnumerable<Chef> chefs = _appDbContext.Chefs.AsEnumerable();

			return View(chefs);
		}
	}
}
