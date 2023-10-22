using BackendProject.Helpers;
using BackendProject.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BackendProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ChefController : Controller
	{
		private readonly AppDbContext _appDbContext;
		private readonly UserManager<AppUser> _userManager;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public ChefController(AppDbContext appDbContext,
			IWebHostEnvironment webHostEnvironment,
			UserManager<AppUser> userManager)
		{
			_webHostEnvironment = webHostEnvironment;
			_appDbContext = appDbContext;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			IEnumerable<Chef> chefs = await _appDbContext.Chefs
				.Include(m => m.SocialMedias)
				.Where(m => !m.IsDeleted)
				.ToListAsync();

			return View(chefs);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			ViewBag.Socials = await GetSocialsAsync();

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Chef chef)
		{
			ViewBag.Socials = await GetSocialsAsync();

			if (!chef.Photo.CheckFileType("image/png"))
			{
				ModelState.AddModelError("Photo", "Please, choose correct image type");
				ViewBag.Socials = await GetSocialsAsync();

				return View(chef);
			}

			if (!chef.Photo.CheckFileSize(1000))
			{
				ModelState.AddModelError("Photo", "Please, choose correct image size");
				ViewBag.Socials = await GetSocialsAsync();

				return View(chef);
			}

			string fileName = Guid.NewGuid().ToString() + "_" + chef.Photo.FileName;

			string path = FileType.GetFilePath(_webHostEnvironment.WebRootPath, "assets/images", fileName);

			await FileType.SaveFile(path, chef.Photo);

			List<SocialMedia> socials = new();

			foreach (var socialId in chef.SocialIds)
			{
				SocialMedia socialMedia = new()
				{
					Id = socialId
				};

				socials.Add(socialMedia);
			}

			Chef newChef = new()
			{
				SocialMedias = socials,
				Name = chef.Name,
				Image = fileName,
				ExperienceInYears = chef.ExperienceInYears,
				CreatedAt = DateTime.UtcNow
			};

			await _appDbContext.Chefs.AddAsync(newChef);
			await _appDbContext.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int id)
		{
			Chef? chef = await _appDbContext.Chefs.FirstOrDefaultAsync(s => s.Id == id);
			if (chef is null)
				return NotFound();

			return View(chef);
		}

		[HttpPost]
		[ActionName(nameof(Delete))]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Deletechef(int id)
		{
			Chef? chef = await _appDbContext.Chefs.FirstOrDefaultAsync(s => s.Id == id);
			if (chef is null)
				return NotFound();

			FileService.DeleteFile(_webHostEnvironment.WebRootPath, "assets", "images", chef.Image);

			_appDbContext.Chefs.Remove(chef);
			await _appDbContext.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		private async Task<SelectList> GetSocialsAsync()
		{
			IEnumerable<SocialMedia> socialMedias = await _appDbContext.SocialMedias
				.ToListAsync();

			return new SelectList(socialMedias, "Id", "Social");
		}
		public IActionResult Detail(int id)
		{
			Chef? chef = _appDbContext.Chefs.AsNoTracking().FirstOrDefault(s => s.Id == id);
			if (chef is null)
				return NotFound();


			return View(chef);
		}
	}
}
