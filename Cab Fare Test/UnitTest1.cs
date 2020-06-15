using NUnit.Framework;
using Cab_Fare_Problem;

namespace Cab_Fare_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenDistanceAndTime_ShouldReturnMonthlyFare()
        {
            double distance = 2.0;
            int time = 5;
            double result = InvoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(25, result);
        }
    }
}