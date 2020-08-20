// <copyright file="RideRepository.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// For Storing List of ride.
    /// </summary>
    public class RideRepository
    {
        private Dictionary<string, List<Ride>> rides;

        /// <summary>
        /// Initializes a new instance of the <see cref="RideRepository"/> class.
        /// </summary>
        public RideRepository()
        {
            this.rides = new Dictionary<string, List<Ride>>();
        }

        /// <summary>
        /// Gets or sets for setting / getting values.
        /// </summary>
        public Dictionary<string, List<Ride>> Rides { get => this.rides; set => this.rides = value; }

        /// <summary>
        /// This function is used for adding ride into ride repository.
        /// </summary>
        /// <param name="userId"> contain userId.</param>
        /// <param name="rideList">contain ride ditails.</param>
        public void AddRide(string userId, List<Ride> rideList)
        {
            if (this.rides.ContainsKey(userId))
            {
                this.rides[userId].AddRange(rideList);
            }

            if (!this.rides.ContainsKey(userId))
            {
                this.rides.Add(userId, rideList);
            }
        }
    }
}
