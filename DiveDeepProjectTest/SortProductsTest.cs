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

namespace DiveDeepProjectTest
{
    [TestClass]
    public class SortProductTest
    {
        private ProductRepo _productRepo;
        private SortingService _sortingService;

        [TestInitialize]
        public void Setup()
        {

            // Code to run before each test
            _productRepo = new ProductRepo();
            _productRepo.Create(new Flipper()
            {
                Id = 1,
                Brand = "SpeedFlipper",
                Model = "UsainBolt",
                PricePerDay = 300,
                Description = "Selv om Usain Bolt ikke er en svømmer, vil du svømme virklig hurtigt",
                Size = Size.XL

            });
            _productRepo.Create(new Flipper()
            {
                Id = 2,
                Brand = "SpeedFlipper",
                Model = "Michael Phelps",
                PricePerDay = 500,
                Description = "hvis du køber disse flippere, så vinder du guld!",
                Size = Size.M

            });
            _productRepo.Create(new Tank()
            {
                Id = 3,
                Brand = "Ohaire",
                PricePerDay = 100,
                Description = "Intet slår luft på dåse",
                Volume = "10 L"

            });
            _sortingService = new SortingService(_productRepo);
        }

        [TestMethod]
        public void TestForSortingOfProducts1()
        {
            // Act
            var SortedProducts = _sortingService.SortProducts(new Tank());
            // Assert
            Assert.AreEqual(1, SortedProducts.Count);
        }


        [TestMethod]
        public void TestForSortingOfProductsNULL() //Should return all products
        {
            // Act
            var SortedProducts = _sortingService.SortProducts(null);
            // Assert
            Assert.AreEqual(_productRepo.GetAll().Count, SortedProducts.Count);
        }
    }
}
