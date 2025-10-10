using DiveDeepProject.Models.Domain;
using DiveDeepProject.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DiveDeepProject.ViewModels
{
    public class ProductViewData
    {
        // NOTE 
        // - Everything has to be nullable except the Id because this class is being checked in a custom modelstate
        // - Happens in the ProductController - AddToBasket()


        // Products information
        public int Id { get; set; }
        public string? Brand { get; set; }
        public double PricePerDay { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public List<UnavailableDates>? UnavailableDates { get; set; }

        // General information
        public string? SearchString { get; set; } = string.Empty;
        public List<Product>? Products { get; set; }
        public int? SelectedProductId { get; set; }

        //Domain models information
        public Size? Size { get; set; }
        public string? Model { get; set; }
        public string? Type { get; set; }
        public Gender? Gender { get; set; }
        public string? Thickness { get; set; }
        public string? FirstStep { get; set; }
        public string? SecondStep { get; set; }
        public string? Octopus { get; set; }
        public string? Volume { get; set; }
    }
}
