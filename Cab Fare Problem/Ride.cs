//-----------------------------------------------------------------------
// <copyright file="Ride.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

namespace Cab_Fare_Problem
{
    /// <summary>
    /// Class For Adding New Rides
    /// </summary>
    public class Ride
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceService" /> class.
        /// </summary>
        public InvoiceService.Travel travel;

        /// <summary>
        /// Variable declaration for Distance
        /// </summary>
        public double distance;

        /// <summary>
        /// Variable declaration for Time
        /// </summary>
        public int time;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ride" /> class.
        /// </summary>
        /// <param name="travel">to add new Ride</param>
        /// <param name="distance">distance traveled</param>
        /// <param name="time">time Required to travel</param>
        public Ride(InvoiceService.Travel travel, double distance, int time)
        {
            this.travel = travel;
            this.distance = distance;
            this.time = time;
        }
    }
}
