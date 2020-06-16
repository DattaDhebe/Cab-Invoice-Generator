namespace Cab_Fare_Test
{ 
    using Cab_Fare_Problem;
    using NUnit.Framework;

    public class Tests
    {
        InvoiceService invoiceService = null;

        [SetUp]
        public void Setup()
        {
            invoiceService = new InvoiceService();
        }

        /// <summary>
        /// Given Distance and Time should return total Monthly Fare
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenCalculated_ShouldReturnMonthlyFare()
        {
            double distance = 2.0;
            int time = 5;
            double result = InvoiceService.CalculateFare(distance, time);
            Assert.AreEqual(25, result);
        }

        /// <summary>
        /// Given Distance and Time if total Fare is Less then should return Minimum Fare
        /// </summary>
        [Test]
        public void GivenLessDistanceAndTime_WhenCalculated_ShouldReturnMinimumFare()
        {
            double distance = 0.1;
            int time = 1;
            double result = InvoiceService.CalculateFare(distance, time);
            Assert.AreEqual(5, result);
        }

        /// <summary>
        /// Given Multiple Rides Should Return Total Fare
        /// </summary>
        [Test]
        public void GivenMultipleRide_WhenCalculated_ShouldReturnTotalFare()
        {
            Ride[] rides = { 
                             new Ride(2.0, 5), 
                             new Ride(0.1, 1) 
            };
            InvoiceSummary summary = invoiceService.CalculateFare(rides);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }

        /// <summary>
        /// Given UserId and Rides When Calculated should return invoice summary
        /// </summary>
        [Test]
        public void GivenUserIdAndRides_WhenCalculated_shouldReturnInvoiceSummary()
        {
            string userId = "abc@g.com";
            Ride[] rides = {
                             new Ride(2.0, 5),
                             new Ride(0.1, 1)
            };
            invoiceService.AddRides(userId, rides);
            InvoiceSummary summary = invoiceService.GetInvoiceSummary(userId);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedInvoiceSummary, summary); 
        }
    }
}