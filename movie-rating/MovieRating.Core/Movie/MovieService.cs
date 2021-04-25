using MovieRating.Data.Entities;
using MovieRating.Data.Repository;
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
        Task<ICollection<Movie>> GetInRange(int min, int max);
    }
    public class MovieService : IMovieService
    {
        readonly IRepository<Movie> movieRepository;
        public MovieService(IRepository<Movie> movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public async Task<Movie> Get(int id)
        {
            return await Task.FromResult(movieRepository.Get(id));
        }

        public async Task<ICollection<Movie>> GetInRange(int min, int max)
        {
            return await Task.FromResult(movieRepository.GetAll()
                .Skip(min - 1)
                .Take(max - min + 1)
                .ToList());
        }
    }
}
