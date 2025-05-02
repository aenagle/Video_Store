namespace Video_Store
{
    public class Rental
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int MovieID { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}