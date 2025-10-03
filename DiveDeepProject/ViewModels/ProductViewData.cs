using DiveDeepProject.Models.Domain;
using DiveDeepProject.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DiveDeepProject.ViewModels
{
    public class ProductViewData
    {
        // Products information
        public int Id { get; set; }
        public string? Brand { get; set; }
        public double PricePerDay { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public List<UnavailableDates>? UnavailableDates { get; set; }


        //Domain models information
        [Required] // We have an issue with the annotation because of this view model Size is now required to be on all products
        public Size? Size { get; set; }
        public string? Model { get; set; }
        public string? Type { get; set; }

        
        [Required] // We have an issue with the annotation because of this view model Gender is now required to be on all products
        public Gender? Gender { get; set; }
        public string? Thickness { get; set; }
        public string? FirstStep { get; set; }
        public string? SecondStep { get; set; }
        public string? Octopus { get; set; }
        public string? Volume { get; set; }
    }
}
