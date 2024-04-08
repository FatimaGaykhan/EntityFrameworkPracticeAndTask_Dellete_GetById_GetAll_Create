using System;
using EntityFrameworkConsole.Helpers.Exceptions;
using EntityFrameworkConsole.Models;
using EntityFrameworkConsole.Services;
using EntityFrameworkConsole.Services.Interfaces;

namespace EntityFrameworkConsole.Controllers
{
	public class SettingController
	{
		private readonly ISettingService _settingService;
		public SettingController()
		{
			_settingService = new SettingService();
		}

		public async Task GetAllAsync()
		{
			var datas = await _settingService.GetAllAsync();
			foreach (var item in datas)
			{
				string data = $"Name:{item.Name},Address:{item.Address}, Email:{item.Email},Phone:{item.Phone}";
				Console.WriteLine(data);
			}
		}

		public async Task GetByIdAsync()
		{
            Console.WriteLine("Add id:");
            int id = Convert.ToInt32(Console.ReadLine());
            try
			{
                var data = await _settingService.GetByIdAsync(id);
                string result = $"Name:{data.Name},Address:{data.Address}, Email:{data.Email},Phone:{data.Phone}";
                Console.WriteLine(result);
            }
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
        }

		public async Task CreateAsync()
		{
			Console.WriteLine("Add name:");
			string name = Console.ReadLine();
            Console.WriteLine("Add address:");
            string address = Console.ReadLine();
            Console.WriteLine("Add email:");
            string email = Console.ReadLine();
            Console.WriteLine("Add phone:");
            string phone = Console.ReadLine();

			await _settingService.CreateAsync(new Setting { Name = name, Address = address, Phone = phone, Email = email });
        }

		public async Task DeleteAsync()
		{
            Console.WriteLine("Add id:");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                await _settingService.DeleteAsync(id);
                Console.WriteLine("Data successfully deleted");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
	}
}

