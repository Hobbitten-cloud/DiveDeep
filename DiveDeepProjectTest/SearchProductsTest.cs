using DiveDeepProject.Models;
using DiveDeepProject.Models.Inferfaces;
using DiveDeepProject.Persistence.IRepo;
using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using DiveDeepProject.Services;
using DiveDeepProject.Models.Domain;

namespace DiveDeepProjectTest
{
    [TestClass]
    public class SearchForProductTest
    {
        private ProductRepo _productRepo;
        private SortingService _sortingService;

        [TestInitialize]
        public void Setup()
        {

            // Code to run before each test
            _productRepo = new ProductRepo();
            //_productRepo.Create(new Flipper()
            //{
            //    Id = 1,
            //    Brand = "SpeedFlipper",
            //    Model = "UsainBolt",
            //    PricePerDay = 300,
            //    Description = "Selv om Usain Bolt ikke er en svømmer, vil du svømme virklig hurtigt",
            //    Size = Size.XL

            //});
            //_productRepo.Create(new Flipper()
            //{
            //    Id = 2,
            //    Brand = "SpeedFlipper",
            //    Model = "Michael Phelps",
            //    PricePerDay = 500,
            //    Description = "hvis du køber disse flippere, så vinder du guld!",
            //    Size = Size.M

            //});
            //_productRepo.Create(new Tank()
            //{
            //    Id = 3,
            //    Brand = "Ohaire",
            //    PricePerDay = 100,
            //    Description = "Intet slår luft på dåse",
            //    Volume = "10 L"

            //});
            //_sortingService = new SortingService(_productRepo);
        }

        [TestMethod]
        public void SearchForProduct1()
        {
            // Act
            var FoundProducts = _sortingService.SearchProducts("Usain");
            // Assert
            Assert.AreEqual(1, FoundProducts.Count);
        }

        [TestMethod]
        public void SearchForProduct2()
        {
            // Act
            var FoundProducts = _sortingService.SearchProducts("VoloPyk");
            // Assert
            Assert.IsNull(FoundProducts);
        }
        [TestMethod]
        public void SearchForProduct3()
        {
            // Act
            var FoundProducts = _sortingService.SearchProducts("SpeedFlipper");
            // Assert
            Assert.AreEqual(2,FoundProducts.Count);
        }
    }
}
