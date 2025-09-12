using DiveDeepProject.Models.Enums;
using DiveDeepProject.Models.Inferfaces;
using System.ComponentModel.DataAnnotations;

namespace DiveDeepProject.Models.Domain
{
    public class BCD : IProduct
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public double PricePerDay { get; set; }

        [Required]
        public Size? Size { get; set; }
        public string Model { get; set; }
        public string ImagePath { get; set; } = "lib/Public/DesignImageTemplate.png";
        public BCD()
        {

        }

    }
}
