using DiveDeepProject.Models.Inferfaces;
using DiveDeepProject.Persistence.IRepo;
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
        private IRepo<IProduct> _productRepo;

        [TestInitialize]
        public void Setup()
        {
            // Code to run before each test
            _productRepo.Create(new IProduct});
        }

        [TestMethod]
        public void TestForAvailabilityOnProducts()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
