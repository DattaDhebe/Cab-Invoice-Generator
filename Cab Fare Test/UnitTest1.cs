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
            double result = InvoiceService.CalculateFare(2.0, 5);
            Assert.AreEqual(25, result);
        }

        /// <summary>
        /// Given Distance and Time if total Fare is Less then should return Minimum Fare
        /// </summary>
        [Test]
        public void GivenLessDistanceAndTime_WhenCalculated_ShouldReturnMinimumFare()
        {
            double result = InvoiceService.CalculateFare(0.1, 1);
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
        /// Given UserId and Rides When Calculated should return Invoice summary
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

        /// <summary>
        /// Given Distance and Time For Premium ride should return total Monthly Fare
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForPremiumRide_WhenCalculated_ShouldReturnMonthlyFare()
        {
            double result = InvoiceService.PremiumCalculateFare(2.0, 5);
            Assert.AreEqual(35, result);
        }

        /// <summary>
        /// Given Distance and Time for premium ride if total Fare is Less then should return Minimum Fare
        /// </summary>
        [Test]
        public void GivenLessDistanceAndTimeForPremiumRide_WhenCalculated_ShouldReturnMinimumFare()
        {
            double result = InvoiceService.PremiumCalculateFare(0.1, 1);
            Assert.AreEqual(5, result);
        }

        /// <summary>
        /// Given Premium Rides when calculated should return Invoice summary
        /// </summary>
        [Test]
        public void GivenPremiumRides_WhenCalculated_shouldReturnInvoiceSummary()
        {
            PremiumRide[] premiumRides = {
                            new PremiumRide(2.0, 5),
                            new PremiumRide(0.1, 1)
            };
            InvoiceSummary premiumRideSummary = invoiceService.PremiumCalculateFare(premiumRides);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 40.0);
            Assert.AreEqual(expectedInvoiceSummary, premiumRideSummary);
        }
    }
}