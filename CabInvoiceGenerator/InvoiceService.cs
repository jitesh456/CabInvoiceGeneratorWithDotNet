// <copyright file="InvoiceService.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Here we have code for generating Invoice.
    /// </summary>
    public class InvoiceService
    {
        private static readonly string NamePattern = "^[A-Z]{1}[0-9]{3}$";

        private readonly Regex regex = new Regex(NamePattern);
        private readonly RideRepository rideRepository = new RideRepository();

        /// <summary>
        /// This function calculate cost.
        /// </summary>
        /// <param name="distance"> store distance covered.</param>
        /// <param name="time">store total time .</param>
        /// <param name="rideType"> store type of ride .</param>
        /// <returns> total fair.</returns>
        public double CalculateFair(double distance, int time, RideType rideType)
        {
            double fair = (distance * rideType.CostPerKiloMeter) + (time * rideType.CostPerMinute);
            return (fair < rideType.MinumumFair) ? rideType.MinumumFair : fair;
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
                totalFair += this.CalculateFair(ride.Distance, ride.Time, ride.RideType);
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
            try
            {
                this.ValidateUserId(userId);
                this.rideRepository.Rides.Add(userId, rides.ToList());
            }
            catch (ArgumentNullException)
            {
                throw new CabServiceException(
                "Plz provide user name.",
                CabServiceException.ExceptionType.PLEASE_PROVIDE_USERID);
            }
        }

        /// <summary>
        /// This function is used for getting List.
        /// </summary>
        /// <param name="userId">contain userId.</param>
        /// <returns> return List.</returns>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            this.ValidateUserId(userId);
            return this.CalculateFair(this.rideRepository.Rides[userId]);
        }

        /// <summary>
        /// This function is used for validating userId.
        /// </summary>
        /// <param name="userId">contain userId.</param>
        private void ValidateUserId(string userId)
        {
            if (!this.regex.IsMatch(userId))
            {
                throw new CabServiceException(
                "User must beging with 1 character and contain 3 numeric value",
                CabServiceException.ExceptionType.PROVIDE_VALID_USER_NAME);
            }
        }
    }
}
