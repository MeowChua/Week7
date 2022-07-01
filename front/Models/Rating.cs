namespace front.Models
{
    public class Rating
    {
        public Rating() { }
        public int IdProduct { get; set; }
        public int rating { get; set; }
        public int Id { get; set; }
        public Rating(int pr, int id, int rating)
        {
            Id = id;
            IdProduct = pr;
            rating = rating;
        }
    }
}
