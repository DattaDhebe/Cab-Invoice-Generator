namespace Cab_Fare_Test
{ 
    using Cab_Fare_Problem;
    using NUnit.Framework;

    public class Tests
    { 
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// UC-1.1 : Given Distance and Time should return total Monthly Fare
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ShouldReturnMonthlyFare()
        {
            double distance = 2.0;
            int time = 5;
            double result = InvoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(25, result);
        }

        /// <summary>
        /// UC-1.2 : Given Distance and Time if total Fare is Less then should return Minimum Fare
        /// </summary>
        [Test]
        public void GivenLessDistanceAndTime_ShouldReturnMinimumFare()
        {
            double distance = 0.1;
            int time = 1;
            double result = InvoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(5, result);
        }

        /// <summary>
        /// UC-2 : Given Multiple Rides Should Return Total Fare
        /// </summary>
        [Test]
        public void GivenMultipleRide_ShouldReturnTotalFare()
        {     
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            double fare = InvoiceGenerator.CalculateFare(rides);
            Assert.AreEqual(30, fare);
        }
    }
}