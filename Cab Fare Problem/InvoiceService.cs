namespace Cab_Fare_Problem
{
    using System;

    public class InvoiceService
    {
        public const int MinimumCostPerTime = 10;
        public const int PremiumCostPerTime = 15;
        public const double CostPerTime = 1;
        public const double MinimumFare = 5;
        private RideRepository rideRepository;

        public InvoiceService()
        {
            this.rideRepository = new RideRepository();
        }
        /// <summary>
        /// Function for Calculating totalFare 
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static double CalculateFare(double distance, int time)
        {
            double totalFare = (distance * MinimumCostPerTime) + (time * CostPerTime);
            return Math.Max(totalFare, MinimumFare);
        }
      
        /// <summary>
        /// Calculate Fare for multiple Rides
        /// </summary>
        /// <param name="rides"></param>
        /// <returns></returns>
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            foreach (Ride ride in rides)
            {
                totalFare += CalculateFare(ride.distance, ride.time);
            }
            return new InvoiceSummary(rides.Length, totalFare);
        }       

        /// <summary>
        /// Add Rides TO Ride Repository
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rides"></param>
        public void AddRides(string userId, Ride[] rides)
        {
            rideRepository.AddRide(userId, rides);
        }

        /// <summary>
        /// Given User Id should get from RideRpository Rides.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            return this.CalculateFare(rideRepository.GetRides(userId));
        }

        public static double PremiumCalculateFare(double distance, int time)
        {
            double totalFare = (distance * PremiumCostPerTime) + (time * CostPerTime);
            return Math.Max(totalFare, MinimumFare);
        }

        public InvoiceSummary PremiumCalculateFare(PremiumRide[] premiumRides)
        {
            double totalFare = 0;
            foreach (PremiumRide ride in premiumRides)
            {
                totalFare += PremiumCalculateFare(ride.distance, ride.time);
            }
            return new InvoiceSummary(premiumRides.Length, totalFare);
        }
    }
}
