namespace DiveDeepProject.Models
{
    public abstract class Category
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImagePath { get; set; }
    }
}
