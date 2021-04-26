using MovieRating.Data.Entities;
using MovieRating.Data.Repository;
using MovieRating.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MovieRating.Core
{
    public interface IMovieService
    {
        Task<Movie> Get(int id);
        Task<ICollection<MovieVM>> GetInRange(int min, int max);
        Task<MovieStar> Add(MovieStar movieStar);
        Task<MovieStar> Update(MovieStar movieStar);
        Task<ICollection<MovieVM>> Search(string term);
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

        public async Task<ICollection<MovieVM>> Search(string term)
        {     
            Regex atLeastNumberRegex = new Regex("at least (.) stars");
            var match = atLeastNumberRegex.Match(term);
            if (match.Success)
            {
                var starNumber = int.Parse(match.Groups[1].Value);
                return await Task.FromResult(ObjectFactory(starNumber).Where(x => x.Rating >= starNumber).ToList());
            }

            Regex exactNumberRegex = new Regex("(.) stars");
            match = exactNumberRegex.Match(term);
            if (match.Success)
            {
                var starNumber = int.Parse(match.Groups[1].Value);
                return await Task.FromResult(ObjectFactory(starNumber).Where(x=>x.Rating == starNumber).ToList());
            }

            var textualSearch = movieRepository.GetAll()
                .Where(x => x.Description.Contains(term) || x.Title.Contains(term))
                .Select(x => new MovieVM
                {
                    CoverImageUrl = x.CoverImageUrl,
                    Description = x.Description,
                    Title = x.Title,
                    ReleaseDate = x.ReleaseDate,
                    YourRate = movieStarRepository.GetAll().Where(y => y.MovieId == x.Id)?.FirstOrDefault()?.Stars,
                    YourRateId = movieStarRepository.GetAll().Where(y => y.MovieId == x.Id)?.FirstOrDefault()?.Id,
                    Rating = Math.Round(ratingMovieRepository.GetAll().Where(y => y.MovieId == x.Id).Average(y => y.Stars)),
                }).ToList();

            return await Task.FromResult(textualSearch);
        }

        public async Task<MovieStar> Add(MovieStar movieStar)
        {
            return await Task.FromResult(movieStarRepository.Add(movieStar));
        }
        public async Task<MovieStar> Update(MovieStar movieStar)
        {
            return await Task.FromResult(movieStarRepository.Update(movieStar));
        }

        private ICollection<MovieVM>ObjectFactory(int starNumber)
        {
            return movieRepository.GetAll().Select(x => new MovieVM
            {
                CoverImageUrl = x.CoverImageUrl,
                Description = x.Description,
                Title = x.Title,
                ReleaseDate = x.ReleaseDate,
                YourRate = movieStarRepository.GetAll().Where(y => y.MovieId == x.Id)?.FirstOrDefault()?.Stars,
                YourRateId = movieStarRepository.GetAll().Where(y => y.MovieId == x.Id)?.FirstOrDefault()?.Id,
                Rating = Math.Round(ratingMovieRepository.GetAll().Where(y => y.MovieId == x.Id).Average(y => y.Stars)),
            }).ToList();
        }
    }
}
