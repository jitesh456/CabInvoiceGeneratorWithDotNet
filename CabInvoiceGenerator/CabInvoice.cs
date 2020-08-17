// <copyright file="CabInvoice.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;

    /// <summary>
    /// Here we have code for generating Invoice.
    /// </summary>
    public class CabInvoice
    {
        private readonly int costPerKiloMeter = 10;
        private readonly int costPerMinute = 1;
        private readonly int minimumCost = 5;

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
    }
}
