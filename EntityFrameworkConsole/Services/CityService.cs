using System;
using EntityFrameworkConsole.Data;
using EntityFrameworkConsole.Helpers.Exceptions;
using EntityFrameworkConsole.Models;
using EntityFrameworkConsole.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkConsole.Services
{
	public class CityService:ICityService
	{
        private readonly AppDbContext _context;
		public CityService()
		{
            _context = new AppDbContext();
		}

        public async Task CreateAsync(City city)
        {
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));

            var data = await _context.Cities.FirstOrDefaultAsync(m => m.Id == id);
            if (data is null) throw new NotFoundException("Data Not Found");

            _context.Cities.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<List<City>> GetAllAsync()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<List<City>> GetAllByCountryIdAsync(int id)
        {
            return await _context.Cities.Include(mn=>mn.country).Where(m => m.CountryId == id).ToListAsync();
        }

        public async Task<City> GetByIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));
            var result= await _context.Cities.FirstOrDefaultAsync(m => m.Id == id);
            if (result is null) throw new NotFoundException("Data Not Found");
            return result;
        }

        public async Task UpdateAsync(City city)
        {
            throw new NotImplementedException();
        }
    }
}

