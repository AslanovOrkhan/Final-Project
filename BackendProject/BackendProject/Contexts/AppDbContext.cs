﻿using BackendProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.Contexts;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

	public DbSet<Slider> Sliders { get; set; } = null!;
	public DbSet<Service> Services { get; set; } = null!;
	//public DbSet<Chef> Chefs { get; set; } = null!;

}
