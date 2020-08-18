// <copyright file="CabInvoiceTest.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGeneratorTest
{
    using CabInvoiceGenerator;
    using NUnit.Framework;

    /// <summary>
    /// Class for testing cab Invoice.
    /// </summary>
    public class CabInvoiceTest
    {
        private CabInvoice cabInvoice;

        /// <summary>
        /// Here we put common code that will be used in all method.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.cabInvoice = new CabInvoice();
        }

        /// <summary>
        /// Testing Calculate Fair.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenProper_ShouldGenerateTotalFair()
        {
            double fair = this.cabInvoice.CalculateFair(2.0, 5);
            Assert.AreEqual(25, fair);
        }

        /// <summary>
        /// Testing  for Minimum  Fair.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenLessThenMinimumFair_ShouldGenerateTotalFair()
        {
            double fair = this.cabInvoice.CalculateFair(0.0, 1);
            Assert.AreEqual(5, fair);
        }

        /// <summary>
        /// Testing  for total fair for multiple ride Fair.
        /// </summary>
        [Test]
        public void GivenMultipleRide_ShouldReturnTotalFair()
        {
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.0, 1) };
            InvoiceSummary actualInvoiceSummary = this.cabInvoice.CalculateFair(rides);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 30);
            Assert.AreEqual(actualInvoiceSummary, expectedInvoiceSummary);
        }
    }
}