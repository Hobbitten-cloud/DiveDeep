namespace DiveDeepProject.Models.Domain
{
    public class SnorkelSet
    {
        public int Id { get; set; }
        //public string Model { get; set; }
        //public string Description { get; set; }
        //public string Brand { get; set; }
        //public double PricePerDay { get; set; }
        //public string ImagePath { get; set; } = "lib/Public/DesignImageTemplate.png";

        public Product Product { get; set; } = null!;
        public int ProductId { get; set; }

        public SnorkelSet()
        {

        }
    }
}
