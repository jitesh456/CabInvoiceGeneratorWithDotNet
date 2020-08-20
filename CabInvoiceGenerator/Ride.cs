// <copyright file="Ride.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CabInvoiceGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class for storing ride information.
    /// </summary>
    public class Ride
    {
        private readonly int time;
        private readonly double distance;
        private readonly RideType rideType;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ride"/> class.
        /// </summary>
        /// <param name="distance">store distance of ride.</param>
        /// <param name="time">store time of ride.</param>
        /// <param name="rideType">contain information of ride type.</param>
        public Ride(double distance, int time, RideType rideType)
        {
            this.time = time;
            this.distance = distance;
            this.rideType = rideType;
        }

        /// <summary>
        /// Gets Time function return time.
        /// </summary>
        public int Time => this.time;

        /// <summary>
        /// Gets Distance function return time.
        /// </summary>
        public double Distance => this.distance;

        /// <summary>
        /// Gets Distance function return rideType.
        /// </summary>
        public RideType RideType => this.rideType;
    }
}
