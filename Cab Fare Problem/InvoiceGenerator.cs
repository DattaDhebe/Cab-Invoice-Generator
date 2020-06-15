using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Cab_Fare_Problem
{
    public class InvoiceGenerator
    {
        public static int Minimum_Cost_Per_Time = 10;
        public static double Cost_Per_Time = 1;

        public static double CalculateFare(double distance, int time)
        {
            return distance * Minimum_Cost_Per_Time + time * Cost_Per_Time;
        }
    }
}
