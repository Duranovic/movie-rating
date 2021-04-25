namespace MovieRating.Data.Entities
{
    public class RatingMovie
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int Stars { get; set; }
    }
}
