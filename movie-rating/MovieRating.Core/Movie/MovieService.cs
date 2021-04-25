using MovieRating.Data.Entities;
using MovieRating.Data.Repository;
using MovieRating.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.Core
{
    public interface IMovieService
    {
        Task<Movie> Get(int id);
        Task<ICollection<MovieVM>> GetInRange(int min, int max);
        Task<MovieStar> Add(MovieStar movieStar);
        Task<MovieStar> Update(MovieStar movieStar);
    }
    public class MovieService : IMovieService
    {
        readonly IRepository<Movie> movieRepository;
        readonly IRepository<RatingMovie> ratingMovieRepository;
        readonly IRepository<MovieStar> movieStarRepository;

        public MovieService(
            IRepository<Movie> movieRepository, 
            IRepository<RatingMovie> ratingMovieRepository,
            IRepository<MovieStar> movieStarRepository)
        {
            this.movieRepository = movieRepository;
            this.ratingMovieRepository = ratingMovieRepository;
            this.movieStarRepository = movieStarRepository;
        }

        public async Task<Movie> Get(int id)
        {
            return await Task.FromResult(movieRepository.Get(id));
        }

        public async Task<ICollection<MovieVM>> GetInRange(int min, int max)
        {
            return await Task.FromResult(movieRepository.GetAll()
                .Skip(min - 1)
                .Take(max - min + 1)
                .Select(x => new MovieVM
                {
                    Id = x.Id,
                    CoverImageUrl = x.CoverImageUrl,
                    Description = x.Description,
                    Title = x.Title,
                    ReleaseDate = x.ReleaseDate,
                    Rating = Math.Round(ratingMovieRepository.GetAll().Where(y => y.MovieId == x.Id).Average(y => y.Stars)),
                    YourRate = movieStarRepository.GetAll().Where(y => y.MovieId == x.Id)?.FirstOrDefault()?.Stars,
                    YourRateId = movieStarRepository.GetAll().Where(y => y.MovieId == x.Id)?.FirstOrDefault()?.Id,
                }).ToList()
                );
        }

        public async Task<MovieStar> Add(MovieStar movieStar)
        {
            return await Task.FromResult(movieStarRepository.Add(movieStar));
        }
        public async Task<MovieStar> Update(MovieStar movieStar)
        {
            return await Task.FromResult(movieStarRepository.Update(movieStar));
        }
    }
}
