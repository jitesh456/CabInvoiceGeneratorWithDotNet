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
    }
}
