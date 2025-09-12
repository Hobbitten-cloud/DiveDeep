using DiveDeepProject.Models.Enums;
using DiveDeepProject.Models.Inferfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace DiveDeepProject.Models.Domain
{
    public class BCD
    {
        public int Id { get; set; }
        //public string Description { get; set; }
        //public string Brand { get; set; }
        //public double PricePerDay { get; set; }
        public Size? Size { get; set; }
        public string Model { get; set; }
        //public string ImagePath { get; set; } = "lib/Public/DesignImageTemplate.png";

        public Product Product { get; set; } = null!;
        public int ProductId { get; set; }

        public BCD()
        {

        }
    }
}
