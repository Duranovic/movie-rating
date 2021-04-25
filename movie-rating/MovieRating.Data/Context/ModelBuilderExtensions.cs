using Bogus;
using Microsoft.EntityFrameworkCore;
using MovieRating.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.Data.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Creating composite primary key for MovieActor and ShowActor tables 
            modelBuilder.Entity<MovieActor>().HasKey(ma => new { ma.ActorId, ma.MovieId });
            modelBuilder.Entity<ShowActor>().HasKey(sa => new { sa.ActorId, sa.ShowId });

            // Seeding data

            Random random = new Random();

            var actorFaker = new Faker<Actor>();
            List<Actor> actors = actorFaker
                .RuleFor(x => x.Id, y => ++y.IndexVariable)
                .RuleFor(x => x.FirstName, y => y.Person.FirstName)
                .RuleFor(x => x.LastName, y => y.Person.LastName)
                .Generate(50);

            var moviesFaker = new Faker<Movie>();
            List<Movie> movies = moviesFaker
                .RuleFor(x => x.Id, y => ++y.IndexVariable)
                .RuleFor(x => x.Title, y => y.Commerce.ProductName())
                .RuleFor(x => x.CoverImageUrl, y => y.Image.PicsumUrl())
                .RuleFor(x => x.Description, y => y.Commerce.ProductDescription())
                .RuleFor(x => x.ReleaseDate, y => y.Date.Future())
                .Generate(25);

            var showsFaker = new Faker<Show>();
            List<Show> shows = showsFaker
                .RuleFor(x => x.Id, y => ++y.IndexVariable)
                .RuleFor(x => x.Title, y => y.Person.FullName)
                .RuleFor(x => x.CoverImageUrl, y => y.Image.PicsumUrl())
                .RuleFor(x => x.Description, y => y.Commerce.ProductDescription())
                .RuleFor(x => x.StartYear, y => y.Random.Number(2005, 2010))
                .RuleFor(x => x.EndYear, y => y.Random.Number(2010, 2020))
                .Generate(25);

            List<MovieActor> movieActor = new List<MovieActor>();
            foreach (var item in movies)
            {
                movieActor.Add(
                new MovieActor()
                {
                    MovieId = item.Id,
                    ActorId = random.Next(1, 25)
                }
                );
                movieActor.Add(new MovieActor()
                {
                    MovieId = item.Id,
                    ActorId = random.Next(26, 50)
                });
            }

            List<ShowActor> showActor = new List<ShowActor>();
            foreach (var item in shows)
            {
                showActor.Add(new ShowActor()
                {
                    ShowId = item.Id,
                    ActorId = random.Next(1, 25)
                }
                );
                showActor.Add(new ShowActor()
                {
                    ShowId = item.Id,
                    ActorId = random.Next(26, 50)
                });
            }


            var tvSeasonFaker = new Faker<TvSeason>();
            List<TvSeason> tvSeason = new List<TvSeason>();

            foreach (var item in shows)
            {
                tvSeason.AddRange(tvSeasonFaker
                    .RuleFor(x => x.Id, y => ++y.IndexVariable)
                    .RuleFor(x => x.Summary, y => y.Company.CatchPhrase())
                    .RuleFor(x => x.ShowId, item.Id)
                    .RuleFor(x => x.SeasonNumber, y => ++y.IndexVariable)
                    .Generate(random.Next(1, 5)));
            }

            var tvEpisodeFaker = new Faker<TvEpisode>();
            List<TvEpisode> tvEpisode = new List<TvEpisode>();

            foreach (var item in tvSeason)
            {
                tvEpisode.AddRange(tvEpisodeFaker
                    .RuleFor(x => x.Id, y => ++y.IndexVariable)
                    .RuleFor(x => x.Summary, y => y.Lorem.Sentence(10, 30))
                    .RuleFor(x => x.TvSeasonId, item.Id)
                    .RuleFor(x => x.Title, y => y.Lorem.Sentence(5, 10))
                    .Generate(random.Next(8, 20)));
            }

            var ratingMovieFaker = new Faker<RatingMovie>();
            List<RatingMovie> ratingMovie = new List<RatingMovie>();

            foreach (var item in movies)
            {
                ratingMovie.AddRange(ratingMovieFaker
                    .RuleFor(x => x.Id, y => ++y.IndexVariable)
                    .RuleFor(x => x.MovieId, item.Id)
                    .RuleFor(x => x.Stars, y => y.Random.Number(1, 5))
                    .Generate(random.Next(1, 20)));
            }

            var ratingShowFaker = new Faker<RatingShow>();
            List<RatingShow> ratingShow = new List<RatingShow>();

            foreach (var item in shows)
            {
                ratingShow.AddRange(ratingShowFaker
                    .RuleFor(x => x.Id, y => ++y.IndexVariable)
                    .RuleFor(x => x.ShowId, item.Id)
                    .RuleFor(x => x.Stars, y => y.Random.Number(1, 5))
                    .Generate(random.Next(1, 20)));
            }

            modelBuilder.Entity<Actor>().HasData(actors);
            modelBuilder.Entity<Movie>().HasData(movies);
            modelBuilder.Entity<Show>().HasData(shows);
            modelBuilder.Entity<MovieActor>().HasData(movieActor);
            modelBuilder.Entity<ShowActor>().HasData(showActor);
            modelBuilder.Entity<TvSeason>().HasData(tvSeason);
            modelBuilder.Entity<TvEpisode>().HasData(tvEpisode);
            modelBuilder.Entity<RatingMovie>().HasData(ratingMovie);
            modelBuilder.Entity<RatingShow>().HasData(ratingShow);
        }
    }
}
