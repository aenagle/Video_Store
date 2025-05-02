namespace Video_Store
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Director Director { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
        public string Country { get; set; }
        public double Rating { get; set; }
    }
}
