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
    public class ShowController : ControllerBase
    {
        readonly IShowService showService;
        public ShowController(IShowService showService)
        {
            this.showService = showService;
        }

        [HttpGet]
        public async Task<ICollection<ShowVM>> Get([FromQuery] int min, [FromQuery] int max, [FromQuery] string searchKey)
        {
            if (searchKey == null)
                return await showService.GetInRange(min, max);
            else
                return await showService.Search(searchKey);
        }
    }
}
