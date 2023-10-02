using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BackendProject.Utils.Enums;

namespace BackendProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin,Moderator")]
	public class DashboardController : Controller
	{

		public IActionResult Index()
		{
			return View();
		}
		 
	}
}
