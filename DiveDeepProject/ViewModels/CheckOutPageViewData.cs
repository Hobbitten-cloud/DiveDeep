using DiveDeepProject.Models;
using DiveDeepProject.Models.Domain;
using DiveDeepProject.Persistence.Repo;

namespace DiveDeepProject.ViewModels
{
    public class CheckOutPageViewData
	{
		public Receipt Receipt { get; set; } = new Receipt();
		public Customer Customer { get; set; } = new Customer();


	}
}
