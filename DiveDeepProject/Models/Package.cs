using DiveDeepProject.Models.Inferfaces;

namespace DiveDeepProject.Models
{
    public class Package
    {
        public List<IProduct> Products { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; } = "Lib/Public/DesignImageTemplate.png";

    }
}
