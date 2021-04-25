namespace MovieRating.Data.Entities
{
    public class RatingShow
    {
        public int Id { get; set; }
        public int ShowId { get; set; }
        public Show Show { get; set; }
        public int Stars { get; set; }
    }
}
