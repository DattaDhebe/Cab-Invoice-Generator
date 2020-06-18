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

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceSummary" /> class and also find Average Fare.
        /// </summary>
        /// <param name="numOfRides">Find Number Of Rides</param>
        /// <param name="totalFare">To calculate total fare</param>
        public InvoiceSummary(int numOfRides, double totalFare)
        {
            this.numOfRides = numOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numOfRides;
        }

        /// <summary>
        /// Method to find Equals
        /// </summary>
        /// <param name="obj">use object in Invoice Summary to compare</param>
        /// <returns>Return Equal values</returns>
        public override bool Equals(object obj)
        {
            return obj is InvoiceSummary summary &&
                   this.numOfRides == summary.numOfRides &&
                   this.totalFare == summary.totalFare &&
                   this.averageFare == summary.averageFare;
        }

        /// <summary>
        /// Method to return HashCode Of base Method
        /// </summary>
        /// <returns>Return HashCode Of Base Method</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
