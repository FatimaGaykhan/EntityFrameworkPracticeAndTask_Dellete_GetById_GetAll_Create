using System;
using EntityFrameworkConsole.Models;

namespace EntityFrameworkConsole.Services.Interfaces
{
	public interface ICountryService
	{
        Task<List<Country>> GetAllAsync();
        Task<Country> GetByIdAsync(int? id);
        Task CreateAsync(Country country);
        Task UpdateAsync(Country country);
        Task DeleteAsync(int? id);
    }
}

