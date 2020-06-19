//-----------------------------------------------------------------------
// <copyright file="InvoiceService.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

namespace Cab_Fare_Problem
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class For Performing Calculation To Generate Invoice Summary
    /// </summary>
    public class InvoiceService
    {
        /// <summary>
        /// Normal Ride Constant values for Normal Cost Per Kilometer
        /// </summary>
        public const int NormalCostPerKiloMeter = 10;

        /// <summary>
        /// Normal Ride Constant values for Cost Per KiloMeter
        /// </summary>
        public const int CostPerTime = 1;

        /// <summary>
        /// Normal Ride Constant values for Minimum Fare
        /// </summary>
        public const double MinimumFare = 5;

        /// <summary>
        /// Premium Ride Constant values for Premium Cost Per kilo Meter
        /// </summary>
        public const int PremiumCostPerKiloMeter = 15;

        /// <summary>
        /// Premium Ride Constant values for Premium Cost Per Time
        /// </summary>
        public const int PremiumCostPerTime = 2;

        /// <summary>
        /// Premium Ride Constant values for Premium Minimum Fare
        /// </summary>
        public const double PremiumMinimumFare = 20;

        /// <summary>
        /// Pre-Define Pattern Matching For User Id
        /// </summary>
        private static string patternForEmail = "^[a-zA-Z0-9]+([.][a-zA-Z0-9]+)?@[a-zA-Z0-9]+.[a-zA-Z]{2,4}([.][a-zA-Z]{2})?$";

        /// <summary>
        /// Initializes a new instance of the <see cref="RideRepository" /> class.
        /// </summary>
        private RideRepository rideRepository;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceService" /> class.
        /// </summary>
        public InvoiceService()
        {
            this.rideRepository = new RideRepository();
        }

        /// <summary>
        /// Enum is used to define Travel 
        /// </summary>
        public enum Travel
        {
            /// <summary>
            /// Enum For Premium Ride 
            /// </summary>
            Premium,

            /// <summary>
            /// Enum For Normal Ride 
            /// </summary>
            Normal
        }

        /// <summary>
        /// Given Method Calculate Normal Fare
        /// </summary>
        /// <param name="distance">total distance Traveled</param>
        /// <param name="time">Time used for Traveling</param>
        /// <returns>Based on time and distance it Returns the Fare</returns>
        public double CalculateNormalFare(double distance, int time)
        {
            ////It Calculates The Total Fare Of the Normal Ride
            double totalFare = (distance * NormalCostPerKiloMeter) + (time * CostPerTime);
            return Math.Max(totalFare, MinimumFare);
        }

        /// <summary>
        /// Given Method Calculate Premium Fare
        /// </summary>
        /// <param name="distance">total distance Traveled</param>
        /// <param name="time">Time used for Traveling</param>
        /// <returns>Based on time and distance it Returns the Fare</returns>
        public double CalculatePremiumFare(double distance, int time)
        {
            ////It Calculates The Total Fare Of the Premium Ride
            double totalFare = (distance * PremiumCostPerKiloMeter) + (time * PremiumCostPerTime);
            return Math.Max(totalFare, PremiumMinimumFare);
        }

        /// <summary>
        /// This Method is Used to return Calculated Fare
        /// </summary>
        /// <param name="travel">It contains the information about travel type</param>
        /// <param name="distance">It gives to total distance Travel</param>
        /// <param name="time">It gives the Time</param>
        /// <returns>Based on Travel type it returns the Calculate Fare</returns>
        public double CalculateFare(InvoiceService.Travel travel, double distance, int time)
        {
            if (travel == InvoiceService.Travel.Normal)
            {
                return this.CalculateNormalFare(distance, time);
            }

            return this.CalculatePremiumFare(distance, time);
        }

        /// <summary>
        /// Given Method is Calculate Fare Of Multiple Rides
        /// </summary>
        /// <param name="rides">it gives the Number of Rides to Travel</param>
        /// <returns>It returns the Total Fare of Rides and the Number Of Rides Travel</returns>
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;

            // Foreach is used to traverse all the values of Ride
            foreach (Ride ride in rides)
            {
                // calculate total Fare by Using CalculateFare function
                totalFare += this.CalculateFare(ride.Travel, ride.Distance, ride.Time);
            }

            return new InvoiceSummary(rides.Length, totalFare);
        }

        /// <summary>
        /// Given Method is Used to Add Rides in Ride Repository
        /// </summary>
        /// <param name="userId">the UserId of the User</param>
        /// <param name="rides">number of Rides to Travel</param>
        public void AddRides(string userId, Ride[] rides)
        {
            try
            {
                // if userId is Right then calculate Fare
                bool userIdCheck = this.ValidateUserId(userId);
                if (userIdCheck == true)
                {
                    this.rideRepository.AddRide(userId, rides);
                }
            }
            catch (ArgumentNullException e)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.Null_Entered, e.Message);
            }
        }

        /// <summary>
        /// This Method Calculate the Fare Based On Rides in the Ride Repository
        /// </summary>
        /// <param name="userId">It is Used to get the Ride Information of that UserId</param>
        /// <returns>It returns the Calculated Fare of number of Rides</returns>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            try
            {
                //// if userId is Right then calculate Fare
                bool userIdCheck = this.ValidateUserId(userId);
                if (userIdCheck == true)
                {
                    //// calculate and return Fare of that User Id
                    return this.CalculateFare(this.rideRepository.GetRides(userId));
                }     
                
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.Wrong_User_Id, "Enter Right User Id");               
            }
            catch (ArgumentNullException e)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.Null_Entered, e.Message);
            }
        }

        /// <summary>
        /// Given Method return User Id Validation
        /// </summary>
        /// <param name="email">validation of Email Id as User Id</param>
        /// <returns>if valid it returns true</returns>
        public bool ValidateUserId(string email)
        {
            // check if Given Userd Id Matches the pattern or not
            if (Regex.Match(email, patternForEmail).Success)
                return true;
            throw new CabInvoiceException(CabInvoiceException.ExceptionType.Wrong_User_Id, "Enter RIght User Id");
        }
    }
}
