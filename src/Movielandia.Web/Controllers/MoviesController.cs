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

        public async Task<IActionResult> All()
        {
            var allMovies = this.movieService.GetAll();
            var viewModels = new List<AllMoviesViewModel>();

            foreach (var movie in allMovies)
            {
                var movieViewModel = this.mapper.Map<AllMoviesViewModel>(movie);
                viewModels.Add(movieViewModel);
            }

            return View(viewModels);
        }
    }
}