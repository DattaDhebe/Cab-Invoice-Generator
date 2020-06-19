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
        /// Gets or sets aInitializes a new instance of the <see cref="InvoiceService" /> class.
        /// </summary>
        public InvoiceService.Travel Travel { get; set; }

        /// <summary> 
        /// Gets or sets a variable Indicating Distance for Ride
        /// </summary>
        public double Distance { get; set; }

        /// <summary> 
        /// Gets or sets a variable Indicating Time for Ride
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ride" /> class.
        /// </summary>
        /// <param name="travel">to add new Ride</param>
        /// <param name="distance">distance traveled</param>
        /// <param name="time">time Required to travel</param>
        public Ride(InvoiceService.Travel travel, double distance, int time)
        {
            this.Travel = travel;
            this.Distance = distance;
            this.Time = time;
        }
    }
}
