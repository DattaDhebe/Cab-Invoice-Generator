//-----------------------------------------------------------------------
// <copyright file="CabInvoiceException.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

namespace Cab_Fare_Problem
{
    using System;

    /// <summary>
    /// Class For Handling Custom Exception
    /// </summary>
    public class CabInvoiceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CabInvoiceException" /> class.
        /// </summary>
        /// <param name="type">Exception Type for Specification</param>
        /// <param name="message">Exception Message For Understanding Exception</param>
        public CabInvoiceException(ExceptionType type, string message) : base(message)
        {
            this.Type = type;
        }

        /// <summary>
        /// Custom Specify Exception Constant
        /// </summary>
        public enum ExceptionType
        {
            /// <summary>
            /// if Entered Data is Empty
            /// </summary>
            Empty_data,

            /// <summary>
            /// if Entered Data is Null
            /// </summary>
            Null_Entered,

            /// <summary>
            /// if Wrong User Id Entered
            /// </summary>
            Wrong_User_Id
        }

        /// <summary>
        /// Gets or sets Exception Type with Declaration
        /// </summary>
        public ExceptionType Type { get; set; }
    }
}
