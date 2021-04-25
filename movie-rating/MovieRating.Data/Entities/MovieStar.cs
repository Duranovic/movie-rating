using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.Data.Entities
{
    /* Because we don't use any authentification, this class will be used to store 
       User rating for movies 
    */
    public class MovieStar
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int Stars { get; set; }
    }
}
