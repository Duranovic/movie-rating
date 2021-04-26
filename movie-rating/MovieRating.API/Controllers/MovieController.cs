using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieRating.Core;
using MovieRating.Data.Entities;
using MovieRating.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRating.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        readonly IMovieService movieService;
        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet]
        public async Task<ICollection<MovieVM>> Get([FromQuery] int min, [FromQuery] int max, [FromQuery] string searchKey)
        {
            if(searchKey == null)
                return await movieService.GetInRange(min, max);
            else
                return await movieService.Search(searchKey);
        }

        [HttpPut]
        public async Task<MovieStar> Update([FromBody] MovieStar movieStar)
        {
            return await movieService.Update(movieStar);
        }

        [HttpPost]
        public async Task<MovieStar> Add([FromBody] MovieStar movieStar)
        {
            return await movieService.Add(movieStar);
        }
    }
}
