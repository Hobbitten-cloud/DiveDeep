using DiveDeepProject.Models.Inferfaces;

namespace DiveDeepProject.Models.Domain
{
    public class Regulatorset
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public double PricePerDay { get; set; }
        public string FirstStep { get; set; }
        public string SecondStep { get; set; }
        public string Octopus { get; set; }
        public string ImagePath { get; set; } = "lib/Public/DesignImageTemplate.png";

        public Regulatorset()
        {

        }

    }
}
