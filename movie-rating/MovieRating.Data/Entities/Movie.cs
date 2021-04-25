using System;
using System.Collections.Generic;

namespace MovieRating.Data.Entities
{
    public sealed class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
        public ICollection<MovieStar> MovieStars { get; set; }
    }
}
