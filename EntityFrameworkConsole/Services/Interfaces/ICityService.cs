using System;
using EntityFrameworkConsole.Models;

namespace EntityFrameworkConsole.Services.Interfaces
{
	public interface ICityService
	{
		Task<List<City>> GetAllByCountryIdAsync(int id);
        Task<List<City>> GetAllAsync();
        Task<City> GetByIdAsync(int? id);
        Task CreateAsync(City city);
        Task UpdateAsync(City city);
        Task DeleteAsync(int? id);

    }
}

