using System;
using EntityFrameworkConsole.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkConsole.Data
{
	public class AppDbContext:DbContext
	{
        public DbSet<Setting> Settings { get; set; } = null;

        public DbSet<Country> Countries { get; set; } = null;

        public DbSet<City> Cities { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=EntityFrameworkPB101DB;User Id=sa;Password=Salam123");
        }
    }
}

