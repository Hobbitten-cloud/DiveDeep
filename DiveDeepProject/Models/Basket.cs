using DiveDeepProject.Models.Domain;

namespace DiveDeepProject.Models
{
    public static class Basket
	{
		public static List<Product> Products { get; set; } = new List<Product>();
		public static List<Package> Packages { get; set; } = new List<Package>();
	

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
