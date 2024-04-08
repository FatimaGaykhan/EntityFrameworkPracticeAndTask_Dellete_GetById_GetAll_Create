using System;
using System.Data;
using System.Net;
using System.Numerics;
using System.Xml.Linq;
using EntityFrameworkConsole.Models;
using EntityFrameworkConsole.Services;
using EntityFrameworkConsole.Services.Interfaces;

namespace EntityFrameworkConsole.Controllers
{
	public class CityController
	{
		private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
		public CityController()
		{
			_cityService = new CityService();
            _countryService = new CountryService();
		}

		public async Task GetAllByCountryId()
		{
			Console.WriteLine("Add country id:");
			int countryId = int.Parse(Console.ReadLine());
			var cities = await _cityService.GetAllByCountryIdAsync(countryId);
            foreach (var item in cities)
            {
                string data = $"City:{item.Name} Country:{item.country.Name}";
                Console.WriteLine(data);
            }
        }

		public async Task GetByIdAsync()
		{
            Console.WriteLine("Add id:");
            int id = Convert.ToInt32(Console.ReadLine());
            try
			{
                var data = await _cityService.GetByIdAsync(id);
                string result = $"City Name:{data.Name}";
                Console.WriteLine(result);

            }
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public async Task GetAllAsync()
		{
			List<City> result = await _cityService.GetAllAsync();

			foreach (var item in result)
			{
                string cities = $"City:{item.Name}";
                Console.WriteLine(cities);
            }
		}

		public async Task CreateAsync()
		{
            try
            {
                Console.WriteLine("Add city name:");
                string cityName = Console.ReadLine();

                Console.WriteLine("Choose country id:");


                List<Country> result = await _countryService.GetAllAsync();

                foreach (var item in result)
                {
                    string countries = $"Country Id:{item.Id} Country name:{item.Name}";
                    Console.WriteLine(countries);
                }
                int id = Convert.ToInt32(Console.ReadLine());

                Country response = await _countryService.GetByIdAsync(id);

                await _cityService.CreateAsync(new City { Name = cityName, CountryId = id });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

		public async Task DeleteAsync()
		{
            Console.WriteLine("Add city id:");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                var data = await _cityService.GetByIdAsync(id);
                if(data is not null)
                {
                    await _cityService.DeleteAsync(id);
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

