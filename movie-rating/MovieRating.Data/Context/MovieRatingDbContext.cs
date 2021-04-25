using Bogus;
using Microsoft.EntityFrameworkCore;
using MovieRating.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.Data.Context
{
    public class MovieRatingDbContext : DbContext
    {
        public MovieRatingDbContext(DbContextOptions<MovieRatingDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<TvEpisode> TvEpisodes { get; set; }
        public DbSet<TvSeason> TvSeasons { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<ShowActor> ShowActors { get; set; }
        public DbSet<RatingMovie> RatingMovies { get; set; }
        public DbSet<RatingShow> RatingShows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
