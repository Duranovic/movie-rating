using MovieRating.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.Data.ViewModels
{
    public class MovieVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
        public int ? YourRate { get; set; }
        public int ? YourRateId { get; set; }
        public MovieStar MovieStar { get; set; }
        public ICollection<Actor> Actors { get; set; }
    }
}
