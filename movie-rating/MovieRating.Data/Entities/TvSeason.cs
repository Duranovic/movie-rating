using System.Collections.Generic;

namespace MovieRating.Data.Entities
{
    public class TvSeason
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public int SeasonNumber { get; set; }
        public int ShowId { get; set; }
        public Show Show { get; set; }
        public ICollection<TvEpisode> Episodes { get; set; }
    }
}
