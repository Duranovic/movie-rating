using System;

namespace MovieRating.Data.Entities
{
    public class TvEpisode
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int TvSeasonId { get; set; }
        public TvSeason TvSeason { get; set; }
    }
}
