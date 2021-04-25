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
    public interface IShowService
    {
        Task<Show> Get(int id);
        Task<ICollection<ShowVM>> GetInRange(int min, int max);
    }
    public class ShowService : IShowService
    {
        readonly IRepository<Show> showRepository;
        readonly IRepository<RatingShow> ratingShowRepository;

        public ShowService(IRepository<Show> showRepository, IRepository<RatingShow> ratingShowRepository)
        {
            this.showRepository = showRepository;
            this.ratingShowRepository = ratingShowRepository;
        }

        public async Task<Show> Get(int id)
        {
            return await Task.FromResult(showRepository.Get(id));
        }

        public async Task<ICollection<ShowVM>> GetInRange(int min, int max)
        {
            return await Task.FromResult(showRepository.GetAll()
                   .Skip(min - 1)
                   .Take(max - min + 1)
                   .Select(x => new ShowVM
                           {
                               Id = x.Id,
                               CoverImageUrl = x.CoverImageUrl,
                               Description = x.Description,
                               Title = x.Title,
                               StartYear = x.StartYear,
                               EndYear = x.EndYear,
                               Rating = Math.Round(ratingShowRepository.GetAll().Where(y => y.ShowId == x.Id).Average(y => y.Stars))
                           }).ToList()
                           );
        }
    }
}
