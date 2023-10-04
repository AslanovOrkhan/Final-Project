using BackendProject.ViewModels.BasketViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BackendProject.ViewComponents;

public class HeaderViewComponent : ViewComponent
{
	private readonly AppDbContext _context;
	private readonly UserManager<AppUser> _userManager;
	private readonly IHttpContextAccessor _httpContextAccessor;

	public HeaderViewComponent(AppDbContext context,
		UserManager<AppUser> userManager,
		IHttpContextAccessor httpContextAccessor)
	{
		_context = context;
		_userManager = userManager;
		_httpContextAccessor = httpContextAccessor;
	}

	public async Task<int> GetUserBasketProductsCount(ClaimsPrincipal userClaims)
	{
		var user = await _userManager.GetUserAsync(userClaims);
		if (user == null) return 0;
		var basketProductCount = await _context.BasketProducts.Where(m => m.Basket.AppUserId == user.Id).SumAsync(m => m.Quantity);
		return basketProductCount;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{
		Dictionary<string, string> settings = await _context.Settings.ToDictionaryAsync(s => s.Key, s => s.Value);

		AppUser user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

		var basket = await _context.Baskets
		   .Include(m => m.BasketProducts)
		   .ThenInclude(m => m.Product)
		   .Include(m => m.BasketProducts)
		   .ThenInclude(m => m.Product)
		   .FirstOrDefaultAsync(m => m.AppUserId == user.Id);

		BasketListVM basketList = new();

		if (basket == null) return View(basketList);

		foreach (var dbBasketProduct in basket.BasketProducts)
		{
			BasketProductVM basketProduct = new()
			{
				Id = dbBasketProduct.Id,
				ProductId = dbBasketProduct.ProductId,
				Name = dbBasketProduct.Product.Name,
				Image = dbBasketProduct.Product.Image,
				Quantity = dbBasketProduct.Quantity,
				Price = dbBasketProduct.Product.Price,
				Total = (dbBasketProduct.Product.Price * dbBasketProduct.Quantity),
			};

			basketList.BasketProducts.Add(basketProduct);
		}

		HeaderVM model = new()
		{
			Settings = settings,
			Basket = basketList,
			Count = await GetUserBasketProductsCount(_httpContextAccessor.HttpContext.User)
		};

		return View(model);
	}
}
