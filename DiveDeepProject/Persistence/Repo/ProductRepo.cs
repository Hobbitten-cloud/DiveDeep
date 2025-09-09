using DiveDeepProject.Models;
using DiveDeepProject.Models.Enums;
using DiveDeepProject.Models.Inferfaces;
using DiveDeepProject.Persistence.IRepo;
using System.Threading.Tasks;

namespace DiveDeepProject.Persistence.Repo
{
    public class ProductRepo : IRepo<IProduct>, ICreateRepo<IProduct>, IGetRepo<IProduct>
    {
        private List<IProduct> _products;
        public IProduct Create(IProduct product)
        {
            _products.Add(product);
            return product;
        }

        public IProduct Get(int Id)
        {
            return _products.Find(p => p.Id == Id);
        }

        public List<IProduct> GetAll()
        {
            return _products;

        }
        public ProductRepo()
        {

            //Adding Buisness data.
            #region
            _products = new List<IProduct>()
            {
                // ------------------ BCDs ------------------
                new BCD { Id = 1, Brand = "Scubapro", Model = "Navigator Lite BCD", PricePerDay = 125, Description = "Comfortable and durable BCD for all diving levels.", Size = Size.S },
                new BCD { Id = 2, Brand = "Scubapro", Model = "BCD Glide", PricePerDay = 140, Description = "Comfortable and durable BCD for all diving levels.", Size = Size.M },
                new BCD { Id = 3, Brand = "Scubapro", Model = "BCD Hydros Pro", PricePerDay = 200, Description = "Comfortable and durable BCD for all diving levels.", Size = Size.L },
                new BCD { Id = 4, Brand = "Seac", Model = "BCD Modular", PricePerDay = 145, Description = "Comfortable and durable BCD for all diving levels.", Size = Size.S },

                // ------------------ DivingSuit ------------------
                new DivingSuit { Id = 5, Brand = "Scubapro", Model = "Definition", PricePerDay = 100, Description = "3 mm wetsuit for warm water diving.", Gender = Gender.Select, Size = Size.S, Thickness = "3 mm", Type = "Våddragt" },
                new DivingSuit { Id = 6, Brand = "Scubapro", Model = "Definition", PricePerDay = 100, Description = "5 mm wetsuit for versatile diving.", Gender = Gender.Select, Size = Size.M, Thickness = "5 mm", Type = "Våddragt" },
                new DivingSuit { Id = 7, Brand = "Scubapro", Model = "Definition", PricePerDay = 100, Description = "7 mm wetsuit for colder waters.", Gender = Gender.Select, Size = Size.L, Thickness = "7 mm", Type = "Våddragt" },
                new DivingSuit { Id = 8, Brand = "Waterproof", Model = "W5", PricePerDay = 100, Description = "3.5 mm wetsuit, flexible and warm.", Gender = Gender.Select, Size = Size.M, Thickness = "3.5 mm", Type = "Våddragt" },
                new DivingSuit { Id = 9, Brand = "Fourth Element", Model = "Proteus", PricePerDay = 120, Description = "5 mm premium wetsuit.", Gender = Gender.Select, Size = Size.L, Thickness = "5 mm", Type = "Våddragt" },
                new DivingSuit { Id = 10, Brand = "Scubapro", Model = "Exodry 4.0", PricePerDay = 300, Description = "Durable drysuit.", Gender = Gender.Select, Size = Size.XL, Thickness = "N/A", Type = "Tørdragt" },
                new DivingSuit { Id = 11, Brand = "Waterproof", Model = "D7 Evo", PricePerDay = 320, Description = "Advanced drysuit for technical diving.", Gender = Gender.Select, Size = Size.L, Thickness = "N/A", Type = "Tørdragt" },
                new DivingSuit { Id = 12, Brand = "Santi", Model = "E.Lite Plus", PricePerDay = 350, Description = "Top-tier drysuit for professionals.", Gender = Gender.Select, Size = Size.M, Thickness = "N/A", Type = "Tørdragt" },

                // ------------------ Tanks ------------------
                new Tank { Id = 13, Brand = "Scubapro", Volume = "5 L", PricePerDay = 150, Description = "Compact tank, good for short dives." },
                new Tank { Id = 14, Brand = "Scubapro", Volume = "10 L", PricePerDay = 160, Description = "Standard tank for recreational diving." },
                new Tank { Id = 15, Brand = "Scubapro", Volume = "12 L", PricePerDay = 170, Description = "Versatile tank, good for most dives." },
                new Tank { Id = 16, Brand = "Scubapro", Volume = "15 L", PricePerDay = 180, Description = "Large tank for extended dives." },

                // ------------------ Regulators ------------------
                new Regulatorset { Id = 17, Brand = "Scubapro", PricePerDay = 125, Description = "High performance regulator.", FirstStep = "MK25EVO", SecondStep = "S600", Octopus = "R105" },
                new Regulatorset { Id = 18, Brand = "Scubapro", PricePerDay = 100, Description = "Reliable regulator set.", FirstStep = "MK17EVO", SecondStep = "C370", Octopus = "R095" },
                new Regulatorset { Id = 19, Brand = "Scubapro", PricePerDay = 150, Description = "Top-tier regulator with carbon second stage.", FirstStep = "MK25EVO BT", SecondStep = "A700 Carbon BT", Octopus = "S270" },

                // ------------------ SnorkelSet ------------------
                new SnorkelSet { Id = 20, Brand = "Scubapro", Model = "Ghost", PricePerDay = 50, Description = "Frameless mask with wide view." },
                new SnorkelSet { Id = 21, Brand = "Scubapro", Model = "D-Mask", PricePerDay = 60, Description = "Premium diving mask." },
                new SnorkelSet { Id = 22, Brand = "Scubapro", Model = "Spectra Mini", PricePerDay = 50, Description = "Compact mask for smaller faces." },
                new SnorkelSet { Id = 23, Brand = "Scubapro", Model = "Crystal VU", PricePerDay = 75, Description = "Wide field of view mask." },
                new SnorkelSet { Id = 24, Brand = "Fourth Element", Model = "Scout Kontrast", PricePerDay = 75, Description = "Advanced mask for all conditions." },
                new SnorkelSet { Id = 25, Brand = "Fourth Element", Model = "Scout Enhance", PricePerDay = 75, Description = "High clarity mask." },
                new SnorkelSet { Id = 26, Brand = "Tusa", Model = "Element", PricePerDay = 75, Description = "Durable and clear diving mask." },

                // ------------------ Flipper ------------------
                new Flipper { Id = 27, Brand = "Scubapro", Model = "Jet Fin", PricePerDay = 50, Description = "Classic durable fin.", Size = Size.M },
                new Flipper { Id = 28, Brand = "Scubapro", Model = "GO Travel", PricePerDay = 50, Description = "Lightweight travel fin.", Size = Size.S },
                new Flipper { Id = 29, Brand = "Scubapro", Model = "Seawing Supernova", PricePerDay = 60, Description = "High performance split fin.", Size = Size.L },
                new Flipper { Id = 30, Brand = "Seac", Model = "Propulsion", PricePerDay = 50, Description = "Durable and powerful fin.", Size = Size.M },
                new Flipper { Id = 31, Brand = "Seac", Model = "ALA", PricePerDay = 50, Description = "Compact and flexible fin.", Size = Size.S },
                new Flipper { Id = 32, Brand = "Fourth Element", Model = "Tech", PricePerDay = 75, Description = "Strong fin for technical diving.", Size = Size.L },
                new Flipper { Id = 33, Brand = "Fourth Element", Model = "Rec Fin", PricePerDay = 80, Description = "All-round recreational fin.", Size = Size.XL },
            };
            #endregion
        }
    }
}
