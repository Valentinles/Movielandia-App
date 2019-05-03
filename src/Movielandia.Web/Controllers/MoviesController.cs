using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movielandia.Common.ViewModels;
using Movielandia.Services.Interfaces;

namespace Movielandia.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IMapper mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            this.movieService = movieService;
            this.mapper = mapper;
        }

        public IActionResult All()
        {
            var movies = (this.movieService.GetAll())
                .Select(this.mapper.Map<AllMoviesViewModel>);

            return View(movies);
        }
    }
}