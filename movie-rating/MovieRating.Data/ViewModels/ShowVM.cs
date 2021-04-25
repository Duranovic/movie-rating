using MovieRating.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.Data.ViewModels
{
    public class ShowVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public double Rating { get; set; }
        public ICollection<ShowActor> ShowActors { get; set; }
    }
}
