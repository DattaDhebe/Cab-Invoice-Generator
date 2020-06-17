namespace Cab_Fare_Problem
{
    using System;

    public class CabInvoiceException : Exception
    {
        public enum ExceptionType
        {
            Empty_data,
            Null_Entered,
            Wrong_User_Id
        }
        public ExceptionType Type { get; set; }

        public CabInvoiceException(ExceptionType type, string message) : base(message)
        {
            this.Type = type;
        }
    }

}
