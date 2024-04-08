using System;
using EntityFrameworkConsole.Data;
using EntityFrameworkConsole.Helpers.Exceptions;
using EntityFrameworkConsole.Models;
using EntityFrameworkConsole.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkConsole.Services
{
	public class CountryService:ICountryService
	{
        private readonly AppDbContext _context;
		public CountryService()
		{
            _context = new AppDbContext();
		}

        public async Task CreateAsync(Country country)
        {
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
        }
       

        public async Task DeleteAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));

            var data = await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);
            if (data is null) throw new NotFoundException("Data Not Found");

            _context.Countries.Remove(data);
            await _context.SaveChangesAsync();
        }


        public async Task<List<Country>> GetAllAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetByIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));
            var result = await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);
            if (result is null) throw new NotFoundException("Data Not Found");
            return result;
        }

        public Task UpdateAsync(Country country)
        {
            throw new NotImplementedException();
        }
    }
}

