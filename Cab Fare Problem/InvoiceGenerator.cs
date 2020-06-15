namespace Cab_Fare_Problem
{
    using System;

    public class InvoiceGenerator
    {
        private static int minimumCostPerTime = 10;
        private static double costPerTime = 1;
        private static double minimumFare = 5;

        /// <summary>
        /// Function for Calculating totalFare 
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static double CalculateFare(double distance, int time)
        {
            double totalFare = (distance * minimumCostPerTime) + (time * costPerTime);
            return Math.Max(totalFare, minimumFare);
        }

        /// <summary>
        /// Calculate Fare for multiple Rides
        /// </summary>
        /// <param name="rides"></param>
        /// <returns></returns>
        public static double CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            foreach (Ride ride in rides)
            {
                totalFare += CalculateFare(ride.distance, ride.time);
            }
            return totalFare;
        }
    }
}
