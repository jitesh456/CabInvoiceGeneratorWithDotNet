// <copyright file="RideType.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// contain info of ride Type.
    /// </summary>
    public class RideType
    {
        /// <summary>
        /// Store Info of NormalType.
        /// </summary>
       public static readonly RideType Normal = new RideType(10, 1, 5);

        /// <summary>
        /// Store Info of NormalType.
        /// </summary>
       public static readonly RideType Primium = new RideType(15, 2, 10);

       private int costPerKiloMeter;
       private int costPerMinute;
       private int minimumFair;

        /// <summary>
        /// Initializes a new instance of the <see cref="RideType"/> class.
        /// </summary>
        /// <param name="costPerKiloMeter"> cost per kilometer.</param>
        /// <param name="costPerMinute">cost per minute.</param>
        /// <param name="minimumFair">minimumcost.</param>
       public RideType(int costPerKiloMeter,  int costPerMinute, int minimumFair)
        {
            this.costPerKiloMeter = costPerKiloMeter;
            this.costPerMinute = costPerMinute;
            this.minimumFair = minimumFair;
        }

        /// <summary>
        /// Gets Return cost per kiometer.
        /// </summary>
       public int CostPerKiloMeter => this.costPerKiloMeter;

        /// <summary>
        /// Gets Return cost per minute.
        /// </summary>
       public int CostPerMinute => this.costPerMinute;

        /// <summary>
        /// Gets Return minimumFair.
        /// </summary>
       public int MinumumFair => this.minimumFair;
    }
}
