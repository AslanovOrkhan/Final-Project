using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace BackendProject.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;


		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		//private readonly IWebHostEnvironment _webHostEnvironment;
		public IActionResult Register()
		{
			if (User.Identity.IsAuthenticated)
				return BadRequest();
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
		{
			if (User.Identity.IsAuthenticated)
				return BadRequest();

			if (!ModelState.IsValid)
				return View();

			AppUser newUser = new()
			{
				Fullname = registerViewModel.Fullname,
				Email = registerViewModel.Email,
				UserName = registerViewModel.Username,
				IsActive = true,
			};
			var identityResult = await _userManager.CreateAsync(newUser, registerViewModel.Password);
			if (!identityResult.Succeeded)
			{
				foreach (var error in identityResult.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
				return View();
			}
			return RedirectToAction(nameof(Login));



			//await _userManager.AddToRoleAsync(newUser, RoleType.Member.ToString());

		}
		public IActionResult Login()
		{
			if (User.Identity.IsAuthenticated)
				return BadRequest();

			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			if (User.Identity.IsAuthenticated)
				return BadRequest();

			if (!ModelState.IsValid)
				return View();

			var user = await _userManager.FindByNameAsync(loginViewModel.Username);
			if (user is null)
			{
				ModelState.AddModelError("", "Username or password invalid");
				return View();
			}

			var signInResult = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, true);
			if (signInResult.IsLockedOut)
			{
				ModelState.AddModelError("", "Your account is blocked temporary");
				return View();
			}
			if (!signInResult.Succeeded)
			{
				ModelState.AddModelError("", "Username or password invalid");
				return View();
			}

			return RedirectToAction("Index", "Home");
		}
		public async Task<IActionResult> Logout()
		{
			if (!User.Identity.IsAuthenticated)
				return BadRequest();

			await _signInManager.SignOutAsync();
			return RedirectToAction(nameof(Login));
		}
	}
}
