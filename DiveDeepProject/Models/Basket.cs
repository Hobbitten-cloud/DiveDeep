using DiveDeepProject.Models.Domain;

namespace DiveDeepProject.Models
{
    public static class Basket
	{
		public static List<Product> Products { get; set; } = new List<Product>();
		public static List<Package> Packages { get; set; } = new List<Package>();
	
		public static int GetAmountOfSpecificProducts(Product product)
		{
			return Products.FindAll(p=> p==product).Count ;
		}

		public static void AddItem(int id, string type) 
		{
			if(type == "product")
			{
				Product product = Products.Find(p => p.Id == id);
				Products.Add(product);
			}
			else if (type == "package")
			{
				Package package = Packages.Find(p => p.id == id);
				Packages.Add(package);
			}
			
		}

		public static void Remove(int id, string type)
		{
			if (type == "product")
			{
				Product product = Products.Find(p => p.Id == id);
				Products.Remove(product);
			}
			else if (type == "package")
			{
				Package package = Packages.Find(p => p.id == id);
				Packages.Remove(package);
			}

		}

		public static List<Product> GetProducts()
		{
			return Products.Distinct().ToList();
		}

		public static List<Package> GetPackages()
		{
			return Packages.Distinct().ToList();
		}
		public static int GetAmountOfSpecificPackages(Package package)
		{
			return Packages.FindAll(p => p == package).Count;
		}
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
