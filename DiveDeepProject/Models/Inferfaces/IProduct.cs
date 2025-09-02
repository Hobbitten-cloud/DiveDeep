using Microsoft.AspNetCore.Components.Web;

namespace DiveDeepProject.Models.Inferfaces
{
    public interface IProduct
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public double PricePerDay { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public string GetCategory();
        	
	}
}
