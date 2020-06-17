//-----------------------------------------------------------------------
// <copyright file="RideRepository.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

namespace Cab_Fare_Problem
{
    using System.Collections.Generic;

    /// <summary>
    /// RIde Repository Class for Storing UserId and Rides
    /// </summary>
    public class RideRepository
    {
        /// <summary>
        /// To store value in key value pare as UserId and Data
        /// </summary>
        private Dictionary<string, List<Ride>> userRides = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RideRepository" /> class.
        /// </summary>
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        /// <summary>
        /// Add Rides With User Id Using List
        /// </summary>
        /// <param name="userId">Specific User Id</param>
        /// <param name="rides">Add Multiple Ride</param>
        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            if (rideList == false)
            {
                List<Ride> list = new List<Ride>();
                list.AddRange(rides);
                this.userRides.Add(userId, list);
            }
        }
        
        /// <summary>
        /// Given Method Uses Ride Array and returns Invoice Summary of Specific User
        /// </summary>
        /// <param name="userId">Specific User Id</param>
        /// <returns>It Returns Invoice Summary of Specific User</returns>
        public Ride[] GetRides(string userId)
        {
            return this.userRides[userId].ToArray();
        }
    }
}
