﻿// <copyright file="CabInvoice.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Here we have code for generating Invoice.
    /// </summary>
    public class InvoiceService
    {
        private readonly int costPerKiloMeter = 10;
        private readonly int costPerMinute = 1;
        private readonly int minimumCost = 5;
        private RideRepository rideRepository = new RideRepository();

        /// <summary>
        /// This function calculate cost.
        /// </summary>
        /// <param name="distance"> store distance covered.</param>
        /// <param name="time">store total time .</param>
        /// <returns> total fair.</returns>
        public double CalculateFair(double distance, int time)
        {
            double fair = (distance * this.costPerKiloMeter) + (time * this.costPerMinute);
            return (fair < this.minimumCost) ? this.minimumCost : fair;
        }

        /// <summary>
        /// This function calculate fair of multiple ride.
        /// </summary>
        /// <param name="rides">contain information of multiple ride.</param>
        /// <returns> total fair.</returns>
        public InvoiceSummary CalculateFair(List<Ride> rides)
        {
            double totalFair = 0;
            foreach (Ride ride in rides)
            {
                totalFair += this.CalculateFair(ride.Distance, ride.Time);
            }

            return new InvoiceSummary(rides.Count, totalFair);
        }

        /// <summary>
        /// This function is used for AddingRide.
        /// </summary>
        /// <param name="userId"> user id.</param>
        /// <param name="rides"> contain rides info.</param>
        public void AddRide(string userId, List<Ride> rides)
        {
            this.rideRepository.Rides.Add(userId, rides.ToList());
        }

        /// <summary>
        /// This function is used for getting List.
        /// </summary>
        /// <param name="userId">contain userId.</param>
        /// <returns> return List.</returns>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            return this.CalculateFair(this.rideRepository.Rides[userId]);
        }
    }
}