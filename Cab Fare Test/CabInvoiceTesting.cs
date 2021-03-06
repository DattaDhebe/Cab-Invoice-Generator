//-----------------------------------------------------------------------
// <copyright file="CabInvoiceTesting.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

namespace Cab_Fare_Test
{
    using System;
    using Cab_Fare_Problem;
    using NUnit.Framework;

    /// <summary>
    /// Class For Writing Test Cases
    /// </summary>
    public class CabInvoiceTesting
    {
        /// <summary>
        ///  Creation of InvoiceService Object
        /// </summary>
        private InvoiceService invoiceService = null;

        /// <summary>
        /// Assign InvoiceService Class Object
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.invoiceService = new InvoiceService();
        }

        /// <summary>
        /// Given Distance and Time should return total Monthly Fare
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenCalculated_ShouldReturnMonthlyFare()
        {
            double actual = this.invoiceService.CalculateFare(InvoiceService.Travel.Normal, 2.0, 5);
            double expected = 25;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Given Distance and Time if total Fare is Less then should return Minimum Fare
        /// </summary>
        [Test]
        public void GivenLessDistanceAndTime_WhenCalculated_ShouldReturnMinimumFare()
        {
            double actual = this.invoiceService.CalculateFare(InvoiceService.Travel.Normal, 0.1, 1);
            double expected = 5;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Given Multiple Rides Should Return Total Fare
        /// </summary>
        [Test]
        public void GivenMultipleRide_WhenCalculated_ShouldReturnTotalFare()
        {
            Ride[] rides = 
                            { 
                                new Ride(InvoiceService.Travel.Normal, 2.0, 5), 
                                new Ride(InvoiceService.Travel.Normal, 0.1, 1) 
                            };
            InvoiceSummary summary = this.invoiceService.CalculateFare(rides);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }

        /// <summary>
        /// Given UserId and Rides When Calculated should return Invoice summary
        /// </summary>
        [Test]
        public void GivenUserIdAndRides_WhenCalculated_shouldReturnInvoiceSummary()
        {            
            string userId = "abc@gmail.com";
            this.invoiceService.ValidateUserId(userId);
            Ride[] rides = 
                        {
                            new Ride(InvoiceService.Travel.Normal, 2.0, 5),
                            new Ride(InvoiceService.Travel.Normal, 0.1, 1)
                        };
            this.invoiceService.AddRides(userId, rides);
            InvoiceSummary summary = this.invoiceService.GetInvoiceSummary(userId);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedInvoiceSummary, summary); 
        }

        /// <summary>
        /// Given Distance and Time For Premium ride should return total Monthly Fare
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeForPremiumRide_WhenCalculated_ShouldReturnMonthlyFare()
        {
            double actual = this.invoiceService.CalculateFare(InvoiceService.Travel.Premium, 2.0, 5);
            double expected = 40;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Given Distance and Time for premium ride if total Fare is Less then should return Minimum Fare
        /// </summary>
        [Test]
        public void GivenLessDistanceAndTimeForPremiumRide_WhenCalculated_ShouldReturnMinimumFare()
        {
            double actual = this.invoiceService.CalculateFare(InvoiceService.Travel.Premium, 0.1, 1);
            double expected = 20;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Given Premium Rides when calculated should return Invoice summary
        /// </summary>
        [Test]
        public void GivenPremiumRides_WhenCalculated_shouldReturnInvoiceSummary()
        {
            Ride[] rides = 
                        {
                            new Ride(InvoiceService.Travel.Premium, 2.0, 5),
                            new Ride(InvoiceService.Travel.Premium, 0.1, 1)
                        };
            InvoiceSummary premiumRideSummary = this.invoiceService.CalculateFare(rides);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 60.0);
            Assert.AreEqual(expectedInvoiceSummary, premiumRideSummary);
        }

        /// <summary>
        /// Given Premium and Normal Rides When Calculated should return Invoice Summary
        /// </summary>
        [Test]
        public void GivenPremiumAndNormalRides_WhenCalculated_shouldReturnInvoiceSummary()
        {
            string userId = "abc@gmail.com";
            this.invoiceService.ValidateUserId(userId);
            Ride[] rides = 
                        {
                             new Ride(InvoiceService.Travel.Normal, 2.0, 5),
                             new Ride(InvoiceService.Travel.Normal, 0.1, 1),
                             new Ride(InvoiceService.Travel.Premium, 2.0, 5),
                             new Ride(InvoiceService.Travel.Premium, 0.1, 1)
                        };
            this.invoiceService.AddRides(userId, rides);
            InvoiceSummary summary = this.invoiceService.GetInvoiceSummary(userId);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(4, 90.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }

        /// <summary>
        /// Given Empty Rides when calculated should return Custom Exception
        /// </summary>
        [Test]
        public void GivenEmptyRides_WhenCalculated_shouldReturnCustomException()
        {
            try
            {
                string userId = "abc@gmail.com";
                this.invoiceService.ValidateUserId(userId);
                Ride[] rides = { };
                this.invoiceService.AddRides(userId, rides);
                InvoiceSummary summary = this.invoiceService.GetInvoiceSummary(userId); 
            }
            catch (CabInvoiceException e)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.Empty_data, e.Message);
            }
        }

        /// <summary>
        /// Given Wrong UserId when Validated should return Custom Exception
        /// </summary>
        [Test]
        public void GivenWrongUserId_WhenValidated_shouldReturnCustomException() 
        {
            try
            {
                string userId = "@gmail.com";
                Assert.Throws<CabInvoiceException>(() => this.invoiceService.ValidateUserId(userId)); 
            }
            catch (CabInvoiceException e)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.Wrong_User_Id, e.Message);
            }
        }

        /// <summary>
        /// Given Wrong UserId with Numbers and Dot when validated should return Custom Exception
        /// </summary>
        [Test]
        public void GivenWrongUserIdWithNumbersAndDot_WhenValidated_shouldReturnCustomException()
        {
            try
            {
                string userId = "123.@gmail.com";
                Assert.Throws<CabInvoiceException>(() => this.invoiceService.ValidateUserId(userId));
            }
            catch (CabInvoiceException e)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.Wrong_User_Id, e.Message);
            }
        }
    }
}