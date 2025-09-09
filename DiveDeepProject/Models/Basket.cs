using DiveDeepProject.Models.Inferfaces;
using DiveDeepProject.Models.Enums;
namespace DiveDeepProject.Models
{
	public static class Basket
	{
		public static List<IProduct> Products { get; set; } = new List<IProduct>() { new BCD { Id = 1, Brand = "Scubapro", Model = "Navigator Lite BCD", PricePerDay = 125, Description = "Comfortable and durable BCD for all diving levels.", Size = Size.S },
				new BCD { Id = 2, Brand = "Scubapro", Model = "BCD Glide", PricePerDay = 140, Description = "Comfortable and durable BCD for all diving levels.", Size = Size.M },
				new BCD { Id = 3, Brand = "Scubapro", Model = "BCD Hydros Pro", PricePerDay = 200, Description = "Comfortable and durable BCD for all diving levels.", Size = Size.L } };// test data
		public static List<Package> Packages { get; set; } = new List<Package>() { 
		new Package()
		{
			Name = "Komplet Snorkelsæt 1",
			Description = "Alt hvad du skal bruge for at komme i gang med snorkling",
			Products = new List<IProduct>()
			{
				new BCD { Id = 1, Brand = "Scubapro", Model = "Navigator Lite BCD", PricePerDay = 125, Description = "Comfortable and durable BCD for all diving levels.", Size = Size.S },
				new BCD { Id = 2, Brand = "Scubapro", Model = "BCD Glide", PricePerDay = 140, Description = "Comfortable and durable BCD for all diving levels.", Size = Size.M }
			} 
		},
		new Package()
		{
			Name = "Komplet Snorkelsæt 2",
			Description = "Alt hvad du skal bruge for at komme i gang med snorkling",
			Products = new List<IProduct>()
			{
				new BCD { Id = 3, Brand = "Scubapro", Model = "BCD Hydros Pro", PricePerDay = 200, Description = "Comfortable and durable BCD for all diving levels.", Size = Size.L },
				new BCD { Id = 4, Brand = "Seac", Model = "BCD Modular", PricePerDay = 145, Description = "Comfortable and durable BCD for all diving levels.", Size = Size.S }
			}
		}

		};

		public static double GetTotalPricePerDay()
		{
			double total = 0;
			foreach(var product in Products)
			{
				total += product.PricePerDay;
			}
			foreach (var package in Packages)
			{
				total += package.TotalPricePerDay;
			}
			return total;
		}
	}
}
