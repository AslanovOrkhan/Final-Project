﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class DashboardController : Controller
	{

		public IActionResult Index()
		{
			return View();
		}
		 
	}
}
