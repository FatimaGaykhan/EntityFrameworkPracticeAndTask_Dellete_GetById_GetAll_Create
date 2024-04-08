
//using EntityFrameworkConsole.Data;

//AppDbContext context = new AppDbContext();

//void GetAllSettings()
//{
//    var datas = context.Settings.ToList();
//    foreach (var item in datas)
//    {
//        Console.WriteLine(item.Address +" "+item.Email+" "+item.Phone);
//    }
//}

//GetAllSettings();

//void GetById(int id)
//{
//    var data = context.Settings.FirstOrDefault(m=>m.Id==id);
//    Console.WriteLine(data.Address + " " + data.Email + " " + data.Phone);
//}
//GetById(3);

using EntityFrameworkConsole.Controllers;

//SettingController settingController = new SettingController();
CityController cityController = new CityController();
CountryController countryController = new CountryController();

//await settingController.GetAllAsync();

//await settingController.GetByIdAsync();

//await settingController.CreateAsync();

//await settingController.DeleteAsync();

//await settingController.GetAllAsync();


//await cityController.GetAllByCountryId();

//await cityController.GetByIdAsync();
//await cityController.GetAllAsync();
//await cityController.DeleteAsync();

//await countryController.GetByIdAsync();
await countryController.GetAllAsync();

//await cityController.CreateAsync();

//await countryController.CreateAsync();

//await countryController.DeleteAsync();