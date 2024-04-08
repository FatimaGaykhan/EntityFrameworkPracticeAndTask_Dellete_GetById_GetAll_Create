using System;
namespace EntityFrameworkConsole.Models
{
	public class City:BaseEntity
	{
		public string Name { get; set; }
		public int CountryId { get; set; }
		public Country country { get; set; }

	}
}

