using DiveDeepProject.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DiveDeepProject.Models.Domain
{
    public class DivingSuit
    {
        public int Id { get; set; }
        //public string Description { get; set; }
        //public string Brand { get; set; }
        //public double PricePerDay { get; set; }
        //public string ImagePath { get; set; } = "lib/Public/DesignImageTemplate.png";

        [Required]
        public Size Size { get; set; }
       
        public string Type { get; set; }
        
        [Required]
        public Gender Gender { get; set; }
        
        [Required]
        public string Thickness { get; set; }
        
        public string Model { get; set; }

        public Product Product { get; set; } = null!;
        public int ProductId { get; set; }

        public DivingSuit()
        {

        }


    }
}
