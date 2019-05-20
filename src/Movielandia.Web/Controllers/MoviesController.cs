using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movielandia.Common;
using Movielandia.Common.ViewModels;
using Movielandia.Services.Interfaces;

namespace Movielandia.Web.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IMapper mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            this.movieService = movieService;
            this.mapper = mapper;
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(AddMovieBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var movie = this.movieService.Add(model);

            return RedirectToAction("All", "Movies");
        }

        public IActionResult All()
        {
            var movies = (this.movieService.GetAll())
                .Select(this.mapper.Map<AllMoviesViewModel>);

            return View(new MovieOrderViewModel()
            {
                Movies = movies
            });
        }

        public IActionResult Details(int id)
        {
            var movie =  this.movieService.ShowDetails(id);

            if (movie==null)
            {
                return  NotFound();
            }
            
            var movieView =  this.mapper.Map<MovieViewModel>(movie);

            return this.View(movieView);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = this.movieService.Get(id);

            if (movie == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            var viewModel =this.mapper.Map<EditMovieViewModel>(movie);

            return this.View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(EditMovieViewModel model, int id)
        {
            this.movieService.Delete(id);

            return RedirectToAction("All", "Movies");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = this.movieService.Get(id);

            if (movie == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            var viewModel = this.mapper.Map<EditMovieViewModel>(movie);

            return this.View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(EditMovieViewModel model)
        {
            this.movieService.Edit(model);

            return this.RedirectToAction("All", "Movies");
        }
    }
}