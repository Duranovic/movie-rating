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
    public interface IShowService
    {
        Task<Show> Get(int id);
        Task<ICollection<ShowVM>> GetInRange(int min, int max);
        Task<ICollection<ShowVM>> Search(string searchKey); 
    }
    public class ShowService : IShowService
    {
        readonly IRepository<Show> showRepository;
        readonly IRepository<RatingShow> ratingShowRepository;
        readonly IRepository<MovieStar> showStarRepository;

        public ShowService(
            IRepository<Show> showRepository, 
            IRepository<RatingShow> ratingShowRepository,
            IRepository<MovieStar> showStarRepository)
        {
            this.showRepository = showRepository;
            this.ratingShowRepository = ratingShowRepository;
            this.showStarRepository = showStarRepository;
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
                           }).OrderByDescending(x => x.Rating).ToList()
                   );
        }

        public async Task<ICollection<ShowVM>> Search(string term)
        {
            Regex atLeastNumberRegex = new Regex("at least (.) stars");
            var match = atLeastNumberRegex.Match(term);
            if (match.Success)
            {
                var starNumber = int.Parse(match.Groups[1].Value);
                return await Task.FromResult(ObjectFactory().Where(x => x.Rating >= starNumber).ToList());
            }

            Regex exactNumberRegex = new Regex("(.) stars");
            match = exactNumberRegex.Match(term);
            if (match.Success)
            {
                var starNumber = int.Parse(match.Groups[1].Value);
                return await Task.FromResult(ObjectFactory().Where(x => x.Rating == starNumber).ToList());
            }

            var textualSearch = showRepository.GetAll()
                .Where(x => x.Description.Contains(term) || x.Title.Contains(term))
                .Select(x => new ShowVM
                {
                    Id = x.Id,
                    CoverImageUrl = x.CoverImageUrl,
                    Description = x.Description,
                    Title = x.Title,
                    StartYear = x.StartYear,
                    EndYear = x.EndYear,
                    Rating = Math.Round(ratingShowRepository.GetAll().Where(y => y.ShowId == x.Id).Average(y => y.Stars)),
                }).OrderByDescending(x => x.Rating).ToList();

            return await Task.FromResult(textualSearch);
        }
        private ICollection<ShowVM> ObjectFactory()
        {
            return showRepository.GetAll().Select(x => new ShowVM
            {
                Id = x.Id,
                CoverImageUrl = x.CoverImageUrl,
                Description = x.Description,
                Title = x.Title,
                StartYear = x.StartYear,
                EndYear = x.EndYear,
                Rating = Math.Round(ratingShowRepository.GetAll().Where(y => y.ShowId == x.Id).Average(y => y.Stars)),
            }).OrderByDescending(x => x.Rating).ToList();
        }
    }
}
