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

        InvoiceGenerator invoiceGenerator = new InvoiceGenerator();

        [Test]
        public void GivenDistanceAndTime_ShouldReturnMonthlyFare()
        {
            double distance = 2.0;
            int time = 5;
            double result = InvoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(25, result);
        }

        [Test]
        public void GivenLessDistanceAndTime_ShouldReturnMinimumFare()
        {
            double distance = 0.1;
            int time = 1;
            double result = InvoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void GivenMultipleRide_ShouldReturnTotalFare()
        {     
            Ride[] rides = { new Ride(2.0, 5),
                             new Ride(0.1, 1),
                            };
            double fare = InvoiceGenerator.CalculateFare(rides);
            Assert.AreEqual(30, fare);
        }
    }
}