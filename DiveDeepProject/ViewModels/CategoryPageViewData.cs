using DiveDeepProject.Models.Domain;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace DiveDeepProject.ViewModels
{
    public class CategoryPageViewData
	{
		public List<Category> categories;

		public int SelectedCategoryId;

		public List<Package> snorkelPackages;

		public List<Package> completePackages;

	}
}
