using DiveDeepProject.Models;
using DiveDeepProject.Models.Inferfaces;
using DiveDeepProject.Persistence.IRepo;
using DiveDeepProject.Services;

namespace DiveDeepProject.Persistence.Repo
{
	public class PackageRepo : IRepo<Package>, IGetRepo<Package>, ICreateRepo<Package>
	{
		private List<Package> _snorkelPackages;
		private List<Package> _completePackages;
		private SortingService _sortingService;
		private ProductRepo _productRepo;
		public PackageRepo(SortingService sortingService, ProductRepo productRepo)
		{
			_snorkelPackages = new List<Package>();
			_completePackages = new List<Package>();
			_sortingService = sortingService;

			#region
			for (int i = 0; i < 3; i++)
			{
				_snorkelPackages.Add(
				new Package()
				{
					id = i + 1,
					Name = $"Komplet Snorkelsæt {i + 1}",
					Description = "Alt hvad du skal bruge for at komme i gang med snorkling",
					ImagePath = "lib/Public/SnorkelSetProduct.png",
					Products = new List<IProduct>()
					{
						sortingService.SortProductsByCategory(new Category(){Name = "Finner"})[i],
						sortingService.SortProductsByCategory(new Category(){Name = "Maske/snorkel"})[i],
					}
				}
				);
				_completePackages.Add(
				new Package()
				{
					id = i + 3,
					Name = $"Komplet Dykkersæt {i + 1}",
					Description = "Du for helemuleviten du",
                    ImagePath = "lib/Public/DivingSetProduct.png",
                    Products = new List<IProduct>()
					{
						sortingService.SortProductsByCategory(new Category(){Name = "Finner"})[i],
						sortingService.SortProductsByCategory(new Category(){Name = "Maske/snorkel"})[i],
						sortingService.SortProductsByCategory(new Category(){Name = "Dykkerdragter"})[i],
						sortingService.SortProductsByCategory(new Category(){Name = "BCD"})[i],
						sortingService.SortProductsByCategory(new Category(){Name = "Regulatorsæt"})[i],
						sortingService.SortProductsByCategory(new Category(){Name = "Tanke"})[i],
					}
				}
				);
			}
			#endregion
		}
		public Package Create(Package item)
		{
			throw new NotImplementedException();
		}

		public Package Get(int Id)
		{
			return _snorkelPackages.Concat(_completePackages).ToList().Find(p => p.id == Id);
		}

		public List<Package> GetAll()
		{
			throw new NotImplementedException();
		}
		public List<Package> GetAllSnorkelPackages()
		{
			return _snorkelPackages;
		}
		public List<Package> GetAllCompletePackages()
		{
			return _completePackages;
		}
	}
}
