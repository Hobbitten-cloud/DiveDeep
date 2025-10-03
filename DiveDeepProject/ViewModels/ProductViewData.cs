using DiveDeepProject.Models.Domain;
using DiveDeepProject.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DiveDeepProject.ViewModels
{
    public class ProductViewData
    {
        // Products information
        //public string ProductType { get; set; }
        public int Id { get; set; }
        public string Brand { get; set; }
        public double PricePerDay { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public List<UnavailableDates>? UnavailableDates { get; set; }


        //Domain models information
        [Required]
        public Size Size { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public string? Thickness { get; set; }
        public string FirstStep { get; set; }
        public string SecondStep { get; set; }
        public string Octopus { get; set; }
        public string Volume { get; set; }



        // Classes
        //public Product Product { get; set; }
        //public DivingSuit DivingSuit { get; set; }
        //public BCD BCD { get; set; }
        //public Flipper Flipper { get; set; }
        //public Regulatorset Regulatorset { get; set; }
        //public SnorkelSet SnorkelSet { get; set; }
        //public Tank Tank { get; set; }
        //public List<UnavailableDates>? UnavailableDates { get; set; }
    }
}
