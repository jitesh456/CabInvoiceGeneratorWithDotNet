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
            double fair = this.invoiceService.CalculateFair(2.0, 5, RideType.Normal);
            Assert.AreEqual(25, fair);
        }

        /// <summary>
        /// Testing  for Minimum  Fair.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenLessThenMinimumFair_ShouldGenerateTotalFair()
        {
            double fair = this.invoiceService.CalculateFair(0.0, 1, RideType.Normal);
            Assert.AreEqual(5, fair);
        }

        /// <summary>
        /// Testing  for total fair for multiple ride Fair.
        /// </summary>
        [Test]
        public void GivenMultipleRide_ShouldReturnTotalFair()
        {
            List<Ride> rides = new List<Ride>();
            rides.Add(new Ride(2.0, 5, RideType.Normal));
            rides.Add(new Ride(0.0, 1, RideType.Normal));
            InvoiceSummary actualInvoiceSummary = this.invoiceService.CalculateFair(rides);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 30);
            Assert.AreEqual(expectedInvoiceSummary, actualInvoiceSummary);
        }

        /// <summary>
        /// Testing  for total fair for multiple ride Fair.
        /// </summary>
        [Test]
        public void GivenUserIdAndRide_ShouldReturnInvoiceSummary()
        {
            string userId = "S412";
            List<Ride> rides = new List<Ride>()
            {
            new Ride(2.0, 5, RideType.Normal), new Ride(0.0, 1, RideType.Normal),
            };
            this.invoiceService.AddRide(userId, rides);
            InvoiceSummary actualInvoiceSummary = this.invoiceService.GetInvoiceSummary(userId);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 30);
            Assert.AreEqual(expectedInvoiceSummary, actualInvoiceSummary);
        }

        /// <summary>
        /// Test for calculating cost for premimum Ride.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_WhenRideTypePremimum_ShouldGenerateFair()
        {
            double fair = this.invoiceService.CalculateFair(2.0, 5, RideType.Primium);
            Assert.AreEqual(40, fair);
        }

        /// <summary>
        /// Test for calculating cost for multiple premium Rides.
        /// </summary>
        [Test]
        public void GivenMultipleRide_WhenRideTypePremimum_ShouldGenerateFair()
        {
            List<Ride> rides = new List<Ride>();
            rides.Add(new Ride(2.0, 5, RideType.Primium));
            rides.Add(new Ride(0.0, 1, RideType.Primium));
            InvoiceSummary invoiceSummary = this.invoiceService.CalculateFair(rides);
            Assert.AreEqual(50, invoiceSummary.TotalFair);
        }

        /// <summary>
        /// Test for calculating cost for multiple premium nad normal Rides.
        /// </summary>
        [Test]
        public void GivenMultipleRide_WhenRideTypePremimumAndNormal_ShouldGenerateFair()
        {
            List<Ride> rides = new List<Ride>();
            rides.Add(new Ride(2.0, 5, RideType.Primium));
            rides.Add(new Ride(0.0, 1, RideType.Normal));
            InvoiceSummary invoiceSummary = this.invoiceService.CalculateFair(rides);
            Assert.AreEqual(45, invoiceSummary.TotalFair);
        }

        /// <summary>
        /// Test for Invalid userId.
        /// </summary>
        [Test]
        public void GivenUserId_WhenNotValid_ShouldGenerateProperMessage()
        {
            string userId = "1412";
            List<Ride> rides = new List<Ride>()
            {
            new Ride(2.0, 5, RideType.Normal), new Ride(0.0, 1, RideType.Normal),
            };
            var ex = Assert.Throws<CabServiceException>(() =>
            this.invoiceService.AddRide(userId, rides));
            Assert.AreEqual(CabServiceException.ExceptionType.PROVIDE_VALID_USER_NAME, ex.GivenExceptionType);
        }

        /// <summary>
        /// Test for null argument.
        /// </summary>
        [Test]
        public void GivenUserId_WhenNull_ShouldGenerateProperMessage()
        {
            string userId = null;
            List<Ride> rides = new List<Ride>()
            {
            new Ride(2.0, 5, RideType.Normal), new Ride(0.0, 1, RideType.Normal),
            };
            var ex = Assert.Throws<CabServiceException>(() =>
            this.invoiceService.AddRide(userId, rides));
            Assert.AreEqual(CabServiceException.ExceptionType.PLEASE_PROVIDE_USERID, ex.GivenExceptionType);
        }
    }
}