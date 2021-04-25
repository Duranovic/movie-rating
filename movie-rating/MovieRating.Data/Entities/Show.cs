using System.Collections.Generic;

namespace MovieRating.Data.Entities
{
    public sealed class Show
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public ICollection<ShowActor> ShowActors { get; set; }
    }
}
