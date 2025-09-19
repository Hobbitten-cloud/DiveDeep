using DiveDeepProject.Models;
using DiveDeepProject.Persistence.IRepo;
using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DiveDeepProjectTest
{
    [TestClass]
    public class CheckAvailabilityTest
    {
        //private ProductRepo _productRepo = new ProductRepo();

        [TestInitialize]
        public void Setup()
        {

            // Code to run before each test
   //         _productRepo.Create(new Flipper()
   //         {
   //             Id = 1,
   //             Brand = "SpeedFlipper",
   //             Model = "UsainBolt",
   //             PricePerDay = 300,
   //             Description = "Selv om Usain Bolt ikke er en svømmer, vil du svømme virklig hurtigt",
   //             Size = Size.XL

   //         });
   //         _productRepo.Create(new Flipper()
   //         {
   //             Id = 2,
   //             Brand = "SpeedFlipper",
   //             Model = "Michael Phelps",
   //             PricePerDay = 500,
   //             Description = "hvis du køber disse flippere, så vinder du guld!",
   //             Size = Size.M

   //         });
   //         _productRepo.Create(new Tank()
			//{
			//	Id = 3,
			//	Brand = "Ohaire",
			//	PricePerDay = 100,
			//	Description = "Intet slår luft på dåse",
			//	Volume = "10 L"

			//});

		}

   //     [TestMethod]
   //     public void TestForAvailabilityOnProducts()
   //     {

   //         // Act
   //         //var result = _productRepo.Get(1).CheckAvailability(DateTime.Now, DateTime.Now.AddDays(5));
			//// Assert
			////Assert.AreEqual(false,result);
   //     }
     }
}
