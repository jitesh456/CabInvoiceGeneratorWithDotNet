// <copyright file="CabInvoiceTest.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGeneratorTest
{
    using System.Collections.Generic;
    using CabInvoiceGenerator;
    using NUnit.Framework;

    /// <summary>
    /// Class for testing cab Invoice.
    /// </summary>
    public class CabInvoiceTest
    {
        private InvoiceService invoiceService;

        /// <summary>
        /// Here we put common code that will be used in all method.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.invoiceService = new InvoiceService();
        }

        /// <summary>
        /// Testing Calculate Fair.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenProper_ShouldGenerateTotalFair()
        {
            double fair = this.invoiceService.CalculateFair(2.0, 5);
            Assert.AreEqual(25, fair);
        }

        /// <summary>
        /// Testing  for Minimum  Fair.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenLessThenMinimumFair_ShouldGenerateTotalFair()
        {
            double fair = this.invoiceService.CalculateFair(0.0, 1);
            Assert.AreEqual(5, fair);
        }

        /// <summary>
        /// Testing  for total fair for multiple ride Fair.
        /// </summary>
        [Test]
        public void GivenMultipleRide_ShouldReturnTotalFair()
        {
            List<Ride> rides = new List<Ride>();
            rides.Add(new Ride(2.0, 5));
            rides.Add(new Ride(0.0, 1));
            InvoiceSummary actualInvoiceSummary = this.invoiceService.CalculateFair(rides);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 30);
            Assert.AreEqual(actualInvoiceSummary, expectedInvoiceSummary);
        }

        /// <summary>
        /// Testing  for total fair for multiple ride Fair.
        /// </summary>
        [Test]
        public void GivenUserIdAndRide_ShouldReturnInvoiceSummary()
        {
            string userId = "S41";
            List<Ride> rides = new List<Ride>();
            rides.Add(new Ride(2.0, 5));
            rides.Add(new Ride(0.0, 1));
            this.invoiceService.AddRide(userId, rides);
            InvoiceSummary actualInvoiceSummary = this.invoiceService.GetInvoiceSummary(userId);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 30);
            Assert.AreEqual(actualInvoiceSummary, expectedInvoiceSummary);
        }
    }
}