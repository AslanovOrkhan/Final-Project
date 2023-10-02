﻿using Microsoft.EntityFrameworkCore;

namespace BackendProject.ViewComponents;

public class HeaderViewComponent : ViewComponent
{
	private readonly AppDbContext _context;

	public HeaderViewComponent(AppDbContext context)
	{
		_context = context;
	}

	public async Task<IViewComponentResult> InvokeAsync(string test)
	{
	Dictionary<string, string> settings = await _context.Settings.ToDictionaryAsync(s => s.Key, s => s.Value);

	return View(settings);
	}
}
