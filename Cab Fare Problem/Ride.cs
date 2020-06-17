namespace Cab_Fare_Problem
{
    public class Ride
    {
        public InvoiceService.Travel travel;
        public double distance;
        public int time;

        public Ride(InvoiceService.Travel travel, double distance, int time)
        {
            this.travel = travel;
            this.distance = distance;
            this.time = time;
        }
    }
}
