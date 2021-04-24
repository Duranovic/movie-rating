using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.Data.Entities
{
    public sealed class Show
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public int Description { get; set; }
        public string CoverImage { get; set; }
        public float AverageRating { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public ICollection<Actor> Actors { get; set; }
    }
}
