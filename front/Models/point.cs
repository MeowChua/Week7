namespace front.Models
{
    public class point
    {
        public int points { get; set; }
        public int ProductId { get; set; }
        public point() { }
        public point(int points, int productId)
        {
            this.points = points;
            this.ProductId = productId;
        }
    }
}
