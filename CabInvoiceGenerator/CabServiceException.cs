// <copyright file="CabServiceException.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// custom exception class for cab Invoice.
    /// </summary>
    public class CabServiceException : Exception
    {
        private readonly ExceptionType givenExceptionType;

        /// <summary>
        /// Initializes a new instance of the <see cref="CabServiceException"/> class.
        /// </summary>
        /// <param name="message">contain exception Message.</param>
        /// <param name="exceptionType">contain exception type.</param>
        public CabServiceException(string message, ExceptionType exceptionType)
            : base(message)
        {
            this.givenExceptionType = exceptionType;
        }

        /// <summary>
        /// Contain exception Type.
        /// </summary>
        public enum ExceptionType
        {
            /// <summary>
            /// this is used for invalid user Id.
            /// </summary>
            PROVIDE_VALID_USER_NAME,

            /// <summary>
            /// This for empty user id.
            /// </summary>
            PLEASE_PROVIDE_USERID,
        }

        /// <summary>
        /// Gets return excption type.
        /// </summary>
        public ExceptionType GivenExceptionType => this.givenExceptionType;
    }
}
