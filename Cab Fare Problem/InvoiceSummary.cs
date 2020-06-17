//-----------------------------------------------------------------------
// <copyright file="InvoiceSummary.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

namespace Cab_Fare_Problem
{
    /// <summary>
    /// Class For Invoice Summary To Number Of Rides and Total Fare
    /// </summary>
    public class InvoiceSummary
    {
        /// <summary>
        /// Declaration of Variable for Number of Rides
        /// </summary>
        private int numOfRides;

        /// <summary>
        /// Declaration of Variable for Total Fare 
        /// </summary>
        private double totalFare;

        /// <summary>
        /// Declaration of Variable for finding Average Fare
        /// </summary>
        private double averageFare;

        public InvoiceSummary(int numOfRides, double totalFare)
        {
            this.numOfRides = numOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numOfRides;
        }

        public override bool Equals(object obj)
        {
            return obj is InvoiceSummary summary &&
                   numOfRides == summary.numOfRides &&
                   totalFare == summary.totalFare &&
                   averageFare == summary.averageFare;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
