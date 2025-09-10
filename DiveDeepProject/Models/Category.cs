using DiveDeepProject.Models.Inferfaces;

namespace DiveDeepProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; } = "Lib/Public/DesignImageTemplate.png";

        public List<IProduct> products;
        
        public Category()
        {
            products = new List<IProduct>();
        }   

    }
}

