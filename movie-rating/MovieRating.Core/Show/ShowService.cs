using MovieRating.Data.Entities;
using MovieRating.Data.Repository;
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
        Task<ICollection<Show>> GetInRange(int min, int max);
    }
    public class ShowService : IShowService
    {
        readonly IRepository<Show> showRepository;
        public ShowService(IRepository<Show> showRepository)
        {
            this.showRepository = showRepository;
        }

        public async Task<Show> Get(int id)
        {
            return await Task.FromResult(showRepository.Get(id));
        }

        public async Task<ICollection<Show>> GetInRange(int min, int max)
        {
            return  await Task.FromResult(showRepository.GetAll()
                .Skip(min)
                .Take(max - min + 1)
                .ToList());
        }
    }
}
