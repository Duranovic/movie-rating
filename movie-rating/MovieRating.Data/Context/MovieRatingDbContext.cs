using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.Data.Context
{
    class MovieRatingDbContext : DbContext
    {
        public MovieRatingDbContext(DbContextOptions<MovieRatingDbContext> options) : base(options)
        {
        }
    }
}
