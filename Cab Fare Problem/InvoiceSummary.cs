namespace Cab_Fare_Problem
{
    public class InvoiceSummary
    {
        private int numOfRides;
        private double totalFare;
        private double averageFare;

        public InvoiceSummary(int numOfRides, double totalFare)
        {
            this.numOfRides = numOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numOfRides;
        }

        public override bool Equals(object obj)
        {
            return obj is InvoiceSummary summary &&
                   numOfRides == summary.numOfRides &&
                   totalFare == summary.totalFare &&
                   averageFare == summary.averageFare;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
