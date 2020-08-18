// <copyright file="Ride.cs" company="PlaceholderCompany">
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Ride"/> class.
        /// </summary>
        /// <param name="distance">store distance of ride.</param>
        /// <param name="time">store time of ride.</param>
        public Ride(double distance, int time)
        {
            this.time = time;
            this.distance = distance;
        }

        /// <summary>
        /// Gets Time function return time.
        /// </summary>
        public int Time => this.time;

        /// <summary>
        /// Gets Distance function return time.
        /// </summary>
        public double Distance => this.distance;
    }
}
