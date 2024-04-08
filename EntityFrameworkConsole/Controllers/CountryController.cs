using System;
using EntityFrameworkConsole.Models;
using EntityFrameworkConsole.Services;
using EntityFrameworkConsole.Services.Interfaces;

namespace EntityFrameworkConsole.Controllers
{
	public class CountryController
	{
		private readonly ICountryService _countryService;
		public CountryController()
		{
			_countryService = new CountryService();
		}

        public async Task GetByIdAsync()
        {
            Console.WriteLine("Add id:");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                var data = await _countryService.GetByIdAsync(id);
                string result = $"Country Name:{data.Name}";
                Console.WriteLine(result);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task GetAllAsync()
        {
            List<Country> result = await _countryService.GetAllAsync();

            foreach (var item in result)
            {
                string countries = $"Country:{item.Name}";
                Console.WriteLine(countries);
            }
        }

        public async Task CreateAsync()
        {
            try
            {
                Console.WriteLine("Add country name:");
                string countryName = Console.ReadLine();

                await _countryService.CreateAsync(new Country { Name = countryName});
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteAsync()
        {
            Console.WriteLine("Add country id:");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                var data = await _countryService.GetByIdAsync(id);
                if (data is not null)
                {
                    await _countryService.DeleteAsync(id);
                    Console.WriteLine("Data successfully deleted");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

