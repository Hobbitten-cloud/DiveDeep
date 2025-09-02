using DiveDeepProject.Models.Inferfaces;

namespace DiveDeepProject.Models
{
    public class Regulatorset : IProduct
    {
		public static string Category = "Regulatorsæt";
		public int Id { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public double PricePerDay { get; set; }
        public string FirstStep { get; set; }
        public string SecondStep { get; set; }
        public string Octopus { get; set; }


        public Regulatorset() 
        { 

        }

		public string GetCategory()
		{
			return Category;
		}
	}
}
