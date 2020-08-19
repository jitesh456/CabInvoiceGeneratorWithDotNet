// <copyright file="InvoiceSummary.cs" company="BridgeLabzSolution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CabInvoiceGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Return Summary Of Invoice.
    /// </summary>
    public class InvoiceSummary
    {
        private readonly int noOfRide;
        private readonly double totalFair;
        private readonly double averageFair;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceSummary"/> class.
        /// </summary>
        /// <param name="noOfRide">contain total no of ride.</param>
        /// <param name="totalFair">contain total fair.</param>
        public InvoiceSummary(int noOfRide, double totalFair)
        {
            this.noOfRide = noOfRide;
            this.totalFair = totalFair;
            this.averageFair = this.totalFair / this.noOfRide;
        }

        /// <summary>
        /// Gets TotalFair return totalFair.
        /// </summary>
        public double TotalFair => this.totalFair;

        /// <summary>
        /// checking for equal method.
        /// </summary>
        /// <param name="obj"> contaon invoice Information.</param>
        /// <returns> return true/false.</returns>
        public override bool Equals(object obj)
        {
            var summary = obj as InvoiceSummary;
            return summary != null &&
                   this.noOfRide == summary.noOfRide &&
                   this.totalFair == summary.totalFair &&
                   this.averageFair == summary.averageFair;
        }

        /// <summary>
        /// For getting HashCode.
        /// </summary>
        /// <returns> return hashcode.</returns>
        public override int GetHashCode()
        {
            return 0;
        }
    }
}
