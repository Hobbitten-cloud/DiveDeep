using DiveDeepProject.Models.Inferfaces;

namespace DiveDeepProject.Models
{
    public class Category
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImagePath { get; set; }

        public List<IProduct> products;
        
        public Category()
        {
            products = new List<IProduct>();
        }   

    }
}
